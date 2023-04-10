using ProyectoDemo.Controller;
using ProyectoDemo.Model;
using System.Diagnostics;

namespace View
{
    class view
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();

            while(true) 
            {
                Console.WriteLine("\n Bienvenido");
                Console.WriteLine("1. Proveedor ");
                Console.WriteLine("2. cliente \n");

                string opcion = Console.ReadLine();

                switch (opcion) 
                {
                    case "1":

                        Console.WriteLine("Bienvenido proveedor");
                        Console.WriteLine("1. Ingresar o modificar producto ");
                        Console.WriteLine("2. Mostrar productos existentes \n");

                        string opcionProvee = Console.ReadLine();

                        switch (opcionProvee) 
                        { 
                            case "1":
                                while (true)
                                {
                                    Console.WriteLine("Agregue el producto en el siguiente formato: nombre, precio, cantidad \n");

                                    string input_product = Console.ReadLine();

                                    string[] product_values = input_product.Split(',');

                                    try
                                    {
                                        Consumable product = new Consumable(
                                            product_values[0],
                                            Convert.ToDouble(product_values[1]),
                                            Convert.ToInt32(product_values[2])
                                        );

                                        bool resultado = controller.AddProduct(product);

                                        if (resultado)
                                        {
                                            Console.WriteLine("\n Producto agragado correctamente \n");
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n Producto modificado correctamente \n");
                                        }

                                        break;

                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("\n Ingrese un valor adecuado \n");
                                    }
                                    catch (IndexOutOfRangeException)
                                    {
                                        Console.WriteLine("\n Ingrese los 3 valores separados por comas \n");
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("\n Ocurrio un error, intentelo de nuevo... \n");
                                    }
                                }
                            break;

                            case "2":
                                Console.WriteLine(controller.listarProduct());
                            break;
                        }

                    break;
                        case "2":
                            Console.WriteLine("Bienvenido cliente \n");
                            Console.WriteLine(controller.listarProduct());
                            Console.WriteLine("\n Por favor escriba el nombre del producto a comprar \n");
                            string opcionCliente = Console.ReadLine();

                            Consumable enc = controller.validaConsumable(opcionCliente);
                            if(enc != null)
                            {
                                if(enc.Quantity_in_stock > 0)
                                {
                                    Console.WriteLine("\n Ingresa el valor con el que va a realizar el pago \n");
                                    controller.Pago = Console.ReadLine();

                                    Consumable pComprado = controller.vender(opcionCliente);

                                    if (pComprado == null)
                                    {
                                        Console.WriteLine("\n No se pudo hacer la compra, saldo insuficiente \n");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\n Su producto comprado es {0} y su devuelta es {1} \n", pComprado.Name, pComprado.Cambio);
                                        Console.WriteLine("Gracias por su compra \n");
                                    }
                                } else
                                {
                                    Console.WriteLine("\n El producto seleccionado no tiene stock \n");
                                }
                            } else
                            {
                                Console.WriteLine("\n No se encontro un producto con el nombre digitado \n");
                            }
                        break;
                }
            }
        }
    }
}