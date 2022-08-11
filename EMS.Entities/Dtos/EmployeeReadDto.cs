namespace EMS.Entities.Dtos
{
    public class EmployeeReadDto
    {
        #region Public Properties

        public int Id { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public DateTime JoinDate { get; set; } = DateTime.Parse("1/1/1753");
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;

        #endregion Public Properties
    }
}
