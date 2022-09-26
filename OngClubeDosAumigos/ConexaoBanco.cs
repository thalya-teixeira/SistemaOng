using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngClubeDosAumigos
{
    internal class ConexaoBanco
    {
        //conectar com o banco de dados // obj de string de conexao // initial catalog é o USE do sql
        string Conexao = "Data Source= localhost; Initial Catalog=ONGClubeDosAumigos; User Id = sa; Password = password;";

        public ConexaoBanco()
        {

        }

        public string Caminho()
        {
            return Conexao;
        }
        
        #region Método para tratar os dados que serão inseridos no banco pelo usuário
        public string TratamentoDado(string dado)
        {
            string dadoTratado = dado.Replace(".", "").Replace("-", "").Replace("'", "").Replace("]", "").Replace("[", "");
            return dadoTratado;
        }
        #endregion

    }
}
