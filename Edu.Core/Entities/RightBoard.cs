
using Edu.Core.Interfaces;

namespace Edu.Core.Entities;

public class RightBoard:IEntity
{
	public int Id { get; set; }
	public string Title { get; set; }
	public string Information { get; set; }
}
