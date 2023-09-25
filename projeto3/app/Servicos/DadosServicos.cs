using app.ClassesModelo;
using app.Const;
namespace app.Interfaces;

public class DadosServicos
{
    private readonly List<Local> locais = new();
    private readonly List<ItemEntrega> itemsEntregas = new();
    private readonly List<Caminhao> caminhoes = new();


    public int RetornarProximoIdentificadorLocal()
    {
        return this.locais.Count + 1;
    }
    public int RetornarProximoIdentificadorItemEntregas()
    {
        return this.itemsEntregas.Count + 1;
    }
    public int RetornarProximoIdentificadorCaminhoes()
    {
        return this.caminhoes.Count + 1;
    }
    public void AdicionarLocal(Local local)
    {
        if (local.Identificador == null && local.Nome == null)
        {
            return;
        }
        this.locais.Add(new Local { Identificador = RetornarProximoIdentificadorLocal(), Nome = local.Nome });
    }

    public void AdicionarCaminhao(Caminhao caminhao)
    {
        if (caminhao.Identificador == null && caminhao.Placa == null)
        {
            return;
        }
        this.caminhoes.Add(new Caminhao
        {
            Identificador = RetornarProximoIdentificadorCaminhoes(),
            Placa = caminhao.Placa
        });   
    }


    public void AdicionarItemEntrega(ItemEntrega itemEntrega)
    {
        if (itemEntrega.Identificador == null && itemEntrega.Nome == null)
        {
            return;
        }
        this.itemsEntregas.Add(new ItemEntrega
        {
            Identificador = RetornarProximoIdentificadorItemEntregas(),
            Nome = itemEntrega.Nome
        });

    }
    public List<Local> ObterLocais()
    {
        return this.locais;
    }

    public List<Caminhao> ObterCaminhoes()
    {
        return this.caminhoes;
    }

    public List<ItemEntrega> ObterItensEntrega()
    {

        return this.itemsEntregas;
    }


    // Associações
    public string AssociarPontoAoItemDeEntrega(int? idPonto, int? idItem)
    {
        try
        {
            var localEmQuestao = this.locais.FirstOrDefault(x => x.Identificador == idPonto);
            var itemEntrega = this.itemsEntregas.FirstOrDefault(x => x.Identificador == idItem);

            if (localEmQuestao != null
                && itemEntrega != null
                && localEmQuestao.ItensEntrega().Count() + 1 <= Ajudantes.Capacidade)
            {
                localEmQuestao.AdicionarItem(itemEntrega);
                return "Associado com sucesso!";
            }
            else
            {
                return "Capacidade excedida!";
            }
        }
        catch { return "Não foi encontrado."; }
    }

    public string AssociarPontoAoCaminhao(int? idPonto, int? idCaminhao)
    {
        bool existePontoVinculadoAoLocal = this.caminhoes.Any(x => x.LocaisEntregaLista.Any(x => x.Identificador == idPonto));
        bool existeCaminhao = this.caminhoes.Exists(x => x.Identificador == idCaminhao);
        if (!existeCaminhao) { return "Não foi encontrado."; }
        if (existePontoVinculadoAoLocal) { return "Ponto já vinculado a outro caminhão."; }
        try
        {
            var localEmQuestao = this.locais.FirstOrDefault(x => x.Identificador == idPonto);
            var caminhao = this.caminhoes.FirstOrDefault(x => x.Identificador == idCaminhao);
            if (caminhao.ObterTotalQuantidadeDeItems() + localEmQuestao.ItensEntrega().Count() <= Ajudantes.Capacidade
                && localEmQuestao.ItensEntrega().Count() > 0
                && existePontoVinculadoAoLocal != true
                )
            {
                caminhao.LocaisEntregaLista.Add(localEmQuestao);                
                return "Associado com sucesso!";
            }
            else { return "Capacidade excedida!"; }
        }
        catch { return "Não foi encontrado."; }
    }

    // Algo
    public void PrepararVinculosEVincular()
    {
        var caminhoesValidos = this.caminhoes.Where(x => x.ObterTotalQuantidadeDeItems() <= Ajudantes.Capacidade).ToList();
        var caminhoesValidosOrdernadosPorLocal = caminhoesValidos.OrderBy(x => x.LocaisEntregaLista!.Count).ToList();

        var locaisValidos = this.locais?.Where(x => x?.ItensEntrega().Count() > 0) ?? new List<Local>();
        var locaisRegistrados = this.caminhoes.SelectMany(x => x.LocaisEntregaLista!).ToList();
        var locaisNaoRegistrados = locaisValidos.Where(x => !locaisRegistrados.Contains(x)).ToList();

        var locaisNaoRegistradosValidos = locaisNaoRegistrados.Where(x => x.ItensEntrega().Count() > 0).ToList();
        locaisNaoRegistradosValidos = locaisNaoRegistradosValidos.OrderByDescending(x => x.ItensEntrega().Count()).ToList();

        var caminhaoComMenorQuantidade = this.caminhoes.OrderBy(x => x.ObterTotalQuantidadeDeItems()).FirstOrDefault();
        var localComMenorQuantidadeDeItems = locaisNaoRegistradosValidos.OrderBy(x => x.ItensEntrega().Count()).FirstOrDefault();

        if (localComMenorQuantidadeDeItems is null) { localComMenorQuantidadeDeItems = new Local(); }
        if (caminhaoComMenorQuantidade is null) { caminhaoComMenorQuantidade = new Caminhao(); }

        while (locaisNaoRegistradosValidos.Count() != 0
           // || localComMenorQuantidadeDeItems.ItensEntrega.Count + caminhaoComMenorQuantidade.ObterTotalQuantidadeDeItems() < capacidade 
           )
        {
            (var LocaisJaAdicionados, caminhoesValidosOrdernadosPorLocal, locaisNaoRegistradosValidos) = TentarVincularCaminhaoAPontoValido(caminhoesValidosOrdernadosPorLocal, locaisNaoRegistradosValidos);
            if (LocaisJaAdicionados.Count == 1)
            {
                locaisNaoRegistradosValidos.Remove(LocaisJaAdicionados[0]);
                LocaisJaAdicionados.Clear();
            }
            caminhoesValidosOrdernadosPorLocal = this.caminhoes.OrderBy(x => x.LocaisEntregaLista!.Count).ToList();
            localComMenorQuantidadeDeItems = locaisNaoRegistradosValidos.OrderBy(x => x.ItensEntrega().Count()).FirstOrDefault();

            caminhaoComMenorQuantidade = this.caminhoes.OrderBy(x => x.ObterTotalQuantidadeDeItems()).FirstOrDefault();
            if (localComMenorQuantidadeDeItems == null ||
                localComMenorQuantidadeDeItems.ItensEntrega().Count() + caminhaoComMenorQuantidade.ObterTotalQuantidadeDeItems() >= Ajudantes.Capacidade)
            {
                break;
            }
        }
    }
    
    private (List<Local>, List<Caminhao>, List<Local>) TentarVincularCaminhaoAPontoValido(List<Caminhao> caminhoesValidosOrdernadosPorLocal,
                                                            List<Local> locaisNaoRegistradosValidos)
    {
        List<Local> LocaisJaAdicionados = new();
        for (int i = 0; i < caminhoesValidosOrdernadosPorLocal.Count; i++)
        {
            if (caminhoesValidosOrdernadosPorLocal[i].ObterTotalQuantidadeDeItems() <= Ajudantes.Capacidade)
            {
                for (int j = 0; j < locaisNaoRegistradosValidos.Count; j++)
                {
                    if (caminhoesValidosOrdernadosPorLocal[i].ObterTotalQuantidadeDeItems() + locaisNaoRegistradosValidos[j].ItensEntrega().Count() <= Ajudantes.Capacidade)
                    {
                        if (!LocaisJaAdicionados.Contains(locaisNaoRegistradosValidos[j])
                            || LocaisJaAdicionados.Count == 0
                            )
                        {
                            string result = AssociarPontoAoCaminhao(locaisNaoRegistradosValidos[j].Identificador, caminhoesValidosOrdernadosPorLocal[i].Identificador);
                            if (result == "Associado com sucesso!")
                            {
                                LocaisJaAdicionados.Add(locaisNaoRegistradosValidos[j]);
                                break;
                            }
                        }
                    }
                }
                if (LocaisJaAdicionados.Any())
                {
                    break;
                }
            }
        }
        return (LocaisJaAdicionados, caminhoesValidosOrdernadosPorLocal, locaisNaoRegistradosValidos);
    }

    // Prints e queues
    private char GerandoLetraComoNumero(int contador)
    {
        Dictionary<int, char> alphabetMapping = new Dictionary<int, char>
        {
            { 1, 'a' },
            { 2, 'b' },
            { 3, 'c' },
            { 4, 'd' },
            { 5, 'e' },
            { 6, 'f' },
            { 7, 'g' },
            { 8, 'h' },
            { 9, 'i' },
            { 10, 'j' },
            { 11, 'k' },
            { 12, 'l' },
            { 13, 'm' },
            { 14, 'n' },
            { 15, 'o' },
            { 16, 'p' },
            { 17, 'q' },
            { 18, 'r' },
            { 19, 's' },
            { 20, 't' },
            { 21, 'u' },
            { 22, 'v' },
            { 23, 'w' },
            { 24, 'x' },
            { 25, 'y' },
            { 26, 'z' }
        };

        return alphabetMapping[contador];
    }

    public void RealizarEntregas()
    {
        List<Local> locaisVisitados = new();
        this.caminhoes.ForEach(x => x.LocaisEntregaLista?.ForEach(y => x.LocaisEntregaFila?.Enqueue(y)));

        int totalItemEntregues = 0;
        int totalLocaisVisitados = 0;

        foreach (var caminhao in caminhoes)
        {
            Ajudantes.Escrever($"Percurso do caminhão: {caminhao.Placa}: ");

            if (caminhao.LocaisEntregaLista == null) continue;

            for (int cl = 0; cl < caminhao.LocaisEntregaLista.Count; cl++)
            {
                var localEntrega = caminhao.LocaisEntregaLista[cl];
                Ajudantes.Escrever($"\t{GerandoLetraComoNumero(cl + 1)}. Visitado local de entrega {localEntrega.Nome}. Foram entregues os itens: ");

                if (localEntrega.ItensEntrega == null) continue;

                foreach (var (itemEntrega, index) in localEntrega.ItensEntrega().Select((Value, Index) => (Value, Index)))
                {
                    Ajudantes.Escrever($"\t\t{GerandoLetraComoNumero(index + 1)}. {itemEntrega.Nome}");
                    totalItemEntregues++;
                }

                if (caminhao.LocaisEntregaFila == null || !caminhao.LocaisEntregaFila.TryDequeue(out var localVisitado)) continue;

                this.locais.FirstOrDefault(x => x.Identificador == localVisitado.Identificador)?.Desvincular();
                totalLocaisVisitados++;
            }
        }
        Ajudantes.Escrever($"Total de locais de entrega: {totalLocaisVisitados}");
        Ajudantes.Escrever($"Total de items entregues: {totalItemEntregues}");
        this.caminhoes.ForEach(caminhao => caminhao.DesvincularLocais());
    }
}
