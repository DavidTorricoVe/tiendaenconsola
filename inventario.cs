namespace Tiendaconsola 
{
    public class inventario
    {
        private producto[] vectordeproductos = new producto[100];
        private int contador = 0;

        public void agregarproducto(producto prod)
        {
            if (contador < 100)
            {
                vectordeproductos[contador] = prod;
                contador++;
            }
        }   
        
        public int stockdeproductos() { return contador; }  
        public producto getproducto(int posicion) { return vectordeproductos[posicion]; }      

        private int buscarindice(string cod)
        {
            for (int i = 0; i < contador; i++)
            {
                if (vectordeproductos[i].getcodigo() == cod) return i;
            }
            return -1;
        }

        public bool actualizarproducto(string cod, string nuevonombre, double nuevoprecio)
        {
            int idx = buscarindice(cod);
            if (idx != -1)
            {
                vectordeproductos[idx].setnombre(nuevonombre);
                vectordeproductos[idx].setprecio(nuevoprecio);
                return true;
            }
            return false;
        }

        public bool eliminarproducto(string cod)
        {
            int idx = buscarindice(cod);
            if (idx != -1)
            {
                for (int i = idx; i < contador - 1; i++)
                {
                    vectordeproductos[i] = vectordeproductos[i + 1];
                }
                vectordeproductos[contador - 1] = null;
                contador--;
                return true;
            }
            return false;
        }
    }
}