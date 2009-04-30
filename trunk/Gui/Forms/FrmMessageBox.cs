using System;
using System.Windows.Forms;

namespace EzPos.GUI.Forms
{
    public partial class FrmMessageBox : Form
    {
        private string _BriefMsgStr;
        private string _DetailMsgStr;
        private bool _IsCanceledOnly;

        public string BriefMsgStr
        {
            set { _BriefMsgStr = value; }
        }

        public string DetailMsgStr
        {
            set { _DetailMsgStr = value; }
        }

        public bool IsCanceledOnly
        {
            set { _IsCanceledOnly = value; }
        }

        public FrmMessageBox()
        {
            InitializeComponent();
        }

        private void FrmMessageBox_Load(object sender, EventArgs e)
        {
            lblBriefMsg.Text = _BriefMsgStr;
            txtDetailMsg.Text = _DetailMsgStr;

            btnSave.Visible = !_IsCanceledOnly;
        }
    }
}