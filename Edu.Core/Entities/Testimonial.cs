

using Edu.Core.Interfaces;

namespace Edu.Core.Entities;

public class Testimonial : IEntity
{
	public int Id { get; set; }
	public string ImagePath { get; set; }
	public string Information { get; set; }
	public string Name { get; set; }
	public string Position { get; set; }
}
