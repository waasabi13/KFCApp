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
        private int blockMenu = 0;
        private Bitmap photo;
        public FrontForm(string file)
        {
            this.db = new JsonDB(file);
            this.photo = Properties.Resources.photo;
            InitializeComponent();
            comboBox1.SelectedIndex = 3;

        }
        private void DescriptionItem(KFCItemsBase item)
        {
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            label3.Visible = true;
            string label = item.Name;
            string price = "Цена: " + item.Price + " ₽";
            string desc = $"КБЖУ на 100г \nКкал: {item.Kcal}    Б: {item.Proteins} г    Ж: {item.Fats} г    У: {item.Carbohydrates} г\n";            
            if (item is Burger)
            {
                desc += $"Вес: {item.Weight} гр\n";
                Burger b = (Burger)item;
                if (b.Spicy)
                    desc += $"Острый\n";
                else
                    desc += $"Не острый\n";
            }
            if (item is FriedChicken)
            {
                desc += $"Вес: {item.Weight} гр\n";
                FriedChicken ch = (FriedChicken)item;
                desc += $"Количество: {ch.Count}\n";
            }
            if (item is Snack)
            {
                desc += $"Вес: {item.Weight} гр\n";
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
            this.label3.Text = price;
            this.label1.Text = desc;
            this.pictureBox1.Image = photo;
            this.pictureBox1.LoadAsync(item.PictureURL);
        }

        private void sorting(FSharpList<KFCItemsBase> list)
        {
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
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            listBox1.Visible = true;
            comboBox1.Visible = true;
            FSharpList<KFCItemsBase> list = FSharpList<KFCItemsBase>.Empty;
            list = db.Menu();
            blockMenu = 0;
            sorting(list);
        }

        private void бургерыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            listBox1.Visible = true;
            comboBox1.Visible = true;
            blockMenu = 1;
            FSharpList<KFCItemsBase> list = FSharpList<KFCItemsBase>.Empty;
            list = db.GetAllBurgers();
            sorting(list);
        }

        private void курицаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            listBox1.Visible = true;
            comboBox1.Visible = true;
            blockMenu = 2;
            FSharpList<KFCItemsBase> list = FSharpList<KFCItemsBase>.Empty;
            list = db.GetAllChicken();
            sorting(list);
        }

        private void снекиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            blockMenu = 3;
            comboBox1.Visible = true;
            FSharpList<KFCItemsBase> list = FSharpList<KFCItemsBase>.Empty;
            list = db.GetAllSnacks();
            sorting(list);
        }

        private void напиткиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            listBox1.Visible = true;
            comboBox1.Visible = true;
            blockMenu = 4;
            FSharpList<KFCItemsBase> list = FSharpList<KFCItemsBase>.Empty;
            list = db.GetAllDrinks();
            sorting(list);
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            listBox1.Visible = true;
            comboBox1.Visible = true;
            DescriptionItem(selectedItems[listBox1.SelectedIndex]);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FSharpList<KFCItemsBase> list = FSharpList<KFCItemsBase>.Empty;
            switch (blockMenu)
            {
                case 0:
                    list = db.Menu();
                    break;
                case 1:
                    list = db.GetAllBurgers();
                    break;
                case 2:
                    list = db.GetAllChicken();
                    break;
                case 3:
                    list = db.GetAllSnacks();
                    break;
                case 4:
                    list = db.GetAllDrinks();
                    break;
            }
            sorting(list);
        }

        private void самоеДорогоеВМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            listBox1.Visible = false;
            comboBox1.Visible = false;
            DescriptionItem(db.GetMostExpensive());
        }

        private void самыйБольшойБургерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            listBox1.Visible = false;
            comboBox1.Visible = false;
            DescriptionItem(db.GetBiggestBurger());
        }

        private void самыйДешевыйБургерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            listBox1.Visible = false;
            comboBox1.Visible = false;
            DescriptionItem(db.GetCheapBurger());
        }

        private void самыйДешевыйНапитокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            listBox1.Visible = false;
            comboBox1.Visible = false;
            DescriptionItem(db.GetMostCheapDrink());
        }

        private void самыйКалорийныйСнекToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            listBox1.Visible = false;
            comboBox1.Visible = false;
            DescriptionItem(db.GetMostKcalSnack());
        }

        private void FrontForm_Load(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
            listBox1.Visible = false;
            comboBox1.Visible = false;
            label3.Visible = false;
        }

    }
}
