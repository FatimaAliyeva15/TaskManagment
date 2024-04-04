using System.Text.RegularExpressions;

namespace Managment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
      
            Console.Write("Password: ");
            string password = Console.ReadLine();
            
            var user = new
            {
                Username = username,
                Password = password,
            };

            bool check = true;

            do
            {
                Console.WriteLine("");
                Console.WriteLine("Menu");
                Console.WriteLine("1. Show info");
                Console.WriteLine("2. Create new group");
                Console.WriteLine("0. Proqramı bitir");
                Console.WriteLine("");


                string choiceStr;
                byte choice;

                do
                {
                    Console.WriteLine("");
                    Console.Write("Sechim edin: ");
                    choiceStr = Console.ReadLine();
                } while (!byte.TryParse(choiceStr, out choice));

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("");
                        Console.WriteLine("Show Info");
                        Console.WriteLine($"Username: {user.Username}, Password: {user.Password}");
                        break;

                    case 2:
                        Console.WriteLine("");
                        Console.WriteLine("Create new group");
                        Console.WriteLine("");

                        Console.Write("GroupNo: ");
                        string groupno;
                        do
                        {
                            groupno = Console.ReadLine();
                            if (!Regex.IsMatch(groupno, @"^[A-Z]{2}\d{3}$"))
                            {
                                Console.Write("Qrup nomresini duzgun daxil et: ");
                            }
                        } while (!Regex.IsMatch(groupno, @"^[A-Z]{2}\d{3}$"));


                        Console.Write("");
                        string studentlimitStr = "";
                        int studentlimit;
                        do
                        {
                            Console.Write("StudentLimit: ");
                            studentlimitStr = Console.ReadLine();
                        } while (!int.TryParse(studentlimitStr, out studentlimit));

                        Group group = new Group(groupno, studentlimit);



                        bool checkmenu2 = true;

                        do
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Menu");
                            Console.WriteLine("1. Show all students");
                            Console.WriteLine("2. Get student by id");
                            Console.WriteLine("3. Add student");
                            Console.WriteLine("0. Quit");
                            Console.WriteLine("");

                            string choiceStr2;
                            byte choice2;

                            do
                            {
                                Console.WriteLine("");
                                Console.Write("Sechim edin: ");
                                choiceStr2 = Console.ReadLine();
                            } while (!byte.TryParse(choiceStr2, out choice2));

                            switch (choice2)
                            {
                                case 1:
                                    Console.WriteLine("");
                                    Console.WriteLine("Show all students");
                                    Console.WriteLine("");
                                    for (int i = 0; i < group.GetAllStudent().Length; i++)
                                    {
                                         group.GetAllStudent()[i].ShowInfo();
                                    }
                                    break;

                                case 2:
                                    Console.WriteLine("");
                                    Console.WriteLine("Get student by id");
                                    Console.WriteLine("");
                                    string idStr = "";
                                    int id;

                                    do
                                    {
                                        Console.Write("Id daxil et: ");
                                        idStr = Console.ReadLine();
                                    } while (!int.TryParse(idStr, out id));

                                    bool searchId = false;

                                    for (int i = 0; i < group.GetAllStudent().Length; i++)
                                    {
                                        Student studentId = group.GetAllStudent()[i];

                                        if (id == studentId.Id)
                                        {
                                            Console.WriteLine("");
                                            Console.WriteLine($" {studentId.Id}, {studentId.Fullname}, {studentId.Point}");
                                            searchId = true;
                                        }
                                    }
                                    if (!searchId)
                                    {
                                        Console.WriteLine("Bele bir student yoxdur");
                                    }
                                    break;

                                case 3:

                                    Console.WriteLine("");
                                    Console.WriteLine("Add student");
                                    Console.WriteLine("");

                                    if(group.GetAllStudent().Length < group.StudentLimit)
                                    {

                                        Console.Write("Fullname: ");
                                        string fullname = Console.ReadLine();

                                        
                                        string pointStr = "";
                                        double point;

                                        do
                                        {
                                            Console.Write("Point: ");
                                            pointStr = Console.ReadLine();
                                        } while (!double.TryParse(pointStr, out point));

                                        Student student = new Student(fullname, point);
                                        group.AddStudent(student);
                                    }

                                    else
                                    {
                                        Console.WriteLine("Telebe limiti asilmisdir. Artiq telebe elave etmek olmaz. Basqa sechim edin");
                                    }

                                    break;


                                case 0:
                                    Console.WriteLine("");
                                    Console.WriteLine("Quit");
                                    checkmenu2 = false;
                                    break;


                                default:
                                    Console.WriteLine("Duzgun sechin et:");
                                    break;

                            }
                        } while (checkmenu2);

                        break;

                    case 0:
                        check = false;
                        Console.WriteLine("");
                        Console.WriteLine("Proqram bitdi");
                        break;

                    default:
                        Console.WriteLine("Duzgun sechim et:");
                        break;
                }


            } while (check);

        }
    }
}
