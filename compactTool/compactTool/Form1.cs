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

namespace compactTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //选取文件
            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.ShowDialog();
            ////MessageBox.Show(ofd.FileName);
            //textBox1.Text = ofd.FileName; // E:\图片\4f43feb64b.jpg
            //选取文件夹
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            textBox1.Text = fbd.SelectedPath; // E:\图片

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filePath = textBox1.Text.Trim();
            string fileDirectory = Path.GetDirectoryName(filePath);
            string fileName = Path.GetFileName(filePath);
            string newFileName = Path.GetFileNameWithoutExtension(filePath);
            string PassWord = textBox2.Text.Trim();

            ZipClass zc = new ZipClass();
            zc.SetZipFile(filePath, newFileName,fileDirectory,PassWord);
            //清空文本框
            textBox2.Text = "";
            textBox1.Text = "";
            MessageBox.Show("压缩成功！");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                //复选框被勾选，明文显示
                textBox2.PasswordChar = new char();
            }
            else
            {
                //复选框被取消勾选，密文显示
                textBox2.PasswordChar = '*';
            }

        }
    }
}
