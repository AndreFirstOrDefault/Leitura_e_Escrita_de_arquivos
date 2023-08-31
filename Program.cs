using LeituraEscrita.Entities;

Produto p = new Produto();
int opcao = 0;
Leitor leitor = new Leitor();

do
{
    Console.WriteLine("Selecione uma opção abaixo.");
    Console.WriteLine("\n1 - Adicionar um produto");
    Console.WriteLine("2 - Remover um produto");
    Console.WriteLine("3 - Consultar um produto");
    Console.WriteLine("4 - Editar um produto");
    Console.WriteLine("5 - Listar todos os produtos");
    Console.WriteLine("6 - Acrescentar produto (existente)");
    Console.WriteLine("7 - Retirar produto");
    Console.WriteLine("0 - Sair\n\n");

    try
    {

        opcao = int.Parse(Console.ReadLine());

        switch (opcao)
        {
            case 1:
                p.AdicionarProduto();
                break;

            case 2:
                p.RemoverProduto();
                break;

            case 3:
                p.ConsultarProduto();
                break;

            case 4:
                p.EditarProduto();
                break;

            case 5:
                p.ListarTodosProdutos();
                break;
            case 6:
                p.AcrescentarProduto();
                break;
            case 7:
                p.RetirarProduto();
                break;
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Ops, algo deu errado!");
        p.LimparTela();
    }
    //}

} while (opcao != 0);
