using System.IO;
using Microsoft.VisualBasic;

namespace LeituraEscrita.Entities
{
    public class Leitor : Produto
    {
        List<Produto> lista = new List<Produto>();        
        public void LerArquivo(int codigo, string categoria)
        {
            using var file = new StreamReader($@"D:\ArquivoProduto\{categoria}\{codigo}.txt");
            string line;
            while((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
            file.Close();
        }
    
        }
        
}

