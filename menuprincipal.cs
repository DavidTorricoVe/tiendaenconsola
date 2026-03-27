namespace Tiendaconsola
{
    public class menuprincipal
    {
        private int numerodecompra = 1;
        private gestorusuarios gestor = new gestorusuarios();
        private inventario inv = new inventario();
        private carrito car = new carrito();
        private presentacion vista = new presentacion();
        private usuario usuarioactual = null;

        public menuprincipal()
        {
            inv.agregarproducto(new producto("TEC01", "Teclado Mecanico", 150.50));
            inv.agregarproducto(new producto("MOU02", "Mouse Gamer", 85.00));
            inv.agregarproducto(new producto("MON03", "Monitor 24 pulgadas", 1200.00));
            inv.agregarproducto(new producto("AUR04", "Auriculares Inalambricos", 350.00));
        }

        public void iniciar()
        {
            while (true)
            {
                pantallalogin();
                if (usuarioactual.getrol().getnombre() == "Administrador") 
                { 
                    menuadmin(); 
                }
                else 
                { 
                    menucliente(); 
                }
            }
        }

        private void pantallalogin()
        {
            usuarioactual = null;
            while (usuarioactual == null)
            {
                Console.WriteLine("\n LOGIN ");
                Console.Write("Usuario: ");
                string usr = Console.ReadLine();
                Console.Write("Password: ");
                string pwd = Console.ReadLine();
                usuarioactual = gestor.login(usr, pwd);

                if (usuarioactual == null) 
                {
                    Console.WriteLine("Error de credenciales.");
                }
            }
            Console.WriteLine("\n¡Bienvenido " + usuarioactual.getusername() + "!");
        }

        private void menuadmin()
        {
            bool sesion = true;
            while (sesion)
            {
                Console.WriteLine(" PANEL ADMIN");
                Console.WriteLine("1. Listar productos");
                Console.WriteLine("2. Agregar producto");
                Console.WriteLine("3. Actualizar producto");
                Console.WriteLine("4. Eliminar producto");
                Console.WriteLine("5. Listar usuarios");
                Console.WriteLine("6. Agregar usuario");
                Console.WriteLine("7. Actualizar usuario");
                Console.WriteLine("8. Eliminar usuario");
                Console.WriteLine("9. Cerrar Sesion (Volver al login)");
                Console.WriteLine("0. Cerrar Tienda (Salir de la app)");
                Console.Write("Opcion: ");
                string op = Console.ReadLine();

                if (op == "1") vista.mostrarstock(inv);
                else if (op == "2") crearproducto();
                else if (op == "3") modproducto();
                else if (op == "4") delproducto();
                else if (op == "5") listarusers();
                else if (op == "6") crearuser();
                else if (op == "7") moduser();
                else if (op == "8") deluser();
                else if (op == "9") sesion = false;
                else if (op == "0") Environment.Exit(0);
            }
        }

        private void menucliente()
        {
            bool sesion = true;
            while (sesion)
            {
                Console.WriteLine(" TIENDA LACCANAZO");
                Console.WriteLine("1. Ver productos disponibles");
                Console.WriteLine("2. Agregar al carrito (Comprar)");
                Console.WriteLine("3. Ver mi carrito");
                Console.WriteLine("4. Pagar y finalizar compra");
                Console.WriteLine("9. Cerrar Sesion (Volver al login)");
                Console.WriteLine("0. Cerrar Tienda (Salir de la app)");
                Console.Write("Opcion: ");
                string op = Console.ReadLine();

                if (op == "1") vista.mostrarstock(inv);
                else if (op == "2") comprar();
                else if (op == "3") vista.mostrarcompra(car);
                else if (op == "4") pagar();
                else if (op == "9") sesion = false;
                else if (op == "0") Environment.Exit(0);
            }
        }

        private void comprar()
        {
            Console.Write("Ingrese el numero del producto a comprar: ");
            int pos = Convert.ToInt32(Console.ReadLine());
            
            if(pos >= 0 && pos < inv.stockdeproductos()) 
            {
                car.agregaralcarrito(inv.getproducto(pos));
                Console.WriteLine("Agregado al carrito.");
            } 
            else 
            { 
                Console.WriteLine("Indice invalido."); 
            }
        }
    private void pagar()
        {
            if (car.cantidaddeproductos() == 0)
            {
                Console.WriteLine("El carrito esta vacio.");
                return;
            }
            
            compra nuevacompra = new compra(numerodecompra, usuarioactual, car);
            Console.WriteLine($"Compra realizada con exito. Total pagado: ${nuevacompra.gettotal()}");
            
            car.vaciar();
            numerodecompra++;
        }
        private void crearproducto() 
        {
            Console.Write("Codigo: "); 
            string cod = Console.ReadLine();
            Console.Write("Nombre: "); 
            string nom = Console.ReadLine();
            Console.Write("Precio: "); 
            double prec = Convert.ToDouble(Console.ReadLine());
            inv.agregarproducto(new producto(cod, nom, prec));
            Console.WriteLine("Producto agregado.");
        }

        private void modproducto() 
        {
            Console.Write("Codigo del producto a modificar: "); 
            string cod = Console.ReadLine();
            Console.Write("Nuevo Nombre: "); 
            string nom = Console.ReadLine();
            Console.Write("Nuevo Precio: "); 
            double prec = Convert.ToDouble(Console.ReadLine());
            
            if(inv.actualizarproducto(cod, nom, prec)) 
            {
                Console.WriteLine("Actualizado.");
            }
            else 
            {
                Console.WriteLine("No encontrado.");
            }
        }

        private void delproducto() 
        {
            Console.Write("Codigo a eliminar: "); 
            string cod = Console.ReadLine();
            
            if(inv.eliminarproducto(cod)) 
            {
                Console.WriteLine("Eliminado.");
            }
            else 
            {
                Console.WriteLine("No encontrado.");
            }
        }

        private void listarusers() 
        {
            Console.WriteLine("USUARIOS");
            for(int i = 0; i < gestor.cantidadusuarios(); i++) 
            {
                Console.WriteLine($"- {gestor.getusuario(i).getusername()} ({gestor.getusuario(i).getrol().getnombre()})");
            }
        }

        private void crearuser() 
        {
            Console.Write("Nuevo username: "); 
            string u = Console.ReadLine();
            Console.Write("Password: "); 
            string p = Console.ReadLine();
            Console.Write("Rol (Administrador o Cliente): "); 
            string r = Console.ReadLine();
            gestor.agregarusuario(new usuario(u, p, new rol(r)));
            Console.WriteLine("Usuario creado.");
        }

        private void moduser() 
        {
            Console.Write("Username a modificar: "); 
            string u = Console.ReadLine();
            Console.Write("Nueva Password: "); 
            string p = Console.ReadLine();
            
            if(gestor.actualizarusuario(u, p)) 
            {
                Console.WriteLine("Actualizado.");
            }
            else 
            {
                Console.WriteLine("No encontrado.");
            }
        }

        private void deluser() 
        {
            Console.Write("Username a eliminar: "); 
            string u = Console.ReadLine();
            
            if(gestor.eliminarusuario(u)) 
            {
                Console.WriteLine("Eliminado.");
            }
            else 
            {
                Console.WriteLine("No encontrado.");
            }
        }
    }
}