using AutoMapper;

namespace RestauranteWeb.Mappers
{
    public class FormapagamentoProfile : Profile
    {
		public FormapagamentoProfile()
		{
			CreateMap<Core.Formapagamento, Models.FormapagamentoViewModel>().ReverseMap();
		}
	}
}
