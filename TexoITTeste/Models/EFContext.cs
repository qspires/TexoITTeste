using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TexoITTeste.ViewModel;


namespace TexoITTeste.Models
{
    public class EFContext : DbContext
    {


        #region Models
        public DbSet<CIDADE> Cidade { get; set; }
        #endregion

        #region Configuracao EntityFrameWork Connect
        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        //public EFContext() : base("TexoITTeste.Properties.Settings.DBConnect") { }
        public EFContext() : base("Teste") { }
        public DateTime getDateTimeNow()
        { 
            return this.Database.SqlQuery<DateTime>("select getdate()").FirstOrDefault<DateTime>();
        }

        public bool Connexao()
        {
            try
            {
                //bool conexao = this.Database.Exists();
                bool conexao = this.Database.Connection.State == System.Data.ConnectionState.Open;

                return conexao;
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
                return false;
            }
        }
        #endregion
    }
}