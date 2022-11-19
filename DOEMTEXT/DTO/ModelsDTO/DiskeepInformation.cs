namespace DOEMTEXT.DTO.ModelsDTO
{
    public class DiskeepInformation
    {
        /// <summary>
        /// 学号
        /// </summary>
        public string StudentId { get; set; } = null!;

        /// <summary>
        /// 姓名
        /// </summary>
        public string StudentName { get; set; } = null!;

        /// <summary>
        /// 学院名称
        /// </summary>
        public string? CollegeName
        {
            get; set;
        }

        public string ClassName { get; set; }

        /// <summary>
        /// 违规类型
        /// </summary>
        public string? DiskeepType
        {
            get; set;
        }

        /// <summary>
        /// 违规时间
        /// </summary>
        public DateTime DiskeepTime
        {
            get; set;
        }

        /// <summary>
        /// 违规描述
        /// </summary>
        public string? DiskeepText
        {
            get; set;
        }
    }
}
