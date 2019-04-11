using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoMedicamentoGrupo
    {
        internal static List<MedicamentoGrupo> Pesquisar()
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT");
            sSql.AppendLine("     id");
            sSql.AppendLine("   , descricao");
            sSql.AppendLine("   , data_cadastro");
            sSql.AppendLine("   , data_ultalt");
            sSql.AppendLine("   , status");
            sSql.AppendLine("FROM medicamento_grupo");
            sSql.AppendLine("WHERE status=1;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            List<MedicamentoGrupo> Lst = new List<MedicamentoGrupo>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<MedicamentoGrupo>();
                    MedicamentoGrupo item = null;
                    while (scom.Read())
                    {
                        item = new MedicamentoGrupo()
                        {
                            Id = scom.GetValue<int>("id"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status")
                        };

                        Lst.Add(item);
                    }
                }
                else throw new Exception("Nenhum resultado encontrado.");
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }

        internal static MedicamentoGrupo Obter(int _Grupo)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT");
            sSql.AppendLine("     id");
            sSql.AppendLine("   , descricao");
            sSql.AppendLine("   , data_cadastro");
            sSql.AppendLine("   , data_ultalt");
            sSql.AppendLine("   , status");
            sSql.AppendLine("FROM medicamento_grupo");
            sSql.AppendLine("WHERE id=@id;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Grupo);
            MedicamentoGrupo item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new MedicamentoGrupo()
                        {
                            Id = scom.GetValue<int>("id"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status")
                        };
                    }
                }
                else throw new Exception("Nenhum resultado encontrado.");
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }
    }
}