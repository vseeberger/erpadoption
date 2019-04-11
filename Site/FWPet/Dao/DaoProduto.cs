using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoProduto
    {
        internal static void Salvar(Produto item)
        {
            if (item == null) throw new Exception("Atenção! O objeto PRODUTO não foi instanciado para salvar.");
            else
            {
                if (item.Id > 0) Alterar(item);
                else Inserir(item);

                if(item.Fabricantes != null && item.Fabricantes.Count > 0)
                {
                    for (int i = 0; i < item.Fabricantes.Count; i++)
                    {
                        if (item.Fabricantes[i].Alterou)
                        {
                            item.Fabricantes[i].IdProdutoOriginal = item.Id;
                            item.Fabricantes[i].Salvar();
                        }
                    }
                }
            }
        }

        private static void Inserir(Produto item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("INSERT INTO produto (id_fornecedor_principal, tipo_produto, referencia, nome, nome_comercial, trabalha_com_lote, possui_grade, importado, eh_medicamento, eh_vacina");
            sSql.AppendLine("                          , peso_bruto, peso_liquido, quantidade_compra, estoque_minimo, estoque_maximo, quantidade_etiquetas, tem_conversao, observacoes, id_medicamento_generico");
            sSql.AppendLine("                          , id_medicamento_principioativo, id_medicamento_grupo, id_especie_vacina, quantidade_dias_validade, quantidade_doses, quantidade_dias_entre_doses, foto_capa, id_marca)");
            sSql.AppendLine("                   VALUES(@id_fornecedor_principal, @tipo_produto, @referencia, @nome, @nome_comercial, @trabalha_com_lote, @possui_grade, @importado, @eh_medicamento, @eh_vacina");
            sSql.AppendLine("                          , @peso_bruto, @peso_liquido, @quantidade_compra, @estoque_minimo, @estoque_maximo, @quantidade_etiquetas, @tem_conversao, @observacoes, @id_medicamento_generico");
            sSql.AppendLine("                          , @id_medicamento_principioativo, @id_medicamento_grupo, @id_especie_vacina, @quantidade_dias_validade, @quantidade_doses, @quantidade_dias_entre_doses, @foto_capa, @id_marca);SELECT LAST_INSERT_ID();");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id_fornecedor_principal", item.FabricantePrincipal);
            scom.AddWithValue("@tipo_produto", item.STipoProduto);
            scom.AddWithValue("@referencia", item.SReferencia);
            scom.AddWithValue("@nome", item.SNome);
            scom.AddWithValue("@nome_comercial", item.SNomeComercial);
            scom.AddWithValue("@trabalha_com_lote", item.TrabalhaComLote ? 1 : 0);
            scom.AddWithValue("@possui_grade", item.PossuiGrade ? 1 : 0);
            scom.AddWithValue("@importado", item.Importado ? 1 : 0);
            scom.AddWithValue("@eh_medicamento", item.EhMedicamento ? 1 : 0);
            scom.AddWithValue("@eh_vacina", item.EhVacina ? 1 : 0);
            scom.AddWithValue("@peso_bruto", item.DPesoBruto);
            scom.AddWithValue("@peso_liquido", item.DPesoLiquido);
            scom.AddWithValue("@quantidade_compra", item.DQuantidadeCompra);
            scom.AddWithValue("@estoque_minimo", item.DEstoqueMinimo);
            scom.AddWithValue("@estoque_maximo", item.DEstoqueMaximo);
            scom.AddWithValue("@quantidade_etiquetas", item.IQuantidadeEtiquetas);
            scom.AddWithValue("@tem_conversao", item.TemConversao ? 1 : 0);
            scom.AddWithValue("@observacoes", item.SObservacoes);
            scom.AddWithValue("@id_medicamento_generico", item.Generico == null ? 0 : item.Generico.Id);
            scom.AddWithValue("@id_medicamento_principioativo", item.PrincipioAtivo == null ? 0 : item.PrincipioAtivo.Id);
            scom.AddWithValue("@id_medicamento_grupo", item.Grupo == null ? 0 : item.Grupo.Id);
            scom.AddWithValue("@id_especie_vacina", item.Especie == null ? 0 : item.Especie.Id);
            scom.AddWithValue("@quantidade_dias_validade", item.IQuantidadeDiasValidade);
            scom.AddWithValue("@quantidade_doses", item.IQuantidadeDoses);
            scom.AddWithValue("@quantidade_dias_entre_doses", item.IQuantidadeDiasEntreDoses);
            scom.AddWithValue("@foto_capa", item.SPathFotoCapa);
            scom.AddWithValue("@id_marca", item.Marca == null ? 0 : item.Marca.Id);

            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    scom.Read();
                    long i;
                    if (long.TryParse(scom.GetValue<object>(0).ToString(), out i)) item.Id = i;
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        private static void Alterar(Produto item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("UPDATE produto SET ");
            sSql.AppendLine("     id_fornecedor_principal       = @id_fornecedor_principal      ");
            sSql.AppendLine("   , tipo_produto                  = @tipo_produto                 ");
            sSql.AppendLine("   , referencia                    = @referencia                   ");
            sSql.AppendLine("   , nome                          = @nome                         ");
            sSql.AppendLine("   , nome_comercial                = @nome_comercial               ");
            sSql.AppendLine("   , trabalha_com_lote             = @trabalha_com_lote            ");
            sSql.AppendLine("   , possui_grade                  = @possui_grade                 ");
            sSql.AppendLine("   , importado                     = @importado                    ");
            sSql.AppendLine("   , eh_medicamento                = @eh_medicamento               ");
            sSql.AppendLine("   , eh_vacina                     = @eh_vacina                    ");
            sSql.AppendLine("   , peso_bruto                    = @peso_bruto                   ");
            sSql.AppendLine("   , peso_liquido                  = @peso_liquido                 ");
            sSql.AppendLine("   , quantidade_compra             = @quantidade_compra            ");
            sSql.AppendLine("   , estoque_minimo                = @estoque_minimo               ");
            sSql.AppendLine("   , estoque_maximo                = @estoque_maximo               ");
            sSql.AppendLine("   , quantidade_etiquetas          = @quantidade_etiquetas         ");
            sSql.AppendLine("   , tem_conversao                 = @tem_conversao                ");
            sSql.AppendLine("   , observacoes                   = @observacoes                  ");
            sSql.AppendLine("   , id_medicamento_generico       = @id_medicamento_generico      ");
            sSql.AppendLine("   , id_medicamento_principioativo = @id_medicamento_principioativo");
            sSql.AppendLine("   , id_medicamento_grupo          = @id_medicamento_grupo         ");
            sSql.AppendLine("   , id_especie_vacina             = @id_especie_vacina            ");
            sSql.AppendLine("   , quantidade_dias_validade      = @quantidade_dias_validade     ");
            sSql.AppendLine("   , quantidade_doses              = @quantidade_doses             ");
            sSql.AppendLine("   , quantidade_dias_entre_doses   = @quantidade_dias_entre_doses  ");
            sSql.AppendLine("   , status                        = @status                       ");
            sSql.AppendLine("	, data_ultalt                   = NOW()");
            sSql.AppendLine("   , foto_capa                     = @foto_capa");
            sSql.AppendLine("   , id_marca                      = @id_marca");
            sSql.AppendLine("WHERE id = @id");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            scom.AddWithValue("@id_fornecedor_principal", item.FabricantePrincipal.Id);
            scom.AddWithValue("@tipo_produto", item.STipoProduto);
            scom.AddWithValue("@referencia", item.SReferencia);
            scom.AddWithValue("@nome", item.SNome);
            scom.AddWithValue("@nome_comercial", item.SNomeComercial);
            scom.AddWithValue("@trabalha_com_lote", item.TrabalhaComLote ? 1 : 0);
            scom.AddWithValue("@possui_grade", item.PossuiGrade ? 1 : 0);
            scom.AddWithValue("@importado", item.Importado ? 1 : 0);
            scom.AddWithValue("@eh_medicamento", item.EhMedicamento ? 1 : 0);
            scom.AddWithValue("@eh_vacina", item.EhVacina ? 1 : 0);
            scom.AddWithValue("@peso_bruto", item.DPesoBruto);
            scom.AddWithValue("@peso_liquido", item.DPesoLiquido);
            scom.AddWithValue("@quantidade_compra", item.DQuantidadeCompra);
            scom.AddWithValue("@estoque_minimo", item.DEstoqueMinimo);
            scom.AddWithValue("@estoque_maximo", item.DEstoqueMaximo);
            scom.AddWithValue("@quantidade_etiquetas", item.IQuantidadeEtiquetas);
            scom.AddWithValue("@tem_conversao", item.TemConversao ? 1 : 0);
            scom.AddWithValue("@observacoes", item.SObservacoes);
            scom.AddWithValue("@id_medicamento_generico", item.Generico == null ? 0 : item.Generico.Id);
            scom.AddWithValue("@id_medicamento_principioativo", item.PrincipioAtivo == null ? 0 : item.PrincipioAtivo.Id);
            scom.AddWithValue("@id_medicamento_grupo", item.Grupo == null ? 0 : item.Grupo.Id);
            scom.AddWithValue("@id_especie_vacina", item.Especie == null ? 0 : item.Especie.Id);
            scom.AddWithValue("@quantidade_dias_validade", item.IQuantidadeDiasValidade);
            scom.AddWithValue("@quantidade_doses", item.IQuantidadeDoses);
            scom.AddWithValue("@quantidade_dias_entre_doses", item.IQuantidadeDiasEntreDoses);
            scom.AddWithValue("@status", item.Status ? 1 : 0);
            scom.AddWithValue("@foto_capa", item.SPathFotoCapa);
            scom.AddWithValue("@id_marca", item.Marca == null ? 0 : item.Marca.Id);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static List<Produto> Pesquisar(string _Tipo, bool? _Medicamento, bool? _Vacina, bool? PesquisarOU)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT");
            sSql.AppendLine("     produto.id");
            sSql.AppendLine("   , produto.id_fornecedor_principal");
            sSql.AppendLine("   , produto.tipo_produto");
            sSql.AppendLine("   , produto.referencia");
            sSql.AppendLine("   , produto.nome");
            sSql.AppendLine("   , produto.nome_comercial");
            sSql.AppendLine("   , produto.trabalha_com_lote");
            sSql.AppendLine("   , produto.possui_grade");
            sSql.AppendLine("   , produto.importado");
            sSql.AppendLine("   , produto.eh_medicamento");
            sSql.AppendLine("   , produto.eh_vacina");
            sSql.AppendLine("   , produto.peso_bruto");
            sSql.AppendLine("   , produto.peso_liquido");
            sSql.AppendLine("   , produto.quantidade_compra");
            sSql.AppendLine("   , produto.estoque_minimo");
            sSql.AppendLine("   , produto.estoque_maximo");
            sSql.AppendLine("   , produto.quantidade_etiquetas");
            sSql.AppendLine("   , produto.tem_conversao");
            sSql.AppendLine("   , produto.observacoes");
            sSql.AppendLine("   , produto.id_medicamento_generico");
            sSql.AppendLine("   , produto.id_medicamento_principioativo");
            sSql.AppendLine("   , produto.id_medicamento_grupo");
            sSql.AppendLine("   , produto.id_especie_vacina");
            sSql.AppendLine("   , produto.quantidade_dias_validade");
            sSql.AppendLine("   , produto.quantidade_doses");
            sSql.AppendLine("   , produto.quantidade_dias_entre_doses");
            sSql.AppendLine("   , produto.data_cadastro");
            sSql.AppendLine("   , produto.data_ultalt");
            sSql.AppendLine("   , produto.status");
            sSql.AppendLine("   , produto.foto_capa");
            sSql.AppendLine("   , produto.id_marca");
            sSql.AppendLine("FROM produto");
            sSql.AppendLine("WHERE produto.status=1");

            if (!String.IsNullOrEmpty(_Tipo)) sSql.AppendLine("AND produto.tipo_produto = @tipo");
            if (PesquisarOU == null || PesquisarOU.Value == false)
            {
                if (_Medicamento != null) sSql.AppendLine("AND produto.eh_medicamento = @eh_medicamento");
                if (_Vacina != null) sSql.AppendLine("AND produto.eh_vacina = @eh_vacina");
            }
            else
            {
                if (_Medicamento != null && _Medicamento.Value) sSql.AppendLine("AND (produto.eh_vacina = 0 AND produto.eh_medicamento IN (1,0))");
                if (_Vacina != null && _Vacina.Value) sSql.AppendLine("AND (produto.eh_medicamento = 0 AND produto.eh_vacina IN (1,0))");
            }

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@tipo", _Tipo);
            scom.AddWithValue("@eh_medicamento", _Medicamento == null ? 0 : _Medicamento.Value ? 1 : 0);
            scom.AddWithValue("@eh_vacina", _Vacina == null ? 0 : _Vacina.Value ? 1 : 0);

            List<Produto> Lst = new List<Produto>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Produto item = null;
                    while (scom.Read())
                    {
                        item = new Produto()
                        {
                            Id = scom.GetValue<long>("id"),
                            SNome = scom.GetValue<string>("nome"),
                            SNomeComercial = scom.GetValue<string>("nome_comercial"),
                            SObservacoes = scom.GetValue<string>("observacoes"),
                            SReferencia = scom.GetValue<string>("referencia"),

                            STipoProduto = scom.GetValue<string>("tipo_produto"),
                            TrabalhaComLote = scom.GetValue<bool>("trabalha_com_lote"),
                            PossuiGrade = scom.GetValue<bool>("possui_grade"),
                            Importado = scom.GetValue<bool>("importado"),
                            EhMedicamento = scom.GetValue<bool>("eh_medicamento"),
                            EhVacina = scom.GetValue<bool>("eh_vacina"),

                            DPesoBruto = scom.GetValue<decimal>("peso_bruto"),
                            DPesoLiquido = scom.GetValue<decimal>("peso_liquido"),
                            DEstoqueMinimo = scom.GetValue<decimal>("estoque_minimo"),
                            DEstoqueMaximo = scom.GetValue<decimal>("estoque_maximo"),
                            DQuantidadeCompra = scom.GetValue<decimal>("quantidade_compra"),

                            TemConversao = scom.GetValue<bool>("tem_conversao"),
                            IQuantidadeDiasEntreDoses = scom.GetValue<int>("quantidade_dias_entre_doses"),
                            IQuantidadeDiasValidade = scom.GetValue<int>("quantidade_dias_validade"),
                            IQuantidadeDoses = scom.GetValue<int>("quantidade_doses"),
                            IQuantidadeEtiquetas = scom.GetValue<int>("quantidade_etiquetas"),

                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status"),
                            SPathFotoCapa = scom.GetValue<string>("foto_capa")
                        };

                        if (scom.GetValue<int>("id_especie_vacina") > 0)
                        {
                            item.Especie = new Especie()
                            {
                                Id = scom.GetValue<int>("id_especie_vacina")
                            };
                        }

                        if (scom.GetValue<int>("id_medicamento_principioativo") > 0)
                        {
                            item.PrincipioAtivo = new MedicamentoPrincipioAtivo()
                            {
                                Id = scom.GetValue<int>("id_medicamento_principioativo")
                            };
                        }

                        if (scom.GetValue<int>("id_medicamento_grupo") > 0)
                        {
                            item.Grupo = new MedicamentoGrupo()
                            {
                                Id = scom.GetValue<int>("id_medicamento_grupo")
                            };
                        }

                        if (scom.GetValue<long>("id_medicamento_generico") > 0)
                        {
                            item.Generico = new MedicamentoGenerico()
                            {
                                Id = scom.GetValue<long>("id_medicamento_generico")
                            };
                        }

                        if (scom.GetValue<long>("id_fornecedor_principal") > 0)
                        {
                            item.FabricantePrincipal = new Empresa()
                            {
                                Id = scom.GetValue<long>("id_fornecedor_principal")
                            };
                        }

                        if(scom.GetValue<int>("id_marca") > 0)
                        {
                            item.Marca = new ProdutoMarca()
                            {
                                Id = scom.GetValue<int>("id_marca"),
                            };
                        }
                        Lst.Add(item);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }

        internal static void Excluir(Produto item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("UPDATE produto SET ");
            sSql.AppendLine("	  status = 0");
            sSql.AppendLine("	, data_ultalt       = NOW()");
            sSql.AppendLine("WHERE id = @id");
            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item);
            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static Produto Obter(long _Medicamento)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT");
            sSql.AppendLine("     produto.id");
            sSql.AppendLine("   , produto.id_fornecedor_principal");
            sSql.AppendLine("   , produto.tipo_produto");
            sSql.AppendLine("   , produto.referencia");
            sSql.AppendLine("   , produto.nome");
            sSql.AppendLine("   , produto.nome_comercial");
            sSql.AppendLine("   , produto.trabalha_com_lote");
            sSql.AppendLine("   , produto.possui_grade");
            sSql.AppendLine("   , produto.importado");
            sSql.AppendLine("   , produto.eh_medicamento");
            sSql.AppendLine("   , produto.eh_vacina");
            sSql.AppendLine("   , produto.peso_bruto");
            sSql.AppendLine("   , produto.peso_liquido");
            sSql.AppendLine("   , produto.quantidade_compra");
            sSql.AppendLine("   , produto.estoque_minimo");
            sSql.AppendLine("   , produto.estoque_maximo");
            sSql.AppendLine("   , produto.quantidade_etiquetas");
            sSql.AppendLine("   , produto.tem_conversao");
            sSql.AppendLine("   , produto.observacoes");
            sSql.AppendLine("   , produto.id_medicamento_generico");
            sSql.AppendLine("   , produto.id_medicamento_principioativo");
            sSql.AppendLine("   , produto.id_medicamento_grupo");
            sSql.AppendLine("   , produto.id_especie_vacina");
            sSql.AppendLine("   , produto.quantidade_dias_validade");
            sSql.AppendLine("   , produto.quantidade_doses");
            sSql.AppendLine("   , produto.quantidade_dias_entre_doses");
            sSql.AppendLine("   , produto.data_cadastro");
            sSql.AppendLine("   , produto.data_ultalt");
            sSql.AppendLine("   , produto.status");
            sSql.AppendLine("   , IFNULL(especie.descricao,'') AS EspecieDescricao");
            sSql.AppendLine("   , IFNULL(medicamento_principioativo.descricao,'') AS PrincipioDescricao");
            sSql.AppendLine("   , IFNULL(medicamento_grupo.descricao,'') AS GrupoDescricao");
            sSql.AppendLine("   , IFNULL(medicamento_generico.descricao, '') AS GenericoDescricao");
            sSql.AppendLine("   , IFNULL(fornecedor.razaosocial_nome,'') AS FornecedorNome");
            sSql.AppendLine("   , IFNULL(fornecedor.nomefantasia_apelido,'') AS FornecedorApelido");
            sSql.AppendLine("   , produto.foto_capa");
            sSql.AppendLine("   , produto.id_marca");
            sSql.AppendLine("FROM produto");
            sSql.AppendLine("   LEFT JOIN especie ON especie.id = produto.id_especie_vacina");
            sSql.AppendLine("   LEFT JOIN medicamento_principioativo ON medicamento_principioativo.id = produto.id_medicamento_principioativo");
            sSql.AppendLine("   LEFT JOIN medicamento_grupo ON medicamento_grupo.id = produto.id_medicamento_grupo");
            sSql.AppendLine("   LEFT JOIN medicamento_generico ON medicamento_generico.id = produto.id_medicamento_generico");
            sSql.AppendLine("   LEFT JOIN fornecedor ON fornecedor.id = produto.id_fornecedor_principal");
            sSql.AppendLine("WHERE produto.id=@id;");
            sSql.AppendLine("");
            sSql.AppendLine("SELECT");
            sSql.AppendLine("      produto_outros_fornecedores.id");
            sSql.AppendLine("    , produto_outros_fornecedores.id_produto");
            sSql.AppendLine("    , produto_outros_fornecedores.id_fornecedor");
            sSql.AppendLine("    , produto_outros_fornecedores.sequencia");
            sSql.AppendLine("    , produto_outros_fornecedores.codigo_do_fabricante");
            sSql.AppendLine("    , produto_outros_fornecedores.nome");
            sSql.AppendLine("    , produto_outros_fornecedores.nome_generico");
            sSql.AppendLine("    , produto_outros_fornecedores.data_cadastro");
            sSql.AppendLine("    , produto_outros_fornecedores.data_ultalt");
            sSql.AppendLine("    , produto_outros_fornecedores.status");
            sSql.AppendLine("    , fornecedor.razaosocial_nome");
            sSql.AppendLine("    , fornecedor.nomefantasia_apelido");
            sSql.AppendLine("FROM produto_outros_fornecedores");
            sSql.AppendLine("    INNER JOIN fornecedor ON fornecedor.id = produto_outros_fornecedores.id_fornecedor");
            sSql.AppendLine("                         AND fornecedor.status = 1");
            sSql.AppendLine("WHERE id_produto = @id;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Medicamento);
            Produto item = null;

            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        #region Carrega o produto
                        item = new Produto()
                        {
                            Id = scom.GetValue<long>("id"),
                            SNome = scom.GetValue<string>("nome"),
                            SNomeComercial = scom.GetValue<string>("nome_comercial"),
                            SObservacoes = scom.GetValue<string>("observacoes"),
                            SReferencia = scom.GetValue<string>("referencia"),

                            STipoProduto = scom.GetValue<string>("tipo_produto"),
                            TrabalhaComLote = scom.GetValue<bool>("trabalha_com_lote"),
                            PossuiGrade = scom.GetValue<bool>("possui_grade"),
                            Importado = scom.GetValue<bool>("importado"),
                            EhMedicamento = scom.GetValue<bool>("eh_medicamento"),
                            EhVacina = scom.GetValue<bool>("eh_vacina"),

                            DPesoBruto = scom.GetValue<decimal>("peso_bruto"),
                            DPesoLiquido = scom.GetValue<decimal>("peso_liquido"),
                            DEstoqueMinimo = scom.GetValue<decimal>("estoque_minimo"),
                            DEstoqueMaximo = scom.GetValue<decimal>("estoque_maximo"),
                            DQuantidadeCompra = scom.GetValue<decimal>("quantidade_compra"),

                            TemConversao = scom.GetValue<bool>("tem_conversao"),
                            IQuantidadeDiasEntreDoses = scom.GetValue<int>("quantidade_dias_entre_doses"),
                            IQuantidadeDiasValidade = scom.GetValue<int>("quantidade_dias_validade"),
                            IQuantidadeDoses = scom.GetValue<int>("quantidade_doses"),
                            IQuantidadeEtiquetas = scom.GetValue<int>("quantidade_etiquetas"),

                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status"),
                            SPathFotoCapa = scom.GetValue<string>("foto_capa")
                        };


                        //INICIA AS LISTAS PARA NÃO TER LISTA NULL
                        item.Fabricantes = new List<ProdutoOutrosFabricantes>();
                        item.LstConversao = new List<ProdutoConversao>();
                        item.LstCodigoBarras = new List<ProdutoBarras>();
                        item.LstLotes = new List<ProdutoLote>();

                        if (scom.GetValue<int>("id_especie_vacina") > 0)
                            item.Especie = new Especie(scom.GetValue<int>("id_especie_vacina"), scom.GetValue<string>("EspecieDescricao"));

                        if (scom.GetValue<int>("id_medicamento_principioativo") > 0)
                            item.PrincipioAtivo = new MedicamentoPrincipioAtivo(scom.GetValue<int>("id_medicamento_principioativo"), scom.GetValue<string>("PrincipioDescricao"));

                        if (scom.GetValue<int>("id_medicamento_grupo") > 0)
                            item.Grupo = new MedicamentoGrupo(scom.GetValue<int>("id_medicamento_grupo"), scom.GetValue<string>("GrupoDescricao"));

                        if (scom.GetValue<long>("id_medicamento_generico") > 0)
                            item.Generico = new MedicamentoGenerico(scom.GetValue<long>("id_medicamento_generico"), scom.GetValue<string>("GenericoDescricao"));

                        if (scom.GetValue<long>("id_fornecedor_principal") > 0)
                            item.FabricantePrincipal = new Empresa(scom.GetValue<long>("id_fornecedor_principal"), scom.GetValue<string>("FornecedorNome"));

                        if (scom.GetValue<int>("id_marca") > 0)
                            item.Marca = new ProdutoMarca(scom.GetValue<int>("id_marca"));
                        #endregion

                        #region Carrega outros fornecedores
                        scom.NextResult();
                        if (scom.HasRows)
                        {
                            item.Fabricantes = new List<ProdutoOutrosFabricantes>();
                            ProdutoOutrosFabricantes itemOF = null;
                            while (scom.Read())
                            {
                                itemOF = new ProdutoOutrosFabricantes()
                                {
                                    Id = scom.GetValue<long>("id"),
                                    Sequencia = scom.GetValue<int>("sequencia"),
                                    IdProdutoOriginal = scom.GetValue<long>("id_produto"),
                                    DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                                    DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                                    SCodigoDoFabricante = scom.GetValue<string>("codigo_do_fabricante"),
                                    SNomeDoProdutoDoFabricante = scom.GetValue<string>("nome"),
                                    SNomeGenerico = scom.GetValue<string>("nome_generico"),
                                    Status = scom.GetValue<bool>("status"),
                                    Fabricante = new Empresa(scom.GetValue<long>("id_fornecedor"), scom.GetValue<string>("razaosocial_nome"))
                                };
                                item.Fabricantes.Add(itemOF);
                            }
                        }
                        #endregion

                        #region Carrega as conversões

                        #endregion

                        #region Carrega os códigos de barras

                        #endregion
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }
    }
}