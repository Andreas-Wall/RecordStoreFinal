using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final{
    public partial class productListings : UserControl{
        public int index = 0;
        public delegate void RemoveSiteEventHandler(Object sender, ContentArgs e);
        public productListings(){InitializeComponent();}
        private void btnView_Click(object sender, EventArgs e)
        {
            BuyAlbum buy = new BuyAlbum();
            buy.album = lblAlbumInfo.Text.ToString();
            buy.ShowDialog();
        }
        public class ContentArgs : EventArgs{
            public int index;
            public ContentArgs(int value){index = value;}
        }
    }
}
