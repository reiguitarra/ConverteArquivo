using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings;
namespace ConverteArquivo3
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
            string[] valid = new string[] {"", " ","PARATI","-", "Relação", "Cadastral", "Pág.", "Data","Ensino", "Médio", "Completo", "Incompleto",
                                           "Conta", "Modo", "Pagamento....:", "Tipo", "Trabalhando", "Estabilidade...:", "Superior", "Analfabeto",
                                           "Não", "Estável", "Banco", "Turno", "Trabalho.:", "Período", "Aposentadoria", 
                                            "Centro", "Nat.", "Despesa", "%", "Insalubridade...:", "Periculosidade..:", "Valor", "Suplementar.:"
                                          , "Estado", "Anuidades:", "Nº", "Anos", "Percentual", "Grau", "Expedição.:", "Ponto", "Embarque....:"
                                          , "Escala/Turma...:", "VTR........:", "Seguro", "1.....:", "2.....:", "Adiantamento......:", "Emite",
                                            "Cartão......:", "Inclusão.....:", "Dependente", "IR..:", "SF.....:", "Sindicalizado..:",
                                            "Opção.....:", "Salário:", "Recebe", "13º", "Ano", "Opção", "Categoria", "Sefip", "Consta", 
                                            "Recolheu", "no", "Optante", "Hora", "Sindicato......:", 
                                            "-------------------------------------------------------------------------------"
                                            };

            using (FileStream fs = new FileStream(text, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF7))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] d = sr.ReadLine().Split(' ');


                        if (d[0] != "")
                        {
                            linhaAtual++;
                            for (int i = 0; i < d.Length; i++)
                            {
                               
                                if (valid.Contains(d[i]))
                                {
                                }
                                else
                                {
                                    tex.Append(d[i] + ";");
                                    
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
                
                //for (int j = 0; j < separar.Length; j++)
                //{
                //    int posI = Array.IndexOf(separar, "Nome...........:");
                //    int posF = Array.IndexOf(separar, "Apelido........:");
                //    if (j > posI + 1 && j < posF)
                //    {
                //        tex.Append(separar[j] + " ");
                //    }
                //}
                string idEmpresa = separar[0];
                string idFilial = separar[Array.IndexOf(separar, "Filial.........:") + 1];
                string matricula = separar[3];
                string nome = RetornaRegistro(separar, arquivo.Count, Array.IndexOf(separar, "Nome...........:"), Array.IndexOf(separar, "Apelido........:"), 'n');
                string admissao = separar[Array.IndexOf(separar, "Admissão..:") + 1];
                string banco = separar[Array.IndexOf(separar, "Código......:") + 1];
                string agencia = separar[Array.IndexOf(separar, "Agência.....:") + 1];
                string cargo = RetornaRegistro(separar, arquivo.Count, Array.IndexOf(separar, "Cargo..........:"), Array.IndexOf(separar, "Bancária....:"), ' ');
                Console.WriteLine($"Emp: {idEmpresa}, Fil: {idFilial}, Matr: {matricula}, Func: {nome}, Admissão: {admissao}, Banco: {banco}," +
                    $"Ag: {agencia}, Cargo: {cargo}");
            }

            //gerando um commit;
            Console.ReadKey();
        }

        public static string RetornaRegistro(string[] separar, int arquivo, int posI, int posF, char c)
        {
            string nome = "";
            for (int i = 0; i < separar.Length; i++)
            {
                StringBuilder tex = new StringBuilder();

                if (c == 'n')
                {
                    for (int j = 0; j < arquivo; j++)
                    {
                        if (j > posI + 1 && j < posF)
                        {
                            tex.Append(separar[j] + " ");
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < arquivo; j++)
                    {
                        if (j > posI && j < posF)
                        {
                            tex.Append(separar[j] + " ");
                        }
                    }
                }
                

                nome = tex.ToString();
                break;
            }
                                    
            return nome;
        }


    }

    
}


