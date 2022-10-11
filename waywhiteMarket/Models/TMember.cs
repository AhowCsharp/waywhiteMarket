using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace waywhiteMarket.Models
{
    public partial class TMember
    {
        [Display(Name ="真實姓名")]
        [Required(ErrorMessage ="必填欄位")]
        public string? FName { get; set; }

        [Display(Name = "帳號")]
        [Required(ErrorMessage = "必填欄位")]
        public string FAccount { get; set; } = null!;

        [Display(Name = "密碼")]
        [Required(ErrorMessage = "必填欄位")]
        public string? FPassword { get; set; }

        [Display(Name = "信箱")]
        [Required(ErrorMessage = "必填欄位")]
        [EmailAddress(ErrorMessage ="請輸入信箱格式")]
        public string? FMail { get; set; }
        public int? FPower { get; set; }
    }
}
