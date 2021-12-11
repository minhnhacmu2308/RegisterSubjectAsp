﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace RegisterSubjectAsp.Models
{
    public class DBContext : DbContext
    {
        public DBContext() : base("DBConnectionString")
        {

        }
        public DbSet<Schedule> schedules { get; set; }

        public DbSet<Subject> subjects { get; set; }

        public DbSet<Score> scores { get; set; }

        public DbSet<Course> courses { get; set; }

        public DbSet<Role> roles { get; set; }

        public DbSet<User> users { get; set; }

        public DbSet<ScheduleStudent> scheduleStudents { get; set; }

        public DbSet<Grade> grades { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.PropertyName + ": " + x.ErrorMessage));
                throw new DbEntityValidationException(errorMessages);
            }
        }

    }
}