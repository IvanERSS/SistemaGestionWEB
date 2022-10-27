using SistemaGestionWEB.Models;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace SistemaGestionWEB.Repository
{
    public class VentaRepository
    {
        public static List<Venta> Get()
        {
            var Ventas = new List<Venta>();

            using (SqlConnection connection = RepositoryTools.GetConnection())
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = @"
									SELECT
										id,
										Comentarios,
										IdUsuario
									FROM
										Venta
                                    ";

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var venta = new Venta();
                    var pVendidos = new List<ProductoVendido>();
                    venta.ID = Convert.ToInt32(reader.GetValue(0));
                    venta.Comentarios = reader.GetValue(1).ToString();
                    venta.Usuario = UsuarioRepository.Get(Convert.ToInt32(reader.GetValue(2)));
                    venta.Productos = ProductoVendidoRepository.GetByIdVenta(Convert.ToInt32(reader.GetValue(0)));
                    Ventas.Add(venta);

                    Console.WriteLine(venta.ToString());
                }


                //Validaciones console

                return Ventas;

                reader.Close();
                connection.Close();

            }

            return Ventas;
        }
        
        public static Venta Get(int _id)
        {
            var _Venta = new Venta();

            using (SqlConnection connection = RepositoryTools.GetConnection())
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.Parameters.Add(new SqlParameter("id", System.Data.SqlDbType.Int) { Value = _id });

                cmd.CommandText = @"
									SELECT
										id,
										Comentarios,
										IdUsuario
									FROM
										Venta
									WHERE id = @id
                                    ";

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var venta = new Venta();
                    var pVendidos = new List<ProductoVendido>();
                    venta.ID = Convert.ToInt32(reader.GetValue(0));
                    venta.Comentarios = reader.GetValue(1).ToString();
                    venta.Usuario = UsuarioRepository.Get(Convert.ToInt32(reader.GetValue(2)));
                    venta.Productos = ProductoVendidoRepository.GetByIdVenta(Convert.ToInt32(reader.GetValue(0)));
                    _Venta = venta;

                    //Console.WriteLine(venta.ToString());
                }




                reader.Close();
                connection.Close();

            }

            return _Venta;
        }

        public static int Create(int _IdUsuario, string _Comentarios = "")
        {
            using (SqlConnection connection = RepositoryTools.GetConnection())
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.Parameters.Add(new SqlParameter("comentarios", System.Data.SqlDbType.VarChar) { Value = _Comentarios });
                cmd.Parameters.Add(new SqlParameter("id", System.Data.SqlDbType.Int) { Value = _IdUsuario });
                cmd.CommandText = @"
									INSERT INTO Venta(Comentarios,IdUsuario)
									VALUES (@comentarios,@id); SELECT @@IDENTITY
                                ";
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                if (id > 0) { return id; }
                connection.Close();
            }
            return 0;
        }

        public static void Create(Dictionary<int,int> _ProductoCantidad,string _Comentarios,int _IdUsuario)
        {
            //get user y agregarlo como objeto arriba para obtener el di usuario
            //Cambiar diccionario por lista para poder tomar el primer ID sin iterara

            List<ProductoVendido> listaProductosVendidos = new List<ProductoVendido>();
            Venta _Venta = new Venta();
            int idVenta = VentaRepository.Create(_IdUsuario);



            _Venta.Usuario = UsuarioRepository.Get(_IdUsuario);
            _Venta.Comentarios = _Comentarios;

            foreach (var products in _ProductoCantidad)
            {
                listaProductosVendidos.Add(ProductoVendidoRepository.Crear(products.Key, products.Value,idVenta));
            }
            _Venta.Productos = listaProductosVendidos;
            _Venta.Productos[0].ID = _IdUsuario;


        }//FALTA VALIDAR QUE SEAN PRODUCTOS DEL MISMO USUARIO

        public static void Delete(int _idParameter)
        {
            using (SqlConnection connection = RepositoryTools.GetConnection())
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.Parameters.Add(new SqlParameter("id", System.Data.SqlDbType.Int) { Value = _idParameter });
                cmd.CommandText = @"
                                    DELETE FROM Venta WHERE id = @id
                                ";
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

    }
}