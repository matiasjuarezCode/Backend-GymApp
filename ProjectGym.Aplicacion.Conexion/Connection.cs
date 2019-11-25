using System;

namespace ProjectGym.Aplicacion.Connection
{
    public static class Connection
    {
        private const string Server = @"DESKTOP-SODKE63";
        private const string DataBase = "Evento1";
        private const string User = "";
        private const string Password = "";

        public static string GetConnectionStringSql => $"Data Source={Server}; " +
                                                         $"Initial Catalog={DataBase}; " +
                                                         $"User Id={User}; " +
                                                         $"Password={Password};";
        public static string GetConnectionStringWin => $"Data Source={Server}; " +
                                                         $"Initial Catalog={DataBase}; " +
                                                         $"Integrated Security = true";
    }
}
