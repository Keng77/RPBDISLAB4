using System.ComponentModel.DataAnnotations;

namespace RPBDISlLab4.Models
{
    public partial class Inspection
    {
        [Key]
        [Display(Name = "Код проверки")]
        public int InspectionId { get; set; }

        [Display(Name = "Код Испектора")]
        public int InspectorId { get; set; }

        [Display(Name = "Код Предприятия")]
        public int EnterpriseId { get; set; }

        [Display(Name = "Дата Проверки")]
        [DataType(DataType.Date)]
        public DateOnly InspectionDate { get; set; }

        [Display(Name = "Номер Протокола")]
        public string ProtocolNumber { get; set; }

        [Display(Name = "Код Нарушения")]
        public int ViolationTypeId { get; set; }

        [Display(Name = "Ответственный")]
        public string ResponsiblePerson { get; set; }

        [Display(Name = "Задолженность")]
        public decimal PenaltyAmount { get; set; }

        [Display(Name = "Дедлайн Оплаты")]
        [DataType(DataType.Date)]
        public DateOnly PaymentDeadline { get; set; }

        [Display(Name = "Дедлайн исправления")]
        [DataType(DataType.Date)]
        public DateOnly CorrectionDeadline { get; set; }

        [Display(Name = "Статус Оплаты")]
        public string? PaymentStatus { get; set; }

        [Display(Name = "Статус Исправления")]
        public string? CorrectionStatus { get; set; }

        public virtual Enterprise Enterprise { get; set; } = null!;

        public virtual Inspector Inspector { get; set; } = null!;

        public virtual ViolationType ViolationType { get; set; } = null!;
    }
}
