using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using ProtoBuf.Grpc;
using System.ServiceModel;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;

namespace DataView2.Core.Models
{
    [DataContract]
    public class Persona
    {
        [DataMember(Order = 1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPersona { get; set; }

        [DataMember(Order = 2)]
        public string Nombres { get; set; }

        [DataMember(Order = 3)]
        public string Apellidos { get; set; }

        [DataMember(Order = 4)]
        public string Email { get; set; }
    }

    [DataContract]
    public class IdReply
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public string Message { get; set; }
    }

    [ServiceContract]
    public interface ISettingsService
    {
        [OperationContract]
        Task<IdReply> Create(Persona request,
            CallContext context = default);

        [OperationContract]
        Task<List<Persona>> GetAll(Empty empty,
            CallContext context = default);

        [OperationContract]
        Task<Persona> EditValue(Persona request,
            CallContext context = default);
        [OperationContract]
        Task DelValue(string request,
            CallContext context = default);


    }

    public enum SettingType
    {
        Integer,
        Float,
        String
    }
}
