using AplicacionEmpresas2.Models;
using System.Data.SqlClient;
using System.Data;
using AplicacionEmpleados.Models;
using AplicacionEscolar.Models;

namespace AplicacionEmpresas2.Datos
{
    public class EscolarDatos
    {


       public List<EstatusPedidoModel> ObtenerStatus()
        {

            var ListaEstatus = new List<EstatusPedidoModel>();
            var cn = new Conexion();

            using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                Conexion.Open();

                SqlCommand cmd = new SqlCommand("ObtenerEstatusPedido", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var ObjEstatus = new EstatusPedidoModel();

                        ObjEstatus.Id = (int)dr["Id"];
                        ObjEstatus.Descripcion = (string)dr["Descripcion"];
                        ListaEstatus.Add(ObjEstatus);
                    }

                }
            }
            return ListaEstatus;

        }
        public EstatusPedidoModel ObtenerEstatusPedido(string OrdPedido)
        {
            var cn = new Conexion();
            var ObjEstatus = new EstatusPedidoModel();
            using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
            {

                Conexion.Open();
                SqlCommand cmd = new SqlCommand("ObtenerStatusPedido", Conexion);
                cmd.Parameters.AddWithValue("OrdPedido", OrdPedido);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ObjEstatus.Id = (int)dr["Id"];
                        ObjEstatus.Descripcion = (string)dr["Descripcion"];

                    }

                }

            }
            return ObjEstatus;
        }



        public MaestrosModel GuardarMaestro(MaestrosModel Maestro)
        {

            MaestrosModel ManejoErrores = new MaestrosModel();

            try
            {

                var cn = new Conexion();

                using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
                {

                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("InsertarMaestro", Conexion);
                    cmd.Parameters.AddWithValue("Nombre", Maestro.Nombre == null ? DBNull.Value : Maestro.Nombre);
                    cmd.Parameters.AddWithValue("ApePaterno", Maestro.ApePaterno == null ? DBNull.Value : Maestro.ApePaterno);
                    cmd.Parameters.AddWithValue("ApeMaterno", Maestro.ApeMaterno == null ? DBNull.Value : Maestro.ApeMaterno);
                    cmd.Parameters.AddWithValue("Telefono", Maestro.Telefono == null ? DBNull.Value : Maestro.Telefono);
                    cmd.Parameters.AddWithValue("Email", Maestro.Email == null ? DBNull.Value : Maestro.Email);
                    cmd.Parameters.AddWithValue("Estatus", Maestro.Estatus == null ? DBNull.Value : Maestro.Estatus);
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



        public MaestrosModel ActualizaMaestro(MaestrosModel Maestros)
        {
            MaestrosModel ManejoErrores = new MaestrosModel();

            try
            {

                var cn = new Conexion();

                using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
                {

                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("ActualizarMaestros", Conexion);
                    cmd.Parameters.AddWithValue("Id", Maestros.Id == null ? DBNull.Value : Maestros.Id);
                    cmd.Parameters.AddWithValue("Nombre", Maestros.Nombre == null ? DBNull.Value : Maestros.Nombre);
                    cmd.Parameters.AddWithValue("ApePaterno", Maestros.ApePaterno == null ? DBNull.Value : Maestros.ApePaterno);
                    cmd.Parameters.AddWithValue("ApeMaterno", Maestros.ApeMaterno == null ? DBNull.Value : Maestros.ApeMaterno);
                    cmd.Parameters.AddWithValue("Telefono", Maestros.Telefono == null ? DBNull.Value : Maestros.Telefono);
                    cmd.Parameters.AddWithValue("Email", Maestros.Email == null ? DBNull.Value : Maestros.Email);
                    cmd.Parameters.AddWithValue("Estatus", Maestros.Estatus == null ? DBNull.Value : Maestros.Estatus);
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

        public List<AlumnosModel> ObtenerAlumnos()
        {

            var CatalogoAlumnos = new List<AlumnosModel>();
            var cn = new Conexion();


            using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
            {

                Conexion.Open();
                SqlCommand cmd = new SqlCommand("ObtenerAlumnos", Conexion);

                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CatalogoAlumnos.Add(new AlumnosModel()
                        {
                            Matricula = Convert.ToInt32(dr["Matricula"]),
                            Nombre = dr["Nombre"].ToString(),
                            ApePaterno = dr["ApePaterno"].ToString(),
                            ApeMaterno = dr["ApeMaterno"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Email = dr["Email"].ToString(),
                            Estatus = Convert.ToInt32(dr["Estatus"].ToString()),
                            DescEstatus = dr["DescEstatus"].ToString()

                        });
                    }

                }
            }
            return CatalogoAlumnos;
        }



        public AlumnosModel GuardarAlumno(AlumnosModel Alumno)
        {
            AlumnosModel ManejoErrores = new AlumnosModel();
            try
            {

                var cn = new Conexion();

                using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
                {

                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("InsertarAlumnos", Conexion);
                    cmd.Parameters.AddWithValue("Nombre", Alumno.Nombre == null ? DBNull.Value : Alumno.Nombre);
                    cmd.Parameters.AddWithValue("ApePaterno", Alumno.ApePaterno == null ? DBNull.Value : Alumno.ApePaterno);
                    cmd.Parameters.AddWithValue("ApeMaterno", Alumno.ApeMaterno == null ? DBNull.Value : Alumno.ApeMaterno);
                    cmd.Parameters.AddWithValue("Telefono", Alumno.Telefono == null ? DBNull.Value : Alumno.Telefono);
                    cmd.Parameters.AddWithValue("Email", Alumno.Email == null ? DBNull.Value : Alumno.Email);
                    cmd.Parameters.AddWithValue("Estatus", Alumno.Estatus == null ? DBNull.Value : Alumno.Estatus);
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

        public AlumnosModel ActualizaAlumno(AlumnosModel Maestros)
        {
            AlumnosModel ManejoErrores = new AlumnosModel();

            try
            {

                var cn = new Conexion();

                using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
                {

                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("ActualizarAlumnos", Conexion);
                    cmd.Parameters.AddWithValue("Matricula", Maestros.Matricula == null ? DBNull.Value : Maestros.Matricula);
                    cmd.Parameters.AddWithValue("Nombre", Maestros.Nombre == null ? DBNull.Value : Maestros.Nombre);
                    cmd.Parameters.AddWithValue("ApePaterno", Maestros.ApePaterno == null ? DBNull.Value : Maestros.ApePaterno);
                    cmd.Parameters.AddWithValue("ApeMaterno", Maestros.ApeMaterno == null ? DBNull.Value : Maestros.ApeMaterno);
                    cmd.Parameters.AddWithValue("Telefono", Maestros.Telefono == null ? DBNull.Value : Maestros.Telefono);
                    cmd.Parameters.AddWithValue("Email", Maestros.Email == null ? DBNull.Value : Maestros.Email);
                    cmd.Parameters.AddWithValue("Estatus", Maestros.Estatus == null ? DBNull.Value : Maestros.Estatus);
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

        public List<HorarioGeneralModel> ObtenerHorarioGeneral()
        {
            HorarioGeneralModel HorarioGeneral = new HorarioGeneralModel();

            List<HorarioGeneralModel> HorarioGeneralList = new List<HorarioGeneralModel>();
            try
            {

                var cn = new Conexion();

                using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
                {

                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("ObtenerHorariosGeneral", Conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    HorarioGeneral.Error = false;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            HorarioGeneralList.Add(new HorarioGeneralModel()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Hora = dr["Hora"].ToString(),
                                Estatus = Convert.ToInt32(dr["Estatus"]),
                                DescEstatus = dr["DescEstatus"].ToString()

                            });


                        }
                    }
                }
            }

            catch (Exception ex)
            {
                HorarioGeneral.Error = true;
                HorarioGeneral.MsjError = "Ocurrió un error" + ex.Message;

            }
            return HorarioGeneralList;


        }


        public MateriasModel GuardarMateria(MateriasModel Materias)
        {
            MateriasModel ManejoErrores = new MateriasModel();

            try
            {

                var cn = new Conexion();

                using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
                {

                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("InsertarMaterias", Conexion);
                    cmd.Parameters.AddWithValue("Nombre", Materias.Nombre == null ? DBNull.Value : Materias.Nombre);
                    cmd.Parameters.AddWithValue("Estatus", Materias.Estatus == null ? DBNull.Value : Materias.Estatus);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Materias.Id = Convert.ToInt32(dr[0]);

                        }
                    }
                    foreach (var horario in Materias.Horarios)
                    {

                        cmd.Parameters.Clear();
                        cmd = new SqlCommand("InsertarDetalleMateria", Conexion);
                        cmd.Parameters.AddWithValue("IdMateria", Materias.Id == null ? DBNull.Value : Materias.Id);
                        cmd.Parameters.AddWithValue("LimiteAlumno", Materias.LimiteAlumno == null ? DBNull.Value : Materias.LimiteAlumno);
                        cmd.Parameters.AddWithValue("Hora", horario == null ? DBNull.Value : horario);
                        cmd.Parameters.AddWithValue("Estatus", Materias.Estatus == null ? DBNull.Value : Materias.Estatus);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                ManejoErrores.Error = true;
                ManejoErrores.MsjError = "Ocurrió un error" + ex.Message;

            }
            return ManejoErrores;

        }

        public List<MateriasModel> ObtenerMaterias()
        {

            var listaMaterias = new List<MateriasModel>();
            var CatalogoMaterias = new MateriasModel();
            try
            {

                var cn = new Conexion();
                using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    Conexion.Open();

                    SqlCommand cmd = new SqlCommand("ObtenerMaterias", Conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listaMaterias.Add(new MateriasModel()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Nombre = dr["Nombre"].ToString()

                            });

                        }
                    }

                }

            }
            catch (Exception ex)
            {

                listaMaterias.Add(new MateriasModel()
                {
                    Error = true,
                    MsjError = "Ocurrió un error" + ex.Message

                });

            }

            return listaMaterias;

        }


        public List<DetalleMateriaModel> ObtenerMateriasDetalle(string IdMaterias)
        {

            var CatalogoDetalleMaterias = new List<DetalleMateriaModel>();
            var cn = new Conexion();


            using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
            {

                Conexion.Open();
                SqlCommand cmd = new SqlCommand("ObtenerMateriasDetalle", Conexion);
                cmd.Parameters.AddWithValue("IdMaterias", IdMaterias == null ? DBNull.Value : IdMaterias);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CatalogoDetalleMaterias.Add(new DetalleMateriaModel()
                        {
                            IdDetalle = Convert.ToInt32(dr["IdDetalle"]),
                            IdHorarioMaestro = Convert.ToInt32(dr["IdHorarioMaestro"]),
                            Nombre = dr["Nombre"].ToString(),
                            LimiteAlumno = Convert.ToInt32(dr["LimiteAlumno"]),
                            IdHorario = Convert.ToInt32(dr["IdHorario"]),
                            Horario = dr["Horario"].ToString(),
                            IdMaestro = Convert.ToInt32(dr["IdMaestro"]),
                            Maestro = dr["Maestro"].ToString()


                        });
                    }

                }
            }
            return CatalogoDetalleMaterias;
        }


        public DetalleMateriaModel GuardarAsignacion(DetalleMateriaModel ObjAsignacion)
        {
            DetalleMateriaModel MsjErrores = new DetalleMateriaModel();

            try
            {
                var cn = new Conexion();
                using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
                {

                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("InsertarHorariosMaestros", Conexion);
                    cmd.Parameters.AddWithValue("IdDetalleMateria", ObjAsignacion.IdDetalle == null ? DBNull.Value : ObjAsignacion.IdDetalle);
                    cmd.Parameters.AddWithValue("IdMaestro", ObjAsignacion.IdMaestro == null ? DBNull.Value : ObjAsignacion.IdMaestro);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                }

                MsjErrores.Error = false;
            }
            catch (Exception e)
            {
                MsjErrores.Error = true;
                MsjErrores.MsjError = "Ocurrio un error al asignar maestro" + e.Message;
            }


            return MsjErrores;

        }



        public List<AlumnosMateriasModel> ObtenerMateriasHorariosMaestro()
        {

            List<AlumnosMateriasModel> ListaHorarioMateriasHorario = new List<AlumnosMateriasModel>();

            try
            {

                var cn = new Conexion();
                using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
                {

                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("ObtenerMateriasHorariosMaestro", Conexion);

                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ListaHorarioMateriasHorario.Add(new AlumnosMateriasModel()
                            {
                                IdMateria = Convert.ToInt32(dr["IdMateria"]),
                                NomMateria = dr["NomMateria"].ToString(),
                                IdMaestro = Convert.ToInt32(dr["IdMaestro"]),
                                NomMaestros = dr["NomMaestros"].ToString(),
                                IdHora = Convert.ToInt32(dr["IdHora"]),
                                NomHora = dr["NomHora"].ToString(),
                                LimiteAlumno = Convert.ToInt32(dr["LimiteAlumno"]),
                                IdHorarioMaestro = Convert.ToInt32(dr["IdHorarioMaestro"]),
                                Error = false

                            });
                        }

                    }

                }

                return ListaHorarioMateriasHorario;


            }


            catch (Exception e)
            {
                ListaHorarioMateriasHorario.Add(new AlumnosMateriasModel()
                {
                    Error = false,
                    MsjError = "Ocurrio un error al obtener horarios por materia" + e.Message


                });

                throw;
            }

        }


        public AlumnosMateriasModel GuardarAsignacionMateriasAlumnos(List<AlumnosMateriasModel> ListaHorariosMaterias)
        {

            AlumnosMateriasModel ManejoErrores = new AlumnosMateriasModel();
            try
            {

                var cn = new Conexion();

                using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
                {

                    Conexion.Open();

                    foreach (var HorarioMaterias in ListaHorariosMaterias)
                    {

                        SqlCommand cmd = new SqlCommand("GuardarGruposAlumnos", Conexion);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("IdHorarioMaestro", HorarioMaterias.IdHorarioMaestro == null ? DBNull.Value : HorarioMaterias.IdHorarioMaestro);
                        cmd.Parameters.AddWithValue("MatriculaAlumno", HorarioMaterias.MatriculaAlumno == null ? DBNull.Value : HorarioMaterias.MatriculaAlumno);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                    }

                }
                ManejoErrores.Error = false;

            }
            catch (Exception ex)
            {
                ManejoErrores.Error = true;
                ManejoErrores.MsjError = "Ocurrio un error al guardar Grupo Alumno" + ex.Message;

            }

            return ManejoErrores;

        }

        public List<AlumnosMateriasModel> ObtenerListadoAlumnosMateria(int IdAlumno)
        {

            List<AlumnosMateriasModel> ListaHorarioAlumnosMateria = new List<AlumnosMateriasModel>();
            try
            {

                var cn = new Conexion();

                using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
                {

                    Conexion.Open();

                    {

                        SqlCommand cmd = new SqlCommand("ObtenerAlumnosMateria", Conexion);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("IdAlumno", IdAlumno == null ? DBNull.Value : IdAlumno);

                        cmd.CommandType = CommandType.StoredProcedure;
                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ListaHorarioAlumnosMateria.Add(new AlumnosMateriasModel()
                                {
                                    Id = Convert.ToInt32(dr["id"]),
                                    IdMateria = Convert.ToInt32(dr["IdMateria"]),
                                    NomMateria = dr["NomMateria"].ToString(),
                                    IdMaestro = Convert.ToInt32(dr["IdMaestro"]),
                                    MatriculaAlumno = Convert.ToInt32(dr["MatriculaAlumno"]),
                                    NomMaestros = dr["NomMaestros"].ToString(),
                                    IdHora = Convert.ToInt32(dr["IdHora"]),
                                    NomHora = dr["NomHora"].ToString(),
                                    IdHorarioMaestro = Convert.ToInt32(dr["IdHorarioMaestro"]),
                                    Error = false

                                });
                            }

                        }

                    }

                }
            }
            catch (Exception ex)
            {

                ListaHorarioAlumnosMateria.Add(new AlumnosMateriasModel()
                {
                    Error = true,
                    MsjError = "Ocurrio un error al obtener Grupo Alumno" + ex.Message
                });

            }

            return ListaHorarioAlumnosMateria;


        }
    }
}