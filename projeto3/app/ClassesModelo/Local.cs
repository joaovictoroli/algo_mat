namespace app.ClassesModelo;
public class Local
{
    public int? Identificador { get; set; }
    public string? Nome { get; set; }
    private List<ItemEntrega>? _itensEntrega = new();

    public IEnumerable<ItemEntrega> ItensEntrega()
    {
        return this._itensEntrega ?? Enumerable.Empty<ItemEntrega>();
    }

    public void AdicionarItem(ItemEntrega itemEntrega)
    {
        this._itensEntrega!.Add(itemEntrega);
    }
    public override string ToString()
    {
        return $"L{Identificador}: {Nome} - numItens: {ItensEntrega().Count()}";
    }

    public void Desvincular()
    {
        this._itensEntrega!.Clear();
    }
}
