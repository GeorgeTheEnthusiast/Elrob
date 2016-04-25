﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Elrob.Terminal.ExcelServiceServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ImportDataRequest", Namespace="http://Elrob.Webservice/Dto")]
    [System.SerializableAttribute()]
    public partial class ImportDataRequest : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] FileBytesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FileNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] FileBytes {
            get {
                return this.FileBytesField;
            }
            set {
                if ((object.ReferenceEquals(this.FileBytesField, value) != true)) {
                    this.FileBytesField = value;
                    this.RaisePropertyChanged("FileBytes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FileName {
            get {
                return this.FileNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FileNameField, value) != true)) {
                    this.FileNameField = value;
                    this.RaisePropertyChanged("FileName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ImportDataResponse", Namespace="http://Elrob.Webservice/Dto")]
    [System.SerializableAttribute()]
    public partial class ImportDataResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Elrob.Terminal.ExcelServiceServiceReference.OrderContent[] OrderContentsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ResponseMessageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Elrob.Terminal.ExcelServiceServiceReference.OrderContent[] OrderContents {
            get {
                return this.OrderContentsField;
            }
            set {
                if ((object.ReferenceEquals(this.OrderContentsField, value) != true)) {
                    this.OrderContentsField = value;
                    this.RaisePropertyChanged("OrderContents");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ResponseMessage {
            get {
                return this.ResponseMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ResponseMessageField, value) != true)) {
                    this.ResponseMessageField = value;
                    this.RaisePropertyChanged("ResponseMessage");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OrderContent", Namespace="http://Elrob.Webservice/Dto")]
    [System.SerializableAttribute()]
    public partial class OrderContent : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DocumentNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<decimal> HeightField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Elrob.Terminal.ExcelServiceServiceReference.Material MaterialField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Elrob.Terminal.ExcelServiceServiceReference.Order OrderField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PackageQuantityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Elrob.Terminal.ExcelServiceServiceReference.Place PlaceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<decimal> ThicknessField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ToCompleteField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal UnitWeightField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<decimal> WidthField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DocumentNumber {
            get {
                return this.DocumentNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.DocumentNumberField, value) != true)) {
                    this.DocumentNumberField = value;
                    this.RaisePropertyChanged("DocumentNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> Height {
            get {
                return this.HeightField;
            }
            set {
                if ((this.HeightField.Equals(value) != true)) {
                    this.HeightField = value;
                    this.RaisePropertyChanged("Height");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Elrob.Terminal.ExcelServiceServiceReference.Material Material {
            get {
                return this.MaterialField;
            }
            set {
                if ((object.ReferenceEquals(this.MaterialField, value) != true)) {
                    this.MaterialField = value;
                    this.RaisePropertyChanged("Material");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Elrob.Terminal.ExcelServiceServiceReference.Order Order {
            get {
                return this.OrderField;
            }
            set {
                if ((object.ReferenceEquals(this.OrderField, value) != true)) {
                    this.OrderField = value;
                    this.RaisePropertyChanged("Order");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PackageQuantity {
            get {
                return this.PackageQuantityField;
            }
            set {
                if ((this.PackageQuantityField.Equals(value) != true)) {
                    this.PackageQuantityField = value;
                    this.RaisePropertyChanged("PackageQuantity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Elrob.Terminal.ExcelServiceServiceReference.Place Place {
            get {
                return this.PlaceField;
            }
            set {
                if ((object.ReferenceEquals(this.PlaceField, value) != true)) {
                    this.PlaceField = value;
                    this.RaisePropertyChanged("Place");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> Thickness {
            get {
                return this.ThicknessField;
            }
            set {
                if ((this.ThicknessField.Equals(value) != true)) {
                    this.ThicknessField = value;
                    this.RaisePropertyChanged("Thickness");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ToComplete {
            get {
                return this.ToCompleteField;
            }
            set {
                if ((this.ToCompleteField.Equals(value) != true)) {
                    this.ToCompleteField = value;
                    this.RaisePropertyChanged("ToComplete");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal UnitWeight {
            get {
                return this.UnitWeightField;
            }
            set {
                if ((this.UnitWeightField.Equals(value) != true)) {
                    this.UnitWeightField = value;
                    this.RaisePropertyChanged("UnitWeight");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> Width {
            get {
                return this.WidthField;
            }
            set {
                if ((this.WidthField.Equals(value) != true)) {
                    this.WidthField = value;
                    this.RaisePropertyChanged("Width");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Material", Namespace="http://Elrob.Webservice/Dto")]
    [System.SerializableAttribute()]
    public partial class Material : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Order", Namespace="http://Elrob.Webservice/Dto")]
    [System.SerializableAttribute()]
    public partial class Order : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Place", Namespace="http://Elrob.Webservice/Dto")]
    [System.SerializableAttribute()]
    public partial class Place : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://Elrob.Webservice/Services", ConfigurationName="ExcelServiceServiceReference.IExcelService")]
    public interface IExcelService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Elrob.Webservice/Services/IExcelService/ImportData", ReplyAction="http://Elrob.Webservice/Services/IExcelService/ImportDataResponse")]
        Elrob.Terminal.ExcelServiceServiceReference.ImportDataResponse ImportData(Elrob.Terminal.ExcelServiceServiceReference.ImportDataRequest importDataRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Elrob.Webservice/Services/IExcelService/ImportData", ReplyAction="http://Elrob.Webservice/Services/IExcelService/ImportDataResponse")]
        System.Threading.Tasks.Task<Elrob.Terminal.ExcelServiceServiceReference.ImportDataResponse> ImportDataAsync(Elrob.Terminal.ExcelServiceServiceReference.ImportDataRequest importDataRequest);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IExcelServiceChannel : Elrob.Terminal.ExcelServiceServiceReference.IExcelService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ExcelServiceClient : System.ServiceModel.ClientBase<Elrob.Terminal.ExcelServiceServiceReference.IExcelService>, Elrob.Terminal.ExcelServiceServiceReference.IExcelService {
        
        public ExcelServiceClient() {
        }
        
        public ExcelServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ExcelServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ExcelServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ExcelServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Elrob.Terminal.ExcelServiceServiceReference.ImportDataResponse ImportData(Elrob.Terminal.ExcelServiceServiceReference.ImportDataRequest importDataRequest) {
            return base.Channel.ImportData(importDataRequest);
        }
        
        public System.Threading.Tasks.Task<Elrob.Terminal.ExcelServiceServiceReference.ImportDataResponse> ImportDataAsync(Elrob.Terminal.ExcelServiceServiceReference.ImportDataRequest importDataRequest) {
            return base.Channel.ImportDataAsync(importDataRequest);
        }
    }
}
