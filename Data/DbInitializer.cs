//using RPBDISlLab4.Models;
//using System;
//using System.Linq;

//namespace RPBDISlLab4.Data
//{
//    public static class DbInitializer
//    {
//        public static void Initialize(InspectionsDbContext db)
//        {
//            db.Database.EnsureCreated();

//            // Проверка, есть ли уже записи в таблице предприятий
//            if (db.Enterprises.Any())
//            {
//                return; // База данных уже инициализирована
//            }
//            int enterpriseCount = 10;
//            int inspectorCount = 5;
//            int violationTypeCount = 3;
//            int inspectionCount = 100;

//            Random randObj = new(1);

//            // Заполнение таблицы типов нарушений
//            string[] violationBaseNames = { "Нарушение_", "Несоответствие_", "Отсутствие_" };
//            for (int i = 1; i <= violationTypeCount; i++)
//            {
//                db.ViolationType.Add(new ViolationType
//                {
//                    Name = violationBaseNames[randObj.Next(violationBaseNames.Length)] + i,
//                    PenaltyAmount = randObj.Next(1000, 10000),
//                    CorrectionPeriodDays = randObj.Next(7, 30)
//                });
//            }
//            db.SaveChanges();

//            // Заполнение таблицы инспекторов
//            string[] inspectorBaseNames = { "Иванов_", "Петров_", "Сидоров_" };
//            for (int i = 1; i <= inspectorCount; i++)
//            {
//                db.Inspectors.Add(new Inspector
//                {
//                    FullName = inspectorBaseNames[randObj.Next(inspectorBaseNames.Length)] + i,
//                    Department = "Отдел контроля"
//                });
//            }
//            db.SaveChanges();

//            // Заполнение таблицы предприятий
//            string[] enterpriseBaseNames = { "Завод_", "Фабрика_", "Предприятие_" };
//            for (int i = 1; i <= enterpriseCount; i++)
//            {
//                db.Enterprises.Add(new Enterprise
//                {
//                    Name = enterpriseBaseNames[randObj.Next(enterpriseBaseNames.Length)] + i,
//                    OwnershipType = "ООО",
//                    Address = "г. Москва, ул. Примерная, д. " + randObj.Next(1, 100),
//                    DirectorName = "Директор " + i,
//                    DirectorPhone = "+7" + randObj.Next(100000000, 999999999).ToString()
//                });
//            }
//            db.SaveChanges();

//            // Заполнение таблицы проверок
//            var enterprises = db.Enterprises.ToList();
//            var inspectors = db.Inspectors.ToList();
//            var violationTypes = db.ViolationType.ToList();

//            for (int i = 1; i <= inspectionCount; i++)
//            {
//                var inspectionDate = DateTime.Now.AddDays(-randObj.Next(1, 365));
//                db.Inspections.Add(new Inspection
//                {
//                    EnterpriseId = enterprises[randObj.Next(enterprises.Count)].EnterpriseId,
//                    InspectorId = inspectors[randObj.Next(inspectors.Count)].InspectorId,
//                    InspectionDate = DateOnly.FromDateTime(inspectionDate),
//                    ProtocolNumber = "PR-" + randObj.Next(10000, 99999),
//                    ViolationTypeId = violationTypes[randObj.Next(violationType.Count)].ViolationTypeId,
//                    ResponsiblePerson = "Ответственный_" + i,
//                    PenaltyAmount = randObj.Next(500, 5000),
//                    PaymentDeadline = DateOnly.FromDateTime(inspectionDate.AddDays(randObj.Next(10, 60))),
//                    CorrectionDeadline = DateOnly.FromDateTime(inspectionDate.AddDays(randObj.Next(5, 30))),
//                    PaymentStatus = randObj.Next(0, 2) == 0 ? "Оплачено" : "Не оплачено",
//                    CorrectionStatus = randObj.Next(0, 2) == 0 ? "Исправлено" : "Не исправлено"
//                });
//            }
//            db.SaveChanges();
//        }
//    }
//}
