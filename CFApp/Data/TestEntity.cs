using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CFApp.Data
{
    [Table("tblTest")]  // veri tabanındaki tablo ile eşleşmeyi sağlamak için
    public class TestEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Deneme uyarı")]  //isimin boş geçilemeyeceğini belirtiyoruz
        public string Name { get; set; }
        public string Surname { get; set; }
      //  [Column ("No")]
       public string No { get; set; }

    }
}