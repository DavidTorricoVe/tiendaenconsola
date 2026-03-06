   namespace Tiendaconsola
    {
        public class Tiendaconsola
    {
        private string codigo;
        private string nombre;
        private double precio;
        public Tiendaconsola(string cod, string nom , double prec)
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
    public void setcodigo(string cod)
        { 
            
            codigo = cod;
        }
    public void setnombre(string nom)
        { 
            nombre = nom;
        }
    public void setprecio(double prec)  
        { 
            precio = prec;
        }
        
    }


    public class inventario
    {
        private Tiendaconsola[] vectordeproductos = new Tiendaconsola[100];
        private int contador= 0;

        public void agregarproducto(Tiendaconsola prod)
        {
            if (contador < 100)
            {
                vectordeproductos[contador] = prod;
                contador++;
            }
            else
            {
                Console.WriteLine("Inventario lleno");
            }
        }   
        public int stockdeproductos()
        {
            return contador;
        }        
    }
    public class carrito
    {
        private Tiendaconsola[] productos = new Tiendaconsola[100];
        private int cantidad = 0;

        public void agregaralcarrito(Tiendaconsola prod)
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
                suma = suma + productos[i].getprecio();
            }
            return suma;
        }

        public int cantidaddeproductos()
        {
            return cantidad;
        }
    }

    }