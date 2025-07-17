using System.ComponentModel.DataAnnotations;


namespace Abstracciones.Modelos
{
    public class VehiculoBase
    {
        [Required(ErrorMessage = "La propieda placa es requerida")]
        [RegularExpression(@"[A-Za-z]{3}-[0-9]{3}", ErrorMessage = "EL formato de la placa debe de ser ###-ABC"),]
        public string Placa { get; set; }
        [Required(ErrorMessage = "La propieda color es requerida")]
        [StringLength(40, ErrorMessage = "La propieda color debe ser mayor a 4 caracteres y menos a 40", MinimumLength = 4)]
        public string Color { get; set; }
        [Required(ErrorMessage = "La propieda año es requerida")]
        [RegularExpression(@"(19|20)\d\d", ErrorMessage = "EL formato del año no es valido")]
        public int Anio { get; set; }
        [Required(ErrorMessage = "La propieda precio es requerida")]
        public Decimal Precio { get; set; }
        [Required(ErrorMessage = "La propieda correo es requerida")]
        [EmailAddress]
        public string CorreoPropietario { get; set; }
        [Required(ErrorMessage = "La propieda telefono es requerida")]
        [Phone]
        public string TelefonoPropietario { get; set; }
    }
    public class VehiculoRequest : VehiculoBase
    {
        public Guid IdModelo { get; set; }

    }

    public class VehiculoResponse : VehiculoBase
    {
        public Guid Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }


    }
}