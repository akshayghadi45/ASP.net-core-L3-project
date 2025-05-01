namespace CoreSkillsApp.DTOs
{
    public class TaskDTO
    {
        public int TaskID { get; set; }
        public string TaskDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpectedClosureDate { get; set; }
        public string AssignedTo { get; set; }
        public bool CompletionStatus { get; set; }
    }
}
