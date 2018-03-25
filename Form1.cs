using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        bool check = false;
        String path = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            check = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
                richTextBox1.LoadFile(open.FileName, RichTextBoxStreamType.PlainText);
            this.Text = open.FileName;
            check = true;
            path = open.FileName;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
            if (check == false)
            {
                if (save.ShowDialog() == DialogResult.OK)
                    richTextBox1.SaveFile(save.FileName, RichTextBoxStreamType.PlainText);
                this.Text = save.FileName;
                path = save.FileName;
                check = true;
            }
            else
            {
                richTextBox1.SaveFile(path, RichTextBoxStreamType.PlainText);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Modified == true)
            {
                DialogResult dr = MessageBox.Show("Do you want to save?","unsavedfile",MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    richTextBox1.Modified = false;
                    saveToolStripMenuItem_Click(sender, e);
                    this.Close();
                }
                else
                {
                    richTextBox1.Modified = false;
                    this.Close();
                }
            }
            Application.Exit();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            font.Font = richTextBox1.SelectionFont;
            if (font.ShowDialog() == DialogResult.OK)
                richTextBox1.SelectionFont = font.Font;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK)
                richTextBox1.SaveFile(save.FileName, RichTextBoxStreamType.PlainText);
            this.Text = save.FileName;
            path = save.FileName;
            check = true;
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pageSetupDialog1.Document = pd;
            pageSetupDialog1.ShowDialog();
        }
    }
}
