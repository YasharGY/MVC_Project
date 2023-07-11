using Edu.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Core.Entities
{
	public class TeacherDetaile : IEntity
	{
		public int Id { get; set; }
		public string Description { get; set; } = null!;
		[Required, MaxLength(30)]
		public string Degree { get; set; } = null!;
		[Required]
		public int Experince { get; set; }
		[Required, MaxLength(50)]
		public string Hobbies { get; set; } = null!;
		[Required, MaxLength(35)]
		public string Facultry { get; set; } = null!;
		[Required, MaxLength(125)]
		public string Email { get; set; } = null!;

		[Required, MaxLength(40)]
		public string Phone { get; set; } = null!;
		[Required, MaxLength(50)]
		public string Skaype { get; set; } = null!;
		[Required]
		public int LanguageDegree { get; set; }
		[Required]
		public int TeamLeaderDegree { get; set; }
		[Required]
		public int DevelopmentDegree { get; set; }
		[Required]
		public int DesignDegree { get; set; }
		[Required]
		public int InnovationDegree { get; set; }
		[Required]
		public int CommunicationDegree { get; set; }

		public int TeacherId { get; set; }
		[ForeignKey("TeacherId")]
		public Teacher Teacher { get; set; }
	}
}
