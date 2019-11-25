using System;

namespace ProjectGym.Application.ConnectionString
{
    public static class ConnectionString
    {
        //private const string Server = @"BAI-HTLJ362";
        private const string Server = @"DESKTOP-SODKE63\MSSQLSERVER2";
        private const string DataBase = "ProjectGym2";
        private const string User = "sa";
        private const string Password = "Mat19931993";

        public static string GetConnectionStringSql => $"Data Source={Server}; " +
                                                       $"Initial Catalog={DataBase}; " +
                                                       $"User Id={User}; " +
                                                       $"Password={Password};";
        public static string GetConnectionStringWin => $"Data Source={Server}; " +
                                                       $"Initial Catalog={DataBase}; " +
                                                       $"Integrated Security = true";
    }
}
