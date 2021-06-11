using AdminitracionDeTorneosP.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminitracionDeTorneosP.Database
{
    class HorarioDB
    {
        private string connectionString = "Server=DESKTOP-U4PFR0A;Database=PROYECTO_TORNEOS;User Id=Rogelio;Password=12345;";

        public void addHorario(Horario horario)
        {
            string query = "EXEC SP_INSERT_HORARIO @Dia,@HoraApertura, @HoraCierre";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Dia", horario.dia);
                command.Parameters.AddWithValue("@HoraApertura", horario.horaApertura);
                command.Parameters.AddWithValue("@HoraCierre", horario.horaCierre);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Horario Agregado Correctamente");
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al insertar Horario" + error.Message, "ERROR");
                }
            }
        }

        public void updateHorario(Horario horario)
        {
            string query = "EXEC SP_UPDATE_HORARIO @Dia,@HoraApertura, @HoraCierre";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Dia", horario.dia);
                command.Parameters.AddWithValue("@HoraApertura", horario.horaApertura);
                command.Parameters.AddWithValue("@HoraCierre", horario.horaCierre);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Horario Actualizado Correctamente");
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al insertar Horario" + error.Message, "ERROR");
                }
            }
        }

        public void getHorarios(DataGridView list)
        {
            string query = "SELECT * FROM HORARIO";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter sqll = new SqlDataAdapter(query, connection);
                    DataTable data = new DataTable();

                    sqll.Fill(data);
                    list.DataSource = data;
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se pudo realizar la consulta");
                }
            }
        }



        public Horario getHorarioById(string dia)
        {
            Horario horario = new Horario();
            string query = "SELECT * FROM HORARIO WHERE Dia = @Dia";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Dia", dia);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read();

                    horario.horaApertura = TimeSpan.FromHours(1);
                    horario.horaCierre = TimeSpan.FromHours(2);

                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al obtener los datos" + error, "ERROR");
                }
                return horario;
            }
        }
    }
}
