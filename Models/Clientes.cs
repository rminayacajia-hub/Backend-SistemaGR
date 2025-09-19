﻿namespace Backend.Models
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;

        // Relación: Un cliente puede tener muchas órdenes
        
        public ICollection<Ordenes> Ordenes { get; set; } = new List<Ordenes>();
    }
}
