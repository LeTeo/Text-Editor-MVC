using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextEditorMVC
{
    public interface IMainForm
    {
        string FilePath { get; }
        string Content { get; set; }
        void setSymbolCount(int count);
        event EventHandler FileOpenClick;
        event EventHandler FileSaveClick;
        event EventHandler ContentChanged;

    }

    public partial class MainForm : Form, IMainForm
    {
        public MainForm()
        {
            InitializeComponent();
            button2.Click += new EventHandler(button2_Click);
            button3.Click += button3_Click;
            textBox2.TextChanged += textBox2_TextChanged;
            button1.Click += button1_Click;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
        }
        #region Events
        void button2_Click(object sender, EventArgs e)
        {
            if (FileOpenClick != null) FileOpenClick(this, EventArgs.Empty);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (FileSaveClick != null) FileSaveClick(this, EventArgs.Empty);
        }
        
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (ContentChanged != null) ContentChanged(this, EventArgs.Empty);
        }
        #endregion

        #region IMainForm
        public string FilePath
        {
            get { return textBox1.Text; }
        }

        public string Content
        {
            get
            {
                return textBox2.Text;
            }
            set
            {
                textBox2.Text = value;
            }
        }

        public void setSymbolCount(int count)
        {
            toolStripStatusLabel2.Text = count.ToString();
        }

        public event EventHandler FileOpenClick;

        public event EventHandler FileSaveClick;

        public event EventHandler ContentChanged;
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы|*.txt|Все файлы|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog.FileName;
                if (FileOpenClick != null) FileOpenClick(this, EventArgs.Empty);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            textBox2.Font = new Font("Calibri", (float)numericUpDown1.Value);
        }
    }
}
