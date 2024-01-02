using Microsoft.EntityFrameworkCore;
using ReservationService.Datas.Context;
using ReservationService.Datas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationService.Datas.Repository
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        private readonly ApplicationDbContext _context;
        public UtilisateurRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Utilisateur>> GetAllUserAsync()
        {
            return await _context.Utilisateurs.ToListAsync();
        }

        public async Task<Utilisateur> GetUserById(int id)
        {
            return await _context.Utilisateurs.Where(x => x.Id == id).FirstAsync();
        }

        public async Task<bool> SaveUserAsync()
        {
            throw new NotImplementedException();
        }
    }
}
