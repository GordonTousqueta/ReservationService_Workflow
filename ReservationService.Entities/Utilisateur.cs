using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationService.Datas.Entities
{
    public class Utilisateur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Prenom { get;set; }
        public string Nom { get;set; }
        public string Email { get;set; }

        public int UtilisateurId { get; set; }
        public ActiveReservation ActiveReservation { get; set; }
    }
}
