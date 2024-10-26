using System.ComponentModel.DataAnnotations;

namespace RPBDISlLab4.Models
{
    public class Inspector
    {
        [Key]
        [Display(Name = "Код Инспектора")]
        public int InspectorId { get; set; }

        [Display(Name = "Проверяющий")]
        public string FullName { get; set; } = null!;

        [Display(Name = "Департамент")]
        public string Department { get; set; } = null!;

        public virtual ICollection<Inspection> Inspections { get; set; } = new List<Inspection>();
    }
}
