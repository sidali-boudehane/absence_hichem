﻿#pragma checksum "..\..\AjouterClient.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B547E3BD96452C629E5CA2B939383BF3F941499B"
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
    /// ajouterClient
    /// </summary>
    public partial class ajouterClient : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\AjouterClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button minimize;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\AjouterClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button close;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\AjouterClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox matricule;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\AjouterClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nom;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\AjouterClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox code_affect;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\AjouterClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox affectation;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\AjouterClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox code_fonct;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\AjouterClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox fonction;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\AjouterClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox etat;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\AjouterClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox adresse;
        
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
            System.Uri resourceLocater = new System.Uri("/Absence;component/ajouterclient.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AjouterClient.xaml"
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
            
            #line 20 "..\..\AjouterClient.xaml"
            this.minimize.Click += new System.Windows.RoutedEventHandler(this.minimize_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.close = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\AjouterClient.xaml"
            this.close.Click += new System.Windows.RoutedEventHandler(this.close_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.matricule = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.nom = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.code_affect = ((System.Windows.Controls.TextBox)(target));
            
            #line 32 "..\..\AjouterClient.xaml"
            this.code_affect.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.code_affect_textchanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.affectation = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.code_fonct = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\AjouterClient.xaml"
            this.code_fonct.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.code_fonct_textchanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.fonction = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.etat = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.adresse = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            
            #line 47 "..\..\AjouterClient.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ajouter_element);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

