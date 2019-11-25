using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectGym.Domain
{
    public class EntityBase
    {
        [Key]
        public long Id { get; set; }

        // Campo para Borrado Logico o Suave
        [Required]
        public bool IsDelete { get; set; }

    }
}
