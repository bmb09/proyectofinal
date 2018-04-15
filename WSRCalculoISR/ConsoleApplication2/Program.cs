using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoISR
{

    class WsrTest001
    {
        public static int conteo = 0;
        public static int total = 0;
        public static string nombres;
        public static string apellido;
        public static double sueldoBruto;
        public static double cafp;
        public static double csfs;
        public static double sueldoNeto;
        public static double descuento;
        public static double isr;
        public static double cooperativa;

        public static string[] _nombres= new string[100];
        public static string[] _apellido= new string[100];
        public static double[] _sueldoBruto= new double[100];
        public static double[] _cafp= new double[100];
        public static double[] _csfs= new double[100];
        public static double[] _sueldoNeto= new double[100];
        public static double[] _descuento= new double[100];
        public static double[] _isr= new double[100];
        public static double[] _cooperativa= new double[100];

      
        static void encabezado()
        {
            Console.Clear();
            Console.WriteLine("*********** PROGRAMA PARA CALCULAR DESCUENTOS A SUELDOS  *************");
            Console.WriteLine("*************************** BERNADO MORENO          13-MISM-1-036 ***************************");
            Console.WriteLine("*************************** ANTHONY ENCARNACION      15-EISN-1-253 ***************************");
            Console.WriteLine("*************************** ARIEL ROMERO            14-EISN-1-215 ***************************");

            Console.WriteLine("***********************  Ingresar Datos **********************");

            Console.WriteLine();

        }
        static void continuamos()
        {
            string continuar;
            Console.WriteLine();
            Console.Write("Desea ingresar nuevos datos (S/N): ");
            continuar = Console.ReadLine();



         _nombres[conteo]=nombres;
         _apellido[conteo]=apellido;
         _sueldoBruto[conteo]=sueldoBruto;
         _cafp[conteo]=cafp;
         _csfs[conteo]=csfs;
         _sueldoNeto[conteo]=sueldoNeto;
         _descuento[conteo]=descuento;
         _isr[conteo]=isr;
         _cooperativa[conteo]=cooperativa;



            if ((continuar == "S" || continuar == "s"))
            {
                conteo = conteo + 1;
                CapturarDatos();
            }
            else if ((continuar == "N" || continuar == "n"))
            {
                imprimir();
                Console.WriteLine("*********** PROGRAMA PARA CALCULAR DESCUENTOS A SUELDOS  *************");
                Console.WriteLine("***********    HEMOS TERMINADO  *************");
                Console.ReadLine();

            }
            else
            {
                Console.WriteLine(" Ingresar S/N Solamente......Trate de Nuevo....WSR ");
                continuamos();

            }

        }
         public static void imprimir()
        {
            Console.Clear();
            encabezado();

            for (int i = 0; i < conteo+1; i++)
            {
                Console.WriteLine("Datos Ingresados Empleado No. {0}", i.ToString());
                Console.WriteLine();
                Console.WriteLine("Nombres: {0} {1} ", _nombres[i], _apellido[i]);
                Console.WriteLine("Sueldo Bruto RD$ {0}", _sueldoBruto[i].ToString());
                Console.WriteLine();

                Console.WriteLine("Descuentos Calculados...");
                //Console.WriteLine();

                Console.WriteLine("Cooperativa Valorado en  {0} ", _cooperativa[i].ToString());
                Console.WriteLine("El SFS es   Valorado en  {0} ", _csfs[i].ToString());
                Console.WriteLine("El Afp es   Valorado en  {0} ", _cafp[i].ToString());
                Console.WriteLine("El Isr es                {0} ", _isr[i].ToString());

                Console.WriteLine("El Total Descuentos es {0} ", _descuento[i].ToString());
                Console.WriteLine("Sueldo Neto RD$ {0}", _sueldoNeto[i].ToString());
                Console.WriteLine();
            }
        }
        static void CapturarDatos()
        {
            // Captura de los datos


            encabezado();
            try
            {
                Console.Write("Ingrese sus nombres: ");
                nombres = Console.ReadLine();

                Console.Write("Ingrese sus apellidos: ");
                apellido = Console.ReadLine();

                Console.Write("Ingrese Sueldo: ");
                sueldoBruto = Convert.ToDouble(Console.ReadLine());


                //double[] sueldon = sueldoBruto;
                //double sueldoBruto = sueldoBruto;
                CalcularDatos(sueldoBruto);


            }
            catch
            {
                Console.WriteLine(" Error en Dato Suministrado......Trate de Nuevo....WSR .... Presione cualquier tecla..");
                Console.ReadKey();
                CapturarDatos();
            }

        }
        public static void CalcularDatos(double Sueldo)
        {
            isr = 0;
            double afp = 2.72;
            double sfs = 3.01;
            double cop = 2;

            double sueldoISR ;
            double isr25 = 0;
            double isr15 = 0;
            double isr20 = 0;

            //cooperativa = 50;

            double sisr25 = 833171.01;
            double sisr15 = 399923.01;
            double sisr20 = 599884.01;


            //double sfs = 3.01;
            //double cooperativa = 50;

            // Calculos
            // Calculos de sueldo neto

             cafp  = (afp / 100) * Sueldo;
             csfs = (sfs / 100) * Sueldo;
            cooperativa = (cop / 100) * Sueldo;

            sueldoISR = (Sueldo - cafp - csfs) * 12;
            sueldoISR = Sueldo * 12;


            if (sueldoISR > sisr15)
            {
                if (sueldoISR > sisr25)
                {
                    isr25 = (sueldoISR - sisr25);

                    isr25 = isr25 * 0.25;
                    sueldoISR = sueldoISR - (sueldoISR - sisr25);
                    isr = isr + isr25 / 12;

                }
                if (sueldoISR <= sisr25 && sueldoISR > sisr20)
                {
                    isr20 = (sueldoISR - sisr20) * (0.20);
                    isr20 = isr20 / 12;
                    sueldoISR = sueldoISR - (sueldoISR - sisr20);
                    isr = isr + isr20;

                }
                if (sueldoISR <= sisr20 && sueldoISR > sisr15)
                {
                    isr15 = (sueldoISR - sisr15) * 0.15;
                    isr15 = isr15 / 12;
                    isr = isr + isr15;

                    sueldoISR = sueldoISR - (sueldoISR - sisr15);
                }
            }



            descuento = isr + cafp + csfs + cooperativa;
            sueldoNeto = Sueldo - descuento;


            continuamos();
        }
                
        static void Main(string[] args)
        {
            CapturarDatos();




        }
    }
}
