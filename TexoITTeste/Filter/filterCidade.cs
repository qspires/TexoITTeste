using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TexoITTeste.Function;
using TexoITTeste.Models;
using TexoITTeste.ViewModel;

namespace TexoITTeste.Filter
{
    public static class filterCidade
    {
        public static Expression<Func<CIDADE, bool>> ToExpression(this CidadeViewModel Filter)
        {
            Expression<Func<CIDADE, bool>> predicate = PredicateBuilder.True<CIDADE>();


            if (!string.IsNullOrEmpty(Filter.UKEY))
            {
                predicate = predicate.And(x => x.UKEY == Filter.UKEY);
                return predicate;
            }

            if (Filter.Tipo == fncEnum.eOperacao.Contido)
            {
                if (Filter.CI_001_N != 0 && Filter.CI_001_N != null)
                {
                    predicate = predicate.And(x => x.CI_001_N.ToString().Contains(Filter.CI_001_N.ToString()));
                }

                if (!string.IsNullOrEmpty(Filter.CI_002_C))
                {
                    predicate = predicate.And(x => x.CI_002_C.Contains(Filter.CI_002_C));
                }

                if (!string.IsNullOrEmpty(Filter.CI_003_C))
                {
                    predicate = predicate.And(x => x.CI_003_C.Contains(Filter.CI_003_C));
                }

                if (!string.IsNullOrEmpty(Filter.CI_003_C))
                {
                    predicate = predicate.And(x => x.CI_003_C.Contains(Filter.CI_003_C));
                }
            }
            else if (Filter.Tipo == fncEnum.eOperacao.Igual)
            {

                if (Filter.CI_001_N != 0 && Filter.CI_001_N != null)
                {
                    predicate = predicate.And(x => x.CI_001_N == Filter.CI_001_N);
                }

                if (!string.IsNullOrEmpty(Filter.CI_002_C))
                {
                    predicate = predicate.And(x => x.CI_002_C == Filter.CI_002_C);
                }

                if (!string.IsNullOrEmpty(Filter.CI_003_C))
                {
                    predicate = predicate.And(x => x.CI_003_C == Filter.CI_003_C);
                }

                if (!string.IsNullOrEmpty(Filter.CI_003_C))
                {
                    predicate = predicate.And(x => x.CI_003_C == Filter.CI_003_C);
                }
            }

            if (Filter.CI_004_N != fncEnum.eCapital.Ambos)
            {
                if (Filter.CI_004_N == fncEnum.eCapital.Sim)
                {
                    predicate = predicate.And(x => x.CI_004_L == true);
                }
                else
                {
                    predicate = predicate.And(x => x.CI_004_L == false);
                }
              
            }

            return predicate;
        }
    }
}