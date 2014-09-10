using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Security.Cryptography;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

delegate void SetTextCallbackType(object text, object type = null);
delegate void SetTextCallbackListBox(ListBox obj, object text);
delegate void SetTextCallbackListBoxClear(ListBox obj);
delegate void SetTextCallbackListBoxEdit(ListBox obj, int id, object text);
delegate void SetTextCallbackTextBox(TextBox obj, object text);
delegate void SetTextCallbackListBoxCombo(ComboBox obj, object text);
delegate void SetTextCallbackListBoxComboAdd(ComboBox obj, int num, object text);
delegate void SetTextCallbackListBoxComboBool(ComboBox obj, bool value);
delegate void SetTextCallbackListBoxChkBool(CheckBox obj, bool value);
delegate void SetTextCallbackComboBoxClear(ComboBox obj);
delegate void SetTextCallbackButton(Button obj, bool value);
delegate void SetTextCallbackButtonHide(Button obj, bool value, bool value2);
delegate void SetTextCallbackLabel(Label obj, object text);
delegate void SetTextCallbackProgressBar(ProgressBar obj, bool value);
delegate void SetTextCallbackProgressBar2(ProgressBar obj, bool value, int x1, int x2, int x3);

//FormThread v2.1 writen by MarHazK (6 Feb 2014)
namespace TeraLauncher
{
    public interface Form01 { void send(ListBox obj, object _temp); }
    public interface Form02 { void send(ComboBox obj, object _temp); }
    public interface Form03 { void send(ComboBox obj, int num, object _temp); }
    public interface Form04 { void send(ComboBox obj, bool _temp); }
    public interface Form05 { void send(Button obj, bool _temp); }
    public interface Form06 { void send(ListBox obj, int id, object _temp); }
    public interface Form07 { void send(Button obj, bool _temp, bool _temp2); }
    public interface Form08 { void send(ProgressBar obj, bool _temp); }
    public interface Form09 { void send(ListBox obj); }
    public interface Form10 { void send(ComboBox obj); }
    public interface Form11 { void send(TextBox obj, object _temp); }
    public interface Form12 { void send(Label obj, object _temp); }
    public interface Form13 { void send(ProgressBar obj, bool _temp, int _temp2, int _temp3, int _temp4); }
    class FormThread : Form01, Form02, Form03, Form04, Form05, Form06, Form07, Form08, Form09, Form10, Form11, Form12, Form13
    {
        public void send(ListBox obj, int id, object _temp)
        {
            try
            {
                if (obj.InvokeRequired)
                {
                    SetTextCallbackListBoxEdit d = new SetTextCallbackListBoxEdit(send);
                    Program.Form.Invoke(d, new object[] { obj, id, _temp });
                }
                else
                {
                    obj.Items.RemoveAt(id);
                    obj.Items.Insert(id, _temp);
                }
            }
            catch { }
        }
        public void send(ListBox obj)
        {
            try
            {
                if (obj.InvokeRequired)
                {
                    SetTextCallbackListBoxClear d = new SetTextCallbackListBoxClear(send);
                    Program.Form.Invoke(d, new object[] { obj });
                }
                else
                {
                    obj.Items.Clear();
                }
            }
            catch { }
        }
        public void send(ComboBox obj)
        {
            try
            {
                if (obj.InvokeRequired)
                {
                    SetTextCallbackComboBoxClear d = new SetTextCallbackComboBoxClear(send);
                    Program.Form.Invoke(d, new object[] { obj });
                }
                else
                {
                    obj.Items.Clear();
                }
            }
            catch { }
        }
        public void send(ListBox obj, object _temp)
        {
            try
            {
                if (obj.InvokeRequired)
                {
                    SetTextCallbackListBox d = new SetTextCallbackListBox(send);
                    Program.Form.Invoke(d, new object[] { obj, _temp });
                }
                else
                {
                    obj.Items.Insert(0, _temp);
                }
            }
            catch { }
        }
        public void send(ComboBox obj, object _temp)
        {
            try
            {
                if (obj.InvokeRequired)
                {
                    SetTextCallbackListBoxCombo d = new SetTextCallbackListBoxCombo(send);
                    Program.Form.Invoke(d, new object[] { obj, _temp });
                }
                else
                {
                    obj.Items.Insert(0, _temp);
                }
            }
            catch { }
        }
        public void send(ComboBox obj, int num, object _temp)
        {
            try
            {
                if (obj.InvokeRequired)
                {
                    SetTextCallbackListBoxComboAdd d = new SetTextCallbackListBoxComboAdd(send);
                    Program.Form.Invoke(d, new object[] { obj, num, _temp });
                }
                else
                {
                    obj.Items.Insert(num, _temp);
                }
            }
            catch { }
        }
        public void send(ComboBox obj, bool _temp)
        {
            try
            {
                if (obj.InvokeRequired)
                {
                    SetTextCallbackListBoxComboBool d = new SetTextCallbackListBoxComboBool(send);
                    Program.Form.Invoke(d, new object[] { obj, _temp });
                }
                else
                {
                    obj.Enabled = _temp;
                }
            }
            catch { }
        }
        public void send(CheckBox obj, bool _temp)
        {
            try
            {
                if (obj.InvokeRequired)
                {
                    SetTextCallbackListBoxChkBool d = new SetTextCallbackListBoxChkBool(send);
                    Program.Form.Invoke(d, new object[] { obj, _temp });
                }
                else
                {
                    obj.Checked = _temp;
                }
            }
            catch { }
        }
        public void send(ProgressBar obj, bool _temp)
        {
            try
            {
                if (obj.InvokeRequired)
                {
                    SetTextCallbackButton d = new SetTextCallbackButton(send);
                    Program.Form.Invoke(d, new object[] { obj, _temp });
                }
                else
                {
                    obj.Visible = _temp;
                }
            }
            catch { }
        }
        public void send(ProgressBar obj, bool _temp, int _temp2, int _temp3, int _temp4)
        {
            try
            {
                if (obj.InvokeRequired)
                {
                    SetTextCallbackButton d = new SetTextCallbackButton(send);
                    Program.Form.Invoke(d, new object[] { obj, _temp, _temp2, _temp3, _temp4 });
                }
                else
                {
                    obj.Visible = _temp;
                    obj.Minimum = _temp2;
                    obj.Value = _temp3;
                    obj.Maximum = _temp4;
                }
            }
            catch { }
        }
        public void send(Button obj, bool _temp)
        {
            try
            {
                if (obj.InvokeRequired)
                {
                    SetTextCallbackButton d = new SetTextCallbackButton(send);
                    Program.Form.Invoke(d, new object[] { obj, _temp });
                }
                else
                {
                    obj.Enabled = _temp;
                }
            }
            catch { }
        }
        public void send(Button obj, bool _temp, bool _temp2)
        {
            try
            {
                if (obj.InvokeRequired)
                {
                    SetTextCallbackButton d = new SetTextCallbackButton(send);
                    Program.Form.Invoke(d, new object[] { obj, _temp, _temp2 });
                }
                else
                {
                    obj.Visible = _temp2;
                    obj.Enabled = _temp;
                }
            }
            catch { }
        }
        public void send(TextBox obj, object _temp)
        {
            try
            {
                if (obj.InvokeRequired)
                {
                    SetTextCallbackTextBox d = new SetTextCallbackTextBox(send);
                    Program.Form.Invoke(d, new object[] { obj, _temp });
                }
                else
                {
                    obj.Text = (string)_temp;
                }
            }
            catch { }
        }
        public void send(Label obj, object _temp)
        {
            try
            {
                if (obj.InvokeRequired)
                {
                    SetTextCallbackLabel d = new SetTextCallbackLabel(send);
                    Program.Form.Invoke(d, new object[] { obj, _temp });
                }
                else
                {
                    obj.Text = (string)_temp;
                }
            }
            catch { }
        }

    }
}
