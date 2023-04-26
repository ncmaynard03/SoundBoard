﻿#pragma checksum "..\..\AddSoundWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5A8B0E145FEB6277092439E442F694C975A77D39E2B15E7B7749BD05FC7DC7E6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SoundBoardWindow;
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


namespace SoundBoardWindow {
    
    
    /// <summary>
    /// AddSoundWindow
    /// </summary>
    public partial class AddSoundWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\AddSoundWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Name;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\AddSoundWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Path;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\AddSoundWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FindPathBtn;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\AddSoundWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TagTextbox;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\AddSoundWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\AddSoundWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel TagBtnStack;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\AddSoundWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ClearBtn;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\AddSoundWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SubmitBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/SoundBoardWindow;component/addsoundwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddSoundWindow.xaml"
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
            this.Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.Path = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.FindPathBtn = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\AddSoundWindow.xaml"
            this.FindPathBtn.Click += new System.Windows.RoutedEventHandler(this.SelectFile);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TagTextbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 38 "..\..\AddSoundWindow.xaml"
            this.TagTextbox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Add = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\AddSoundWindow.xaml"
            this.Add.Click += new System.Windows.RoutedEventHandler(this.Add_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TagBtnStack = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.ClearBtn = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\AddSoundWindow.xaml"
            this.ClearBtn.Click += new System.Windows.RoutedEventHandler(this.ClearBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.SubmitBtn = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\AddSoundWindow.xaml"
            this.SubmitBtn.Click += new System.Windows.RoutedEventHandler(this.SubmitBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

