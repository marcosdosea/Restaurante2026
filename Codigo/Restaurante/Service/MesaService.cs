using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;



namespace Service
{
    public class MesaService : IMesaService
    {
        private readonly RestauranteContext context;
        public MesaService(RestauranteContext context)
        {
            this.context = context;
        }

        public int Create(Mesa mesa)
        {
            context.Add(mesa);
            context.SaveChanges();
            return mesa.Id;
        }

        public void Edit(Mesa mesa)
        {
            context.Update(mesa);
            context.SaveChanges();
        }

        public void Delete(Mesa mesa) {
            context.Mesas.Remove(mesa);
            context.SaveChanges();
        }

        public Mesa? Get(int id)
        {
            return context.Mesas
                .Include(m => m.IdRestaurante)
                .FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Mesa> GetAll()
        {
            return context.Mesas
                .Include(m => m.IdRestaurante)
                .AsNoTracking()
                .ToList();
        }




    }
}
