using KFC_Base;
using System.Windows.Forms;
using Microsoft.FSharp.Collections;
using System;
using Microsoft.FSharp.Core;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Drawing;

namespace KFCFront
{
    public partial class FrontForm : Form
    {
        private JsonDB db;
        private FSharpList<KFCItemsBase> selectedItems;
        private Bitmap photo;
        public FrontForm(string file)
        {
            this.db = new JsonDB(file);
            this.photo = Properties.Resources.photo;
            InitializeComponent();

        }
        private void DescriptionItem(KFCItemsBase item)
        {
            string label = item.Name + "\nЦена: " + item.Price;
            string desc = $"КБЖУ на 100г \nКкал: {item.Kcal}\tБ: {item.Proteins}\tЖ: {item.Fats}\tУ: {item.Carbohydrates}\n";
            desc += $"Вес: {item.Weight}\n";
            //
            if (item is Burger)
            {
                Burger b = (Burger)item;
                if (b.Spicy)
                    desc += $"Острота: Да\n";
                else
                    desc += $"Острота: Да\n";

            }
            if (item is FriedChicken)
            {
                FriedChicken ch = (FriedChicken)item;
                desc += $"Количество: {ch.Count}\n";
            }
            if (item is Snack)
            {
                Snack s = (Snack)item;
                desc += $"Размер: {sizeString.SizeToString(s.Size)}\n";
            }
            if (item is Drink)
            {
                Drink d = (Drink)item;
                desc += $"Размер: {sizeString.SizeToString(d.Size)}\n";
                if (d.Hot)
                    desc += $"Горячий напиток: Да\n";
                else
                    desc += $"Холодный напиток: Да\n";
            }
            desc += item.Compound;
            this.label2.Text = label;
            this.label1.Text = desc;
            this.pictureBox1.Image = photo;
            this.pictureBox1.LoadAsync(item.PictureURL);
        }

        private void sorting(FSharpList<KFCItemsBase> list) {
            Func<KFCItemsBase, KFCItemsBase, int> sortFunc = (a, b) => 0;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    sortFunc = (a, b) => a.Name.CompareTo(b.Name);
                    break;
                case 1:
                    sortFunc = (a, b) => b.Name.CompareTo(a.Name);
                    break;
                case 2:
                    sortFunc = (a, b) => a.Price.CompareTo(b.Price);
                    break;
                case 3:
                    sortFunc = (a, b) => b.Price.CompareTo(a.Price);
                    break;
            }
            this.selectedItems = JsonDB.Sorted(list, FuncConvert.FromFunc(sortFunc));
            listBox1.Items.Clear();
            ListModule.Iterate(FuncConvert.FromAction<KFCItemsBase>(x => listBox1.Items.Add(x.Name)), selectedItems);

        }

        private void всёМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FSharpList<KFCItemsBase> list = FSharpList<KFCItemsBase>.Empty;
            list = db.Menu();
            sorting(list);
        }

        private void бургерыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FSharpList<KFCItemsBase> list = FSharpList<KFCItemsBase>.Empty;
            list = db.GetAllBurgers();
            sorting(list);
        }

        private void курицаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FSharpList<KFCItemsBase> list = FSharpList<KFCItemsBase>.Empty;
            list = db.GetAllChicken();
            sorting(list);
        }

        private void снекиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FSharpList<KFCItemsBase> list = FSharpList<KFCItemsBase>.Empty;
            list = db.GetAllSnacks();
            sorting(list);
        }

        private void напиткиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FSharpList<KFCItemsBase> list = FSharpList<KFCItemsBase>.Empty;
            list = db.GetAllDrinks();
            sorting(list);
        }

        private void FrontForm_Load(object sender, EventArgs e)
        {

        }
    }
}
