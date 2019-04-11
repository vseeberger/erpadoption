using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoAnimalMedicamentoTratamento
    {
        internal static void Salvar(AnimalMedicamentoTratamento item)
        {
            if (item != null)
            {
                if (item.Id > 0) Alterar(item);
                else Inserir(item);
            }
            else throw new Exception("Atenção! O objeto ANIMALMEDICAMENTOTRATAMENTO não foi instanciado para salvar.");
        }

        private static void Inserir(AnimalMedicamentoTratamento item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO animal_medicamento_tratamento (nome, descricao)");
            sql.AppendLine("                                   VALUES (@nome,@descricao);SELECT LAST_INSERT_ID();");

            cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@nome", item.SNome);
            scom.AddWithValue("@descricao", item.SDescricao);

            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    scom.Read();
                    int i;
                    int.TryParse(scom.GetValue<object>(0).ToString(), out i);
                    if (i > 0) item.Id = i;
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }



        private static void Alterar(AnimalMedicamentoTratamento item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE animal_medicamento_tratamento SET");
            sql.AppendLine("      nome = @nome");
            sql.AppendLine("    , descricao = @descricao");
            sql.AppendLine("    , data_ultalt = NOW()");
            sql.AppendLine("    , status = @status");
            sql.AppendLine("WHERE id = @id;");

            cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@nome", item.SNome);
            scom.AddWithValue("@descricao", item.SDescricao);
            scom.AddWithValue("@status", item.Status ? 1 : 0);
            scom.AddWithValue("@id", item.Id);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static void Excluir(AnimalMedicamentoTratamento item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE animal_medicamento_tratamento SET");
            sql.AppendLine("      data_ultalt = NOW()");
            sql.AppendLine("    , status = 0");
            sql.AppendLine("WHERE id = @id;");

            cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static List<AnimalMedicamentoTratamento> Pesquisar()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      id");
            sql.AppendLine("    , nome");
            sql.AppendLine("    , descricao");
            sql.AppendLine("    , data_ultalt");
            sql.AppendLine("    , data_cadastro");
            sql.AppendLine("    , status");
            sql.AppendLine("FROM animal_medicamento_tratamento");
            sql.AppendLine("WHERE status=1");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);

            List<AnimalMedicamentoTratamento> Lst = new List<AnimalMedicamentoTratamento>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<AnimalMedicamentoTratamento>();
                    AnimalMedicamentoTratamento item = null;
                    while (scom.Read())
                    {
                        item = new AnimalMedicamentoTratamento()
                        {
                            Id = scom.GetValue<int>("id"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            SNome = scom.GetValue<string>("nome"),
                            Status = scom.GetValue<bool>("status")
                        };
                        
                        Lst.Add(item);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }
        
        internal static AnimalMedicamentoTratamento Obter(int _Codigo)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      id");
            sql.AppendLine("    , nome");
            sql.AppendLine("    , descricao");
            sql.AppendLine("    , data_ultalt");
            sql.AppendLine("    , data_cadastro");
            sql.AppendLine("    , status");
            sql.AppendLine("FROM animal_medicamento_tratamento");
            sql.AppendLine("WHERE id=@id");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Codigo);

            AnimalMedicamentoTratamento item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if(scom.Read())
                    {
                        item = new AnimalMedicamentoTratamento()
                        {
                            Id = scom.GetValue<int>("id"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            SNome = scom.GetValue<string>("nome"),
                            Status = scom.GetValue<bool>("status")
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
