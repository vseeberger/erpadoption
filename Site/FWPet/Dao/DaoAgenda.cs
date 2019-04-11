using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoAgenda
    {
        internal static void Salvar(Agenda item)
        {
            if (item == null) throw new Exception("Atenção! O objeto AGENDA não foi instanciado para salvar.");
            else
            {
                if (item.Id > 0) Alterar(item);
                else Inserir(item);
            }
        }

        private static void Inserir(Agenda item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO  agenda (nome, privado, id_usuario) VALUES (@nome, @privado, @id_usuario);SELECT LAST_INSERT_ID();");
            cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@nome", item.SNome);
            scom.AddWithValue("@privado", item.Privado ? 1 : 0);
            scom.AddWithValue("@id_usuario", item.Id_usuario);

            try
            {
                scom.ExecuteReader();
                if (scom.HasRows && scom.Read())
                {
                    long l;
                    if (long.TryParse(scom.GetValue<object>(0).ToString(), out l) && l > 0) AgendaContato.Salvar(item.Contatos, l);
                    else throw new Exception("Ocorreu uma falha ao salvar e algum dos dados pode NÃO ter sido gravado.");
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        private static void Alterar(Agenda item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE agenda SET ");
            sql.AppendLine("      nome = @nome");
            sql.AppendLine("    , data_ultalt = NOW()");
            sql.AppendLine("    , privado = @privado");
            sql.AppendLine("WHERE id=@id;");

            cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            scom.AddWithValue("@nome", item.SNome);
            scom.AddWithValue("@privado", item.Privado);
            try
            {
                scom.ExecuteNonQuery();
                AgendaContato.Salvar(item.Contatos, item.Id);
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static void Excluir(Agenda item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE agenda SET ");
            sql.AppendLine("      status = 0");
            sql.AppendLine("    , data_ultalt = NOW()");
            sql.AppendLine("WHERE id=@id;");

            cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static List<Agenda> Pesquisar(long _Usuario)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT ");
            sql.AppendLine("    id");
            sql.AppendLine("    , nome");
            sql.AppendLine("    , data_cadastro");
            sql.AppendLine("    , data_ultalt");
            sql.AppendLine("    , status ");
            sql.AppendLine("    , privado");
            sql.AppendLine("FROM agenda");
            sql.AppendLine("WHERE status=1");
            sql.AppendLine("    AND (privado=0 OR (privado=1 AND id_usuario = @id_usuario));");

            cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id_usuario", _Usuario);

            List<Agenda> Lst = new List<Agenda>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<Agenda>();
                    Agenda item = null;
                    while (scom.Read())
                    {
                        item = new Agenda()
                        {
                            Id = scom.GetValue<long>("id"),
                            SNome = scom.GetValue<string>("nome"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status"),
                            Privado = scom.GetValue<bool>("privado")
                        };
                        item.Contatos = AgendaContato.Pesquisar(item.Id);
                        Lst.Add(item);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }

        internal static Agenda Obter(long id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT ");
            sql.AppendLine("    id");
            sql.AppendLine("    , nome");
            sql.AppendLine("    , data_cadastro");
            sql.AppendLine("    , data_ultalt");
            sql.AppendLine("    , status ");
            sql.AppendLine("FROM agenda");
            sql.AppendLine("WHERE id=@id;");
            sql.AppendLine("");
            sql.AppendLine("SELECT ");
            sql.AppendLine("   id");
            sql.AppendLine("   , id_contato");
            sql.AppendLine("   , tipo_contato");
            sql.AppendLine("   , contato");
            sql.AppendLine("   , data_cadastro");
            sql.AppendLine("   , data_ultalt");
            sql.AppendLine("   , status");
            sql.AppendLine("FROM agenda_contatos");
            sql.AppendLine("WHERE id_contato=@id;");

            cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", id);
            Agenda item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new Agenda()
                        {
                            Id = scom.GetValue<long>("id"),
                            SNome = scom.GetValue<string>("nome"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status")
                        };

                        scom.NextResult();
                        
                        if (scom.HasRows)
                        {
                            item.Contatos = new List<AgendaContato>();
                            AgendaContato _cont = null;
                            while (scom.Read())
                            {
                                _cont = new AgendaContato()
                                {
                                    Id = scom.GetValue<long>("id"),
                                    DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                                    DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                                    SNome = scom.GetValue<string>("contato"),
                                    STipoContato = scom.GetValue<string>("tipo_contato"),
                                    Id_contato = scom.GetValue<long>("id_contato"),
                                    Status = scom.GetValue<bool>("status"),
                                    Contato = new Agenda(item.Id, item.SNome)
                                };

                                item.Contatos.Add(_cont);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }
    }
}
