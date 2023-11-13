using Business.Models;
using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
	public interface IStudentService
	{
		IQueryable<StudentModel> Query();
		bool Add(StudentModel model);
		bool Update(StudentModel model);
		bool Delete(int id);
	}
	public class StudentService : IStudentService
	{
		private readonly Db _db;

		public StudentService(Db db)
		{
			_db = db;
		}

		public bool Add(StudentModel model)
		{
			if(_db.Students.Any(s => s.Name.ToUpper() == model.Name.ToUpper().Trim()))
			{
				return false;
			}
			Student entity = new Student()
			{
				Id = model.Id,
				GradeId = model.GradeId,
				Name = model.Name,
				Surname = model.Surname,
				UniversityExamRank = model.UniversityExamRank,
				CumulativeGpa = model.CumulativeGpa
			};
			_db.Students.Add(entity);
			_db.SaveChanges();
			return true;
		}

		public bool Delete(int id)
		{
			Student entity = _db.Students.SingleOrDefault(s => s.Id == id);
			if (entity is null)
				return false;
			_db.Students.Remove(entity);
			_db.SaveChanges();
			return true;
		}

		public IQueryable<StudentModel> Query()
		{
			return _db.Students
				.OrderByDescending(s => s.CumulativeGpa).ThenBy(s => s.Name).ThenBy(s => s.Surname)
				.Select(s => new StudentModel()
				{
					Id = s.Id,
					FullNameOutput = String.Concat(s.Name," ",s.Surname),
					Name = s.Name,
					Surname = s.Surname,
					UniversityExamRank = s.UniversityExamRank,
					CumulativeGpa = s.CumulativeGpa,
					GradeOutput = s.Grade.Year.ToString(),
					GradeId = s.GradeId
				});
		}

		public bool Update(StudentModel model)
		{
			if (_db.Students.Any(s => s.Name.ToUpper() == model.Name.ToUpper().Trim() && s.Id != model.Id))
				return false;
			Student existingEntity = _db.Students.SingleOrDefault(s => s.Id == model.Id);
			if (existingEntity is null)
				return false;
			existingEntity.GradeId = model.GradeId;
			existingEntity.Name = model.Name;
			existingEntity.Surname = model.Surname;
			existingEntity.UniversityExamRank = model.UniversityExamRank;
			existingEntity.CumulativeGpa = model.CumulativeGpa;

			_db.Students.Update(existingEntity);
			_db.SaveChanges();
			return true;
		}
	}
}
