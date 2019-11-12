using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Configuration;
using System.Data;

namespace GerenciamentoPIM.Models
{

    public class Tarefas
    {
        public int codigo { get; set; }
        public string Nome { get; set; }
        public string Tarefa { get; set; }
        public DateTime Data { get; set; }

        // "UPDATE PIM_TABELA SET aluno = ?, Tarefa = ?, Data_Entrega = ? WHERE Código = ?"

        public bool Cadastrar(Tarefas aluno)
        {
            try
            {
                string conexaoAccess = ConfigurationManager.ConnectionStrings["conexaoAccess"].ToString();

                OleDbConnection conexaoDb = new OleDbConnection(conexaoAccess);

                conexaoDb.Open();

                string query = "INSERT INTO PIM_TABELA (aluno, Tarefa, Data_Entrega) VALUES (@Nome, @Tarefa, Data)";

                OleDbCommand cmd = new OleDbCommand(query, conexaoDb);



                var parametroNome = cmd.CreateParameter();
                parametroNome.ParameterName = "@Nome";
                parametroNome.DbType = DbType.String;
                parametroNome.Value = aluno.Nome;
                cmd.Parameters.Add(parametroNome);

                var parametroTarefa = cmd.CreateParameter();
                parametroTarefa.ParameterName = "@Tarefa";
                parametroTarefa.DbType = DbType.String;
                parametroTarefa.Value = aluno.Tarefa;
                cmd.Parameters.Add(parametroTarefa);

                var parametroData = cmd.CreateParameter();
                parametroData.ParameterName = "@Data";
                parametroData.DbType = DbType.String;
                parametroData.Value = aluno.Data;
                cmd.Parameters.Add(parametroData);




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

        public List<Tarefas> Consultar()
        {
            List<Tarefas> _alunos = new List<Tarefas>();

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

                    _alunos.Add(new Tarefas() {
                         codigo = Convert.ToInt32(getLista[0]),
                         Nome = getLista[1].ToString(),
                         Tarefa = getLista[2].ToString(),
                         Data = Convert.ToDateTime(getLista[3])

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

        public void Deletar(int id)
        {
            try
            {
                string conexaoAccess = ConfigurationManager.ConnectionStrings["conexaoAccess"].ToString();

                OleDbConnection conexaoDb = new OleDbConnection(conexaoAccess);

                conexaoDb.Open();

                string query = "DELETE FROM PIM_TABELA WHERE (Código) = (@Id)";

                OleDbCommand cmd = new OleDbCommand(query, conexaoDb);


                var parametroId = cmd.CreateParameter();
                parametroId.ParameterName = "@Id";
                parametroId.DbType = DbType.String;
                parametroId.Value = id;
                cmd.Parameters.Add(parametroId);




                if (cmd.ExecuteNonQuery() > 0)
                {

                    conexaoDb.Close();
                   
                }

                else
                {
                    conexaoDb.Close();
                    
                }


            }
            catch (Exception ex)
            {
               

            }

        }

        public void Editar(Tarefas aluno)
        {
            try
            {
                string conexaoAccess = ConfigurationManager.ConnectionStrings["conexaoAccess"].ToString();

                OleDbConnection conexaoDb = new OleDbConnection(conexaoAccess);

                conexaoDb.Open();

                string query = "UPDATE PIM_TABELA SET aluno = ?, Tarefa = ?, Data_Entrega = ? WHERE Código = ?";

                OleDbCommand cmd = new OleDbCommand(query, conexaoDb);



                var parametroNome = cmd.CreateParameter();
                parametroNome.ParameterName = "@Nome";
                parametroNome.DbType = DbType.String;
                parametroNome.Value = aluno.Nome;
                cmd.Parameters.Add(parametroNome);

                var parametroTarefa = cmd.CreateParameter();
                parametroTarefa.ParameterName = "@Tarefa";
                parametroTarefa.DbType = DbType.String;
                parametroTarefa.Value = aluno.Tarefa;
                cmd.Parameters.Add(parametroTarefa);

                var parametroData = cmd.CreateParameter();
                parametroData.ParameterName = "@Data";
                parametroData.DbType = DbType.String;
                parametroData.Value = aluno.Data;
                cmd.Parameters.Add(parametroData);

                var pmtId = cmd.CreateParameter();
                pmtId.ParameterName = "@Id";
                pmtId.DbType = DbType.Int32;
                pmtId.Value = aluno.codigo;
                cmd.Parameters.Add(pmtId);



                if (cmd.ExecuteNonQuery() > 0)
                {

                    conexaoDb.Close();
                    
                }

                else
                {
                    conexaoDb.Close();
                    
                }


            }
            catch (Exception ex)
            {
             

            }
        }
    }
}