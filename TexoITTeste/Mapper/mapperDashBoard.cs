using System.Data;
using TexoITTeste.Function;
using TexoITTeste.Models;
using TexoITTeste.ViewModel;

namespace TexoITTeste.Mapper
{
    public static class mapperDashBoard
    {

        public static CidadesPorEstado toCidadePorEstado(this CIDADE model, int total)
        {
            CidadesPorEstado vmModel = new CidadesPorEstado();
            vmModel.Estado = model.CI_002_C;
            vmModel.Total = total;

            return vmModel;
        }


        public static Capitais toCapitais(this CIDADE model)
        {
            Capitais vmModel = new Capitais();
            vmModel.Estado = model.CI_002_C;
            vmModel.Cidade = model.CI_003_C;

            return vmModel;
        }
    }
}