namespace DOEMTEXT.DTO.ModelsDTO
{
    public partial class LiveInfomation
    {
        public string? StudentName { get; set; }

        public int BuildId { get; set; }

        public int Floor { get; set; }

        public int RoomNumber { get; set; }

        public string? CollgeName { get; set; }

        /// <summary>
        /// 床号
        /// </summary>
        public int? BedId { get; set; }

        /// <summary>
        /// 宿舍角色
        /// </summary>
        public string? Role { get; set; }

        /// <summary>
        /// 班级详细信息
        /// </summary>
        public string? ClassName { get; set; }

        /// <summary>
        /// 班主任
        /// </summary>
        public string? Headmaster { get; set; }

        /// <summary>
        /// 辅导员
        /// </summary>
        public string? Instructor { get; set; }
    }
}
