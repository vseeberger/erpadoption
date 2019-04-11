using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoProdutoMarca
    {
        internal static List<ProdutoMarca> Pesquisar()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      id");
            sql.AppendLine("    , descricao");
            sql.AppendLine("    , tipo");
            sql.AppendLine("    , data_cadastro");
            sql.AppendLine("    , data_ultalt");
            sql.AppendLine("    , status");
            sql.AppendLine("FROM marca");
            sql.AppendLine("WHERE status = 1");
            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);

            List<ProdutoMarca> Lst = new List<ProdutoMarca>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<ProdutoMarca>();
                    ProdutoMarca item = null;
                    while (scom.Read())
                    {
                        item = new ProdutoMarca()
                        {
                            Id = scom.GetValue<int>("id"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            STipo = scom.GetValue<string>("tipo"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status")
                        };
                        
                        Lst.Add(item);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }

        internal static ProdutoMarca Obter(int _Codigo)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      id");
            sql.AppendLine("    , descricao");
            sql.AppendLine("    , tipo");
            sql.AppendLine("    , data_cadastro");
            sql.AppendLine("    , data_ultalt");
            sql.AppendLine("    , status");
            sql.AppendLine("FROM marca");
            sql.AppendLine("WHERE id = @id;");
            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Codigo);

            ProdutoMarca item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new ProdutoMarca()
                        {
                            Id = scom.GetValue<int>("id"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            STipo = scom.GetValue<string>("tipo"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status")
                        };
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }

        internal static void Excluir(ProdutoMarca produtoMarca)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE marca SET");
            sql.AppendLine("      status        = 0");
            sql.AppendLine("    , data_ultalt   = NOW()");
            sql.AppendLine("WHERE");
            sql.AppendLine("id = @id;");
            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", produtoMarca);
            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static void Salvar(ProdutoMarca item)
        {
            if (item == null) throw new Exception("Atenção! O objeto MARCA não foi instanciado para salvar.");
            else
            {
                if (item.Id > 0) Alterar(item);
                else Inserir(item);
            }
        }

        private static void Inserir(ProdutoMarca item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO  marca (descricao, tipo)");
            sql.AppendLine("            VALUES (@descricao, @tipo);SELECT LAST_INSERT_ID();");
            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@descricao", item.SDescricao);
            scom.AddWithValue("@tipo", "M");

            try
            {
                scom.ExecuteReader();
                if (scom.HasRows && scom.Read()) {
                    int i;
                    if (int.TryParse(scom.GetValue<object>(0).ToString(), out i)) item.Id = i;
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        private static void Alterar(ProdutoMarca item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE marca SET");
            sql.AppendLine("      descricao = @descricao");
            sql.AppendLine("    , tipo = @tipo");
            sql.AppendLine("    , status = @status");
            sql.AppendLine("    , data_ultalt = now()");
            sql.AppendLine("WHERE id=@id;");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            scom.AddWithValue("@descricao", item.SDescricao);
            scom.AddWithValue("@tipo", "M");
            scom.AddWithValue("@status", item.Status ? 1 : 0);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }
    }
}
