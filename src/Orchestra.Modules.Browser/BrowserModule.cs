﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BrowserModule.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2012 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orchestra.Modules.Browser
{
    using System.Windows;
    using Catel;
    using Catel.Linq;
    using Catel.MVVM;
    using Models;
    using Services;
    using ViewModels;
    using Views;

    /// <summary>
    /// Browser module.
    /// </summary>
    public class BrowserModule : ModuleBase
    {
        /// <summary>
        /// The module name.
        /// </summary>
        public const string Name = "Browser";

        /// <summary>
        /// Initializes a new instance of the <see cref="BrowserModule"/> class. 
        /// </summary>
        public BrowserModule()
            : base(Name)
        {
        }

        /// <summary>
        /// Called when the module has been initialized.
        /// </summary>
        protected override void OnInitialized()
        {
            // var orchestraService = GetService<IOrchestraService>();
            // orchestraService.ShowDocument<BrowserViewModel>();
        }

        /// <summary>
        /// Initializes the ribbon.
        /// <para />
        /// Use this method to hook up views to ribbon items.
        /// </summary>
        /// <param name="ribbonService">The ribbon service.</param>
        protected override void InitializeRibbon(IRibbonService ribbonService)
        {
            var orchestraService = GetService<IOrchestraService>();

            // Module specific
            ribbonService.RegisterRibbonItem(new RibbonButton(HomeRibbonTabName, ModuleName, "Open", new Command(() => orchestraService.ShowDocument<BrowserViewModel>())) { ItemImage = "/Orchestra.Modules.Browser;component/Resources/Images/action_browse.png" });



            // View specific
            ribbonService.RegisterContextualRibbonItem<BrowserView>(new RibbonButton(Name, Name, "Back", "GoBack") { ItemImage = "/Orchestra.Modules.Browser;component/Resources/Images/action_left.png" }, ModuleName);
            ribbonService.RegisterContextualRibbonItem<BrowserView>(new RibbonButton(Name, Name, "Forward", "GoForward") { ItemImage = "/Orchestra.Modules.Browser;component/Resources/Images/action_right.png" }, ModuleName);
            ribbonService.RegisterContextualRibbonItem<BrowserView>(new RibbonButton(Name, Name, "Browse", "Browse") { ItemImage = "/Orchestra.Modules.Browser;component/Resources/Images/action_browse.png" }, ModuleName);
            ribbonService.RegisterContextualRibbonItem<BrowserView>(new RibbonComboBox(Name, "Recent Sites", null, "RecentSites", "SelectedSite")
            {
                Layout = new RibbonItemLayout { Width = 150 }
            }, ModuleName);

            // Find the template to show as dynamic content. TODO: Refactor, make more elegant.
            var template = Application.Current.Resources["TestTemplate"] as DataTemplate;

            ribbonService.RegisterContextualRibbonItem<BrowserView>(new RibbonContentControl(Name, "Dynamic content", "Test") { ContentTemplate = template }, ModuleName);

            // Demo: show two pages with different tags
            var orchestraViewModel = new BrowserViewModel("Orchestra") { Url = "http://www.github.com/Orcomp/Orchestra" };
            orchestraService.ShowDocument<BrowserViewModel>(orchestraViewModel, "orchestra");

            var catelViewModel = new BrowserViewModel("Catel") { Url = "http://www.catelproject.com" };
            orchestraService.ShowDocument<BrowserViewModel>(catelViewModel, "catel");
        }
    }
}