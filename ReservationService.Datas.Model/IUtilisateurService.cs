using ReservationService.Datas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationService.Datas.Model
{
    public interface IUtilisateurService
    {
        Task<IEnumerable<Utilisateur>> GetUtilisateurServiceAsync();
        Task<Utilisateur> GetUtilisateurById(int id);
    }
}
