using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    class DaoAgendaContato
    {
        internal static void Salvar(List<AgendaContato> Lst, long _Contato)
        {
            if (Lst != null && Lst.Count > 0)
            {
                for (int i = 0; i < Lst.Count; i++)
                {
                    Lst[i].Id_contato = _Contato;
                    if (Lst[i].Id > 0) Alterar(Lst[i]);
                    else Inserir(Lst[i]);
                }
            }
        }

        private static void Inserir(AgendaContato item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO agenda_contatos (id_contato, tipo_contato, contato)");
            sql.AppendLine("VALUES (@id_contato, @tipo_contato, @contato);");

            cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id_contato", item.Id_contato);
            scom.AddWithValue("@tipo_contato", item.STipoContato);
            scom.AddWithValue("@contato", item.SNome);

            try { scom.ExecuteNonQuery(); }
            catch(Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        private static void Alterar(AgendaContato item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE agenda_contatos SET");
            sql.AppendLine("      tipo_contato = @tipo_contato");
            sql.AppendLine("    , contato = @contato");
            sql.AppendLine("    , data_ultalt=NOW()");
            sql.AppendLine("    , status = @status");
            sql.AppendLine("WHERE id=@id");
            sql.AppendLine("    AND id_contato=@id_contato;");

            cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            scom.AddWithValue("@id_contato", item.Id_contato);
            scom.AddWithValue("@tipo_contato", item.STipoContato);
            scom.AddWithValue("@contato", item.SNome);
            scom.AddWithValue("@status", item.Status ? 1 : 0);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static List<AgendaContato> Pesquisar(long? _Contato)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT ");
            sql.AppendLine("      id");
            sql.AppendLine("    , id_contato");
            sql.AppendLine("    , tipo_contato");
            sql.AppendLine("    , contato");
            sql.AppendLine("    , data_cadastro");
            sql.AppendLine("    , data_ultalt");
            sql.AppendLine("    , status");
            sql.AppendLine("FROM agenda_contatos");
            sql.AppendLine("WHERE status=1");
            if (_Contato != null && _Contato > 0) sql.AppendLine("AND id_contato=@contato");
            cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@contato", _Contato);

            List<AgendaContato> Lst = new List<AgendaContato>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<AgendaContato>();
                    AgendaContato item = null;
                    while (scom.Read())
                    {
                        item = new AgendaContato()
                        {
                            Id = scom.GetValue<long>("id"),
                            Id_contato = scom.GetValue<long>("id_contato"),
                            Contato = new Agenda(scom.GetValue<long>("id_contato")),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            SNome = scom.GetValue<string>("contato"),
                            Status = scom.GetValue<bool>("status"),
                            STipoContato = scom.GetValue<string>("tipo_contato"),
                        };
                        
                        Lst.Add(item);
                    }
                }
            }catch(Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }

        internal static void Excluir(AgendaContato _AgendaContato)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE agenda_contatos SET");
            sql.AppendLine("      status = 0");
            sql.AppendLine("    , data_ultalt=NOW()");
            sql.AppendLine("WHERE id=@id;");

            cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", _AgendaContato);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }
    }
}
