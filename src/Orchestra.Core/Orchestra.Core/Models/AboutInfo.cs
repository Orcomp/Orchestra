﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AboutInfo.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2014 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Models
{
    using System.Reflection;
    using Catel.Data;

    public class AboutInfo : ModelBase
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="AboutInfo" /> class.
        /// </summary>
        /// <param name="logoImageSource">The logo image source.</param>
        /// <param name="url">The URL. Can be <c>null</c>.</param>
        /// <param name="assembly">The assembly to use for the information. If <c>null</c>, the assembly will be determined automatically.</param>
        public AboutInfo(string logoImageSource = null, string url = null, Assembly assembly = null)
        {
            LogoImageSource = logoImageSource;
            Url = url;
            Assembly = assembly ?? AssemblyHelper.GetEntryAssembly();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the logo image source.
        /// </summary>
        /// <value>The logo image source.</value>
        public string LogoImageSource { get; private set; }

        /// <summary>
        /// Gets the URL.
        /// </summary>
        /// <value>The URL.</value>
        public string Url { get; private set; }

        /// <summary>
        /// Gets the assembly.
        /// </summary>
        /// <value>The assembly.</value>
        public Assembly Assembly { get; private set; }
        #endregion
    }
}