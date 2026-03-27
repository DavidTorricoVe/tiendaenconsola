namespace Tiendaconsola
{
    public class carrito
    {
        private producto[] productos = new producto[100];
        private int cantidad = 0;

        public void agregaralcarrito(producto prod)
        {
            if (cantidad < 100)
            {
                productos[cantidad] = prod;
                cantidad++;
            }
        }

        public double mostrartotal()
        {
            double total = 0;
            for (int i = 0; i < cantidad; i++)
            {
                total += productos[i].getprecio();
            }
            return total;
        }

        public int cantidaddeproductos() { return cantidad; }
        public producto getproducto(int posicion) { return productos[posicion]; }

        public void vaciar() { cantidad = 0; }
    }
}