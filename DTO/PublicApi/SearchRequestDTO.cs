namespace DTO.PublicApi
{
    public class SearchRequestDTO
    {
        public string? SearchString { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Isbn { get; set; }
    }
}