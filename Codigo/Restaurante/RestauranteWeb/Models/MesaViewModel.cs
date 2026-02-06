using Core;

namespace RestauranteWeb.Models
{
    public class MesaViewModel
    {
        public int Id { get; set; }
        public string Identificacao { get; set; } = null!;
        public uint IdRestaurante { get; set; }
        //public virtual ICollection<AtendimentoViewModel> Atendimentos { get; set; } = new List<AtendimentoViewModel>();
        public virtual Restaurante IdRestauranteNavigation { get; set; } = null!;

    }
}
