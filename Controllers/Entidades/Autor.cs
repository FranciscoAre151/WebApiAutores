using System.ComponentModel.DataAnnotations;
using WebApplication1.Validators;

namespace WebApplication1.Controllers.Entidades
{
    public class Autor
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El nombre es requerido")]
        [PrimeraLetraMayuscula] 
        public string Nombre { get; set; }    
        public List<Libro> Libros { get; set; }

    }
}
