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
        public FrontForm()
        {
            InitializeComponent();
        }
    }
}
