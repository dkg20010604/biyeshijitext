namespace DOEMTEXT.DTO.ModelsDTO
{
    public class BaseClassInfomation
    {
        /// <summary>
        /// 专业代码
        /// </summary>
        public string ClassId { get; set; } = null!;

        /// <summary>
        /// 专业名称
        /// </summary>
        public string ClassName
        {
            get; set;
        }

        /// <summary>
        /// 学院代码
        /// </summary>
        public string CollegeId
        {
            get; set;
        }

        /// <summary>
        /// 状态（是否启用）
        /// </summary>
        public string Status { get; set; } = null!;
    }
}
