using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace balaban.DAL
{
    public static class Utility
    {
        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> pCol)
        {
            List<T> lResultado = new List<T>();
            List<T> lLista = pCol.ToList();
            Random lRandom = new Random();
            int lintPos = 0;

            while (lLista.Count > 0)
            {
                lintPos = lRandom.Next(lLista.Count);
                lResultado.Add(lLista[lintPos]);
                lLista.RemoveAt(lintPos);
            }

            return lResultado;
        }
    }
}