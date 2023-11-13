#nullable disable
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
	public class Grade
	{
		public int Id { get; set; }
		[Required]
        public string Year { get; set; }

		public List<Student> Students { get; set; }
    }
}
