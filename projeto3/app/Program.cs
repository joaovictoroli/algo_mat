using app.ClassesModelo;
using app.Interfaces;
using Bogus;
class Program
{
    public static void Main()
    {
        DadosServicos DadosServicos = new();
        //
        Seed1(DadosServicos);
        //
        bool rodando = true;
        while (rodando)
        {
            MenuInicialFuncional(DadosServicos);
        }
    }

    private static void MenuInicialFuncional(DadosServicos DadosServicos)
    {

        int option = EscreverMenuInicial();
        switch (option)
        {
            case 1:
                Escrever("Inserir ponto de entrega");
                Escrever("Nome: ");
                var nomePonto = LerString();
                int identificador = DadosServicos.RetornarProximoIdentificadorLocal();
                Local local = new Local { Identificador=identificador, Nome = nomePonto } ;
                DadosServicos.AdicionarLocal(local);
                break;
            case 2:
                Escrever("Inserir item de entrega");
                Escrever("Nome: ");
                string nomeItem = LerString();
                identificador = DadosServicos.RetornarProximoIdentificadorItemEntregas();
                ItemEntrega itemEntrega = new() { Identificador = identificador, Nome = nomeItem };
                DadosServicos.AdicionarItemEntrega(itemEntrega);
                break;
            case 3:
                Escrever("Inserir caminhão");
                Escrever("Placa: ");
                string placaCaminhao = LerString();
                Caminhao caminhao = new() { Identificador = DadosServicos.RetornarProximoIdentificadorCaminhoes(), Placa = placaCaminhao };
                DadosServicos.AdicionarCaminhao(caminhao);
                break;
            case 4:
                Escrever("Associar item a ponto de entrega");
                AssociarPontoAoItemEntrega(DadosServicos);
                break;
            case 5:
                Escrever("Associar ponto de entrega a caminhão");
                AssociarPontoAoCaminhao(DadosServicos);
                break;
            case 6:
                Escrever("Realizar entregas");
                DadosServicos.PrepararVinculosEVincular();
                DadosServicos.RealizarEntregas();
                break;
            case 9:
                ImprimirTodosTestes(DadosServicos);
                break;
            case 0:
                Escrever("Sair");
                break;
        }
    }
    private static int EscreverMenuInicial()
    {
        Escrever("[1] Inserir ponto de entrega;");
        Escrever("[2] Inserir item de entrega;");
        Escrever("[3] Inserir caminhão;");
        Escrever("[4] Associar item a ponto de entrega;");
        Escrever("[5] Associar ponto de entrega a caminhão;");
        Escrever("[6] Realizar entregas;");
        Escrever("[0] Sair.");
        return LerInteiro();
    }

    private static void Escrever(string conteudo)
    {
        Console.WriteLine(conteudo);
    }

    private static string LerString()
    {
        return Console.ReadLine()!;
    }
    private static int LerInteiro()
    {
        try
        {
            int option = Convert.ToInt32(Console.ReadLine());
            return option;
        }
        catch
        {
            Escrever("Somente inteiros.");
            return -1;
        }
    }
    private static void ImprimirTodos(DadosServicos servicos)
    {
        Escrever("Imprimir todos");
        Escrever("Items de Entrega:");
        foreach (var itemEntrega in servicos.ObterItensEntrega()) { Escrever(itemEntrega.ToString()); }
        Escrever("Locais:");
        foreach (var local in servicos.ObterLocais())
        {
            Escrever(local.ToString());
            foreach (ItemEntrega itemEntrega in local.ItensEntrega()) { Escrever(itemEntrega.ToString()); }
        }
        Escrever("Caminhões:");
        foreach (var caminhao in servicos.ObterCaminhoes()) { Escrever(caminhao.ToString()); }
    }

    private static void ImprimirTodosTestes(DadosServicos servicos)
    {
        Escrever("Imprimir todos");
        Escrever("Items de Entrega:");
        //foreach (var itemEntrega in servicos.ObterItensEntrega()) { Escrever(itemEntrega.ToString()); }
        Escrever("Locais:");
        foreach (var local in servicos.ObterLocais())
        {
            Escrever(local.ToString());
            foreach (var itemEntrega in local.ItensEntrega()) { Escrever(itemEntrega.ToString()); }

        }
        Escrever("Caminhões:");
        foreach (var caminhao in servicos.ObterCaminhoes()) { Escrever(caminhao.ToString()); }
    }

    private static void AssociarPontoAoItemEntrega(DadosServicos DadosServicos)
    {
        var itemsLista = DadosServicos.ObterItensEntrega();
        foreach (var item in itemsLista) { Escrever(item.ToString()); };
        Escrever("Escreva o numero do item que deseja associar: ");
        int option = LerInteiro();
        var locaisLista = DadosServicos.ObterLocais();
        Escrever("Escreva o numero do local que deseja associar: ");
        foreach (var local in locaisLista) { Escrever(local.ToString()); };
        int option2 = LerInteiro();
        DadosServicos.AssociarPontoAoItemDeEntrega(option, option2);
    }

    private static void AssociarPontoAoCaminhao(DadosServicos DadosServicos)
    {
        var locaisLista = DadosServicos.ObterLocais();
        Escrever("Escreva o numero do local que deseja associar: ");
        foreach (var local in locaisLista) { Escrever(local.ToString()); };
        int option = LerInteiro();
        var caminhaoLista = DadosServicos.ObterCaminhoes();
        foreach (var caminhao in caminhaoLista) { Escrever(caminhao.ToString()); };
        Escrever("Escreva o numero do caminhao que deseja associar: ");
        int option2 = LerInteiro();
        Escrever(DadosServicos.AssociarPontoAoCaminhao(option, option2));
    }

    private static void Seed1(DadosServicos DadosServicos)
    {
        var localFaker = new Faker<Local>()
        .RuleFor(l => l.Identificador, f => f.UniqueIndex + 1)
        .RuleFor(l => l.Nome, f => f.Address.City());

        var itemEntregaFaker = new Faker<ItemEntrega>()
            .RuleFor(i => i.Identificador, f => f.UniqueIndex + 1)
            .RuleFor(i => i.Nome, f => f.Commerce.ProductName());

        var caminhaoFaker = new Faker<Caminhao>()
            .RuleFor(c => c.Identificador, f => f.UniqueIndex + 1)
            .RuleFor(c => c.Placa, f => f.Vehicle.Vin());

        var locals = localFaker.Generate(4);
        foreach (var local in locals) DadosServicos.AdicionarLocal(local);

        var itemsEntrega = itemEntregaFaker.Generate(50);
        foreach (var itemEntrega in itemsEntrega) DadosServicos.AdicionarItemEntrega(itemEntrega);

        var caminhoes = caminhaoFaker.Generate(3);
        foreach (var caminhao in caminhoes) DadosServicos.AdicionarCaminhao(caminhao);

        for (int ci = 1; ci < 6; ci++) DadosServicos.AssociarPontoAoItemDeEntrega(1, ci);
        for (int ci = 6; ci < 11; ci++) DadosServicos.AssociarPontoAoItemDeEntrega(2, ci);
        for (int ci = 11; ci < 16; ci++) DadosServicos.AssociarPontoAoItemDeEntrega(3, ci);
        for (int ci = 16; ci < 30; ci++) DadosServicos.AssociarPontoAoItemDeEntrega(4, ci);
    }
}