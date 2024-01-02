using Microsoft.EntityFrameworkCore;
using ReservationService.Datas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationService.Datas.Context
{
    public interface IApplicationDbContext : IDbContext
    {
        DbSet<Utilisateur> Utilisateurs { get; set; }
        DbSet<Entities.Reservation> Reservations { get; set; }

    }
}
