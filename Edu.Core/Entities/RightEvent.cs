

using Edu.Core.Interfaces;

namespace Edu.Core.Entities;

public class RightEvent : IEntity
{
	public int Id { get; set; }
	public string Day { get; set; }
	public string Month { get; set; }
	public string Title { get; set; }
	public string Datetime { get; set; }
	public string Location { get; set; }
	
}
