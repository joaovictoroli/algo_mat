using app.ClassesModelo;
using app.Interfaces;
class Program
{
    public static void Main()
    {
        DadosServicos DadosServicos = new();
        //
        GerarDados(DadosServicos);
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
                Local local = new() { Identificador = identificador, Nome = nomePonto };
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
            foreach (var itemEntrega in local.ItensEntrega) { Escrever(itemEntrega.ToString()); }

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
            //foreach (var itemEntrega in local.ItensEntrega) { Escrever(itemEntrega.ToString()); }

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

    private static void GerarDados(DadosServicos DadosServicos)
    {
        List<Local> listLocal = new()
        {
            new Local { Identificador = 1, Nome = "Salvador" },
            new Local { Identificador = 2, Nome = "Jakarta" },
            new Local { Identificador = 3, Nome = "Nova Iorque" },
            new Local { Identificador = 4, Nome = "Londres" },
            new Local { Identificador = 5, Nome = "Brasilia" },
            new Local { Identificador = 6, Nome = "Goias" },
            new Local { Identificador = 7, Nome = "Curitiba" },
            new Local { Identificador = 8, Nome = "Parana" },
        };
        foreach (var local in listLocal) { DadosServicos.AdicionarLocal(local); }

        List<ItemEntrega> listItemEntrega = new()
        {
            new ItemEntrega { Identificador = 1, Nome = "NVMe 2tb" },
            new ItemEntrega { Identificador = 2, Nome = "Monitor 27 polegadas" },
            new ItemEntrega { Identificador = 3, Nome = "Teclado mecânico" },
            new ItemEntrega { Identificador = 4, Nome = "Mouse sem fio" },
            new ItemEntrega { Identificador = 5, Nome = "Cadeira ergonômica" },
            new ItemEntrega { Identificador = 6, Nome = "Fone de ouvido Bluetooth" },
            new ItemEntrega { Identificador = 7, Nome = "Impressora a laser" },
            new ItemEntrega { Identificador = 8, Nome = "Webcam HD" },
            new ItemEntrega { Identificador = 9, Nome = "Tablet Android" },
            new ItemEntrega { Identificador = 10, Nome = "Console de jogos" },
            new ItemEntrega { Identificador = 11, Nome = "Smartphone Android" },
            new ItemEntrega { Identificador = 12, Nome = "Fogão a gás" },
            new ItemEntrega { Identificador = 13, Nome = "Geladeira duplex" },
            new ItemEntrega { Identificador = 14, Nome = "Máquina de lavar roupa" },
            new ItemEntrega { Identificador = 15, Nome = "Aspirador de pó" },
            new ItemEntrega { Identificador = 16, Nome = "Liquidificador" },
            new ItemEntrega { Identificador = 17, Nome = "Cafeteira" },
            new ItemEntrega { Identificador = 18, Nome = "Panela de pressão" },
            new ItemEntrega { Identificador = 19, Nome = "Mochila para laptop" },
            new ItemEntrega { Identificador = 20, Nome = "Câmera DSLR" },
            new ItemEntrega { Identificador = 21, Nome = "Micro-ondas" },
            new ItemEntrega { Identificador = 22, Nome = "Caixa de som Bluetooth" },
            new ItemEntrega { Identificador = 23, Nome = "Laptop gamer" },
            new ItemEntrega { Identificador = 24, Nome = "Relógio inteligente" },
            new ItemEntrega { Identificador = 25, Nome = "Bicicleta de montanha" },
            new ItemEntrega { Identificador = 26, Nome = "Tênis de corrida" },
            new ItemEntrega { Identificador = 27, Nome = "Jaqueta de couro" },
            new ItemEntrega { Identificador = 28, Nome = "Mala de viagem" },
            new ItemEntrega { Identificador = 29, Nome = "Cama king size" },
            new ItemEntrega { Identificador = 30, Nome = "Mesa de jantar" },
            new ItemEntrega { Identificador = 31, Nome = "Sofá de couro" },
            new ItemEntrega { Identificador = 32, Nome = "Ventilador de teto" },
            new ItemEntrega { Identificador = 33, Nome = "Máquina de café expresso" },
            new ItemEntrega { Identificador = 34, Nome = "Console de jogos" },
            new ItemEntrega { Identificador = 35, Nome = "Monitor ultrawide" },
            new ItemEntrega { Identificador = 36, Nome = "Smart TV 4K" },
            new ItemEntrega { Identificador = 37, Nome = "Sistema de som surround" },
            new ItemEntrega { Identificador = 38, Nome = "Projetor HD" },
            new ItemEntrega { Identificador = 39, Nome = "Máquina de costura" },
            new ItemEntrega { Identificador = 40, Nome = "Violão acústico" },
            new ItemEntrega { Identificador = 41, Nome = "Quadro de pintura" },
            new ItemEntrega { Identificador = 42, Nome = "Estante de livros" },
            new ItemEntrega { Identificador = 43, Nome = "Churrasqueira a gás" },
            new ItemEntrega { Identificador = 44, Nome = "Cadeira de escritório" },
            new ItemEntrega { Identificador = 45, Nome = "Secador de cabelo" },
            new ItemEntrega { Identificador = 46, Nome = "Máquina de barbear" },
            new ItemEntrega { Identificador = 47, Nome = "Máquina de waffle" },
            new ItemEntrega { Identificador = 48, Nome = "Batedeira" },
            new ItemEntrega { Identificador = 49, Nome = "Forno de micro-ondas" },
            new ItemEntrega { Identificador = 50, Nome = "Liquidificador de alta potência" },
        };

        foreach (var itemEntrega in listItemEntrega) { DadosServicos.AdicionarItemEntrega(itemEntrega); }

        List<Caminhao> caminhoesList = new()
        {
            new Caminhao { Identificador = 1, Placa = "ABC-1234" },
            //new Caminhao { Identificador = 2, Placa = "ALE-3454" },
            //new Caminhao { Identificador = 3, Placa = "BRA-9023" },
        };

        foreach (var caminhao in caminhoesList) { DadosServicos.AdicionarCaminhao(caminhao); }
        var contador = 1;
        var acabar = contador + 3;
        for (int ci = contador; ci < acabar; ci++)
        {
            DadosServicos.AssociarPontoAoItemDeEntrega(1, ci);
            contador += 1;
        }
        acabar = contador + 2;
        for (int ci = contador; ci < acabar; ci++)
        {
            DadosServicos.AssociarPontoAoItemDeEntrega(2, ci);
            contador += 1;
        }
        acabar = contador + 2;
        for (int ci = contador; ci < acabar; ci++)
        {
            DadosServicos.AssociarPontoAoItemDeEntrega(3, ci);
            contador += 1;
        }
        acabar = contador + 3;
        for (int ci = contador; ci < acabar; ci++)
        {
            DadosServicos.AssociarPontoAoItemDeEntrega(4, ci);
            contador += 1;
        }
        acabar = contador + 5;
        for (int ci = contador; ci < acabar; ci++)
        {
            DadosServicos.AssociarPontoAoItemDeEntrega(5, ci);
            contador += 1;
        }
        acabar = contador + 6;
        for (int ci = contador; ci < acabar; ci++)
        {
            DadosServicos.AssociarPontoAoItemDeEntrega(6, ci);
            contador += 1;
        }
        DadosServicos.AssociarPontoAoCaminhao(1, 1);
        DadosServicos.AssociarPontoAoCaminhao(2, 1);
        DadosServicos.AssociarPontoAoCaminhao(3, 1);
        DadosServicos.AssociarPontoAoCaminhao(4, 1);
        DadosServicos.AssociarPontoAoCaminhao(5, 3);
    }
}