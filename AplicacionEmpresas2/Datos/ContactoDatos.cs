using AplicacionEmpresas2.Models;
using System.Data.SqlClient;
using System.Data;

namespace AplicacionEmpresas2.Datos
{
    public class ContactoDatos
    {

        public ContactoModel Listar(int IdCompañia)
        {

            var oLista = new ContactoModel();
            var cn = new Conexion();

            using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
            {

                Conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerCompañia", Conexion);
                cmd.Parameters.AddWithValue("IdCompañia", IdCompañia);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        oLista.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        oLista.NombreCompañia = dr["NombreCompañia"].ToString();
                        oLista.NombreCalle = dr["NombreCalle"].ToString();
                        oLista.NoExterior = dr["NoExterior"].ToString();
                        oLista.NoPuerta = dr["NoPuerta"].ToString();
                        oLista.Colonia = dr["Colonia"].ToString();
                        oLista.Ciudad = dr["Ciudad"].ToString();
                        oLista.Provincia = Convert.ToInt32(dr["Provinicia"]);
                        oLista.DescProvincia = dr["DescProvincia"].ToString();
                        oLista.CP = Convert.ToInt32(dr["CP"]);
                        oLista.IdPais = Convert.ToInt32(dr["IdPais"]);
                        oLista.DescPais = dr["DescPais"].ToString();
                        oLista.Telefono = dr["Telefono"].ToString();
                        oLista.CorreoElectronico = dr["CorreoElectronico"].ToString();
                        oLista.SitioWeb = dr["SitioWeb"].ToString();
                        oLista.RFC = dr["RFC"].ToString();
                        oLista.RegistroCompañia = dr["RegistroCompañia"].ToString();
                        oLista.Moneda = dr["Moneda"].ToString();
                        oLista.DescMoneda = dr["DescMoneda"].ToString();

                        
                    }

                }
            }

            return oLista;

        }



        public ContactoModel Obtener(int IdContacto)
        {

            var oContacto = new ContactoModel();
            var cn = new Conexion();

            using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
            {

                Conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_obtener", Conexion);
                cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                     /*   oContacto.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        oContacto.Nombre = dr["Nombre"].ToString();
                        oContacto.Telefono = dr["Telefono"].ToString();
                        oContacto.Correo = dr["Correo"].ToString();*/

                    }

                }
            }

            return oContacto;

        }


        public int Guardar(ContactoModel ocontacto)
        { 
            int Id = 0;
            try
            {

                var cn = new Conexion();

                using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
                {

                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardaCompañia", Conexion);
                    cmd.Parameters.AddWithValue("NombreCompañia", ocontacto.NombreCompañia == null ? DBNull.Value : ocontacto.NombreCompañia);
                    cmd.Parameters.AddWithValue("NombreCalle", ocontacto.NombreCalle == null ? DBNull.Value : ocontacto.NombreCalle);
                    cmd.Parameters.AddWithValue("NoExterior", ocontacto.NoExterior == null ? DBNull.Value : ocontacto.NoExterior);
                    cmd.Parameters.AddWithValue("NoPuerta", ocontacto.NoPuerta == null ? DBNull.Value : ocontacto.NoPuerta);
                    cmd.Parameters.AddWithValue("Colonia", ocontacto.Colonia == null ? DBNull.Value : ocontacto.Colonia);
                    cmd.Parameters.AddWithValue("Ciudad", ocontacto.Ciudad == null ? DBNull.Value : ocontacto.Ciudad);
                    cmd.Parameters.AddWithValue("Provincia", ocontacto.Provincia == null ? DBNull.Value : ocontacto.Provincia);
                    cmd.Parameters.AddWithValue("CP", ocontacto.CP == null ? DBNull.Value : ocontacto.CP);
                    cmd.Parameters.AddWithValue("IdPais", ocontacto.IdPais == null ? DBNull.Value : ocontacto.IdPais); 
                    cmd.Parameters.AddWithValue("Telefono", ocontacto.Telefono == null ? DBNull.Value : ocontacto.Telefono);
                    cmd.Parameters.AddWithValue("CorreoElectronico", ocontacto.CorreoElectronico == null ? DBNull.Value : ocontacto.CorreoElectronico); 
                    cmd.Parameters.AddWithValue("SitioWeb", ocontacto.SitioWeb == null ? DBNull.Value : ocontacto.SitioWeb);
                    cmd.Parameters.AddWithValue("RFC", ocontacto.RFC == null ? DBNull.Value : ocontacto.RFC);
                    cmd.Parameters.AddWithValue("RegistroCompañia", ocontacto.RegistroCompañia == null ? DBNull.Value : ocontacto.RegistroCompañia);
                    cmd.Parameters.AddWithValue("Moneda", ocontacto.Moneda == null ? DBNull.Value : ocontacto.Moneda);

                    cmd.CommandType = CommandType.StoredProcedure;
                  

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                           Id= Convert.ToInt32(dr[0]);
                        }

                    }
                }
      
            }

            catch (Exception e)
            {
                Id = 0;
              
           
            }
            return Id;
        }



        public ErrorViewModel Modificar(ContactoModel ocontacto)
        {
            ErrorViewModel errorViewModel = new ErrorViewModel();
            try
            {

                var cn = new Conexion();

                using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
                {

                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarCompañia", Conexion);
                    cmd.Parameters.AddWithValue("IdCompañia", ocontacto.IdContacto);
                    cmd.Parameters.AddWithValue("NombreCompañia", ocontacto.NombreCompañia == null ? DBNull.Value : ocontacto.NombreCompañia);
                    cmd.Parameters.AddWithValue("NombreCalle", ocontacto.NombreCalle == null ? DBNull.Value : ocontacto.NombreCalle);
                    cmd.Parameters.AddWithValue("NoExterior", ocontacto.NoExterior == null ? DBNull.Value : ocontacto.NoExterior);


                    cmd.Parameters.AddWithValue("NoPuerta", ocontacto.NoPuerta == null ? DBNull.Value : ocontacto.NoPuerta);
                    cmd.Parameters.AddWithValue("Colonia", ocontacto.Colonia == null ? DBNull.Value : ocontacto.Colonia);
                    cmd.Parameters.AddWithValue("Ciudad", ocontacto.Ciudad == null ? DBNull.Value : ocontacto.Ciudad);

                    cmd.Parameters.AddWithValue("Provincia", ocontacto.Provincia == null ? DBNull.Value : ocontacto.Provincia);
                    cmd.Parameters.AddWithValue("CP", ocontacto.CP == null ? DBNull.Value : ocontacto.CP);
                    cmd.Parameters.AddWithValue("IdPais", ocontacto.IdPais == null ? DBNull.Value : ocontacto.IdPais);


                    cmd.Parameters.AddWithValue("Telefono", ocontacto.Telefono == null ? DBNull.Value : ocontacto.Telefono);
                    cmd.Parameters.AddWithValue("CorreoElectronico", ocontacto.CorreoElectronico == null ? DBNull.Value : ocontacto.CorreoElectronico);
                    cmd.Parameters.AddWithValue("SitioWeb", ocontacto.SitioWeb == null ? DBNull.Value : ocontacto.SitioWeb);

                    cmd.Parameters.AddWithValue("RFC", ocontacto.RFC == null ? DBNull.Value : ocontacto.RFC);
                    cmd.Parameters.AddWithValue("RegistroCompañia", ocontacto.RegistroCompañia == null ? DBNull.Value : ocontacto.RegistroCompañia);
                    cmd.Parameters.AddWithValue("Moneda", ocontacto.Moneda == null ? DBNull.Value : ocontacto.Moneda);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                    
                }

            }
            catch (Exception ex) 
            {
                errorViewModel.RequestId = ex.Message;
                   throw;
            }

            return errorViewModel;

            }



                public List<CatalogosModel> ObtenerPaises()
        {

            var CatalogoPaises = new List<CatalogosModel>();
            var cn = new Conexion();

            using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
            {

                Conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerPaises", Conexion);
             
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CatalogoPaises.Add(new CatalogosModel()
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Descripcion = dr["Descripcion"].ToString()
                        });
                }

                }
            }

            return CatalogoPaises;

        }

        public List<CatalogosModel> ObtenerProvincia()
        {

            var CatalogoProvincias = new List<CatalogosModel>();
            var cn = new Conexion();

            using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
            {

                Conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerProvincias", Conexion);

                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CatalogoProvincias.Add(new CatalogosModel()
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Descripcion = dr["Descripcion"].ToString()
                        });
                }

                }
            }

            return CatalogoProvincias;

        }


        
  

    }
}
