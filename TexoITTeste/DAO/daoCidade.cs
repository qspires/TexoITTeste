using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TexoITTeste.Models;
using TexoITTeste.ViewModel;
using TexoITTeste.Filter;

namespace TexoITTeste.DAO
{
    public class daoCidade
    {
        EFContext dbs = new EFContext();

        public void Add(CIDADE Model)
        {
            dbs.Cidade.Add(Model);
            dbs.SaveChanges();
        }


        public void Update(CIDADE Model)
        {
            dbs.Entry(Model).State = EntityState.Modified;
            dbs.SaveChanges();
        }


        public CIDADE FindUfCidade(string uf, string cidade)
        {
            try
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
            catch(Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }


        public List<CIDADE> FindCidade(CidadeViewModel Filter)
        {
            try
            {
                List<CIDADE> ListModel = dbs.Cidade.Where(Filter.ToExpression()).ToList();
                return ListModel;
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
                List<CIDADE> ListModel = dbs.Cidade.Where(Filter.ToExpression()).ToList();
                return ListModel;
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
                List<CIDADE> ListModel = dbs.Cidade.ToList();
                return ListModel;
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
                CidadeViewModel Filter = new CidadeViewModel() { UKEY = ukey};

                List<CIDADE> ListModel = dbs.Cidade.Where(Filter.ToExpression()).ToList();

                foreach(CIDADE item in ListModel)
                {
                    dbs.Entry(item).State = EntityState.Deleted;
                    dbs.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

    }
}