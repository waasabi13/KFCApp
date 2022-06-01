using KFC_Base;
using System.Windows.Forms;
using Microsoft.FSharp.Collections;
using System;
using Microsoft.FSharp.Core;
using System.Net;
using System.IO;
using System.IO.Compression;
namespace KFCFront
{
    public partial class FrontForm : Form
    {
        private JsonDB db;
        private FSharpList<KFCItemsBase> selectedItems;
        //private Bitmap load
        public FrontForm(string file)
        {
            this.db = new JsonDB(file);
            
            InitializeComponent();

        }
        private void DescriptionItem(KFCItemsBase item)
        {
            string label = item.Name+"\nЦена: "+item.Price;
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
                desc += $"Размер: {s.Size}\n";
            }
            if (item is Drink)
            {
                Drink d = (Drink)item;
                desc += $"Размер: {d.Size}\n";
                if (d.Hot)
                    desc += $"Горячий напиток: Да\n";
                else
                    desc += $"Холодный напиток: Да\n";
            }
            desc += item.Compound;
        }


        private void FrontForm_Load(object sender, EventArgs e)
        {

        }
    }
}
