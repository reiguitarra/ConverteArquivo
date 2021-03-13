using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CoverteArquivo
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Importe arquivos");
            Console.WriteLine();
            StringBuilder tex = new StringBuilder();
            int linhaAtual = 0;
            List<string> arquivo = new List<string>();
           // List<string> arqDados = new List<string>();

            string text = @"C:\Users\reinaldo.almeida.HMB\Documents\Rei Querys\Documentos\ArquivosTransforme\Registro_Geral.txt";

            using (FileStream fs = new FileStream(text, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] d = sr.ReadLine().Split(' ');


                        if (d[0] != "")
                        {
                            linhaAtual++;
                            for (int i = 0; i < d.Length; i++)
                            {
                                if (d[i] == "" || d[i] == "  ")
                                {
                                    if (linhaAtual == 2 && i == 15)
                                    {
                                        tex.Append(";");
                                    }
                                }
                                else
                                {
                                    if (linhaAtual == 2 && i > 3 && i < 20)
                                    {
                                       
                                        tex.Append(d[i] + " ");
                                       
                                    }
                                    else
                                    {
                                        tex.Append(d[i] + ";");
                                    }
                                    

                                }
                            }
                            
                           
                            if (linhaAtual == 34)
                            {
                                arquivo.Add(tex.ToString());
                                tex.Clear();
                                linhaAtual = 0;
                            }
                        }
                       

                    }
                }
            }

            for (int i = 0; i < arquivo.Count; i++)
            {
                string[] separar = arquivo[i].Split(';');
                string[] nomeMat = separar[8].Split(' ');
                string idEmpresa = separar[0];
                string idFilial = separar[53];
                string matricula = nomeMat[0];
                for (int j = 1; j < nomeMat.Length; j++)
                {
                    tex.Append(nomeMat[j] + " ");
                }
                string nome = tex.ToString();
                tex.Clear();
                string admissao = separar[12];
                Console.WriteLine($"Empresa: {idEmpresa}, Filial: {idFilial}, Matricula: {matricula}, Funcionário: {nome}, Admissão: {admissao}");
            }
           

            Console.ReadKey();
        }

        
    }
}
