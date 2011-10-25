using System;
using System.Collections;
using EzPos.GUIs.Forms;
using EzPos.Utility;
using Resources=EzPos.Properties.Resources;

namespace EzPos.GUIs.Components
{
    partial class ExtendedComboBox : System.Windows.Forms.ComboBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void OnLeave(EventArgs e)
        {
            if (DataSource == null)
                return;

            if (((IList)DataSource).Count == 0)
                return;

            if (StringHelper.Length(DisplayMember) == 0)
                return;

            if (StringHelper.Length(ValueMember) == 0)
                return;

            if (StringHelper.Length(Text) == 0)
                return;

            int selectedIndex = FindString(Text);
            if (selectedIndex == -1)
            {
                FrmExtendedMessageBox.ErrorMessage(Resources.MsgItemNotInList);
                Text = string.Empty;
            }
            SelectedIndex = selectedIndex;
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        #endregion
    }
}