﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataGridModule.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2012 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orchestra.Modules.DataGrid
{
    using Catel.MVVM;

    using Orchestra.Models;
    using Orchestra.Modules.DataGrid.ViewModels;
    using Orchestra.Modules.DataGrid.Views;
    using Orchestra.Services;

    /// <summary>
    /// The data grid module.
    /// </summary>
    public class DataGridModule : ModuleBase
    {
        #region Constants
        /// <summary>
        /// The module name.
        /// </summary>
        public const string Name = "DataGrid";
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridModule" /> class.
        /// </summary>
        public DataGridModule()
            : base(Name)
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// The on initialized.
        /// </summary>
        protected override void OnInitialized()
        {
            //var orchestraService = GetService<IOrchestraService>();
            //orchestraService.ShowDocument<DataGridViewModel>();
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
            ribbonService.RegisterRibbonItem(
                new RibbonItem(HomeRibbonTabName, ModuleName, "Open", new Command(() => orchestraService.ShowDocument<DataGridViewModel>()))
                {
                    ItemImage = "/Orchestra.Modules.DataGrid;component/Resources/Images/Table.png"
                });

            // View specific
            ribbonService.RegisterContextualRibbonItem<DataGridView>(
                new RibbonItem(Name, "File", "Open", "OpenFileCommand") { ItemImage = "/Orchestra.Library;component/Resources/Images/FileOpen.png" },
                ModuleName);
            ribbonService.RegisterContextualRibbonItem<DataGridView>(
                new RibbonItem(Name, "File", "Save", "SaveToFileCommand") { ItemImage = "/Orchestra.Library;component/Resources/Images/FileSave.png" },
                ModuleName);
            ribbonService.RegisterContextualRibbonItem<DataGridView>(
                new RibbonItem(Name, "Rows", "Add row", "AddRowCommand") { ItemImage = "/Orchestra.Library;component/Resources/Images/ActionAdd.png" },
                ModuleName);
            ribbonService.RegisterContextualRibbonItem<DataGridView>(
                new RibbonItem(Name, "Rows", "Remove row", "RemoveRowCommand") { ItemImage = "/Orchestra.Library;component/Resources/Images/ActionRemove.png" },
                ModuleName);
        }
        #endregion
    }
}