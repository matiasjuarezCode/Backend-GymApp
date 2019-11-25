using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectGym.Dominio
{
    public class EntityBase
    {
        [Key]
        public long Id { get; set; }

        // Campo para Borrado Logico o Suave
        [Required]
        public bool EstaBorrado { get; set; }

        // Campo para Concurrencia
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
