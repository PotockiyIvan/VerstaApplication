using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VerstaApplication.Domain.Entities
{
    public class Order
    {
        /// <summary>
        /// Id заказа.
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Номер заказа.
        /// </summary>
        [Required]
        protected int OrderNumber { get; }

        /// <summary>
        /// Город отправителя.
        /// </summary>
        [Required]
        [Display(Name = "Город отправителя")]
        public string SenderCity { get; set; }

        /// <summary>
        /// Адрес отправителя.
        /// </summary>
        [Required]
        [Display(Name = "Адрес отправителя")]
        public string SenderAddress { get; set; }

        /// <summary>
        /// Город получателя.
        /// </summary>
        [Required]
        [Display(Name = "Город получателя")]
        public string RecipientCity { get; set; }

        /// <summary>
        /// Адрес получателя.
        /// </summary>
        [Required]
        [Display(Name = "Адрес получателя")]
        public string RecipientAddress { get; set; }

        /// <summary>
        /// Вес груза.
        /// </summary>
        [Required]
        [Display(Name = "Вес груза")]
        public decimal CargoWeight { get; set; }

        /// <summary>
        /// Дата забора.
        /// </summary>
        [Required]
        [Display(Name = "Дата забора груза")]
        [DataType(DataType.Date)]
        public DateTime PickUpDate { get; set; }


    }
}
