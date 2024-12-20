﻿using ContosoUniverstity.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniverstity.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int  Credits { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}