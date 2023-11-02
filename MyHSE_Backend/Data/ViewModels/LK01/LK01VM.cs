using MyHSE_Backend.Data.DbModels.Docs;
using MyHSE_Backend.Data.DbModels.LK01;
using MyHSE_Backend.Data.DbModels.Settings;
using MyHSE_Backend.Data.DbModels.WorkFlow;

namespace MyHSE_Backend.Data.ViewModels.LK01
{
    public class LK01VM
    {
        public LK01Header Header { get; set; }

        public List<LK01Victim> Victims { get; set; }

        public List<RequestComments> CommentsLst { get; set; }

        public List<Documents> DocumentsLst { get; set; }

        public List<WorkflowLog> WorkFlowLogs { get; set; }

    }
}
