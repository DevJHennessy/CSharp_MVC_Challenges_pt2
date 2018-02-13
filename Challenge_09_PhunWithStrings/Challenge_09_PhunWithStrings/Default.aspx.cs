using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Challenge_09_PhunWithStrings
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //1. Reverse your name:
            //John Hennessy would be yssenneH nhoJ


            //First way:
            /*
            string wordsBefore = "John Hennessy";
            string[] wordsWorking = wordsBefore.Split(new[] { ' ' }, 2);
            string wordsAfter = string.Format("{1} {0}", wordsWorking);
            string result = string.Join(" ", wordsAfter.Split(' ').Select(x => new string(x.Reverse().ToArray())));
            resultLabel.Text = result;
            */

            //Second way:
            //You want to iterate as long as i is greater than or equal to zero, where i
            //is the the length of name/string, subtracting one each time through.
            //You have to subtract 1 from the length of the name so that it works with
            //arrays, otherwise you end up out of bounds.
            //(int i = name.Length - 1; i >= 0; i--) This is a simple formula to go 
            //from the last item to the first item in the array.
            
            /*
            string name = "John Hennessy";
            for (int i = name.Length - 1; i >= 0; i--)
            {
                resultLabel.Text += name[i];
            }
            */
            

            //2. Reverse this sequence:
            //Finished should look like Chewbacca,Han,Leia,Luke

            /*
            //First way:
            string names = "Luke,Leia,Han,Chewbacca";
            string reverse = string.Join(",", names.Split(',').Reverse());
            resultLabel.Text = reverse;
            */

            /*
            //Second way:
            string names = "Luke,Leia,Han,Chewbacca";
            string[] rebelScum = names.Split(',');
            string result = "";
            for (int i = rebelScum.Length - 1; i >= 0; i--)
            {
                result += rebelScum[i] + ",";
            }
            result = result.Remove(result.Length - 1, 1);
            resultLabel.Text = result;
            */

            //3. Use the sequence to create ascii art:
           //Take Luke, Leia, Han, Chewbacca and make it look like (total 14 characters):
           /* *****luke*****
            * *****leia*****
            * *****han******
            * **chewbacca*** */
            /*
            string names = "Luke,Leia,Han,Chewbacca";
            string[] splitNames = names.Split(',');
            string result = "";
            for (int i = 0; i < splitNames.Length; i++)
            {
                int padLeft = (14 - splitNames[i].Length) / 2;
                string theForce = splitNames[i].PadLeft(splitNames[i].Length + padLeft, '*');
                result += theForce.PadRight(14, '*') + "<br />";
            }
            resultLabel.Text = result;
            */

            //4. Solve this puzzle:
            //Goal is to make the line look like"
            //Now is the time for all good men to come to the aid of their country.
            //A. Remove the remove me.
            //B. Make all lowercase except for first letter.
            //C. Replace all Z's with T's

            
            string puzzle = "NOW IS ZHEremove-me ZIME FOR ALL GOOD MEN ZO COME ZO ZHE AID OF ZHEIR COUNTRY.";
            string removeMe = "remove-me";
            int index = puzzle.IndexOf(removeMe);
            puzzle = puzzle.Remove(index, removeMe.Length);
            puzzle = puzzle.Substring(0, 1) + puzzle.Substring(1).ToLower();
            puzzle = puzzle.Replace('z', 't');
            resultLabel.Text = puzzle;
            


        }




    }
}