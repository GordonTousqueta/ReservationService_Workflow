using ReservationService.Datas.Entities;
using ReservationService.Datas.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationService.Datas.Model
{
    public class UtilisateurService : IUtilisateurService
    {
        IUtilisateurRepository _utilisateurRepo;
        UtilisateurService(IUtilisateurRepository utilisateurRepository) 
        {
            _utilisateurRepo = utilisateurRepository;
        }
        public async Task<Utilisateur> GetUtilisateurById(int id)
        {
            return await _utilisateurRepo.GetUserById(id);
        }

        public async Task<IEnumerable<Utilisateur>> GetUtilisateurServiceAsync()
        {
            return await _utilisateurRepo.GetAllUserAsync();
        }
    }
}
