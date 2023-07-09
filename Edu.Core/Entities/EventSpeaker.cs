using Edu.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Core.Entities;

public class EventSpeaker : IEntity
{
    public int Id { get; set; }
    public int EventsId { get; set; }
    public LeftEvent Events { get; set; }


    public int SpeakersId { get; set; }
    public Speaker Speakers { get; set; }
}
