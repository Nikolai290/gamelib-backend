using AutoMapper;
using FluentValidation;
using gamelib_backend.Business.Interfaces.Services;
using gamelib_backend.Domain.Core.DbEntities;
using gamelib_backend.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamelib_backend.Infrastructure.Business.Services {
    public class BaseCrudService<TEntity, TId, TRequestDto, TOutDto, TCreateDto, TUpdateDto>
        : IBaseCrudService<TEntity, TId, TRequestDto, TOutDto, TCreateDto, TUpdateDto> where TEntity : DbEntity<TId> {

        private readonly IBaseCrudRepository<TEntity, TId> baseCrudRepository;
        private readonly IValidator<TCreateDto> createValidator;
        private readonly IValidator<TUpdateDto> updateValidator;
        private readonly IMapper mapper;
        public virtual async Task<TOutDto> CreateAsync(TCreateDto createDto) {
            throw new NotImplementedException();
        }

        public virtual async Task DeleteAsync(TId id) {
            throw new NotImplementedException();
        }

        public virtual async Task<IList<TOutDto>> GetAllByAsync(TRequestDto requestDto) {
            throw new NotImplementedException();
        }

        public virtual async Task<TOutDto> GetByIdAsync(TId id) {
            throw new NotImplementedException();
        }

        public virtual async Task<TOutDto> UpdateAsync(TUpdateDto updateDto) {
            throw new NotImplementedException();
        }
    }
}
