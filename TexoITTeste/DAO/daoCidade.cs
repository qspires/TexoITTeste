using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TexoITTeste.Models;
using TexoITTeste.ViewModel;
using TexoITTeste.Filter;
using TexoITTeste.Mapper;

namespace TexoITTeste.DAO
{
    public class daoCidade
    {
        EFContext dbs = new EFContext();

        public void Add(CIDADE Model)
        {

            if (dbs.Connexao())
            {
                dbs.Cidade.Add(Model);
                dbs.SaveChanges();
            }
            else
            {
                MvcApplication.CidadePublic.Add(Model);
            }
        }

        public void Update(CIDADE Model)
        {
            if (dbs.Connexao())
            {
                dbs.Entry(Model).State = EntityState.Modified;
                dbs.SaveChanges();
            }
            else
            {
                //MvcApplication.CidadePublic.Remove(Model);
                //MvcApplication.CidadePublic.Add(Model);

                for(int i=0; i< MvcApplication.CidadePublic.Count(); i++)
                {
                    if(MvcApplication.CidadePublic[i].UKEY == Model.UKEY)
                    {
                        Model.toEdit(MvcApplication.CidadePublic[i]);
                    }
                }

            }
        }

        public CIDADE FindUfCidade(string uf, string cidade)
        {
            try
            {
                if (dbs.Connexao())
                {
                    List<CIDADE> ListModel = dbs.Cidade.Where(x => x.CI_002_C == uf && x.CI_003_C == cidade).ToList();
                    if (ListModel.Count() > 0)
                    {
                        return ListModel.FirstOrDefault();
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    List<CIDADE> ListModel = MvcApplication.CidadePublic.Where(x => x.CI_002_C == uf && x.CI_003_C == cidade).ToList();
                    if (ListModel.Count() > 0)
                    {
                        return ListModel.FirstOrDefault();
                    }
                    else
                    {
                        return null;
                    }
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }

        public List<CIDADE> FindCidade(CidadeViewModel Filter)
        {
            try
            {
                if (dbs.Connexao())
                {
                    List<CIDADE> ListModel = dbs.Cidade.Where(Filter.ToExpression()).ToList();
                    return ListModel;
                }
                {
                    List<CIDADE> ListModel = MvcApplication.CidadePublic.AsQueryable().Where(Filter.ToExpression()).ToList();
                    return ListModel;
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }

        public List<CIDADE> FindCidadeAtributo(CidadeFilterModel Filter)
        {
            try
            {
                if (dbs.Connexao())
                {
                    List<CIDADE> ListModel = dbs.Cidade.Where(Filter.ToExpression()).ToList();
                    return ListModel;
                }
                else
                {
                    List<CIDADE> ListModel = MvcApplication.CidadePublic.AsQueryable().Where(Filter.ToExpression()).ToList();
                    return ListModel;
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }

        public List<CIDADE> GetAll()
        {
            try
            {
                if (dbs.Connexao())
                {
                    List<CIDADE> ListModel = dbs.Cidade.ToList();
                    return ListModel;
                }
                else
                {
                    List<CIDADE> ListModel = MvcApplication.CidadePublic.ToList();
                    return ListModel;
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }

        public void Delete(string ukey)
        {
            try
            {
                if (dbs.Connexao())
                {
                    CidadeViewModel Filter = new CidadeViewModel() { UKEY = ukey };

                    List<CIDADE> ListModel = dbs.Cidade.Where(Filter.ToExpression()).ToList();

                    foreach (CIDADE item in ListModel)
                    {
                        dbs.Entry(item).State = EntityState.Deleted;
                        dbs.SaveChanges();
                    }
                }
                else
                {
                    if(MvcApplication.CidadePublic.Where(x => x.UKEY == ukey).Count() > 0)
                    {
                        CIDADE Model = MvcApplication.CidadePublic.Where(x => x.UKEY == ukey).First();
                        MvcApplication.CidadePublic.Remove(Model);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

    }
}