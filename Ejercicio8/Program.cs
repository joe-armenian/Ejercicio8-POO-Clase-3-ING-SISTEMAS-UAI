using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ejercicio8
{
    public class Program
    {
        static void Main(string[] args)
        {
            string condicionAgregarC, nombre, apellido, nombreElectro, colorElectro;

            int cantidadClientes, cuenta;

            double precioElectro, pesoElectro;

            char consumoElectro;
           

            Console.WriteLine("Estimado Cliente/a..\n\n¡Bienvenido a Electro-UAI!..\n");
            do
            {
                Console.Write("Si desea agregar clientes ingrese 1,de lo contrario ingrese 2:");
                condicionAgregarC=Console.ReadLine();

                if (condicionAgregarC!="1" && condicionAgregarC!="2")
                {
                    Console.WriteLine("\nHubo un error en el ingreso de datos.¡Por favor intente nuevamente!.\n");
                    continue;
                }
              
                if (condicionAgregarC == "1")
                {
                    do
                    {
                        Console.Write("\nIngrese la cantidad de clientes:");
                        string lineaClientes = Console.ReadLine();

                        if (!VerificarNumero(lineaClientes)) //uso las expresiones regulares y con el do while y continue vuelvo a preguntar.
                        {
                            Console.WriteLine("\nHubo un error en el ingreso de datos.¡Por favor ingrese una cantidad valida de clientes!.\n");
                            continue;
                        }
                        else
                        {
                            cantidadClientes = Convert.ToInt32(lineaClientes); //como instancie antes, puedo convertir a entero en caso de que sea correcto.
                        }
                        break;
                    } while (true);

                    Cliente[] clientes=new Cliente[cantidadClientes]; //creo el vector para los clientes.

                    Electrodomesticos[] electrodomesticos=new Electrodomesticos[cantidadClientes]; //el mismo me sirve para los electodomesticos.

                   for (int i=0;i<cantidadClientes;i++) 
                    {
                        do //vuelvo a utilizar la estructura do while para validar
                        {
                            Console.Write($"\nIngrese el nombre del cliente {i+1}:");
                            string lineaNombre = Console.ReadLine();
                            Console.Write($"\nIngrese el apellido del cliente {i + 1}:");
                            string lineaApellido = Console.ReadLine();
                            Console.Write($"\nIngrese el numero de cuenta del cliente {i + 1}:");
                            string lineaCuenta = Console.ReadLine();

                            if (!VerificarLetra(lineaNombre) || !VerificarLetra(lineaApellido) || !VerificarNumero(lineaCuenta)) //uso nuevamente para validar las exp regulares.
                            {
                                Console.WriteLine($"\nHubo un error en el ingreso de datos para el cliente {i+1}. ¡Por favor intente nuevamente!.");
                                continue;
                            }
                            else
                            {
                                nombre = lineaNombre; apellido = lineaApellido; cuenta = Convert.ToInt32(lineaCuenta);
                            }
                            break;
                        } while (true);

                        clientes[i] = new Cliente(nombre, apellido, cuenta); //asigno los primeros datos al objeto cliente. 

                        do
                        {
                            Console.WriteLine($"\n\nEstimado Cliente {clientes[i].Nombre}... ¡Por favor!...Leer atentamente.");
                            Console.WriteLine("\nTanto el peso como el precio del producto, puede ser cargado con sus decimales utilizando ,'coma'.");
                            Console.WriteLine("\nLos colores disponibles son: Rojo,blanco,azul,gris y negro.\nEn caso de no haber el seleccionado disponible u erroneo, se establecera por defecto el color Azul.");
                            Console.WriteLine("\nLos consumos permitidos van desde A hasta F, consulte el precio en la cartilla.\nEn caso de no haber seleccionado un consumo correcto, se establecera por defecto el A.");
                            Console.WriteLine("\n¡Gracias!");
                            //para los double utilice las exp regulares que les puse "0,0" a "9," mientras lo ponga con "," no hay problema, si lo pone con "." punto si. Tengo que trabajar eso.

                            Console.Write($"\nIngrese el nombre del electrodomestico adquirido para el cliente {clientes[i].Nombre} {clientes[i].Apellido}:");
                            string lineaNombreElectro = Console.ReadLine();
                            Console.Write($"\nIngrese el precio del electrodomestico adquirido para el cliente {clientes[i].Nombre} {clientes[i].Apellido}:");
                            string lineaPrecioElectro = Console.ReadLine();
                            Console.Write($"\nIngrese el color del electrodomestico adquirido para el cliente {clientes[i].Nombre} {clientes[i].Apellido}:");
                            string lineaColorElectro = Console.ReadLine();
                            Console.Write($"\nIngrese el peso del electrodomestico adquirido para el cliente {clientes[i].Nombre} {clientes[i].Apellido}:");
                            string lineaPesoElectro = Console.ReadLine();
                            Console.Write($"\nIngrese el consumo del electrodomestico adquirido para el cliente {clientes[i].Nombre} {clientes[i].Apellido}:");
                            string lineaConsumoElectro = Console.ReadLine();

                            if (!VerificarNombreElectro(lineaNombreElectro) || !VerificarNumeroDouble(lineaPrecioElectro) || !VerificarLetra(lineaColorElectro) || !VerificarNumeroDouble(lineaPesoElectro) || !VerificarLetra(lineaConsumoElectro)) //otra vez, vuelvo a validar.
                            {
                                Console.WriteLine("\nError en el formato de ingreso para los datos. ¡Por favor intente nuevamente!.\n");
                                continue;
                            }
                            else
                            {
                                nombreElectro = lineaNombreElectro; precioElectro = Convert.ToDouble(lineaPrecioElectro); colorElectro = lineaColorElectro.ToUpper(); pesoElectro = Convert.ToDouble(lineaPesoElectro); consumoElectro = lineaConsumoElectro[0];
                            }
                            //si es correcto entonces, establezco los valores y convierto a su tipo correcto los necesarios para el OBJETO electrodomestico. 
                            
                            electrodomesticos[i] = new Electrodomesticos(nombreElectro,precioElectro,colorElectro,char.ToUpper(consumoElectro),pesoElectro); //el de char lo convierto a mayuscula desed aca, xq arriba me daba error, sin embargo con el string no tuve problemas.
                            
                            electrodomesticos[i].ComprobarConsumoEnergetico(consumoElectro); //llamo a los metodos que pedia la consigna.
                            electrodomesticos[i].ComprobarColor(colorElectro);

                            break;
                        } while (true);

                    
                    }
                    
                    for (int i=0;i<cantidadClientes;i++) //muestro los datos.
                    {

                        Console.WriteLine($"\n¡Electro-UAI informa los datos de compra  para el cliente {i+1}");


                        Console.WriteLine($"\n\nNombre:{clientes[i].Nombre}\n\nApellido:{clientes[i].Apellido}\n\nCuenta:{clientes[i].NroCuenta}\n\nElectrodomestico adquirido:{electrodomesticos[i].Nombre}\n\nPrecio Inicial:{electrodomesticos[i].Precio}\n\nColor:{electrodomesticos[i].Color}\n\nPeso:{electrodomesticos[i].Peso}\n\nConsumo:{electrodomesticos[i].Consumo}\n\nPrecio Final:{electrodomesticos[i].PrecioFinal()}");
                    }

                
                }


                Console.WriteLine("\n¡Gracias por utilizar nuestros servicios!(Presione enter para volver a cargar datos)."); 
               //cuando termina y muestra todo los datos, si empieza de cero se borra todo y vuelve a empezar.
               // podria implementar lo de listas y archivos para dejar un registro

                condicionAgregarC = Console.ReadLine();//y aca vuelve a empezar.
            } while (true);

        }
        public static bool VerificarNombreElectro(string linea)
        {
            return Regex.IsMatch(linea, @"^[a-zA-Z ]+$");  //Es muy parecido al de letra, pero el agrege el espacio x si ingresaba "Aire Acondicionado" y no queria tener problemas con los nombres o apellidos si lo ingresan con un espacio no quedaba muy bien.
        }
        public static bool VerificarLetra(string linea)
        {
            return Regex.IsMatch(linea, @"^[a-zA-Z]+$");
        }
        public static bool VerificarNumero(string linea)
        {
            return Regex.IsMatch(linea, @"^[0-9]+$");
        }
        public static bool VerificarNumeroDouble(string linea)
        {
            return Regex.IsMatch(linea, @"^[0,0-9,9]+$");
        }
    }
}
