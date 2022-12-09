using System;
using System.IO;
using System.Net;

namespace AplicatieTXT
{
    class Program
    {
        static void Main(String[] args)
        {
            string? fileName = "";
            try
            {
                if (args?.Length <= 0)
                {
                    Console.WriteLine(" Descriere:  \n");
                    Console.WriteLine("\tCitirea unui fisier text si afisarea numarului de linii.\n");
                    Console.WriteLine(" Sintaxa:\n");
                    Console.WriteLine("\tAplicatieTXT fisier     fisier citit\n");
                    Console.WriteLine(" Introduceti adresa fisierului: \n");
                    fileName = Console.ReadLine();
                }
                else
                {
                    fileName = args[0];
                }
                var numarLinii = 0;
                using (var fstream = File.OpenText(@$"{fileName}"))
                {
                    while (!fstream.EndOfStream)
                    {
                        string? line = fstream.ReadLine();
                        // Console.WriteLine(line); --> afiseaza toate liniile din fisierul txt
                        if (!string.IsNullOrEmpty(line))
                        {
                            numarLinii++;
                        }
                    }
                }
                Console.WriteLine($"numar linii: {numarLinii}");
            }
            catch (DirectoryNotFoundException de)
            {
                Console.WriteLine("This directory does not exists. Please insert a real directory:");
                // Console.WriteLine(de.Message);
            }
            catch (FileNotFoundException fe)
            {
                Console.WriteLine("!The file is not found!");
                // Console.WriteLine(fe.Message);
            }
            catch (IndexOutOfRangeException ie)
            {
                Console.WriteLine("!Invalid index for the array!");
                // Console.WriteLine(ie.Message);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine("!Empty path name!");
                // Console.WriteLine(ae.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}