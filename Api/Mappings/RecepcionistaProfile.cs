using Api.DTOs.Recepcionistas;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;

namespace Api.Mappings;

public sealed class RecepcionistaProfile : Profile
{
    public RecepcionistaProfile()
    {
        // Configuración global para todos los ValueObjects simples
        CreateMap<IdVO, int>().ConvertUsing(vo => vo.Value);
        CreateMap<NombreVO, string>().ConvertUsing(vo => vo.Value);
        CreateMap<TelefonoVO, string>().ConvertUsing(vo => vo.Value);
        CreateMap<DescripcionVO, string>().ConvertUsing(vo => vo.Value);
        CreateMap<EstadoVO, bool>().ConvertUsing(vo => vo.Value);

        // Entidad -> DTO
        CreateMap<Administrador, RecepcionistaDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
            .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre.Value))
            .ForMember(dest => dest.Telefono, opt => opt.MapFrom(src => src.Telefono.Value))
            .ForMember(dest => dest.AreaResponsabilidad, opt => opt.MapFrom(src => src.AreaResponsabilidad.Value))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive.Value))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt));

        // Create DTO -> Entidad
        CreateMap<CreateRecepcionistaDto, Administrador>()
            .AfterMap((src, dest) =>
            {
                dest.Nombre = new NombreVO(src.Nombre);
                dest.Telefono = new TelefonoVO(src.Telefono);
                dest.AreaResponsabilidad = new DescripcionVO(src.AreaResponsabilidad);
                dest.IsActive = new EstadoVO(true);
            });
        // Update DTO -> Entidad (actualización parcial)
        var updateMap = CreateMap<UpdateRecepcionistaDto, Administrador>();
        updateMap.ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        updateMap.AfterMap((src, dest) =>
        {
            if (src.Nombre != null) dest.Nombre = new NombreVO(src.Nombre);
            if (src.Telefono != null) dest.Telefono = new TelefonoVO(src.Telefono);
            if (src.AreaResponsabilidad != null) dest.AreaResponsabilidad = new DescripcionVO(src.AreaResponsabilidad);
            if (src.IsActive.HasValue) dest.IsActive = new EstadoVO(src.IsActive.Value);
        });
    }
}