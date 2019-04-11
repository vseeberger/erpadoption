using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoAnimalFotos
    {
        internal static List<AnimalFotos> Pesquisar(long _Animal)
        {
            StringBuilder SQL = new StringBuilder();
            SQL.AppendLine("SELECT ");
            SQL.AppendLine("      id");
            SQL.AppendLine("    , id_animal");
            SQL.AppendLine("    , nome");
            SQL.AppendLine("    , nome_virtual");
            SQL.AppendLine("    , extensao");
            SQL.AppendLine("    , objeto_fileinfo");
            SQL.AppendLine("    , foto_miniatura");
            SQL.AppendLine("    , data_cadastro");
            SQL.AppendLine("    , data_ultalt");
            SQL.AppendLine("    , status");
            SQL.AppendLine("FROM animal_fotos");
            SQL.AppendLine("WHERE id_animal = @id_animal");
            SQL.AppendLine("    AND status=1;");

            cMySqlCommand scom = new cMySqlCommand(SQL.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id_animal", _Animal);

            List<AnimalFotos> Lst = new List<AnimalFotos>();
            AnimalFotos item = null;

            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<AnimalFotos>();
                    while (scom.Read())
                    {
                        item = new AnimalFotos()
                        {
                            Id = scom.GetValue<long>("id"),
                            Animal = new Animal(scom.GetValue<long>("id_animal")),
                            SNome_original_arquivo = scom.GetValue<string>("nome"),
                            SNome_novo_arquivo = scom.GetValue<string>("nome_virtual"),
                            SExtensao = scom.GetValue<string>("extensao"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            BArquivo = scom.GetValue<byte[]>("objeto_fileinfo"),
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

        internal static void Excluir(AnimalFotos item)
        {
            StringBuilder SQL = new StringBuilder();
            SQL.AppendLine("UPDATE animal_fotos SET");
            SQL.AppendLine("      status=0");
            SQL.AppendLine("    , data_ultalt = NOW()");
            SQL.AppendLine("WHERE id=@id;");
            cMySqlCommand scom = new cMySqlCommand(SQL.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static void Salvar(AnimalFotos item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO animal_fotos (id_animal, nome, nome_virtual, extensao, objeto_fileinfo, foto_miniatura)");
            sql.AppendLine("                  VALUES (@id_animal, @nome, @nome_virtual, @extensao, @objeto_fileinfo, @foto_miniatura);SELECT LAST_INSERT_ID();");

            cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id_animal", item.Animal);
            scom.AddWithValue("@nome", item.SNome_original_arquivo + "");
            scom.AddWithValue("@nome_virtual", item.SNome_novo_arquivo + "");
            scom.AddWithValue("@extensao", item.SExtensao + "");
            scom.AddWithValue("@objeto_fileinfo", item.BArquivo);
            scom.AddWithValue("@foto_miniatura", item.BFotoMiniatura);

            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    scom.Read();
                    long i;
                    if (!long.TryParse(scom.GetValue<object>(0).ToString(), out i) || i == 0) throw new Exception("Atenção! Os dados podem não ter sido gravados, verifique no sistema!");
                    item.Id = i;
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }
    }
}
