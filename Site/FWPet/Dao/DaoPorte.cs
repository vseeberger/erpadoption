using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoPorte
    {
        internal static List<Porte> Pesquisar()
        {
            StringBuilder sSQl = new StringBuilder();
            sSQl.AppendLine("SELECT");
            sSQl.AppendLine("     id");
            sSQl.AppendLine("   , descricao");
            sSQl.AppendLine("   , sigla");
            sSQl.AppendLine("   , data_cadastro");
            sSQl.AppendLine("   , data_ultalt");
            sSQl.AppendLine("   , status");
            sSQl.AppendLine("FROM porte");
            sSQl.AppendLine("WHERE status = 1;");
            cMySqlCommand scom = new cMySqlCommand(sSQl.ToString(), System.Data.CommandType.Text);
            List<Porte> Lst = new List<Porte>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<Porte>();
                    Porte item = null;
                    while (scom.Read())
                    {
                        item = new Porte()
                        {
                            Id = scom.GetValue<int>("id"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            SSigla = scom.GetValue<string>("sigla"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status")
                        };

                        Lst.Add(item);
                    }
                }
                else throw new Exception("Nenhum registro encontrado.");
            }
            catch(Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }

        internal static Porte Obter(int _Porte)
        {
            StringBuilder sSQl = new StringBuilder();
            sSQl.AppendLine("SELECT");
            sSQl.AppendLine("     id");
            sSQl.AppendLine("   , descricao");
            sSQl.AppendLine("   , sigla");
            sSQl.AppendLine("   , data_cadastro");
            sSQl.AppendLine("   , data_ultalt");
            sSQl.AppendLine("   , status");
            sSQl.AppendLine("FROM porte");
            sSQl.AppendLine("WHERE id = @id;");
            cMySqlCommand scom = new cMySqlCommand(sSQl.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Porte);

            Porte item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new Porte()
                        {
                            Id = scom.GetValue<int>("id"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            SSigla = scom.GetValue<string>("sigla"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status")
                        };
                    }
                }
                else item = new Porte(0, "selecione"); //throw new Exception("Nenhum registro encontrado.");
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }
    }
}
