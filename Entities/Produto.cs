using LeituraEscrita.Entities;

public class Produto
{
    public Produto(int codigo, Categoria categoria, string nome, string descricao, string marca, double preco, int quantidade)
    {
        Codigo = codigo;
        Nome = nome;
        Descricao = descricao;
        Marca = marca;
        Preco = preco;
        Quantidade = quantidade;
    }

    public Produto()
    { }
    public int Codigo { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Marca { get; set; }
    public double Preco { get; set; }
    public int Quantidade { get; set; }
    List<Produto> listaProduto = new List<Produto>();
    public void AdicionarProduto()
    {
        try
        {
            Console.Clear();
            Console.Write("Digite o código do produto: ");
            int codigo = int.Parse(Console.ReadLine());
            VerificarSeExiste(codigo);
            Console.Write("Informe a categoria do produto: 1 - Informática, 2 - Smartphone, 3 - Acessórios: ");
            int categoria = int.Parse(Console.ReadLine());
            var categoriaProduto = Categoria.Informática;
            if (categoria == 1)
            {
                categoriaProduto = Categoria.Informática;
            }
            else if (categoria == 2)
            {
                categoriaProduto = Categoria.Smartphone;
            }
            else if (categoria == 3)
            {
                categoriaProduto = Categoria.Acessorios;
            }
            Console.Write("Digite o nome do produto:       ");
            string nome = Console.ReadLine();
            Console.Write("Digite a descrição do produto:  ");
            string descricao = Console.ReadLine();
            Console.Write("Digite a marca do produto:      ");
            string marca = Console.ReadLine();
            Console.Write("Digite o preço do produto:      ");
            double preco = double.Parse(Console.ReadLine());
            Console.Write("Digite a quantidade do produto: ");
            int quantidade = int.Parse(Console.ReadLine());

            Produto produto = new Produto(codigo, categoriaProduto, nome, descricao, marca, preco, quantidade);
            Gravador gravador = new Gravador();
            gravador.GravarArquivo(produto, categoria);
            listaProduto.Add(produto);
            Console.WriteLine("Produto adicionado com sucesso!");
        }
        catch (Exception)
        {
            Console.WriteLine("Ops, algo deu errado, o programa será encerrado em 3 segundos");
            Thread.Sleep(3000);
            Environment.Exit(0);
        }
        finally
        {
            LimparTela();
        }
    }

    public void RemoverProduto()
    {
        Console.Clear();
        try
        {
            Console.Write("Digite o código do produto: ");
            int codigo = int.Parse(Console.ReadLine());            
            if (VerificarSeExiste(codigo))
            {
                Console.Write("Informe a categoria do produto: 1 - Informática, 2 - Smartphone, 3 - Acessórios: ");
                int categoria = int.Parse(Console.ReadLine());
                foreach (var item in listaProduto)
                {
                    if (item.Codigo == codigo)
                    {
                        Gravador gravador = new Gravador();
                        gravador.ApagarArquivo(item, categoria);
                        listaProduto.Remove(item);
                        Console.WriteLine("Produto removido com sucesso!");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Produto não encontrado na lista.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ops, algo deu errado, o programa será encerrado em 3 segundos");
            Console.WriteLine(ex.Message);
            Thread.Sleep(3000);
            Environment.Exit(0);
        }

        finally
        {
            LimparTela();
        }

    }

    public void ConsultarProduto()
    {
        Console.Clear();
        try
        {
            Console.Write("Digite o código do produto: ");
            int codigo = int.Parse(Console.ReadLine());
            Console.Write("Qual a categoria do produto: 1 - Informática, 2 - Smartphone, 3 - Acessórios: ");
            string opcao = Console.ReadLine();
            string categoria;
            if(opcao == "1")
            {
                categoria = "Informatica";
            }
            else if(opcao == "2")
            {
                categoria = "Smartphone";
            }
            else if(opcao == "3")
            {
                categoria = "Acessorios";
            }
            else
            {
                throw new Exception();
            }
            Leitor leitor1= new Leitor();
            leitor1.LerArquivo(codigo, categoria);
        }
        catch (Exception)
        {
            Console.WriteLine("Produto não encontrado!");
            Thread.Sleep(2000);
        }

        finally
        {
            LimparTela();
        }

    }

    public void EditarProduto()
    {
        Console.Clear();
        try
        {
            Console.Write("Digite o código do produto: ");
            int codigo = int.Parse(Console.ReadLine());
            Console.Write("Qual a categoria do produto: 1 - Informática, 2 - Smartphone, 3 - Acessórios: ");
            int categoria = int.Parse(Console.ReadLine());
            if (VerificarSeExiste(codigo))
            {
                foreach (var item in listaProduto)
                {
                    if (item.Codigo == codigo)
                    {
                        var produto = item;
                        item.Codigo = codigo;
                        Console.WriteLine("O que você deseja editar? \n1 - Nome\n2 - Descrição\n3 - Marca\n4 - Preço\n0 - Sair.");
                        int opcao = int.Parse(Console.ReadLine());
                        switch (opcao)
                        {
                            case 1:
                                Console.Write("Digite o novo nome do produto: ");
                                string novoNome = Console.ReadLine();
                                item.Nome = novoNome;
                                break;
                            case 2:
                                Console.Write("Digite a nova descrição do produto: ");
                                string novaDescricao = Console.ReadLine();
                                item.Descricao = novaDescricao;
                                break;
                            case 3:
                                Console.Write("Digite a nova marca do produto: ");
                                string novaMarca = Console.ReadLine();
                                item.Marca = novaMarca;
                                break;
                            case 4:
                                Console.Write("Digite o novo preço do produto: ");
                                double novoPreco = double.Parse(Console.ReadLine());
                                item.Preco = novoPreco;
                                break;
                            case 0:
                                Console.Clear();
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Valor inválido!");
                                return;
                        }

                        Gravador gravador = new Gravador();
                        gravador.GravarArquivo(produto, categoria);

                    }
                }
            }
            else
            {
                Console.WriteLine("Produto não encontrado na lista.");
            }
        }
        catch (Exception)
        {
            LimparTela();
        }
    }

    public void ListarTodosProdutos()
    {
        Console.Clear();
        if (verificaListaVazia())
        {
            Console.WriteLine("A lista está vazia.");
        }
        foreach (var item in listaProduto)
        {
            Console.WriteLine(item.ToString());
        }
        LimparTela();
    }

    public void AcrescentarProduto()
    {
        Console.Clear();
        Console.Write("Acrescentar produto (existente)\nDigite o codigo do produto: ");
        int codigo = int.Parse(Console.ReadLine());
        if (VerificarSeExiste(codigo))
        {
            Console.Write("Qual a categoria do produto: 1 - Informática, 2 - Smartphone, 3 - Acessórios: ");
            int categoria = int.Parse(Console.ReadLine());
            Console.Write("Digite a quantidade que deseja acrescentar: ");
            int quantidade = int.Parse(Console.ReadLine());
            foreach (var item in listaProduto)
            {
                if (item.Codigo == codigo)
                {
                    item.Quantidade += quantidade;
                    Gravador gravador = new Gravador();
                    gravador.GravarArquivo(item,categoria);
                    Console.WriteLine($"Operação realizada com sucesso, quantidade atual: {item.Quantidade}");
                }
            }
        }
        else
        {
            Console.WriteLine("Não existe produto com esse código");
        }

        LimparTela();
    }

    public void RetirarProduto()
    {
        Console.Clear();
        Console.Write("Retirar produto\nDigite o codigo do produto: ");
        int codigo = int.Parse(Console.ReadLine());
        if (VerificarSeExiste(codigo))
        {
            Console.Write("Qual a categoria do produto: 1 - Informática, 2 - Smartphone, 3 - Acessórios: ");
            int categoria = int.Parse(Console.ReadLine());
            Console.Write("Digite a quantidade que deseja retirar: ");
            int quantidade = int.Parse(Console.ReadLine());
            foreach (var item in listaProduto)
            {
                if (item.Codigo == codigo)
                {
                    if (item.Quantidade >= quantidade)
                    {
                        item.Quantidade -= quantidade;
                        Gravador gravador = new Gravador();
                        gravador.GravarArquivo(item,categoria);
                        Console.WriteLine($"Operação realizada com sucesso, quantidade atual: {item.Quantidade}");
                    }
                    else
                    {
                        Console.WriteLine($"Quantidade indisponivel no momento, quantidade atual: {item.Quantidade}");
                    }

                }
            }
        }
        else
        {
            Console.WriteLine("Não existe produto com esse código");
        }
        LimparTela();
    }

    public bool VerificarSeExiste(int codigo)
    {
        foreach (var item in listaProduto)
        {
            if (item.Codigo == codigo)
            {
                return true;
            }

        }
        return false;
    }

    public bool verificaListaVazia()
    {
        Leitor leitor = new Leitor();
        if (listaProduto.Count == 0 )
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public void LimparTela()
    {
        Console.WriteLine("Clique em [enter] para continuar e selecionar uma nova opção");
        Console.ReadLine();
        Console.Clear();
    }

    public override string ToString()
    {
        return $"\nCódigo: {Codigo}\n" +
                $"Nome: {Nome}\n" +
                $"Descricao: {Descricao}\n" +
                $"Marca: {Marca}\n" +
                $"Preço: R$ {Preco:f2}\n" +
                $"Quantidade: {Quantidade}";
    }

}