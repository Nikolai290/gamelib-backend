namespace gamelib_backend.Business.Dtos {
    public class UpdateCompanyDto {
        public string Name { get; set; }
        public IList<int> GameIds { get; set; }
    }
}
