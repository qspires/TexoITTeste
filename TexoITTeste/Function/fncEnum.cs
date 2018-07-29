using System.ComponentModel.DataAnnotations;

namespace TexoITTeste.Function
{

    public class fncEnum
    {
        public enum eCapital : int
        {
            Não = 0,
            Sim = 1,
            Ambos = 2
        }

        public enum eOperacao : int
        {
            Igual = 0,
            Contido = 1
        }
    }
}