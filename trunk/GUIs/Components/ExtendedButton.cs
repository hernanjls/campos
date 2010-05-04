using System;
using System.ComponentModel;
using System.Windows.Forms;
using EzPos.Properties;

namespace EzPos.GUIs.Components
{
    public partial class ExtendedButton : Button
    {
        public ExtendedButton()
        {
            InitializeComponent();
        }

        public ExtendedButton(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            SetCustomizedBehavior();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            RemoveCustomizedBehavior();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            SetCustomizedBehavior();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            RemoveCustomizedBehavior();
        }

        private void SetCustomizedBehavior()
        {
            BackgroundImage = Resources.background_9;
            //Font = new Font(Font, FontStyle.Bold);
            //ForeColor = Color.White;
        }

        private void RemoveCustomizedBehavior()
        {
            BackgroundImage = Resources.background_2;
            //Font = new Font(Font, FontStyle.Regular);
            //ForeColor = SystemColors.WindowText;
        }
    }
}