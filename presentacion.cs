namespace Tiendaconsola 
{
    public class presentacion
    {
        public void mostrarstock(inventario inv)
        {
            Console.WriteLine(" INVENTARIO DE PRODUCTOS ");
            
            for (int i = 0; i < inv.stockdeproductos(); i++)
            {
                producto p = inv.getproducto(i);
                Console.WriteLine("Codigo: " + p.getcodigo() + " | Nombre: " + p.getnombre() + " | Precio: Bs." + p.getprecio());
            }
            
            Console.WriteLine("Total de unidades en stock: " + inv.stockdeproductos());
        }

        public void mostrarcompra(carrito car)
        {
            Console.WriteLine(" DATOS DEL CARRITO ");
            
            for (int i = 0; i < car.cantidaddeproductos(); i++)
            {
                producto p = car.getproducto(i);
                Console.WriteLine("- " + p.getnombre() + " (Bs." + p.getprecio() + ")");
            }
            
            Console.WriteLine("Cosas llevadas: " + car.cantidaddeproductos());
            Console.WriteLine("Total a pagar: Bs. " + car.mostrartotal());
        }
    }
}