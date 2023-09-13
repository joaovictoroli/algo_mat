namespace app.ClassesModelo;
public class Local
{
    public int? Identificador { get; set; }
    public string? Nome { get; set; }
    public List<ItemEntrega>? ItensEntrega { get; set; } = new();

    public override string ToString()
    {
        return $"L{Identificador}: {Nome} - numItens: {ItensEntrega?.Count}";
    }

    public void Desvincular()
    {
        this.ItensEntrega!.Clear();
    }
}
