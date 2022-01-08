using Nexos.Prueba.Core.API.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nexos.Prueba.Core.API.BindingModel
{
    /// <summary>
    /// Clase para el manejo de editoriales
    /// </summary>
    public class EditorialesDTO
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public EditorialesDTO()
        {
            Libros = new HashSet<LibrosDTO>();
        }

        /// <summary>
        /// Id de la editorial
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Nombre de la editorial
        /// </summary>
        [Required(ErrorMessage = "El nombre de la editorial es reuqerido")]
        public string Nombre { get; set; }
        /// <summary>
        /// Dirección de la editorial
        /// </summary>
        [Required(ErrorMessage = "La dirección es requerida")]
        public string Direccion { get; set; }
        /// <summary>
        /// Número telefonico
        /// </summary>
        [Required(ErrorMessage = "El telefono es requerido")]
        public string Telefono { get; set; }
        /// <summary>
        /// Correo electronico
        /// </summary>
        [Required(ErrorMessage = "El email es requerido")]
        [CorreoValido(ErrorMessage ="El formato del correo no es válido")]
        public string Email { get; set; }
        /// <summary>
        /// Número máximo de libros para regitrar
        /// </summary>
        public int MaximoLibros { get; set; }
        /// <summary>
        /// Libros de la editorial
        /// </summary>
        public virtual ICollection<LibrosDTO> Libros { get; set; }
    }

    #region Validaciones
    /// <summary>
    /// 
    /// </summary>
    public class CorreoValidoAttribute: ValidationAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            string correo = (string)value;

            ValidatorEmail validator = new();
            return validator.EmailIsValid(correo);         
        }
    }

    #endregion

}
