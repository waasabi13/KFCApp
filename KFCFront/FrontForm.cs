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
            string label = item.Name + "\nЦена: " + item.Price+ " ₽";
            string desc = $"КБЖУ на 100г \nКкал: {item.Kcal}\tБ: {item.Proteins}\tЖ: {item.Fats}\tУ: {item.Carbohydrates}\n";            //
            if (item is Burger)
            {
                desc += $"Вес: {item.Weight}\n";
                Burger b = (Burger)item;
                if (b.Spicy)
                    desc += $"Острота: Да\n";
                else
                    desc += $"Острота: Нет\n";

            }
            if (item is FriedChicken)
            {
                desc += $"Вес: {item.Weight}\n";
                FriedChicken ch = (FriedChicken)item;
                desc += $"Количество: {ch.Count}\n";
            }
            if (item is Snack)
            {
                desc += $"Вес: {item.Weight}\n";
                Snack s = (Snack)item;
                desc += $"Размер: {sizeString.SizeToString(s.Size)}\n";
            }
            if (item is Drink)
            {
                Drink d = (Drink)item;
                desc += $"Размер: {sizeString.SizeToString(d.Size)}\n";
                if (d.Hot)
                    desc += $"Горячий напиток\n";
                else
                    desc += $"Холодный напиток\n";
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

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DescriptionItem(selectedItems[listBox1.SelectedIndex]);
        }
        private void самоеДорогоеВМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DescriptionItem(db.GetMostExpensive());
        }

        private void самыйБольшойБургерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DescriptionItem(db.GetBiggestBurger());
        }

        private void самыйДешевыйБургерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DescriptionItem(db.GetCheapBurger());
        }

        private void самыйДешевыйНапитокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DescriptionItem(db.GetMostCheapDrink());
        }

        private void самыйКалорийныйСнекToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DescriptionItem(db.GetMostKcalSnack());
        }

        //сделать масштаб картинки
    }
}
