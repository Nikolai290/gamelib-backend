﻿using gamelib_backend.Business.Dtos;
using gamelib_backend.Domain.Core.DbEntities;

namespace gamelib_backend.Business.Interfaces.Services {
    public interface IGenreService
        : IBaseCrudService<Genre, int, RequestGenreDto, GenreOutDto, CreateGenreDto, UpdateGenreDto> {
    }
}
