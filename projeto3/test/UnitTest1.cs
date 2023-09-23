using app.ClassesModelo;
using app.Const;
using app.Interfaces;
using test.Seeds;

namespace test;

public class UnitTest1
{
    [Fact]
    public void Caso1()
    {
        DadosServicos DadosServicos = new();
        Seed.Seed1(DadosServicos);        
        var caminhaoMaisCarregado = DadosServicos.ObterCaminhoes().OrderByDescending(x => x.ObterTotalQuantidadeDeItems()).FirstOrDefault()!;
        Assert.NotNull(caminhaoMaisCarregado);
        Assert.True(caminhaoMaisCarregado.ObterTotalQuantidadeDeItems() <= Ajudantes.Capacidade); 

        DadosServicos.PrepararVinculosEVincular();
        caminhaoMaisCarregado = DadosServicos.ObterCaminhoes().OrderByDescending(x => x.ObterTotalQuantidadeDeItems()).FirstOrDefault()!;
        
        DadosServicos.RealizarEntregas();
        Assert.Equal(0, caminhaoMaisCarregado.ObterTotalQuantidadeDeItems());
        Assert.Empty(caminhaoMaisCarregado.LocaisEntregaFila);
        Assert.Empty(caminhaoMaisCarregado.LocaisEntregaLista);
    }

    [Fact]
    public void Caso2()
    {
        //capacidade >= 12
        DadosServicos DadosServicos = new();
        Seed.Seed2(DadosServicos);      
        var items = DadosServicos.ObterItensEntrega();
        var locais = DadosServicos.ObterLocais();

        var caminhaoMaisCarregado = DadosServicos.ObterCaminhoes().OrderByDescending(x => x.ObterTotalQuantidadeDeItems()).FirstOrDefault()!;
        int quantidade = caminhaoMaisCarregado.ObterTotalQuantidadeDeItems();
        Assert.NotNull(caminhaoMaisCarregado);
        Assert.True(quantidade <= Ajudantes.Capacidade);
        var caminhoes = DadosServicos.ObterCaminhoes();
        Assert.Equal(3, caminhoes.Count);
        Assert.Equal(7, quantidade);

        DadosServicos.PrepararVinculosEVincular();
        caminhaoMaisCarregado = DadosServicos.ObterCaminhoes().OrderByDescending(x => x.ObterTotalQuantidadeDeItems()).FirstOrDefault()!;
        DadosServicos.RealizarEntregas();
        Assert.Equal(0, caminhaoMaisCarregado.ObterTotalQuantidadeDeItems()!);
        Assert.Empty(caminhaoMaisCarregado.LocaisEntregaFila);
        Assert.Empty(caminhaoMaisCarregado.LocaisEntregaLista);
    }

    [Fact]
    public void Caso3()
    {
        //capacidade >= 11
        DadosServicos DadosServicos = new();
        Seed.Seed3(DadosServicos);
        var caminhaoMaisCarregado = DadosServicos.ObterCaminhoes().OrderByDescending(x => x.ObterTotalQuantidadeDeItems()).FirstOrDefault()!;
        int quantidade = caminhaoMaisCarregado.ObterTotalQuantidadeDeItems();

        var teste = DadosServicos.ObterCaminhoes();
        Assert.Equal(3, teste.Count());

        Assert.NotNull(caminhaoMaisCarregado);
        Assert.True(quantidade <= Ajudantes.Capacidade);
        Assert.Equal(14, quantidade);

        DadosServicos.PrepararVinculosEVincular();
        caminhaoMaisCarregado = DadosServicos.ObterCaminhoes().OrderByDescending(x => x.ObterTotalQuantidadeDeItems()).FirstOrDefault()!;
        Assert.Equal(14, caminhaoMaisCarregado.ObterTotalQuantidadeDeItems());
        DadosServicos.RealizarEntregas();
        Assert.Equal(0, caminhaoMaisCarregado.ObterTotalQuantidadeDeItems());
        Assert.Empty(caminhaoMaisCarregado.LocaisEntregaFila);
        Assert.Empty(caminhaoMaisCarregado.LocaisEntregaLista);
    }

}
