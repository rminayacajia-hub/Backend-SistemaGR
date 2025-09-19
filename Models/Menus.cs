namespace Backend.Models
{
    public class Menus
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public double Precio { get; set; }
        public bool Disponible { get; set; } = true;

        // Relación: Un menú puede estar en muchas órdenes
        public ICollection<Ordenes> Ordenes { get; set; } = new List<Ordenes>();
    }
}
