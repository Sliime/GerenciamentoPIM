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

        public List<Aluno> Consultar()
        {
            List<Aluno> _alunos = new List<Aluno>();

            try
            {
                string conexaoAccess = ConfigurationManager.ConnectionStrings["conexaoAccess"].ToString();

                OleDbConnection conexaoDb = new OleDbConnection(conexaoAccess);

                conexaoDb.Open();

                
                string query = "SELECT * FROM PIM_TABELA";

                OleDbCommand cmd = new OleDbCommand(query, conexaoDb);
                OleDbDataReader getLista = cmd.ExecuteReader();

                
                while (getLista.Read())
                {

                    _alunos.Add(new Aluno() {
                         codigo = Convert.ToInt32(getLista[0]),
                         Nome = getLista[1].ToString(),
                         Disciplina = getLista[2].ToString()
                     });
                }
                getLista.Close();

                return _alunos;
            }
            catch (Exception ex)
            {
                throw ex;
                

            }

        }

    }
}