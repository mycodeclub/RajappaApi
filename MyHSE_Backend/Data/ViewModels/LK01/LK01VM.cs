using MyHSE_Backend.Data.DbModels.LK01;
using MyHSE_Backend.Data.DbModels.Settings;

namespace MyHSE_Backend.Data.ViewModels.LK01
{
    public class LK01VM
    {
        public LK01Header Header { get; set; }

        public List<LK01Victim> Victims { get; set; }

        public List<RequestComments> CommentsLst { get; set; }
    }
}
