using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class MarcaBase
    {
        public string Nombre { get; set; }
     
    }

    public class MarcaResponse : MarcaBase
    {
        public Guid Id { get; set; }
    

    }
}