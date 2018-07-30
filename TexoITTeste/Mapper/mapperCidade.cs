using System.Data;
using TexoITTeste.Function;
using TexoITTeste.Models;
using TexoITTeste.ViewModel;

namespace TexoITTeste.Mapper
{
    public static class mapperCidade
    {
        public static CidadeViewModel toDataTableViewModel(this DataRow row)
        {
            CidadeViewModel model = new CidadeViewModel();
            model.UKEY = "";
            model.CI_001_N = int.Parse(row[0].ToString());
            model.CI_002_C = row[1].ToString();
            model.CI_003_C = row[2].ToString();
            model.CI_004_L = (row[3].ToString() == "" ? false : row[3].ToString() == "true" ? true : false) ;
            model.CI_005_C = row[4].ToString();
            model.CI_006_C = row[5].ToString();
            model.CI_007_C = row[6].ToString();
            model.CI_008_C = row[7].ToString();
            model.CI_009_C = row[8].ToString();
            model.CI_010_C = row[9].ToString();

            return model;
        }

        public static CidadeViewModel toViewModel(this CIDADE model)
        {
            CidadeViewModel vmModel = new CidadeViewModel();
            vmModel.UKEY = model.UKEY;
            vmModel.CI_001_N = model.CI_001_N;
            vmModel.CI_002_C = model.CI_002_C;
            vmModel.CI_003_C = model.CI_003_C;
            vmModel.CI_004_L = model.CI_004_L;
            vmModel.CI_005_C = model.CI_005_C;
            vmModel.CI_006_C = model.CI_006_C;
            vmModel.CI_007_C = model.CI_007_C;
            vmModel.CI_008_C = model.CI_008_C;
            vmModel.CI_009_C = model.CI_009_C;
            vmModel.CI_010_C = model.CI_010_C;
            return vmModel;
        }


        public static CidadeViewModelList toViewModelList(this CIDADE model)
        {
            CidadeViewModelList vmModel = new CidadeViewModelList();
            vmModel.UKEY = model.UKEY;
            vmModel.CI_001_N = model.CI_001_N;
            vmModel.CI_002_C = model.CI_002_C;
            vmModel.CI_003_C = model.CI_003_C;
            vmModel.CI_004_L = model.CI_004_L;
            vmModel.CI_005_C = model.CI_005_C;
            vmModel.CI_006_C = model.CI_006_C;
            vmModel.CI_007_C = model.CI_007_C;
            vmModel.CI_008_C = model.CI_008_C;
            vmModel.CI_009_C = model.CI_009_C;
            vmModel.CI_010_C = model.CI_010_C;
            return vmModel;
        }

        public static CIDADE toCreate(this CidadeViewModel vmModel)
        {
            CIDADE model = new CIDADE();
            model.UKEY = fncBiblio.GetUkey();
            model.CI_001_N = vmModel.CI_001_N;
            model.CI_002_C = vmModel.CI_002_C ?? "";
            model.CI_003_C = vmModel.CI_003_C ?? "";
            model.CI_004_L = vmModel.CI_004_L;
            model.CI_005_C = vmModel.CI_005_C ?? "";
            model.CI_006_C = vmModel.CI_006_C ?? "";
            model.CI_007_C = vmModel.CI_007_C ?? "";
            model.CI_008_C = vmModel.CI_008_C ?? "";
            model.CI_009_C = vmModel.CI_009_C ?? "";
            model.CI_010_C = vmModel.CI_010_C ?? "";

            return model;
        }

        public static void toEdit(this CidadeViewModel vmModel, CIDADE model)
        {
            //model.UKEY = fncBiblio.GetUkey();
            model.CI_001_N = vmModel.CI_001_N;
            model.CI_002_C = vmModel.CI_002_C ?? "";
            model.CI_003_C = vmModel.CI_003_C ?? "";
            model.CI_004_L = vmModel.CI_004_L;
            model.CI_005_C = vmModel.CI_005_C ?? "";
            model.CI_006_C = vmModel.CI_006_C ?? "";
            model.CI_007_C = vmModel.CI_007_C ?? "";
            model.CI_008_C = vmModel.CI_008_C ?? "";
            model.CI_009_C = vmModel.CI_009_C ?? "";
            model.CI_010_C = vmModel.CI_010_C ?? "";
            //return model;
        }
    }
}