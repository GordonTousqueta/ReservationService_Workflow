using ReservationService.Datas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationService.Datas.Repository
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetReservationAsync();
        Task<IEnumerable<Reservation>> GetReservationByNumeroAsync(string noVol);
        Task<IEnumerable<Reservation>> GetReservationsByUtilisateurAsync(Utilisateur user);
        Task<Reservation> GetReservationById(int id);

    }
}
