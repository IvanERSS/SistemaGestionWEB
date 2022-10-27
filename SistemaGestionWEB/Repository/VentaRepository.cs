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

        public static void Create(Dictionary<int,int> _ProductoCantidad,string _Comentarios)
        {
            List<ProductoVendido> listaProductosVendidos = new List<ProductoVendido>();
            Venta _Venta = new Venta();

            foreach (var producto in _ProductoCantidad)
            {
                //listaProductosVendidos.Add(ProductoVendidoRepository.Crear(producto.Key, producto.Value,));
            }

            _Venta.Productos = listaProductosVendidos;
            _Venta.Comentarios = _Comentarios;
        }
    }
}
