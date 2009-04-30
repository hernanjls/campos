using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GenericDataGridView
{
    public partial class ExtendedDataGridView : DataGridView
    {
        #region ValidationStyle enum

        public enum ValidationStyle
        {
            NumericInt,
            NumericDouble,
            Email,
            Date
        }

        #endregion

        private readonly DataTable dtValidation = new DataTable("ValidationTable");

        private string m_DataColumns;
        private string m_DataColumnsRaw;
        private string m_DataColumnsTable;

        public ExtendedDataGridView()
        {
            InitializeComponent();
        }

        public ExtendedDataGridView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #region New Properties

        // [Browsable(false), EditorBrowsable(EditorBrowsableState.Always)] 
        [Browsable(true)]
        public string DataColumns
        {
            get { return m_DataColumnsRaw; }
            set
            {
                m_DataColumnsRaw = value;
                m_DataColumns = value.Replace("%", "");
            }
        }

        [Browsable(true)]
        public string DataColumnsTable
        {
            get { return m_DataColumnsTable; }
            set { m_DataColumnsTable = value; }
        }

        //public bool ExcelExportButton
        //{
        //    get
        //    {
        //        return m_ExcelExportButton;
        //    }
        //    set
        //    {
        //        m_ExcelExportButton = value;
        //        if (value == true)
        //        {
        //            if (btDown.Text != "->")
        //            {
        //                btDown.Text = "->";
        //                btDown.ProductLocation = new System.Drawing.Point(this.ProductLocation.X, this.ProductLocation.Y - 30);
        //                btDown.Click += new EventHandler(BtDownOnClick);
        //                this.Parent.Controls.Add(btDown);
        //            }
        //        }
        //        btDown.Visible = value;
        //     }
        //}

        //public void BtDownOnClick(object sender, EventArgs e)
        //{

        //}

        [Browsable(true)]
        public string DataConnection { get; set; }

        #endregion

        #region FillAll

        public void FillAll()
        {
            SqlConnection cn;
            cn = new SqlConnection(DataConnection);
            cn.Open();
            string sql;
            sql = "Select " + m_DataColumns + " from " + m_DataColumnsTable;
            var da = new SqlDataAdapter(sql, cn);
            DataTable dt;
            dt = new DataTable();
            da.Fill(dt);
            DataSource = dt;
            dt.Columns[0].ReadOnly = true;
            Columns[0].ReadOnly = true;
            cn.Close();
        }

        #endregion

        #region AddValidation

        public void AddValidation(string ColumnName, bool BlankControl, ValidationStyle ValidationType,
                                  string ValidationMessage)
        {
            if (dtValidation.Columns.Count == 0)
            {
                dtValidation.Columns.Add("Name", Type.GetType("System.String"));
                dtValidation.Columns.Add("BlankControl", Type.GetType("System.Boolean"));
                dtValidation.Columns.Add("Validation", Type.GetType("System.Int16"));
                // ValidationType

                // dtValidation.Columns.Add("Validation", Type.GetType(ValidationType));
                dtValidation.Columns.Add("ValidationMessage", Type.GetType("System.String"));
            }
            DataRow dr;
            dr = dtValidation.NewRow();
            dr[0] = ColumnName;
            dr[1] = BlankControl;
            dr[2] = ValidationType;
            dr[3] = ValidationMessage;
            dtValidation.Rows.Add(dr);
        }

        #endregion

        #region AddCombo

        public void AddCombo(string ColumnName, string HeaderText, string SourceTable, string DisplayColumn,
                             string ValueMember, string SWhere)
        {
            Columns.Remove(ColumnName);
            SqlConnection cn;
            cn = new SqlConnection(DataConnection);
            cn.Open();
            string sql;
            sql = "Select " + DisplayColumn + " as LB," + ValueMember + " as VL from " + SourceTable + " " + SWhere;
            var da_addcombo = new SqlDataAdapter(sql, cn);
            DataTable dt_addcombo;
            dt_addcombo = new DataTable();
            da_addcombo.Fill(dt_addcombo);
            var column_addcombo = new DataGridViewComboBoxColumn();
            column_addcombo.DataSource = dt_addcombo;
            column_addcombo.DisplayMember = "LB";
            column_addcombo.ValueMember = "VL";
            column_addcombo.DataPropertyName = ColumnName;
            column_addcombo.Name = ColumnName;
            column_addcombo.HeaderText = HeaderText;
            Columns.Add(column_addcombo);
            int j, i;
            string[] k;
            char a;
            a = ',';
            k = m_DataColumns.Split(a);
            i = k.Length - 1;
            j = 0;
            while ((j < i) && (k[j].IndexOf(ColumnName) == -1))
            {
                j = j + 1;
            }
            Columns[i].DisplayIndex = j;
        }

        #endregion

        #region AddCalendar

        public void AddCalendar(string ColumnName, string HeaderText)
        {
            Columns.Remove(ColumnName);
            var column_addcalendar = new CalendarColumn();
            column_addcalendar.DataPropertyName = ColumnName;
            column_addcalendar.Name = ColumnName;
            column_addcalendar.HeaderText = HeaderText;
            Columns.Add(column_addcalendar);
            int j, i;
            string[] k;
            char a;
            a = ',';
            k = m_DataColumns.Split(a);
            i = k.Length - 1;
            j = 0;
            while ((j < i) && (k[j].IndexOf(ColumnName) == -1))
            {
                j = j + 1;
            }
            Columns[i].DisplayIndex = j;
        }

        #endregion

        #region AddMask

        public void AddMask(string ColumnName, string HeaderText, string MaskStr)
        {
            Columns.Remove(ColumnName);
            MaskedTextColumn column_addmask;
            column_addmask = new MaskedTextColumn();
            column_addmask.DataPropertyName = ColumnName;
            column_addmask.Name = ColumnName;
            column_addmask.HeaderText = HeaderText;
            column_addmask.maskA(MaskStr);
            Columns.Add(column_addmask);
            int j, i;
            string[] k;
            char a;
            a = ',';
            k = m_DataColumns.Split(a);
            i = k.Length - 1;
            j = 0;
            while ((j < i) && (k[j].IndexOf(ColumnName) == -1))
            {
                j = j + 1;
            }
            Columns[i].DisplayIndex = j;
        }

        #endregion

        #region Row_Save

        private void Row_Save(int rowNumber)
        {
            int j, i, s;
            string sql;
            string[] kValues;
            string[] columns_mod;
            char a;
            a = ',';
            kValues = m_DataColumns.Split(a);
            columns_mod = m_DataColumnsRaw.Split(a);

            j = kValues.Length;


            if (this[kValues[0], rowNumber].Value is DBNull)
            {
                kValues[0] = "Null";
            }
            else
            {
                kValues[0] = (this[kValues[0], rowNumber].Value).ToString();
            }

            if (kValues[0] != "Null")
            {
                sql = " update " + DataColumnsTable + " set ";
                for (i = 1; i < j; i++)
                {
                    kValues[i] = kValues[i].Replace(',', ' ');
                    if (this[kValues[i], rowNumber].Value is DBNull)
                    {
                        kValues[i] = "Null";
                    }
                    else
                    {
                        kValues[i] = (this[kValues[i], rowNumber].Value).ToString();
                    }
                    if (columns_mod[i].IndexOf('%') != -1)
                    {
                        columns_mod[i] = columns_mod[i].Replace('%', ' ');
                        sql = sql + columns_mod[i] + "='" + kValues[i] + "',";
                    }
                    else
                    {
                        columns_mod[i] = columns_mod[i].Replace('%', ' ');
                        sql = sql + columns_mod[i] + "=" + kValues[i] + ",";
                    }
                }
                s = sql.Length - 1;
                sql = sql.Substring(0, s);
                sql = sql + " where " + columns_mod[0] + "=" + kValues[0];
                SqlConnection cn;
                cn = new SqlConnection(DataConnection);
                cn.Open();
                var cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            else
            {
                sql = " insert into " + DataColumnsTable + " ( ";
                string sql2 = ") values (";
                for (i = 1; i < j; i++)
                {
                    kValues[i] = kValues[i].Replace(',', ' ');
                    if (this[kValues[i], rowNumber].Value is DBNull)
                    {
                        kValues[i] = "Null";
                    }
                    else
                    {
                        kValues[i] = (this[kValues[i], rowNumber].Value).ToString();
                    }
                    if (columns_mod[i].IndexOf('%') != -1)
                    {
                        columns_mod[i] = columns_mod[i].Replace('%', ' ');
                        sql = sql + columns_mod[i] + ",";
                        sql2 = sql2 + "'" + kValues[i] + "',";
                    }
                    else
                    {
                        columns_mod[i] = columns_mod[i].Replace('%', ' ');
                        sql = sql + columns_mod[i] + ",";
                        sql2 = sql2 + kValues[i] + ",";
                    }
                }
                sql2 = sql2.Substring(0, sql2.Length - 1);
                sql = sql.Substring(0, sql.Length - 1);
                sql = sql + sql2 + ")";
                SqlConnection cn;
                cn = new SqlConnection(DataConnection);
                cn.Open();
                var cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
                FillAll();
            }
        }

        #endregion

        #region Events

        /// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellCancelEventArgs"></see> that contains the event data.</param>
        protected override void OnCellBeginEdit(DataGridViewCellCancelEventArgs e)
        {
            CurrentRow.DefaultCellStyle.BackColor = Color.Red;
            base.OnCellBeginEdit(e);
        }


        /// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellEventArgs"></see> that contains the event data.</param>
        protected override void OnRowValidated(DataGridViewCellEventArgs e)
        {
            if (CurrentRow.DefaultCellStyle.BackColor == Color.Red)
            {
                CurrentRow.DefaultCellStyle.BackColor = Color.Aqua;
                Row_Save(e.RowIndex);
                base.OnRowValidated(e);
            }
        }


        /// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellEventArgs"></see> that contains the event data.</param>
        protected override void OnCellEndEdit(DataGridViewCellEventArgs e)
        {
            Rows[e.RowIndex].ErrorText = String.Empty;
            base.OnCellEndEdit(e);
        }

        /// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellValidatingEventArgs"></see> that contains the event data.</param>
        protected override void OnCellValidating(DataGridViewCellValidatingEventArgs e)
        {
            int j;
            j = dtValidation.Rows.Count - 1;
            if (j != -1)
            {
                bool check = false;
                var dv = new DataView(dtValidation, "Name='" + Columns[e.ColumnIndex].Name + "'", null,
                                      DataViewRowState.CurrentRows);
                if (dv.Count == 1)
                {
                    if ((bool) dv[0][1])
                    {
                        if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            Rows[e.RowIndex].ErrorText = "Empty Text";
                            e.Cancel = true;
                        }
                    }
                    if ((dv[0][2].ToString()) != "")
                    {
                        switch (dv[0][2].ToString())
                        {
                            case "0":
                                check = IsNumericInt(e.FormattedValue.ToString());
                                break;
                            case "1":
                                check = IsNumericDouble(e.FormattedValue.ToString());
                                break;
                            case "2":
                                check = IsEmail(e.FormattedValue.ToString());
                                break;
                            case "3":
                                check = IsDate(e.FormattedValue.ToString());
                                break;
                        }
                        if (check)
                        {
                            Rows[e.RowIndex].ErrorText = dv[0][3].ToString();
                            e.Cancel = check;
                        }
                    }
                }
            }
            base.OnCellValidating(e);
        }

        #endregion

        #region ValidationControls

        private bool IsNumericDouble(object ValueToCheck)
        {
            double Dummy;
            return !double.TryParse(ValueToCheck.ToString(), NumberStyles.Any, null, out Dummy);
        }

        private bool IsNumericInt(object ValueToCheck)
        {
            int Dummy;
            return !int.TryParse(ValueToCheck.ToString(), NumberStyles.Any, null, out Dummy);
        }

        private bool IsEmail(object ValueToCheck)
        {
            return !Regex.IsMatch(ValueToCheck.ToString(), @"^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$");
        }

        private bool IsDate(object ValueToCheck)
        {
            return
                !Regex.IsMatch(ValueToCheck.ToString(), @"^[0-2]?[1-9](/|-|.)[0-3]?[0-9](/|-|.)[1-2][0-9][0-9][0-9]$");
        }

        #endregion

        #region CalendarColumn

        #region Nested type: CalendarCell

        public class CalendarCell : DataGridViewTextBoxCell
        {
            public CalendarCell()
            {
                // Use the short date format.
                Style.Format = "d";
            }

            public override Type EditType
            {
                get
                {
                    // Return the type of the editing contol that CalendarCell uses.
                    return typeof (CalendarEditingControl);
                }
            }

            public override Type ValueType
            {
                get
                {
                    // Return the type of the value that CalendarCell contains.
                    return typeof (DateTime);
                }
            }

            public override object DefaultNewRowValue
            {
                get
                {
                    // Use the current date and time as the default value.                    
                    return DateTime.Now;
                }
            }

            public override void InitializeEditingControl(int rowIndex, object
                                                                            initialFormattedValue,
                                                          DataGridViewCellStyle dataGridViewCellStyle)
            {
                // Set the value of the editing control to the current cell value.
                base.InitializeEditingControl(rowIndex, initialFormattedValue,
                                              dataGridViewCellStyle);
                var ctl =
                    DataGridView.EditingControl as CalendarEditingControl;
                if (Value is DBNull)
                    return;
                ctl.Value = (DateTime) Value;
            }
        }

        #endregion

        #region Nested type: CalendarColumn

        public class CalendarColumn : DataGridViewColumn
        {
            public CalendarColumn()
                : base(new CalendarCell())
            {
            }

            public override DataGridViewCell CellTemplate
            {
                get { return base.CellTemplate; }
                set
                {
                    if (value != null &&
                        !value.GetType().IsAssignableFrom(typeof (CalendarCell)))
                    {
                        throw new InvalidCastException("Must be a CalendarCell");
                    }
                    base.CellTemplate = value;
                }
            }
        }

        #endregion

        #region Nested type: CalendarEditingControl

        private class CalendarEditingControl : DateTimePicker, IDataGridViewEditingControl
        {
            private bool valueChanged;

            public CalendarEditingControl()
            {
                Format = DateTimePickerFormat.Short;
            }

            // Implements the IDataGridViewEditingControl.EditingControlFormattedValue 
            // property.

            #region IDataGridViewEditingControl Members

            public object EditingControlFormattedValue
            {
                get { return Value.ToShortDateString(); }
                set
                {
                    if (value is String)
                    {
                        Value = DateTime.Parse((String) value);
                    }
                }
            }

            // Implements the 
            // IDataGridViewEditingControl.GetEditingControlFormattedValue method.
            public object GetEditingControlFormattedValue(
                DataGridViewDataErrorContexts context)
            {
                return EditingControlFormattedValue;
            }

            // Implements the 
            // IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
            public void ApplyCellStyleToEditingControl(
                DataGridViewCellStyle dataGridViewCellStyle)
            {
                Font = dataGridViewCellStyle.Font;
                CalendarForeColor = dataGridViewCellStyle.ForeColor;
                CalendarMonthBackground = dataGridViewCellStyle.BackColor;
            }

            // Implements the IDataGridViewEditingControl.EditingControlRowIndex 
            // property.
            public int EditingControlRowIndex { get; set; }

            // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey 
            // method.
            public bool EditingControlWantsInputKey(
                Keys key, bool dataGridViewWantsInputKey)
            {
                // Let the DateTimePicker handle the keys listed.
                switch (key & Keys.KeyCode)
                {
                    case Keys.Left:
                    case Keys.Up:
                    case Keys.Down:
                    case Keys.Right:
                    case Keys.Home:
                    case Keys.End:
                    case Keys.PageDown:
                    case Keys.PageUp:
                        return true;
                    default:
                        return false;
                }
            }

            // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit 
            // method.
            public void PrepareEditingControlForEdit(bool selectAll)
            {
                // No preparation needs to be done.
            }

            // Implements the IDataGridViewEditingControl
            // .RepositionEditingControlOnValueChange property.
            public bool RepositionEditingControlOnValueChange
            {
                get { return false; }
            }

            // Implements the IDataGridViewEditingControl
            // .EditingControlDataGridView property.
            public DataGridView EditingControlDataGridView { get; set; }

            // Implements the IDataGridViewEditingControl
            // .EditingControlValueChanged property.
            public bool EditingControlValueChanged
            {
                get { return valueChanged; }
                set { valueChanged = value; }
            }

            // Implements the IDataGridViewEditingControl
            // .EditingPanelCursor property.
            public Cursor EditingPanelCursor
            {
                get { return base.Cursor; }
            }

            #endregion

            protected override void OnValueChanged(EventArgs eventargs)
            {
                // Notify the DataGridView that the contents of the cell
                // have changed.
                valueChanged = true;
                EditingControlDataGridView.NotifyCurrentCellDirty(true);
                base.OnValueChanged(eventargs);
            }
        }

        #endregion

        #endregion

        #region MaskColumn

        #region Nested type: MaskedTextCell

        public class MaskedTextCell : DataGridViewTextBoxCell
        {
            public MaskedTextCell()
            {
                Style.ForeColor = Color.RoyalBlue;
            }


            public override Type EditType
            {
                get { return typeof (MaskedTextEditingControl); }
            }

            public override Type ValueType
            {
                get { return typeof (string); }
            }

            public override void InitializeEditingControl(int rowIndex, object
                                                                            initialFormattedValue,
                                                          DataGridViewCellStyle dataGridViewCellStyle)
            {
                // Set the value of the editing control to the current cell value.
                base.InitializeEditingControl(rowIndex, initialFormattedValue,
                                              dataGridViewCellStyle);
                var ctl = DataGridView.EditingControl as MaskedTextEditingControl;
                ctl.Text = (string) Value;
            }

            #region Nested type: MaskedTextEditingControl

            private class MaskedTextEditingControl : MaskedTextBox, IDataGridViewEditingControl
            {
                private bool valueChanged;

                public MaskedTextEditingControl()
                {
                    Mask = mskn.msk;
                }

                #region IDataGridViewEditingControl Members

                public object EditingControlFormattedValue
                {
                    get { return Text; }
                    set
                    {
                        if (value is String)
                        {
                            Text = (String) value;
                        }
                    }
                }

                public object GetEditingControlFormattedValue(
                    DataGridViewDataErrorContexts context)
                {
                    return EditingControlFormattedValue;
                }

                public void ApplyCellStyleToEditingControl(
                    DataGridViewCellStyle dataGridViewCellStyle)
                {
                    Font = dataGridViewCellStyle.Font;
                }

                // Implements the IDataGridViewEditingControl.EditingControlRowIndex 
                // property.
                public int EditingControlRowIndex { get; set; }

                public bool EditingControlWantsInputKey(
                    Keys key, bool dataGridViewWantsInputKey)
                {
                    switch (key & Keys.KeyCode)
                    {
                        case Keys.Left:
                        case Keys.Up:
                        case Keys.Down:
                        case Keys.Right:
                        case Keys.Home:
                        case Keys.End:
                        case Keys.PageDown:
                        case Keys.PageUp:
                            return true;
                        default:
                            return false;
                    }
                }

                public void PrepareEditingControlForEdit(bool selectAll)
                {
                    // No preparation needs to be done.
                }

                public bool RepositionEditingControlOnValueChange
                {
                    get { return false; }
                }

                public DataGridView EditingControlDataGridView { get; set; }

                public bool EditingControlValueChanged
                {
                    get { return valueChanged; }
                    set { valueChanged = value; }
                }


                public Cursor EditingPanelCursor
                {
                    get { return base.Cursor; }
                }

                #endregion

                /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
                protected override void OnLeave(EventArgs e)
                {
                    valueChanged = true;
                    EditingControlDataGridView.NotifyCurrentCellDirty(true);
                    base.OnTextChanged(e);
                }
            }

            #endregion
        }

        #endregion

        #region Nested type: MaskedTextColumn

        public class MaskedTextColumn : DataGridViewColumn
        {
            public MaskedTextColumn()
                : base(new MaskedTextCell())
            {
            }


            public override DataGridViewCell CellTemplate
            {
                get { return base.CellTemplate; }
                set
                {
                    if (value != null &&
                        !value.GetType().IsAssignableFrom(typeof (MaskedTextCell)))
                    {
                        throw new InvalidCastException("Must be a MaskedTextCell");
                    }
                    base.CellTemplate = value;
                }
            }

            public void maskA(string m)
            {
                mskn.msk = m;
            }
        }

        #endregion

        #region Nested type: mskn

        public class mskn
        {
            public static string msk = "";
        }

        #endregion

        #endregion
    }
}