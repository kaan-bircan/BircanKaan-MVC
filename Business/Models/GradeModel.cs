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
	public class GradeModel
	{
		public int Id { get; set; }
		
		[Required]
		public string Year { get; set; }

		[DisplayName("Grade")]
        public string GradeOutput { get; set; }
    }
}
