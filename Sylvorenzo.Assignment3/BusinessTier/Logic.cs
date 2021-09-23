using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using DataTier;
namespace BusinessTier
{
    public class Logic
    {
        static Connection c = new Connection();

        string[] Lines = File.ReadAllLines(c.str);

        
        public bool readRecords()
        {




            Console.WriteLine("Insert Entertainment Type(Movie or TV Show) ");
            String entertainmentType = Console.ReadLine();

            //if statement that handles errors during user input
            if (entertainmentType.Contains("T") || entertainmentType.Contains("t"))
            {
                //Regex for entertainment Type 
                Regex regT = new Regex("^[T-V]{2} [S-w]{4}$");
                // validatorT verifies if the entertainment type matches the regular expression
                bool validatorT = regT.IsMatch(entertainmentType);
                //while the user input does not match the regular expression, the user would be asked to type
                //user input as specified.
                while (validatorT == false)
                {
                    Console.WriteLine("Please Insert entertainment Type as specified");
                    entertainmentType = Console.ReadLine();
                    validatorT = regT.IsMatch(entertainmentType);

                }
                // If the user input contains an M or m which symbolise movies, the entertainment type will be compared
                //to the regular expression.
            }else if(entertainmentType.Contains("M") || entertainmentType.Contains("m"))
            {
                //Regex for entertainment Type 
                Regex regM = new Regex("^[M]ovie$");
                //checks whether entertainment type matches regular expression.
                bool validatorM = regM.IsMatch(entertainmentType);
                //while the user input does not match the regular expression, the user would be asked to type
                //user input as specified.
                while (validatorM == false)
                {
                    Console.WriteLine("Please Insert entertainment Type as specified");
                    entertainmentType = Console.ReadLine();
                    validatorM = regM.IsMatch(entertainmentType);

                }
            }
            else
            {//while the entertainment type is a blank string the user will be asked to re-enter input
                while (entertainmentType == "")
                {
                    Console.WriteLine("Please Insert entertainment Type as specified");
                    entertainmentType = Console.ReadLine();
                    //if entertainment type is not a blank screen, it'll break out of the while loop
                    if (entertainmentType != "") break;
                }
            }
            

   




  

            //user input for release year is asked.
            Console.WriteLine("Insert Release Year");
            //user input is stored in the release year variable
            String ReleaseYear = Console.ReadLine();

            //regex is established for the year 
            Regex regY = new Regex("^[0-9]{4}$");
            // a boolean is xreated to see if user matches input
            bool validatorY = regY.IsMatch(ReleaseYear);

            //if user input does not match th regex expression, new user input will be asked until the expression
            //is matched.
            while(validatorY == false)
            {
                Console.WriteLine("Please insert year in numbers in the format displayed in brackets (yyyy)");
                ReleaseYear = Console.ReadLine();
                validatorY = regY.IsMatch(ReleaseYear);
            }

            StreamWriter sw = new StreamWriter("Netflix_report.csv");
            sw.WriteLine("Final Analysed: netflix_titles.csv\n\n");
            sw.WriteLine("NETFLIX REPORT");
            sw.WriteLine("-----------------");
            sw.WriteLine("show_id\t   " + "type\t   " + "release_year\t   " + "duration\t  " + "description\t    ");
            sw.WriteLine("-----------------------------------------------------------------------------");

            //for loop created to read through the csv file
            for (int x= 1; x < Lines.Length; x++)
                {
                //if the rows contains the specified release year and entertainment type, those rows will be displayed.
                if (Lines[x].Contains(ReleaseYear) && Lines[x].Contains(entertainmentType))
                {
                    //lines are split into fields/columns.
                    string[] fields = Lines[x].Split(',');
             
                    //writes fields with  the required fields to the console.
                    Console.WriteLine("{0} {1} {2} {3} {4}", fields[0], fields[1],fields[9], fields[7], fields[11]);

                    //writes fields with  the required fields to the csv file.
                    sw.WriteLine("{0} {1} {2} {3} {4}", fields[0], fields[1], fields[9], fields[7], fields[11]);


                }
            }
            //End of Report
            sw.WriteLine("End of Report");
            //closes file
            sw.Close();
            //this line is used to keep console open 
             Console.ReadLine();
            //returns true
             return true;
        }
    }
}
