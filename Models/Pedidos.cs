using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


using System.Transactions;

namespace Concentrix.Models
{
    public class Pedidos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }


        [Required]
        [StringLength(150)]
        public string nomeCliente { get; set; }

        [Required]
        public DateTime dataPedido { get; set; }

        [Required]
        public double valorTotalPedido { get; set; }


        public ICollection<Itens> ItensPedidos { get; set; }


    }
}
