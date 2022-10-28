using SistemaGestionWEB.Models;
using System.Data.SqlClient;

namespace SistemaGestionWEB.Repository
{
    public class ProductoVendidoRepository
    {
        public static List<ProductoVendido> Get()
        {

            var ProductosVendidos = new List<ProductoVendido>();

            using (SqlConnection connection = RepositoryTools.GetConnection())
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = @"
                    SELECT 
						id,
						Stock as Cantidad,
						IdProducto,
						idVenta
					FROM ProductoVendido
                    ";


                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var pVendido = new ProductoVendido();

                    pVendido.ID = Convert.ToInt32(reader.GetValue(0));
                    pVendido.Cantidad = Convert.ToInt32(reader.GetValue(1));
                    pVendido.Producto = ProductoRepository.Get(Convert.ToInt32(reader.GetValue(2)));
                    pVendido.IDVenta = Convert.ToInt32(reader.GetValue(3));

                    ProductosVendidos.Add(pVendido);

                }

                /*
                //Validadciones console
                foreach (var pVendido in ProductosVendidos)
                {
                    Console.WriteLine(pVendido.ToString());
                }
                Console.WriteLine("\n");
                */

                reader.Close();
                connection.Close();
            }

            return ProductosVendidos;

        }

        public static ProductoVendido Get(int _id)
        {

            ProductoVendido pv = new ProductoVendido();

            using (SqlConnection connection = RepositoryTools.GetConnection())
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.Parameters.Add(new SqlParameter("id", System.Data.SqlDbType.Int) { Value = _id });

                cmd.CommandText = @"
                    SELECT 
						id,
						Stock as Cantidad,
						IdProducto,
						idVenta
					FROM ProductoVendido
                    WHERE id = @id
                    ";


                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var pVendido = new ProductoVendido();

                    pVendido.ID = Convert.ToInt32(reader.GetValue(0));
                    pVendido.Cantidad = Convert.ToInt32(reader.GetValue(1));
                    pVendido.Producto = ProductoRepository.Get(Convert.ToInt32(reader.GetValue(2)));
                    pVendido.IDVenta = Convert.ToInt32(reader.GetValue(3));

                    pv = pVendido;
                }

                //Validadciones console
                //Console.WriteLine(pv.ToString() + "\n");

                reader.Close();
                connection.Close();
            }

            return pv;

        }

        public static ProductoVendido GetByUserId(int _UserId)
        {

            return null;
        }//Terminar

        public static List<ProductoVendido> GetByIdVenta(int _VentaID)
        {

            var ProductosVendidos = new List<ProductoVendido>();

            using (SqlConnection connection = RepositoryTools.GetConnection())
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.Parameters.Add(new SqlParameter("id", System.Data.SqlDbType.Int) { Value = _VentaID });

                cmd.CommandText = @"
                    SELECT 
						id,
						Stock as Cantidad,
						IdProducto,
						idVenta
					FROM ProductoVendido
                    WHERE idVenta = @id
                    ";


                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var pVendido = new ProductoVendido();

                    pVendido.ID = Convert.ToInt32(reader.GetValue(0));
                    pVendido.Cantidad = Convert.ToInt32(reader.GetValue(1));
                    pVendido.Producto = ProductoRepository.Get(Convert.ToInt32(reader.GetValue(2)));
                    pVendido.IDVenta = Convert.ToInt32(reader.GetValue(3));

                    ProductosVendidos.Add(pVendido);

                    //Validaciones console
                    //Console.WriteLine(pVendido.ToString());

                }

                reader.Close();
                connection.Close();
            }

            return ProductosVendidos;

        }

        public static ProductoVendido Crear(int _IdProducto, int _Cantidad, int _IdVenta)
        {
            using (SqlConnection connection = RepositoryTools.GetConnection())
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.Parameters.Add(new SqlParameter("stock", System.Data.SqlDbType.Int) { Value = _Cantidad });
                cmd.Parameters.Add(new SqlParameter("idProducto", System.Data.SqlDbType.Int) { Value = _IdProducto });
                cmd.Parameters.Add(new SqlParameter("idVenta", System.Data.SqlDbType.Int) { Value = _IdVenta });
                cmd.CommandText = @"
									INSERT INTO ProductoVendido(Stock,IdProducto,IdVenta)
									VALUES (@stock,@idProducto,@idVenta); SELECT @@IDENTITY
                                ";
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                if (id > 0)
                {
                    ProductoVendido productoVendido = new ProductoVendido()
                    {
                        ID = id,
                        Cantidad = _Cantidad,
                        Producto = ProductoRepository.Get(_IdProducto),
                        IDVenta = _IdVenta
                    };
                    return productoVendido;
                }
                connection.Close();
            }
            return null;
        }

        public static void Crear(Dictionary<Producto,int> _ProductoCantidad)
        {

        }

    }
}
