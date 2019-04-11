using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoPessoas
    {
        internal static List<Pessoas> Pesquisar()
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT");
            sSql.AppendLine("     pessoa.id");
            sSql.AppendLine("   , pessoa.nome");
            sSql.AppendLine("   , pessoa.rg");
            sSql.AppendLine("   , pessoa.cpf");
            sSql.AppendLine("   , pessoa.data_cadastro");
            sSql.AppendLine("   , pessoa.data_ultalt");
            sSql.AppendLine("   , pessoa.data_nascimento");
            sSql.AppendLine("   , pessoa.tipo");
            sSql.AppendLine("   , pessoa.sexo");
            sSql.AppendLine("   , pessoa.status");
            sSql.AppendLine("   , pessoa.email");
            sSql.AppendLine("   , pessoa.telefone");
            sSql.AppendLine("   , pessoa.celular");
            sSql.AppendLine("   , pessoa.outro_contato");
            sSql.AppendLine("FROM pessoa");
            sSql.AppendLine("WHERE pessoa.status=1");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            List<Pessoas> Lst = new List<Pessoas>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<Pessoas>();
                    Pessoas item = null;
                    while (scom.Read())
                    {
                        item = new Pessoas()
                        {
                            Id = scom.GetValue<long>("id"),
                            SNome = scom.GetValue<string>("nome"),
                            SRG = scom.GetValue<string>("rg"),
                            SCPF = scom.GetValue<string>("cpf"),
                            CTipo = scom.GetValue<char>("tipo"),
                            SSexo = scom.GetValue<string>("sexo"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            DtmNascimento = scom.GetValue<DateTime?>("data_nascimento"),
                            Status = scom.GetValue<bool>("status"),
                            SCelular = scom.GetValue<string>("celular"),
                            SEmail = scom.GetValue<string>("email"),
                            SOutroContato = scom.GetValue<string>("outro_contato"),
                            STelefone = scom.GetValue<string>("telefone")
                        };

                        Lst.Add(item);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }

        internal static Pessoas Obter(long idPessoa)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT");
            sSql.AppendLine("     pessoa.id");
            sSql.AppendLine("   , pessoa.nome");
            sSql.AppendLine("   , pessoa.rg");
            sSql.AppendLine("   , pessoa.cpf");
            sSql.AppendLine("   , pessoa.data_cadastro");
            sSql.AppendLine("   , pessoa.data_ultalt");
            sSql.AppendLine("   , pessoa.data_nascimento");
            sSql.AppendLine("   , pessoa.tipo");
            sSql.AppendLine("   , pessoa.sexo");
            sSql.AppendLine("   , pessoa.status");
            sSql.AppendLine("   , pessoa.email");
            sSql.AppendLine("   , pessoa.telefone");
            sSql.AppendLine("   , pessoa.celular");
            sSql.AppendLine("   , pessoa.outro_contato");
            sSql.AppendLine("FROM pessoa");
            sSql.AppendLine("WHERE pessoa.id=@id");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", idPessoa);
            Pessoas item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if(scom.Read())
                    {
                        item = new Pessoas()
                        {
                            Id = scom.GetValue<long>("id"),
                            SNome = scom.GetValue<string>("nome"),
                            SRG = scom.GetValue<string>("rg"),
                            SCPF = scom.GetValue<string>("cpf"),
                            CTipo = scom.GetValue<char>("tipo"),
                            SSexo = scom.GetValue<string>("sexo"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            DtmNascimento = scom.GetValue<DateTime?>("data_nascimento"),
                            Status = scom.GetValue<bool>("status"),
                            SCelular = scom.GetValue<string>("celular"),
                            SEmail = scom.GetValue<string>("email"),
                            SOutroContato = scom.GetValue<string>("outro_contato"),
                            STelefone = scom.GetValue<string>("telefone")
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
