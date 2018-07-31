using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using TexoITTeste.ViewModel;
using TexoITTeste.Manager;
using TexoITTeste.Function;
using Swashbuckle.Swagger.Annotations;

namespace TexoITTeste.Controllers
{
    [RoutePrefix("api/Cidade")]
    public class CidadeController : ApiController
    {

        [AllowAnonymous]
        [ResponseType(typeof(CidadeModel))]
        [Route("")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                List<CidadeViewModel> model = new List<CidadeViewModel>();
                managerCidade mngCidade = new managerCidade();

                model = mngCidade.GetAll();

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [AllowAnonymous]
        [Route("Id")]
        [HttpGet]
        public HttpResponseMessage GetId(string ukey)
        {
            try
            {
                List<CidadeViewModel> model = new List<CidadeViewModel>();
                managerCidade mngCidade = new managerCidade();

                model = mngCidade.Get(new CidadeViewModel() { Tipo = fncEnum.eOperacao.Igual, UKEY = ukey });

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [AllowAnonymous]
        [Route("Ibge")]
        [HttpGet]
        public HttpResponseMessage GetIbge(int ibge)
        {
            try
            {
                List<CidadeViewModel> model = new List<CidadeViewModel>();
                managerCidade mngCidade = new managerCidade();

                model = mngCidade.Get(new CidadeViewModel() { Tipo = fncEnum.eOperacao.Igual, CI_001_N = ibge});

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [AllowAnonymous]
        [Route("Uf")]
        [HttpGet]
        public HttpResponseMessage GetUf(string uf)
        {
            try
            {
                List<CidadeViewModel> model = new List<CidadeViewModel>();
                managerCidade mngCidade = new managerCidade();

                model = mngCidade.Get(new CidadeViewModel() { Tipo = fncEnum.eOperacao.Igual, CI_002_C = uf });

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [AllowAnonymous]
        [Route("Cidade")]
        [HttpGet]
        public HttpResponseMessage GetCidade(string cidade)
        {
            try
            {
                List<CidadeViewModel> model = new List<CidadeViewModel>();
                managerCidade mngCidade = new managerCidade();

                model = mngCidade.Get(new CidadeViewModel() { Tipo = fncEnum.eOperacao.Igual, CI_003_C = cidade });

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [AllowAnonymous]
        [Route("Capitais")]
        [HttpGet]
        public HttpResponseMessage GetCapitais()
        {
            try
            {
                List<CidadeViewModel> model = new List<CidadeViewModel>();
                managerCidade mngCidade = new managerCidade();

                model = mngCidade.Get(new CidadeViewModel() { Tipo = fncEnum.eOperacao.Igual, CI_004_N = fncEnum.eCapital.Sim });

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [AllowAnonymous]
        [Route("QtdPorEstado")]
        [HttpGet]
        public HttpResponseMessage GetQtdPorEstado()
        {
            try
            {
                DashBoardViewModel model = new DashBoardViewModel();
                managerCidade mngCidade = new managerCidade();

                model = mngCidade.DashBoard();

                return Request.CreateResponse(HttpStatusCode.OK, model.CidadesPorEstado);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [AllowAnonymous]
        [Route("PorAtributo")]
        [HttpGet]
        public HttpResponseMessage GetPorAtributo([FromUri]CidadeFilterModel Filter)
        {
            try
            {
                List<CidadeViewModel> model = new List<CidadeViewModel>();
                managerCidade mngCidade = new managerCidade();

                model = mngCidade.GetAtributo(Filter);

                return Request.CreateResponse(HttpStatusCode.OK, model.Count());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [AllowAnonymous]
        [Route("UfMaiorMenor")]
        [HttpGet]
        public HttpResponseMessage GetUfMaiorMenor()
        {
            try
            {
                DashBoardViewModel model = new DashBoardViewModel();
                managerCidade mngCidade = new managerCidade();

                model = mngCidade.DashBoard();

                return Request.CreateResponse(HttpStatusCode.OK, model.EstadoMaiorMenor);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }


        [AllowAnonymous]
        [Route("TotalCidades")]
        [HttpGet]
        public HttpResponseMessage GetTotalCidades()
        {
            try
            {
                DashBoardViewModel model = new DashBoardViewModel();
                managerCidade mngCidade = new managerCidade();

                model = mngCidade.DashBoard();

                return Request.CreateResponse(HttpStatusCode.OK, model.Total);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [AllowAnonymous]
        [ResponseType(typeof(CidadeModel))]
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]CidadeViewModel model)
        {
            try
            {
                managerCidade mngCidade = new managerCidade();

                model = mngCidade.Create(model);

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [AllowAnonymous]
        [ResponseType(typeof(CidadeModel))]
        [Route("")]
        [HttpPut]
        public HttpResponseMessage Put([FromBody]CidadeViewModel model)
        {
            try
            {
                managerCidade mngCidade = new managerCidade();

                model = mngCidade.Edit(model);

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [AllowAnonymous]
        [Route("")]
        [HttpDelete]
        public HttpResponseMessage Delete(string ukey)
        {
            try
            {
                managerCidade mngCidade = new managerCidade();
                mngCidade.Delete(ukey);
                return Request.CreateResponse(HttpStatusCode.OK, ukey);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }
    }
}
