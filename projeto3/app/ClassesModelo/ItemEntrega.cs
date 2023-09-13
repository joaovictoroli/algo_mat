namespace app.ClassesModelo;

public class ItemEntrega
{
    public int? Identificador { get; set; }
    public string? Nome { get; set; }

    public override string ToString()
    {
        return $"I{Identificador}: {Nome}";
    }
}
