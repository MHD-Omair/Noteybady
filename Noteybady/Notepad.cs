using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text.Editor
{
    public partial class frmNotepad : Form
    {
        string filePath = "";//Used to store the file location

        public frmNotepad() =>InitializeComponent();

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0)
            {
                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
            }
            else
            {
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filePath = "";
            richTextBox1.Text = "";
           
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Rich Text Files|*.rtf", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        filePath = ofd.FileName;
                        Task<string> text = sr.ReadToEndAsync();
                        richTextBox1.Text = text.Result;
                    }
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Rich Text Files|*.rtf", ValidateNames = true })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName))
                        {
                            sw.WriteLineAsync(richTextBox1.Text);

                        }

                    }
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLineAsync(richTextBox1.Text);
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "TextDocument|*.txt", ValidateNames = true })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName))
                        {
                            sw.WriteLineAsync(richTextBox1.Text);

                        }

                    }
                }
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            printPreviewDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) =>this.Close();

        private void undoToolStripMenuItem_Click(object sender, EventArgs e) =>richTextBox1.Undo();

        private void randoToolStripMenuItem_Click(object sender, EventArgs e) =>richTextBox1.Redo();

        private void cutToolStripMenuItem_Click(object sender, EventArgs e) =>richTextBox1.Cut();

        private void copyToolStripMenuItem_Click(object sender, EventArgs e) =>richTextBox1.Copy();

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e) =>richTextBox1.Paste();

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) =>richTextBox1.SelectedText = "";

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e) =>richTextBox1.SelectAll();

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordWrapToolStripMenuItem.Checked == true)
            {
                wordWrapToolStripMenuItem.Checked = false;
                richTextBox1.WordWrap = false;
            }
            else
            {
                wordWrapToolStripMenuItem.Checked = true;
                richTextBox1.WordWrap = true;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog.ShowDialog();
            richTextBox1.SelectionFont = new Font(fontDialog.Font.FontFamily, fontDialog.Font.Size, fontDialog.Font.Style);
        }

        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            richTextBox1.ForeColor = colorDialog.Color;
        }

        private void haighlightTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionBackColor = Color.Yellow;
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            richTextBox1.BackColor = colorDialog.Color;
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e) =>richTextBox1.ZoomFactor = 2;

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e) =>richTextBox1.ZoomFactor = 1;

        private void restoreDefaultZoomToolStripMenuItem_Click(object sender, EventArgs e) =>richTextBox1.ZoomFactor = 0;
    }
}
