using System;
using System.Collections.Generic;

namespace mysqlWebApi.Models;

public partial class Bancos
{
    public int IId { get; set; }

    public string? Nombre { get; set; }

    public string? Sucursal { get; set; }

    public int? Numsucursal { get; set; }

    public string? Contacto { get; set; }

    public string? Telefono { get; set; }

    public byte[]? Imagen { get; set; }

    public int? ICodigoSat { get; set; }

    public int? IActivo { get; set; }
}
