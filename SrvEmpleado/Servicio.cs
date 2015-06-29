using DAL;
using System;
using System.Collections.Generic;

namespace SrvEmpleado
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Servicio : IServicio
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        /// <summary>
        /// Obtiene la lista de empleados.
        /// </summary>
        /// <returns></returns>
        public List<Empleado> ObtenerEmpleadosLista()
        {
            return DbContext.ObtenerEmpleadosLista();
        }

        /// <summary>
        /// Actualiza los datos de un empleado
        /// </summary>
        /// <param name="empleado"></param>
        /// <returns></returns>
        public bool ActualizarEmpleado(Empleado empleado)
        {
            return DbContext.ActualizarEmpleado(empleado);
        }

        /// <summary>
        /// Obtiene el detalle de un empleado
        /// </summary>
        /// <param name="empID"></param>
        /// <returns></returns>
        public Empleado ObtenerEmpleadoDetalle(int empID)
        {
            return DbContext.ObtenerEmpleadoDetalle(empID);
        }

        /// <summary>
        /// Borrar un empleado
        /// </summary>
        /// <param name="empID"></param>
        /// <returns></returns>
        public bool BorrarEmpleado(int empID)
        {
            return DbContext.BorrarEmpleado(empID);
        }

        /// <summary>
        /// Agrega un empleado
        /// </summary>
        /// <param name="empleado"></param>
        /// <returns></returns>
        public bool AgregarEmpleado(Empleado empleado)
        {
            return DbContext.AgregarEmpleado(empleado);
        }
    }
}
