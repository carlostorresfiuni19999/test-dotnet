using System.ComponentModel.DataAnnotations;

namespace TestEx.Models
{
    public class TodoDTOCreate
    {
        [Required(ErrorMessage ="Requerido")]
        public string Name { get; set; }
    }
}
