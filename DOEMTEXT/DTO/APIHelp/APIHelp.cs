namespace DOEMTEXT.DTO.APIHelp
{
    public class APIHelp<T>
    {
        public int? code { get; set; }
        public string? Messege { get; set; }
        public T? Data { get; set; }
    }
}
