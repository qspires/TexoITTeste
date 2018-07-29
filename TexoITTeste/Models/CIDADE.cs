using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TexoITTeste.Models
{
    public class CIDADE
    {
        [Key]
        public string UKEY { get; set; } //
        public int CI_001_N { get; set; } //
        public string CI_002_C { get; set; } //
        public string CI_003_C { get; set; } //
        public bool CI_004_L { get; set; } //
        public string CI_005_C { get; set; } //
        public string CI_006_C { get; set; } //
        public string CI_007_C { get; set; } //
        public string CI_008_C { get; set; } //
        public string CI_009_C { get; set; } //
        public string CI_010_C { get; set; } //
    }
}