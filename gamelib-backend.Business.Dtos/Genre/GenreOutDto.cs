﻿namespace gamelib_backend.Business.Dtos {
    public class GenreOutDto {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<int> GameIds { get; set; }
    }
}
