namespace Tiendaconsola
{
    public class presentacion
    {
        public void mostrarstock(inventario inv)
        {
   
            Console.WriteLine("¡Mira lo que tenemos ");
           
            
            if (inv.stockdeproductos() == 0)
            {
                Console.WriteLine(" No hay disponible");

                return;
            }
            
            for (int i = 0; i < inv.stockdeproductos(); i++)
            {
                producto p = inv.getproducto(i);
                Console.WriteLine($"  [{i}] {p.getnombre()} - ${p.getprecio()} (Cod: {p.getcodigo()})");
            }

        }

        public void mostrarcompra(carrito car)
        {

            Console.WriteLine("  Tu carrito de compras actual:");

            
            if (car.cantidaddeproductos() == 0)
            {
                Console.WriteLine(" El carrito esta super vacio");

                return;
            }
            
            for (int i = 0; i < car.cantidaddeproductos(); i++)
            {
                producto p = car.getproducto(i);
                Console.WriteLine($"  - {p.getnombre()} (${p.getprecio()})");
            }

            Console.WriteLine($"Total a pagar: ${car.mostrartotal()}");

        }
    }
}