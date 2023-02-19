using System;
using System.Collections.Generic;
using MySqlConnector;

namespace projeto_mf.Models
{
    public class CadastroBanco
    {
         // Dados de conexão
        private static string dadosConexao = "Database=mflanches; Data Source=localhost; User Id=root;";

        public static void Inserir (CadastroPedido cadastropedido)
        {
            MySqlConnection conexao = new MySqlConnection(dadosConexao);
            conexao.Open();
            string query = "INSERT INTO cadastropedido (Nome, Telefone, DataEntrega, Pedido, Quantidade) VALUES (@Nome, @Telefone, @DataEntrega, @Pedido, @Quantidade);";
            MySqlCommand comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@Nome", cadastropedido.Nome);
            comando.Parameters.AddWithValue("@Telefone", cadastropedido.Telefone);
            comando.Parameters.AddWithValue("@DataEntrega", cadastropedido.DataEntrega);
            comando.Parameters.AddWithValue("@Pedido", cadastropedido.Pedido);
            comando.Parameters.AddWithValue("@Quantidade", cadastropedido.Quantidade);
            comando.ExecuteNonQuery();
            conexao.Close();
        }


        public static List <CadastroPedido> Listar()
        {
            MySqlConnection conexao = new MySqlConnection(dadosConexao);
            conexao.Open();
            string query = "SELECT * FROM cadastropedido;";
            MySqlCommand comando = new MySqlCommand(query, conexao);
            MySqlDataReader leitor = comando.ExecuteReader();
            
            List<CadastroPedido> lista = new List<CadastroPedido>();

            while (leitor.Read()) {
                CadastroPedido cadastropedido = new CadastroPedido();

                if (!leitor.IsDBNull(leitor.GetOrdinal("Id")))
                    cadastropedido.Id = leitor.GetInt32("Id");
                if (!leitor.IsDBNull(leitor.GetOrdinal("Nome")))
                    cadastropedido.Nome = leitor.GetString("Nome");
                if (!leitor.IsDBNull(leitor.GetOrdinal("Telefone")))
                    cadastropedido.Telefone = leitor.GetInt32("Telefone");
                if (!leitor.IsDBNull(leitor.GetOrdinal("DataEntrega")))
                    cadastropedido.DataEntrega = leitor.GetString("DataEntrega");
                if (!leitor.IsDBNull(leitor.GetOrdinal("Pedido")))
                    cadastropedido.Pedido = leitor.GetString("Pedido");
                     if (!leitor.IsDBNull(leitor.GetOrdinal("Quantidade")))
                    cadastropedido.Quantidade = leitor.GetInt32("Quantidade");

                lista.Add(cadastropedido);
            }

            conexao.Close();
            return lista;
        }

        public static void Atualizar (CadastroPedido cadastropedido) {
            MySqlConnection conexao = new MySqlConnection(dadosConexao);
            conexao.Open();
            string query = "UPDATE cadastropedido SET Nome=@Nome, Telefone=@Telefone, DataEntrega=@DataEntrega, Pedido=@Pedido, Quantidade=@Quantidade WHERE Id=@Id;";
            MySqlCommand comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@Nome", cadastropedido.Nome);
            comando.Parameters.AddWithValue("@Telefone", cadastropedido.Telefone);
            comando.Parameters.AddWithValue("@DataEntrega", cadastropedido.DataEntrega);
            comando.Parameters.AddWithValue("@Pedido", cadastropedido.Pedido);
            comando.Parameters.AddWithValue("@Quantidade", cadastropedido.Quantidade);
            comando.Parameters.AddWithValue("@Id", cadastropedido.Id);
            comando.ExecuteNonQuery();
            conexao.Close();
        }        

        public static void Remover (int Id) {
            MySqlConnection conexao = new MySqlConnection(dadosConexao);
            conexao.Open();
            string query = "DELETE FROM cadastropedido WHERE Id=@Id;";
            MySqlCommand comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@Id", Id);
            comando.ExecuteNonQuery();
            conexao.Close();
        }        

        public static CadastroPedido BuscarPorId(int Id) {
            MySqlConnection conexao = new MySqlConnection(dadosConexao);
            conexao.Open();
            string query = "SELECT * FROM cadastropedido WHERE Id=@Id;";
            MySqlCommand comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@Id", Id);
            MySqlDataReader leitor = comando.ExecuteReader();
            
             CadastroPedido cadastropedido = new CadastroPedido();

            if (leitor.Read()) {
                if (!leitor.IsDBNull(leitor.GetOrdinal("Id")))
                    cadastropedido.Id = leitor.GetInt32("Id");
                if (!leitor.IsDBNull(leitor.GetOrdinal("Nome")))
                    cadastropedido.Nome = leitor.GetString("Nome");
                if (!leitor.IsDBNull(leitor.GetOrdinal("Telefone")))
                    cadastropedido.Telefone = leitor.GetInt32("Telefone");
                if (!leitor.IsDBNull(leitor.GetOrdinal("DataEntrega")))
                    cadastropedido.DataEntrega = leitor.GetString("DataEntrega");
                if (!leitor.IsDBNull(leitor.GetOrdinal("Pedido")))
                    cadastropedido.Pedido = leitor.GetString("Pedido");
                     if (!leitor.IsDBNull(leitor.GetOrdinal("Quantidade")))
                    cadastropedido.Quantidade = leitor.GetInt32("Quantidade");
            }

            conexao.Close();
            return cadastropedido;



    }
}