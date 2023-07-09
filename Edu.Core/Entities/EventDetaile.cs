using Edu.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Core.Entities;

public class EventDetaile : IEntity
{
    public int Id { get; set; }
    [Required, MaxLength(300)]
    public string ImagePath { get; set; } = null!;
    [Required, MaxLength(1300)]
    public string Description { get; set; } = null!;

    //Relationships
    public int EventsId { get; set; }
    [ForeignKey("LeftEventsId")]
    public LeftEvent Events { get; set; }
}
