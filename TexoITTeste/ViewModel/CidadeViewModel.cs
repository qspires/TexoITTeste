using System.Collections.Generic;
using static TexoITTeste.Function.fncEnum;

namespace TexoITTeste.ViewModel
{
    public class CidadeViewModel
    {
        public string UKEY { get; set; } //
        public int CI_001_N { get; set; } //
        public string CI_002_C { get; set; } //
        public string CI_003_C { get; set; } //
        public bool CI_004_L { get; set; } //
        public eCapital CI_004_N { get; set; } //
        public string CI_005_C { get; set; } //
        public string CI_006_C { get; set; } //
        public string CI_007_C { get; set; } //
        public string CI_008_C { get; set; } //
        public string CI_009_C { get; set; } //
        public string CI_010_C { get; set; } //

        public eOperacao Tipo { get; set; } //

        public List<CidadeViewModelList> List { get; set; }

        public CidadeViewModel()
        {
            this.List = new List<CidadeViewModelList>();
        }
    }

    public class CidadeViewModelList
    {
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