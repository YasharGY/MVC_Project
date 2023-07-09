using Edu.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Core.Entities;

public class Categorie : IEntity
{
    [Key]
    public int Id { get; set; }
    public string Categories { get; set; } = null!;
    public List<CoursesOffer> Courses { get; set; }
}
