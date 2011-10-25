using System;
using System.Collections;
using System.ComponentModel;
using EzPos.Utility;

namespace EzPos.GUIs.Components
{
    public partial class ExtendedComboBox
    {
        public ExtendedComboBox()
        {
            InitializeComponent();
        }

        public ExtendedComboBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void CustomizedDataBinding(IList dataSource, string displayMember, string valueMember, bool defaultSelect)
        {
            if (dataSource == null)
                throw new ArgumentNullException("dataSource", "DataSource");

            if (StringHelper.Length(valueMember) == 0)
                throw new ArgumentNullException(valueMember, "ValueMember");

            if (StringHelper.Length(displayMember) == 0)
                throw new ArgumentNullException(displayMember, "displayMember");

            DataSource = dataSource;
            if (dataSource.Count != 0)
            {
                DisplayMember = displayMember;
                ValueMember = valueMember;
                if (!defaultSelect)
                    SelectedIndex = -1;
            }
        }
    }
}