﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18046
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Collective.Console.ServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Item", Namespace="http://schemas.datacontract.org/2004/07/Collective.DataTransferObjects")]
    [System.SerializableAttribute()]
    public partial class Item : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ArtistIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ArtistNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ItemIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PhotoUrlField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime PublishingDateField;
        
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
        public int ArtistID {
            get {
                return this.ArtistIDField;
            }
            set {
                if ((this.ArtistIDField.Equals(value) != true)) {
                    this.ArtistIDField = value;
                    this.RaisePropertyChanged("ArtistID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ArtistName {
            get {
                return this.ArtistNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ArtistNameField, value) != true)) {
                    this.ArtistNameField = value;
                    this.RaisePropertyChanged("ArtistName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ItemID {
            get {
                return this.ItemIDField;
            }
            set {
                if ((this.ItemIDField.Equals(value) != true)) {
                    this.ItemIDField = value;
                    this.RaisePropertyChanged("ItemID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PhotoUrl {
            get {
                return this.PhotoUrlField;
            }
            set {
                if ((object.ReferenceEquals(this.PhotoUrlField, value) != true)) {
                    this.PhotoUrlField = value;
                    this.RaisePropertyChanged("PhotoUrl");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime PublishingDate {
            get {
                return this.PublishingDateField;
            }
            set {
                if ((this.PublishingDateField.Equals(value) != true)) {
                    this.PublishingDateField = value;
                    this.RaisePropertyChanged("PublishingDate");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetData", ReplyAction="http://tempuri.org/IService/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetData", ReplyAction="http://tempuri.org/IService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetItems", ReplyAction="http://tempuri.org/IService/GetItemsResponse")]
        Collective.Console.ServiceReference.Item[] GetItems();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetItems", ReplyAction="http://tempuri.org/IService/GetItemsResponse")]
        System.Threading.Tasks.Task<Collective.Console.ServiceReference.Item[]> GetItemsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : Collective.Console.ServiceReference.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<Collective.Console.ServiceReference.IService>, Collective.Console.ServiceReference.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public Collective.Console.ServiceReference.Item[] GetItems() {
            return base.Channel.GetItems();
        }
        
        public System.Threading.Tasks.Task<Collective.Console.ServiceReference.Item[]> GetItemsAsync() {
            return base.Channel.GetItemsAsync();
        }
    }
}
