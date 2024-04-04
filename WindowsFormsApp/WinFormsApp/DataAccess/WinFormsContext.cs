using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace WinFormsApp.DataAccess
{
    public class WinFormsContext : DbContext
    {
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<ClassModel> Classes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            /*
             * Issue occurs while adding migration. Works when replaced with direct string in optionBuilder. 
             */

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentModel>().ToTable("Students");
            modelBuilder.Entity<ClassModel>().ToTable("Classes");

            modelBuilder.Entity<ClassModel>().HasData(
                new ClassModel { Id = 1, Name = "One", CreatedDate = DateTime.Now, ModificationDate = null },
                new ClassModel { Id = 2, Name = "Two", CreatedDate = DateTime.Now, ModificationDate = null },
                new ClassModel { Id = 3, Name = "Three", CreatedDate = DateTime.Now, ModificationDate = null },
                new ClassModel { Id = 4, Name = "Four", CreatedDate = DateTime.Now, ModificationDate = null },
                new ClassModel { Id = 5, Name = "Five", CreatedDate = DateTime.Now, ModificationDate = null },
                new ClassModel { Id = 6, Name = "Six", CreatedDate = DateTime.Now, ModificationDate = null },
                new ClassModel { Id = 7, Name = "Seven", CreatedDate = DateTime.Now, ModificationDate = null },
                new ClassModel { Id = 8, Name = "Eight", CreatedDate = DateTime.Now, ModificationDate = null },
                new ClassModel { Id = 9, Name = "Nine", CreatedDate = DateTime.Now, ModificationDate = null },
                new ClassModel { Id = 10, Name = "Ten", CreatedDate = DateTime.Now, ModificationDate = null }
            );

            modelBuilder.Entity<StudentModel>().HasData(
                new StudentModel { Id = Guid.NewGuid(), Name = "John", Gender = 1, DOB = new DateTime(2010, 1, 12), ClassId = 1, CreatedDate = DateTime.Now, ModificationDate = null },
                new StudentModel { Id = Guid.NewGuid(), Name = "Jamie", Gender = 1, DOB = new DateTime(2012, 7, 21), ClassId = 7, CreatedDate = DateTime.Now, ModificationDate = null },
                new StudentModel { Id = Guid.NewGuid(), Name = "Aaron", Gender = 1, DOB = new DateTime(2015, 10, 2), ClassId = 5, CreatedDate = DateTime.Now, ModificationDate = null },
                new StudentModel { Id = Guid.NewGuid(), Name = "Aysha", Gender = 2, DOB = new DateTime(2018, 4, 7), ClassId = 4, CreatedDate = DateTime.Now, ModificationDate = null },
                new StudentModel { Id = Guid.NewGuid(), Name = "Finch", Gender = 1, DOB = new DateTime(2020, 8, 13), ClassId = 6, CreatedDate = DateTime.Now, ModificationDate = null },
                new StudentModel { Id = Guid.NewGuid(), Name = "Xander", Gender = 1, DOB = new DateTime(2014, 11, 27), ClassId = 2, CreatedDate = DateTime.Now, ModificationDate = null },
                new StudentModel { Id = Guid.NewGuid(), Name = "Patricia", Gender = 2, DOB = new DateTime(2014, 3, 3), ClassId = 2, CreatedDate = DateTime.Now, ModificationDate = null },
                new StudentModel { Id = Guid.NewGuid(), Name = "Jane", Gender = 2, DOB = new DateTime(2012, 7, 30), ClassId = 4, CreatedDate = DateTime.Now, ModificationDate = null },
                new StudentModel { Id = Guid.NewGuid(), Name = "Maria", Gender = 2, DOB = new DateTime(2014, 5, 11), ClassId = 5, CreatedDate = DateTime.Now, ModificationDate = null },
                new StudentModel { Id = Guid.NewGuid(), Name = "Kayla", Gender = 2, DOB = new DateTime(2016, 2, 22), ClassId = 8, CreatedDate = DateTime.Now, ModificationDate = null }
            );
        }
    }
}
