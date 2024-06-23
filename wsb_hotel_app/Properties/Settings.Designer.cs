// ***********************************************************************
// Assembly         : wsb_hotel_app
// Author           : plowi
// Created          : 06-08-2024
//
// Last Modified By : plowi
// Last Modified On : 06-08-2024
// ***********************************************************************
// <copyright file="Settings.Designer.cs" company="">
//     Copyright ©  2024
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace wsb_hotel_app.Properties
{


    /// <summary>
    /// Class Settings. This class cannot be inherited.
    /// Implements the <see cref="System.Configuration.ApplicationSettingsBase" />
    /// </summary>
    /// <seealso cref="System.Configuration.ApplicationSettingsBase" />
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase
    {

        /// <summary>
        /// The default instance
        /// </summary>
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));

        /// <summary>
        /// Gets the default.
        /// </summary>
        /// <value>The default.</value>
        public static Settings Default
        {
            get
            {
                return defaultInstance;
            }
        }
    }
}
