using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpidemProc
{
    class Doctor
    {
        public int Id { get; set; }
        public int CitizenId { get; set; }
        public int HospitalId { get; set; }
        public bool Initiative { get; set; }
        public int Quality { get; set; }


        public static SqlCommand PrepareCommand(SqlCommand command)
        {
            Doctor _doctor = new Doctor();//Гражданин

            command.CommandText = @"select ID, CITIZENS_ID, HOSPITAL_ID, INICIATIVE, QUALITY from dbo.DOCTORS";

            command.Parameters.Add("ID",            SqlDbType.Int).Value = _doctor.Id;
            command.Parameters.Add("CITIZENS_ID",   SqlDbType.Int).Value = _doctor.CitizenId;
            command.Parameters.Add("HOSPITAL_ID",   SqlDbType.Int).Value = _doctor.HospitalId;
            command.Parameters.Add("INICIATIVE",    SqlDbType.Bit).Value = _doctor.Initiative;
            command.Parameters.Add("QUALITY",       SqlDbType.Int).Value = _doctor.Quality;
            return command;
        }
        public static Doctor Get(SqlDataReader reader)
        {
            int i = 0;
            return new Doctor
            {
                Id          = reader.GetInt32(i++),
                CitizenId   = reader.GetInt32(i++),
                HospitalId  = reader.GetInt32(i++),
                Initiative  = reader.GetBoolean(i++),
                Quality     = reader.GetInt32(i++)
            };
        }
    }
}
