
using Edu.Core.Interfaces;

namespace Edu.Core.Entities;

public class Blog : IEntity
{
	public int Id { get; set; }
	public string ImagePath { get; set; }
	public string ByWhom { get; set; }
	public DateTime Date { get; set; }
	public string Description { get; set; }
}
