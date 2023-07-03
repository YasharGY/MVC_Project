

using Edu.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Edu.Core.Entities;

public class Slider : IEntity
{
	public int Id { get; set;}
    [Required, MaxLength(60)]
    public string Title { get; set; } = null!;
    [Required, MaxLength(60)]
    public string Title2 { get; set; }=null!;
    [Required, MaxLength(150)]
    public string Description { get; set;}=null!;
	public string ImagePath { get; set;}=null!;
}
