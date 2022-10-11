using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace waywhiteMarket.Models
{
    public partial class TProduct
    {
        [Display(Name = "商品名稱")]
        [Required(ErrorMessage = "必填欄位")]
        public string FName { get; set; } = null!;
        [Display(Name = "價格")]
        [Required(ErrorMessage = "必填欄位")]
        public int FPrice { get; set; }
        public string? FPath { get; set; }
        [Display(Name = "商品敘述")]
        [Required(ErrorMessage = "必填欄位")]
        public string? FDescription { get; set; }
        [Display(Name = "類別")]
        [Required(ErrorMessage = "必填欄位")]
        public string FType { get; set; } = null!;
       
        public string? FOwner { get; set; }
        public DateTime FDay { get; set; }

        
    }
}
