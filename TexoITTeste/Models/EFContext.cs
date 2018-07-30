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
        public EFContext() : base("DefaultConnection") { }

        public DateTime getDateTimeNow()
        { 
            return this.Database.SqlQuery<DateTime>("select getdate()").FirstOrDefault<DateTime>();
        }
        #endregion
    }
}