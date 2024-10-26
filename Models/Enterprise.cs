using System.ComponentModel.DataAnnotations;

namespace RPBDISlLab4.Models
{
    public partial class Enterprise
    {
        [Key]
        [Display(Name = "Код Предприятия")]
        public int EnterpriseId { get; set; }

        [Display(Name = "Предприятие")]
        public string Name { get; set; } = null!;

        [Display(Name = "Тип Собственности")]
        public string OwnershipType { get; set; } = null!;

        [Display(Name = "Адресс")]
        public string Address { get; set; } = null!;

        [Display(Name = "Управляющий")]
        public string DirectorName { get; set; } = null!;

        [Display(Name = "Номер Управляющего")]
        public string DirectorPhone { get; set; } = null!;

        public virtual ICollection<Inspection> Inspections { get; set; } = new List<Inspection>();
    }
}
