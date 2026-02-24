using Core;

namespace Core.Service
{
    public interface IPagamentoService
    {
        uint Create(Pagamento pagamento);
        decimal GetTotalPago(uint idAtendimento);
    }
}