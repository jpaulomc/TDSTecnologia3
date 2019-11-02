using System;

namespace TDSTecnologia.Site.Infrastructure.Data
{
    public class Databases
    {
        private static readonly Databases instance = new Databases();

        /**
         * Lê o valor da variável de ambiente ASPNETCORE_DB_CONNECTION
         * 
         */
        public string Conexao {
            get{
                return Environment.GetEnvironmentVariable("ASPNETCORE_DB_CONNECTION");
            }
        }

        private Databases() { }

        public static Databases Instance
        {
            get
            {
                return instance;
            }
        }

    }
}
