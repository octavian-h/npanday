﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3603
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by wsdl, Version=2.0.50727.42.
// 
namespace webService {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="DiomedeStorageLegacyTransferSoap", Namespace="http://transfer.diomedestorage.com")]
    public partial class DiomedeStorageLegacyTransfer : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback UploadWithCreateFileOperationCompleted;
        
        private System.Threading.SendOrPostCallback CreateFileOperationCompleted;
        
        private System.Threading.SendOrPostCallback UploadOperationCompleted;
        
        /// <remarks/>
        public DiomedeStorageLegacyTransfer() {
            this.Url = "http://service.diomedestorage.com/diomedestoragelegacytransfer.asmx";
        }
        
        /// <remarks/>
        public event UploadWithCreateFileCompletedEventHandler UploadWithCreateFileCompleted;
        
        /// <remarks/>
        public event CreateFileCompletedEventHandler CreateFileCompleted;
        
        /// <remarks/>
        public event UploadCompletedEventHandler UploadCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://transfer.diomedestorage.com/UploadWithCreateFile", RequestNamespace="http://transfer.diomedestorage.com", ResponseNamespace="http://transfer.diomedestorage.com", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public UploadWithCreateFileResponse UploadWithCreateFile(LegacyUploadWithCreateFileRequest request) {
            object[] results = this.Invoke("UploadWithCreateFile", new object[] {
                        request});
            return ((UploadWithCreateFileResponse)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginUploadWithCreateFile(LegacyUploadWithCreateFileRequest request, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("UploadWithCreateFile", new object[] {
                        request}, callback, asyncState);
        }
        
        /// <remarks/>
        public UploadWithCreateFileResponse EndUploadWithCreateFile(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((UploadWithCreateFileResponse)(results[0]));
        }
        
        /// <remarks/>
        public void UploadWithCreateFileAsync(LegacyUploadWithCreateFileRequest request) {
            this.UploadWithCreateFileAsync(request, null);
        }
        
        /// <remarks/>
        public void UploadWithCreateFileAsync(LegacyUploadWithCreateFileRequest request, object userState) {
            if ((this.UploadWithCreateFileOperationCompleted == null)) {
                this.UploadWithCreateFileOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUploadWithCreateFileOperationCompleted);
            }
            this.InvokeAsync("UploadWithCreateFile", new object[] {
                        request}, this.UploadWithCreateFileOperationCompleted, userState);
        }
        
        private void OnUploadWithCreateFileOperationCompleted(object arg) {
            if ((this.UploadWithCreateFileCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UploadWithCreateFileCompleted(this, new UploadWithCreateFileCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://transfer.diomedestorage.com/CreateFile", RequestNamespace="http://transfer.diomedestorage.com", ResponseNamespace="http://transfer.diomedestorage.com", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public CreateFileResponse CreateFile(LegacyCreateFileRequest request) {
            object[] results = this.Invoke("CreateFile", new object[] {
                        request});
            return ((CreateFileResponse)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginCreateFile(LegacyCreateFileRequest request, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("CreateFile", new object[] {
                        request}, callback, asyncState);
        }
        
        /// <remarks/>
        public CreateFileResponse EndCreateFile(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((CreateFileResponse)(results[0]));
        }
        
        /// <remarks/>
        public void CreateFileAsync(LegacyCreateFileRequest request) {
            this.CreateFileAsync(request, null);
        }
        
        /// <remarks/>
        public void CreateFileAsync(LegacyCreateFileRequest request, object userState) {
            if ((this.CreateFileOperationCompleted == null)) {
                this.CreateFileOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCreateFileOperationCompleted);
            }
            this.InvokeAsync("CreateFile", new object[] {
                        request}, this.CreateFileOperationCompleted, userState);
        }
        
        private void OnCreateFileOperationCompleted(object arg) {
            if ((this.CreateFileCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CreateFileCompleted(this, new CreateFileCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://transfer.diomedestorage.com/Upload", RequestNamespace="http://transfer.diomedestorage.com", ResponseNamespace="http://transfer.diomedestorage.com", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void Upload(LegacyUploadRequest request) {
            this.Invoke("Upload", new object[] {
                        request});
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginUpload(LegacyUploadRequest request, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Upload", new object[] {
                        request}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndUpload(System.IAsyncResult asyncResult) {
            this.EndInvoke(asyncResult);
        }
        
        /// <remarks/>
        public void UploadAsync(LegacyUploadRequest request) {
            this.UploadAsync(request, null);
        }
        
        /// <remarks/>
        public void UploadAsync(LegacyUploadRequest request, object userState) {
            if ((this.UploadOperationCompleted == null)) {
                this.UploadOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUploadOperationCompleted);
            }
            this.InvokeAsync("Upload", new object[] {
                        request}, this.UploadOperationCompleted, userState);
        }
        
        private void OnUploadOperationCompleted(object arg) {
            if ((this.UploadCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UploadCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://transfer.diomedestorage.com")]
    public partial class LegacyUploadWithCreateFileRequest {
        
        /// <remarks/>
        public string sessionToken;
        
        /// <remarks/>
        public UploadWithCreateFileInfo uploadWithCreateFileInfo;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] content;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://transfer.diomedestorage.com")]
    public partial class UploadWithCreateFileInfo {
        
        /// <remarks/>
        public string fileName;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> totalLength;
        
        /// <remarks/>
        public string callbackAddress;
        
        /// <remarks/>
        public string hash;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://transfer.diomedestorage.com")]
    public partial class UploadInfo {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<long> fileID;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<long> offset;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> bufferLength;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<bool> isComplete;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://transfer.diomedestorage.com")]
    public partial class LegacyUploadRequest {
        
        /// <remarks/>
        public string sessionToken;
        
        /// <remarks/>
        public UploadInfo uploadInfo;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] content;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://transfer.diomedestorage.com")]
    public partial class CreateFileResponse {
        
        /// <remarks/>
        public long fileID;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://transfer.diomedestorage.com")]
    public partial class LegacyCreateFileRequest {
        
        /// <remarks/>
        public string sessionToken;
        
        /// <remarks/>
        public string fileName;
        
        /// <remarks/>
        public string callbackAddress;
        
        /// <remarks/>
        public string hash;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://transfer.diomedestorage.com")]
    public partial class UploadWithCreateFileResponse {
        
        /// <remarks/>
        public long fileID;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    public delegate void UploadWithCreateFileCompletedEventHandler(object sender, UploadWithCreateFileCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UploadWithCreateFileCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UploadWithCreateFileCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public UploadWithCreateFileResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((UploadWithCreateFileResponse)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    public delegate void CreateFileCompletedEventHandler(object sender, CreateFileCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CreateFileCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CreateFileCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public CreateFileResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((CreateFileResponse)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    public delegate void UploadCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}