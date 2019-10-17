using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace GStackPlayer.Models
{
    /// <summary>
    /// Handles app file operations
    /// </summary>
    class StorageModel
    {
        /// <summary>
        /// Singleton instance
        /// </summary>
        private static StorageModel Instance { get; set; }

        /// <summary>
        /// Stores application state, used also for exporting playlists
        /// </summary>
        private ApplicationDataCompositeValue Storage;
        /// <summary>
        /// Stores app settings
        /// </summary>
        private ApplicationDataCompositeValue Settings;
        /// <summary>
        /// Stores tutorial tooltips tht have been show/closed
        /// </summary>
        private IList<string> TutorialTooltips;
        /// <summary>
        /// Creates a StorageModel instance and initializes storage data
        /// </summary>
        /// <param name="nullAuth">Method ovarload differentiation, unused</param>
        private StorageModel(object nullAuth)
        {
            ApplicationDataContainer applicationData = ApplicationData.Current.RoamingSettings;
            this.Storage = (ApplicationDataCompositeValue)applicationData.Values["storage"];
            this.Settings = (ApplicationDataCompositeValue)applicationData.Values["settings"];
            this.TutorialTooltips = (IList<string>)applicationData.Values["tutorial"];
        }
        /// <summary>
        /// Forbids creation of new instances
        /// </summary>
        public StorageModel()
        {
            throw new InvalidOperationException("Cannot call constructor on Singleton. Use StorageModel.GetInstance() instead.");
        }
        /// <summary>
        /// Singleton access method
        /// </summary>
        /// <returns></returns>
        internal static StorageModel GetInstance()
        {
            if (Instance == null) Instance = new StorageModel(null);
            return Instance;
        }
        /// <summary>
        /// Saves current state of application
        /// </summary>
        internal void SaveCurrentState()
        {
            // TODO: Save current app state to file
            
            throw new NotImplementedException();
        }
    }
}
