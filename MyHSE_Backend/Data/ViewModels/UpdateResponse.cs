namespace MyHSE_Backend.Data.ViewModels
{
    public class UpdateResponse
    {
        public bool IsUpdated { get; set; }
        public Guid UniqueId { get; set; }
        public List<string>? ErrorMessages { get; set; }
        public List<string>? SuccessMessages { get; set; }
        public List<string>? Details { get; set; }
    }
}
