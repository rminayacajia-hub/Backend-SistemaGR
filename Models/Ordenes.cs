namespace Backend.Models
{
    public class Ordenes
    {
        public int Id { get; set; }
        public DateTime FechaOrden { get; set; } = DateTime.UtcNow;
        public int Cantidad { get; set; } = 1;
        

        // Claves foráneas
        public int ClientesId { get; set; }
        public int MenusId { get; set; }

        // Relaciones
        public Clientes Cliente { get; set; } = null!;
        public Menus Menu { get; set; } = null!;
    }
}
