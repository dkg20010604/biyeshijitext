namespace DOEMTEXT.DTO.ModelsDTO
{
    public class DetailedClassInfomation
    {
        /// <summary>
        /// 专业班级详细名称
        /// </summary>
        public string ClassName
        {
            get; set;
        }

        /// <summary>
        /// 班主任
        /// </summary>
        public string? Headmaster
        {
            get; set;
        }

        public int Total { get; set; }

        /// <summary>
        /// 辅导员
        /// </summary>
        public string? Instructor
        {
            get; set;
        }
    }
}
