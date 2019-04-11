using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoVacina
    {
        internal static void Salvar(Vacina item)
        {
            if (item != null)
            {
                if (item.Id > 0) Alterar(item);
                else Inserir(item);
            }
            else throw new Exception("Atenção! O objeto VACINA não foi instanciado, verifique os dados!");
        }

        internal static void Inserir(Vacina item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("INSERT INTO vacina (id_fabricante, id_especie, nome, descricao, atencao, quantidade_dias_validade, quantidade_doses, quantidade_dias_entre_doses)");
            sSql.AppendLine("VALUES (@id_fabricante, @id_especie, @nome, @descricao, @atencao, @quantidade_dias_validade, @quantidade_doses, @quantidade_dias_entre_doses);SELECT LAST_INSERT_ID();");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id_fabricante", item.Empresa == null ? 0 : item.Empresa.Id);
            scom.AddWithValue("@id_especie", item.Especie);
            scom.AddWithValue("@nome", item.SNome);
            scom.AddWithValue("@descricao", item.SDescricao);
            scom.AddWithValue("@atencao", item.SAtencao);
            scom.AddWithValue("@quantidade_dias_validade", item.IQuantidadeDiasValidade);
            scom.AddWithValue("@quantidade_doses", item.IQuantidadeDoses);
            scom.AddWithValue("@quantidade_dias_entre_doses", item.IQuantidadeDiasEntreDoses);

            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    scom.Read();
                    int i;
                    int.TryParse(scom.GetValue<object>(0).ToString(), out i);
                    if (i == 0) throw new Exception("Atenção! Os dados podem não ter sido gravados, verifique no sistema!");
                    item.Id = i;
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static void Alterar(Vacina item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("UPDATE vacina SET ");
            sSql.AppendLine("         id_fabricante = @id_fabricante");
            sSql.AppendLine("       , nome  = @nome ");
            sSql.AppendLine("       , descricao  = @descricao ");
            sSql.AppendLine("       , atencao  = @atencao ");
            sSql.AppendLine("       , quantidade_dias_validade  = @quantidade_dias_validade ");
            sSql.AppendLine("       , quantidade_doses  = @quantidade_doses ");
            sSql.AppendLine("       , quantidade_dias_entre_doses = @quantidade_dias_entre_doses");
            sSql.AppendLine("       , id_especie = @id_especie");
            sSql.AppendLine("       , data_ultalt= NOW()");
            sSql.AppendLine("WHERE id = @id;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            scom.AddWithValue("@id_fabricante", item.Empresa == null ? 0 : item.Empresa.Id);
            scom.AddWithValue("@id_especie", item.Especie);
            scom.AddWithValue("@nome", item.SNome);
            scom.AddWithValue("@descricao", item.SDescricao);
            scom.AddWithValue("@atencao", item.SAtencao);
            scom.AddWithValue("@quantidade_dias_validade", item.IQuantidadeDiasValidade);
            scom.AddWithValue("@quantidade_doses", item.IQuantidadeDoses);
            scom.AddWithValue("@quantidade_dias_entre_doses", item.IQuantidadeDiasEntreDoses);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static void Excluir(Vacina item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("UPDATE vacina SET ");
            sSql.AppendLine("         status = 0");
            sSql.AppendLine("       , data_ultalt= NOW()");
            sSql.AppendLine("WHERE id = @id;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static List<Vacina> Pesquisar()
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT");
            sSql.AppendLine("      vacina.id");
            sSql.AppendLine("    , vacina.id_fabricante");
            sSql.AppendLine("    , vacina.nome");
            sSql.AppendLine("    , vacina.descricao");
            sSql.AppendLine("    , vacina.atencao");
            sSql.AppendLine("    , vacina.quantidade_dias_validade");
            sSql.AppendLine("    , vacina.quantidade_doses");
            sSql.AppendLine("    , vacina.data_cadastro");
            sSql.AppendLine("    , vacina.data_ultalt");
            sSql.AppendLine("    , vacina.status");
            sSql.AppendLine("    , vacina.id_especie");
            sSql.AppendLine("    , especie.descricao as dscEspecie");
            sSql.AppendLine("    , vacina.quantidade_dias_entre_doses");
            sSql.AppendLine("FROM vacina");
            sSql.AppendLine("LEFT JOIN especie ON especie.id = vacina.id_especie");
            sSql.AppendLine("WHERE vacina.status = 1;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);

            List<Vacina> Lst = new List<Vacina>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<Vacina>();
                    Vacina item = null;
                    while (scom.Read())
                    {
                        item = new Vacina()
                        {
                            Id = scom.GetValue<int>("id"),
                            SNome = scom.GetValue<string>("nome"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            SAtencao = scom.GetValue<string>("atencao"),
                            IQuantidadeDiasValidade = scom.GetValue<int>("quantidade_dias_validade"),
                            IQuantidadeDoses = scom.GetValue<int>("quantidade_doses"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            IQuantidadeDiasEntreDoses = scom.GetValue<int>("quantidade_dias_entre_doses"),
                            Status = scom.GetValue<bool>("status")
                        };

                        if (scom.GetValue<int?>("id_especie") != null)
                        {
                            item.Especie = new Especie(scom.GetValue<int>("id_especie"), scom.GetValue<string>("dscEspecie"));
                        }

                        Lst.Add(item);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }

            return Lst;
        }

        internal static Vacina Obter(int _Vacina)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT");
            sSql.AppendLine("      vacina.id");
            sSql.AppendLine("    , vacina.id_fabricante");
            sSql.AppendLine("    , vacina.nome");
            sSql.AppendLine("    , vacina.descricao");
            sSql.AppendLine("    , vacina.atencao");
            sSql.AppendLine("    , vacina.quantidade_dias_validade");
            sSql.AppendLine("    , vacina.quantidade_doses");
            sSql.AppendLine("    , vacina.data_cadastro");
            sSql.AppendLine("    , vacina.data_ultalt");
            sSql.AppendLine("    , vacina.status");
            sSql.AppendLine("    , vacina.id_especie");
            sSql.AppendLine("    , vacina.quantidade_dias_entre_doses");
            sSql.AppendLine("FROM vacina");
            sSql.AppendLine("WHERE id = @id;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Vacina);

            Vacina item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new Vacina()
                        {
                            Id = scom.GetValue<int>("id"),
                            SNome = scom.GetValue<string>("nome"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            SAtencao = scom.GetValue<string>("atencao"),
                            IQuantidadeDiasValidade = scom.GetValue<int>("quantidade_dias_validade"),
                            IQuantidadeDoses = scom.GetValue<int>("quantidade_doses"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                             IQuantidadeDiasEntreDoses = scom.GetValue<int>("quantidade_dias_entre_doses"),
                            Status = scom.GetValue<bool>("status")
                        };

                        if(scom.GetValue<int?>("id_especie") != null)
                        {
                            item.Especie = new Especie(scom.GetValue<int>("id_especie"));
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
