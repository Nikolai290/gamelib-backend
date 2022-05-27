namespace gamelib_backend.Business.Dtos {
    public class RequestGenreDto {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public IList<int> GameIds { get; set; }
    }
}
