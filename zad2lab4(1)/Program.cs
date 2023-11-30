using System;
using System.Collections.Generic;


namespace zad2lab4
{
    abstract class Person
    {
        public string FirstName;
        public string LastName;
        public string PESEL;

        public void SetFirstName(string firstName)
        {

            FirstName = firstName;

        }
        public void SetLastName(string lastName)
        {

            LastName = lastName;

        }

        public void SetPesel(string pesel)
        {

            PESEL = pesel;

        }

        public abstract int GetAge();

        public abstract string GetGender();

        public abstract string GetEducationInfo();

        public abstract string GetFullName();

        public abstract bool CanGoAloneToHome();

    }

    class Student : Person
    {
        public string School;

        private bool canGoAloneToHome;

        public void SetSchool(string school)
        {

            School = school;
        }
        public void SetCanGoHomeAlone(bool canGoHomeAlone)
        {

            canGoAloneToHome = canGoHomeAlone;
        }
        public void ChangeSchool(string newSchool)
        {

            School = newSchool;
        }

        public override int GetAge()
        {

            return 18;
        }

        public override string GetGender()
        {

            return PESEL[9] % 2 == 0 ? "Kobieta" : "Mężczyzna";
        }
        public override string GetEducationInfo()
        {


            return $"Student w {School}";
        }
        public override string GetFullName()
        {

            return $"{FirstName} {LastName}";
        }
        public override bool CanGoAloneToHome()
        {

            return canGoAloneToHome || GetAge() >= 12;
        }

        public string Info()
        {
            if (GetAge() < 12 && !canGoAloneToHome)
            {

                return "Osoby poniżej 12 roku życia nie mogą wrócić same, chyba że mają pozwolenie";
            }
            else
            {

                return "Uczeń może wrócić do domu sam";
            }
        }
    }

    class Teacher : Student
    {
        private string AcademicTitle;

        private List<Student> SubordinateStudents;

        public Teacher(string academicTitle)
        {
            AcademicTitle = academicTitle;

            SubordinateStudents = new List<Student>();
        }
        public void AddSubordinateStudent(Student student)
        {

            SubordinateStudents.Add(student);
        }
        public void WhichStudentCanGoHomeAlone()
        {
            Console.WriteLine("Uczniowie, którzy mogą wrócić do domu sami:");

            foreach (var student in SubordinateStudents)
            {

                if (student.CanGoAloneToHome())
                {
                    Console.WriteLine($"{student.GetFullName()} - {student.GetGender()} - {student.Info()}");
                }

            }
        }
        public void PrintTeacherAndStudentsInfo(string dayOfWeek)
        {
            Console.WriteLine($"{School} Na: {dayOfWeek}");
            Console.WriteLine($"Nauczyciel: {AcademicTitle} {FirstName} {LastName}");
            Console.WriteLine("Lista uczniów:");

            int lp = 1;

            foreach (var student in SubordinateStudents)
            {
                Console.WriteLine($"{lp}. {student.GetFullName()} - {student.GetGender()} - {student.Info()}");
                lp++;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Teacher teacher = new Teacher("dr.");
            teacher.SetFirstName("Iwona");
            teacher.SetLastName("Bibik");
            teacher.SetSchool("Szkoła");


            Student student1 = new Student();
            student1.SetFirstName("Olha");
            student1.SetLastName("Movchan");
            student1.SetSchool("Szkoła");
            student1.SetCanGoHomeAlone(false);

            Student student2 = new Student();
            student2.SetFirstName("Polina");
            student2.SetLastName("Cybulska");
            student2.SetSchool("Szkoła");
            student2.SetCanGoHomeAlone(true);

            teacher.AddSubordinateStudent(student1);

            teacher.AddSubordinateStudent(student2);

            teacher.PrintTeacherAndStudentsInfo("Whensday");

            teacher.WhichStudentCanGoHomeAlone();
        }
    }
}