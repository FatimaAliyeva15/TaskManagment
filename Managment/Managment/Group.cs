using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Managment
{
    internal class Group
    {
        public string GroupNo { get; set; }
        private int _studentLimit;


        public int StudentLimit
        {

            get { return _studentLimit; }

            set
            {
                bool check = false;
                do
                {
                    if (value >= 0 && value <= 18)
                    {
                        _studentLimit = value;
                        check = true;
                    }
                    else
                    {
                        Console.WriteLine("Limit duzgun daxil et");
                        string limit;
                        do
                        {
                            Console.Write("StudentLimit: ");
                            limit = Console.ReadLine();
                        } while (!int.TryParse(limit, out value));
                    }
                } while (!check);
            }

        }

        public Group(string groupno, int studentlimit)
        {
            GroupNo = groupno;
            StudentLimit = studentlimit;
        }

        Student[] Students = new Student[] { };

        public void CheckGroupNo(string groupNo)
        {
            bool check = false;
            do
            {
                string checkNo = @"^[A-Z]{2}\d{3}$";
                if (Regex.IsMatch(groupNo, checkNo))
                {
                    check = true;
                }
                else
                {
                    Console.WriteLine("Qrup nomresi duzgun daxil et");
                    Console.Write("No: ");
                    groupNo = Console.ReadLine();

                }
            } while (!check);
        }


        public void AddStudent(Student student)
        {
            if (Students.Length < StudentLimit)
            {
                Array.Resize(ref Students, Students.Length + 1);
                Students[Students.Length - 1] = student;
            }
            else
            {
                Console.WriteLine("Telebe limiti aşılmışdır");
            }
        }

        public Student[] GetStudent(int id)
        {
            Student[] studentId = { };
            for (int i = 0; i < Students.Length; i++)
            {
                Student student = Students[i];
                if (student.Id == id)
                {
                    Array.Resize(ref studentId, studentId.Length + 1);
                    studentId[studentId.Length - 1] = Students[i];
                }
                else
                {
                    Console.WriteLine("Bu id`de student yoxdur");
                }
            }
            return studentId;
        }

        public Student[] GetAllStudent()
        {
            return Students;
        }
    }
}
