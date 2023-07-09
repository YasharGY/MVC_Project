using Edu.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Core.Entities;

public class Speaker : IEntity
{
    public int Id { get; set; }
    public string ImagePath { get; set; }
    public string Name { get; set; }
    public string Postions { get; set; }
    public string JobName { get; set; }
    //Relationships
    public List<EventSpeaker> EventSpeakers { get; set; }
}
