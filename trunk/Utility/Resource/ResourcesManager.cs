using System;
using System.Resources;

namespace EzPos.Utility
{
    /// <summary>
    /// This clas provides resource access mehods for this module.
    /// </summary>
    public class ResourcesManager
    {
        private static ResourceManager applicationResources;
        private static ResourceManager messageResources;

        /// <summary>
        /// Loads message string from <c>ApplicationResources.resx</c>.
        /// </summary>
        /// <param name="resourceKey">resource identifier.</param>
        /// <returns>An application resource or <c>null</c> if there's no such application resource.</returns>
        public static string GetApplicationResource(string resourceKey)
        {
            Type type = typeof (ResourcesManager);
            if (applicationResources == null)
                applicationResources = new ResourceManager(type.Namespace + ".Resource." + "ApplicationResources",
                                                           type.Assembly);
            return applicationResources.GetString(resourceKey);
        }

        /// <summary>
        /// Loads message string from <c>MessageResources.resx</c>.
        /// </summary>
        /// <param name="resourceKey">resource identifier.</param>
        /// <returns>A message resource or <c>null</c> if there's no such application resource.</returns>
        public static string GetMessageResource(string resourceKey)
        {
            Type type = typeof (ResourcesManager);
            if (messageResources == null)
                messageResources = new ResourceManager(type.Namespace + ".Resource." + "MessageResources", type.Assembly);
            return messageResources.GetString(resourceKey);
        }
    }
}