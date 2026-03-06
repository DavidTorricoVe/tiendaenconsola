using Tiendaconsola;

inventario inv = new inventario();
carrito car = new carrito();

Tiendaconsola.Tiendaconsola p1 = new Tiendaconsola.Tiendaconsola("TEC01", "Teclado", 150.50);
Tiendaconsola.Tiendaconsola p2 = new Tiendaconsola.Tiendaconsola("MOU01", "Mouse", 80.00);
Tiendaconsola.Tiendaconsola p3 = new Tiendaconsola.Tiendaconsola("PAD01", "Mousepad", 35.00);

inv.agregarproducto(p1);
inv.agregarproducto(p2);
inv.agregarproducto(p3);

Console.WriteLine(" INVENTARIO ");
Console.WriteLine("Total en stock: " + inv.stockdeproductos());

car.agregaralcarrito(p1); 
car.agregaralcarrito(p2); 

Console.WriteLine("CARRITO");
Console.WriteLine("Cantidad de cosas: " + car.cantidaddeproductos());
Console.WriteLine("Total a pagar: Bs. " + car.mostrartotal());

Console.ReadLine();