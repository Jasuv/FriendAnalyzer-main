using System.Collections.Generic;
using System.IO;
using System.Threading;
using System;

namespace Analyzer
{
    class FriendAnalyzer
    {
        const string dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FriendAnalyzer");
        public List<Person> peopleList = new List<Person>();
        static void Main(string[] args)
        {
            Console.WriteLine("AAAAAAAAAAAAAAAAAAAABBBAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            FriendAnalyzer newAnalyzer = new FriendAnalyzer();
            newAnalyzer.TheAnalyzer();
        }
        
        void TheAnalyzer()
        {
            Console.WriteLine("Initializing FriendAnalyzer");
            Thread.Sleep(2000);
            Console.Write("Analyzing FriendList");
            for (int i = 0; i < 4; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            
            if (File.Exists("people.txt"))
            {
                //write proper friend request stuff here
                Console.WriteLine("Send friend request(s)? (y/n)");
                string answer = Console.In.ReadLine().ToLower();
                while (!(answer.Equals("y") || answer.Equals("n")))
                {
                    Console.WriteLine("I said (y/n), loner");
                    answer = Console.In.ReadLine().ToLower();
                }
                if (answer.Equals("y")) { Console.WriteLine("Friend request(s) sent"); }
                if (answer.Equals("n")) { Console.WriteLine("Friend request(s) not sent"); }
            }
            else
            {
                Console.WriteLine("It appears your people list is empty...");
                Console.WriteLine("Please input at least 3 people into the list\n");
                Thread.Sleep(500);
                for(int i = 0; i < 2; i++)
                {
                    AddPeople();
                }
                FileStream file = new FileStream(Path.Combine(dataPath, "FriendAnalyzer", "people.txt"), FileMode.Create);
                using (StreamWriter writer = new StreamWriter(file))
                {
                    //put the people in here
                }
                TheAnalyzer();
            }
            
        }

        void AddPeople()
        {
            Console.WriteLine("Name? ");
            string inName = Console.In.ReadLine().ToLower();
            Console.WriteLine("Input at least 1 tag for " + inName + ". Type stop to finish...");
            List<string> inTags = new List<string>();
            bool exit = false;
            while(!exit)
            {
                string inTag = Console.In.ReadLine().ToLower();
                if (inTag != "stop") {inTags.Add(inTag);}
                else {exit = true;}
            }
            Console.Write("Adding " + inName + " to people list...");
            Person newPerson = new Person(inName, inTags);
            peopleList.Add(newPerson);
        }
    }

    public class Person
    {
        string name;
        List<string> tags;

        public Person(string inName, List<string> inTags)
        {
            name = inName;
            tags = inTags;
        }   
    }
}