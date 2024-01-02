using ReservationService.Datas.Entities;
using ReservationService.Datas.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ReservationService.Datas.Repository
{
    public class ReservationRepository :IReservationRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ReservationRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<IEnumerable<Reservation>> GetReservationAsync()
        {
            var query = await _applicationDbContext.Reservations
                        .Include(x => x.Utilisateur)
                        .ToListAsync();
            return query;
        }

        public async Task<Reservation> GetReservationById(int id)
        {
            var query = await _applicationDbContext.Reservations.Where(x => x.Id == id).FirstOrDefaultAsync();
            return query;
        }

        public async Task<IEnumerable<Reservation>> GetReservationByNumeroAsync(string noVol)
        {
            var query = await _applicationDbContext.Reservations.Where(x => x.NoVol == noVol).ToListAsync();
            return query;
        }

        public Task<IEnumerable<Reservation>> GetReservationsByUtilisateurAsync(Utilisateur user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Save(Reservation obj)
        {
            if(obj == null) throw new ArgumentNullException(nameof(obj));

            if(obj.Id <= 0)
            {
                _applicationDbContext.Reservations.Add(obj);
            }
            else
            {
                _applicationDbContext.Entry(obj).State = EntityState.Modified;
            }
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }
    }
}
