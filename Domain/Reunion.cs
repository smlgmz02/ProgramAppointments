using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace GestionReuniones.Domain
{
    public class Reunion
    {
        [BsonId]
        public ObjectId IdMongo { get; set; }

        [BsonElement("id_reunion")]
        public int IdReunion { get; set; }

        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonElement("motivo")]
        public string Motivo { get; set; }

        [BsonElement("fecha_inicio")]
        public DateTime FechaInicio { get; set; }

        [BsonElement("fecha_fin")]
        public DateTime FechaFin { get; set; }

        [BsonElement("participantes_ids")]
        public List<int> ParticipantesIds { get; set; } = new List<int>();
    }
}