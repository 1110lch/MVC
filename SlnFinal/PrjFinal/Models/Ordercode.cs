using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PrjFinal.Models
{
    public class tOrdercode
    {
        [Required(ErrorMessage = "訂單編號不可空白")]
        public int 訂單號碼 { get; set; }
        public string 客戶編號 { get; set; }
        public int 員工編號 { get; set; }
        public DateTime 訂單日期 { get; set; }
        public DateTime 要貨日期 { get; set; }
        public DateTime 送貨日期 { get; set; }
        public int 送貨方式 { get; set; }
        public int 運費 { get; set; }

        [Required(ErrorMessage = "姓名不可空白")]
        public string 收貨人 { get; set; }
        public string 送貨地址 { get; set; }
        public string 送貨城市 { get; set; }
        public string 送貨行政區 { get; set; }
        public string 送貨郵遞區號 { get; set; }
        public string 送貨國家地區 { get; set; }
    }
}