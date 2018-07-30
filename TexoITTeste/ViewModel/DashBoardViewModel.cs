using System.Collections.Generic;

namespace TexoITTeste.ViewModel
{
    public class DashBoardViewModel
    {
        public List<CidadesPorEstado> CidadesPorEstado { get; set; } //
        public List<CidadesPorEstado> EstadoMaiorMenor { get; set; } //
        public List<Capitais> Capitais { get; set; } //
        public int Total { get; set; } //

        public DashBoardViewModel()
        {
            this.CidadesPorEstado = new List<CidadesPorEstado>();
            this.Capitais = new List<Capitais>();
            this.EstadoMaiorMenor = new List<CidadesPorEstado>();
        }
    }

    public class CidadesPorEstado
    {
        public string Estado { get; set; } //
        public int Total { get; set; } //
    }

    public class Capitais
    {
        public string Estado { get; set; } //
        public string Cidade { get; set; } //
    }
}