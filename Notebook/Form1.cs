using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Notebook
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            fontDialog.ShowColor = true;
        }
        private void FileExit_Click(object sender, EventArgs e)
        {
            if (notebox.TextLength != 0)
            {
                DialogResult mes = MessageBox.Show("Сохранить текущий документ перед закрытием?", "Выход из программы ", MessageBoxButtons.YesNo);
                if (mes == DialogResult.Yes)
                {
                    SaveFileDialog save = new SaveFileDialog();
                    save.Filter = "Текстовый файл |*.txt";
                    save.FileName = "Безымянный";
                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(save.FileName, notebox.Text);
                        this.Close();
                    }
                }
                else if (mes == DialogResult.No)
                {
                    this.Close();
                }
            }
        }

        private void FileNew_Click(object sender, EventArgs e)
        {
            if (notebox.TextLength != 0)
            {
               DialogResult mes = MessageBox.Show("Сохранить текущий документ перед созданием?", "Создание документа", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               if(mes == DialogResult.Yes)
                {
                    SaveFileDialog save = new SaveFileDialog();
                    save.FileName = "Безымянный";
                    save.Filter = "Текстовый файл |*.txt";
                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(save.FileName, notebox.Text);
                        notebox.Clear();
                    }
                }
               else if(mes == DialogResult.No)
                {
                    notebox.Clear();
                }
            }
        }

        private void FileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Тексовый файл |*.txt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                notebox.Text = File.ReadAllText(open.FileName);
            }
        }

        private void FileSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Тексовый файл |*.txt";
            if (save.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(save.FileName, notebox.Text);
            }
        }
        private void EditCopy_Click(object sender, EventArgs e)
        {
            if (notebox.SelectionLength > 0)
            {
                notebox.Copy();
            }
        }
        private void EditPaste_Click(object sender, EventArgs e)
        {
            notebox.Paste();
        }
        private void FilePrint_Click(object sender, EventArgs e)
        {
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    printDoc.Print();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка параметров печати", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void EditCut_Click(object sender, EventArgs e)
        {
            if (notebox.SelectionLength > 0)
            {
                notebox.Cut();
            }
        }
        private void HelpAboutProgram_Click(object sender, EventArgs e)
        {
            AboutProgramm prog = new AboutProgramm();
            prog.ShowDialog();

        }
        private void FormatFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = notebox.Font;
            DialogResult = fontDialog.ShowDialog();
            if (DialogResult == DialogResult.OK)
            {
                notebox.Font = fontDialog.Font;
                notebox.ForeColor = fontDialog.Color;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (notebox.TextLength != 0)
            {
                DialogResult mes = MessageBox.Show("Сохранить текущий документ перед закрытием?", "Выход из программы ", MessageBoxButtons.YesNo);
                if (mes == DialogResult.Yes)
                {
                    SaveFileDialog save = new SaveFileDialog();
                    save.Filter = "Текстовый файл |*.txt";
                    save.FileName = "Безымянный";
                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(save.FileName, notebox.Text);
                        Application.Exit();
                    }
                }
                else if (mes == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
