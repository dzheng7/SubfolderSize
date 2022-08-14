using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;

namespace SubfolderSize 
{
    public partial class Form1 : Form 
    {
        public class FilePath
        {
            string path;
            public FilePath(string fPath)
            {
                path = fPath;
            }
            public FilePath()
            {

            }
            public void setPath(string fPath)
            {
                path = fPath;
            }
            public string getPath()
            {
                return path;
            }
        }
        string folderPath = "";
        string sortDir = ">";
        public Form1() 
        {
            //MessageBox.Show("1");
            InitializeComponent();
            this.AcceptButton = startButton;
            //textBox1.Location = new Point(3, 3);
            //browseButton.Location = new Point(this.Size.Width - 185, 6);
            //textBox1.Size = new Size(browseButton.Location.X - 9, textBox1.Size.Height);
            //richTextBox1.Text = "a\r\n";
            //richTextBox1.Text += "a\r\n";
        }

        public Form1(string path, string dir) 
        {
            //MessageBox.Show("2");
            this.AcceptButton = startButton;
            InitializeComponent();
            textBox1.Text = path;
            if(dir == ">")
            {
                comboBox1.SelectedIndex = comboBox1.FindStringExact("Big to Small");
                //Or High to Low
                //Or Descending
            }
            else if (dir == "<")
            {
                comboBox1.SelectedIndex = comboBox1.FindStringExact("Small to Big");
            }
            else
            {
                comboBox1.SelectedIndex = comboBox1.FindStringExact("None");
            }
            startButton_Click(this, new EventArgs());
        }

        #region Elements
        private void textBox1_TextChanged(object sender, EventArgs e) 
        {
            if (textBox1.Text.Trim() != "") 
            {
                startButton.Enabled = true;
                folderPath = textBox1.Text;
            } 
            else 
            {
                startButton.Enabled = false;
            }
        }

        private void browseButton_Click(object sender, EventArgs e) 
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) 
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                //folderPath = folderBrowserDialog1.SelectedPath;
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            //label2.Text = "";
            richTextBox1.Text = "";
            textBox1.Text = "";
            comboBox1.ResetText();
            textBox2.BorderStyle = BorderStyle.None;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

        private void startButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(folderPath))
            {
                int byteDim = 0;
                double folderSize = DirSize(new DirectoryInfo(folderPath));
                while (folderSize > 1023)
                {
                    byteDim++;
                    folderSize /= 1024;
                }
                textBox2.Text = "Total size: ";
                textBox2.Text += folderSize.ToString("F");
                textBox2.Text += bitDim(byteDim) + "B";
                textBox2.BorderStyle = BorderStyle.Fixed3D;
                byteDim = 0;
                //richTextBox1.Text = folderPath;
                //MessageBox.Show(folderPath);
                if (folderPath.Substring(folderPath.Length - 1).Trim() != "/")
                {
                    folderPath += "/";
                }
                richTextBox1.Text = "Size:              Folder: \n";
                string[] subfolders = Directory.GetDirectories(folderPath);
                int[] subfolderSizes = new int[subfolders.Length];
                double[] subfolderSize = new double[subfolders.Length];
                int[] multiplier = new int[subfolderSize.Length];
                long tempSize = 0;
                for (int i = 0; i < subfolders.Length; i++)
                {//C:/Daniel/College
                    tempSize = DirSize(new DirectoryInfo(subfolders[i]));

                    subfolderSize[i] = tempSize;
                }
                sizeListD = subfolderSize;
                nameList = subfolders;
                double[] sortedSizes = subfolderSize;
                if (sortDir != "=")
                {
                    sortedSizes = sizeSortD(subfolderSize, subfolders, sortDir);
                }
                else
                {
                    folderList = subfolders;
                }
                for (int m = 0; m < sortedSizes.Length; m++)
                {
                    byteDim = 0;
                    double size = sortedSizes[m];
                    while (size > 1023)
                    {
                        size /= 1024;
                        byteDim++;
                    }
                    //byteDim += multiplier[m];
                    if (size < 10)
                        richTextBox1.Text += "      ";
                    else if (size < 100)
                        richTextBox1.Text += "    ";
                    else if (size < 1000)
                        richTextBox1.Text += "  ";
                    //richTextBox1.Text += Math.Round(size, 2).ToString();
                    richTextBox1.Text += size.ToString("F");
                    string str = bitDim(byteDim);
                    richTextBox1.Text += str;
                    /*if (byteDim < 1)
                        richTextBox1.Text += "   ";
                    else if (byteDim == 1)
                        richTextBox1.Text += " K";
                    else if (byteDim == 2)
                        richTextBox1.Text += " M";
                    else if (byteDim == 3)
                        richTextBox1.Text += " G";
                    else if (byteDim == 4)
                        richTextBox1.Text += " T";
                    else if (byteDim == 5)
                        richTextBox1.Text += " P";
                    else
                        richTextBox1.Text += " _";*/

                    /*if (byteDim < 1)
                        richTextBox1.Text += " K";
                    else if (byteDim == 1)
                        richTextBox1.Text += " M";
                    else if (byteDim == 2)
                        richTextBox1.Text += " G";
                    else if (byteDim == 3)
                        richTextBox1.Text += " T";
                    else if (byteDim == 4)
                        richTextBox1.Text += " P";
                    else
                        richTextBox1.Text += " _";*/
                    richTextBox1.Text += "B";
                    richTextBox1.Text += "      " + folderList[m] + "\n";
                }
            }
            else
            {
                //MessageBox.Show(folderPath);
                MessageBox.Show("Please use a legitimate folder");
            }
            folderList = new string[0];
        }

        #region HelperFunc

        private int[] AddIntArr(int[] array, int item, int location)
        {
            int[] temp = new int[array.Length + 1];
            for (int i = 0; i < temp.Length; i++)
            {
                if (i < location)
                {
                    temp[i] = array[i];
                }
                else if (i == location)
                {
                    temp[i] = item;
                }
                else
                {
                    temp[i] = array[i - 1];
                }
            }
            return temp;
        }

        private double[] AddDblArr(double[] array, double item, double location)
        {
            double[] temp = new double[array.Length + 1];
            for (int i = 0; i < temp.Length; i++)
            {
                if (i < location)
                {
                    temp[i] = array[i];
                }
                else if (i == location)
                {
                    temp[i] = item;
                }
                else
                {
                    temp[i] = array[i - 1];
                }
            }
            return temp;
        }

        private string[] AddStrArr(string[] array, string item, int location)
        {
            //MessageBox.Show(item);
            string[] temp = new string[array.Length + 1];
            for (int i = 0; i < temp.Length; i++)
            {
                if (i < location)
                {
                    temp[i] = array[i];
                }
                else if (i == location)
                {
                    temp[i] = item;
                    //MessageBox.Show(temp[i]);
                }
                else
                {
                    temp[i] = array[i - 1];
                }
            }
            return temp;
        }

        private static long DirSize(DirectoryInfo d)
        {
            long size = 0;
            // Add file sizes.
            try
            {
                FileInfo[] fis = d.GetFiles();
                foreach (FileInfo fi in fis)
                {
                    size += fi.Length;
                }
                // Add subdirectory sizes.
                DirectoryInfo[] dis = d.GetDirectories();
                foreach (DirectoryInfo di in dis)
                {
                    size += DirSize(di);
                }
            }
            catch (Exception e)
            {

            }
            return size;  
        }

        private static string bitDim(int numDiv)
        {
            string temp = "";
            if (numDiv < 1)
                temp = "   ";
            else if (numDiv == 1)
                temp = " K";
            else if (numDiv == 2)
                temp = " M";
            else if (numDiv == 3)
                temp = " G";
            else if (numDiv == 4)
                temp = " T";
            else if (numDiv == 5)
                temp = " P";
            else
                temp = " _";
            return temp;
        }

        string[] folderList = new string[0];
        int[] sizeList = new int[0];
        string[] nameList = new string[0];
        double[] sizeListD = new double[0];
        private int[] sizeSort(int[] sortArray, string[] names, string direction)
        {
            int[] temp = new int[0];
            temp = AddIntArr(temp, sortArray[0], 0);
            folderList = AddStrArr(folderList, names[0], 0);
            #region CODE
            if (direction == "=")
            {
                if (sizeList.Length == 0)
                {
                    temp = sizeList;
                    folderList = nameList;
                }
                else
                {
                    temp = sortArray;
                    folderList = names;
                }
            }
            else
            {
                for (int i = 1; i < sortArray.Length; i++)
                {
                    bool inserted = false;
                    for (int j = 0; j < temp.Length; j++)
                    {
                        if (sortArray[i] < temp[j] && (j == 0 || (j > 0 && sortArray[i] >= temp[j - 1]))
)
                        {
                            temp = AddIntArr(temp, sortArray[i], j);
                            folderList = AddStrArr(folderList, names[i], j);
                            inserted = true;
                            break;
                        }
                    }
                    if (!inserted)
                    {
                        temp = AddIntArr(temp, sortArray[i], temp.Length);
                        folderList = AddStrArr(folderList, names[i], folderList.Length);
                    }
                    inserted = false;
                }
                if (direction == ">")
                {
                    int[] intArr = new int[temp.Length];
                    string[] strArr = new string[folderList.Length];
                    for (int j = 0; j < temp.Length; j++)
                    {
                        intArr[j] = temp[temp.Length - 1 - j];
                    }
                    for (int h = 0; h < folderList.Length; h++)
                    {
                        strArr[h] = folderList[folderList.Length - 1 - h]; 
                    }
                    temp = intArr;
                    folderList = strArr;
                }
            }
            #endregion
            
            return temp;
        }

        private double[] sizeSortD(double[] sortArray, string[] names, string direction)
        {
            double[] temp = new double[0];
            temp = AddDblArr(temp, sortArray[0], 0);
            folderList = AddStrArr(folderList, names[0], 0);
            #region CODE
            if (direction == "=")
            {
                if (sizeList.Length == 0)
                {
                    temp = sizeListD;
                    folderList = nameList;
                }
                else
                {
                    temp = sortArray;
                    folderList = names;
                }
            }
            else
            {
                for (int i = 1; i < sortArray.Length; i++)
                {
                    bool inserted = false;
                    for (int j = 0; j < temp.Length; j++)
                    {
                        if (sortArray[i] < temp[j] && (j == 0 || (j > 0 && sortArray[i] >= temp[j - 1]))
)
                        {
                            temp = AddDblArr(temp, sortArray[i], j);
                            folderList = AddStrArr(folderList, names[i], j);
                            inserted = true;
                            break;
                        }
                    }
                    if (!inserted)
                    {
                        temp = AddDblArr(temp, sortArray[i], temp.Length);
                        folderList = AddStrArr(folderList, names[i], folderList.Length);
                    }
                    inserted = false;
                }
                if (direction == ">")
                {
                    double[] dblArr = new double[temp.Length];
                    string[] strArr = new string[folderList.Length];
                    for (int j = 0; j < temp.Length; j++)
                    {
                        dblArr[j] = temp[temp.Length - 1 - j];
                    }
                    for (int h = 0; h < folderList.Length; h++)
                    {
                        strArr[h] = folderList[folderList.Length - 1 - h];
                    }
                    temp = dblArr;
                    folderList = strArr;
                }
            }
            #endregion

            return temp;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(richTextBox1.SelectedText))
            {
                Process.Start(Application.ExecutablePath);
            }
            else
            {
                //textBox2.Text = "Calculating";
                //MessageBox.Show("hi");
                /*ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = Application.ExecutablePath;
                startInfo.Arguments = richTextBox1.SelectedText + " " + sortDir;
                Process.Start(startInfo);*/
                //MessageBox.Show("1");
                //FilePath p = new FilePath(richTextBox1.SelectedText.Trim();
                string temp = "\"" + richTextBox1.SelectedText.Trim() + "\"";
                //string temp = richTextBox1.SelectedText.Trim();
                //        + " " + sortDir;
                Process.Start(Application.ExecutablePath, temp + " " + sortDir);
                //textBox2.Text = "";
                //MessageBox.Show("2");
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //textBox1.Location = new Point(3, 3);
            //browseButton.Location = new Point(this.Size.Width - 185, 6);
            //textBox1.Size = new Size(browseButton.Location.X - 9, textBox1.Size.Height);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Big to Small")
            {
                sortDir = ">";
            }
            else if (comboBox1.SelectedItem == "Small to Big")
            {
                sortDir = "<";
            }
            else if (comboBox1.SelectedItem == "None")
            {
                sortDir = "=";
            }
        }

        #endregion

        #region BackWorker
        private void startButton_Click2(object sender, EventArgs e)
        {
            backWorker1.RunWorkerAsync();
        }

        private void backWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //textBox2.Text = "Calculating";
            if (Directory.Exists(folderPath))
            {
                int byteDim = 0;
                double folderSize = DirSize(new DirectoryInfo(folderPath));
                while (folderSize > 1023)
                {
                    byteDim++;
                    folderSize /= 1024;
                }
                textBox2.Text = "Total size: ";
                textBox2.Text += folderSize.ToString("F");
                textBox2.Text += bitDim(byteDim) + "B";
                textBox2.BorderStyle = BorderStyle.Fixed3D;
                byteDim = 0;
                //richTextBox1.Text = folderPath;
                //MessageBox.Show(folderPath);
                if (folderPath.Substring(folderPath.Length - 1).Trim() != "/")
                {
                    folderPath += "/";
                }
                richTextBox1.Text = "Size:              Folder: \n";
                string[] subfolders = Directory.GetDirectories(folderPath);
                int[] subfolderSizes = new int[subfolders.Length];
                double[] subfolderSize = new double[subfolders.Length];
                int[] multiplier = new int[subfolderSize.Length];
                long tempSize = 0;
                long perSize = 0;
                for (int i = 0; i < subfolders.Length; i++)
                {//C:/Daniel/College
                    tempSize = DirSize(new DirectoryInfo(subfolders[i]));

                    perSize += tempSize;
                    backWorker1.ReportProgress((int)((perSize / folderSize) * 100));

                    subfolderSize[i] = tempSize;
                }
                sizeListD = subfolderSize;
                nameList = subfolders;
                double[] sortedSizes = subfolderSize;
                if (sortDir != "=")
                {
                    sortedSizes = sizeSortD(subfolderSize, subfolders, sortDir);
                }
                else
                {
                    folderList = subfolders;
                }
                for (int m = 0; m < sortedSizes.Length; m++)
                {
                    byteDim = 0;
                    double size = sortedSizes[m];
                    while (size > 1023)
                    {
                        size /= 1024;
                        byteDim++;
                    }
                    //byteDim += multiplier[m];
                    if (size < 10)
                        richTextBox1.Text += "      ";
                    else if (size < 100)
                        richTextBox1.Text += "    ";
                    else if (size < 1000)
                        richTextBox1.Text += "  ";
                    //richTextBox1.Text += Math.Round(size, 2).ToString();
                    richTextBox1.Text += size.ToString("F");
                    string str = bitDim(byteDim);
                    richTextBox1.Text += str;
                    /*if (byteDim < 1)
                        richTextBox1.Text += "   ";
                    else if (byteDim == 1)
                        richTextBox1.Text += " K";
                    else if (byteDim == 2)
                        richTextBox1.Text += " M";
                    else if (byteDim == 3)
                        richTextBox1.Text += " G";
                    else if (byteDim == 4)
                        richTextBox1.Text += " T";
                    else if (byteDim == 5)
                        richTextBox1.Text += " P";
                    else
                        richTextBox1.Text += " _";*/

                    /*if (byteDim < 1)
                        richTextBox1.Text += " K";
                    else if (byteDim == 1)
                        richTextBox1.Text += " M";
                    else if (byteDim == 2)
                        richTextBox1.Text += " G";
                    else if (byteDim == 3)
                        richTextBox1.Text += " T";
                    else if (byteDim == 4)
                        richTextBox1.Text += " P";
                    else
                        richTextBox1.Text += " _";*/
                    richTextBox1.Text += "B";
                    richTextBox1.Text += "      " + folderList[m] + "\n";
                }
            }
            else
            {
                //MessageBox.Show(folderPath);
                MessageBox.Show("Please use a legitimate folder");
            }
            folderList = new string[0];
            //textBox2.Text = "";
        }

        private void backWorker1_RunWorkerCompleted(object sender,
            RunWorkerCompletedEventArgs e)
        {

        }

        private void backWorker1_ProgressChanged(object sender,
           ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            this.Text = e.ProgressPercentage.ToString();
        }


        private void backWorker1_RunWorkerCompleted_1(object sender, RunWorkerCompletedEventArgs e)
        {

        }
        #endregion
    }
}
