using System;
using System.Collections.Generic;
using System.Text;

namespace GtfsEngine.Entities
{
    public class CalendarDates
    {
        /// <summary>
        /// Définit les dates auxquelles le service est exceptionnellement disponible 
        /// pour un ou plusieurs itinéraires. Chaque paire (service_id, date) ne peut 
        /// apparaître qu'une seule fois dans le fichier calendar_dates.txt si vous 
        /// utilisez conjointement calendar.txt et calendar_dates.txt. Si la même valeur 
        /// service_id apparaît dans les fichiers calendar.txt et calendar_dates.txt, les 
        /// informations contenues dans le fichier calendar_dates.txt modifient celles 
        /// indiquées pour le service dans le fichier calendar.txt.
        /// </summary>
        public string service_id { get; set; }

        /// <summary>
        /// Date à laquelle le service proposé est différent du service standard.
        /// format : 20211031 -- AAAAmmJJ
        /// </summary>
        public string date { get; set; }

        /// <summary>
        /// Indique si le service est disponible à la date spécifiée dans le champ date. 
        /// Les options suivantes sont acceptées :
        /// 1 : le service a été ajouté pour la date spécifiée.
        /// 2 : le service a été supprimé pour la date spécifiée.
        /// </summary>
        public short exception_type { get; set; }




        public DateTime Date
		{
            get
			{
                return Tools.ConvertToDateTime(date);
			}
		}
    }
}
