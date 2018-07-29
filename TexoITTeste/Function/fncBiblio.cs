using System;
using System.ComponentModel.DataAnnotations;

namespace TexoITTeste.Function
{
    public static class fncBiblio
    {
        public static string GetUkey()
        {
            //var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            //var random = new Random();
            //var result = new string(
            //    Enumerable.Repeat(chars, 20)
            //              .Select(s => s[random.Next(s.Length)])
            //              .ToArray());

            Guid guid = Guid.NewGuid();
            string result = guid.ToString().Replace("-", "").ToString().Substring(0, 19);

            return result;
        }
    }
}