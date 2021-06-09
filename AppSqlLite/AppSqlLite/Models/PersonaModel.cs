using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppSqlLite.Models
{
    public class PersonaModel
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int IdPersona { get; set; }
            public string NombrePersona { get; set; }
            public DateTime FechaNacimiento { get; set; }
            public bool PersonaActiva { get; set; }
        
    }
}