using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoConfiguracoes
    {
        internal static void Salvar(Configuracoes item)
        {
            if (item.Id > 0)
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE configuracoes SET");
                sql.AppendLine("      dia_pagamento_default = @dia_pagamento_default");
                sql.AppendLine("    , valor_diaria          = @valor_diaria");
                sql.AppendLine("    , alerta_dias_contato   = @alerta_dias_contato");
                sql.AppendLine("    , data_ultalt           = NOW()");
                sql.AppendLine("WHERE id = @id");

                cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);
                scom.AddWithValue("@id", item.Id);
                scom.AddWithValue("@dia_pagamento_default", item.DiaPagamento);
                scom.AddWithValue("@valor_diaria", item.DValorDiaria);
                scom.AddWithValue("@alerta_dias_contato", item.IQtdDiasAlertaContatoDeAdocao);

                try { scom.ExecuteNonQuery(); }
                catch (Exception ex) { throw ex; }
                finally { scom.Close(); }
            }
        }

        internal static Configuracoes Obter()
        {
            cMySqlCommand scom = new cMySqlCommand("SELECT id, dia_pagamento_default, valor_diaria, alerta_dias_contato, data_cadastro, data_ultalt, status FROM configuracoes WHERE status = 1", System.Data.CommandType.Text);
            Configuracoes item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows && scom.Read())
                {
                    item = new Configuracoes()
                    {
                        Id = scom.GetValue<int>("id"),
                        DiaPagamento = scom.GetValue<int>("dia_pagamento_default"),
                        DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                        DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                        DValorDiaria = scom.GetValue<decimal>("valor_diaria"),
                        Status = scom.GetValue<bool>("status"),
                        IQtdDiasAlertaContatoDeAdocao = scom.GetValue<int>("alerta_dias_contato")
                    };
                }
            }
            catch (Exception ex) { return item; }
            finally { scom.Close(); }
            return item;
        }
    }
}
