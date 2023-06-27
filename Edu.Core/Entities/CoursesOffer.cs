
using Edu.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Edu.Core.Entities;

public class CoursesOffer:IEntity
{
	public int Id { get; set; }
	public string ImagePath { get; set; }
	[Required,MaxLength(30)]
	public string Title { get; set; }
	[Required,MaxLength(150)]
	public string Description { get; set; }
	
}
