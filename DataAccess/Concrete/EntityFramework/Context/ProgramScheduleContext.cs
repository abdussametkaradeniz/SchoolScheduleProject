
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class ProgramScheduleContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-LDKVN8F\SQLEXPRESS;Initial Catalog=ProgramSchedule;Integrated Security=True");
            //trusted connection yap hata alırsan

        }
        public DbSet<CustomerDto> CustomerDtos { get; set; }
        public DbSet<ClassDto> ClassesDtos { get; set; }
        public DbSet<CustomersAndSchoolDtos> CustomersAndSchoolDtos { get; set; }
       

    }
}
