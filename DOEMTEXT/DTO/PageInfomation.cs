namespace DOEMTEXT.DTO
{
    public class PageInfomation<T>
    {
        public int PageIndex{get;set;}
        public int PageSize{get;set;}
        public int DataTotal{get;set;}
        public List<T>? Data{
            get;set;
        }
    }
}
