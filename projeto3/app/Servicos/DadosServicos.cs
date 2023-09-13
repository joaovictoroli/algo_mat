using app.ClassesModelo;
using app.Const;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace app.Interfaces;

public class DadosServicos
{
    int capacidade = Ajudantes.Capacidade;
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
        this.locais.Add(local);
    }

    public List<Local> ObterLocais()
    {
        return this.locais;
    }

    public List<Caminhao> ObterCaminhoes()
    {
        return this.caminhoes;
    }

    public void AdicionarItemEntrega(ItemEntrega itemEntrega)
    {
        this.itemsEntregas.Add(itemEntrega);
    }

    public List<ItemEntrega> ObterItensEntrega()
    {
        return this.itemsEntregas;
    }

    public void AdicionarCaminhao(Caminhao caminhao)
    {
        this.caminhoes.Add(caminhao);
    }

    public string AssociarPontoAoItemDeEntrega(int? idPonto, int? idItem)
    {
        try
        {
            var localEmQuestao = this.locais.FirstOrDefault(x => x.Identificador == idPonto);
            var itemEntrega = this.itemsEntregas.FirstOrDefault(x => x.Identificador == idItem);

            if (localEmQuestao.ItensEntrega.Count + 1 <= capacidade)
            {
                localEmQuestao.ItensEntrega?.Add(itemEntrega);
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
        bool existePontoVinculadoAoLocal = this.caminhoes.Any((x => x.LocaisEntregaLista.Any(x => x.Identificador == idPonto)));
        bool existeCaminhao = this.caminhoes.Exists(x => x.Identificador == idCaminhao);
        if (!existeCaminhao) { return "Não foi encontrado."; }
        if ( existePontoVinculadoAoLocal) { return "Ponto já vinculado a outro caminhão."; }
        try
        {
            var localEmQuestao = this.locais.FirstOrDefault(x => x.Identificador == idPonto);
            var caminhao = this.caminhoes.FirstOrDefault(x => x.Identificador == idCaminhao);
            if (caminhao.ObterTotalQuantidadeDeItems() + localEmQuestao.ItensEntrega.Count <= capacidade
                && localEmQuestao.ItensEntrega.Count > 0
                && existePontoVinculadoAoLocal != true
                )
            {
                caminhao.LocaisEntregaLista?.Add(localEmQuestao);
                return "Associado com sucesso!";
            }
            else { return "Capacidade excedida!"; }
        }
        catch { return "Não foi encontrado."; }
    }
    public void PrepararVinculosEVincular()
    {
        var caminhoesValidos = this.caminhoes.Where(x => x.ObterTotalQuantidadeDeItems() <= capacidade).ToList();
        var caminhoesValidosOrdernadosPorLocal = caminhoesValidos.OrderBy(x => x.LocaisEntregaLista!.Count).ToList();

        var locaisValidos = this.locais.Where(x => x.ItensEntrega.Count > 0).ToList();
        var locaisRegistrados = this.caminhoes.SelectMany(x => x.LocaisEntregaLista!).ToList();
        var locaisNaoRegistrados = locaisValidos.Where(x => !locaisRegistrados.Contains(x)).ToList();

        var locaisNaoRegistradosValidos = locaisNaoRegistrados.Where(x => x.ItensEntrega!.Count > 0).ToList();
        locaisNaoRegistradosValidos = locaisNaoRegistradosValidos.OrderByDescending(x => x.ItensEntrega!.Count).ToList();

        var caminhaoComMenorQuantidade = this.caminhoes.OrderBy(x => x.ObterTotalQuantidadeDeItems()).FirstOrDefault();
        var localComMenorQuantidadeDeItems = locaisNaoRegistradosValidos.OrderBy(x => x.ItensEntrega!.Count).FirstOrDefault();

        if (localComMenorQuantidadeDeItems is null) { localComMenorQuantidadeDeItems = new Local(); }
        if (caminhaoComMenorQuantidade is null) { caminhaoComMenorQuantidade = new Caminhao(); }

        while ( locaisNaoRegistradosValidos.Count != 0 
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
            localComMenorQuantidadeDeItems = locaisNaoRegistradosValidos.OrderBy(x => x.ItensEntrega!.Count).FirstOrDefault();

            caminhaoComMenorQuantidade = this.caminhoes.OrderBy(x => x.ObterTotalQuantidadeDeItems()).FirstOrDefault();
            if (localComMenorQuantidadeDeItems == null ||
                localComMenorQuantidadeDeItems.ItensEntrega.Count + caminhaoComMenorQuantidade.ObterTotalQuantidadeDeItems() >= capacidade)
            {
                break;
            }
        }
    }

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

    private (List<Local>, List<Caminhao>, List<Local>) TentarVincularCaminhaoAPontoValido(List<Caminhao> caminhoesValidosOrdernadosPorLocal,
                                                            List<Local> locaisNaoRegistradosValidos)
    {
        List<Local> LocaisJaAdicionados = new();
        for (int i = 0; i < caminhoesValidosOrdernadosPorLocal.Count; i++)
        {
            if (caminhoesValidosOrdernadosPorLocal[i].ObterTotalQuantidadeDeItems() <= capacidade)
            {
                for (int j = 0; j < locaisNaoRegistradosValidos.Count; j++)
                {
                    if (caminhoesValidosOrdernadosPorLocal[i].ObterTotalQuantidadeDeItems() + locaisNaoRegistradosValidos[j].ItensEntrega!.Count <= capacidade)
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

    public void RealizarEntregas()
    {
        List<Local> locaisVisitados = new();
        this.caminhoes.ForEach(x => x.LocaisEntregaLista.ForEach(y => x.LocaisEntregaFila.Enqueue(y)));

        int totalItemEntregues = 0;
        int totalLocaisVisitados = 0;
        for (int cc = 0; cc < caminhoes.Count; cc++)
        {
            Console.WriteLine($"Percurso do caminhão: {caminhoes[cc].Placa}: ");
            for (int cl = 0; cl < caminhoes[cc].LocaisEntregaLista!.Count; cl++)
            {
                Console.WriteLine($"\t" + GerandoLetraComoNumero(cl + 1) +
                    $". Visitado local de entrega {caminhoes[cc].LocaisEntregaLista[cl].Nome}. Foram entregues os itens: ");

                for (int ci = 0; ci < caminhoes[cc].LocaisEntregaLista[cl].ItensEntrega!.Count; ci++)
                {
                    Console.WriteLine($"\t\t" + GerandoLetraComoNumero(ci + 1) +
                    $". {caminhoes[cc].LocaisEntregaLista[cl].ItensEntrega[ci].Nome}");

                    totalItemEntregues += 1;
                }

                var localVisitado = this.caminhoes[cc].LocaisEntregaFila.Dequeue();
                this.locais.FirstOrDefault(x=> x.Identificador == localVisitado.Identificador).Desvincular();
                totalLocaisVisitados += 1;
            }          
        }
        Console.WriteLine($"Total de locais de entrega: {totalLocaisVisitados}");
        Console.WriteLine($"Total de items entregues: {totalItemEntregues}");

        this.caminhoes.ForEach(caminhoes => caminhoes.DesvincularLocais());
    }
}
