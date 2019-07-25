using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        
        public static string[] names = new string[100];
        public static string[] towns = new string[100];
        public static string[] foods = new string[100];
        public static List<Student> Students = new List<Student>();
        static void Main(string[] args)
        {
           
               
                //Student data being added to list of Students ( type of Student-class)

                AddStudent("Tommy", "Raleigh", "Chicken curry", 0);
                Student studentInfo = GetStudent(0);
                AddStudent("Callista", "Traverse City", "Crab Rangoon", 1);
                Student studentInfo1 = GetStudent(1);
                AddStudent("Brad", "Kentwood,Mi", "Sushi", 2);
                Student studentInfo2 = GetStudent(2);
                AddStudent("Lisa", "Sokcho,South Korea", "Fruit", 3);
                Student studentInfo3 = GetStudent(3);
                AddStudent("Nathan", "Grand Rapids", "Burgers", 4);
                Student studentInfo4 = GetStudent(4);
                AddStudent("Steven", "Ontario", "Risotto", 5);
                Student studentInfo5 = GetStudent(5);
                AddStudent("Miguel", "Chicago, IL", "BBQ Ribs", 6);
                Student studentInfo6 = GetStudent(6);
                AddStudent("Andre", "St Catherines, Ontario", "Veggie Burgers", 7);
                Student studentInfo7 = GetStudent(7);
                AddStudent("Yeni", "Havana, Cuba", "So Delicious Vegan Salted Caramel Icecream", 8);
                Student studentInfo8 = GetStudent(8);
                
                GetInput();                         
                                        
        }

        public static void AddStudent(string name,string town,string food, int index)
        {
            //This method adds the students data to the list of Students.
            Student s = new Student(name, town, food);
            Students.Add(s);
        }
        public static Student GetStudent(int index)
        { 
            // this methods grabs the info of the student selected.
            Student output = Students[index];
            return output;
        }
        public static void PrintMenu()
        {
            //iterates through the Students list and grabs/prints the students name with a ")".
           for( int i=0; i< Students.Count; i++)
            {
                Student s = Students[i];
                string name =s.Name;
                if(name != null)
                {
                    Console.WriteLine(i + ")" + name);
                }
               
            }
        }
        public static void GetInput()
        {
            Console.WriteLine("Welcome to our C# class.");
            PrintMenu();
            Console.WriteLine("Select 0-8");
            Console.WriteLine("Please select the index of the student you want to learn about");
            int index = -1;
            while (true)
            {
                // validating that the input is a whole number, if not throw the exception message.
                try
                {                                   
                    string input = Console.ReadLine();
                    index = int.Parse(input);
                    if (index >= 0)
                        break;
                    throw new Exception("That was not a valid integer please try again!");
                }
                 catch (Exception e)
                {
                        Console.WriteLine(e.Message);
                }
                
            }
            
            Student s = GetStudent(index);//pulls the student selected(index) info from the GetStudent method.
            Console.WriteLine($"Student at {index} is {s.Name}");

            if (0 <= index && index < Students.Count)
            {     //if index is a whole number and withing the Students list we can proceed to ask and provide more info about the student.   
                while (true)
                { 
                Console.WriteLine($"What more would you like to learn about {s.Name} ?");
                Console.WriteLine("Select one of the following: Town (t for short) or Food (f for short)");
                string userInput = Console.ReadLine().ToLower();
                    
                    if (userInput == "town" || userInput == "t")
                    {
                        Console.WriteLine($"{s.Name} is from {s.HomeTown}");
                        Console.WriteLine($"Would you like to know more about {s.Name}? (y/n)");// allows the user to learn more about their initial choice without starting over.
                        string answer = Console.ReadLine().ToLower();
                        if (answer == "yes" || answer == "y")
                        {
                            continue;
                        }
                        else if (answer == "no" || answer == "n")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("not a valid answer");
                        }
                    }
                    else if (userInput == "food" || userInput == "f")
                    {
                        Console.WriteLine($"{s.Name}'s favorite food is {s.FavoriteFood} ");
                        Console.WriteLine($"Would you like to know more about {s.Name}? (y/n)");
                        string answer = Console.ReadLine().ToLower();
                        if (answer == "yes" || answer == "y")
                        {
                            continue;
                        }
                        else if(answer=="no"|| answer=="n")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("not a valid answer");
                            
                        }
                    }
                    else
                    {
                        Console.WriteLine("Im sorry I did not understand that please try again.");
                        continue;
                    }
                     
                }
                        Continue();
            }


        }
        
        public static void Continue()
        {
            bool play = true;
            while (play)
            {
                Console.WriteLine("Would you like to know more about the class? (y/n)");
                string input = Console.ReadLine().ToLower();

                if (input == "y" || input == "yes")
                {
                    GetInput();
                }
                else if (input == "n" || input == "no")
                {
                    Console.WriteLine("Thanks!");
                    play = false;
                    System.Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("I'm sorry that I didn't understand your input. Goodbye.");
                    System.Environment.Exit(0);
                }
            }
        }
    }

}
