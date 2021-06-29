using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GtfsEngine.Entities
{
    public class Calendar
    {
        /// <summary>
        /// Définit de façon unique les dates auxquelles le service est disponible pour un 
        /// ou plusieurs itinéraires. Chaque valeur du champ service_id peut apparaître 
        /// au maximum une fois dans un fichier calendar.txt.
        /// </summary>
        public string service_id { get; set; }

        /// <summary>
        /// Indique si le service est proposé tous les lundis de la plage de dates 
        /// spécifiée par les champs start_date et end_date. Sachez que vous pouvez 
        /// répertorier des exceptions pour des dates particulières dans le fichier calendar_dates.txt. 
        /// Les options suivantes sont acceptées :
        /// 1 : le service est disponible tous les lundis de la plage de dates.
        /// 0 : le service n'est pas disponible les lundis de la plage de dates.
        /// </summary>
        public short monday { get; set; }

        /// <summary>
        /// Fonctionne comme le champ monday, mais pour les mardis.
        /// </summary>
        public short tuesday { get; set; }

        /// <summary>
        /// Fonctionne comme le champ monday, mais pour les mercredi.
        /// </summary>
        public short wednesday { get; set; }

        /// <summary>
        /// Fonctionne comme le champ monday, mais pour les jeudi.
        /// </summary>
        public short thursday { get; set; }

        /// <summary>
        /// Fonctionne comme le champ monday, mais pour les vendredi.
        /// </summary>
        public short friday { get; set; }

        /// <summary>
        /// Fonctionne comme le champ monday, mais pour les samedi.
        /// </summary>
        public short saturday { get; set; }

        /// <summary>
        /// Fonctionne comme le champ monday, mais pour les dimanche.
        /// </summary>
        public short sunday { get; set; }

        /// <summary>
        /// Date de début du service.
        /// format : 20211031 -- AAAAmmJJ
        /// </summary>
        public string start_date { get; set; }

        /// <summary>
        /// Date de fin du service (date incluse dans la période de service).
        /// format : 20211031 -- AAAAmmJJ
        /// </summary>
        public string end_date { get; set; }



        public DateTime StarTime 
        { 
            get
			{
                return Tools.ConvertToDateTime(start_date);
			} 
        }

        public DateTime EndTime
        {
            get
            {
                return Tools.ConvertToDateTime(end_date);
            }
        }



	}
}
