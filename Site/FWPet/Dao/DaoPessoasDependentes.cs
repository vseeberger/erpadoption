using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    class DaoPessoasDependentes
    {
        internal static void Salvar(PessoasDependentes item)
        {
            if (item == null) throw new Exception("Atenção! O objeto AGENDA não foi instanciado para salvar.");
            else
            {
                if (item.Alterou)
                {
                    if (item.Id > 0) Alterar(item);
                    else Inserir(item);
                }
            }
        }

        private static void Inserir(PessoasDependentes item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO dependentes (id_grau_parentesco, id_pessoa, nome, data_nascimento)");
            sql.AppendLine("VALUES (@id_grau_parentesco, @id_pessoa, @nome, @data_nascimento);SELECT LAST_INSERT_ID();");
            
            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id_grau_parentesco", item.GrauParentesco.Id);
            scom.AddWithValue("@id_pessoa", item.IdPessoa);
            scom.AddWithValue("@nome", item.SNome);
            scom.AddWithValue("@data_nascimento", item.DtmNascimento);

            try
            {
                scom.ExecuteReader();
                if(scom.HasRows && scom.Read())
                {
                    long i;
                    long.TryParse(scom.GetValue<object>(0).ToString(), out i);
                    item.Id = i;
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        private static void Alterar(PessoasDependentes item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE dependentes SET");
            sql.AppendLine("      id_grau_parentesco= @id_grau_parentesco");
            sql.AppendLine("    , id_pessoa         = @id_pessoa");
            sql.AppendLine("    , nome              = @nome");
            sql.AppendLine("    , data_nascimento   = @data_nascimento");
            sql.AppendLine("    , data_ultalt       = NOW()");
            sql.AppendLine("    , status            = @status");
            sql.AppendLine("WHERE id = @id;");
            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id_grau_parentesco", item.GrauParentesco.Id);
            scom.AddWithValue("@id_pessoa", item.IdPessoa);
            scom.AddWithValue("@nome", item.SNome);
            scom.AddWithValue("@data_nascimento", item.DtmNascimento);
            scom.AddWithValue("@status", item.Status ? 1 : 0);
            scom.AddWithValue("@id", item.Id);

            try { scom.ExecuteNonQuery(); }
            catch(Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static void Excluir(PessoasDependentes item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE dependentes SET");
            sql.AppendLine("      data_ultalt = NOW()");
            sql.AppendLine("    , status = 0");
            sql.AppendLine("WHERE id = @id;");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static List<PessoasDependentes> Pesquisar(long _Pessoa)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      dependentes.id");
            sql.AppendLine("    , dependentes.id_grau_parentesco");
            sql.AppendLine("    , dependentes.id_pessoa");
            sql.AppendLine("    , dependentes.nome");
            sql.AppendLine("    , dependentes.data_nascimento");
            sql.AppendLine("    , dependentes.data_cadastro");
            sql.AppendLine("    , dependentes.data_ultalt");
            sql.AppendLine("    , dependentes.status");

            sql.AppendLine("    , grau_parentesco.descricao AS GrauDescricao");

            sql.AppendLine("FROM dependentes");
            sql.AppendLine("    LEFT JOIN grau_parentesco ON grau_parentesco.id = dependentes.id_grau_parentesco");
            sql.AppendLine("WHERE dependentes.id_pessoa = @id;");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Pessoa);

            List<PessoasDependentes> Lst = new List<PessoasDependentes>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<PessoasDependentes>();
                    PessoasDependentes item = null;
                    while (scom.Read())
                    {
                        item = new PessoasDependentes()
                        {
                            Id = scom.GetValue<long>("id"),
                            SNome = scom.GetValue<string>("nome"),
                            DtmNascimento = scom.GetValue<DateTime?>("data_nascimento"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status"),
                            IdPessoa = scom.GetValue<long>("id_pessoa"),
                            Sequencia = scom.GetValue<long>("id"),
                        };

                        if (scom.GetValue<int?>("id_grau_parentesco") != null)
                        {
                            item.GrauParentesco = new PessoaGrauParentesco(scom.GetValue<int>("id_grau_parentesco"), scom.GetValue<string>("GrauDescricao"));
                        }
                        Lst.Add(item);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }
    }
}
