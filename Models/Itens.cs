using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;




namespace Concentrix.Models
{
    public class Itens
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idItem { get; set; }



        [Required]
        [StringLength(150)]
        public string nomePedido { get; set; }


        [Required]
        public int quantidade { get; set; }


        [Required]
        public double valorUnitario { get; set; }


    }
}
