using AgenciaViviendas.Clases;
using AgenciaViviendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgenciaViviendas.Controllers
{
    // Ruta para acceder al controlador de Viviendas
    [RoutePrefix("api/Viviendas")] 
    public class ViviendaController : ApiController
    {
        private Vivienda vivienda = null;

        [HttpGet] //Endpoint (ruta) para acceder a ConsultarTodos
        [Route("ConsultarTodos")]
        public List<Vivienda> ConsultarTodos()
        {
            clsVivienda Vivienda = new clsVivienda();
            return Vivienda.ConsultarTodos();
        }

        [HttpGet] //Endpoint (ruta) para acceder a ConsultarXTipoVivienda
        [Route("ConsultarXTipoVivienda")]
        public List<Vivienda> ConsultarXTipoVivienda(int idTipoVivienda)
        {
            clsVivienda Vivienda = new clsVivienda();
            return Vivienda.ConsultarXTipoVivienda(idTipoVivienda);
        }

        [HttpGet] //Endpoint (ruta) para acceder a ConsultarXId
        [Route("Consultar")]
        public Vivienda Consultar(int id)
        {
            clsVivienda Vivienda = new clsVivienda();
            return Vivienda.Consultar(id);
        }

        [HttpPost] //Endpoint (ruta) para insertar una vivienda
        [Route("Insertar")]
        public string Insertar([FromBody] Vivienda vivi)
        {
            clsVivienda Vivienda = new clsVivienda();
            Vivienda.vivienda = vivi;
            return Vivienda.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")] //Endpoint (ruta) para actualizar una vivienda
        public string Actualizar([FromBody] Vivienda vivi)
        {
            clsVivienda Vivienda = new clsVivienda();
            Vivienda.vivienda = vivi;
            return Vivienda.Actualizar();
        }
        
        [HttpDelete] //Endpoint (ruta) para eliminar una vivienda por medio de su identificador
        [Route("Eliminar")]
        public string Eliminar(int Id)
        {
            clsVivienda Vivienda = new clsVivienda();
            return Vivienda.Eliminar(Id);
        }
    }
}