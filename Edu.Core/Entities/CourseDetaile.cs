﻿using Edu.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Core.Entities;

public class CourseDetaile : IEntity
{
    public int Id { get; set; }
    public string AboutCours { get; set; } = null!;
    [Required, MaxLength(350)]
    public string AboutCoursDescription { get; set; } = null!;
    [Required, MaxLength(50)]
    public string ToApply { get; set; } = null!;
    [Required, MaxLength(350)]
    public string ToApplyDescription { get; set; } = null!;
    [Required, MaxLength(50)]
    public string Certification { get; set; } = null!;
    [Required, MaxLength(400)]
    public string CertificationDescription { get; set; } = null!;
    [Required]
    public DateTime Starts { get; set; }
    [Required]
    public int Month { get; set; }
    [Required]
    public int Hours { get; set; }
    [Required, MaxLength(25)]
    public string Level { get; set; } = null!;
    [Required, MaxLength(22)]
    public string Language { get; set; } = null!;
    [Required]
    public int Students { get; set; }
    [Required, MaxLength(20)]
    public string Assesments { get; set; } = null!;
    [Required]
    public int CourseFee { get; set; }


    // Foreign Key
    public int CoursesOfferId { get; set; }
    [ForeignKey("CoursesOfferId")]
    public CoursesOffer Courses { get; set; }
}
