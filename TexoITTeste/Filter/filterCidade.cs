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

        public static Expression<Func<CIDADE, bool>> ToExpression(this CidadeFilterModel Filter)
        {
            Expression<Func<CIDADE, bool>> predicate = PredicateBuilder.True<CIDADE>();


            if (!string.IsNullOrEmpty(Filter.UKEY))
            {
                predicate = predicate.And(x => x.UKEY == Filter.UKEY);
                return predicate;
            }


            if (Filter.ibge != 0 && Filter.ibge != null)
            {
                predicate = predicate.And(x => x.CI_001_N == Filter.ibge);
            }

            if (!string.IsNullOrEmpty(Filter.Uf))
            {
                predicate = predicate.And(x => x.CI_002_C.Contains(Filter.Uf));
            }

            if (!string.IsNullOrEmpty(Filter.Cidade))
            {
                predicate = predicate.And(x => x.CI_003_C == Filter.Cidade);
            }

            if (Filter.Capital)
            {
                predicate = predicate.And(x => x.CI_004_L == Filter.Capital);
            }

            if (!string.IsNullOrEmpty(Filter.Longitude))
            {
                predicate = predicate.And(x => x.CI_005_C == Filter.Longitude);
            }

            if (!string.IsNullOrEmpty(Filter.Latitude))
            {
                predicate = predicate.And(x => x.CI_006_C == Filter.Latitude);
            }

            if (!string.IsNullOrEmpty(Filter.NomeSemAcento))
            {
                predicate = predicate.And(x => x.CI_007_C == Filter.NomeSemAcento);
            }

            if (!string.IsNullOrEmpty(Filter.NomeAlternativo))
            {
                predicate = predicate.And(x => x.CI_008_C == Filter.NomeAlternativo);
            }

            if (!string.IsNullOrEmpty(Filter.MicroRegiao))
            {
                predicate = predicate.And(x => x.CI_009_C == Filter.MicroRegiao);
            }

            if (!string.IsNullOrEmpty(Filter.RegiaoDistancia))
            {
                predicate = predicate.And(x => x.CI_010_C == Filter.RegiaoDistancia);
            }

            return predicate;
        }
    }
}