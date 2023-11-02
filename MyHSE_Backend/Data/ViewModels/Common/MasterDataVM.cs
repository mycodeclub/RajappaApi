using MyHSE_Backend.Data.DbModels.Settings;
using MyHSE_Backend.Data.DbModels.WorkFlow;

namespace MyHSE_Backend.Data.ViewModels
{
    public class MasterDataVM
    {
        public List<IncidentCategory> IncidentCategories { get; set; }
        public List<IncidentClassification> IncidentClassifications { get; set; }
        public List<VictimCategory> VictimCategories { get; set; }
        public List<Department> Departments { get; set; }
        public List<Division> Divisions { get; set; }
        public List<WFApprover> WFApprovers { get; set; }
    }
}
