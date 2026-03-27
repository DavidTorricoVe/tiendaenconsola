namespace Tiendaconsola
{
    public class compra
    {
        private int idcompra;
        private usuario cliente;
        private producto[] detalle;
        private int cantidad;
        private double total;

        public compra(int id, usuario cli, carrito car)
        {
            idcompra = id;
            cliente = cli;
            cantidad = car.cantidaddeproductos();
            detalle = new producto[cantidad];
            
            for(int i = 0; i < cantidad; i++) 
            {
                detalle[i] = car.getproducto(i);
            }
            total = car.mostrartotal();
        }

        public int getid() { return idcompra; }
        public usuario getcliente() { return cliente; }
        public double gettotal() { return total; }
        public int getcantidad() { return cantidad; }
        public producto getproducto(int pos) { return detalle[pos]; }
    }
}