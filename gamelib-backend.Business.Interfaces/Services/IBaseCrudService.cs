namespace gamelib_backend.Business.Interfaces.Services {
    public interface IBaseCrudService<TEntity, TId, TRequestDto, TOutDto, TCreateDto, TUpdateDto> {
        Task<TOutDto> GetByIdAsync(TId id);
        Task<IList<TOutDto>> GetAllByAsync(TRequestDto requestDto);
        Task<TOutDto> CreateAsync(TCreateDto createDto);
        Task<TOutDto> UpdateAsync(TUpdateDto updateDto);
        Task DeleteAsync(TId id);
    }
}
