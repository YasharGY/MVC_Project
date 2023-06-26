

using Edu.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Edu.Core.Entities;

public class NoticeBoard : IEntity
{
	public int Id { get; set; }
		
	public string Title { get; set; } 
	[Required, MaxLength(20)]
	public string Date { get; set; }=null!;
	[Required, MaxLength(200)]
	public string Description { get; set; } = null!;
}
