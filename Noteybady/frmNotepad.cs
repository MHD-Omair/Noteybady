using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Noteybady
{
    public partial class frmNotepad : Form
    {
        String path = String.Empty;

        public frmNotepad() => InitializeComponent();
        
        /// File Envnts
        private void newToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.Clear();

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void themBlackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.ForeColor = Color.White;
            richTextBox1.BackColor = Color.Black;
            this.BackColor = Color.Gray;
        }

        private void themGrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.ForeColor = Color.Black;
            richTextBox1.BackColor = Color.Gray;
            this.BackColor = Color.Gray;
        }

        private void themDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.ForeColor = Color.Black;
            richTextBox1.BackColor = Color.White;
            this.BackColor = Color.White;
        }
    }
}
