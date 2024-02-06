using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;
using System.Diagnostics;
using ConsoleAppsCHOOL.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace ConsoleAppsCHOOL;

class Program
{
    static void Main(string[] args)
    {
        using (var db = new ApplicationContext())
        {
            //1) Получить список студентов, зачисленных на определенный курс.
            //var query = db.Enrollments.Where(e => e.CourseId == 1).Select(e => e.Student).ToList();
            //2) Получить список курсов, на которых учит определенный преподаватель.
            //var instructorId = 1;
            //var query = db.Courses.Where(c => c.InstructorId == instructorId).ToList();
            //3) Получить список курсов, на которых учит определенный преподаватель, вместе с именами студентов, зачисленных на каждый курс.
            //int instructorId = 1;
            //var coursesWithStudents = db.Courses.Where(c => c.InstructorId == instructorId).Select(c => new
            //{CourseTitle = c.Title,Students = c.Enrollments.Select(e => e.Student).ToList()}).ToList();
            //4) Получить список курсов, на которые зачислено более 10 студентов.
            //var query = db.Courses.Where(c => c.Enrollments.Count > 10).Select(c => new{CourseTitle = c.Title,StudentCount = c.Enrollments.Count}).ToList();
            //5) Получить список студентов, старше 25 лет.
            //var currentDate = DateTime.Today;
            //var ageLimit = 25;
            //var query = db.Students.Where(s => (currentDate.Year - s.BirthDate.Year) > ageLimit ||((currentDate.Year - s.BirthDate.Year) == ageLimit &&currentDate.DayOfYear >= s.BirthDate.DayOfYear))
            //    .Select(s => new{s.FirstName,s.LastName,Age = currentDate.Year - s.BirthDate.Year - (currentDate.DayOfYear < s.BirthDate.DayOfYear ? 1 : 0)}).ToList();
            //6) Получить средний возраст всех студентов.
            //var currentDate = DateTime.Today;
            //var studentsExist = db.Students.Any(); // Проверяем, есть ли студенты
            //var averageAge = db.Students
            //        .Select(s => currentDate.Year - s.BirthDate.Year - (currentDate.DayOfYear < s.BirthDate.DayOfYear ? 1 : 0))
            //        .Average();
            //7) Получить самого молодого студента.
            //var query = db.Students.OrderByDescending(s => s.BirthDate).FirstOrDefault();
            //9) Получить количество курсов, на которых учится студент с определенным Id.
            //int studentId = 1; 
            //var query = db.Enrollments.Where(e => e.StudentId == studentId).Count();
            //10) Получить список имен всех студентов.
            //var query = db.Students.Select(s => s.FirstName).ToList();
            //11) Сгруппировать студентов по возрасту.
            //var currentDate = DateTime.Today;
            //var query = db.Students.AsEnumerable() .Select(s => new
            //    { Student = s,
            //    Age = currentDate.Year - s.BirthDate.Year - (currentDate < s.BirthDate.AddYears(currentDate.Year - s.BirthDate.Year) ? 1 : 0)
            //    }).GroupBy(s => s.Age).ToList();
            //12) Получить список студентов, отсортированных по фамилии в алфавитном порядке.
            //var query = db.Students.OrderBy(s => s.LastName).ToList();
            //13) Получить список студентов вместе с информацией о зачислениях на курсы.
            //var query = db.Students.Include(s => s.Enrollments).ThenInclude(e => e.Course).ToList();
            //14) Получить список студентов, не зачисленных на определенный курс.
            //int courseIdToExclude = 1; 
            //var query = db.Students.Where(student => !student.Enrollments.Any(enrollment => enrollment.CourseId == courseIdToExclude)).ToList();
            //15) Получить список студентов, зачисленных одновременно на два определенных курса.
            //int courseId1 = 1; 
            //int courseId2 = 2;
            //var query = db.Students.Where(student => student.Enrollments.Count(enrollment => enrollment.CourseId == courseId1 || enrollment.CourseId == courseId2) == 2).ToList();
            //16) Получить количество студентов на каждом курсе.
            //var query = db.Courses.Select(course => new{CourseTitle = course.Title,StudentCount = course.Enrollments.Count()}).ToList();

        }
    }
    public class ApplicationContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=School;Trusted_Connection=True;TrustServerCertificate=True;");
                optionsBuilder.LogTo(e => Debug.WriteLine(e), new[] { RelationalEventId.CommandExecuted });
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Отношение многие-ко-многим между Student и Course через Enrollment
            //modelBuilder.Entity<Enrollment>()
            //    .HasKey(e => e.EnrollmentId); // Определение первичного ключа для Enrollment

            ////modelBuilder.Entity<Enrollment>()
            ////    .HasOne(e => e.Student) // У Enrollment есть один Student
            ////    .WithMany(s => s.Enrollments) // У Student есть много Enrollments
            ////    .HasForeignKey(e => e.StudentId); // Внешний ключ в Enrollment, соединяющий с Student

            ////modelBuilder.Entity<Enrollment>()
            ////    .HasOne(e => e.Course) // У Enrollment есть один Course
            ////    .WithMany(c => c.Enrollments) // У Course есть много Enrollments
            ////    .HasForeignKey(e => e.CourseId); // Внешний ключ в Enrollment, соединяющий с Course

            ////// Если у вас есть связь между Instructor и Course, вы можете настроить ее аналогичным образом
            ////// Например, если каждый курс имеет одного преподавателя
            ////modelBuilder.Entity<Course>()
            ////    .HasOne(c => c.Instructor) // У Course есть один Instructor
            ////    .WithMany(i => i.Courses) // У Instructor есть много Courses
            ////    .HasForeignKey(c => c.InstructorId); // Внешний ключ в Course, соединяющий с Instructor
            ////                                         // Предполагается добавление свойства InstructorId в класс Course и коллекции Courses в класс Instructor


            //modelBuilder.Entity<Student>()
            //    .Property(s => s.FirstName)
            //    .IsRequired()
            //    .HasMaxLength(50);

            //modelBuilder.Entity<Student>()
            //    .Property(s => s.LastName)
            //    .IsRequired()
            //    .HasMaxLength(50);

            //        base.OnModelCreating(modelBuilder);
            //        // Добавление преподавателей
            //        modelBuilder.Entity<Instructor>().HasData(
            //            new Instructor { InstructorId = 1, FirstName = "Alan", LastName = "Turing" },
            //            new Instructor { InstructorId = 2, FirstName = "Grace", LastName = "Hopper" }
            //        );

            //        // Добавление зачислений
            //        modelBuilder.Entity<Enrollment>().HasData(
            //            new Enrollment { EnrollmentId = 1, CourseId = 1, StudentId = 1, EnrollmentDate = DateTime.Now },
            //            new Enrollment { EnrollmentId = 2, CourseId = 2, StudentId = 2, EnrollmentDate = DateTime.Now },
            //            new Enrollment { EnrollmentId = 3, CourseId = 1, StudentId = 2, EnrollmentDate = DateTime.Now }
            //        );

            //        // Дополните своими данными для Student и Course, если еще не добавлены
            //        modelBuilder.Entity<Student>().HasData(
            //            new Student { StudentId = 1, FirstName = "John", LastName = "Doe", BirthDate = new DateTime(2000, 1, 1) },
            //            new Student { StudentId = 2, FirstName = "Jane", LastName = "Doe", BirthDate = new DateTime(1999, 2, 2) }
            //        );

            //        modelBuilder.Entity<Course>().HasData(
            //            new Course { CourseId = 1, Title = "Mathematics", Description = "Mathematics Course" },
            //            new Course { CourseId = 2, Title = "Physics", Description = "Physics Course" }
            //        );
            //    }


            //}
        }
    }
}
    

