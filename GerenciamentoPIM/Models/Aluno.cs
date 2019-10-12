using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Configuration;
using System.Data;

namespace GerenciamentoPIM.Models
{

    public class Aluno
    {
        public int codigo { get; set; }
        public string Nome { get; set; }
        public string Disciplina { get; set; }




        public bool Cadastrar(Aluno aluno)
        {
            try
            {
                string conexaoAccess = ConfigurationManager.ConnectionStrings["conexaoAccess"].ToString();

                OleDbConnection conexaoDb = new OleDbConnection(conexaoAccess);

                conexaoDb.Open();

                string query = "INSERT INTO PIM_TABELA (aluno, disciplina) VALUES (@Nome, @Disciplina)";

                OleDbCommand cmd = new OleDbCommand(query, conexaoDb);

                var parametroDisciplina = cmd.CreateParameter();
                parametroDisciplina.ParameterName = "@Disciplina";
                parametroDisciplina.DbType = DbType.String;
                parametroDisciplina.Value = aluno.Disciplina;
                cmd.Parameters.Add(parametroDisciplina);

                var parametroNome = cmd.CreateParameter();
                parametroNome.ParameterName = "@Nome";
                parametroNome.DbType = DbType.String;
                parametroNome.Value = aluno.Nome;
                cmd.Parameters.Add(parametroNome);




                 if (cmd.ExecuteNonQuery() > 0)
                {

                    conexaoDb.Close();
                    return true;
                }

                else
                {
                    conexaoDb.Close();
                    return false;
                }

                 
            }
            catch (Exception ex)
            {
                return false;

            }

        }

        public static void Consultar()
        {
            try
            {
                string conexaoAccess = ConfigurationManager.ConnectionStrings["conexaoAccess"].ToString();

                OleDbConnection conexaoDb = new OleDbConnection(conexaoAccess);

                conexaoDb.Open();

                
                string query = "SELECT aluno FROM PIM_TABELA";

                OleDbCommand cmd = new OleDbCommand(query, conexaoDb);
                OleDbDataReader getLista = cmd.ExecuteReader();


                while (getLista.Read())
                {
                    var teste =getLista[0].ToString();
                }
                getLista.Close();


            }
            catch (Exception ex)
            {
               

            }

        }

    }
}