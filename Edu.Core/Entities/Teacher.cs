using Edu.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Core.Entities;

public class Teacher : IEntity
{
	public int Id { get; set; }
	public string ImagePath { get; set; }
	[Required, MaxLength(22)]
	public string Name { get; set; } = null!;
	[Required, MaxLength(30)]
	public string Posistion { get; set; } = null!;
	public TeacherDetaile teacherDetaile { get; set; }
}
