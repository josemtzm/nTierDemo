using DAL;
using System;
using System.Collections.Generic;
using System.ServiceModel.Activation;

namespace SrvEmpleadoAjax
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class SrvEmpleado : ISrvEmpleado
    {
        public List<Empleado> ObtenerEmpleadosLista()
        {
            return DbContext.ObtenerEmpleadosLista();
        }

        public Empleado ObtenerEmpleadoDetalle(int empID)
        {
            return DbContext.ObtenerEmpleadoDetalle(empID);
        }

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
    }
}
