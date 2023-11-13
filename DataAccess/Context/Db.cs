using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
	public class Db : DbContext
	{
		public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }

		public Db(DbContextOptions options) : base(options)
		{
		}
	}
}
