﻿#pragma checksum "..\..\CustomisationWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E691FF744EF954B975339FF9DF08C54CDA30CDBA13EBF919D5D9864CADC0D1DF"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Dino_Park_2._0;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Dino_Park_2._0 {
    
    
    /// <summary>
    /// CustomisationWindow
    /// </summary>
    public partial class CustomisationWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\CustomisationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Dino_Park_2._0.CustomisationWindow Customisation;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\CustomisationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl CustomisationCharacters;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\CustomisationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem DinoTabItem;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\CustomisationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid DinoCustomGrid;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\CustomisationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem OctopusTabItem;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\CustomisationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid OctopusCustonGrid;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\CustomisationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem ItemTabItem;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\CustomisationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ItemCustomGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Dino Park 2.0;component/customisationwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CustomisationWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Customisation = ((Dino_Park_2._0.CustomisationWindow)(target));
            
            #line 8 "..\..\CustomisationWindow.xaml"
            this.Customisation.Closing += new System.ComponentModel.CancelEventHandler(this.Customisation_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CustomisationCharacters = ((System.Windows.Controls.TabControl)(target));
            
            #line 13 "..\..\CustomisationWindow.xaml"
            this.CustomisationCharacters.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CustomisationCharacterSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DinoTabItem = ((System.Windows.Controls.TabItem)(target));
            
            #line 14 "..\..\CustomisationWindow.xaml"
            this.DinoTabItem.MouseLeave += new System.Windows.Input.MouseEventHandler(this.MakeTabItemForegroundWhite);
            
            #line default
            #line hidden
            
            #line 14 "..\..\CustomisationWindow.xaml"
            this.DinoTabItem.MouseEnter += new System.Windows.Input.MouseEventHandler(this.MakeTabItemForegroundRed);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DinoCustomGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.OctopusTabItem = ((System.Windows.Controls.TabItem)(target));
            
            #line 21 "..\..\CustomisationWindow.xaml"
            this.OctopusTabItem.MouseEnter += new System.Windows.Input.MouseEventHandler(this.MakeTabItemForegroundRed);
            
            #line default
            #line hidden
            
            #line 21 "..\..\CustomisationWindow.xaml"
            this.OctopusTabItem.MouseLeave += new System.Windows.Input.MouseEventHandler(this.MakeTabItemForegroundWhite);
            
            #line default
            #line hidden
            return;
            case 6:
            this.OctopusCustonGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.ItemTabItem = ((System.Windows.Controls.TabItem)(target));
            
            #line 28 "..\..\CustomisationWindow.xaml"
            this.ItemTabItem.MouseEnter += new System.Windows.Input.MouseEventHandler(this.MakeTabItemForegroundRed);
            
            #line default
            #line hidden
            
            #line 28 "..\..\CustomisationWindow.xaml"
            this.ItemTabItem.MouseLeave += new System.Windows.Input.MouseEventHandler(this.MakeTabItemForegroundWhite);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ItemCustomGrid = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
