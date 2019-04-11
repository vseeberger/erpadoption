using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoProdutoOutrosFabricantes
    {
        internal static List<ProdutoOutrosFabricantes> Pesquisar(long _Produto)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      produto_outros_fornecedores.id");
            sql.AppendLine("    , produto_outros_fornecedores.id_produto");
            sql.AppendLine("    , produto_outros_fornecedores.id_fornecedor");
            sql.AppendLine("    , produto_outros_fornecedores.sequencia");
            sql.AppendLine("    , produto_outros_fornecedores.codigo_do_fabricante");
            sql.AppendLine("    , produto_outros_fornecedores.nome");
            sql.AppendLine("    , produto_outros_fornecedores.nome_generico");
            sql.AppendLine("    , produto_outros_fornecedores.data_cadastro");
            sql.AppendLine("    , produto_outros_fornecedores.data_ultalt");
            sql.AppendLine("    , produto_outros_fornecedores.status");

            sql.AppendLine("    , fornecedor.razaosocial_nome");
            sql.AppendLine("    , fornecedor.nomefantasia_apelido");

            sql.AppendLine("FROM produto_outros_fornecedores");
            sql.AppendLine("    INNER JOIN fornecedor ON fornecedor.id = produto_outros_fornecedores.id_fornecedor");
            sql.AppendLine("                         AND fornecedor.status = 1");
            sql.AppendLine("WHERE id_produto = @id_produto");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id_produto", _Produto);
            List<ProdutoOutrosFabricantes> Lst = new List<ProdutoOutrosFabricantes>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<ProdutoOutrosFabricantes>();
                    ProdutoOutrosFabricantes item = null;
                    while (scom.Read())
                    {
                        item = new ProdutoOutrosFabricantes()
                        {
                            Id = scom.GetValue<long>("id"),
                            Sequencia = scom.GetValue<int>("sequencia"),
                            IdProdutoOriginal = scom.GetValue<long>("id_produto"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            SCodigoDoFabricante = scom.GetValue<string>("codigo_do_fabricante"),
                            SNomeDoProdutoDoFabricante = scom.GetValue<string>("nome"),
                            SNomeGenerico = scom.GetValue<string>("nome_generico"),
                            Status = scom.GetValue<bool>("status"),
                            Fabricante = new Empresa(scom.GetValue<long>("id_fornecedor"), scom.GetValue<string>("razaosocial_nome"))
                        };
                        Lst.Add(item);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }

        internal static void Salvar(ProdutoOutrosFabricantes item)
        {
            if (item != null)
            {
                if (item.Id > 0) Alterar(item);
                else Inserir(item);
            }
        }

        private static void Inserir(ProdutoOutrosFabricantes item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO produto_outros_fornecedores(id_produto, id_fornecedor, sequencia, codigo_do_fabricante, nome, nome_generico)");
            sql.AppendLine("VALUES(@id_produto, @id_fornecedor, @sequencia, @codigo_do_fabricante, @nome, @nome_generico);SELECT LAST_INSERT_ID();");
            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id_produto", item.IdProdutoOriginal);
            scom.AddWithValue("@id_fornecedor", item.Fabricante.Id);
            scom.AddWithValue("@sequencia", item.Sequencia);
            scom.AddWithValue("@codigo_do_fabricante", item.SCodigoDoFabricante);
            scom.AddWithValue("@nome", item.SNomeDoProdutoDoFabricante);
            scom.AddWithValue("@nome_generico", item.SNomeGenerico);
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows && scom.Read())
                {
                    long l;
                    if (long.TryParse(scom.GetValue<object>(0).ToString(), out l)) { item.Id = l; item.Alterou = false; }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        private static void Alterar(ProdutoOutrosFabricantes item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE produto_outros_fornecedores SET");
            sql.AppendLine("      id_produto            = @id_produto");
            sql.AppendLine("    , id_fornecedor         = @id_fornecedor");
            sql.AppendLine("    , codigo_do_fabricante  = @codigo_do_fabricante");
            sql.AppendLine("    , nome                  = @nome");
            sql.AppendLine("    , nome_generico         = @nome_generico");
            sql.AppendLine("    , data_ultalt           = NOW()");
            sql.AppendLine("    , status                = @status");
            sql.AppendLine("WHERE id=@id;");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id_produto", item.IdProdutoOriginal);
            scom.AddWithValue("@id_fornecedor", item.Fabricante.Id);
            scom.AddWithValue("@codigo_do_fabricante", item.SCodigoDoFabricante);
            scom.AddWithValue("@nome", item.SNomeDoProdutoDoFabricante);
            scom.AddWithValue("@nome_generico", item.SNomeGenerico);
            scom.AddWithValue("@status", item.Status ? 1 : 0);
            scom.AddWithValue("@id", item.Id);
            try { scom.ExecuteNonQuery(); item.Alterou = false; }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }
    }
}