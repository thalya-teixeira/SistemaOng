using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngClubeDosAumigos
{
    internal class ConexaoBanco
    {
        //conectar com o banco de dados // obj de string de conexao // initial catalog é o USE do sql
        string Conexao = "Data Source= localhost; Initial Catalog=ONGClubeDosAumigos; User Id = sa; Password = th031425;";

        public ConexaoBanco()
        {

        }

        public string Caminho()
        {
            return Conexao;
        }
    }
}
