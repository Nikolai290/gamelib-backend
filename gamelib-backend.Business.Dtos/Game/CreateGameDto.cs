namespace gamelib_backend.Business.Dtos {
    public class CreateGameDto {
        public string Name { get; set; }
        public int? CompanyId { get; set; }
        public IList<int>? GenreIds { get; set; }
    }
}
