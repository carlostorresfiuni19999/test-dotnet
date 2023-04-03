using System.ComponentModel.DataAnnotations;

namespace TestEx.Models
{
    public class TodoDTOEdit
    {
        [Required(ErrorMessage = "Requerido")]
        public string Name { get; set; }
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
