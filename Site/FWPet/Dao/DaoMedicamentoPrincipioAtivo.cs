using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoMedicamentoPrincipioAtivo
    {
        internal static void Salvar(MedicamentoPrincipioAtivo item)
        {
            if (item != null)
            {
                if (item.Id > 0) Alterar(item);
                else Inserir(item);
            }
            else throw new Exception("Atenção! O objeto MEDICAMENTOPRINCIPIOATIVO não foi instanciado para salvar.");
        }

        private static void Inserir(MedicamentoPrincipioAtivo item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("INSERT INTO medicamento_principioativo (descricao)");
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

        private static void Alterar(MedicamentoPrincipioAtivo item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("UPDATE medicamento_principioativo SET ");
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

        internal static void Excluir(MedicamentoPrincipioAtivo item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("UPDATE medicamento_principioativo SET ");
            sSql.AppendLine("         status = 0");
            sSql.AppendLine("       , data_ultalt= NOW()");
            sSql.AppendLine("WHERE id = @id");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item);
            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static MedicamentoPrincipioAtivo Obter(int _Principio)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT");
            sSql.AppendLine("     medicamento_principioativo.id");
            sSql.AppendLine("   , medicamento_principioativo.descricao");
            sSql.AppendLine("   , medicamento_principioativo.data_cadastro");
            sSql.AppendLine("   , medicamento_principioativo.data_ultalt");
            sSql.AppendLine("   , medicamento_principioativo.status");
            sSql.AppendLine("FROM medicamento_principioativo");
            sSql.AppendLine("WHERE medicamento_principioativo.id = @id;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Principio);

            MedicamentoPrincipioAtivo item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new MedicamentoPrincipioAtivo()
                        {
                            Id = scom.GetValue<int>("id"),
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

        internal static List<MedicamentoPrincipioAtivo> Pesquisar()
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT");
            sSql.AppendLine("     medicamento_principioativo.id");
            sSql.AppendLine("   , medicamento_principioativo.descricao");
            sSql.AppendLine("   , medicamento_principioativo.data_cadastro");
            sSql.AppendLine("   , medicamento_principioativo.data_ultalt");
            sSql.AppendLine("   , medicamento_principioativo.status");
            sSql.AppendLine("FROM medicamento_principioativo");
            sSql.AppendLine("WHERE medicamento_principioativo.status = 1");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            List<MedicamentoPrincipioAtivo> Lst = new List<MedicamentoPrincipioAtivo>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<MedicamentoPrincipioAtivo>();
                    MedicamentoPrincipioAtivo item = null;
                    while (scom.Read())
                    {
                        item = new MedicamentoPrincipioAtivo()
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
    }
}
