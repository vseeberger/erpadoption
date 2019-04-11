using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWPet.Dao
{
    internal class DaoColaboradorFerias
    {
        internal static void Salvar(ColaboradorFerias _Ferias)
        {
            if (_Ferias != null && _Ferias.Alterou)
            {
                if (_Ferias.Id <= 0) Inserir(_Ferias);
                else Alterar(_Ferias);
            }
        }

        private static void Alterar(ColaboradorFerias _Ferias)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE pessoa_ferias SET");
            sql.AppendLine("      idPessoa = @idPessoa");
            sql.AppendLine("    , observacoes = @observacoes");
            sql.AppendLine("    , data_ultalt = NOW()");
            sql.AppendLine("    , data_comp_de = @data_comp_de");
            sql.AppendLine("    , data_comp_ate = @data_comp_ate");
            sql.AppendLine("    , data_periodo_de = @data_periodo_de");
            sql.AppendLine("    , data_periodo_ate = @data_periodo_ate");
            sql.AppendLine("    , agendado = @agendado");
            sql.AppendLine("    , realizou = @realizou");
            sql.AppendLine("    , status = @status");
            sql.AppendLine("WHERE id = @id;");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Ferias.Id);
            scom.AddWithValue("@idPessoa", _Ferias.IdColaborador);
            scom.AddWithValue("@observacoes", _Ferias.SObservacoes);
            scom.AddWithValue("@data_comp_de", _Ferias.DtmCompetenciaDe);
            scom.AddWithValue("@data_comp_ate", _Ferias.DtmCompetenciaAte);
            scom.AddWithValue("@data_periodo_de", _Ferias.DtmPeriodoDe);
            scom.AddWithValue("@data_periodo_ate", _Ferias.DtmPeriodoAte);
            scom.AddWithValue("@agendado", _Ferias.Agendado ? 1 : 0);
            scom.AddWithValue("@realizou", _Ferias.Realizou ? 1 : 0);
            scom.AddWithValue("@status", _Ferias.Status ? 1 : 0);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        private static void Inserir(ColaboradorFerias _Ferias)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO pessoa_ferias (idPessoa, observacoes, data_comp_de, data_comp_ate, data_periodo_de, data_periodo_ate, agendado, realizou, status)");
            sql.AppendLine("VALUES(@idPessoa, @observacoes, @data_comp_de, @data_comp_ate, @data_periodo_de, @data_periodo_ate, @agendado, @realizou, @status);");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@idPessoa", _Ferias.IdColaborador);
            scom.AddWithValue("@observacoes", _Ferias.SObservacoes);
            scom.AddWithValue("@data_comp_de", _Ferias.DtmCompetenciaDe);
            scom.AddWithValue("@data_comp_ate", _Ferias.DtmCompetenciaAte);
            scom.AddWithValue("@data_periodo_de", _Ferias.DtmPeriodoDe);
            scom.AddWithValue("@data_periodo_ate", _Ferias.DtmPeriodoAte);
            scom.AddWithValue("@agendado", _Ferias.Agendado ? 1 : 0);
            scom.AddWithValue("@realizou", _Ferias.Realizou ? 1 : 0);
            scom.AddWithValue("@status", _Ferias.Status ? 1 : 0);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }
    }
}