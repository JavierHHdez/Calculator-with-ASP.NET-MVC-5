using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace P2.Models
{
    public class property
    {

        public int id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public double num1 { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public double num2 { get; set; }
        public string operador { get; set; }
        public double resultado { get; set; }
    }
}