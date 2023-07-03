
using Edu.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Edu.Core.Entities;

public class Blog : IEntity
{
	public int Id { get; set; }
	public string ImagePath { get; set; }
    [Required, MaxLength(30)]
    public string ByWhom { get; set; }
    [Required, MaxLength(20)]
    public string Date { get; set; }
	public string Description { get; set; }
}
