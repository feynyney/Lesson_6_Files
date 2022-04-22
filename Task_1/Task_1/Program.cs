using System;
using System.Globalization;
using System.IO;

namespace Task_1
{
    internal class Program
    {
        public static void WriteFile()
        {
            using (StreamWriter db_write = new StreamWriter("Database.txt", true))
            {
                string note = string.Empty;

                string now = DateTime.Now.ToShortDateString();
                note += now + "#";

                Console.WriteLine("Enter your name: ");
                note += Console.ReadLine() + "#";

                Console.WriteLine("Enter your age: ");
                int age = int.Parse(Console.ReadLine());
                note += age + "#";

                Console.WriteLine("Enter height: ");
                note += Console.ReadLine() + "#";

                Console.WriteLine("Enter your date of birth");
                string date_format = "dd/MM/yyyy";
                DateTime date_of_birth;

                Console.WriteLine("Enter a date in the format dat/month/year");
                string entered_date = Console.ReadLine();

                date_of_birth = DateTime.ParseExact(entered_date, date_format, CultureInfo.InvariantCulture);
                note += date_of_birth.ToShortDateString() + "#";

                Console.WriteLine("Enter the place of birth: ");
                note += Console.ReadLine();

                db_write.WriteLine(note);

            }
        }

        public static void ReadFile()
        {
             using (StreamReader db_read = new StreamReader("Database.txt"))
            {
                string[] subs;
                int j = 1;

                Console.WriteLine($"{"id"} {"date of note",15} {"name",15} {"age",17} {"height",17} {"date of birth",18} {"place of birth",18}");
                Console.WriteLine("\n");

                while (!db_read.EndOfStream)
                {
                    string Read_text = db_read.ReadLine();
                    subs = Read_text.Split('#');

                    Console.Write(j);
                    for(int i = 0; i < subs.Length; i++)
                    {
                        Console.Write($"{subs[i] , 17}");
                    }

                    j++;
                    Console.WriteLine('\n');
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("1 - to add a new note\n2 - to show existing notes");
            char choice = char.Parse(Console.ReadLine());

            switch(choice)
            {
                case '1':
                    WriteFile();
                    break;
                case '2':
                    ReadFile();
                    break;
            }            
        }
    }
}
