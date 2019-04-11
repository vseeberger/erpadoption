using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoPessoaGrauParentesco
    {
        internal static void Salvar(PessoaGrauParentesco item)
        {
            if (item == null) throw new Exception("Atenção! O GRAUDEPARENTENSCO não foi instanciado para salvar.");
            else
            {
                if (item.Id > 0) Alterar(item);
                else Inserir(item);
            }
        }

        private static void Alterar(PessoaGrauParentesco item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE grau_parentesco SET");
            sql.AppendLine("      descricao     = @descricao");
            sql.AppendLine("    , status        = @status");
            sql.AppendLine("    , data_ultalt   = NOW()");
            sql.AppendLine("WHERE id=@id");
            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            scom.AddWithValue("@descricao", item.SDescricao);
            scom.AddWithValue("@status", item.Status);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        private static void Inserir(PessoaGrauParentesco item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO grau_parentesco(descricao)VALUES(@descricao);SELECT LAST_INSERT_ID();");
            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@descricao", item.SDescricao);
            try
            {
                scom.ExecuteReader();
                if(scom.HasRows && scom.Read())
                {
                    int i;
                    if (int.TryParse(scom.GetValue<object>(0).ToString(), out i)) item.Id = i;
                }
            }
            catch(Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static void Excluir(PessoaGrauParentesco item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE grau_parentesco SET");
            sql.AppendLine("      status        = 0");
            sql.AppendLine("    , data_ultalt   = NOW()");
            sql.AppendLine("WHERE id=@id");
            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static List<PessoaGrauParentesco> Pesquisar()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      grau_parentesco.id");
            sql.AppendLine("    , grau_parentesco.descricao");
            sql.AppendLine("    , grau_parentesco.data_cadastro");
            sql.AppendLine("    , grau_parentesco.data_ultalt");
            sql.AppendLine("    , grau_parentesco.status");
            sql.AppendLine("FROM grau_parentesco");
            sql.AppendLine("WHERE status = 1;");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            List<PessoaGrauParentesco> Lst = new List<PessoaGrauParentesco>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<PessoaGrauParentesco>();
                    PessoaGrauParentesco item = null;
                    while (scom.Read())
                    {
                        item = new PessoaGrauParentesco()
                        {
                            Id = scom.GetValue<int>("id"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status"),
                        };
                        Lst.Add(item);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }

        internal static PessoaGrauParentesco Obter(int _Codigo)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      grau_parentesco.id");
            sql.AppendLine("    , grau_parentesco.descricao");
            sql.AppendLine("    , grau_parentesco.data_cadastro");
            sql.AppendLine("    , grau_parentesco.data_ultalt");
            sql.AppendLine("    , grau_parentesco.status");
            sql.AppendLine("FROM grau_parentesco");
            sql.AppendLine("WHERE id = @id;");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Codigo);
            PessoaGrauParentesco item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new PessoaGrauParentesco()
                        {
                            Id = scom.GetValue<int>("id"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status"),
                        };
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }
    }
}