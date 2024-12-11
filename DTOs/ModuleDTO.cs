namespace VarsityManagementAPI.DTOs
{
    public class ModuleDTO
    {
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public string ModuleCode { get; set; }
        public int Credits { get; set; }
        public int CourseId { get; set; }
    }
}
