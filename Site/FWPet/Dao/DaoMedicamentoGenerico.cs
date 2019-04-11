using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWPet.Dao
{
    internal class DaoMedicamentoGenerico
    {
        internal static void Salvar(MedicamentoGenerico item)
        {
            if (item != null)
            {
                if (item.Id > 0) Alterar(item);
                else Inserir(item);
            }
            else throw new Exception("Atenção! O objeto MEDICAMENTOGENERICO não foi instanciado para salvar.");
        }

        private static void Inserir(MedicamentoGenerico item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("INSERT INTO medicamento_generico (descricao)");
            sSql.AppendLine("VALUES (@descricao);SELECT LAST_INSERT_ID();");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@descricao", item.SDescricao);
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    scom.Read();
                    int i;
                    int.TryParse(scom.GetValue<object>(0).ToString(), out i);
                    if (i == 0) throw new Exception("Atenção! Os dados podem não ter sido gravados, verifique no sistema!");
                    else item.Id = i;
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        private static void Alterar(MedicamentoGenerico item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("UPDATE medicamento_generico SET ");
            sSql.AppendLine("         descricao  = @descricao ");
            sSql.AppendLine("       , data_ultalt= NOW()");
            sSql.AppendLine("WHERE id = @id");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            scom.AddWithValue("@descricao", item.SDescricao);
            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static MedicamentoGenerico Obter(long _Generico)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT");
            sSql.AppendLine("     id");
            sSql.AppendLine("   , descricao");
            sSql.AppendLine("   , data_cadastro");
            sSql.AppendLine("   , data_ultalt");
            sSql.AppendLine("   , status");
            sSql.AppendLine("FROM medicamento_generico");
            sSql.AppendLine("WHERE id = @id;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Generico);

            MedicamentoGenerico item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new MedicamentoGenerico()
                        {
                            Id = scom.GetValue<long>("id"),
                            SDescricao = scom.GetValue<string>("descricao"),
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

        internal static List<MedicamentoGenerico> Pesquisar()
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT");
            sSql.AppendLine("     id");
            sSql.AppendLine("   , descricao");
            sSql.AppendLine("   , data_cadastro");
            sSql.AppendLine("   , data_ultalt");
            sSql.AppendLine("   , status");
            sSql.AppendLine("FROM medicamento_generico");
            sSql.AppendLine("WHERE status = 1");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            List<MedicamentoGenerico> Lst = new List<MedicamentoGenerico>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<MedicamentoGenerico>();
                    MedicamentoGenerico item = null;
                    while (scom.Read())
                    {
                        item = new MedicamentoGenerico()
                        {
                            Id = scom.GetValue<long>("id"),
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

    }
}
