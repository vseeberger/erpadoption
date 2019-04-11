-- --------------------------------------------------------
-- Sistema:                     Sistema PetRescue
-- Versão:						1.0.0
-- Plataforma:					WEB
-- Linguagem:					ASP.NET C#
-- Framework					.NET 4.0
-- ########################################################
--			 SCRIPT DE CRIAÇÃO DE TABELAS
-- --------------------------------------------------------

-- Copiando estrutura para tabela agenda
CREATE TABLE IF NOT EXISTS `agenda` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_usuario` bigint(20) DEFAULT NULL,
  `nome` varchar(255) DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  `privado` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


-- Copiando estrutura para tabela agenda_contatos
CREATE TABLE IF NOT EXISTS `agenda_contatos` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_contato` bigint(20) NOT NULL,
  `tipo_contato` varchar(50) NOT NULL,
  `contato` varchar(255) NOT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


-- Copiando estrutura para tabela anamnese
CREATE TABLE IF NOT EXISTS `anamnese` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_animal` bigint(20) DEFAULT NULL,
  `id_veterinario` bigint(20) DEFAULT NULL,
  `descricao` varchar(255) DEFAULT NULL,
  `anamnese` longtext,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_realizacao` datetime DEFAULT NULL,
  `peso` decimal(18,3) DEFAULT '0.000',
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


-- Copiando estrutura para tabela animal
CREATE TABLE IF NOT EXISTS `animal` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `nome` varchar(255) DEFAULT NULL,
  `id_especie` int(11) DEFAULT NULL,
  `sexo` varchar(50) DEFAULT NULL,
  `id_responsavel` bigint(20) DEFAULT NULL,
  `observacoes` longtext,
  `numero_chip` varchar(255) DEFAULT NULL,
  `cor` varchar(255) DEFAULT NULL,
  `data_chegou` datetime DEFAULT NULL,
  `data_resgate` datetime DEFAULT NULL,
  `data_nascimento` datetime DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `id_porte` int(11) DEFAULT NULL,
  `id_disponibilidade` int(11) DEFAULT NULL,
  `id_raca` int(11) DEFAULT NULL,
  `castrado` int(11) NOT NULL DEFAULT '0',
  `status` int(11) NOT NULL DEFAULT '1',
  `foto_capa` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


-- Copiando estrutura para tabela animal_fotos
CREATE TABLE IF NOT EXISTS `animal_fotos` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_animal` bigint(20) DEFAULT NULL,
  `nome` varchar(255) DEFAULT NULL,
  `nome_virtual` varchar(255) DEFAULT NULL,
  `extensao` varchar(5) DEFAULT NULL,
  `objeto_fileinfo` blob,
  `foto_miniatura` blob,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


-- Copiando estrutura para tabela beneficio_desconto
CREATE TABLE IF NOT EXISTS `beneficio_desconto` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descricao` varchar(255) DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `valor_maximo` decimal(18,2) DEFAULT '0.00',
  `percentual_salario` decimal(18,2) DEFAULT '0.00',
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


-- Copiando estrutura para tabela cargos_funcoes
CREATE TABLE IF NOT EXISTS `cargos_funcoes` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_cbo` bigint(20) NOT NULL DEFAULT '0',
  `descricao` varchar(255) DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


-- Copiando estrutura para tabela cbo_cargos_funcoes
CREATE TABLE IF NOT EXISTS `cbo_cargos_funcoes` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `cbo` varchar(255) DEFAULT NULL,
  `descricao` varchar(255) DEFAULT NULL,
  `complemento` varchar(255) DEFAULT NULL,
  `versao` varchar(255) DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


-- Copiando estrutura para tabela centro_de_custos_lucro
CREATE TABLE IF NOT EXISTS `centro_de_custos_lucro` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descricao` varchar(250) DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  `custo_ou_lucro` varchar(1) NOT NULL DEFAULT 'C',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


-- Copiando estrutura para tabela clinica
CREATE TABLE IF NOT EXISTS `clinica` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `razaosocial_nome` varchar(255) DEFAULT NULL,
  `nomefantasia_apelido` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `site` varchar(255) DEFAULT NULL,
  `data_fundacao_nasc` datetime DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `tipo_pessoa` int(11) NOT NULL DEFAULT '1',
  `cnpj_cpf` varchar(50) NOT NULL,
  `insc_municipal` varchar(50) DEFAULT NULL,
  `insc_estadual` varchar(50) DEFAULT NULL,
  `endereco` varchar(255) DEFAULT NULL,
  `endereco_numero` varchar(255) DEFAULT NULL,
  `endereco_bairro` varchar(255) DEFAULT NULL,
  `endereco_cidade` varchar(255) DEFAULT NULL,
  `endereco_uf` varchar(2) DEFAULT NULL,
  `endereco_cep` varchar(12) DEFAULT NULL,
  `endereco_observacoes` varchar(12) DEFAULT NULL,
  `status` int(11) NOT NULL DEFAULT '1',
  `tipocadastro` varchar(2) NOT NULL DEFAULT 'C',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;



-- Copiando estrutura para tabela colaborador_escalas
CREATE TABLE IF NOT EXISTS `colaborador_escalas` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `idColaborador` bigint(20) DEFAULT NULL,
  `titulo` varchar(255) DEFAULT NULL,
  `url` varchar(255) DEFAULT NULL,
  `css_classe` varchar(255) DEFAULT NULL,
  `descricao` longtext,
  `data_inicio` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_final` datetime DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela configuracoes
CREATE TABLE IF NOT EXISTS `configuracoes` (
  `id` int(20) NOT NULL AUTO_INCREMENT,
  `dia_pagamento_default` int(11) DEFAULT '5',
  `valor_diaria` decimal(18,3) DEFAULT '0.000',
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela conta_bancaria
CREATE TABLE IF NOT EXISTS `conta_bancaria` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_tipo_conta` int(11) DEFAULT NULL,
  `descricao` varchar(250) DEFAULT NULL,
  `agencia` varchar(250) DEFAULT NULL,
  `conta` varchar(250) DEFAULT NULL,
  `titular_nome` varchar(250) DEFAULT NULL,
  `titular_documento` varchar(250) DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  `principal` int(11) NOT NULL DEFAULT '0',
  `saldo_inicial` decimal(18,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela conta_bancaria_tipo
CREATE TABLE IF NOT EXISTS `conta_bancaria_tipo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descricao` varchar(250) DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela conta_pagar_receber
CREATE TABLE IF NOT EXISTS `conta_pagar_receber` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_conta_bancaria` int(11) DEFAULT NULL,
  `id_centro_de_custos_lucro` int(11) DEFAULT NULL,
  `id_origem_de_custos_lucro` int(11) DEFAULT NULL,
  `descricao_ou_referencia` varchar(250) DEFAULT NULL,
  `nome_de_quem_pagou` varchar(250) DEFAULT NULL,
  `numero_do_documento` varchar(250) DEFAULT NULL,
  `custo_ou_lucro` varchar(1) DEFAULT NULL,
  `mais_detalhes` longtext,
  `data_pagamento` datetime DEFAULT NULL,
  `data_previsao` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_competencia` datetime DEFAULT NULL,
  `valor` decimal(18,3) DEFAULT '0.000',
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  `situacao` int(11) NOT NULL DEFAULT '0',
  `id_forma_pagamento` int(11) DEFAULT NULL,
  `id_pagopara` bigint(20) DEFAULT NULL,
  `pagopara_tipo` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela dependentes
CREATE TABLE IF NOT EXISTS `dependentes` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_grau_parentesco` int(11) NOT NULL DEFAULT '0',
  `id_pessoa` bigint(20) NOT NULL DEFAULT '0',
  `nome` varchar(255) DEFAULT NULL,
  `data_nascimento` datetime DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela endereco
CREATE TABLE IF NOT EXISTS `endereco` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `endereco` varchar(255) DEFAULT NULL,
  `bairro` varchar(255) DEFAULT NULL,
  `cidade` varchar(255) DEFAULT NULL,
  `uf` varchar(2) DEFAULT NULL,
  `cep` varchar(10) DEFAULT NULL,
  `complemento` varchar(255) DEFAULT NULL,
  `numero` varchar(255) DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela especie
CREATE TABLE IF NOT EXISTS `especie` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descricao` varchar(255) DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela estoque_entradas_saidas
CREATE TABLE IF NOT EXISTS `estoque_entradas_saidas` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_usuario` bigint(20) NOT NULL DEFAULT '0',
  `nota_fiscal` varchar(255) DEFAULT NULL,
  `entrada_saida` int(11) NOT NULL DEFAULT '1',
  `valor_total` decimal(18,3) NOT NULL DEFAULT '0.000',
  `data_movimentacao` datetime DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  `observacao` longtext,
  `id_estoque_tipo_movimentacao` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela estoque_item
CREATE TABLE IF NOT EXISTS `estoque_item` (
  `id_estoque` bigint(20) NOT NULL,
  `item` int(11) NOT NULL,
  `id_produto` bigint(20) DEFAULT NULL,
  `id_lote_produto` bigint(20) DEFAULT NULL,
  `quantidade` decimal(18,3) DEFAULT '0.000',
  `data_movimento` datetime DEFAULT NULL,
  `valor_un` decimal(18,3) DEFAULT NULL,
  `data_cadastro` datetime DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime DEFAULT CURRENT_TIMESTAMP,
  `id_usuario` bigint(20) DEFAULT '0',
  `nota_fiscal` varchar(255) DEFAULT NULL,
  `status` int(11) DEFAULT '1',
  `integrado` int(11) DEFAULT '1',
  `entrada_saida` int(1) NOT NULL DEFAULT '1',
  `id_endereco_origem` bigint(20) DEFAULT NULL,
  `id_endereco_destino` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id_estoque`,`item`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela estoque_tipo_movimentacao
CREATE TABLE IF NOT EXISTS `estoque_tipo_movimentacao` (
  `id` varchar(10) NOT NULL,
  `descricao` varchar(255) DEFAULT NULL,
  `data_cadastro` datetime DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela exame
CREATE TABLE IF NOT EXISTS `exame` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `descricao` varchar(255) DEFAULT NULL,
  `corpo_exame` longtext,
  `id_tipo` int(11) DEFAULT NULL,
  `id_clinica` bigint(20) DEFAULT NULL,
  `profissional_que_assinou` varchar(255) DEFAULT NULL,
  `id_veterinario` bigint(20) DEFAULT NULL,
  `id_animal` bigint(20) DEFAULT NULL,
  `data_realizado` datetime DEFAULT NULL,
  `data_agendado` datetime DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela formas_pagamento_recebimento
CREATE TABLE IF NOT EXISTS `formas_pagamento_recebimento` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descricao` varchar(250) DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela formularios
CREATE TABLE IF NOT EXISTS `formularios` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(250) DEFAULT NULL,
  `path` varchar(250) DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  `grupo` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela formulario_x_perfil_x_acesso
CREATE TABLE IF NOT EXISTS `formulario_x_perfil_x_acesso` (
  `id_formulario` int(11) NOT NULL,
  `id_perfil` bigint(20) NOT NULL,
  `abrir` int(11) NOT NULL DEFAULT '0',
  `pesquisar` int(11) NOT NULL DEFAULT '0',
  `inserir` int(11) NOT NULL DEFAULT '0',
  `alterar` int(11) NOT NULL DEFAULT '0',
  `excluir` int(11) NOT NULL DEFAULT '0',
  `especial` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_formulario`,`id_perfil`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela fornecedor
CREATE TABLE IF NOT EXISTS `fornecedor` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `razaosocial_nome` varchar(255) DEFAULT NULL,
  `nomefantasia_apelido` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `site` varchar(255) DEFAULT NULL,
  `data_fundacao_nasc` datetime DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `tipo_pessoa` int(11) NOT NULL DEFAULT '1',
  `cnpj_cpf` varchar(50) NOT NULL,
  `insc_municipal` varchar(50) DEFAULT NULL,
  `insc_estadual` varchar(50) DEFAULT NULL,
  `endereco` varchar(255) DEFAULT NULL,
  `endereco_numero` varchar(255) DEFAULT NULL,
  `endereco_bairro` varchar(255) DEFAULT NULL,
  `endereco_cidade` varchar(255) DEFAULT NULL,
  `endereco_uf` varchar(2) DEFAULT NULL,
  `endereco_cep` varchar(12) DEFAULT NULL,
  `endereco_observacoes` varchar(12) DEFAULT NULL,
  `status` int(11) NOT NULL DEFAULT '1',
  `tipocadastro` varchar(2) NOT NULL DEFAULT 'E',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela grau_parentesco
CREATE TABLE IF NOT EXISTS `grau_parentesco` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descricao` varchar(255) DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela lista_compras
CREATE TABLE IF NOT EXISTS `lista_compras` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_usuario` bigint(20) NOT NULL DEFAULT '0',
  `descricao` varchar(255) DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  `finalizado` int(11) NOT NULL DEFAULT '0',
  `data_previsao` datetime DEFAULT NULL,
  `data_realizacao_compra` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela lista_compras_produtos
CREATE TABLE IF NOT EXISTS `lista_compras_produtos` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_lista` bigint(20) NOT NULL DEFAULT '0',
  `id_produto` bigint(20) NOT NULL DEFAULT '0',
  `quantidade` int(11) NOT NULL DEFAULT '0',
  `id_usuario_pediu` bigint(20) NOT NULL DEFAULT '0',
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  `quantidade_atendida` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela logs
CREATE TABLE IF NOT EXISTS `logs` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `descricao` longtext,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `id_usuario` bigint(20) NOT NULL,
  `id_formulario` int(11) NOT NULL,
  `id_log_acao` int(11) NOT NULL,
  `objeto_antes` longtext,
  `objeto_depois` longtext,
  `tipo_do_objeto` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela log_acao
CREATE TABLE IF NOT EXISTS `log_acao` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descricao` varchar(255) DEFAULT NULL,
  `texto` varchar(255) DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela marca
CREATE TABLE IF NOT EXISTS `marca` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descricao` varchar(255) DEFAULT NULL,
  `tipo` varchar(10) NOT NULL DEFAULT 'M',
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela medicamento_generico
CREATE TABLE IF NOT EXISTS `medicamento_generico` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `descricao` varchar(255) DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela medicamento_grupo
CREATE TABLE IF NOT EXISTS `medicamento_grupo` (
  `id` int(11) NOT NULL,
  `descricao` varchar(255) DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela medicamento_principioativo
CREATE TABLE IF NOT EXISTS `medicamento_principioativo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descricao` varchar(255) DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela origem_de_custos_lucro
CREATE TABLE IF NOT EXISTS `origem_de_custos_lucro` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_origem_de_custos_lucro` int(11) DEFAULT NULL,
  `descricao` varchar(250) DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  `entrada_saida` varchar(1) NOT NULL DEFAULT 'S',
  `classificacao` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela perfil
CREATE TABLE IF NOT EXISTS `perfil` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `nome` varchar(255) DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela pessoa
CREATE TABLE IF NOT EXISTS `pessoa` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `nome` varchar(255) DEFAULT NULL,
  `rg` varchar(255) DEFAULT NULL,
  `cpf` varchar(255) DEFAULT NULL,
  `crmv` varchar(255) DEFAULT NULL,
  `id_endereco` bigint(20) DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_nascimento` datetime DEFAULT NULL,
  `tipo` varchar(1) NOT NULL COMMENT '//P -> PADRINHOS // R -> RESPONSAVEIS',
  `sexo` varchar(1) NOT NULL COMMENT '//M -> Masculino // F -> Feminino',
  `status` int(11) NOT NULL DEFAULT '1',
  `outro_contato` varchar(255) DEFAULT NULL,
  `celular` varchar(255) DEFAULT NULL,
  `telefone` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `hora_trab_entrada` varchar(5) DEFAULT NULL,
  `hora_trab_saida` varchar(5) DEFAULT NULL,
  `trab_domingo` int(11) NOT NULL DEFAULT '0',
  `trab_segunda` int(11) NOT NULL DEFAULT '0',
  `trab_terca` int(11) NOT NULL DEFAULT '0',
  `trab_quarta` int(11) NOT NULL DEFAULT '0',
  `trab_quinta` int(11) NOT NULL DEFAULT '0',
  `trab_sexta` int(11) NOT NULL DEFAULT '0',
  `trab_sabado` int(11) NOT NULL DEFAULT '0',
  `valor` decimal(18,3) DEFAULT '0.000',
  `diarista` int(11) NOT NULL DEFAULT '0',
  `dia_pagamento` int(11) DEFAULT '5',
  `recebe_na_diaria` int(11) NOT NULL DEFAULT '0',
  `rg_uf` varchar(2) DEFAULT NULL,
  `rg_orgao` varchar(255) DEFAULT NULL,
  `rg_data` datetime DEFAULT NULL,
  `ctps` varchar(50) DEFAULT NULL,
  `ctps_serie` varchar(50) DEFAULT NULL,
  `ctps_uf` varchar(2) DEFAULT NULL,
  `tit_eleitor` varchar(50) DEFAULT NULL,
  `tit_eleitor_zona` varchar(50) DEFAULT NULL,
  `tit_eleitor_secao` varchar(50) DEFAULT NULL,
  `pis_pasep` varchar(50) DEFAULT NULL,
  `data_admissao` datetime DEFAULT NULL,
  `data_demissao` datetime DEFAULT NULL,
  `nome_mae` varchar(250) DEFAULT NULL,
  `nome_pai` varchar(250) DEFAULT NULL,
  `estrangeiro` int(11) NOT NULL DEFAULT '0',
  `naturalidade` varchar(250) DEFAULT NULL,
  `uf_nascimento` varchar(2) DEFAULT NULL,
  `nacionalidade` varchar(250) DEFAULT NULL,
  `passaporte` varchar(250) DEFAULT NULL,
  `tipo_sanguineo` varchar(3) DEFAULT NULL,
  `estado_civil` varchar(250) DEFAULT NULL,
  `numero_filhos` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela pessoa_ferias
CREATE TABLE IF NOT EXISTS `pessoa_ferias` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `idPessoa` bigint(20) NOT NULL DEFAULT '0',
  `observacoes` varchar(255) DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_comp_de` datetime DEFAULT NULL,
  `data_comp_ate` datetime DEFAULT NULL,
  `data_periodo_de` datetime DEFAULT NULL,
  `data_periodo_ate` datetime DEFAULT NULL,
  `agendado` int(11) NOT NULL DEFAULT '1',
  `realizou` int(11) NOT NULL DEFAULT '0',
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela pessoa_x_endereco
CREATE TABLE IF NOT EXISTS `pessoa_x_endereco` (
  `id_pessoa` bigint(20) NOT NULL,
  `id_endereco` bigint(20) NOT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id_pessoa`,`id_endereco`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela plano_de_contas
CREATE TABLE IF NOT EXISTS `plano_de_contas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_pai` int(11) DEFAULT NULL,
  `numero` varchar(250) DEFAULT NULL,
  `descricao` varchar(250) DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela porte
CREATE TABLE IF NOT EXISTS `porte` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descricao` varchar(255) DEFAULT NULL,
  `sigla` varchar(50) DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela produto
CREATE TABLE IF NOT EXISTS `produto` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_fornecedor_principal` bigint(20) NOT NULL DEFAULT '0',
  `tipo_produto` varchar(2) NOT NULL DEFAULT 'C',
  `referencia` varchar(50) DEFAULT NULL,
  `nome` varchar(250) DEFAULT NULL,
  `nome_comercial` varchar(250) DEFAULT NULL,
  `trabalha_com_lote` int(11) NOT NULL DEFAULT '0',
  `possui_grade` int(11) NOT NULL DEFAULT '0',
  `importado` int(11) NOT NULL DEFAULT '0',
  `eh_medicamento` int(11) NOT NULL DEFAULT '0',
  `eh_vacina` int(11) NOT NULL DEFAULT '0',
  `peso_bruto` decimal(18,3) NOT NULL DEFAULT '0.000',
  `peso_liquido` decimal(18,3) NOT NULL DEFAULT '0.000',
  `quantidade_compra` decimal(18,2) NOT NULL DEFAULT '0.00',
  `estoque_minimo` decimal(18,2) NOT NULL DEFAULT '0.00',
  `estoque_maximo` decimal(18,2) NOT NULL DEFAULT '0.00',
  `quantidade_etiquetas` int(11) NOT NULL DEFAULT '0',
  `tem_conversao` int(11) NOT NULL DEFAULT '0',
  `observacoes` longtext,
  `id_medicamento_generico` bigint(20) DEFAULT NULL,
  `id_medicamento_principioativo` int(11) DEFAULT NULL,
  `id_medicamento_grupo` int(11) DEFAULT NULL,
  `id_especie_vacina` int(11) DEFAULT NULL,
  `quantidade_dias_validade` int(11) NOT NULL DEFAULT '0',
  `quantidade_doses` int(11) NOT NULL DEFAULT '0',
  `quantidade_dias_entre_doses` int(11) NOT NULL DEFAULT '0',
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  `foto_capa` varchar(250) DEFAULT NULL,
  `id_marca` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela produto_outros_fornecedores
CREATE TABLE IF NOT EXISTS `produto_outros_fornecedores` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_produto` bigint(20) NOT NULL DEFAULT '0',
  `id_fornecedor` bigint(20) NOT NULL DEFAULT '0',
  `sequencia` int(11) NOT NULL DEFAULT '1',
  `codigo_do_fabricante` varchar(250) DEFAULT NULL,
  `nome` varchar(250) DEFAULT NULL,
  `nome_generico` varchar(250) DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela raca
CREATE TABLE IF NOT EXISTS `raca` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_especie` int(11) NOT NULL,
  `descricao` varchar(255) NOT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`,`id_especie`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela usuario
CREATE TABLE IF NOT EXISTS `usuario` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `sid` varchar(50) DEFAULT NULL,
  `idpessoa` bigint(20) DEFAULT NULL,
  `login` varchar(50) DEFAULT NULL,
  `senha` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `idperfil` bigint(20) DEFAULT NULL,
  `nome` varchar(255) DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultimologin` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  `ignora_permissao` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




-- Copiando estrutura para tabela vacina_x_animal
CREATE TABLE IF NOT EXISTS `vacina_x_animal` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_animal` bigint(20) DEFAULT NULL,
  `id_vacina` int(11) DEFAULT NULL,
  `data_aplicacao` datetime DEFAULT NULL,
  `data_agendamento` datetime DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `aplicado` int(11) NOT NULL DEFAULT '0',
  `dose_aplicada` int(11) NOT NULL DEFAULT '1',
  `dose_total` int(11) NOT NULL DEFAULT '1',
  `observacoes` longtext,
  `status` int(11) NOT NULL DEFAULT '1',
  `id_produto` bigint(20) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Copiando estrutura para tabela animal_medicamento

CREATE TABLE IF NOT EXISTS `animal_medicamento` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_animal` bigint(20) DEFAULT NULL,
  `id_medicamento` bigint(20) DEFAULT NULL,
  `id_usuario_aplicou` bigint(20) DEFAULT NULL,
  `codigo_agrupamento` varchar(255) DEFAULT NULL,
  `dose` int(11) DEFAULT '1',
  `total_dose` int(11) DEFAULT '1',
  `posologia` varchar(50) DEFAULT NULL,
  `dia_atual` int(11) DEFAULT '1',
  `total_dias` int(11) DEFAULT '1',
  `data_iniciou` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_previsao` datetime DEFAULT NULL,
  `data_realizou` datetime DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `aplicado` int(11) NOT NULL DEFAULT '0',
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


-- 21.03.2017
ALTER TABLE estoque_entradas_saidas
	ADD COLUMN `finalizado` int(11) NOT NULL DEFAULT '0'
	, ADD COLUMN `data_emissao_nf` datetime DEFAULT NULL;

-- 23.03.2017
ALTER TABLE `formularios`
	ADD COLUMN `eh_menu` int(11) NOT NULL DEFAULT '0'
	, ADD COLUMN `id_menu_pai` int(11) DEFAULT NULL;

ALTER TABLE `formularios`
	ADD COLUMN `css_menu` varchar(255) NOT NULL DEFAULT ''
	, ADD COLUMN `css_icone` varchar(255) NOT NULL DEFAULT '';

ALTER TABLE `formularios`
	ADD COLUMN `sequencia_menu` int(11) NOT NULL DEFAULT '0';

ALTER TABLE `formularios`
	ADD COLUMN `url_curta` varchar(255) NOT NULL DEFAULT '';

-- 27.03.2017
-- separei do cadastro de pessoas pois são menos campos e fica melhor de controlar
CREATE TABLE IF NOT EXISTS `adotante` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `nome` varchar(255) DEFAULT NULL,
  `sexo` varchar(1) NOT NULL COMMENT '//M -> Masculino // F -> Feminino',
  `rg` varchar(255) DEFAULT NULL,
  `cpf` varchar(255) DEFAULT NULL,
  `profissao` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `celular` varchar(255) DEFAULT NULL,
  `telefone` varchar(255) DEFAULT NULL,
  `outro_contato` varchar(255) DEFAULT NULL,
  `id_endereco` bigint(20) DEFAULT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_nascimento` datetime DEFAULT NULL,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `adotante_x_endereco` (
  `id_adotante` bigint(20) NOT NULL,
  `id_endereco` bigint(20) NOT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id_adotante`,`id_endereco`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


CREATE TABLE IF NOT EXISTS `adocao` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_animal` bigint(20) DEFAULT '0',
  `id_adotante` bigint(20) DEFAULT '0',
  `id_endereco_animal` bigint(20) DEFAULT '0',

  `data_adocao` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_desadocao` datetime DEFAULT NULL,

  `nome_original` varchar(255) NOT NULL DEFAULT '',
  `nome_salvo` varchar(255) NOT NULL DEFAULT '',
  `extensao` varchar(255) NOT NULL DEFAULT '',
  
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `adocao_anexos` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_animal` bigint(20) DEFAULT '0',
  `id_adocao` bigint(20) DEFAULT '0',
  `id_adotante` bigint(20) DEFAULT '0',
  
  `descricao` varchar(255) DEFAULT '',
  `nome_original` varchar(255) NOT NULL DEFAULT '',
  `nome_salvo` varchar(255) NOT NULL DEFAULT '',
  `extensao` varchar(255) NOT NULL DEFAULT '',
  
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


--- 28.03.2017
ALTER TABLE `exame`
	ADD COLUMN `anexo` varchar(255) NOT NULL DEFAULT '';

-- 29.03.2017
ALTER TABLE `vacina_x_animal`
	CHANGE COLUMN `id_vacina` `id_vacina` BIGINT NULL DEFAULT NULL;

ALTER TABLE `animal_medicamento`
	CHANGE COLUMN `id_medicamento` `id_medicamento` BIGINT NULL DEFAULT NULL;


CREATE TABLE IF NOT EXISTS `adocao_x_endereco` (
  `id_adocao` bigint(20) NOT NULL,
  `id_endereco` bigint(20) NOT NULL,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id_adocao`,`id_endereco`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 03.04.2017
ALTER TABLE `configuracoes`
  ADD COLUMN `alerta_dias_contato` int(11) DEFAULT '5';

-- 12.04.2017
CREATE TABLE IF NOT EXISTS `animal_medicamento_tratamento` (
  `id` int(11) NOT NULL,
  `nome` varchar(255) NOT NULL,
  `descricao` longtext,
  `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

ALTER TABLE `animal_medicamento`
	ADD COLUMN `id_tratamento` int(11) DEFAULT '0',
	ADD COLUMN `observacao` varchar(255) DEFAULT '';