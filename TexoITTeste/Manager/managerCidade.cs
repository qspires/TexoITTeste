using TexoITTeste.ViewModel;
using TexoITTeste.Mapper;
using System.Data;
using System;
using System.Web;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using System.Linq;
using System.Collections.Generic;
using TexoITTeste.Models;
using System.Data.Entity.Validation;
using TexoITTeste.DAO;
using TexoITTeste.Mapper;
using System.Web.Hosting;

namespace TexoITTeste.Manager
{
    public class managerCidade
    {

        public CidadeViewModel Search(CidadeViewModel Model)
        {
            try
            {
                daoCidade DaoCidade = new daoCidade();

                if (Model.List == null)
                {
                    Model.List = new List<CidadeViewModelList>();
                }

                DaoCidade.FindCidade(Model).OrderBy(x => x.CI_003_C).ToList().ForEach(x => Model.List.Add(x.toViewModelList()));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return Model;
        }

        public CidadeViewModel SearchEdit(string ukey)
        {
            CidadeViewModel Model;
            try
            {
                daoCidade DaoCidade = new daoCidade();

                Model = new CidadeViewModel() { UKEY = ukey };

                Model = DaoCidade.FindCidade(Model).Select(x => x.toViewModel()).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return Model;
        }

        public CidadeViewModel Edit(CidadeViewModel Model)
        {

            try
            {
                daoCidade DaoCidade = new daoCidade();

                CIDADE ModelEdit = DaoCidade.FindCidade(Model).FirstOrDefault();
                Model.toEdit(ModelEdit);
                DaoCidade.Update(ModelEdit);
                return Model;
            }
            catch (DbEntityValidationException e)
            {
                #region Detalha Erro
                string erro = "";

                foreach (var eve in e.EntityValidationErrors)
                {
                    erro = "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:";
                    erro = String.Format(erro, eve.Entry.Entity.GetType().Name, eve.Entry.State);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        erro = erro + String.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }

                #endregion
                throw new Exception(erro.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        public CidadeViewModel Create(CidadeViewModel Model)
        {

            try
            {
                daoCidade DaoCidade = new daoCidade();

                CIDADE ModelAdd = DaoCidade.FindUfCidade(Model.CI_002_C, Model.CI_003_C);
                if (ModelAdd != null)
                {
                    throw new Exception("Já existe uma cidade com o mesmo no no estado");
                }
                else
                {
                    ModelAdd = Model.toCreate();
                    DaoCidade.Add(ModelAdd);
                }

                return ModelAdd.toViewModel() ;
            }
            catch (DbEntityValidationException e)
            {
                #region Detalha Erro
                string erro = "";

                foreach (var eve in e.EntityValidationErrors)
                {
                    erro = "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:";
                    erro = String.Format(erro, eve.Entry.Entity.GetType().Name, eve.Entry.State);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        erro = erro + String.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }

                #endregion
                throw new Exception(erro.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        public void Delete(string ukey)
        {
            try
            {
                daoCidade DaoCidade = new daoCidade();
                DaoCidade.Delete(ukey);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public DataTable CreateImport(HttpPostedFileBase upload)
        {

            try
            {
                if (upload != null && upload.ContentLength > 0)
                {

                    if (upload.FileName.EndsWith(".csv"))
                    {
                        Stream stream = upload.InputStream;
                        DataTable csvTable = new DataTable();
                        using (CsvReader csvReader =
                            new CsvReader(new StreamReader(stream), true))
                        {
                            csvTable.Load(csvReader);
                        }

                        if (csvTable.Rows != null && csvTable.Rows[0].ItemArray.Count() == 9)
                        {
                            throw new Exception("Com numero de colunas incompativel");
                        }

                        List<CidadeViewModel> vmCidade = new List<CidadeViewModel>();
                        foreach (DataRow row in csvTable.Rows)
                        {
                            vmCidade.Add(row.toDataTableViewModel());
                        }

                        daoCidade DaoCidade = new daoCidade();
                        CIDADE Model;
                        foreach (CidadeViewModel item in vmCidade)
                        {

                            Model = DaoCidade.FindUfCidade(item.CI_002_C, item.CI_003_C);
                            if (Model != null)
                            {
                                item.toEdit(Model);
                                DaoCidade.Update(Model);
                            }
                            else
                            {
                                Model = item.toCreate();
                                DaoCidade.Add(Model);
                            }
                        }

                        return csvTable;
                    }
                    else
                    {
                        throw new Exception("Formato de arquivo invalido");
                    }
                }
            }
            catch (DbEntityValidationException e)
            {
                #region Detalha Erro
                string erro = "";

                foreach (var eve in e.EntityValidationErrors)
                {
                    erro = "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:";
                    erro = String.Format(erro, eve.Entry.Entity.GetType().Name, eve.Entry.State);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        erro = erro + String.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }

                #endregion
                throw new Exception(erro.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return null;
        }
        
        public DashBoardViewModel DashBoard()
        {
            DashBoardViewModel Model = new DashBoardViewModel();
            try
            {
                daoCidade DaoCidade = new daoCidade();

                List <CIDADE> ModelList = DaoCidade.GetAll();

                ModelList
                   .GroupBy(x => new { x.CI_002_C })
                   .Select(x => new CidadesPorEstado { Estado = x.Key.CI_002_C, Total = x.GroupBy(z => z.CI_003_C).Count() })
                   .ToList()
                   .ForEach(x => Model.CidadesPorEstado.Add(x));
                Model.CidadesPorEstado = Model.CidadesPorEstado.OrderByDescending(x => x.Total).ToList();

                Model.EstadoMaiorMenor.Add(Model.CidadesPorEstado.OrderByDescending(x => x.Total).ToList().First());
                Model.EstadoMaiorMenor.Add(Model.CidadesPorEstado.OrderBy(x => x.Total).ToList().First());

                //Model.EstadoMaiorMenor.Add(Model.CidadesPorEstado.GroupBy(x => new { x.Estado }).Select(x => new CidadesPorEstado { Estado = x.Key.Estado, Total = x.Max(z => z.Total) }).First());
                //Model.EstadoMaiorMenor.Add(Model.CidadesPorEstado.GroupBy(x => new { x.Estado }).Select(x => new CidadesPorEstado { Estado = x.Key.Estado, Total = x.Min(z => z.Total) }).First());


                Model.Capitais = ModelList.Where(x => x.CI_004_L == true).Select(x => x.toCapitais()).OrderBy(x => x.Cidade).ToList();

                Model.Total = ModelList.Count();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return Model;
        }

        public List<CidadeViewModel> GetAll()
        {
            List<CidadeViewModel> Model = new List<CidadeViewModel>();
            try
            {
                daoCidade DaoCidade = new daoCidade();

                Model = DaoCidade.GetAll().OrderBy(x => x.CI_003_C).Select(x => x.toViewModel()).ToList();
                return Model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        public List<CidadeViewModel> Get(CidadeViewModel Model)
        {
            try
            {
                List<CidadeViewModel> ModelList = new List<CidadeViewModel>();
                daoCidade DaoCidade = new daoCidade();

                DaoCidade.FindCidade(Model).OrderBy(x => x.CI_003_C).ToList().ForEach(x => ModelList.Add(x.toViewModel()));
                return ModelList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<CidadeViewModel> GetAtributo(CidadeFilterModel Model)
        {
            try
            {
                List<CidadeViewModel> ModelList = new List<CidadeViewModel>();
                daoCidade DaoCidade = new daoCidade();

                DaoCidade.FindCidadeAtributo(Model).OrderBy(x => x.CI_003_C).ToList().ForEach(x => ModelList.Add(x.toViewModel()));
                return ModelList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<CIDADE> CarregaMemoria()
        {

            List<CIDADE> Cidade = new List<CIDADE>();
            try
            {
                EFContext dbs = new EFContext();
                if (!dbs.Connexao())
                {
                    string Caminho = HttpContext.Current.Server.MapPath("~/Arquivos/Cidades.json");
                    string json = File.ReadAllText(Caminho);

                    List<CidadeViewModel> Model = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CidadeViewModel>>(json);

                    Model.ForEach(x => Cidade.Add(x.toCreate()));

                    return Cidade;
                }
                else
                {
                    return Cidade;
                }
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }

            return Cidade;
        }
    }
}