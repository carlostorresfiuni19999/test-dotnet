using System.ComponentModel.DataAnnotations;

namespace TestEx.Models
{
    public class Todo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public bool IsActive { get; set; }
        public string Name { get; set; }
   
    }
}
