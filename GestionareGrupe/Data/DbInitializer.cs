using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GestionareGrupe.Models;

namespace GestionareGrupe.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            //context.Database.EnsureCreated();

            // daca exista deja studenti
            if (context.Students.Any())
            {
                return;   // DB a fost deja populata
            }

            var students = new Student[]
            {
                new Student { FirstMidName = "Ionel",   LastName = "Popescu",
                    EnrollmentDate = DateTime.Parse("2010-09-01") },
                new Student { FirstMidName = "Marcel", LastName = "Ionescu",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Gigel",   LastName = "Georgescu",
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstMidName = "Costel",    LastName = "Vasilescu",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Dorian",      LastName = "Popa",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Adrian",    LastName = "Vasian",
                    EnrollmentDate = DateTime.Parse("2011-09-01") },
                new Student { FirstMidName = "Vasile",    LastName = "George",
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstMidName = "Gica",     LastName = "Contra",
                    EnrollmentDate = DateTime.Parse("2005-09-01") }
            };

            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var instructors = new Instructor[]
            {
                new Instructor { FirstMidName = "Ionescu",     LastName = "Popescu",
                    HireDate = DateTime.Parse("1995-03-11") },
                new Instructor { FirstMidName = "Georgescu",    LastName = "Vasilescu",
                    HireDate = DateTime.Parse("2002-07-06") },
                new Instructor { FirstMidName = "Burebista",   LastName = "Decebal",
                    HireDate = DateTime.Parse("1998-07-01") },
                new Instructor { FirstMidName = "Adrian", LastName = "Adi",
                    HireDate = DateTime.Parse("2001-01-15") },
                new Instructor { FirstMidName = "Roger",   LastName = "Roger",
                    HireDate = DateTime.Parse("2004-02-12") }
            };

            foreach (Instructor i in instructors)
            {
                context.Instructors.Add(i);
            }
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department { Name = "DAW",     Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Popescu").ID },
                new Department { Name = "Programare", Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Vasilescu").ID },
                new Department { Name = "Ingineria sistemelor", Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Decebal").ID },
                new Department { Name = "Econometrie",   Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Roger").ID }
            };

            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course {CourseID = 1050, Title = "Ingineria sistemelor complexe",      Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Ingineria sistemelor").DepartmentID
                },
                new Course {CourseID = 4022, Title = "Microeconomie", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Econometrie").DepartmentID
                },
                new Course {CourseID = 4041, Title = "Macroeconomie", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Econometrie").DepartmentID
                },
                new Course {CourseID = 1045, Title = "Programare dinamica",       Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Programare").DepartmentID
                },
                new Course {CourseID = 3141, Title = "Programare logica",   Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Programare").DepartmentID
                },
                new Course {CourseID = 2021, Title = "JavaScript Server-Side",    Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "DAW").DepartmentID
                },
                new Course {CourseID = 2042, Title = "Aplicatii web cu .NET Core",     Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "DAW").DepartmentID
                },
            };

            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var officeAssignments = new OfficeAssignment[]
            {
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Decebal").ID,
                    Location = "Aleea Strada" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Roger").ID,
                    Location = "Bulevardul Calea" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Vasilescu").ID,
                    Location = "Intersectia Giratoriul" },
            };

            foreach (OfficeAssignment o in officeAssignments)
            {
                context.OfficeAssignments.Add(o);
            }
            context.SaveChanges();

            var courseInstructors = new CourseAssignment[]
            {
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Ingineria sistemelor complexe" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Decebal").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Microeconomie" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Roger").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Macroeconomie" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Roger").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Programare dinamica" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Vasilescu").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Programare logica" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Vasilescu").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "JavaScript Server-Side" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Popescu").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Aplicatii web cu .NET Core" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Popescu").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Microeconomie" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Roger").ID
                    },
            };

            foreach (CourseAssignment ci in courseInstructors)
            {
                context.CourseAssignments.Add(ci);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Popescu").ID,
                    CourseID = courses.Single(c => c.Title == "Microeconomie" ).CourseID,
                    Grade = 10
                },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Ionescu").ID,
                    CourseID = courses.Single(c => c.Title == "Macroeconomie" ).CourseID,
                    Grade = 9
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Vasilescu").ID,
                    CourseID = courses.Single(c => c.Title == "Macroeconomie" ).CourseID,
                    Grade = 9
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Georgescu").ID,
                    CourseID = courses.Single(c => c.Title == "Programare dinamica" ).CourseID,
                    Grade = 10
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Contra").ID,
                    CourseID = courses.Single(c => c.Title == "Programare logica" ).CourseID,
                    Grade = 9
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Popescu").ID,
                    CourseID = courses.Single(c => c.Title == "Programare logica" ).CourseID,
                    Grade = 8
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Vasilescu").ID,
                    CourseID = courses.Single(c => c.Title == "JavaScript Server-Side" ).CourseID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Popescu").ID,
                    CourseID = courses.Single(c => c.Title == "JavaScript Server-Side").CourseID,
                    Grade = 10
                    },
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Popa").ID,
                    CourseID = courses.Single(c => c.Title == "Ingineria Sistemelor Complexe").CourseID,
                    Grade = 10
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Vasian").ID,
                    CourseID = courses.Single(c => c.Title == "Aplicatii web cu .NET Core").CourseID,
                    Grade = 9
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "George").ID,
                    CourseID = courses.Single(c => c.Title == "Aplicatii web cu .NET Core").CourseID,
                    Grade = 10
                    }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                            s.Student.ID == e.StudentID &&
                            s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}