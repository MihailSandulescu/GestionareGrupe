using GestionareGrupe.Models;
using System;
using System.Linq;

namespace GestionareGrupe.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            // Daca exista studenti in baza de date, nu mai facem seed
            if (context.Students.Any())
            {
                return;
            }

            var students = new Student[]
            {
            new Student{FirstMidName="Ion",LastName="Popescu",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Student{FirstMidName="Andreea",LastName="Ionescu",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Alex",LastName="Vasilescu",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstMidName="Georgiana",LastName="Georgescu",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Alexandra",LastName="Alexandrescu",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Marcel",LastName="Andreescu",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new Student{FirstMidName="George",LastName="Escu",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstMidName="Vlad",LastName="Popovici",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
            new Course{CourseID=1050,Title="DAW",Credits=3},
            new Course{CourseID=4022,Title="SGBD",Credits=3},
            new Course{CourseID=4041,Title="PAO",Credits=3},
            new Course{CourseID=1045,Title="Statistica",Credits=4},
            new Course{CourseID=3141,Title="POO",Credits=4},
            new Course{CourseID=2021,Title="Pogramare Logica",Credits=3},
            new Course{CourseID=2042,Title="Programare Declarativa",Credits=4}
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
            new Enrollment{StudentID=1,CourseID=1050,Grade=10},
            new Enrollment{StudentID=1,CourseID=4022,Grade=9},
            new Enrollment{StudentID=1,CourseID=4041,Grade=10},
            new Enrollment{StudentID=2,CourseID=1045,Grade=8},
            new Enrollment{StudentID=2,CourseID=3141,Grade=9},
            new Enrollment{StudentID=2,CourseID=2021,Grade=9},
            new Enrollment{StudentID=3,CourseID=1050},
            new Enrollment{StudentID=4,CourseID=1050},
            new Enrollment{StudentID=4,CourseID=4022,Grade=10},
            new Enrollment{StudentID=5,CourseID=4041,Grade=10},
            new Enrollment{StudentID=6,CourseID=1045},
            new Enrollment{StudentID=7,CourseID=3141,Grade=9},
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }
    }
}