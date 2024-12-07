namespace LabDemo.Models
{
    public class ChoreViewModel
    {

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public ChoreStatus Status { get; set; }
    }
}
