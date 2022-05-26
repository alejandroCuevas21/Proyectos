using AplicacionEmpresas2.Models;
using System.Data.SqlClient;
using System.Data;

namespace AplicacionEmpresas2.Datos
{
    public class EmpleadosDatos
    {



        public List<EmpleadoModel> ObtenerEmpleados()
        {

            var ListaEmpleados = new List<EmpleadoModel>();
            var cn = new Conexion();

            using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
            {

                Conexion.Open();
                SqlCommand cmd = new SqlCommand("ObtenerEmpleados", Conexion);
                            cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                     var ObjEmpleados = new EmpleadoModel();
                        ObjEmpleados.Empleado_Id = (int)dr["Empleado_Id"];
                        ObjEmpleados.Nombre = (string)dr["Nombre"];
                        ObjEmpleados.Apellido_Paterno = (string)dr["Apellido_Paterno"];
                        ObjEmpleados.Apellido_Materno = (string)dr["Apellido_Materno"];
                        ObjEmpleados.Fecha_Nacimiento = (DateTime)dr["Fecha_Nacimiento"];
                        ObjEmpleados.Estatus_Id = (int)dr["Estatus_Id"];
                        ObjEmpleados.DescEstatus = (string)dr["DescEstatus"];
                        ListaEmpleados.Add(ObjEmpleados);
                    }
              

                    }

                }
            return ListaEmpleados;
        }

           

       
        public EmpleadoModel Guardar(EmpleadoModel Empleado)
        {

            EmpleadoModel ManejoErrores = new EmpleadoModel();
            
            try
            {

                var cn = new Conexion();

                using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
                {

                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("GuardarEmpleado", Conexion);
                    cmd.Parameters.AddWithValue("Nombre", Empleado.Nombre == null ? DBNull.Value : Empleado.Nombre);
                    cmd.Parameters.AddWithValue("Apellido_Paterno", Empleado.Apellido_Paterno == null ? DBNull.Value : Empleado.Apellido_Paterno);
                    cmd.Parameters.AddWithValue("Apellido_Materno", Empleado.Apellido_Materno == null ? DBNull.Value : Empleado.Apellido_Materno);
                    cmd.Parameters.AddWithValue("Fecha_Nacimiento", Empleado.Fecha_Nacimiento == null ? DBNull.Value : Empleado.Fecha_Nacimiento);
                    cmd.Parameters.AddWithValue("Estatus_Id", Empleado.Estatus_Id == null ? DBNull.Value : Empleado.Estatus_Id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    ManejoErrores.Error = false;
                    

                }
            }
            catch (Exception ex)
            {
                ManejoErrores.Error=true;
                ManejoErrores.MsjError = "Ocurrió un error" + ex.Message;

            }
            return ManejoErrores;
        }



        public EmpleadoModel ActualizaEmpleado(EmpleadoModel Empleado)
        {
            EmpleadoModel ManejoErrores = new EmpleadoModel();

            try
            {

                var cn = new Conexion();

                using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
                {

                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("ActualizaEmpleados", Conexion);
                    cmd.Parameters.AddWithValue("Empleado_Id", Empleado.Empleado_Id == null ? DBNull.Value : Empleado.Empleado_Id);
                    cmd.Parameters.AddWithValue("Nombre", Empleado.Nombre == null ? DBNull.Value : Empleado.Nombre);
                    cmd.Parameters.AddWithValue("Apellido_Paterno", Empleado.Apellido_Paterno == null ? DBNull.Value : Empleado.Apellido_Paterno);
                    cmd.Parameters.AddWithValue("Apellido_Materno", Empleado.Apellido_Materno == null ? DBNull.Value : Empleado.Apellido_Materno);
                    cmd.Parameters.AddWithValue("Fecha_Nacimiento", Empleado.Fecha_Nacimiento == null ? DBNull.Value : Empleado.Fecha_Nacimiento);
                    cmd.Parameters.AddWithValue("Estatus_Id", Empleado.Estatus_Id == null ? DBNull.Value : Empleado.Estatus_Id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    ManejoErrores.Error = false;


                }
            }
            catch (Exception ex)
            {
                ManejoErrores.Error = true;
                ManejoErrores.MsjError = "Ocurrió un error" + ex.Message;

            }
            return ManejoErrores;

        }


        //public ErrorViewModel Modificar(ContactoModel ocontacto)
        //{
        //    ErrorViewModel errorViewModel = new ErrorViewModel();
        //    try
        //    {

        //        var cn = new Conexion();

        //        using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
        //        {

        //            Conexion.Open();
        //            SqlCommand cmd = new SqlCommand("sp_EditarCompañia", Conexion);
        //            cmd.Parameters.AddWithValue("IdCompañia", ocontacto.IdContacto);
        //            cmd.Parameters.AddWithValue("NombreCompañia", ocontacto.NombreCompañia == null ? DBNull.Value : ocontacto.NombreCompañia);
        //            cmd.Parameters.AddWithValue("NombreCalle", ocontacto.NombreCalle == null ? DBNull.Value : ocontacto.NombreCalle);
        //            cmd.Parameters.AddWithValue("NoExterior", ocontacto.NoExterior == null ? DBNull.Value : ocontacto.NoExterior);


        //            cmd.Parameters.AddWithValue("NoPuerta", ocontacto.NoPuerta == null ? DBNull.Value : ocontacto.NoPuerta);
        //            cmd.Parameters.AddWithValue("Colonia", ocontacto.Colonia == null ? DBNull.Value : ocontacto.Colonia);
        //            cmd.Parameters.AddWithValue("Ciudad", ocontacto.Ciudad == null ? DBNull.Value : ocontacto.Ciudad);

        //            cmd.Parameters.AddWithValue("Provincia", ocontacto.Provincia == null ? DBNull.Value : ocontacto.Provincia);
        //            cmd.Parameters.AddWithValue("CP", ocontacto.CP == null ? DBNull.Value : ocontacto.CP);
        //            cmd.Parameters.AddWithValue("IdPais", ocontacto.IdPais == null ? DBNull.Value : ocontacto.IdPais);


        //            cmd.Parameters.AddWithValue("Telefono", ocontacto.Telefono == null ? DBNull.Value : ocontacto.Telefono);
        //            cmd.Parameters.AddWithValue("CorreoElectronico", ocontacto.CorreoElectronico == null ? DBNull.Value : ocontacto.CorreoElectronico);
        //            cmd.Parameters.AddWithValue("SitioWeb", ocontacto.SitioWeb == null ? DBNull.Value : ocontacto.SitioWeb);

        //            cmd.Parameters.AddWithValue("RFC", ocontacto.RFC == null ? DBNull.Value : ocontacto.RFC);
        //            cmd.Parameters.AddWithValue("RegistroCompañia", ocontacto.RegistroCompañia == null ? DBNull.Value : ocontacto.RegistroCompañia);
        //            cmd.Parameters.AddWithValue("Moneda", ocontacto.Moneda == null ? DBNull.Value : ocontacto.Moneda);

        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.ExecuteNonQuery();


        //        }

        //    }
        //    catch (Exception ex) 
        //    {
        //        errorViewModel.RequestId = ex.Message;
        //           throw;
        //    }

        //    return errorViewModel;

        //    }



        public List<CatalogosModel> ObtenerEstatus()
        {

            var CatalogoEstatus = new List<CatalogosModel>();
            var cn = new Conexion();

            using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
            {

                Conexion.Open();
                SqlCommand cmd = new SqlCommand("LeerCatalogoEstatus", Conexion);

                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CatalogoEstatus.Add(new CatalogosModel()
                        {
                            Estatus_Id = Convert.ToInt32(dr["Estatus_Id"]),
                            Descripcion = dr["Descripcion"].ToString()
                        });
                    }

                }
            }

            return CatalogoEstatus;

        }

    }
}
