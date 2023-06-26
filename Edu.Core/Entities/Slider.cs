

using Edu.Core.Interfaces;

namespace Edu.Core.Entities;

public class Slider : IEntity
{
	public int Id { get; set;}
	public string Title { get; set; } = null!;
	public string Title2 { get; set; }=null!;
	public string Description { get; set;}=null!;
	public string ImagePath { get; set;}=null!;
}
