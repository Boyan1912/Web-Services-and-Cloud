﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhraseCountServiceClient.PhraseCountService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PhraseCountService.IPhraseCountable")]
    public interface IPhraseCountable {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPhraseCountable/GetCount", ReplyAction="http://tempuri.org/IPhraseCountable/GetCountResponse")]
        int GetCount(string phrase, string text);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPhraseCountable/GetCount", ReplyAction="http://tempuri.org/IPhraseCountable/GetCountResponse")]
        System.Threading.Tasks.Task<int> GetCountAsync(string phrase, string text);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPhraseCountableChannel : PhraseCountServiceClient.PhraseCountService.IPhraseCountable, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PhraseCountableClient : System.ServiceModel.ClientBase<PhraseCountServiceClient.PhraseCountService.IPhraseCountable>, PhraseCountServiceClient.PhraseCountService.IPhraseCountable {
        
        public PhraseCountableClient() {
        }
        
        public PhraseCountableClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PhraseCountableClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PhraseCountableClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PhraseCountableClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int GetCount(string phrase, string text) {
            return base.Channel.GetCount(phrase, text);
        }
        
        public System.Threading.Tasks.Task<int> GetCountAsync(string phrase, string text) {
            return base.Channel.GetCountAsync(phrase, text);
        }
    }
}
