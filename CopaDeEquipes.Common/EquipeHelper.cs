using System;
using System.Collections.Generic;

namespace CopaDeEquipes.Common
{
    public class EquipeHelper
    {
        static IEnumerable<T> OrderBy(this IEnumerable<T> data)
        {
            return data.OrderBy(x => new string(x.Nome.Where(char.IsLetter).ToArray()))
                .ThenBy(x =>
                {
                    int number;
                    if (int.TryParse(new string(x.Nome.Where(char.IsDigit).ToArray()), out number))
                        return number;
                    return -1;
                }).ToList();
        }
    }
}
