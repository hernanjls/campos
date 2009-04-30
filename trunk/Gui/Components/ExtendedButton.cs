using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using EzPos.Properties;

namespace EzPos.Component
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
            SetBackGroundImage(Resources.bg_mouse_enter);
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            SetBackGroundImage(null);
            base.OnMouseLeave(e);
        }

        private void SetBackGroundImage(Image backgroundImage)
        {
            //ForeColor = backgroundImage == null ? Color.RoyalBlue : Color.White;
            BackgroundImage = backgroundImage;
        }
    }
}