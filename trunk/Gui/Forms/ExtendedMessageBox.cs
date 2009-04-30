using System.Windows.Forms;
using EzPos.Properties;

namespace EzPos.GUI.Forms
{
    /// <summary>
    /// Summary description for MessageType.
    /// </summary>
    internal class ExtendedMessageBox
    {
        private static DialogResult _DialogResult;
        private static MessageBoxButtons _MsgButton;
        private static string _MsgCaption;
        private static MessageBoxDefaultButton _MsgDefaultButton;
        private static MessageBoxIcon _MsgIcon;
        private static string _MsgStr;

        public static bool ConfirmMessage(string messageKey, string complementStr)
        {
            _MsgStr = string.Format("{0} {1}?", messageKey, complementStr);
            _MsgCaption = Resources.MessageCaptionConfirm;
            _MsgButton = MessageBoxButtons.YesNo;
            _MsgIcon = MessageBoxIcon.Question;
            _MsgDefaultButton = MessageBoxDefaultButton.Button2;
            _DialogResult = MessageBox.Show(_MsgStr, _MsgCaption, _MsgButton, _MsgIcon, _MsgDefaultButton);
            return (_DialogResult == DialogResult.Yes);
        }

        public static void InformMessage(string messageKey)
        {
            _MsgStr = string.Format("{0}", messageKey);
            _MsgCaption = Resources.MessageCaptionConfirm;
            _MsgButton = MessageBoxButtons.OK;
            _MsgIcon = MessageBoxIcon.Information;
            MessageBox.Show(_MsgStr, _MsgCaption, _MsgButton, _MsgIcon);
        }

        public static void ErrorMessage(string messageKey)
        {
            _MsgStr = string.Format("{0}", messageKey);
            _MsgCaption = Resources.MessageCaptionError;
            _MsgButton = MessageBoxButtons.OK;
            _MsgIcon = MessageBoxIcon.Error;
            MessageBox.Show(_MsgStr, _MsgCaption, _MsgButton, _MsgIcon);
        }

        public static void UnknownErrorMessage(string messageKey, string additionnalMsg)
        {
            _MsgStr = string.Format("{0}\nAdditional message: {1}",
                                    messageKey, additionnalMsg);
            _MsgCaption = Resources.MessageCaptionUnknownError;
            _MsgButton = MessageBoxButtons.OK;
            _MsgIcon = MessageBoxIcon.Error;
            MessageBox.Show(_MsgStr, _MsgCaption, _MsgButton, _MsgIcon);
        }
    }
}