namespace gamelib_backend.Domain.Core.DbEntities {
    public class DbEntity : DbEntity<int> {
    }

    public class DbEntity<TId> {
        public TId Id { get; set; }
        public bool IsDeleted { get; set; }

    }
}
