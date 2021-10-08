using System;
using System.Collections.Generic;

enum Menu
{
    Student = 1,
    Teacher
}
enum Vacine
{
    Astrazeneca = 1,
    Sinovac,
    Pfizer
}
enum Time
{
    a = 1,
    b,
    c,
    d
}
namespace HW2Register2
{
    class Program
    {
        static RegistrationInformation List;
        static void Main(string[] args)
        {
            PreparePerson();
            PrintMenuScreen();
            PrintVacineScreen();
            
        }
        static void PreparePerson()
        {
            Program.List = new RegistrationInformation();
        }
        static void ShowGetListPersonScreen()
        {
            Console.Clear();
            Program.List.FetchPersonList();
        }
        static void PrintMenuScreen()
        {
            Console.Clear();

            HeaderWelcome welcome = new HeaderWelcome();
            welcome.PrintHeaderWelcome();
            ListMenu listMenu = new ListMenu();
            listMenu.PrintListMenu();

            Console.Write("Please Select Menu: ");
            Menu menu = (Menu)(int.Parse(Console.ReadLine()));

            PresentMenu(menu);
        }
        static void PresentMenu(Menu menu)
        {
            if (menu == Menu.Student)
            {
                ShowInputRegisterStudentScreen();
            }
            else if (menu == Menu.Teacher)
            {
                ShowInputRegisterTeacherScreen();
            }
            else
            {
                ShowMessageInputMenuInCorrect();
            }
        }
        static void ShowInputRegisterStudentScreen()
        {
            Console.Clear();
            HeaderRegisterStudent headerRegisterStudent = new HeaderRegisterStudent();
            headerRegisterStudent.PrintHeaderRegisterStudent();
            
            InputForStudentFromKeyboard();
        }
        static void ShowInputRegisterTeacherScreen()
        {
            Console.Clear();
            HeaderRegisterTeacher headerRegisterTeacher = new HeaderRegisterTeacher();
            headerRegisterTeacher.PrintHeaderRegisterTeacher();
            
            InputForTeacherFromKeyboard();
        }
        static void InputForStudentFromKeyboard()
        {
            Console.Clear();
            HeaderRegisterStudent headerRegisterStudent = new HeaderRegisterStudent();
            headerRegisterStudent.PrintHeaderRegisterStudent();

            Student student = CreateNewStudent();
            Program.List.AddNewPerson(student);
        }
        static void InputForTeacherFromKeyboard()
        {
            Console.Clear();
            HeaderRegisterTeacher headerRegisterTeacher = new HeaderRegisterTeacher();
            headerRegisterTeacher.PrintHeaderRegisterTeacher();

            Teacher teacher = CreateNewTeacher();
            Program.List.AddNewPerson(teacher);
        }
       
        static void ShowMessageInputMenuInCorrect()
        {
            InputMenuInCorrect inputMenuInCorrect = new InputMenuInCorrect();
            inputMenuInCorrect.ShowMessageInputMenuInCorrect();
            PrintMenuScreen();
        }
        static void ShowMessageInputVacineInCorrect()
        {
            InputVacineInCorrect inputVacineInCorrect = new InputVacineInCorrect();
            inputVacineInCorrect.ShowMessageInputVacineInCorrect();
            PrintVacineScreen();
        }
        static void ShowMessageInputTimeInCorrect()
        {
            InputTimeInCorrect inputTimeInCorrect = new InputTimeInCorrect();
            inputTimeInCorrect.ShowMessageInputTimeInCorrect();
            PrintTimeScreen();
        }
        static Student CreateNewStudent()
        {
            return new Student(InputName(), InputSurname(), InputAge(), InputIDCardNumber(), 
                 InputPhoneNumber(), InputEmail(), InputStudentID());
        }
        static Teacher CreateNewTeacher()
        {
            return new Teacher(InputName(), InputSurname(), InputAge(), InputIDCardNumber(),
                InputPhoneNumber(), InputEmail(), InputPosition());
        }
        static string InputName()
        {
            Console.Write("Name: ");
            return Console.ReadLine();
        }
        static string InputSurname()
        {
            Console.Write("Surname: ");
            return Console.ReadLine();
        }
        static string InputAge()
        {
            Console.Write("Age: ");
            return Console.ReadLine();
        }
        static string InputIDCardNumber()
        {
            Console.Write("ID Card Number: ");
            return Console.ReadLine();
        }
        static string InputStudentID()
        {
            Console.Write("Student ID: ");
            return Console.ReadLine();
        }
        static string InputPhoneNumber()
        {
            Console.Write("Phone Number: ");
            return Console.ReadLine();
        }
        static string InputEmail()
        {
            Console.Write("Email: ");
            return Console.ReadLine();
        }
        static string InputPosition()
        {
            Console.Write("Position: ");
            return Console.ReadLine();
        }
        static void PrintVacineScreen()
        {
            Console.Clear();

            HeaderVacine headerVacine = new HeaderVacine();
            headerVacine.PrintHeaderVacine();
            ListVacine listVacine = new ListVacine();
            listVacine.PrintListVacine();

            Console.Write("Choose the vaccine you need: ");
            Vacine vacine = (Vacine)(int.Parse(Console.ReadLine()));

            PresentVacine(vacine);
        }
        static void PresentVacine(Vacine vacine)
        {
            if (vacine == Vacine.Astrazeneca || vacine == Vacine.Sinovac || vacine == Vacine.Pfizer)
            {
                PrintTimeScreen();
            }
            else
            {
                ShowMessageInputVacineInCorrect();
            }
        }
        
        static void PrintTimeScreen()
        {
            Console.Clear();

            HeaderTime headerTime = new HeaderTime();
            headerTime.PrintHeaderTime();
            ListTime listTime = new ListTime();
            listTime.PrintListTime();

            Console.Write("please select the timeframe you would like: ");
            Time time = (Time)(int.Parse(Console.ReadLine()));

            PresentTime(time);
        }
        static void PresentTime(Time time)
        {
            if(time == Time.a || time == Time.b || time == Time.c || time == Time.d)
            {
                ShowGetListPersonScreen();
            }
            else
            {
                ShowMessageInputTimeInCorrect();
            }

        }

    }
    class HeaderWelcome
    {
        public void PrintHeaderWelcome()
        {
            string PrintHeaderWelcome = "Welcome to the vaccination booking system for students and teachers.\nKing Mongkut's University of Technology Thonburi" +
                "\n>> November 6, 2021\n>> 1st needle vaccine\n*********************************";
            Console.WriteLine(PrintHeaderWelcome);
        }
    }
    
    class ListMenu
    {
        public void PrintListMenu()
        {
            string PrintListMenu = "1. Student. \n2. Teacher.";
            Console.WriteLine(PrintListMenu);
        }
    }
    class ListVacine
    {
        public void PrintListVacine()
        {
            string PrintListVacine = "1. Astrazeneca\n2. Sinovac.\n3. Pfizer.";
            Console.WriteLine(PrintListVacine);
        }
    }
    class ListTime
    {
        public void PrintListTime()
        {
            string PrintListTime = "1. 9:30-10:30 \n2. 10:30-11:30 \n3. 13:30-14:30 \n4. 14:30-15:30";
            Console.WriteLine(PrintListTime);
        }
    }
    class HeaderRegisterStudent
    {
        public void PrintHeaderRegisterStudent()
        {
            string PrintHeaderRegisterStudent = "**********************\n  Register student. \n**********************";
            Console.WriteLine(PrintHeaderRegisterStudent);
        }
    }
    class HeaderRegisterTeacher
    {
        public void PrintHeaderRegisterTeacher()
        {
            string PrintHeaderRegisterTeacher = "**********************\n  Register teacher. \n**********************";
            Console.WriteLine(PrintHeaderRegisterTeacher);
        }
    }
    class HeaderVacine
    {
        public void PrintHeaderVacine()
        {
            string PrintHeaderVacine = "**********************\n  COVID-19 Vaccines  \n**********************";
            Console.WriteLine(PrintHeaderVacine);
        }
    }
    class HeaderTime
    {
        public void PrintHeaderTime()
        {
            string PrintHeaderTime = "**********************\n  Times  \n**********************";
            Console.WriteLine(PrintHeaderTime);
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
    class InputVacineInCorrect
    {
        public void ShowMessageInputVacineInCorrect()
        {
            Console.Clear();
            string PleaseTryAgian = "Vacine Incorrect Please try agian.";
            Console.WriteLine(PleaseTryAgian);
        }
    }
    class InputTimeInCorrect
    {
        public void ShowMessageInputTimeInCorrect()
        {
            Console.Clear();
            string PleaseTryAgian = "Time Incorrect Please try agian.";
            Console.WriteLine(PleaseTryAgian);
        }
    }
    
    class RegistrationInformation
    {
        private List<Person> personList;
        public RegistrationInformation()
        {
            this.personList = new List<Person>();
        }
        public void AddNewPerson(Person person)
        {
            this.personList.Add(person);
        }

        public void FetchPersonList()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("  registered successfully");
            Console.WriteLine("-----------------------------");

            foreach (Person person in this.personList)
            {
                if (person is Student)
                {
                    Console.WriteLine("Name: {0} \nSurname: {1} \nType: Student \nID Card Number: {2}  \n>> November 6, 2021\n>> 1st needle vaccine \n **** Please arrive 30 minutes before the appointment time.", person.GetName(), person.GetSurName(), person.GetIDCardNumber());
                }
                else if (person is Teacher)
                {
                    Console.WriteLine("Name: {0} \nSurname: {1} \nType: Teacher \nID Card Number: {2}  \n>> November 6, 2021\n>> 1st needle vaccine \n **** Please arrive 30 minutes before the appointment time.", person.GetName(), person.GetSurName(), person.GetIDCardNumber());
                }
            }
        }
    }
    class Person
    {
        protected string name;
        protected string surname;
        protected string age;
        protected string idCardNumber;
        protected string phonenumber;
        protected string email;
        public Person(string name, string surname, string age, string idCardNumber,
            string phonenumber, string email)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.idCardNumber = idCardNumber;
            this.phonenumber = phonenumber;
            this.email = email;
        }
        public string GetName()
        {
            return this.name;
        }
        public string GetSurName()
        {
            return this.surname;
        }
        public string GetIDCardNumber()
        {
            return this.idCardNumber;
        }
    }
    class Student : Person
    {
        
        protected string studentID;
        

        public Student(string name, string surname, string age, string idCardNumber,
            string studentID, string phonenumber, string email) :base(name,surname,age,idCardNumber,phonenumber,email)
        {
            
            this.studentID = studentID;
            
        }
        public string GetStudentID()
        {
            return this.studentID;
        }
    }
    class Teacher : Person
    {
        
        protected string position;
        

        public Teacher(string name, string surname, string age, string idCardNumber,
            string position, string phonenumber, string email) :base(name,surname,age,idCardNumber,phonenumber,email)
        {
            
            this.position = position;
            
        }
        public string GetPosition()
        {
            return this.position;
        }
    }
}
