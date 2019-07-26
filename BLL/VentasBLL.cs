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
    public class VentasBLL
    {
        /// <summary>
        /// Permite guardar una entidad en la base de datos
        /// </summary>
        /// <param name="inscripciones">Una instancia de visita</param>
        /// <returns>Retorna True si guardo o Falso si falló </returns>
        public static bool Guardar(Ventas venta)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Ventas.Add(venta) != null)
                {
                    foreach (var item in venta.Detalle)
                    {
                        contexto.Clientes.Find(item.ClienteId).Balance += (decimal)item.Total;
                    }

                    contexto.SaveChanges(); //Guardar los cambios
                    paso = true;
                }
                //siempre hay que cerrar la conexion
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
        public static bool Modificar(Ventas ventas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //todo: buscar las entidades que no estan para removerlas
                var buscar = VentasBLL.Buscar(ventas.VentasId);

                foreach (var item in buscar.Detalle)//recorrer el detalle aterior
                {
                    //restar todas las visitas
                    contexto.Clientes.Find(item.ClienteId).Balance -= (decimal)item.Total;

                    //determinar si el item no esta en el detalle actual
                    if (!ventas.Detalle.ToList().Exists(v => v.ClienteId == item.ClienteId))
                    {
                        contexto.Clientes.Find(item.ClienteId).Balance -= (decimal)item.Total;
                        //item.Balance  = ; //quitar la ciudad para que EF no intente hacerle nada
                        contexto.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    }
                }

                //recorrer el detalle
                foreach (var item in ventas.Detalle)
                {
                    //Sumar todas las visitas
                    contexto.Clientes.Find(item.ClienteId).Balance += (decimal)item.Total;

                    //Muy importante indicar que pasara con la entidad del detalle
                    var estado = item.ClienteId > 0 ? EntityState.Modified : EntityState.Added;
                    contexto.Entry(item).State = estado;
                }

                //Idicar que se esta modificando el encabezado
                contexto.Entry(ventas).State = EntityState.Modified;

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
                Ventas ventas = contexto.Ventas.Find(id);

                foreach (var item in ventas.Detalle)
                {
                    var balance = contexto.Clientes.Find(item.ClienteId);
                    balance.Balance -= (decimal)item.Total;
                }

                contexto.Ventas.Remove(ventas);

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
        public static Ventas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Ventas ventas = new Ventas();
            try
            {
                ventas = contexto.Ventas.Find(id);
                if (ventas != null)
                {
                    //Cargar la lista en este punto porque
                    //luego de hacer Dispose() el Contexto 
                    //no sera posible leer la lista
                    ventas.Detalle.Count();

                    //Cargar los nombres de las ciudades
                    foreach (var item in ventas.Detalle)
                    {
                        //forzando la ciudad a cargarse
                        // double s = item.Estudiantes.Balance;
                    }
                }
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return ventas;
        }

        /// <summary>
        /// Permite extraer una lista de Visitas de la base de datos
        /// </summary> 
        ///<param name="expression">Expression Lambda conteniendo los filtros de busqueda </param>
        /// <returns>Retorna una lista de Visitas</returns>
        public static List<Ventas> GetList(Expression<Func<Ventas, bool>> expression)
        {
            List<Ventas> inscripcion = new List<Ventas>();
            Contexto contexto = new Contexto();
            try
            {
                inscripcion = contexto.Ventas.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

            return inscripcion;
        }

        public static decimal Calculo(decimal cantidad, decimal precio)
        {
            decimal calculo = cantidad * precio;

            return calculo;

        }
    }
}
