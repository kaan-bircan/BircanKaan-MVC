using Business.Models;
using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
	public interface IGradeService
	{
        IQueryable<GradeModel> Query();
    }
    public class GradeService : IGradeService
    {
        private readonly Db _db;

        public GradeService(Db db)
        {
            _db = db;
        }

        public IQueryable<GradeModel> Query()
        {
            return _db.Grades.Select(a => new GradeModel()
            {
                Id = a.Id,
                Year = a.Year
            });
        }
    }
}
