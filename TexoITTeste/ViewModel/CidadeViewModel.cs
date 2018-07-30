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


    public class CidadeModel
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

    public class CidadeFilterModel
    {
        public string UKEY { get; set; } //
        public int ibge { get; set; } //
        public string Uf { get; set; } //
        public string Cidade { get; set; } //
        public bool Capital { get; set; } //
        public string Longitude { get; set; } //
        public string Latitude { get; set; } //
        public string NomeSemAcento { get; set; } //
        public string NomeAlternativo { get; set; } //
        public string MicroRegiao { get; set; } //
        public string RegiaoDistancia { get; set; } //
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