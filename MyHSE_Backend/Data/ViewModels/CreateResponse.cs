namespace MyHSE_Backend.Data.ViewModels
{
    public class CreateResponse
    {
        public bool IsCreated { get; set; }
        public Guid UniqueId { get; set; }
        public List<string>? ErrorMessages { get; set; }
        public List<string>? SuccessMessages { get; set; }
        public List<string>? Details { get; set; }
    }
}
