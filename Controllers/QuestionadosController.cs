﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Questionados.Net.entities;
using Questionados.Net.Models.Request;
using Questionados.Net.Models.Response;
using Questionados.Net.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionados.Net.Controllers
{
    [Microsoft.AspNetCore.Components.Route("questionados")]
    [ApiController]
    public class QuestionadosController : ControllerBase
    {
        private readonly ILogger<QuestionadosController> _logger;
        private QuestionadosService _service;

        public QuestionadosController(ILogger<QuestionadosController> logger, QuestionadosService questionadoService)
        {
            _logger = logger;
            _service = questionadoService;

        }

        [HttpGet("next")]
        public ActionResult<List<PreguntaAResolver>> traerPreguntaRandom()
        {

            Pregunta pregunta = _service.TraerPreguntaRandom();

            PreguntaAResolver preguntaAResolver = PreguntaAResolver.ConvertirDesde(pregunta);

            return Ok(preguntaAResolver);


        }

        [HttpPost("verificaciones")]
        public ActionResult<RespuestaVerificada> verificarRespuesta([FromBody] RespuestaAVerificar respuestaAVerificar)
        {

            RespuestaVerificada respuestaVerificada = new RespuestaVerificada();
            if (_service.VerificarRespuesta(respuestaAVerificar.PreguntaId, respuestaAVerificar.RespuestaId))
            {
                respuestaVerificada.EsCorrecta = true;
            }
            else
            {
                respuestaVerificada.EsCorrecta = false;
            }

            return Ok(respuestaVerificada);
        }

    }


}
