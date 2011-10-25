using System;
using System.Windows.Forms;
using EzPos.Properties;

namespace EzPos.GUIs.Forms
{
    public partial class FrmExtendedMessageBox : Form
    {
        private string _briefMsgStr;
        private string _detailMsgStr;
        private bool _isCanceledOnly;

        private static DialogResult _dialogResult;
        private static MessageBoxButtons _msgButton;
        private static string _msgCaption;
        private static MessageBoxDefaultButton _msgDefaultButton;
        private static MessageBoxIcon _msgIcon;
        private static string _msgStr;

        public static bool ConfirmMessage(string messageKey, string complementStr)
        {
            _msgStr = string.Format("{0} {1}?", messageKey, complementStr);
            _msgCaption = Resources.MsgCaptionConfirm;
            _msgButton = MessageBoxButtons.YesNo;
            _msgIcon = MessageBoxIcon.Question;
            _msgDefaultButton = MessageBoxDefaultButton.Button2;
            _dialogResult = MessageBox.Show(_msgStr, _msgCaption, _msgButton, _msgIcon, _msgDefaultButton);
            return (_dialogResult == DialogResult.Yes);
        }

        public static void InformMessage(string messageKey)
        {
            _msgStr = string.Format("{0}", messageKey);
            _msgCaption = Resources.MsgCaptionConfirm;
            _msgButton = MessageBoxButtons.OK;
            _msgIcon = MessageBoxIcon.Information;
            MessageBox.Show(_msgStr, _msgCaption, _msgButton, _msgIcon);
        }

        public static void ErrorMessage(string messageKey)
        {
            _msgStr = string.Format("{0}", messageKey);
            _msgCaption = Resources.MsgCaptionError;
            _msgButton = MessageBoxButtons.OK;
            _msgIcon = MessageBoxIcon.Error;
            MessageBox.Show(_msgStr, _msgCaption, _msgButton, _msgIcon);
        }

        public static void UnknownErrorMessage(string messageKey, string additionnalMsg)
        {
            _msgStr = string.Format("{0}\nAdditional message: {1}",
                                    messageKey, additionnalMsg);
            _msgCaption = Resources.MsgCaptionUnknownError;
            _msgButton = MessageBoxButtons.OK;
            _msgIcon = MessageBoxIcon.Error;
            MessageBox.Show(_msgStr, _msgCaption, _msgButton, _msgIcon);
        }

        public FrmExtendedMessageBox()
        {
            InitializeComponent();
        }

        public string BriefMsgStr
        {
            set { _briefMsgStr = value; }
        }

        public string DetailMsgStr
        {
            set { _detailMsgStr = value; }
        }

        public bool IsCanceledOnly
        {
            set { _isCanceledOnly = value; }
        }

        private void BtnSaveMouseEnter(object sender, EventArgs e)
        {
            btnAccept.BackgroundImage = Resources.background_9;
        }

        private void BtnSaveMouseLeave(object sender, EventArgs e)
        {
            btnAccept.BackgroundImage = Resources.background_2;
        }

        private void BtnCancelMouseEnter(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = Resources.background_9;
        }

        private void BtnCancelMouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = Resources.background_2;
        }

        private void FrmMessageBox_Load(object sender, EventArgs e)
        {
            lblBriefMsg.Text = _briefMsgStr;
            txtDetailMsg.Text = _detailMsgStr;

            btnAccept.Visible = !_isCanceledOnly;
        }
    }
}