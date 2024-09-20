public class SistemaPontuacaoService
{
    public int CalcularPontos(decimal valorVenda)
    {
        return (int)(valorVenda * 0.1M);
    }

    public void AdicionarPontos(int clienteId, int pontos)
    {
        Console.WriteLine($"Cliente {clienteId} recebeu {pontos} pontos.");
    }
}
