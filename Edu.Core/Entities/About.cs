using Edu.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Core.Entities;

public class About : IEntity
{
    public int Id { get; set; }
    public string Imagepath { get; set; }

    [Required]
    [StringLength(70)]
    public string Title { get; set; }
    [Required]
    [StringLength(500)]
    public string Description { get; set; }
}
