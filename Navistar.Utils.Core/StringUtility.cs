using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Navistar.Utils.Core
{
    public class StringUtility
    {
        private readonly static Regex rgx = new Regex(@"[^0-9a-zA-Z.]+");

        private readonly static CultureInfo provider = default;
        private readonly static NumberStyles style =
            NumberStyles.AllowDecimalPoint |
            NumberStyles.AllowThousands |
            NumberStyles.AllowCurrencySymbol |
            NumberStyles.AllowExponent |
            NumberStyles.AllowLeadingSign |
            NumberStyles.AllowLeadingWhite |
            NumberStyles.AllowTrailingWhite |
            NumberStyles.AllowCurrencySymbol |
            NumberStyles.Float |
            NumberStyles.Integer;

        public static string EliminarBlancos(string valor)
        {
            return string.IsNullOrEmpty(valor) || string.IsNullOrWhiteSpace(valor) ? null : valor.Trim();
        }

        public static bool ValidarNuloVacioBlanco(string valor)
        {
            return string.IsNullOrEmpty(valor) || string.IsNullOrWhiteSpace(valor) ? true : false;
        }

        public static bool ValidarNombreArchivo(string valor)
        {
            if (string.IsNullOrEmpty(valor) || string.IsNullOrWhiteSpace(valor))
            {
                return false;
            }
            return !rgx.IsMatch(valor);
        }

        public static string LimpiarFiltroToIsNull(string valor)
        {
            valor ??= null;
            return valor.Trim().Equals("") ? null : ValidarFiltroBusqueda(valor.Trim());
        }

        public static string LimpiarFiltroPermitirCaracteres(string valor)
        {
            valor = valor != null ? valor.Trim() : string.Empty;
            return valor.Trim().ToLower().Equals("null") ? string.Empty : valor;
        }

        public static string LimpiarFiltro(string valor)
        {
            valor ??= string.Empty;
            return (valor.Trim().ToLower().Equals("null") || valor.Trim().ToLower().Equals("undefined")) ? string.Empty :
                   ValidarFiltroBusqueda(valor.Trim());

        }

        public static string EliminarCaracteresEspeciales(string valor)
        {
            return Regex.Replace(valor, @"[^0-9a-zA-Z:,\s]+", "");
        }

        public static string ValidarFiltroBusqueda(string valor)
        {
            return Regex.Replace(valor, @"[^0-9a-zA-ZáéíóúÁÉÍÓÚ|,.\s]+", "");
        }

        public static string ValidarNumeroLetraAcentoBlancoComaPuntos(string valor)
        {
            return Regex.Replace(valor, @"[^0-9a-zA-ZáéíóúÁÉÍÓÚ:#$Ññ,.\s]+", "");
        }

        public static string ValidarLetra(string valor)
        {
            string respuesta = Regex.Replace(valor, @"[^a-zA-Z]+", "");
            return EliminarBlancos(respuesta);
        }

        public static string ValidarLetraNumero(string valor)
        {
            string respuesta = Regex.Replace(valor, @"[^0-9a-zA-Z]+", "");
            return EliminarBlancos(respuesta);
        }

        public static string ValidarRutaArchivo(string valor)
        {
            valor = EliminarBlancos(valor);
            return valor == null ? null : Regex.Replace(valor, @"[^0-9a-zA-Z://\\.]+", "");
        }

        public static int ObtenerEnteroDeCadena(string valor)
        {
            try
            {
                if (!string.IsNullOrEmpty(valor))
                {
                    return Int32.Parse(valor);
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static Int64 ObtenerLongDeCadena(string valor)
        {
            try
            {
                if (!string.IsNullOrEmpty(valor))
                {
                    return Int64.Parse(valor);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }




        public static Double ObtenerDoubleDeCadena(string valor)
        {
            try
            {
                if (!string.IsNullOrEmpty(valor))
                {
                    return Double.Parse(valor);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static Decimal ObtenerDecimalDeCadena(string valor, String unidad)
        {
            try {
                valor = EliminarBlancos(valor);
                if (valor != null)
                {
                    if (valor.Contains("E"))
                    {
                        Decimal resultado = Decimal.Parse(valor, System.Globalization.NumberStyles.Float);
                        if (unidad != null && unidad.Trim().ToLower().Equals("porcentaje"))
                        {
                            resultado = resultado * 100;
                        }
                        return Decimal.Round(resultado, 2, MidpointRounding.ToEven);
                    }
                    else
                    {
                        Decimal resultado = Decimal.Parse(valor);
                        if (unidad != null && unidad.Trim().ToLower().Equals("porcentaje"))
                        {
                            resultado = resultado * 100;
                        }
                        return Decimal.Round(resultado, 2, MidpointRounding.ToEven);
                    }
                }
                else
                {
                    return 0;
                }
            } catch (Exception e) {
                return 0;
            }
        }

        public static bool ObtenerLogicoDeCadena(string valor)
        {
            try
            {
                if (!string.IsNullOrEmpty(valor))
                {
                    return ObtenerEnteroDeCadena(valor) > 0;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static DateTime? DarFormatoFecha(String fecha)
        {
            try
            {
                EliminarBlancos(fecha);
                if (fecha != null && !String.IsNullOrEmpty(fecha))
                {
                    DateTime filtro = DateTime.ParseExact(fecha, "yyyy-MM-dd", null);
                    return filtro;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static Decimal ObtenerDecimalDeCadenaLimpio(string valor)
        {
            if (valor != null)
            {
                return Decimal.Parse(valor, style, provider);
            }
            else
            {
                return 0;
            }
        }

        public static String RemoverDominio(String usuario)
        {
            EliminarBlancos(usuario);
            if (usuario == null)
            {
                return String.Empty;
            }

            String[] lista = usuario.Split("\\");
            if (lista != null && lista.Length == 0)
            {
                return String.Empty;
            }

            return lista.Length == 1 ? lista[0] : lista[1];

        }

        public static Int32 ObtenerCodigo(IList<String> distribuidores, Int32 codigo)
        {
            try
            {
                if(distribuidores == null || distribuidores.Count == 0)
                {
                    return 0;
                }
                return distribuidores.Contains(codigo.ToString()) ? codigo : 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static Int32 ObtenerFiltroCodigo(IList<String> distribuidores, Int32 codigo)
        {
            try
            {
                if (distribuidores == null || distribuidores.Count == 0)
                {
                    return 0;
                }
                return distribuidores.Contains(codigo.ToString()) ? codigo : ObtenerEnteroDeCadena(distribuidores[0]);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static Double ObtenerHorasRangoFechas (DateTime inicio, DateTime fin)
        {
            try
            {
                if (inicio == null || fin == null) { return 0; }
                TimeSpan ts = fin - inicio;
                return ts.TotalHours;
            } catch (Exception)
            {
                return 0;
            }
        }

        public static string ObtenerDecimal2Ceros(double myNumber)
        {
            var s = string.Format("{0:0.00}", myNumber);

            if (s.EndsWith("00"))
            {
                return ((int)myNumber).ToString();
            }
            else
            {
                return s;
            }
        }

        public static string FNacional(DateTime? fecha)
        {
            if (fecha != null)
            {
                string dia;
                string mes;
                string anio;

                dia = fecha.Value.Day.ToString();
                mes = fecha.Value.Month.ToString();
                anio = fecha.Value.Year.ToString();

                switch (mes)
                {
                    case "1": mes = "Enero"; break;
                    case "2": mes = "Febrero"; break;
                    case "3": mes = "Marzo"; break;
                    case "4": mes = "Abril"; break;
                    case "5": mes = "Mayo"; break;
                    case "6": mes = "Junio"; break;
                    case "7": mes = "Julio"; break;
                    case "8": mes = "Agosto"; break;
                    case "9": mes = "Septiembre"; break;
                    case "10": mes = "Octubre"; break;
                    case "11": mes = "Noviembre"; break;
                    case "12": mes = "Diciembre"; break;

                }

                return dia + "-" + mes + "-" + anio;
            }
            else {
                return String.Empty;
            }
        }

        public static string ObtenerCadenaBlanco(string valor)
        {
            return string.IsNullOrEmpty(valor) || string.IsNullOrWhiteSpace(valor) ? String.Empty : valor.Trim();
        }

        public static DateTime CalcularHoraEmision()
        {
            DateTime dPivot = DateTime.Now;
            int iMinute = dPivot.Minute;
            int minuteToAsign = 0;
            if (iMinute >= 0 && iMinute <= 14)
            {
                minuteToAsign = 0;
            }
            else if (iMinute >= 15 && iMinute <= 29)
            {
                minuteToAsign = 15;
            }
            else if (iMinute >= 30 && iMinute <= 44)
            {
                minuteToAsign = 30;
            }
            else if (iMinute >= 45)
            {
                minuteToAsign = 45;
            }

            DateTime dResult = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                DateTime.Now.Hour, minuteToAsign, 0);

            return dResult;
        }

        public static bool ObtenerBooleanoDeCadena(string valor)
        {
            try
            {
                if (!string.IsNullOrEmpty(valor))
                {
                    return (valor == "true");
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static String LimpiarFiltroNull(string valor)
        {
            valor ??= string.Empty;
            return (valor.Trim().ToLower().Equals("null") || valor.Trim().ToLower().Equals("undefined")) ? null :
                   ValidarFiltroBusqueda(valor.Trim());

        }

        public static String LimpiarVacioNull(string valor)
        {

            valor = LimpiarFiltroNull(valor);
            if (valor != null && String.Equals(valor, ""))
            {
                valor = null;
            }
            return valor;


        }

        public static String ObtenerCadenaDeLista(List<Int64> ids)
        {
            try
            {
                String cadena = "";
                foreach (Int64 id in ids)
                {
                    cadena = cadena == "" ? id.ToString() : cadena + "," + id.ToString();
                }
                return cadena;
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }


        public static String ObtenerCodigos(String codigo, bool origen)
        {
            try
            {
                if (codigo == null || String.IsNullOrEmpty(codigo.Trim()))
                {
                    return String.Empty;
                }
                string[] codigos = codigo.Split("-");
                if (codigos == null || codigos.Count() == 0)
                {
                    return String.Empty;
                }
                if (origen)
                {
                    return codigos[0];
                }
                else
                {
                    if (codigos.Count() > 1)
                    {
                        return codigos[1];
                    }
                    return String.Empty;
                }

            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

    }
}
