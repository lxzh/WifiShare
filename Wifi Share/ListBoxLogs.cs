using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Wifi_Share
{
    public class ListBoxLogs
    {
        private delegate void AddCtrlValueHandler(Control ctrl, string value);
        private delegate void ChangeComboBoxValueHandler(ComboBox ctrl);
        private delegate void SetCtrlEnableHandler(Control ctrl, bool value);
        private delegate void SetCtrlValueHandler(Control ctrl, string value);

        public static void AddCtrlValue(Form parentForm, Control ctrl, string value)
        {
            if (parentForm.InvokeRequired)
            {
                AddCtrlValueHandler method = new AddCtrlValueHandler(AddCtrlValueMethod);
                parentForm.BeginInvoke(method, new object[] { ctrl, value });
            }
            else
            {
                AddCtrlValueMethod(ctrl, value);
            }
        }

        private static void AddCtrlValueMethod(Control ctrl, string value)
        {
            if (ctrl is TextBox)
            {
                TextBox box = ctrl as TextBox;
                box.Text = box.Text + value;
            }
            else if (ctrl is Label)
            {
                Label label = ctrl as Label;
                label.Text = label.Text + value;
            }
            else if (ctrl is ListBox)
            {
                ListBox listbox = ctrl as ListBox;
                if (listbox.Items.Count > 200)
                {
                    listbox.Items.Clear();
                }
                listbox.Items.Add(value);
                if (listbox.Items.Count > 1)
                {
                    listbox.SelectedIndex = (listbox.Items.Count - 1);
                }
            }
            else if (ctrl is RichTextBox)
            {
                RichTextBox richtextbox = ctrl as RichTextBox;
                richtextbox.Text += value + "\r\n";
                if (richtextbox.Text.Length > 6000)
                {
                    richtextbox.Text = string.Empty;
                }
            }

        }

        public static void ChangeComboBoxValue(Form parentForm, ComboBox ctrl)
        {
            if (parentForm.InvokeRequired)
            {
                ChangeComboBoxValueHandler method = new ChangeComboBoxValueHandler(ChangeComboBoxValueMethod);
                parentForm.BeginInvoke(method, new object[] { ctrl });
            }
            else
            {
                ChangeComboBoxValueMethod(ctrl);
            }
        }

        private static void ChangeComboBoxValueMethod(ComboBox ctrl)
        {
            if (ctrl.Items.Count > 1)
            {
                if (ctrl.SelectedIndex == 0)
                {
                    ctrl.SelectedIndex = 1;
                }
                else
                {
                    ctrl.SelectedIndex = 0;
                }
            }
        }

        public static void SetCtrlEnable(Form parentForm, Control ctrl, bool value)
        {
            if (parentForm.InvokeRequired)
            {
                SetCtrlEnableHandler method = new SetCtrlEnableHandler(SetCtrlEnableMethod);
                parentForm.BeginInvoke(method, new object[] { ctrl, value });
            }
            else
            {
                SetCtrlEnableMethod(ctrl, value);
            }
        }

        public static void SetCtrlEnable(UserControl parentCtrl, Control ctrl, bool value)
        {
            if (parentCtrl.InvokeRequired)
            {
                SetCtrlEnableHandler method = new SetCtrlEnableHandler(SetCtrlEnableMethod);
                parentCtrl.BeginInvoke(method, new object[] { ctrl, value });
            }
            else
            {
                SetCtrlEnableMethod(ctrl, value);
            }
        }

        private static void SetCtrlEnableMethod(Control ctrl, bool value)
        {
            //if (ctrl is TextBox)
            //{
            //    TextBox box = ctrl as TextBox;
            //    box.Enabled = value;
            //}
            //if (ctrl is ComboBox)
            //{
            //    ComboBox box2 = ctrl as ComboBox;
            //    box2.Enabled = value;
            //}
            //if (ctrl is Label)
            //{
            //    Label label = ctrl as Label;
            //    label.Enabled = value;
            //}
            //if (ctrl is Button)
            //{
            //    Button button = ctrl as Button;
            //    button.Enabled = value;
            //}
            //if (ctrl is NumericUpDown)
            //{
            //    NumericUpDown down = ctrl as NumericUpDown;
            //    down.Enabled = value;
            //}
            //if (ctrl is Form)
            //{
            //    Form form = ctrl as Form;
            //    form.Enabled = value;
            //}
            ////if (ctrl is IPTextBox)
            ////{
            ////    IPTextBox box3 = ctrl as IPTextBox;
            ////    box3.Enabled = value;
            ////}
            //if (ctrl is GroupBox)
            //{
            //    GroupBox box4 = ctrl as GroupBox;
            //    box4.Enabled = value;
            //}
            //if (ctrl is CheckBox)
            //{
            //    CheckBox box5 = ctrl as CheckBox;
            //    box5.Enabled = value;
            //}
            try
            {
                ctrl.Enabled = value;
            }
            catch { }
        }

        public static void SetCtrlValue(Form parentForm, Control ctrl, string value)
        {
            if (parentForm.InvokeRequired)
            {
                SetCtrlValueHandler method = new SetCtrlValueHandler(SetCtrlValueMethod);
                parentForm.BeginInvoke(method, new object[] { ctrl, value });
            }
            else
            {
                SetCtrlValueMethod(ctrl, value);
            }
        }

        public static void SetCtrlValue(UserControl parentCtrl, Control ctrl, string value)
        {
            if (parentCtrl.InvokeRequired)
            {
                SetCtrlValueHandler method = new SetCtrlValueHandler(SetCtrlValueMethod);
                parentCtrl.BeginInvoke(method, new object[] { ctrl, value });
            }
            else
            {
                SetCtrlValueMethod(ctrl, value);
            }
        }

        private static void SetCtrlValueMethod(Control ctrl, string value)
        {
            if (ctrl is TextBox)
            {
                TextBox box = ctrl as TextBox;
                box.Text = value;
            }
            else if (ctrl is ComboBox)
            {
                ComboBox box2 = ctrl as ComboBox;
                try
                {
                    int selIndex = 0;
                    try
                    {
                        selIndex = int.Parse(value);
                        if (selIndex < box2.Items.Count - 1)
                        {
                            box2.SelectedIndex = selIndex;
                        }
                        else
                        {
                            box2.SelectedIndex = box2.FindString(value);
                        }
                    }
                    catch
                    {
                        box2.SelectedIndex = box2.FindString(value);
                    }

                }
                catch (Exception exception)
                {
                    //LogFile.Log.Debug(exception.Message);
                }
            }
            else if (ctrl is Label)
            {
                Label label = ctrl as Label;
                label.Text = value;
            }
            else if (ctrl is Button)
            {
                Button button = ctrl as Button;
                button.Text = value;
            }
            else if (ctrl is NumericUpDown)
            {
                NumericUpDown down = ctrl as NumericUpDown;
                down.Value = int.Parse(value);
            }
            else if (ctrl is Form)
            {
                Form form = ctrl as Form;
                form.Text = value;
            }
            else if (ctrl is ProgressBar)
            {
                ProgressBar bar = ctrl as ProgressBar;
                bar.Value = int.Parse(value);
            }
            else if (ctrl is CheckBox)
            {
                try
                {
                    CheckBox cb = ctrl as CheckBox;
                    cb.Checked = bool.Parse(value);
                }
                catch
                {
                }
            }
            else
            {
                ctrl.Text = value;
            }
        }

        private delegate void SetCtrlVisibleHandler(Control ctrl, bool value);
        public static void SetCtrlVisible(Form parentForm, Control ctrl, bool value)
        {
            if (parentForm.InvokeRequired)
            {
                SetCtrlVisibleHandler method = new SetCtrlVisibleHandler(SetCtrlVisibleMethod);
                parentForm.BeginInvoke(method, new object[] { ctrl, value });
            }
            else
            {
                SetCtrlVisibleMethod(ctrl, value);
            }
        }

        private static void SetCtrlVisibleMethod(Control ctrl, bool value)
        {
            try
            {
                ctrl.Visible = value;
            }
            catch { }
        }

        private delegate void SetCtrlTagHandler(Control ctrl, string value);
        public static void SetCtrlTag(Form parentForm, Control ctrl, string value)
        {
            if (parentForm.InvokeRequired)
            {
                SetCtrlTagHandler method = new SetCtrlTagHandler(SetCtrlTagMethod);
                parentForm.BeginInvoke(method, new object[] { ctrl, value });
            }
            else
            {
                SetCtrlTagMethod(ctrl, value);
            }
        }

        private static void SetCtrlTagMethod(Control ctrl, string value)
        {
            try
            {
                ctrl.Tag = value;
            }
            catch { }
        }
    }
}
