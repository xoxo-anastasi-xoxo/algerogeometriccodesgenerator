﻿#pragma checksum "..\..\CodeGeneratingWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "302E5BF162EB733B12DF5E19A22614A2"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Генератор_алгеброгеометрических_кодов;


namespace Генератор_алгеброгеометрических_кодов {
    
    
    /// <summary>
    /// CodeGeneratingWindow
    /// </summary>
    public partial class CodeGeneratingWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\CodeGeneratingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox size;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\CodeGeneratingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox equations;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\CodeGeneratingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button previousWindowButton;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\CodeGeneratingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlock2;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\CodeGeneratingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button nextWindowButton;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\CodeGeneratingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button helpButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Генератор алгеброгеометрических кодов;component/codegeneratingwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CodeGeneratingWindow.xaml"
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
            this.size = ((System.Windows.Controls.ComboBox)(target));
            
            #line 36 "..\..\CodeGeneratingWindow.xaml"
            this.size.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SizeComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.equations = ((System.Windows.Controls.RichTextBox)(target));
            
            #line 58 "..\..\CodeGeneratingWindow.xaml"
            this.equations.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Equations_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.previousWindowButton = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\CodeGeneratingWindow.xaml"
            this.previousWindowButton.Click += new System.Windows.RoutedEventHandler(this.PreviousWindowButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.textBlock2 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.nextWindowButton = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\CodeGeneratingWindow.xaml"
            this.nextWindowButton.Click += new System.Windows.RoutedEventHandler(this.NextWindowButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.helpButton = ((System.Windows.Controls.Button)(target));
            
            #line 87 "..\..\CodeGeneratingWindow.xaml"
            this.helpButton.Click += new System.Windows.RoutedEventHandler(this.HelpButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

