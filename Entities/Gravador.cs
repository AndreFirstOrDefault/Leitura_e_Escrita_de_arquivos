namespace LeituraEscrita.Entities
{
    public class Gravador : Produto
    {
        public Gravador()
        { }

        public Gravador(int categoria)
        {

        }
        public string caminho;

        public void GravarArquivo(Produto produto, int categoria)
        {
            try
            {
                if (categoria == 1)
                {
                    caminho += @"D:\ArquivoProduto\Informatica\";
                }
                else if (categoria == 2)
                {
                    caminho += @"D:\ArquivoProduto\Smartphone\";
                }
                else if (categoria == 3)
                {
                    caminho += @"D:\ArquivoProduto\Acessorios\";
                }
                
                Directory.CreateDirectory(caminho);

                using var file = File.CreateText(caminho + $@"{produto.Codigo}.txt");
                file.WriteLine(produto.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                
            }
        }        

        public void ApagarArquivo(Produto produto, int categoria)
        {
            try
            {
               if (categoria == 1)
                {
                    caminho += @"D:\ArquivoProduto\Informatica\";
                }
                else if (categoria == 2)
                {
                    caminho += @"D:\ArquivoProduto\Smartphone\";
                }
                else if (categoria == 3)
                {
                    caminho += @"D:\ArquivoProduto\Acessorios\";
                }
                File.Delete(caminho + $@"{produto.Codigo}.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}