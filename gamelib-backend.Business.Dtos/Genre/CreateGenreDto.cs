namespace gamelib_backend.Business.Dtos {
    public class CreateGenreDto {
        public string Name { get; set; }
        public IList<int> GameIds { get; set; }
    }
}
