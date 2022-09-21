using Microsoft.Identity.Client;
using System;
using System.Data.SqlClient;
using Project_Evaluasi_DTS.model;


namespace Project_Evaluasi_DTS
{
    class Program
    {
        SqlConnection sqlConnection;

        /*
         * Data Source -> Server
         * Initial Catalog -> Database
         * User ID -> username
         * Password -> password
         * Connect Timeout
         */

        public static void Main(string[] args)
        {

            Program program = new Program();

            program.Menu();
        }

        void Menu()
        {
            int input;
            Program pengaturan = new Program();
            Console.WriteLine("=====================");
            Console.WriteLine("======== M E N U =======\n");
            Console.WriteLine("");
            Console.WriteLine("1. Data Karyawan");
            Console.WriteLine("2. Data Cuti");
            Console.WriteLine("3. Data Lembur");
            Console.WriteLine("Masukan Kode : ");
            input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:

                    pengaturan.karyawan();
                    break;
                case 2:
                    pengaturan.Cuti();
                    break;
                case 3:
                    pengaturan.lembur();
                    break;

                default:
                    break;
            }
        }


        void karyawan()
        {

            String connectionString;
            connectionString = "Data Source=LAPTOP-LDJ6J02G;Initial Catalog=Db_Kantors;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            int Nip, Nik, Nomor;
            string Nama, Jkelamin, Tempat, Agama, Alamat, masukan;
            string Tanggal;
            Console.WriteLine("=====================");
            Console.WriteLine("======== DATA KARYAWAN =======\n");
            Console.WriteLine("");
            Console.WriteLine("Masukkan Data");
            Console.Write("NIP : ");
            Nip = int.Parse(Console.ReadLine());
            Console.Write("NIK : ");
            Nik = int.Parse(Console.ReadLine());
            Console.Write("Nama : ");
            Nama = Console.ReadLine();
            Console.Write("Jenis Kelamin (Pria/Wanita) : ");
            Jkelamin = Console.ReadLine();
            Console.Write("Tempat Lahir : ");
            Tempat = Console.ReadLine();
            Console.Write("Tanggal Lahir : ");
            Tanggal = Console.ReadLine();
            Console.Write("Nomor Telp : ");
            Nomor = int.Parse(Console.ReadLine());
            Console.Write("Agama (Islam/Protestan/Katolik/Hindu/Buddha/Khonghucu) :");
            Agama = Console.ReadLine();
            Console.Write("Alamat : ");
            Alamat = Console.ReadLine();
            Console.Write("yakin untuk disimpan ? (y/t): ");
            masukan = Console.ReadLine();
            switch (masukan)
            {
                case "y":

                    Program program = new Program();
                    Karyawan karyawan = new Karyawan();
                    program.Insert(karyawan);

                    program.ViewAll(karyawan);
                    program.karyawan();



                    break;


                default:
                    break;
            }

        }

        void Insert(Karyawan karyawan)
        {
            String connectionString;
            connectionString = "Data Source=LAPTOP-LDJ6J02G;Initial Catalog=Db_Kantors;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            sqlConnection = new SqlConnection(connectionString);
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter1 = new SqlParameter();
                sqlParameter1.ParameterName = "@Id";
                sqlParameter1.Value = karyawan.Id;

                SqlParameter sqlParameter2 = new SqlParameter();
                sqlParameter2.ParameterName = "@nip";
                sqlParameter2.Value = karyawan.NIP;

                SqlParameter sqlParameter3 = new SqlParameter();
                sqlParameter3.ParameterName = "@nik";
                sqlParameter3.Value = karyawan.NIK;

                SqlParameter sqlParameter4 = new SqlParameter();
                sqlParameter4.ParameterName = "@nama";
                sqlParameter4.Value = karyawan.Nama;

                SqlParameter sqlParameter5 = new SqlParameter();
                sqlParameter5.ParameterName = "@jenis";
                sqlParameter5.Value = karyawan.Jenis_Kelamin;

                SqlParameter sqlParameter6 = new SqlParameter();
                sqlParameter6.ParameterName = "@tempat";
                sqlParameter6.Value = karyawan.Tempat;

                SqlParameter sqlParameter7 = new SqlParameter();
                sqlParameter7.ParameterName = "@tanggal";
                sqlParameter7.Value = karyawan.Tanggal;

                SqlParameter sqlParameter8 = new SqlParameter();
                sqlParameter8.ParameterName = "@no";
                sqlParameter8.Value = karyawan.Telp;

                SqlParameter sqlParameter9 = new SqlParameter();
                sqlParameter9.ParameterName = "@agama";
                sqlParameter9.Value = karyawan.Agama;

                SqlParameter sqlParameter10 = new SqlParameter();
                sqlParameter10.ParameterName = "@alamat";
                sqlParameter10.Value = karyawan.Alamat;




                sqlCommand.Parameters.Add(sqlParameter1);
                sqlCommand.Parameters.Add(sqlParameter2);
                sqlCommand.Parameters.Add(sqlParameter3);
                sqlCommand.Parameters.Add(sqlParameter4);
                sqlCommand.Parameters.Add(sqlParameter5);
                sqlCommand.Parameters.Add(sqlParameter6);
                sqlCommand.Parameters.Add(sqlParameter7);
                sqlCommand.Parameters.Add(sqlParameter8);
                sqlCommand.Parameters.Add(sqlParameter9);
                sqlCommand.Parameters.Add(sqlParameter10);

                try
                {
                    sqlCommand.CommandText = "INSERT INTO Data_Karyawan " +
                        "VALUES (@Id, @nip, @nik, @nama, @jenis, @tempat,@tanggal," +
                        "@no, @agama,@alamat)";

                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        void ViewAll(Karyawan karyawan)
        {
            String connectionString;
            connectionString = "Data Source=LAPTOP-LDJ6J02G;Initial Catalog=Db_Kantors;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            sqlConnection = new SqlConnection(connectionString);
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;


                try
                {
                    sqlCommand.CommandText = "Select * FROM Data_Karyawan";

                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        void delet(Karyawan karyawan)
        {
            String connectionString;
            connectionString = "Data Source=LAPTOP-LDJ6J02G;Initial Catalog=Db_Kantors;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            sqlConnection = new SqlConnection(connectionString);
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter1 = new SqlParameter();
                sqlParameter1.ParameterName = "@Id";
                sqlParameter1.Value = karyawan.Id;

                sqlCommand.Parameters.Add(sqlParameter1);




                try
                {
                    sqlCommand.CommandText = "DELETE Data_Karyawan " +
                 "WHERE Id = " + "@Id"; ;

                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        void Cuti()
        {
            int id, karyawan_id, jumlah;
            string tanggal, masukan;
            Console.WriteLine("=====================");
            Console.WriteLine("======== DATA CUTI =======\n");
            Console.WriteLine("");
            Console.WriteLine("Masukkan Data");
            Console.Write("Id : ");
            id = int.Parse(Console.ReadLine());
            Console.Write("Karyawan Id : ");
            karyawan_id = int.Parse(Console.ReadLine());
            Console.Write("Tanggal cuti : ");
            tanggal = Console.ReadLine();
            Console.Write("Jumlah : ");
            jumlah = int.Parse(Console.ReadLine());
            Console.Write("yakin untuk disimpan ? (y/t): ");
            masukan = Console.ReadLine();
            switch (masukan)
            {
                case "y":

                    Program program = new Program();
                    Cuti cuti = new Cuti();
                    program.Insert(cuti);

                    program.ViewAll(cuti);
                    program.Cuti();



                    break;


                default:
                    break;
            }

        }

        void Insert(Cuti cuti
            )
        {
            String connectionString;
            connectionString = "Data Source=LAPTOP-LDJ6J02G;Initial Catalog=Db_Kantors;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            sqlConnection = new SqlConnection(connectionString);
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter1 = new SqlParameter();
                sqlParameter1.ParameterName = "@Id";
                sqlParameter1.Value = cuti.Id;

                SqlParameter sqlParameter2 = new SqlParameter();
                sqlParameter2.ParameterName = "@kid";
                sqlParameter2.Value = cuti.Karyawan_id;

                SqlParameter sqlParameter3 = new SqlParameter();
                sqlParameter3.ParameterName = "@tgg";
                sqlParameter3.Value = cuti.Tanggal_cuti;

                SqlParameter sqlParameter4 = new SqlParameter();
                sqlParameter4.ParameterName = "@jumlah";
                sqlParameter4.Value = cuti.Jumlah;

                sqlCommand.Parameters.Add(sqlParameter1);
                sqlCommand.Parameters.Add(sqlParameter2);
                sqlCommand.Parameters.Add(sqlParameter3);
                sqlCommand.Parameters.Add(sqlParameter4);


                try
                {
                    sqlCommand.CommandText = "INSERT INTO Cuti " +
                        "VALUES (@Id, @kid, @tgg, @jumlah)";

                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        void ViewAll(Cuti cuti)
        {
            String connectionString;
            connectionString = "Data Source=LAPTOP-LDJ6J02G;Initial Catalog=Db_Kantors;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            sqlConnection = new SqlConnection(connectionString);
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;



                try
                {
                    sqlCommand.CommandText = "Select * From Cuti";

                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        void delet(Cuti cuti)
        {
            String connectionString;
            connectionString = "Data Source=LAPTOP-LDJ6J02G;Initial Catalog=Db_Kantors;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            sqlConnection = new SqlConnection(connectionString);
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter1 = new SqlParameter();
                sqlParameter1.ParameterName = "@Id";
                sqlParameter1.Value = cuti.Id;

                sqlCommand.Parameters.Add(sqlParameter1);




                try
                {
                    sqlCommand.CommandText = "DELETE Cuti " +
                 "WHERE Id = " + "@Id"; ;

                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        void lembur()
        {
            int id, karyawan_id, jumlah;
            string tanggal, masukan;
            Console.WriteLine("=====================");
            Console.WriteLine("======== DATA LEMBUR =======\n");
            Console.WriteLine("");
            Console.WriteLine("Masukkan Data");
            Console.Write("Id : ");
            id = int.Parse(Console.ReadLine());
            Console.Write("Karyawan Id : ");
            karyawan_id = int.Parse(Console.ReadLine());
            Console.Write("Tanggal Lembur : ");
            tanggal = Console.ReadLine();
            Console.Write("Jumlah : ");
            jumlah = int.Parse(Console.ReadLine());
            Console.Write("yakin untuk disimpan ? (y/t): ");
            masukan = Console.ReadLine();
            switch (masukan)
            {
                case "y":

                    Program program = new Program();
                    Lembur lembur = new Lembur();
                    program.Insert(lembur);

                    program.ViewAll(lembur);
                    program.lembur();



                    break;


                default:
                    break;
            }
        }

        void Insert(Lembur lembur
            )
        {
            String connectionString;
            connectionString = "Data Source=LAPTOP-LDJ6J02G;Initial Catalog=Db_Kantors;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            sqlConnection = new SqlConnection(connectionString);
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter1 = new SqlParameter();
                sqlParameter1.ParameterName = "@Id";
                sqlParameter1.Value = lembur.Id;

                SqlParameter sqlParameter2 = new SqlParameter();
                sqlParameter2.ParameterName = "@kid";
                sqlParameter2.Value = lembur.Karyawan_id;

                SqlParameter sqlParameter3 = new SqlParameter();
                sqlParameter3.ParameterName = "@tgl";
                sqlParameter3.Value = lembur.Tanggal_Lembur;

                SqlParameter sqlParameter4 = new SqlParameter();
                sqlParameter4.ParameterName = "@jml";
                sqlParameter4.Value = lembur.Jumlah;


                sqlCommand.Parameters.Add(sqlParameter1);
                sqlCommand.Parameters.Add(sqlParameter2);
                sqlCommand.Parameters.Add(sqlParameter3);
                sqlCommand.Parameters.Add(sqlParameter4);

                try
                {
                    sqlCommand.CommandText = "INSERT INTO Lembur " +
                        "VALUES (@Id, @kid, @tgl, @jml )";

                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        void ViewAll(Lembur lembur)
        {
            String connectionString;
            connectionString = "Data Source=LAPTOP-LDJ6J02G;Initial Catalog=Db_Kantors;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            sqlConnection = new SqlConnection(connectionString);
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;




                try
                {
                    sqlCommand.CommandText = "Select * from Lembur";

                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            void delet(Lembur lembur)
            {
                String connectionString;
                connectionString = "Data Source=LAPTOP-LDJ6J02G;Initial Catalog=Db_Kantors;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                sqlConnection = new SqlConnection(connectionString);
                {
                    sqlConnection.Open();
                    SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.Transaction = sqlTransaction;

                    SqlParameter sqlParameter1 = new SqlParameter();
                    sqlParameter1.ParameterName = "@Id";
                    sqlParameter1.Value = lembur.Id;

                    sqlCommand.Parameters.Add(sqlParameter1);




                    try
                    {
                        sqlCommand.CommandText = "DELETE Lembur " +
                     "WHERE Id = " + "@Id"; ;

                        sqlCommand.ExecuteNonQuery();
                        sqlTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

        }


    }
}
