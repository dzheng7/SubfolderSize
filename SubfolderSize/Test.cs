using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SubfolderSize 
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }
        string direction = "=";
        int[] sortArray = new int[0];
        string[] names = new string[0];
        string[] folderList = new string[0];
        private string[] AddStrArr(string[] array, string item, int location) { return new string[0]; }
        private int[] AddIntArr(int[] array, int item, int location) { return new int[0]; }
        private void sizeSortCode()
        {
            int[] temp = new int[0];
            temp = AddIntArr(temp, sortArray[0], 0);
            folderList = AddStrArr(folderList, names[0], 0);
            if (direction.ToLower() == "<")
            {
                //temp = sortArray.OrderByDescending(c => c).ToArray();
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
            }
            else if (direction.ToLower() == ">")
            {
                for (int i = 1; i < sortArray.Length; i++)
                {
                    bool inserted = false;
                    for (int j = 0; j < temp.Length; j++)
                    {
                        if (sortArray[i] < temp[j] && (j == 0 || (j > 0 && sortArray[i] >= temp[j - 1])))
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
                        //temp[temp.Length - 1] = sortArray[i];
                        //folderList[folderList.Length - 1] = names[i];
                    }
                    inserted = false;
                }
                int[] intArr = new int[temp.Length];
                //richTextBox1.Text += temp.Length + "\n";
                for (int j = 0; j < temp.Length; j++)
                {
                    //richTextBox1.Text += j.ToString() + "\n";
                    intArr[j] = temp[temp.Length - 1 - j];
                }
                temp = intArr;
            }
            else
            {
                temp = sortArray;
                folderList = names;
            }
        }
        private void startMiscCode()
        {
            //MessageBox.Show(subfolders.Length + ", " + folderList.Length);
            //string show = "Original: \n";
            /*string show = "#: \n";
            for (int k = 0; k < subfolderSize.Length; k++)
            {
                show += subfolderSizes[k] + "\n";
            }
            show += "Original: \n";
            for (int n = 0; n < subfolders.Length; n++)
            //for(int m = 0; m < folderList.Length; m++) 
            {
                //show += "|" + folderList[m] + "\n";
                //show += subfolders[n] + ", " + folderList[n] + "\n";
            }
            show += "Sorted: \n";
            for (int a = 0; a < folderList.Length; a++)
            {
                show += folderList[a] + "\n";
            }
            //MessageBox.Show(show);
            richTextBox1.Text = show;*/
        }
    }
}
