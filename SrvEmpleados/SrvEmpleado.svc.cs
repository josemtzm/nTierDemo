using DAL;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace SrvEmpleados
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class SrvEmpleado
    {
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        public void DoWork()
        {
            // Add your operation implementation here
            return;
        }

        [OperationContract]
        public List<Empleado> ObtenerEmpleadosLista()
        {
            return DbContext.ObtenerEmpleadosLista();
        }

        [OperationContract]
        public bool ActualizarEmpleado(Empleado empleado)
        {
            return DbContext.ActualizarEmpleado(empleado);
        }

        [OperationContract]
        public Empleado ObtenerEmpleadoDetalle(int empID)
        {
            return DbContext.ObtenerEmpleadoDetalle(empID);
        }

        [OperationContract]
        public bool BorrarEmpleado(int empID)
        {
            return DbContext.BorrarEmpleado(empID);
        }

        [OperationContract]
        public bool AgregarEmpleado(Empleado empleado)
        {
            return DbContext.AgregarEmpleado(empleado);
        }

        // Add more operations here and mark them with [OperationContract]
    }
}
