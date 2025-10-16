using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Auth;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Recepcionista : BaseEntity
{
    public IdVO Id { get; set; } = null!;
    public NombreVO Nombre { get; set; } = null!;
    public TelefonoVO Telefono { get; set; } = null!;
    public DescripcionVO AreaResponsabilidad { get; set; } = null!;
    //El valor por defecto seria Activo hasta que no lo este o lo despidan
    public EstadoVO IsActive { get; set; } = new EstadoVO(true);
    //Relaciones
    //FK real (int)
    public int UserId { get; set; }
    public UserMember User { get; set; } = null!;
    // Relacion de uno a muchos
    public ICollection<OrdenServicio> OrdenesServicio { get; set; } = new List<OrdenServicio>();
    //constructores
    public Recepcionista()
    {
        IsActive = new EstadoVO(true); //nunca sera null
    }
    public Recepcionista (IdVO id, NombreVO nombre, TelefonoVO? telefono, DescripcionVO areaResponsabilidad, EstadoVO? isActive, int userId)
    {
        Id = id;
        Nombre = nombre;
        Telefono = telefono;
        AreaResponsabilidad = areaResponsabilidad;
        IsActive = isActive ?? new EstadoVO(true); // valor por defecto si no se pasa
        UserId = userId; 
    }
}
