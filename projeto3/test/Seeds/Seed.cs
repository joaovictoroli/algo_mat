using app.ClassesModelo;
using app.Interfaces;
using Bogus;

namespace test.Seeds;

public class Seed
{

    private static void AdicionarLocais(DadosServicos dadosServicos)
    {
        var localFaker = new Faker<Local>()
            //.RuleFor(l => l.Identificador, f => f.UniqueIndex + 1)
            .RuleFor(l => l.Nome, f => f.Address.City());

        var locais = localFaker.Generate(4);
        foreach (var local in locais) dadosServicos.AdicionarLocal(local);
    }

    private static void AdicionarItensEntrega(DadosServicos dadosServicos)
    {
        var itemEntregaFaker = new Faker<ItemEntrega>()
            //.RuleFor(i => i.Identificador, f => f.UniqueIndex + 1)
            .RuleFor(i => i.Nome, f => f.Commerce.ProductName());

        var itensEntrega = itemEntregaFaker.Generate(50);
        foreach (var itemEntrega in itensEntrega) dadosServicos.AdicionarItemEntrega(itemEntrega);
    }

    private static void AdicionarCaminhoes(DadosServicos dadosServicos)
    {
        var caminhaoFaker = new Faker<Caminhao>()
            //.RuleFor(c => c.Identificador, f => f.UniqueIndex + 1)
            .RuleFor(c => c.Placa, f => f.Vehicle.Vin());

        var caminhoes = caminhaoFaker.Generate(3);
        foreach (var caminhao in caminhoes) dadosServicos.AdicionarCaminhao(caminhao);
    }

    public static void Seed1(DadosServicos DadosServicos)
    {
        AdicionarLocais(DadosServicos);
        AdicionarItensEntrega(DadosServicos);
        AdicionarCaminhoes(DadosServicos);


        var mapaPontosEntrega = new Dictionary<int, (int Inicio, int Fim)>
        {
            { 1, (1, 15) },
            { 2, (15, 20) },
            { 3, (20, 31) },
            { 4, (31, 40) },
            { 5, (40, 44) }

        };

        foreach (var ponto in mapaPontosEntrega)
        {
            for (int ci = ponto.Value.Inicio; ci < ponto.Value.Fim; ci++)
            {
                DadosServicos.AssociarPontoAoItemDeEntrega(ponto.Key, ci);
            }
        }

        // Lista de associações para caminhões
        var associacoesCaminhoes = new List<(int caminhao, int ponto)>
        {
            (1, 1),
            (2, 2),
            (3, 3),
            (5, 3),
            (4, 3)
        };

        foreach (var associacao in associacoesCaminhoes)
        {
            DadosServicos.AssociarPontoAoCaminhao(associacao.caminhao, associacao.ponto);
        }
    }

    public static void Seed2(DadosServicos DadosServicos)
    {
        AdicionarLocais(DadosServicos);
        AdicionarItensEntrega(DadosServicos);
        AdicionarCaminhoes(DadosServicos);

        var mapaPontosEntrega = new Dictionary<int, (int Inicio, int Fim)>
        {
            { 1, (1, 6) },
            { 2, (6, 11) },
            { 3, (11, 14) },
            { 4, (14, 18) },
            { 5, (18, 21) },
            { 6, (21, 28) }
        };

        foreach (var ponto in mapaPontosEntrega)
        {
            for (int ci = ponto.Value.Inicio; ci < ponto.Value.Fim; ci++)
            {
                DadosServicos.AssociarPontoAoItemDeEntrega(ponto.Key, ci);
            }
        }

        var associacoesCaminhoes = new List<(int caminhao, int ponto)>
        {
            (1, 1),
            (2, 2),
            (3, 3),
            (5, 3),
            (4, 3)
        };

        foreach (var associacao in associacoesCaminhoes)
        {
            DadosServicos.AssociarPontoAoCaminhao(associacao.caminhao, associacao.ponto);
        }

    }

    public static void Seed3(DadosServicos DadosServicos)
    {
        AdicionarLocais(DadosServicos);
        AdicionarItensEntrega(DadosServicos);
        AdicionarCaminhoes(DadosServicos);

        var mapaPontosEntrega = new Dictionary<int, (int Inicio, int Fim)>
        {
            { 1, (1, 15) },
            { 2, (15, 30) },
            { 3, (30, 38) },
            { 4, (38, 45) },
        };

        foreach (var ponto in mapaPontosEntrega)
        {
            for (int ci = ponto.Value.Inicio; ci < ponto.Value.Fim; ci++)
            {
                DadosServicos.AssociarPontoAoItemDeEntrega(ponto.Key, ci);
            }
        }

        // Lista de associações para caminhões
        var associacoesCaminhoes = new List<(int caminhao, int ponto)>
        {
            (1, 1),
            (2, 2),
            (3, 3),
            (5, 3),
            (4, 3)
        };

        foreach (var associacao in associacoesCaminhoes)
        {
            DadosServicos.AssociarPontoAoCaminhao(associacao.caminhao, associacao.ponto);
        }
    }
    
}
