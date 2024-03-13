using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ejercicio8
{
    public class Electrodomesticos
    {
        public string Nombre { get; set; }
        public double Precio { get; set; } 

        public string Color { get; set; }

        public char Consumo { get; set; } //A-F
        
        public double Peso { get; set; }

        public char ConsumoPorDefecto = 'A';

        public string ColorPorDefecto = "AZUL";

        public Electrodomesticos() { } //Creo el constructor vacio y lo inicializo. 
        public Electrodomesticos(string nombre,double precio,string color,char consumo,double peso) //Constructor parametrizado 
        {
            Nombre = nombre;
            Precio = precio;
            Color = color;
            Consumo = consumo;
            Peso = peso;
        }
        public void ComprobarConsumoEnergetico(char letra) //El metodo para comprobar el consumo, si es diferente a la funcion booleana de las expresiones regulares, entonces hay error.
        {
            if (!ConsumoLetra(Consumo))
            {
                Consumo = ConsumoPorDefecto;

                Console.WriteLine("\nConsumo cargado fuera de predeterminados (A-F), se establecera por defecto el consumo categoria A.");
            }
            else
            {
                Console.WriteLine("\nConsumo cargado correctamente");
            }
        }

        public void ComprobarColor(string color) //Lo mismo en cuanto a las expreiones regulares pero con el color.
        {
            if (!VerificarColor(color))
            {
                Color = ColorPorDefecto;

                Console.WriteLine("\nColor cargado fuera de predeterminados (Blanco-Negro-Rojo-Azul-Gris), se estableció por defecto el color Azul.\n");
            }
            else
            {
                Console.WriteLine("\nColor cargado correctamente\n");
            }
        }

        public double PrecioFinal()
        {
            int ExtraConsumo=0,extraPeso=0;

            switch (Consumo)
            {
                case 'A':
                    ExtraConsumo = 1000;
                    break;
                case 'B':
                    ExtraConsumo = 800;
                    break;
                case 'C':
                    ExtraConsumo = 600;
                    break;
                case 'D':
                    ExtraConsumo = 500;
                    break;
                case 'E':
                    ExtraConsumo = 400;
                    break;
                case 'F':
                    ExtraConsumo = 200;
                    break;
            }



            if (Peso >= 0 && Peso <= 19)
            {
                extraPeso = 20;
            }
            else if (Peso >= 20 && Peso <=49)
            {
                extraPeso = 60;
            }
            else if (Peso >= 50 && Peso <= 79)
            {
                extraPeso = 90;
            }
            else 
            {
                extraPeso = 120;
            
            }

            return Precio + extraPeso + ExtraConsumo;

        }


        public static bool VerificarColor(string linea)
        {
            return Regex.IsMatch(linea,@"^(BLANCO|NEGRO|ROJO|AZUL|GRIS)$"); //Es la primera vez que uso una expresion regular de este tipo, me daba error si utilizaba 
            //las que venia haciendo,como la de abajo. Investigue y aprendi que cuando le pongo +$,le estoy pasando un intervalo/rango de caracteres de x-y. 

            //Y utilizando el | (pipe) y sin el "+" indica que la cadena debe coindicir con una de las palabras de la lista. 
        }


        public static bool ConsumoLetra(char linea)
        {
            return Regex.IsMatch(linea.ToString(),@"^[A-F]+$"); //estas son las misma que venia utilizando en los parciales.
        }


         
       }
    }

