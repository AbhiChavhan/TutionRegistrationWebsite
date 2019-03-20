using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TutionRegistration.Models;

namespace TutionRegistration.ViewModels
{
    public class StudentRegisterViewModel
    {
        public IEnumerable<Batches> Batches { get; set; }
        public Students Students { get; set; }
    }
}