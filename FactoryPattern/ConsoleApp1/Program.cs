using FactoryPattern;

// Pedido de un producto físico
IPedido pedidoFisico = PedidoFactory.CrearPedido("Fisico");
pedidoFisico.Procesar(); // Se llama al método del objeto físico

Console.WriteLine("--------------------");

// Pedido de un producto digital
IPedido pedidoDigital = PedidoFactory.CrearPedido("Digital");
pedidoDigital.Procesar(); // Se llama al método del objeto digital

Console.WriteLine("--------------------");

// Pedido de un producto suscripcion
IPedido pedidoSuscripcion = PedidoFactory.CrearPedido("Suscripcion");
pedidoSuscripcion.Procesar(); // Se llama al método del objeto suscripcion

Console.WriteLine("--------------------");

// Pedido de un producto regalo
IPedido pedidoRegalo = PedidoFactory.CrearPedido("Regalo");
pedidoRegalo.Procesar(); // Se llama al método del objeto regalo