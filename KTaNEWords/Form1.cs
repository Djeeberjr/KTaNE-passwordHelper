using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTaNEWords
{
    public partial class form1 : Form
    {

        int length = 5;
        int hight = 6;

        TextBox[,] textBoxes;
        List<string> words;

        public form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// populate the words list
        /// </summary>
        private void  generateWordList()
        {
            words = new List<string>();
            
            words.Add("about");
            words.Add("after");
            words.Add("again");
            words.Add("below");
            words.Add("could");
            words.Add("every");
            words.Add("first");
            words.Add("found");
            words.Add("great");
            words.Add("house");
            words.Add("large");
            words.Add("learn");
            words.Add("never");
            words.Add("other");
            words.Add("place");
            words.Add("plant");
            words.Add("point");
            words.Add("right");
            words.Add("small");
            words.Add("sound");
            words.Add("spell");
            words.Add("still");
            words.Add("study");
            words.Add("their");
            words.Add("there");
            words.Add("these");
            words.Add("thing");
            words.Add("think");
            words.Add("three");
            words.Add("water");
            words.Add("where");
            words.Add("which");
            words.Add("world");
            words.Add("would");
            words.Add("write");

        }
        
        
        /// <summary>
        /// searches the password
        /// </summary>
        /// <returns>password or "!!!" if no password was found</returns>
        private string getWord()
        {

            for (int i = 0; i < length; i++)
            {
                if (words.Count == 1)
                {
                    return words.Single();
                }

                char[] c = new char[6];
                c[0] = textBoxes[i, 0].Text.ToLower()[0];
                c[1] = textBoxes[i, 1].Text.ToLower()[0];
                c[2] = textBoxes[i, 2].Text.ToLower()[0];
                c[3] = textBoxes[i, 3].Text.ToLower()[0];
                c[4] = textBoxes[i, 4].Text.ToLower()[0];
                c[5] = textBoxes[i, 5].Text.ToLower()[0];

                for (int j = words.Count - 1; j >= 0; j--)
                {
                    if (!c.Contains(words[j][i]))
                    {
                        words.RemoveAt(j);
                    }
                }
            }

            return "!!!";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           textBoxes = new TextBox[length, hight];

            for (int i = 0; i< length; i++)
            {
                for (int j = 0; j < hight; j++)
                {
                    textBoxes[i, j] = new TextBox();
                    textBoxes[i, j].Size = new Size(20, 20);
                    textBoxes[i, j].TabIndex = (i * length) + j;
                    textBoxes[i, j].MaxLength = 1;
                    textBoxes[i, j].Location = new Point(10 + (i*25),10+(j*25));
                    textBoxes[i, j].KeyPress += (a,s) => { SendKeys.Send("{Tab}"); }; 
                    this.Controls.Add(textBoxes[i,j]);
                }
            }

            generateWordList();

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            lableResult.Text = getWord();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            foreach(TextBox t in textBoxes)
            {
                t.Clear();
            }

            lableResult.Text = "???";
            generateWordList();
        }


    }
}
