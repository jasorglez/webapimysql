using System;
using System.Collections.Generic;

namespace mysqlWebApi.Models;

public partial class Users
{
    public int Id { get; set; }

    public string? Usuario { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }

    public string? Mail { get; set; }

    public string? Position { get; set; }

    public short? Activo { get; set; }
}
