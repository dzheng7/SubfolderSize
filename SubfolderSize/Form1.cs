using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
        CancellationTokenSource cts;
        private bool isRunning = false;
        public Form1() 
        {
            //MessageBox.Show("1");
            InitializeComponent();
            this.AcceptButton = startButton;
            int totalWidth = listView1.ClientSize.Width;
            listView1.Columns[0].Width = (int)(totalWidth * 0.25);
            listView1.Columns[1].Width = (int)(totalWidth * 0.75);
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
            int totalWidth = listView1.ClientSize.Width;
            listView1.Columns[0].Width = (int)(totalWidth * 0.25);
            listView1.Columns[1].Width = (int)(totalWidth * 0.75);
            textBox1.Text = path;

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
            totalSizeBox.Text = "";
            //label2.Text = "";
            //richTextBox1.Text = "";
            listView1.Items.Clear();
            textBox1.Text = "";
            totalSizeBox.BorderStyle = BorderStyle.None;
            progressBar1.Visible = false;
            //startButton.Enabled = true;
            totalSizeBox.Text = "";
            listView1.Items.Clear(); 
            startButton.Text = "Start";

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

        private async void startButton_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                isRunning = true;
                startButton.Text = "Stop";

                cts = new CancellationTokenSource();
                var token = cts.Token;  
                progressBar1.Visible = true;
                progressBar1.Style = ProgressBarStyle.Marquee;

                listView1.Items.Clear();

                // startButton.Enabled = false;
                clearButton.Enabled = false;
                totalSizeBox.Text = "";
                if (Directory.Exists(folderPath))
                {

                    int byteDim = 0;
                    byteDim = 0;
                    //richTextBox1.Text = folderPath;
                    //MessageBox.Show(folderPath);
                    if (folderPath.Substring(folderPath.Length - 1).Trim() != "/")
                    {
                        folderPath += "/";
                    }
                    try
                    {
                        await Task.Run(() =>
                        {
                            long folderSize = 0;
                            // double folderSize = DirSize(new DirectoryInfo(folderPath));
                            // var subfolders = new List<KeyValuePair<string, long>>();
                            string input = Path.GetFullPath(folderPath);
                            int count = 0;
                            foreach (var dir in Directory.EnumerateDirectories(input))
                            {
                                long size = DirSize(dir);
                                folderSize += size;
                                if (token.IsCancellationRequested)
                                {
                                    return;
                                }
                                this.BeginInvoke(new Action(() =>
                                {
                                    if (token.IsCancellationRequested)
                                    {
                                        return;
                                    }
                                    totalSizeBox.Text = "Total size: ";
                                    totalSizeBox.Text += getSizeString(folderSize, false);
                                    totalSizeBox.BorderStyle = BorderStyle.Fixed3D;
                                }));
                                long originalSize = size;
                                string sizeText = getSizeString(size, true);
                                this.Invoke(new Action(() =>
                                {
                                    var item = new ListViewItem(new[] { sizeText, dir });
                                    item.Tag = originalSize;
                                    listView1.Items.Add(item);

                                    if (count > 9)
                                    {
                                        listView1.ListViewItemSorter = new ListViewItemComparer(0, true);
                                        listView1.Sort();
                                    }
                                }));
                                count++;
                            }
                        });
                    } catch (OperationCanceledException) { }

                }
                else
                {
                    //MessageBox.Show(folderPath);
                    MessageBox.Show("Please use a legitimate folder");
                }

                folderList = new string[0];
                progressBar1.Visible = false;
                // startButton.Enabled = true;
                clearButton.Enabled = true; 
                isRunning = false;
                startButton.Text = "Start";

            }
            else
            {
                cts.Cancel();
                isRunning = false;
                progressBar1.Visible = false;
                startButton.Text = "Start";
            }

        }

        private string getSizeString(long size, bool spaces)
        {
            int byteDim = 0;
            while (size > 1023)
            {
                size /= 1024;
                byteDim++;
            }
            string sizeText = "";
            if (spaces)
            {
                if (size < 10)
                    sizeText += "      ";
                else if (size < 100)
                    sizeText += "    ";
                else if (size < 1000)
                    sizeText += "  ";
            }
            sizeText += size.ToString("F");
            string str = bitDim(byteDim);
            sizeText += str;
            sizeText += "B";
            if (size < 0)
                sizeText = "N/A";
            return sizeText;
        }
        private void listView1_Resize(object sender, EventArgs e)
        {
            int totalWidth = listView1.ClientSize.Width;
            int width = listView1.Columns[0].Width;
            listView1.Columns[1].Width = totalWidth - width;
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
        
        public static long DirSize(string path)
        {
            long size = 0;
            bool error = false;

            /*foreach(string file in Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories))
            {
                try
                {
                    FileInfo fi = new FileInfo(file);
                    size += fi.Length;
                }
                catch (UnauthorizedAccessException e)
                {
                    error = true;
                }
                catch (PathTooLongException p)
                {
                    error = true;
                }
            }*/
            try
            {
                foreach (var file in Directory.GetFiles(path))
                {
                    try
                    {
                        size += new FileInfo(file).Length;
                    }
                    catch { }
                }
            }
            catch { }

            try
            {
                foreach (var dir in Directory.GetDirectories(path))
                {
                    try
                    {
                        size += DirSize(dir);
                    }
                    catch { }
                }
            }
            catch { }


            if ((int)size == 0 && error)
                return -1;
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


            //figure out opening a new window based on file path



            /*if (!Directory.Exists(richTextBox1.SelectedText))
            {
                Process.Start(Application.ExecutablePath);
            }
            else
            {
                string temp = "\"" + richTextBox1.SelectedText.Trim() + "\"";
                Process.Start(Application.ExecutablePath, temp + " " + sortDir);
            }*/
            Process.Start(Application.ExecutablePath);
        }



        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //textBox1.Location = new Point(3, 3);
            //browseButton.Location = new Point(this.Size.Width - 185, 6);
            //textBox1.Size = new Size(browseButton.Location.X - 9, textBox1.Size.Height);

            //int totalWidth = listView1.ClientSize.Width;
            //listView1.Columns[0].Width = (int)(totalWidth * 0.25);
            //listView1.Columns[1].Width = (int)(totalWidth * 0.75);
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
                totalSizeBox.Text = "Total size: ";
                totalSizeBox.Text += folderSize.ToString("F");
                totalSizeBox.Text += bitDim(byteDim) + "B";
                totalSizeBox.BorderStyle = BorderStyle.Fixed3D;
                byteDim = 0;
                //richTextBox1.Text = folderPath;
                //MessageBox.Show(folderPath);
                if (folderPath.Substring(folderPath.Length - 1).Trim() != "/")
                {
                    folderPath += "/";
                }
                //richTextBox1.Text = "Size:              Folder: \n";
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
                   /* if (size < 10)
                        richTextBox1.Text += "      ";
                    else if (size < 100)
                        richTextBox1.Text += "    ";
                    else if (size < 1000)
                        richTextBox1.Text += "  ";
                    //richTextBox1.Text += Math.Round(size, 2).ToString();
                    richTextBox1.Text += size.ToString("F");
                    string str = bitDim(byteDim);
                    richTextBox1.Text += str;
                    richTextBox1.Text += "B";
                    richTextBox1.Text += "      " + folderList[m] + "\n";*/
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

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var hit = listView1.HitTest(e.Location);

            if (hit.Item != null)
            {
                int subItemIndex = hit.Item.SubItems.IndexOf(hit.SubItem);

                if (subItemIndex == 1) // file path column
                {
                    // Get the bounds of the clicked subitem
                    Rectangle cellBounds = hit.SubItem.Bounds;

                    // Create a temporary TextBox
                    System.Windows.Forms.TextBox tb = new System.Windows.Forms.TextBox();
                    tb.Bounds = cellBounds;
                    tb.Text = hit.SubItem.Text;
                    tb.ReadOnly = true;
                    tb.BorderStyle = BorderStyle.None;

                    // Add to ListView
                    listView1.Controls.Add(tb);

                    // Select all text for easy copy
                    tb.Focus();
                    tb.SelectAll();

                    // Remove TextBox when focus is lost
                    tb.LostFocus += (s, ev) =>
                    {
                        listView1.Controls.Remove(tb);
                        tb.Dispose();
                    };
                }
            }

        }

        private int sortColumn = -1; 
        private bool sortDescending = true;

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == sortColumn)
            {
                sortDescending = !sortDescending;
            }
            else
            {
                sortColumn = e.Column;
                sortDescending = false;
            }

            listView1.ListViewItemSorter = new ListViewItemComparer(e.Column, sortDescending);
            listView1.Sort();

        }

        //RIGHT CLICK CONTEXT MENU: COPY ITEM AND OPEN FILE IN WINDOWS EXPLORER
        private void OpenPath()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string filePath = listView1.SelectedItems[0].SubItems[1].Text;
                System.Diagnostics.Process.Start(filePath);
            }

        }

        private void CopyPath()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string filePath = listView1.SelectedItems[0].SubItems[1].Text;
                Clipboard.SetText(filePath);
            }

        }

        private void RunPath()
        {
            string filePath = listView1.SelectedItems[0].SubItems[1].Text;
            string temp = "\"" + filePath + "\"";
            Process.Start(Application.ExecutablePath, temp + " " + sortDir);
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = listView1.HitTest(e.Location);

                if (hit.Item != null)
                {
                    int subItemIndex = hit.Item.SubItems.IndexOf(hit.SubItem);

                    if (subItemIndex == 1) // right column (file path)
                    {
                        // Select the item
                        listView1.SelectedItems.Clear();
                        hit.Item.Selected = true;

                        // Show context menu at mouse position
                        contextMenuStrip1.Show(listView1, e.Location);
                    }
                }
            }

        }

        private void copyPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string filePath = listView1.SelectedItems[0].SubItems[1].Text;
                Clipboard.SetText(filePath);
            }
        }

        private void runThisPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = listView1.SelectedItems[0].SubItems[1].Text;
            string temp = "\"" + filePath + "\"";
            Process.Start(Application.ExecutablePath, temp + " " + sortDir);
        }

        private void openPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string filePath = listView1.SelectedItems[0].SubItems[1].Text;
                System.Diagnostics.Process.Start(filePath);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    public class ListViewItemComparer : IComparer
    {
        private int col;
        private bool desc;

        public ListViewItemComparer(int column, bool descending)
        {
            col = column;
            desc = descending;
        }

        public int Compare(object x, object y)
        {
            var itemA = (ListViewItem)x;
            var itemB = (ListViewItem)y;

            int result;
            if (col == 0) // left column: alphabetical
            {
                long valA = itemA.Tag is long ? (long)itemA.Tag : 0L;
                long valB = itemB.Tag is long ? (long)itemB.Tag : 0L;
                result = valA.CompareTo(valB);

            }
            else if (col == 1) // right column: file path
            {
                result = string.Compare(itemA.SubItems[col].Text, itemB.SubItems[col].Text);
            }
            else // fallback
            {
                result = string.Compare(itemA.SubItems[col].Text, itemB.SubItems[col].Text);
            }

            return desc ? -result : result;

        }
    }
    // System.Windows.Forms.VisualStyles.VisualStyleElement.ListView
    public class CustomListView : System.Windows.Forms.ListView
    {
        protected override void OnMouseDown(MouseEventArgs e)
        {
            var info = this.HitTest(e.Location);
            if (info.Item != null)
            {
                int subItemIndex = info.Item.SubItems.IndexOf(info.SubItem);

                if (subItemIndex == 0)
                {
                    // Left column clicked → skip base logic (no highlight)
                    return;
                }
            }
            base.OnMouseDown(e); // allow normal selection otherwise
        }
    }


}
