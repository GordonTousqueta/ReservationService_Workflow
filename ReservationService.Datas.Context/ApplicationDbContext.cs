using Microsoft.EntityFrameworkCore;
using ReservationService.Datas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationService.Datas.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }

        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Utilisateur>().HasData(
                new Utilisateur
                {
                    Id = 1,
                    Nom = "Gagak",
                    Prenom = "gougk",
                    Email = "Agagag.gougk@Email.com",

                });
            modelBuilder.Entity<Reservation>().HasData(
                new Reservation
                {
                    Id = 1,
                    UtilisateurId = 1,
                    NoVol = "A123B",
                    NoSiege="A1",
                    ActualActiveReservation = ActiveReservation.Active,
                    Changement =DateTime.Now,
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
