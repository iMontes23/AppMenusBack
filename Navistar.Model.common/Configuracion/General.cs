using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Navistar.Model.common.Configuracion
{
    /// <summary>
    /// Clase que contiene los datos base para el correcto funcionamiento de la aplicación
    /// </summary>
    [NotMapped]
    public class General
    {
        /// <summary>
        /// Directorio en el servidor donde se almacenan los archivos
        /// </summary>
        public String RutaBase { get; set; }

        /// <summary>
        /// Tamaño máximo permitido para un archivo que se desea adjuntar en el sistema en (MB)
        /// </summary>
        public int TamanoMax { get; set; }

        /// <summary>
        /// Indica si el sistema debe enviar el correo
        /// </summary>
        public int EnviarCorreo { get; set; }

        /// <summary>
        /// Ruta del frontend (La ruta varia interna/externa)
        /// </summary>
        public String RutaApp { get; set; }

        /// <summary>
        /// Dirección de la vista donde se acepta o rechaza la solicitud de interrupción
        /// </summary>
        public String SolicitudInterrupcion { get; set; }

        public String SolicitudInterrupcionIndividual { get; set; }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public General() { }
    }
}
