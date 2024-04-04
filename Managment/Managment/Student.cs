using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managment
{
    internal class Student
    {
        private static int _id;
        public int Id { get; set; }

        public string Fullname { get; set; }

        private double _point;
        public double Point
        {
            get { return _point; }

            set
            {
                bool check = false;
                do
                {
                    if (value >= 0 && value <= 100)
                    {
                        _point = value;
                        check = true;
                    }
                    else
                    {
                        Console.WriteLine("Point duzgun daxil edilmeyib");

                        string point;
                        do
                        {
                            Console.Write("Point: ");
                            point = Console.ReadLine();
                        } while ((!double.TryParse(point, out value)));
                    }

                } while (!check);
            }
        }

        public Student(string fullname, double point)
        {
            _id++;
            Id = _id;
            Fullname = fullname;
            Point = point;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Id: {Id}, Fullname: {Fullname}, Point: {Point}");
        }

    }
}
