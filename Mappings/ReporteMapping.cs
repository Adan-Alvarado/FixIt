using FixIt.Dtos.Reportes;
using FixIt.Entities;
using Mapster;

namespace FixIt.Mappings
{
    public class ReporteMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Mapeo de ReporteCreateDto a ReporteEntity
            config.NewConfig<ReporteCreateDto, ReporteEntity>()
                .Map(dest => dest.Id, src => Guid.NewGuid())
                .Map(dest => dest.CreationDate, src => DateTime.Now)
                .Ignore(dest => dest.UpdatedDate)
                .Ignore(dest => dest.Activa);
            
            config.NewConfig<ReporteEntity, ReporteActionResponseDto>();

             config.NewConfig<ReporteEntity, ReporteItemDto>();

            config.NewConfig<ReporteEditDto, ReporteEntity>()
                .Map(dest => dest.UpdatedDate, src => DateTime.Now)
                .Ignore(dest => dest.CreationDate)
                .Ignore(dest => dest.Id)
                .Ignore(dest => dest.Activa);
        }
    }
}