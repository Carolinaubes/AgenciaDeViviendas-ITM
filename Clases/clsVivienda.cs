using AgenciaViviendas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace AgenciaViviendas.Clases
{
    public class clsVivienda
    {

        //Objeto para gestionar los datos de la vivienda con la base de datos, para usar el dataset de Viviendas
        private db_AgenciaViviendasEntities dbAgencia = new db_AgenciaViviendasEntities();

        //Propiedad para poder gestionar el CRUD en la bd 
        public Vivienda vivienda { get; set; }

        // Metodos CRUD

        // Metodo para insertar viviendas
        public string Insertar()
        {
            try
            {
                dbAgencia.Viviendas.Add(vivienda); // Agrega la vivienda
                dbAgencia.SaveChanges(); // Confirma los cambios
                return "Vivienda insertada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar la vivienda: " + ex.Message;
            }
        }

        //Metodo para consultar si una vivienda existe en la bd por medio del id
        public Vivienda Consultar(int Id)
        {
            //Obtengo el primer objeto que coincida con la condición, sino, devuelve null
            Vivienda vivi = dbAgencia.Viviendas.FirstOrDefault(vivienda => vivienda.Id == Id);

            return vivi;
        }

        // Metodo para consultar todos (Ordenado por numero de cuartos) 
        public List<Vivienda> ConsultarTodos()
        {
            return dbAgencia.Viviendas
                .OrderBy(vivienda => vivienda.NumeroCuartos)
                .ToList();
        }
        
        // Metodo para consultar por tipo de vivienda
        public List<Vivienda> ConsultarXTipoVivienda(int idTipoVivienda)
        {
            return dbAgencia.Viviendas
                .Where(vivienda => vivienda.IdTipoVivienda == idTipoVivienda)
                .ToList();
        }

        // Metodo para actualizar una vivienda
        public string Actualizar()
        {
            try
            {
                //Se verifica la existencia de ese dato de lo contrario
                //se deberia insertar o retornar un mensaje de error
                Vivienda vivi = Consultar(vivienda.Id);
                if (vivi == null)
                {
                    return "La vivienda no existe";
                }
                dbAgencia.Viviendas.AddOrUpdate(vivienda);
                dbAgencia.SaveChanges();
                return "La vivienda se actualizo correctamente";

            }
            catch (Exception ex)
            {
                return "Error al actualizar la vivienda" + ex.Message;
            }
        }

        // Metodo para eliminar por Id de vivienda
        public string Eliminar(int Id) 
        {
            try
            {
                //Antes de eliminar se deberia consultar si el dato ya existe para poder eliminarlo
                Vivienda vivi = Consultar(Id);

                if (vivi == null)  // Si vivi es nulo, no existe, debe marcar error
                {
                    return "La vivienda no existe";
                }

                // Uso del objeto dbAgencia para acceder al dataSet de Viviendas y poder manipularlo
                dbAgencia.Viviendas.Remove(vivi); ; //Elimina la vivienda en la lista del EF, se debe invocar el metodo SaveChanges para guardar los cambios en la db
                dbAgencia.SaveChanges(); //Guarda los cambios en la base de datos
                return "Vivienda eliminada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al eliminar la vivienda: " + ex.Message;
            }
            
        }

        
    }
}