﻿using System.Data;
using System.Data.SqlClient;

namespace EpidemProc.Models
{
	class Citizen
	{
		public int Id { get; set; }
		public int Immunity { get; set; }
		public bool WasSick { get; set; }
		public int ProfessionId { get; set; }
		public int Health { get; set; }
		public int HealthStatus { get; set; }
		public bool HardWorker { get; set; }
		public bool SickLeave { get; set; }
		public bool Hospitalized { get; set; }
		public int FactureId { get; set; }
		public int HomeId { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
		public int Salary { get; set; }
		public int TrustTheDoctor { get; set; }


		public static SqlCommand PrepareCommand(SqlCommand command)
        {
            Citizen _citizen = new Citizen();
            command.CommandText = @"SELECT ID, IMMUNITY, WAS_SICK, PROFESSION_ID, HEALTH, HEALTH_STATUS, HARD_WORKER, SICK_LEAVE, HOSPITALIZED, FACTURE_ID, HOME_ID, X, Y, SALARY, TRUST_THE_DOCTOR from dbo.CITIZENS";

            command.Parameters.Add("ID",				SqlDbType.Int).Value =  _citizen.Id;
            command.Parameters.Add("IMMUNITY",			SqlDbType.Int).Value =  _citizen.Immunity;
            command.Parameters.Add("WAS_SICK",			SqlDbType.Bit).Value =  _citizen.WasSick;
            command.Parameters.Add("PROFESSION_ID",		SqlDbType.Int).Value =  _citizen.ProfessionId;
            command.Parameters.Add("HEALTH",			SqlDbType.Int).Value =  _citizen.Health;
            command.Parameters.Add("HEALTH_STATUS",		SqlDbType.Int).Value =  _citizen.HealthStatus;
            command.Parameters.Add("HARD_WORKER",		SqlDbType.Bit).Value =  _citizen.HardWorker;
            command.Parameters.Add("SICK_LEAVE",		SqlDbType.Bit).Value =  _citizen.SickLeave;
            command.Parameters.Add("HOSPITALIZED",		SqlDbType.Bit).Value =  _citizen.Hospitalized;
            command.Parameters.Add("FACTURE_ID",		SqlDbType.Int).Value =  _citizen.FactureId;
            command.Parameters.Add("HOME_ID",			SqlDbType.Int).Value = _citizen.HomeId;
            command.Parameters.Add("X",					SqlDbType.Int).Value =  _citizen.X;
            command.Parameters.Add("Y",					SqlDbType.Int).Value =  _citizen.Y;
            command.Parameters.Add("SALARY",			SqlDbType.Int).Value = _citizen.Salary;
			command.Parameters.Add("TRUST_THE_DOCTOR",	SqlDbType.Int).Value = _citizen.TrustTheDoctor;
			return command;
        }
        public static Citizen Get(SqlDataReader reader)
        {
            int i = 0;
            return new Citizen
            {
                Id              = reader.GetInt32(i++),
                Immunity        = reader.GetInt32(i++),
                WasSick         = reader.GetBoolean(i++),
                ProfessionId    = reader.GetInt32(i++),
                Health          = reader.GetInt32(i++),
                HealthStatus    = reader.GetInt32(i++),
                HardWorker      = reader.GetBoolean(i++),
                SickLeave       = reader.GetBoolean(i++),
                Hospitalized    = reader.GetBoolean(i++),
                FactureId       = reader.GetInt32(i++),
                HomeId          = reader.GetInt32(i++),
                X               = reader.GetInt32(i++),
                Y               = reader.GetInt32(i++),
                Salary          = reader.GetInt32(i++),
				TrustTheDoctor	= reader.GetInt32(i++)
			};
        }

    }
}
