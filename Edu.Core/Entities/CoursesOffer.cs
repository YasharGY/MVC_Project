
using Edu.Core.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Edu.Core.Entities;

public class CoursesOffer:IEntity
{
	public int Id { get; set; } 
    public string ImagePath { get; set; } = null!;
    [Required,MaxLength(30)]
	public string Title { get; set; } = null!;
    [Required,MaxLength(150)]
	public string Description { get; set; } = null!;

    public int CategoriesId { get; set; }
    [ForeignKey("CategorieId")]
    public Categorie Categories { get; set; } 

    /* EF Relation */
    public CourseDetaile CoursesDetails { get; set; }


}
