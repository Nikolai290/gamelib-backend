namespace gamelib_backend.Business.Dtos {
    public class CreateCompanyDto {
        public string Name { get; set; }
        public IList<int>? GameIds { get; set; }
    }
}
