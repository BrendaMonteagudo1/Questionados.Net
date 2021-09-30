﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace Questionados.Net.entities
{
 
    [Table("respuesta")] //Indica el nombre de la tabla
    public class Respuesta
    {
        [Key] //Indica que es primary Key
        [Column("respuesta_id")] //Indica el nombre de la columna en la db
        public int RespuestaId { get; set; }

        public string Texto { get; set; }

        [Column("es_correcta")]
        public bool EsCorrecta { get; set; }

        [JsonIgnore]
        [Column("pregunta_id")] //Esta columna actua como ForeignKey automagicamente
        public int PreguntaId { get; set; }

        //relacion uno a muchos automagicamente
        [JsonIgnore]
        public Pregunta Pregunta { get; set; }


    }
}
