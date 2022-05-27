namespace gamelib_backend.Business.Dtos {
    public class GameOutDto {
        public int Id { get; set; }
        public string Name { get; set; }
        public CompanyOutDto Company { get; set; }
        public IList<GenreOutDto> Genres { get; set; }
    }
}
