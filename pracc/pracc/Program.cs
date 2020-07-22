using System;

namespace pracc
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Employee testEmployee = new Employee("Adam-EgyCegnel", DateTime.Now, Gender.Male, 130000, "Junior C# developer");
            testEmployee.PersonRoom = new Room(111);
            Employee Kovacs = (Employee)testEmployee.Clone();
            Kovacs.PersonRoom.RoomNumber = 222;
            Console.WriteLine(testEmployee);
            Console.WriteLine(Kovacs);
        
        }
    }


    class Person
    {
        public Person(string name, DateTime birthDate, Gender gender)
        {
            this.Name = name;
            this.BirthDate = birthDate;
            this.PersonGender = gender;
        }

        protected Gender PersonGender
        {
            get;set;
        }

        protected string Name
        {
            get;set;
        }

        protected DateTime BirthDate
        {
            get;set;
        }

        public override string ToString()
        {
            return "{ Name: " + this.Name + " BirthDate: " + this.BirthDate + " Gender: " + this.PersonGender + " }";
        }

    }

    class Employee : Person, ICloneable
    {
       public Employee(string name, DateTime birthDate, Gender gender, int salary, string profession) : base(name, birthDate, gender)
        {
            this.Salary = salary;
            this.Profession = profession;
        }


        int Salary
        {
            get;set;
        }
        string Profession
        {
            get;set;
        }

        public Room PersonRoom
        {
            get;set;
        }

        public override string ToString()
        {
            return "{ Name: " + base.Name + ", BirthDate: " + this.BirthDate + ", Gender: " + this.PersonGender + ", Profession: " + this.Profession + ", Salary: " + this.Salary + ", RoomNumber: " + PersonRoom.RoomNumber + " }";
        }

        public object Clone()
        {
            Employee newEmployee = (Employee)this.MemberwiseClone();
            newEmployee.PersonRoom = new Room(222);
            return newEmployee;
        }
    }

    class Room
    {
        public Room(int number)
        {
            this.RoomNumber = number;
        }
        public int RoomNumber
        {
            set;get;
        }
    }

    enum Gender 
    {
        Male, Female
    }
}
