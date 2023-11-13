#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
	public class StudentModel
	{
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		[Required]
		[StringLength(50)]
		public string Surname { get; set; }

		[DisplayName("University Exam Rank")]
		public int? UniversityExamRank { get; set; }

		[DisplayName("Cumulative Gpa")]
		public decimal? CumulativeGpa { get; set; }

		[DisplayName("Full Name")]
		public string FullNameOutput { get; set; }

		[DisplayName("Grade")]
		public string GradeOutput { get; set; }
		public int GradeId {  get; set; }

    }
}
