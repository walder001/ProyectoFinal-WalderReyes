using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class OrdenCompraBLL
    {
        /// <summary>
        /// Permite guardar una entidad en la base de datos
        /// </summary>
        /// <param name="inscripciones">Una instancia de visita</param>
        /// <returns>Retorna True si guardo o Falso si falló </returns>
        public static bool Guardar(Compras compras)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Compras.Add(compras) != null)
                {
                    contexto.SaveChanges(); //Guardar los cambios
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        /// <summary>
        /// Permite Modificar una entidad en la base de datos 
        /// </summary>
        /// <param name="inscripciones">Una instancia de visita</param>
        /// <returns>Retorna True si Modifico o Falso si falló </returns>
        public static bool Modificar(Compras compras)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //todo: buscar las entidades que no estan para removerlas
                var buscar = OrdenCompraBLL.Buscar(compras.CompraId);

                //Idicar que se esta modificando el encabezado
                contexto.Entry(compras).State = EntityState.Modified;

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        /// <summary>
        /// Permite Eliminar una entidad en la base de datos
        /// </summary>
        ///<param name="id">El Id de la visita que se desea eliminar </param>
        /// <returns>Retorna True si Eliminó o Falso si falló </returns>
        public static bool Eliminar(int id)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
              Compras compras = contexto.Compras.Find(id);

                

                contexto.Compras.Remove(compras);

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        /// <summary>
        /// Permite Buscar una entidad en la base de datos
        /// </summary>
        ///<param name="id">El Id de la visita que se desea encontrar </param>
        /// <returns>Retorna la visita encontrada </returns>
        public static Compras Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Compras compras = new Compras();
            try
            {
                compras = contexto.Compras.Find(id);
              
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return compras;
        }

        /// <summary>
        /// Permite extraer una lista de Visitas de la base de datos
        /// </summary> 
        ///<param name="expression">Expression Lambda conteniendo los filtros de busqueda </param>
        /// <returns>Retorna una lista de Visitas</returns>
        public static List<Compras> GetList(Expression<Func<Compras, bool>> expression)
        {
            List<Compras> compras = new List<Compras>();
            Contexto contexto = new Contexto();
            try
            {
                compras = contexto.Compras.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

            return compras;
        }

        public static decimal Calculo(decimal cantidad, decimal precio)
        {
            decimal calculo = cantidad * precio;

            return calculo;

        }
    }
}
