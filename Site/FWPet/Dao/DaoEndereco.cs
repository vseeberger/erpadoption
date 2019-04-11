using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoEndereco
    {
        internal static void Salvar(Endereco item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("INSERT INTO endereco (endereco, bairro, cidade, uf, cep, complemento, numero)");
            sSql.AppendLine("VALUES (@endereco, @bairro, @cidade, @uf, @cep, @complemento, @numero);SELECT LAST_INSERT_ID();");
            
            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@endereco", item.SEndereco);
            scom.AddWithValue("@bairro", item.SBairro);
            scom.AddWithValue("@cidade", item.SCidade);
            scom.AddWithValue("@uf", item.SUF);
            scom.AddWithValue("@cep", item.SCEP);
            scom.AddWithValue("@complemento", item.SComplemento);
            scom.AddWithValue("@numero", item.SNumero);

            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    scom.Read();
                    long i;
                    long.TryParse(scom.GetValue<object>(0).ToString(), out i);
                    if (i > 0) item.Id = i;
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }
    }
}
