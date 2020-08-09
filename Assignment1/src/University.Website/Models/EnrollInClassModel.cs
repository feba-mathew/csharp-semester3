using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace University.Website.Models
{
    public class EnrollInClassModel
    {
        [Display(Name = "Class")]
        public int SelectedClassId { get; set; }
    }
}