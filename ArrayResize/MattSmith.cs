using System.Diagnostics;
using static ArrayResize.MattSmith;

namespace ArrayResize
{
    internal class MattSmith
    {
        public int menu;
        public struct IceCream
        {
            public string Name;
            public string Brand;
            public int Year;
        }
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            string temp, play;
            int menu;

            do
            {
                Console.WriteLine("1: Show Ice Cream Database \n2: Edit Information\n3: Add Entries");
                temp = Console.ReadLine();
                menu = Convert.ToInt32(temp);


                ArrayRead(ref menu);
                Console.WriteLine("Would you like to go back to the main menu? Y/N");
                play = Console.ReadLine();
            } while (play.ToUpper() == "Y");
            
        }

        static void ArrayRead(ref int menu)
        {
            int count=0;
            
            StreamReader sr = new StreamReader(@"icecream.txt");
            while (!sr.EndOfStream)
            {
                sr.ReadLine();
                count++;
            }
            sr.Close();
            count = count / 3;
            IceCream[] icecreams = new IceCream[count];
            sr = new StreamReader(@"icecream.txt");
            while (!sr.EndOfStream)
            {
                for (int i = 0; i < icecreams.Length; i++)
                {
                    icecreams[i].Name = sr.ReadLine();
                    icecreams[i].Brand = sr.ReadLine();
                    icecreams[i].Year = Convert.ToInt32(sr.ReadLine());
                }
            }
            sr.Close();
            if (menu == 1)
            {
                Console.Clear();
                ArrayWritter(ref icecreams);
            }
            else if (menu == 2)
            {
                Console.Clear();
                EditArray(ref icecreams);
            }
            else if (menu == 3) 
            { 
                Console.Clear();
                ArrayExpand(ref icecreams);
            }
            
        }
        static void ArrayWritter(ref IceCream[] icecreams)
        {
            for (int i = 0; i < icecreams.Length; i++)
            {
                Console.WriteLine($"{icecreams[i].Name.PadRight(20)} {icecreams[i].Brand.PadRight(20)} {icecreams[i].Year}");
            }
            Console.ReadKey();
        }

        static void EditArray(ref IceCream[] icecreams)
        {
            string looking,change,input;
            bool found = false;
            Console.WriteLine("What Ice-Cream are you looking for?");
            looking = Console.ReadLine();

            for (int i = 0; i < icecreams.Length; i++) 
            {
                if (icecreams[i].Name == looking) 
                { 
                    found = true;
                    Console.WriteLine("What would you like to change? Name,Brand or Year");
                    change = Console.ReadLine();
                    if (change.ToUpper() == "NAME")
                    {
                        Console.WriteLine("What should it be?");
                        input = Console.ReadLine();
                        icecreams[i].Name = input;
                    }
                    else if (change.ToUpper() == "BRAND")
                    {
                        Console.WriteLine("What should it be?");
                        input = Console.ReadLine();
                        icecreams[i].Brand = input;
                    }
                    else if (change.ToUpper() == "YEAR")
                    {
                        Console.WriteLine("What should it be?");
                        input = Console.ReadLine();
                        icecreams[i].Year = Convert.ToInt32(input);
                    }

                }
            }
            Writter(ref icecreams);

        }
        static void Writter(ref IceCream[] icecreams)
        {
            StreamWriter sw = new StreamWriter(@"icecream.txt");
            for (int i = 0; i < icecreams.Length; i++) 
            { 
                sw.WriteLine(icecreams[i].Name);
                sw.WriteLine(icecreams[i].Brand);
                sw.WriteLine(icecreams[i].Year);
            }
            sw.Close();
        }
        static void ArrayExpand(ref IceCream[] iceCreams)
        {
            int expand,year;
            string temp,input;
            Console.WriteLine("How many more entries would you like to add?");
            temp = Console.ReadLine();
            Console.Clear();
            expand = Convert.ToInt32(temp);
            Array.Resize(ref iceCreams, iceCreams.Length + expand);
            for (int i = iceCreams.Length - expand; i < iceCreams.Length; i++) 
            {
                Console.WriteLine("What is the name of the Ice Cream?");
                input = Console.ReadLine();
                Console.Clear();
                iceCreams[i].Name = input;
                Console.WriteLine("Who makes the ice cream?");
                input = Console.ReadLine();
                Console.Clear() ;
                iceCreams[i].Brand = input;
                Console.WriteLine("What was the first year of manufacture for this ice cream?");
                input = Console.ReadLine() ;
                Console.Clear() ;
                iceCreams[i].Year = Convert.ToInt32(input);
            }

            Writter(ref iceCreams);
        }
    }
}
