﻿#pragma checksum "..\..\AddOwner.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "44274F08E664FCA69BBE2CFB8425BBF8B8F8DAE1499C535759C3D546506D1083"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Gibdd;
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


namespace Gibdd {
    
    
    /// <summary>
    /// AddOwner
    /// </summary>
    public partial class AddOwner : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\AddOwner.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox fioOwnerTextBox;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\AddOwner.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox phoneNumberTextBox;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\AddOwner.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox addressTextBox;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\AddOwner.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameCompanyTextBox;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\AddOwner.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox innTextBox;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\AddOwner.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox districtTextBox;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\AddOwner.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addOwnerButton;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\AddOwner.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton indOwnerRadioButton;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\AddOwner.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton entityOwnerRadioButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Gibdd;component/addowner.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddOwner.xaml"
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
            this.fioOwnerTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.phoneNumberTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.addressTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.nameCompanyTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.innTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.districtTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.addOwnerButton = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\AddOwner.xaml"
            this.addOwnerButton.Click += new System.Windows.RoutedEventHandler(this.AddOwnerButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.indOwnerRadioButton = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 9:
            this.entityOwnerRadioButton = ((System.Windows.Controls.RadioButton)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

