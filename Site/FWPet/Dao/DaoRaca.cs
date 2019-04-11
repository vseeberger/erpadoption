using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoRaca
    {
        internal static List<Raca> Pesquisar()
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT");
            sSql.AppendLine("     raca.id");
            sSql.AppendLine("   , raca.descricao");
            sSql.AppendLine("   , raca.data_cadastro");
            sSql.AppendLine("   , raca.data_ultalt");
            sSql.AppendLine("   , raca.status");
            sSql.AppendLine("   , raca.id_especie");
            sSql.AppendLine("   , especie.descricao as dscEspecie");
            sSql.AppendLine("FROM raca");
            sSql.AppendLine("INNER JOIN especie ON especie.id = raca.id_especie");
            sSql.AppendLine("WHERE raca.status = 1");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            List<Raca> Lst = new List<Raca>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<Raca>();
                    Raca item = null;
                    while (scom.Read())
                    {
                        item = new Raca()
                        {
                            Id = scom.GetValue<int>("id"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status"),
                            Especie = new Especie(scom.GetValue<int>("id_especie"), scom.GetValue<string>("dscEspecie"))
                        };

                        Lst.Add(item);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }

        internal static void Excluir(Raca item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("UPDATE raca SET ");
            sSql.AppendLine("         status = 0");
            sSql.AppendLine("       , data_ultalt= NOW()");
            sSql.AppendLine("WHERE id = @id");
            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item);
            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static Raca Obter(int _Raca)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT");
            sSql.AppendLine("     raca.id");
            sSql.AppendLine("   , raca.descricao");
            sSql.AppendLine("   , raca.data_cadastro");
            sSql.AppendLine("   , raca.data_ultalt");
            sSql.AppendLine("   , raca.status");
            sSql.AppendLine("   , raca.id_especie");
            sSql.AppendLine("   , especie.descricao as dscEspecie");
            sSql.AppendLine("FROM raca");
            sSql.AppendLine("INNER JOIN especie ON especie.id = raca.id_especie");
            sSql.AppendLine("WHERE raca.id = @id;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Raca);

            Raca item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new Raca()
                        {
                            Id = scom.GetValue<int>("id"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status"),
                            Especie = new Especie(scom.GetValue<int>("id_especie"), scom.GetValue<string>("dscEspecie"))
                        };
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }

        internal static void Salvar(Raca raca)
        {
            if (raca != null)
            {
                if (raca.Id == 0) Inserir(raca);
                else Alterar(raca);
            }
            else throw new Exception("Atenção! O objeto RAÇA não foi instanciado para salvar.");
        }

        private static void Alterar(Raca item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("UPDATE raca SET ");
            sSql.AppendLine("         id_especie = @id_especie");
            sSql.AppendLine("       , descricao  = @descricao ");
            sSql.AppendLine("       , data_ultalt= NOW()");
            sSql.AppendLine("WHERE id = @id");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            scom.AddWithValue("@id_especie", item.Especie.Id);
            scom.AddWithValue("@descricao", item.SDescricao);
            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        private static void Inserir(Raca item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("INSERT INTO raca (id_especie, descricao)");
            sSql.AppendLine("VALUES (@id_especie, @descricao);SELECT LAST_INSERT_ID();");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id_especie", item.Especie.Id);
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
    }
}
