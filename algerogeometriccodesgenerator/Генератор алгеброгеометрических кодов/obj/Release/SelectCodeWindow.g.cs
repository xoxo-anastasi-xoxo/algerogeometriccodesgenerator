﻿#pragma checksum "..\..\SelectCodeWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DF8D2A3256D0F4A62D2E02040594E3EA"
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
    /// SelectCodeWindow
    /// </summary>
    public partial class SelectCodeWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\SelectCodeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Генератор_алгеброгеометрических_кодов.SelectCodeWindow win1;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\SelectCodeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label mainLabel;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\SelectCodeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox codeSelector;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\SelectCodeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button previousWindowButton;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\SelectCodeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button trashButton;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\SelectCodeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button nextWindowButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Генератор алгеброгеометрических кодов;component/selectcodewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SelectCodeWindow.xaml"
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
            this.win1 = ((Генератор_алгеброгеометрических_кодов.SelectCodeWindow)(target));
            return;
            case 2:
            this.mainLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.codeSelector = ((System.Windows.Controls.ComboBox)(target));
            
            #line 30 "..\..\SelectCodeWindow.xaml"
            this.codeSelector.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.codeSelectorComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.previousWindowButton = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\SelectCodeWindow.xaml"
            this.previousWindowButton.Click += new System.Windows.RoutedEventHandler(this.previousWindowButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.trashButton = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\SelectCodeWindow.xaml"
            this.trashButton.Click += new System.Windows.RoutedEventHandler(this.trashButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.nextWindowButton = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\SelectCodeWindow.xaml"
            this.nextWindowButton.Click += new System.Windows.RoutedEventHandler(this.nextWindowButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

