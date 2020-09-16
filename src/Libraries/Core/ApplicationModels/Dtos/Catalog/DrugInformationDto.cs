using System;
using System.Linq;
using Core.Entities.Catalog;

namespace Core.ApplicationModels.Dtos.Catalog
{
    public class DrugInformationDto
    {
        public int Id { get; set; }
        public int? DrugId { get; set; }

        public string Indication { get; set; }

        public string CounterIndication { get; set; }

        public string HowWorks { get; set; }

        public string HowToUse { get; set; }

        public string TypeOfUse { get; set; }

        public int? MinimalAgeOfUse { get; set; }

        public string Substances { get; set; }

        public string UserBule { get; set; }

        public string ProfessionalBule { get; set; }

        public DrugDto Drug { get; set; }

        public static DrugInformationDto FromModel(DrugInformation model)
        {
            return new DrugInformationDto()
            {
                DrugId = model.DrugId, 
                Indication = model.Indication, 
                CounterIndication = model.CounterIndication, 
                HowWorks = model.HowWorks, 
                HowToUse = model.HowToUse, 
                TypeOfUse = model.TypeOfUse, 
                MinimalAgeOfUse = model.MinimalAgeOfUse, 
                Substances = model.Substances, 
                UserBule = model.UserBule, 
                ProfessionalBule = model.ProfessionalBule, 
                Drug = DrugDto.FromModel(model.Drug), 
            }; 
        }

        public DrugInformation ToModel()
        {
            return new DrugInformation()
            {
                DrugId = DrugId, 
                Indication = Indication, 
                CounterIndication = CounterIndication, 
                HowWorks = HowWorks, 
                HowToUse = HowToUse, 
                TypeOfUse = TypeOfUse, 
                MinimalAgeOfUse = MinimalAgeOfUse, 
                Substances = Substances, 
                UserBule = UserBule, 
                ProfessionalBule = ProfessionalBule, 
                Drug = Drug.ToModel(), 
            }; 
        }
    }
}