using MyHSE_Backend.Data.DbModels.Settings;

namespace MyHSE_Backend.Data.ViewModels
{
    public class MasterDataVM
    {
        public List<IncidentCategory> IncidentCategories { get; set; }
        public List<IncidentClassification> IncidentClassifications { get; set; }
        public List<VictimCategory> VictimCategories { get; set; }
        public List<Department> Departments { get; set; }
        public List<Division> Divisions { get; set; }

    }
}
