﻿#pragma checksum "..\..\Conge_spec.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A9AD55F7A83B8F300F27C1C80E13A76105A6E06B"
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
    /// Conge_spec
    /// </summary>
    public partial class Conge_spec : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\Conge_spec.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button minimize;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Conge_spec.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button close;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Conge_spec.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock nom;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Conge_spec.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel form;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\Conge_spec.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox type_absence;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\Conge_spec.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker date_debut;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\Conge_spec.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker date_fin;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\Conge_spec.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid absenceTable;
        
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
            System.Uri resourceLocater = new System.Uri("/Absence;component/conge_spec.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Conge_spec.xaml"
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
            this.minimize = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\Conge_spec.xaml"
            this.minimize.Click += new System.Windows.RoutedEventHandler(this.minimize_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.close = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\Conge_spec.xaml"
            this.close.Click += new System.Windows.RoutedEventHandler(this.close_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.nom = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.form = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.type_absence = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.date_debut = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.date_fin = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            
            #line 41 "..\..\Conge_spec.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.editer);
            
            #line default
            #line hidden
            return;
            case 9:
            this.absenceTable = ((System.Windows.Controls.DataGrid)(target));
            
            #line 43 "..\..\Conge_spec.xaml"
            this.absenceTable.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.absence_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 60 "..\..\Conge_spec.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.supprimer);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
