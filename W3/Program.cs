using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace W3
{
    class Program
    {
        private static string FileName = "Data.json";
        private static string FilePath = @"Data.json";
        static void WeatherData()
        {
            while(true)
            {
                try 
                {
                    Console.WriteLine("╔════════════╤══════════════════════════════╗");
                    Console.WriteLine("   Hot key   │            Function       ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("      A      │       Add new student  ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("      S      │ Search student by city  ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("      D      │ Delete student by city ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("      T      │      Show all students base  ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("    Space    │         Clear console  ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("     Esc     │          Exit program  ");
                    Console.WriteLine("╚════════════╧══════════════════════════════╝");

                    var data = JsonConvert.DeserializeObject<List<Weather_Data>>(File.ReadAllText(FilePath));

                    int menuselect = 0;
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.A:
                            menuselect = 1;
                            break;
                        case ConsoleKey.S:
                            menuselect = 2;
                            break;
                        case ConsoleKey.T:
                            menuselect = 3;
                            break;
                        case ConsoleKey.Escape:
                            menuselect = 4;
                            break;
                        case ConsoleKey.D:
                            menuselect = 5;
                            break;
                    }

                    if (menuselect == 1)
                    {
                        Console.Clear();

                        Console.WriteLine("Enter Student Data\n");
                        Console.WriteLine("Name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("City: ");
                        string city = Console.ReadLine();
                        Console.WriteLine("Success: ");
                        string success = Console.ReadLine();
                        Console.WriteLine("Point: ");
                        string point = Console.ReadLine();
                        Console.WriteLine("Position in group: ");
                        string ngroup = Console.ReadLine();

                        if (name != null && city != null && success != null && point != null && ngroup != null)
                        {
                            data.Add(new Weather_Data { Name = name, Сity = city, Success = success, Point = point, NGroup = ngroup });
                        }
                        else
                        {
                            Console.WriteLine("          Error\nSome fileds are empty.\nTry again");
                        }
                        Console.Clear();
                    }

                    if (menuselect == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter search name: ");
                        string nam = Console.ReadLine();
                        if (Console.ReadLine() != null)
                        {
                            Console.Clear();
                            Weather_Data FoundData = data.Find(found => found.Name == nam);
                            if (FoundData != null)
                            {
                                Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                                Console.WriteLine("     Name    │    City    │  Success │    Point    │ Pos in Group");
                                Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                                Console.WriteLine("{0,10} {1, 10} {2, 10} {3, 12} {4, 13}", FoundData.Name, FoundData.Сity, FoundData.Success, FoundData.Point, FoundData.NGroup);
                                Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");


                                Console.WriteLine("\nTo edit press 'E'");
                                Console.WriteLine("\n\nTo edit press 'D'");
                                if (Console.ReadKey().Key == ConsoleKey.E)
                                {
                                    Console.WriteLine("\nEdit Student Data\n");
                                    Console.WriteLine("Name: ");
                                    string name = Console.ReadLine();
                                    Console.WriteLine("City: ");
                                    string city = Console.ReadLine();
                                    Console.WriteLine("Success: ");
                                    string success = Console.ReadLine();
                                    Console.WriteLine("Point: ");
                                    string point = Console.ReadLine();
                                    Console.WriteLine("Position in group: ");
                                    string ngroup = Console.ReadLine();

                                    if (name == null || city == null || success == null || point == null || ngroup == null)
                                    {
                                        Console.WriteLine("          Error\nSome fileds are empty.\nTry again");
                                    }
                                    FoundData.Name = name;
                                    FoundData.Сity = city;
                                    FoundData.Success = success;
                                    FoundData.Point = point;
                                    FoundData.NGroup = ngroup;
                                    Console.Clear();
                                    Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                                    Console.WriteLine("     Name    │    City    │  Success │    Point    │ Pos in Group");
                                    Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                                    Console.WriteLine("{0,10} {1, 10} {2, 10} {3, 12} {4, 13}", FoundData.Name, FoundData.Сity, FoundData.Success, FoundData.Point, FoundData.NGroup);
                                    Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");
                                }
                                if (Console.ReadKey().Key == ConsoleKey.D)
                                {
                                    data.RemoveAll(x => x.Name == nam);
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Error\n\n" +
                            "Student not found");
                            }
                             
                            
                        }
                    }

                    if (menuselect == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                        Console.WriteLine("     Name    │    City    │  Success │    Point    │ Pos in Group");
                        Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                        for (int i = 0; i < data.Count; i++)
                        {
                            Console.WriteLine("{0,10} {1, 10} {2, 10} {3, 12} {4, 13}", data[i].Name, data[i].Сity, data[i].Success, data[i].Point, data[i].NGroup);
                            Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                        }
                        Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");
                        Console.WriteLine("\nTo sort by points press 'P'");
                        Console.WriteLine("\nTo sort by name press 'N'");
                        Console.WriteLine("\nTo sort by position in group press 'G'");
                        if (Console.ReadKey().Key == ConsoleKey.P)
                        {

                            Console.Clear();
                            List<Weather_Data> SortData = data.OrderBy(o => o.Point).ToList();
                            Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                            Console.WriteLine("     Name    │    City    │  Success │    Point    │ Pos in Group");
                            Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                            for (int i = 0; i < data.Count; i++)
                            {
                                Console.WriteLine("{0,10} {1, 10} {2, 10} {3, 12} {4, 13}", SortData[i].Name, SortData[i].Сity, SortData[i].Success, SortData[i].Point, SortData[i].NGroup);
                                Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                            }
                            Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");
                        }
                        if (Console.ReadKey().Key == ConsoleKey.N)
                        {

                            Console.Clear();
                            List<Weather_Data> SortData = data.OrderBy(o => o.Name).ToList();
                            Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                            Console.WriteLine("     Name    │    City    │  Success │    Point    │ Pos in Group");
                            Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                            for (int i = 0; i < data.Count; i++)
                            {
                                Console.WriteLine("{0,10} {1, 10} {2, 10} {3, 12} {4, 13}", SortData[i].Name, SortData[i].Сity, SortData[i].Success, SortData[i].Point, SortData[i].NGroup);
                                Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                            }
                            Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");
                        }
                        if (Console.ReadKey().Key == ConsoleKey.G)
                        {

                            Console.Clear();
                            List<Weather_Data> SortData = data.OrderBy(o => o.NGroup).ToList();
                            Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                            Console.WriteLine("     Name    │    City    │  Success │    Point    │ Pos in Group");
                            Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                            for (int i = 0; i < data.Count; i++)
                            {
                                Console.WriteLine("{0,10} {1, 10} {2, 10} {3, 12} {4, 13}", SortData[i].Name, SortData[i].Сity, SortData[i].Success, SortData[i].Point, SortData[i].NGroup);
                                Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                            }
                            Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");
                        }
                        if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                        {
                            Console.Clear();
                        }
                    }

                    if (menuselect == 4)
                    {
                        Environment.Exit(0);
                    }

                    if (menuselect == 5)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter name to delete: ");
                        string name = Console.ReadLine();
                        if (Console.ReadLine() != null)
                        {
                            Console.Clear();
                            Weather_Data FoundData = data.Find(found => found.Name == name);
                            if (FoundData != null)
                            {
                                Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                                Console.WriteLine("     Name    │    City    │  Success │    Point    │ Pos in Group");
                                Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                                Console.WriteLine("{0,10} {1, 10} {2, 10} {3, 12} {4, 13}", FoundData.Name, FoundData.Сity, FoundData.Success, FoundData.Point, FoundData.NGroup);
                                Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");
                                data.RemoveAll(x => x.Name == name);
                                Console.WriteLine("This information has been deleted");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Error\n\n" +
                            "City not found");
                            }


                        }
                    }

                    if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                    {
                        Console.Clear();
                    }

                    string serialize = JsonConvert.SerializeObject(data, Formatting.Indented);
                    if (serialize.Count() > 1)
                    {
                        if (!File.Exists(FileName))
                        {
                            File.Create(FileName).Close();
                        }
                        File.WriteAllText(FilePath, serialize, Encoding.UTF8);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
                
            } 
        }
        static void Main(string[] args)
        {
            WeatherData();
        }
    }

    public class Weather_Data
    {
        private string name;
        private string city;
        private string point;
        private string success;
        private string nGroup;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Сity
        {
            get { return city; }
            set { city = value; }
        }
        public string Success
        {
            get { return success; }
            set { success = value; }
        }
        public string Point
        {
            get { return point; }
            set { point = value; }
        }
        public string NGroup
        {
            get { return nGroup; }
            set { nGroup = value; }
        }

    }
}
