﻿#pragma checksum "..\..\Archive.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AB9008109BBBEA838576FF84BF5897B39BA2B48A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using Absence;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace Absence {
    
    
    /// <summary>
    /// Archive
    /// </summary>
    public partial class Archive : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 31 "..\..\Archive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button close;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\Archive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border infoCard;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\Archive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image photo;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\Archive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock matricule;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\Archive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock nom;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\Archive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock code_affectation;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\Archive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock affectation;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\Archive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock code_fonction;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\Archive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock fonction;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\Archive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox filter;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\Archive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid personTable;
        
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
            System.Uri resourceLocater = new System.Uri("/Absence;component/archive.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Archive.xaml"
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
            this.close = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\Archive.xaml"
            this.close.Click += new System.Windows.RoutedEventHandler(this.close_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 37 "..\..\Archive.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.refresh_click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.infoCard = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            this.photo = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.matricule = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.nom = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.code_affectation = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.affectation = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.code_fonction = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.fonction = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.filter = ((System.Windows.Controls.TextBox)(target));
            
            #line 68 "..\..\Archive.xaml"
            this.filter.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.filter_TextChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            this.personTable = ((System.Windows.Controls.DataGrid)(target));
            
            #line 70 "..\..\Archive.xaml"
            this.personTable.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.person_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 89 "..\..\Archive.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Conge_spec);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 91 "..\..\Archive.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Editer);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 13:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Control.MouseDoubleClickEvent;
            
            #line 84 "..\..\Archive.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.Row_DoubleClick);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}

