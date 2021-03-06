namespace gamelib_backend.Domain.Core.DbEntities {
    public class Company : DbEntity {
        public string Name { get; set; }
        public virtual IList<Game> Games { get; set; }
    }
}
