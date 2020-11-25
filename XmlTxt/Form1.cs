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

namespace XmlTxt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = @"E:\Clientes\Romulus\Loja1\NfeEntrada_Loja1\202005\Xml\";
            DirectoryInfo directory = new DirectoryInfo(path);
            foreach (FileInfo file in directory.GetFiles())
            {
                if (file.Extension.ToUpper() == ".XML")
                {
                    string content = getStream(file.FullName);
                    TNfeProc tNfe = TNfeProc.GetNfeProc(content);
                    
                    continue;

                }


                file.Delete();
            }


        }

        string getStream(string path)
        {
            using(StreamReader sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }
    }

}


    

