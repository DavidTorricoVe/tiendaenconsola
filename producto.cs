namespace Tiendaconsola 
{
    public class producto
    {
        private string codigo;
        private string nombre;
        private double precio;
        
        public producto(string cod, string nom, double prec)
        {
            codigo = cod;
            nombre = nom;
            precio = prec;
        }

        public string getcodigo()
        {
            return codigo;
        }

        public string getnombre()
        {
            return nombre;
        }

        public double getprecio()
        {
            return precio;
        }   

        public void setnombre(string n) 
        { nombre = n;
         }
        public void setprecio(double p) 
        { precio = p; 
        }
    }
}