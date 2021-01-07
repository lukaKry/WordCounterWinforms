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

namespace WordCounterWinforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_loadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFile.FileName;
                textBox1.Text = File.ReadAllText(filePath, Encoding.Default);
            }

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void btn_clear2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void btn_split_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            string[] textSplit = text.Split(' ', ',', '.', '?', '!', '-');

            foreach (string word in textSplit)
            {
                if (!listBox1.Items.Contains(word))
                {
                    listBox1.Items.Add(word);
                }
            }
        }

        private void btn_erase_Click(object sender, EventArgs e)
        {
           

            //swaping polish language special symbol using for loop

           string text1 = textBox1.Text;
           char[] letters = text1.ToCharArray();

            for (int i = 0; i < letters.Length; i++)
            {
                switch (letters[i])
                {
                    case 'ł': letters[i] = 'l'; break;
                    case 'Ł': letters[i] = 'L'; break;
                    case 'ą': letters[i] = 'a'; break;
                    case 'Ą': letters[i] = 'A'; break;
                    case 'ć': letters[i] = 'c'; break;
                    case 'Ć': letters[i] = 'C'; break;
                    case 'ę': letters[i] = 'e'; break;
                    case 'Ę': letters[i] = 'E'; break;
                    case 'ń': letters[i] = 'n'; break;
                    case 'Ń': letters[i] = 'N'; break;
                    case 'ó': letters[i] = 'o'; break;
                    case 'Ó': letters[i] = 'O'; break;
                    case 'ś': letters[i] = 's'; break;
                    case 'Ś': letters[i] = 'S'; break;
                    case 'ź': letters[i] = 'z'; break;
                    case 'Ź': letters[i] = 'Z'; break;
                    case 'ż': letters[i] = 'z'; break;
                    case 'Ż': letters[i] = 'Z'; break;
                    default:
                        break;
                    
                }
            }
            textBox1.Clear();
            string textNoForaignLetters = new string(letters);
            textBox1.Text = textNoForaignLetters;
            
            



        }

        private void btn_Sort_Click(object sender, EventArgs e)
        {
            listBox1.Sorted = true;
        }

        private void btn_sort2_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_count_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            string[] textSplit = text.Split(' ', ',', '.', '?', '!', '-');

            //change array to a list

            List<WordCounter> wordCounters = new List<WordCounter>();

            //go throug the array
            //if the word is already on the list add 1 to frequency, else add word to the list

            foreach (string word in textSplit)
            {
                //method finds if the word is on the list
                WordCounter foundWord =  wordCounters.Find(x => x.word == word);

                if (foundWord == null)
                {
                    wordCounters.Add(new WordCounter(word, 1));
                }
                else 
                {
                    foundWord.frequency += 1;
                }        

            }
            //should we have now a full list of words

            //add some details to the listview
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Sorting = SortOrder.Descending;

            //add wordcounters elements to the listview
            foreach (WordCounter w in wordCounters)
            {
                string[] items = new string[] {w.frequency.ToString("D5"), w.word };
                ListViewItem lst = new ListViewItem(items);
                listView1.Items.Add(lst);
            }


            

            


        }
    }
}
