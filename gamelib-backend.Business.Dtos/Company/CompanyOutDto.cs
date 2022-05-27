namespace gamelib_backend.Business.Dtos {
    public class CompanyOutDto {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<int> GameIds { get; set; }
    }
}
