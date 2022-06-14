using System.Data;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Noteybady
{
    public partial class frmNotepad : Form
    {
        public frmNotepad() => InitializeComponent();

        /// File Envnts
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedPath = "";

            Thread t = new Thread((ThreadStart)(() => {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Rich Text Files (*.rtf)|*.rtf|" +
                             "Microsoft Word Document (*.doc)|*.doc|" +
                             "Hypertext Markup Language Document (*.html)|*.html" +
                             "Text Document (*.txt)|*.txt|";
                ofd.ValidateNames = true;
                ofd.Multiselect = false; 
                ofd.FilterIndex = 4;
                ofd.RestoreDirectory = true;
                
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        selectedPath = ofd.FileName;
                        Task<string> text = sr.ReadToEndAsync();
                       /// richTextBox1.Text =text.Result;
                    }
                }
            }));

            // Run your code from a thread that joins the STA Thread
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();

            // e.g C:\Users\MyName\Desktop\myfile.* *
            Console.WriteLine(selectedPath);
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
             string selectedPath = "";

             Thread t = new Thread((ThreadStart)(() => {
                 SaveFileDialog sfd = new SaveFileDialog();

                 sfd.Filter ="Rich Text Files (*.rtf)|*.rtf|" +
                             "Microsoft Word Document (*.doc)|*.doc|" +
                             "Hypertext Markup Language Document (*.html)|*.html" +
                             "Text Document (*.txt)|*.txt|";
                 sfd.ValidateNames = true;
                 sfd.FilterIndex = 4;
                 sfd.RestoreDirectory = true;
                 if (string.IsNullOrEmpty(selectedPath))
                 {
                     if (sfd.ShowDialog() == DialogResult.OK)
                     {
                         using (StreamWriter sw = new StreamWriter(sfd.FileName))
                         {
                             sw.WriteLineAsync(richTextBox1.Text);
                         }
                       /*  richTextBox1.SaveFile(sfd.FileName, RichTextBoxStreamType.RichText);
                         selectedPath = sfd.FileName;
                         this.Text = string.Format("{0} - Basic Word Processor", sfd.FileName);*/
                     }
                 }
                 else
                 {
                     using (StreamWriter sw = new StreamWriter(selectedPath))
                     {
                         sw.WriteLineAsync(richTextBox1.Text);
                     }
                 }
             }));

             t.SetApartmentState(ApartmentState.STA);
             t.Start();
             t.Join();

             Console.WriteLine(selectedPath);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        ///
        /// Edit Envet
        ///

        private void undoToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.Undo();

        private void redoToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.Redo();

        private void cutToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.Cut();

            
        private void copyToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.Copy();

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.Paste();

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.SelectAll();

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.SelectionFont = fontDialog1.Font;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox1.SelectionColor = colorDialog1.Color;
        }

        ///
        /// Help Envet
        ///

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a Notepad for educational purposes. ");
        }

        ///
        /// Theme Envet
        ///

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.ForeColor = Color.Black;
            richTextBox1.BackColor = Color.White;
            this.BackColor = Color.White;
        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.ForeColor = Color.White;
            richTextBox1.BackColor = Color.Black;
            this.BackColor = Color.Gray;
        }

        private void grayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.ForeColor = Color.Black;
            richTextBox1.BackColor = Color.Gray;
            this.BackColor = Color.Gray;
        }
    }
}
