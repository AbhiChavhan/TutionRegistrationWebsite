using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TutionRegistration.Models
{
    public enum FeeStatus{ online = 1, offline = 2};
    public enum Gender { Male = 1, Female = 2, Transgender = 3};

    public class Students
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public string Qualification { get; set; }
        [Required]
        [Display(Name ="Date Of Birth")]
        public DateTime DOB { get; set; }
        [Required]
        public FeeStatus Fee { get; set; }
        [Display(Name = "Select Batch")]
        public Batches BatchData { get; set; }
        [Display(Name = "Select your batch")]
        public byte BatchId { get; set; }

        public bool Approved { get; set; }

        public string ExamKey { get; set; }

    }
}