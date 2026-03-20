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
            double suma = 0;
            
            for (int i = 0; i < cantidad; i++)
            {
                suma += productos[i].getprecio();
            }
            
            return suma;
        }

        public int cantidaddeproductos()
        {
            return cantidad;
        }

        public producto getproducto(int posicion)
        {
            return productos[posicion];
        }
    }
}