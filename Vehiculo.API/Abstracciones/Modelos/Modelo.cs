using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class ModeloBase
    {
        [Required(ErrorMessage = "La propiedad nombre es requerida")]
        public string Nombre { get; set; }
    }

    public class ModeloRequest : ModeloBase
    {
        public Guid IdMarca { get; set; }

    }

    public class ModeloResponse : ModeloBase
    {
        public Guid Id { get; set; }

        public string Marca { get; set; }

    }
}