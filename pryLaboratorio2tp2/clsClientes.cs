using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; 
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO;



namespace pryLaboratorio2tp2
{
    internal class clsClientes
    {
        private OleDbConnection conexion = new OleDbConnection();
        private OleDbCommand comando = new OleDbCommand();
        private OleDbDataAdapter adaptador = new OleDbDataAdapter();

        private String cadenaConexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Clientes.mdb";
        private String Tabla = "Cliente";


        private Decimal deuda;
        private Int32 cantidad;
        public Decimal TotalDeuda
        {
            get { return deuda; }
        }
        public Int32 CantidadDeudores
        {
            get { return cantidad; }
        }
        public void Listar(DataGridView grilla)
        {
            try
            {
                conexion.ConnectionString = cadenaConexion;
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.TableDirect;
                comando.CommandText = Tabla;

                adaptador = new OleDbDataAdapter(comando);
                DataSet DS = new DataSet();

                grilla.DataSource = DS.Tables[0];

                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

         }

        public void ListarDeudores(DataGridView grilla)
        {
            try
            {
                conexion.ConnectionString = cadenaConexion;
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = Tabla;

                OleDbDataReader DR = comando.ExecuteReader();

                cantidad = 0;
                deuda = 0;
                grilla.Rows.Clear();


                if (DR.HasRows)
                {
                    while (DR.Read())
                    {
                        if (DR.GetDecimal(2) > 0)
                        {
                            grilla.Rows.Add(DR.GetInt32(0), DR.GetString(1), DR.GetInt32(2));
                            cantidad++;
                            deuda = deuda + DR.GetDecimal(2);
                        }
                    }
                }
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
         }

        public void ReporteCliente()
        {
            try
            {
                conexion.ConnectionString = cadenaConexion;
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = Tabla;

                OleDbDataReader DR = comando.ExecuteReader();
                StreamWriter AD = new StreamWriter("ReporteClientes.csv",false,Encoding.UTF8);

                AD.WriteLine("Listado de clientes\n");
                AD.WriteLine("Codigo; Nombre; Deuda");

                cantidad = 0;
                deuda = 0;
               


                if (DR.HasRows)
                {
                    while (DR.Read())
                    {
                        AD.Write(DR.GetInt32(0));
                        AD.Write(";");
                        AD.Write(DR.GetString(1));
                        AD.Write(";");
                        AD.WriteLine(DR.GetDecimal(2));

                            cantidad++;
                            deuda = deuda + DR.GetDecimal(2);
                        
                    }
                    AD.Write("Cantidad de clientes:;;");
                    AD.WriteLine(cantidad);
                    AD.Write("Cantidad de deudores:;;");
                    AD.WriteLine(deuda);
                    AD.Write("Promedio de deuda:;;");
                    AD.WriteLine(deuda/cantidad);
                    AD.Close();
                }
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }   
}
