namespace app.ClassesModelo;
public class Caminhao
{
    public int? Identificador { get; set; }
    public string? Placa { get; set; }
    public List<Local>? LocaisEntregaLista { get; set; } = new();
    public Queue<Local>? LocaisEntregaFila { get; set; } = new();
    public override string ToString()
    {
        return $"C{Identificador} - Placa: {Placa} - numPontos: {LocaisEntregaLista?.Count}";
    }

    public int ObterTotalQuantidadeDeItems()
    {
        int soma = 0;
        this.LocaisEntregaLista?.ForEach(x => soma += x.ItensEntrega!.Count);
        return soma;
    }

    public void DesvincularLocais()
    {
        this.LocaisEntregaLista.Clear();
    }

}
