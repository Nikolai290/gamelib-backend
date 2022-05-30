namespace gamelib_backend.Business.Dtos {
    public class UpdateGenreDto {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<int> GameIds { get; set; }
    }
}
