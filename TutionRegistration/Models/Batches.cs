using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutionRegistration.Models
{
    public class Batches
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Fees { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public DateTime BatchStartDate { get; set; }
        [Required]
        public string Timing { get; set; }

    }
}