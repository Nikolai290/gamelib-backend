namespace gamelib_backend.Domain.Core.DbEntities {
    public abstract class DbEntity : DbEntity<int> {
    }

    public abstract class DbEntity<TId> {
        public TId Id { get; set; }
        public bool IsDeleted { get; set; }

    }
}
