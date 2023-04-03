﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.269.
// 
#pragma warning disable 1591

namespace SBSCore.UpComGateway {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="GatewaySoap", Namespace="http://www.vics.com.vn")]
    public partial class Gateway : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetListForCancelOperationCompleted;
        
        private System.Threading.SendOrPostCallback CancelOrderOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetDayCanceledListOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetDayModifiedListOperationCompleted;
        
        private System.Threading.SendOrPostCallback ModifyOrderOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Gateway() {
            this.Url = global::SBSCore.Properties.Settings.Default.SBSCore_UpComGateway_Gateway;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetListForCancelCompletedEventHandler GetListForCancelCompleted;
        
        /// <remarks/>
        public event CancelOrderCompletedEventHandler CancelOrderCompleted;
        
        /// <remarks/>
        public event GetDayCanceledListCompletedEventHandler GetDayCanceledListCompleted;
        
        /// <remarks/>
        public event GetDayModifiedListCompletedEventHandler GetDayModifiedListCompleted;
        
        /// <remarks/>
        public event ModifyOrderCompletedEventHandler ModifyOrderCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vics.com.vn/GetListForCancel", RequestNamespace="http://www.vics.com.vn", ResponseNamespace="http://www.vics.com.vn", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public UpComMsgOrder[] GetListForCancel(string customerId, string stockCode, string orderside) {
            object[] results = this.Invoke("GetListForCancel", new object[] {
                        customerId,
                        stockCode,
                        orderside});
            return ((UpComMsgOrder[])(results[0]));
        }
        
        /// <remarks/>
        public void GetListForCancelAsync(string customerId, string stockCode, string orderside) {
            this.GetListForCancelAsync(customerId, stockCode, orderside, null);
        }
        
        /// <remarks/>
        public void GetListForCancelAsync(string customerId, string stockCode, string orderside, object userState) {
            if ((this.GetListForCancelOperationCompleted == null)) {
                this.GetListForCancelOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetListForCancelOperationCompleted);
            }
            this.InvokeAsync("GetListForCancel", new object[] {
                        customerId,
                        stockCode,
                        orderside}, this.GetListForCancelOperationCompleted, userState);
        }
        
        private void OnGetListForCancelOperationCompleted(object arg) {
            if ((this.GetListForCancelCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetListForCancelCompleted(this, new GetListForCancelCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vics.com.vn/CancelOrder", RequestNamespace="http://www.vics.com.vn", ResponseNamespace="http://www.vics.com.vn", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void CancelOrder(string orderNumber, string canceledBy) {
            this.Invoke("CancelOrder", new object[] {
                        orderNumber,
                        canceledBy});
        }
        
        /// <remarks/>
        public void CancelOrderAsync(string orderNumber, string canceledBy) {
            this.CancelOrderAsync(orderNumber, canceledBy, null);
        }
        
        /// <remarks/>
        public void CancelOrderAsync(string orderNumber, string canceledBy, object userState) {
            if ((this.CancelOrderOperationCompleted == null)) {
                this.CancelOrderOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCancelOrderOperationCompleted);
            }
            this.InvokeAsync("CancelOrder", new object[] {
                        orderNumber,
                        canceledBy}, this.CancelOrderOperationCompleted, userState);
        }
        
        private void OnCancelOrderOperationCompleted(object arg) {
            if ((this.CancelOrderCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CancelOrderCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vics.com.vn/GetDayCanceledList", RequestNamespace="http://www.vics.com.vn", ResponseNamespace="http://www.vics.com.vn", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public UpComMsgOrder[] GetDayCanceledList() {
            object[] results = this.Invoke("GetDayCanceledList", new object[0]);
            return ((UpComMsgOrder[])(results[0]));
        }
        
        /// <remarks/>
        public void GetDayCanceledListAsync() {
            this.GetDayCanceledListAsync(null);
        }
        
        /// <remarks/>
        public void GetDayCanceledListAsync(object userState) {
            if ((this.GetDayCanceledListOperationCompleted == null)) {
                this.GetDayCanceledListOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetDayCanceledListOperationCompleted);
            }
            this.InvokeAsync("GetDayCanceledList", new object[0], this.GetDayCanceledListOperationCompleted, userState);
        }
        
        private void OnGetDayCanceledListOperationCompleted(object arg) {
            if ((this.GetDayCanceledListCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetDayCanceledListCompleted(this, new GetDayCanceledListCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vics.com.vn/GetDayModifiedList", RequestNamespace="http://www.vics.com.vn", ResponseNamespace="http://www.vics.com.vn", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public UpComMsgOrder[] GetDayModifiedList() {
            object[] results = this.Invoke("GetDayModifiedList", new object[0]);
            return ((UpComMsgOrder[])(results[0]));
        }
        
        /// <remarks/>
        public void GetDayModifiedListAsync() {
            this.GetDayModifiedListAsync(null);
        }
        
        /// <remarks/>
        public void GetDayModifiedListAsync(object userState) {
            if ((this.GetDayModifiedListOperationCompleted == null)) {
                this.GetDayModifiedListOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetDayModifiedListOperationCompleted);
            }
            this.InvokeAsync("GetDayModifiedList", new object[0], this.GetDayModifiedListOperationCompleted, userState);
        }
        
        private void OnGetDayModifiedListOperationCompleted(object arg) {
            if ((this.GetDayModifiedListCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetDayModifiedListCompleted(this, new GetDayModifiedListCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vics.com.vn/ModifyOrder", RequestNamespace="http://www.vics.com.vn", ResponseNamespace="http://www.vics.com.vn", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void ModifyOrder(string orderNumber, decimal newPrice) {
            this.Invoke("ModifyOrder", new object[] {
                        orderNumber,
                        newPrice});
        }
        
        /// <remarks/>
        public void ModifyOrderAsync(string orderNumber, decimal newPrice) {
            this.ModifyOrderAsync(orderNumber, newPrice, null);
        }
        
        /// <remarks/>
        public void ModifyOrderAsync(string orderNumber, decimal newPrice, object userState) {
            if ((this.ModifyOrderOperationCompleted == null)) {
                this.ModifyOrderOperationCompleted = new System.Threading.SendOrPostCallback(this.OnModifyOrderOperationCompleted);
            }
            this.InvokeAsync("ModifyOrder", new object[] {
                        orderNumber,
                        newPrice}, this.ModifyOrderOperationCompleted, userState);
        }
        
        private void OnModifyOrderOperationCompleted(object arg) {
            if ((this.ModifyOrderCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ModifyOrderCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.vics.com.vn")]
    public partial class UpComMsgOrder {
        
        private string accountIdField;
        
        private string clOrdIDField;
        
        private string orderIDField;
        
        private decimal modiPriceField;
        
        /// <remarks/>
        public string AccountId {
            get {
                return this.accountIdField;
            }
            set {
                this.accountIdField = value;
            }
        }
        
        /// <remarks/>
        public string ClOrdID {
            get {
                return this.clOrdIDField;
            }
            set {
                this.clOrdIDField = value;
            }
        }
        
        /// <remarks/>
        public string OrderID {
            get {
                return this.orderIDField;
            }
            set {
                this.orderIDField = value;
            }
        }
        
        /// <remarks/>
        public decimal ModiPrice {
            get {
                return this.modiPriceField;
            }
            set {
                this.modiPriceField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetListForCancelCompletedEventHandler(object sender, GetListForCancelCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetListForCancelCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetListForCancelCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public UpComMsgOrder[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((UpComMsgOrder[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void CancelOrderCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetDayCanceledListCompletedEventHandler(object sender, GetDayCanceledListCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetDayCanceledListCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetDayCanceledListCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public UpComMsgOrder[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((UpComMsgOrder[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetDayModifiedListCompletedEventHandler(object sender, GetDayModifiedListCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetDayModifiedListCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetDayModifiedListCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public UpComMsgOrder[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((UpComMsgOrder[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void ModifyOrderCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}

#pragma warning restore 1591