using System;
using System.Windows.Forms;
using EzPos.Model;
using EzPos.Model.Common;

namespace EzPos.GUI
{
    public partial class FrmThank : Form
    {
        public FrmThank()
        {
            InitializeComponent();
        }

        private void FrmThank_KeyDown(object sender, KeyEventArgs e)
        {
            Close();
        }

        private void FrmThank_Load(object sender, EventArgs e)
        {
            lblInfo.Text = "ហាង " + AppContext.ShopName +
                           " សូមថ្លែងអំណរគុណដល់លោកអ្នកដែលបាន​ជាវ\nផលិតផលពីហាងរបស់យើងខ្ញុំ៕";
        }
    }
}