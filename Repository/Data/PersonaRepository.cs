using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace Repository.Data
{
    public class PersonaRepository : IPersona
    {
        private IDbConnection conexionDB;
        public PersonaRepository(string _connectionString)
        {
            conexionDB = new DbConection(_connectionString).dbConnection();
        }
        public bool add(PersonaModel persona)
        {
            try
            {
                if(conexionDB.Execute("Insert into Persona(nombre, apellido, cedula) values(@nombre, @apellido, @cedula)", persona) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PersonaModel get(int id)
        {
            try
            {
                return conexionDB.QueryFirst<PersonaModel>(" select * from persona where id = {id}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<PersonaModel> list()
        {
            try
            {
                return conexionDB.Query<PersonaModel>(" select * from persona; ");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string remove(int id)
        {
            try
            {
                conexionDB.Execute(" delete from persona where id = {id};");
                return "Se eliminó a la persona correctamente.";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string update(int id)
        {
            try
            {
                conexionDB.Execute(" update persona set " +
                                   " nombre = @nombre, " +
                                   " apellido = @apellido, " +
                                   " cedula = @cedula " +
                                   " where id = {id}");
                return "Se modificaron los datos correctamente.";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}