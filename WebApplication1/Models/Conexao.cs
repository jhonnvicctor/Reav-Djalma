using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebApplication1.Models
{
    public class Conexao : IDisposable
    {
        public SqlConnection conn;

        public Conexao()
        {
            conectar();
        }

        private void conectar()
        {
            string strconx = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Reav Project;Data Source=DESKTOP-OSU2GLA\\SQLEXPRESSS";
            conn = new SqlConnection(strconx);

            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Dispose()
        {
            conn.Close();
            conn.Dispose();
        }

        public void FecharConexao()
        {
            conn.Close();
            conn.Dispose();
        }


    }
}