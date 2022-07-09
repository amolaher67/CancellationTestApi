using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CancellationTestApi.Data
{
    public class OrderDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long OrderDetailsId { get; set; }
        public string OrderNumber { get; set; }
        public DateTimeOffset OrderDateTime { get; set; }
        public string StoreName { get; set; }
    }
}
