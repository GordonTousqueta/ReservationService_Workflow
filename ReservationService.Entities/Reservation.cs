using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationService.Datas.Entities
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UtilisateurId { get; set; }
        [ForeignKey("UtilisateurId")]
        public virtual Utilisateur Utilisateur { get; set; }
        public string NoVol { get; set; }
        public string NoSiege { get; set; }
        public ActiveReservation ActualActiveReservation { get; set; }
        public DateTime Changement { get; set; }

    }
}
