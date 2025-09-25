using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Navistar.Utils.Core
{
    public class ValidaMail
    {
        /// <summary>
        /// Retorna verdadero si la cadena ingresada es un email valido
        /// </summary>
        /// <param name="single"></param>
        /// <returns></returns>
        public static bool ValidateEmail(string single)
        {
            Regex validate = new Regex(@"\b[a-zA-Z0-9_\-\.]+@[a-zA-Z0-9_\-\.]+\.[a-zA-Z]{2,5}\b");
            return validate.IsMatch(single);
        }

        /// <summary>
        /// Retorna verdadero si la cadena actual es una lista de correos v�lida
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool ValidateEmailList(string list)
        {
            //intentar verificar cuantas coincidencias se deben encontrar
            string[] myLenght = list.Split(new char[] { ',' });

            //validar
            Regex validate = new Regex(@"\b[a-zA-Z0-9_\-\.]+@[a-zA-Z0-9_\-\.]+\.[a-zA-Z]{2,5}\b");
            MatchCollection matches =
                validate.Matches(list);
            if (matches.Count == myLenght.Length)
            {
                return true;
            }
            return false;
        }
    }
}
