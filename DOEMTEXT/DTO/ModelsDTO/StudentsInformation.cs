namespace DOEMTEXT.DTO.ModelsDTO
{
    public partial class StudentsInformation
    {
        public string StudentId { get; set; } = null!;

        public string StudentName { get; set; } = null!;

        public string Gender { get; set; } = null!;

        public string IdentityCard { get; set; } = null!;

        public string Status { get; set; } = null!;

        public string? Power { get; set; }

        public string? CollegeName { get; set; }
        #region 班级信息
        public string? ClassName { get; set; }
        #endregion
        public string? Headmaster { get; set; }

        public string? Instructor { get; set; }
    }

}
