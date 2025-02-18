﻿using System.ComponentModel.DataAnnotations;

namespace DiscograficaWebApi.Entity;

public class Usuario
{
    public long Id { get; set; }
    public string Nombre { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
