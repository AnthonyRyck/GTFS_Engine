namespace GtfsEngine.Entities
{
    public partial class Transfer
    {
        /// <summary>
        /// ID de l'arrêt
        /// </summary>
        public string from_stop_id { get; set; }
        
        /// <summary>
        /// Id de l'arrêt
        /// </summary>
        public string to_stop_id { get; set; }
        
        /// <summary>
        /// Type de transfert
        /// </summary>
        public string transfer_type { get; set; }
        
        /// <summary>
        /// Temps minimal du transfert
        /// </summary>
        public int min_transfer_time { get; set; }
    }
}