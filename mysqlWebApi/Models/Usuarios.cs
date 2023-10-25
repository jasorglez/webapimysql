using System;
using System.Collections.Generic;

namespace mysqlWebApi.Models;

public partial class Usuarios
{
    public int Id { get; set; }

    public string? Usuario { get; set; }

    public string? Password { get; set; }

    public string? Nombre { get; set; }

    public string? Mail { get; set; }

    public string? Puesto { get; set; }

    public short? Activo { get; set; }
}
