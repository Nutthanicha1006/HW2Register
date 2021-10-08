using System;
using System.Collections.Generic;

enum Menu
{
    RegisterNewStudent = 1,
    RegisterNewTeacher,
    GetListPersons
}
namespace HW2register1
{
    class Program
    {
        static PersonList personList;

        static void Main(string[] args)
        {
            PreparePersonListWhenProgramIsLoad();
            PrintMenuScreen();
        }

        static void PreparePersonListWhenProgramIsLoad()
        {
            Program.personList = new PersonList();
        }

        static void PrintMenuScreen()
        {
            Console.Clear();

            HeaderWelcome welcome = new HeaderWelcome();
            welcome.PrintHeader();
            ListMenu listMenu = new ListMenu();
            listMenu.PrintListMenu();

            InputMenuFromKeyboard();
        }
        static void InputMenuFromKeyboard()
        {

            Console.Write("Please Select Menu: ");
            Menu menu = (Menu)(int.Parse(Console.ReadLine()));

            PresentMenu(menu);
        }
        static void PresentMenu(Menu menu)
        {
            if (menu == Menu.RegisterNewStudent)
            {
                ShowInputRegisterNewStudentScreen();
            }
            else if (menu == Menu.RegisterNewTeacher)
            {
                ShowInputRegisterNewTeacherScreen();
            }
            else if (menu == Menu.GetListPersons)
            {
                ShowGetListPersonScreen();
            }
            else
            {
                ShowMessageInputMenuInCorrect();
            }
        }
        static void ShowGetListPersonScreen()
        {
            Console.Clear();
            Program.personList.FetchPersonList();
            InputExitFromKeyboard();
        }
        static void InputExitFromKeyboard()
        {
            InputExit Input = new InputExit();
            Input.InputExitFromUser();
            PrintMenuScreen();
        }
        static void ShowInputRegisterNewTeacherScreen()
        {
            Console.Clear();

            int totalTeacher = TotalTeacher();

            InputNewTeacherFromKeyboard(totalTeacher);
        }
        static int TotalTeacher()
        {
            Console.Write("Input Total new Teacher: ");

            return int.Parse(Console.ReadLine());
        }
        static void InputNewTeacherFromKeyboard(int totalTeacher)
        {
            for (int i = 0; i < totalTeacher; i++)
            {
                Console.Clear();
                HeaderRegisterTeacher headerRegisterTeacher = new HeaderRegisterTeacher();
                headerRegisterTeacher.PrintHeaderRegisterTeacher();
                Teacher teacher = CreateNewTeacher();

                Program.personList.AddNewPerson(teacher);
            }

            Console.Clear();
            PrintMenuScreen();
        }
        static Teacher CreateNewTeacher()
        {
            return new Teacher(InputName(), InputAddress(), InputCitizenID(), InputEmployeeID());
        }
        static void ShowInputRegisterNewStudentScreen()
        {
            Console.Clear();
            HeaderRegisterStudent headerRegisterStudent = new HeaderRegisterStudent();
            headerRegisterStudent.PrintHeaderRegisterStudent();

            int totalStudent = TotalNewStudent();

            InputNewStudentFromKeyboard(totalStudent);
        }

        static void InputNewStudentFromKeyboard(int totalStudent)
        {
            for (int i = 0; i < totalStudent; i++)
            {
                Console.Clear();
                HeaderRegisterStudent headerRegisterStudent = new HeaderRegisterStudent();
                headerRegisterStudent.PrintHeaderRegisterStudent();

                Student student = CreateNewStudent();

                Program.personList.AddNewPerson(student);
            }

            Console.Clear();
            PrintMenuScreen();
        }
        static Student CreateNewStudent()
        {
            return new Student(InputName(), InputAddress(), InputCitizenID(), InputStudentID());
        }
        static string InputEmployeeID()
        {
            Console.Write("Employee ID: ");
            return Console.ReadLine();
        }
        static string InputName()
        {
            Console.Write("Name: ");
            return Console.ReadLine();
        }
        static string InputAddress()
        {
            Console.Write("Address: ");
            return Console.ReadLine();
        }
        static string InputCitizenID()
        {
            Console.Write("Citizen ID: ");
            return Console.ReadLine();
        }
        static string InputStudentID()
        {
            Console.Write("Student ID: ");
            return Console.ReadLine();
        }
        static int TotalNewStudent()
        {
            Console.Write("Input Total new student: ");
            return int.Parse(Console.ReadLine());
        }
        static void ShowMessageInputMenuInCorrect()
        {
            InputMenuInCorrect inputMenuInCorrect = new InputMenuInCorrect();
            inputMenuInCorrect.ShowMessageInputMenuInCorrect();
            InputMenuFromKeyboard();
        }
    }
    class HeaderRegisterStudent
    {
        public void PrintHeaderRegisterStudent()
        {
            string PrintHeaderRegisterStudent = "Register new student. \n---------------------";
            Console.WriteLine(PrintHeaderRegisterStudent);
        }
    }
    class HeaderRegisterTeacher
    {
        public void PrintHeaderRegisterTeacher()
        {
            string PrintHeaderRegisterTeacher = "Register new teacher. \n---------------------";
            Console.WriteLine(PrintHeaderRegisterTeacher);
        }
    }
    class InputMenuInCorrect
    {
        public void ShowMessageInputMenuInCorrect()
        {
            Console.Clear();
            string PleaseTryAgian = "Menu Incorrect Please try agian.";
            Console.WriteLine(PleaseTryAgian);
        }
    }
    class HeaderWelcome
    {
        public void PrintHeader()
        {
            string PrintHeader = "Welcome to registration new user school application \n----------------------------------------------------";
            Console.WriteLine(PrintHeader);
        }
    }
    class ListMenu
    {
        public void PrintListMenu()
        {
            string PrintListMenu = "1. Register new student. \n2. Register new Teacher.\n3. Get List Persons.";
            Console.WriteLine(PrintListMenu);
        }
    }
    class InputExit
    {
        public string text = "";

        public void InputExitFromUser()
        {
            while (text != "exit")
            {
                Console.Write("Input: ");
                text = Console.ReadLine();
            }

            Console.Clear();
        }
    }
    class Person
    {
        protected string name;
        protected string address;
        protected string citizenID;

        public Person(string name, string address, string citizenID)
        {
            this.name = name;
            this.address = address;
            this.citizenID = citizenID;
        }

        public string GetName()
        {
            return this.name;
        }
    }
    class Student : Person
    {
        private string studentID;
        public Student(string name, string address, string citizenID, string studentID) : base(name, address, citizenID)
        {
            this.studentID = studentID;
        }
    }
    class PersonList
    {
        private List<Person> personList;

        public PersonList()
        {
            this.personList = new List<Person>();
        }
        public void AddNewPerson(Person person)
        {
            this.personList.Add(person);
        }
        public void FetchPersonList()
        {
            Console.WriteLine("List Persons");
            Console.WriteLine("------------");
            foreach (Person person in this.personList)
            {
                if (person is Student)
                {
                    Console.WriteLine("Name: {0} \nType: Student\n", person.GetName());
                }
                else if (person is Teacher)
                {
                    Console.WriteLine("Name: {0} \nType: Teacher\n", person.GetName());
                }
            }
        }
    }
    class Teacher : Person
    {
        private string employeeID;

        public Teacher(string name, string address, string citizenID, string employeeID) : base(name, address, citizenID)
        {
            this.employeeID = employeeID;
        }
    }
    
}
