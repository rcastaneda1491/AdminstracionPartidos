using AdminitracionDeTorneosP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminitracionDeTorneosP.View
{
    public partial class ViewReporteDisponibilidadCancha : Form
    {
        private string connectionString = "Server=DESKTOP-U4PFR0A;Database=PROYECTO_TORNEOS;User Id=Rogelio;Password=12345;";
        string[,] disponibilidad;
        DateTime[] fechas;

        public ViewReporteDisponibilidadCancha()
        {
            InitializeComponent();
            getCanchas(cbxCanchas);
        }

        public void getCanchas(ComboBox cbx)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cbx.Items.Clear();
                connection.Open();
                
                SqlCommand sql = new SqlCommand("SELECT * FROM CANCHA", connection);
                
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    cbx.Items.Add($"{dr[0]}| {dr[1]}");
                }
                connection.Close();
            }
        }

        public List<Horario> getHorario()
        {
            List<Horario> horarios = new List<Horario>();
            string query = "SELECT * FROM HORARIO";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        Horario horario = new Horario();
                        horario.dia = reader.GetString(0);
                        horario.horaApertura = reader.GetTimeSpan(1);
                        horario.horaCierre = reader.GetTimeSpan(2);
                        horarios.Add(horario);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(),"Error al obtener los datos");
                }
            }
            return horarios;
        }

        public string getDisponibilidadCancha(DateTime fecha, TimeSpan horaInicio, TimeSpan horaFinal, int numeroCancha)
        {
            string query = "EXEC SP_REPORTE_DISPONIBILIDAD_CANCHA @Fecha, @HoraInicio, @HoraFinal, @NumeroCancha";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Fecha", fecha.Date);
                sql.Parameters.AddWithValue("@HoraInicio", horaInicio);
                sql.Parameters.AddWithValue("@HoraFinal", horaFinal);
                sql.Parameters.AddWithValue("@NumeroCancha", numeroCancha);

                connection.Open();
                //Ejecuta el query
                SqlDataReader reader = sql.ExecuteReader();
                if (!reader.HasRows)
                {
                    reader.Close();
                    connection.Close();
                    return "Diponible";
                }
                else
                {
                    reader.Close();
                    connection.Close();
                    return "No Diponible";
                }

            }
        }

        private void updateTable()
        {
            string stringCancha = Convert.ToString(cbxCanchas.SelectedItem);
            string[] ArrelgoCancha = stringCancha.Split('|');
            int numeroCancha = Convert.ToInt32(ArrelgoCancha[0]);
            List<Horario> horario = getHorario();

            TimeSpan restaFechas = Convert.ToDateTime(txtFechaFinal.Text).Date - Convert.ToDateTime(txtFechaInicio.Text).Date;
            int cantidadDias = restaFechas.Days;

            TimeSpan horaMayor = horario[0].horaCierre - horario[0].horaApertura;
            int cantidadHorasMayor = horaMayor.Hours;
            TimeSpan Apertura = horario[0].horaApertura;
            TimeSpan Cierre = horario[0].horaCierre;

            DateTime fechaInicio = Convert.ToDateTime(txtFechaInicio.Text).Date;
            DateTime fechaFinal = Convert.ToDateTime(txtFechaFinal.Text).Date;

            int contador = 0;
            fechas = new DateTime[cantidadDias + 1];
            
            while (fechaInicio <= fechaFinal)
            {
                fechas[contador] = fechaInicio;
                fechaInicio += new TimeSpan(1, 0, 0, 0);
                Console.WriteLine(fechas[contador]);
                contador++;
            }

            for (int i = 1; i < horario.Count; i++)
            {
                TimeSpan diferenciaHoras = horario[i].horaCierre - horario[i].horaApertura;
                int horas = diferenciaHoras.Hours;

                if (horas > cantidadHorasMayor)
                {
                    cantidadHorasMayor = horas;
                    Apertura = horario[i].horaApertura;
                    Cierre = horario[i].horaCierre;
                }

            }

            TimeSpan Inicial = Apertura;
            disponibilidad = new string[cantidadHorasMayor + 1, cantidadDias + 2];

            disponibilidad[0, 0] = "|";

            for (int i = 1; i <= cantidadHorasMayor; i++)
            {
                disponibilidad[i, 0] = $"{Apertura}-{Apertura + new TimeSpan(1, 0, 0)}";
                Apertura += new TimeSpan(1, 0, 0);
                Console.WriteLine(disponibilidad[i, 0]);
            }

            int contador2 = 0;
            for (int i = 1; i <= cantidadDias + 1; i++)
            {
                disponibilidad[0, i] = $"{fechas[contador2]}";

                Console.WriteLine(disponibilidad[0, i]);
                contador2++;
            }

            for (int horas = 1; horas <= cantidadHorasMayor; horas++)
            {
                string horarioIndividual = Convert.ToString(disponibilidad[horas, 0]);
                string[] arrayHorario = horarioIndividual.Split('-');

                for (int dias = 1; dias <= cantidadDias + 1; dias++)
                {
                    TimeSpan Horauno = new TimeSpan(Convert.ToDateTime(arrayHorario[0]).Hour, Convert.ToDateTime(arrayHorario[0]).Minute, Convert.ToDateTime(arrayHorario[0]).Second);
                    TimeSpan Horados = new TimeSpan(Convert.ToDateTime(arrayHorario[1]).Hour, Convert.ToDateTime(arrayHorario[1]).Minute, Convert.ToDateTime(arrayHorario[1]).Second);

                    disponibilidad[horas, dias] = getDisponibilidadCancha(Convert.ToDateTime(disponibilidad[0, dias]), Horauno, Horados, numeroCancha);
                }
            }

            int heigth = cantidadHorasMayor;
            int width = cantidadDias + 2;

            this.listDisponibilidad.ColumnCount = width;

            for (int f = 0; f <= heigth; f++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.listDisponibilidad);
                for (int c = 0; c < width; c++)
                {
                    row.Cells[c].Value = disponibilidad[f, c];
                }
                this.listDisponibilidad.Rows.Add(row);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listDisponibilidad.Rows.Clear();
            updateTable();
        }
    }
}
