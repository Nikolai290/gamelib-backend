namespace gamelib_backend.Business.Dtos {
    public class UpdateGameDto {
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public IList<int> GenreIds { get; set; }
    }
}
