using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Evaluasi_DTS.model
{
    class Karyawan
    {
        public int Id { get; set; }
        public int NIP { get; set; }
        public int NIK { get; set; }
        public string Nama { get; set; }
        public string Jenis_Kelamin { get; set; }
        public string Tempat { get; set; }
        public string Tanggal { get; set; }
        public int Telp { get; set; }
        public string Agama { get; set; }
        public string Alamat { get; set; }

    }

    class Cuti
    {
        public int Id { get; set; }
        public int Karyawan_id { get; set; }
        public int Tanggal_cuti { get; set; }
        public int Jumlah { get; set; }


    }
    class Lembur
    {
        public int Id { get; set; }
        public int Karyawan_id { get; set; }
        public int Tanggal_Lembur { get; set; }
        public int Jumlah { get; set; }


    }
    
}
