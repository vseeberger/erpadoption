-- --------------------------------------------------------
-- Sistema:                     Sistema PetRescue
-- Versão:						1.0.0
-- Plataforma:					WEB
-- Linguagem:					ASP.NET C#
-- Framework					.NET 4.0
-- ########################################################
--			 SCRIPT DE INSERÇÃO DE REGISTROS
-- --------------------------------------------------------


INSERT INTO `perfil` (`id`, `nome`, `data_cadastro`, `data_ultalt`, `status`) VALUES
	(1, 'Default', '2016-12-16 12:59:25', '2016-12-16 12:59:26', 1);

INSERT INTO `usuario` (`id`, `sid`, `idpessoa`, `login`, `senha`, `email`, `idperfil`, `nome`, `data_cadastro`, `data_ultalt`, `data_ultimologin`, `status`) VALUES
	(1, 'ADM001', NULL, 'adm', '123', NULL, 1, 'Valter Furtado', '2016-12-16 13:00:20', '2016-12-16 13:00:20', '2000-01-01 00:00:00', 1);

INSERT INTO `especie` (`id`, `descricao`, `data_cadastro`, `data_ultalt`, `status`) VALUES
	(1, 'Canino', '2016-12-26 10:32:22', '2016-12-26 10:32:23', 1),
	(2, 'Felino', '2016-12-26 10:32:36', '2016-12-26 10:32:36', 1);


REPLACE INTO `vacina` (`id`, `id_fabricante`, `id_especie`, `nome`, `descricao`, `atencao`, `quantidade_dias_validade`, `quantidade_doses`, `quantidade_dias_entre_doses`, `data_cadastro`, `data_ultalt`, `status`) VALUES
	(1, 0, 1, 'V10', '- Cinomose\r\n- Hepatite Infecciosa Canina\r\n- Adenovirose\r\n- Coronavirose\r\n- Parainfluenza Canina\r\n- Parvovirose\r\n- Leptospirose canina', 'FILHOTES:\r\n6 a 8 semanas a primeira dose\r\n12 semanas a segunda dose\r\n16 semanas a terceira dose', 365, 1, 28, '2016-12-27 22:11:11', '2016-12-27 22:58:54', 1),
	(2, 0, 1, 'Anti-rábica', 'Vacina contra raiva.', 'Aplicar em animais com idade igual ou superior a 16 semanas,', 365, 1, 0, '2016-12-27 22:15:48', '2016-12-27 22:59:09', 1),
	(3, 0, 1, 'V8', '- Cinomose\r\n- Hepatite Infecciosa Canina\r\n- Adenovirose\r\n- Coronavirose\r\n- Parainfluenza Canina\r\n- Parvovirose\r\n- Leptospirose canina', 'FILHOTES:\r\n6 a 8 semanas a primeira dose\r\n12 semanas a segunda dose\r\n16 semanas a terceira dose', 365, 1, 28, '2016-12-27 22:17:33', '2016-12-27 22:59:16', 1),
	(6, 0, 1, 'Gripe Canina', 'Adenovirus Canino Tipo 2, Parainfluenza Canina e Bordetella bronchiseptica', 'FILHOTES:\r\nPrimeira dose com 12 semanas\r\nSegunda dose com 16 semanas', 365, 1, 28, '2016-12-27 22:54:59', '2016-12-27 22:59:26', 1),
	(7, 0, 1, 'Giardíase', 'Indicada para animais que vivem em grupos como canis, criadores ou locais com muitos cães que vivem em abientes mais úmido.', 'FILHOTES:\r\nPrimeira dose com 12 semanas\r\nReforço 15 dias depois.', 365, 1, 15, '2016-12-27 22:56:05', '2016-12-27 23:03:52', 1);

REPLACE INTO `porte` (`id`, `descricao`, `sigla`, `data_cadastro`, `data_ultalt`, `status`) VALUES
	(1, 'Mini', 'MN', '2016-12-28 07:33:07', '2016-12-28 07:33:07', 1),
	(2, 'Pequeno', 'P', '2016-12-28 07:33:20', '2016-12-28 07:33:21', 1),
	(3, 'Médio', 'M', '2016-12-28 07:33:33', '2016-12-28 07:33:36', 1),
	(4, 'Grande', 'G', '2016-12-28 07:33:46', '2016-12-28 07:33:46', 1),
	(5, 'Gigante', 'GG', '2016-12-28 07:34:01', '2016-12-28 07:34:04', 1);

INSERT INTO `medicamento_grupo` (`id`, `descricao`, `data_cadastro`, `data_ultalt`, `status`) VALUES
	(1, 'OUTROS', '2016-12-30 16:24:39', '2016-12-30 16:24:39', 1),
	(2, 'GENERICO', '2016-12-28 12:12:07', '2016-12-28 12:12:07', 1),
	(3, 'SIMILAR', '2016-12-28 12:12:07', '2016-12-28 12:12:07', 1),
	(4, 'OTC/MIP', '2016-12-28 12:12:07', '2016-12-28 12:12:07', 1),
	(5, 'PERFUMARIA/HIGIENE/COSMÉTICOS', '2016-12-28 12:12:07', '2016-12-28 12:12:07', 1),
	(13, 'SEM GRUPO', '2016-12-28 12:12:07', '2016-12-28 12:12:07', 1),
	(15, 'ANTIMICROBIANOS', '2016-12-28 12:12:07', '2016-12-28 12:12:07', 1),
	(18, 'ALIMENTOS', '2016-12-28 12:12:07', '2016-12-28 12:12:07', 1);



INSERT INTO `conta_bancaria_tipo` (`descricao`) VALUES
	('Conta corrente'),
	('Poupança'),
	('Carteira'),
	('Caixa'),
	('Investimento'),
	('Outros'),
	('Cartão de Crédito');

INSERT INTO `origem_de_custos_lucro` (`id`, `id_origem_de_custos_lucro`, `descricao`, `data_cadastro`, `data_ultalt`, `status`, `entrada_saida`, `classificacao`) VALUES
	(1, NULL, 'Receitas operacionais', '2017-02-03 17:19:40', '2017-02-03 17:19:40', 1, 'E', 'R'),
	(2, 1, 'Receita - Doação Mensal', '2017-02-03 17:19:40', '2017-02-03 17:19:40', 1, 'E', 'R'),
	(3, 1, 'Receita com serviços', '2017-02-03 17:19:40', '2017-02-03 17:19:40', 1, 'E', 'R'),
	(4, 1, 'Receita com vendas', '2017-02-03 17:19:40', '2017-02-03 17:19:40', 1, 'E', 'R'),
	(5, NULL, 'Custos operacionais', '2017-02-03 17:20:54', '2017-02-03 17:20:54', 1, 'S', 'D'),
	(6, 5, 'Custo serviço prestado', '2017-02-03 17:20:54', '2017-02-03 17:20:54', 1, 'S', 'D'),
	(7, 5, 'Custos produto vendido', '2017-02-03 17:20:54', '2017-02-03 17:20:54', 1, 'S', 'DV'),
	(8, 5, 'Impostos sobre receita', '2017-02-03 17:20:54', '2017-02-03 17:20:54', 1, 'S', 'DV'),
	(9, NULL, 'Despesas operacionais e outras receitas', '2017-02-03 17:22:10', '2017-02-03 17:22:10', 1, 'S', 'D'),
	(10, 9, 'Aluguel e condomínio', '2017-02-03 17:22:10', '2017-02-03 17:22:10', 1, 'S', 'DF'),
	(11, 9, 'Despesas financeiras', '2017-02-03 17:22:10', '2017-02-03 17:22:10', 1, 'S', 'D'),
	(12, 9, 'Luz, água e outros', '2017-02-03 17:22:10', '2017-02-03 17:22:10', 1, 'S', 'DF'),
	(13, 9, 'Material de escritório', '2017-02-03 17:22:10', '2017-02-03 17:22:10', 1, 'S', 'DV'),
	(14, NULL, 'Outras despesas', '2017-02-03 17:22:10', '2017-02-03 17:22:10', 1, 'S', 'D'),
	(16, 9, 'Salários, encargos e benefícios', '2017-02-03 17:22:10', '2017-02-03 17:22:10', 1, 'S', 'DP'),
	(17, 9, 'Serviços contratados', '2017-02-03 17:22:10', '2017-02-03 17:22:10', 1, 'S', 'D'),
	(18, 9, 'Taxas e contribuições', '2017-02-03 17:22:10', '2017-02-03 17:22:10', 1, 'S', 'D'),
	(19, NULL, 'Atividades de financiamento', '2017-02-03 17:22:10', '2017-02-03 17:22:10', 1, 'S', 'DR'),
	(20, 19, 'Aporte de capital', '2017-02-03 17:22:10', '2017-02-03 17:22:10', 1, 'E', 'R'),
	(21, 19, 'Obtenção de empréstimo', '2017-02-03 17:22:10', '2017-02-03 17:22:10', 1, 'E', 'R'),
	(22, 19, 'Pagamento de empréstimo', '2017-02-03 17:22:10', '2017-02-03 17:22:10', 1, 'S', 'D'),
	(23, 19, 'Retirada de capital', '2017-02-03 17:22:10', '2017-02-03 17:22:10', 1, 'S', 'D');


INSERT INTO `formas_pagamento_recebimento` (`id`, `descricao`) VALUES
(1, 'Dinheiro'),
(2, 'Cheque'),
(3, 'Boleto bancário'),
(4, 'Cartão de crédito'),
(5, 'Transferência bancária'),
(6, 'Promissória'),
(7, 'Cartão de débito'),
(8, 'Débito automático');

INSERT INTO `formas_pagamento_recebimento` (`id`, `descricao`) VALUES
(9, 'Débito em conta');

INSERT INTO `formularios` (`id`, `nome`, `path`, `grupo`) VALUES
	(40, 'Movimentações Financeiras', 'pesquisa_de_movimentacoes.aspx', 40),
	(41, 'Financeiro: Conta a pagar', 'cadastro_de_conta_pagar.aspx', 40),
	(42, 'Financeiro: Conta a receber', 'cadastro_de_conta_receber.aspx', 40);


INSERT INTO `formularios` (`id`, `nome`, `path`, `grupo`) VALUES
	(50, 'Cadastro de fornecedor', 'cadastro_de_fornecedor.aspx', 50),
	(51, 'Pesquisa de fornecedor', 'pesquisa_de_fornecedores.aspx', 50);

-- 22.02.2017
INSERT INTO `formularios` (`id`, `nome`, `path`, `grupo`) VALUES
	(60, 'Cadastro de Escala', 'cadastro_de_escala.aspx', 60),
	(61, 'Cadastro de Escala em lote', 'cadastro_de_escala_lote.aspx', 60);

-- 01.03.2017
INSERT INTO `log_acao` (`id`, `descricao`, `texto`) VALUES
	(1, 'INSERIR', 'INSERIU')
	, (2, 'ALTERAR', 'ALTEROU')
	, (3, 'EXCLUIR', 'EXCLUIU')
	, (4, 'ACESSAR', 'ACESSOU')
	, (5, 'ESPECIAL', 'PERMISSÃO ESPECIAL');

INSERT INTO `formularios` (`id`, `nome`, `path`, `grupo`) VALUES
	(990, 'Log de acessos', 'Log.aspx', 990),
	(999, 'LOGAR - ACESSO AO SISTEMA', 'Logar.aspx', 990);

-- 02.03.2017
INSERT INTO beneficio_desconto (id, descricao, valor_maximo, percentual_salario) VALUES
	  (1, 'Plano de saúde', 0, 0)
	, (2, 'Alimentação', 0, '20')
	, (3, 'Transporte', '0', '6');

-- 06.03.2017
INSERT INTO grau_parentesco (id, descricao) VALUES 
	  (1, 'PAI')	, (2, 'MÃE')	, (3, 'CÔNJUGE')	, (4, 'IRMÃO')
	, (5, 'IRMÃ')	, (6, 'FILHO')	, (7, 'FILHA')	, (8, 'AVÓ')
	, (9, 'AVÔ')	, (10, 'TIO')	, (11, 'TIA')	, (12, 'SOBRINHO')
	, (13, 'SOBRINHA')	, (14, 'PRIMO')	, (15, 'PRIMA')	, (16, 'ENTEADO')
	, (17, 'ENTEADA')	, (18, 'SOGRO')	, (19, 'SOGRA')	, (20, 'CUNHADO')
	, (21, 'CUNHADA')	, (22, 'NETO')	, (23, 'NETA')	, (24, 'BISNESTO')
	, (25, 'BISNESTA')	, (26, 'BISAVÓ')	, (27, 'BISAVÔ')	, (28, 'GENRO')
	, (29, 'NORA');

INSERT INTO `formularios` (`id`, `nome`, `path`, `grupo`) VALUES
	(70, 'Cadastro de benefício', 'cadastro_de_beneficio.aspx', 70),
	(71, 'Pesquisa de benefício', 'pesquisa_de_beneficios.aspx', 70);

-- 07.03.2017
INSERT INTO `formularios` (`id`, `nome`, `path`, `grupo`) VALUES
	(80, 'Cadastro de grau de parentesco', 'cadastro_de_grau_parentesco.aspx', 80),
	(81, 'Pesquisa de grau de parentesco', 'pesquisa_de_graus_parentesco.aspx', 80);

INSERT INTO `formularios` (`id`, `nome`, `path`, `grupo`) VALUES
	(90, 'Cadastro de grau de parentesco', 'cadastro_de_cargo_cbo.aspx', 90),
	(91, 'Pesquisa de grau de parentesco', 'pesquisa_de_cargos_cbo.aspx', 90);

INSERT INTO `formularios` (`id`, `nome`, `path`, `grupo`) VALUES
	(100, 'Cadastro de cargo', 'cadastro_de_cargo.aspx', 100),
	(101, 'Pesquisa de cargos', 'pesquisa_de_cargos.aspx', 100);

TRUNCATE TABLE cbo_cargos_funcoes;
INSERT INTO `cbo_cargos_funcoes` (`cbo`, `descricao`, `complemento`, `versao`) VALUES
('6230.05','ADESTRADOR DE ANIMAIS','OCUPAÇÃO','CBO2002'),
('5193.15','BANHISTA DE ANIMAIS DOMÉSTICOS','OCUPAÇÃO','CBO2002'),
('7828.05','CONDUTOR DE VEÍCULOS DE TRAÇAO ANIMAL (RUAS E ESTRADAS)','OCUPAÇÃO','CBO2002'),
('6130.10','CRIADOR DE ANIMAIS DOMÉSTICOS','OCUPAÇÃO','CBO2002'),
('6134.10','CRIADOR DE ANIMAIS PRODUTORES DE VENENO','OCUPAÇÃO','CBO2002'),
('3762.25','DOMADOR DE ANIMAIS (CIRCENSE)','OCUPAÇÃO','CBO2002'),
('5193.10','ESTETICISTA DE ANIMAIS DOMÉSTICOS','OCUPAÇÃO','CBO2002'),
('2030.10','PESQUISADOR EM BIOLOGIA ANIMAL','OCUPAÇÃO','CBO2002'),
('5193.20','TOSADOR DE ANIMAIS DOMÉSTICOS','OCUPAÇÃO','CBO2002'),
('6234.05','TRABALHADOR EM CRIATÓRIOS DE ANIMAIS PRODUTORES DE VENENO','OCUPAÇÃO','CBO2002'),
('6230.20','TRATADOR DE ANIMAIS','OCUPAÇÃO','CBO2002'),
('5193','TRABALHADORES DE SERVIÇOS VETERINÁRIOS, DE HIGIENE E ESTÉTICA DE ANIMAIS DOMÉSTICOS','FAMÍLIA','CBO2002'),
('6131','PRODUTORES EM PECUÁRIA DE ANIMAIS DE GRANDE PORTE','FAMÍLIA','CBO2002'),
('6132','PRODUTORES EM PECUÁRIA DE ANIMAIS DE MÉDIO PORTE','FAMÍLIA','CBO2002'),
('6134','PRODUTORES DE ANIMAIS E INSETOS ÚTEIS','FAMÍLIA','CBO2002'),
('6230','TRATADORES POLIVALENTES DE ANIMAIS','FAMÍLIA','CBO2002'),
('6231','TRABALHADORES NA PECUÁRIA DE ANIMAIS DE GRANDE PORTE','FAMÍLIA','CBO2002'),
('6232','TRABALHADORES NA PECUÁRIA DE ANIMAIS DE MÉDIO PORTE','FAMÍLIA','CBO2002'),
('6234','TRABALHADORES NA CRIAÇAO DE INSETOS E ANIMAIS ÚTEIS','FAMÍLIA','CBO2002'),
('6313','CRIADORES DE ANIMAIS AQUÁTICOS','FAMÍLIA','CBO2002'),
('7828','CONDUTORES DE ANIMAIS E DE VEÍCULOS DE TRAÇAO ANIMAL E PEDAIS','FAMÍLIA','CBO2002'),
('3184.10','DESENHISTA DE DESENHO ANIMADO','SINÔNIMO','CBO2002'),
('3201.05','TÉCNICO EM CRIAÇÃO DE ANIMAIS DE LABORATÓRIO','SINÔNIMO','CBO2002'),
('1414.10','LOCADOR DE ANIMAIS PARA LAZER','SINÔNIMO','CBO2002'),
('3762.25','TREINADOR DE ANIMAIS (CIRCENSE)','SINÔNIMO','CBO2002'),
('3763.15','ANIMADOR DE RÁDIO','SINÔNIMO','CBO2002'),
('3763.15','APRESENTADOR ANIMADOR DE PROGRAMAS DE RÁDIO','SINÔNIMO','CBO2002'),
('3763.20','ANIMADOR DE TELEVISÃO','SINÔNIMO','CBO2002'),
('3763.20','APRESENTADOR ANIMADOR DE PROGRAMAS DE TELEVISÃO','SINÔNIMO','CBO2002'),
('3763.25','ANIMADOR DE CIRCO','SINÔNIMO','CBO2002'),
('3763.25','APRESENTADOR ANIMADOR DE CIRCO','SINÔNIMO','CBO2002'),
('3763.10','ANIMADOR DE FESTAS POPULARES','SINÔNIMO','CBO2002'),
('3763.10','APRESENTADOR ANIMADOR DE FESTAS POPULARES','SINÔNIMO','CBO2002'),
('3763.05','ANIMADOR DE EVENTOS','SINÔNIMO','CBO2002'),
('3763.05','APRESENTADOR ANIMADOR DE EVENTOS','SINÔNIMO','CBO2002'),
('6130.10','CRIADOR DE PEQUENOS ANIMAIS','SINÔNIMO','CBO2002'),
('6130.10','SÓCIO- PROPRIETÁRIO - NA CRIAÇÃO DE PEQUENOS ANIMAIS - EMPREGADOR','SINÔNIMO','CBO2002'),
('6210.05','CURADOR DE ANIMAIS - NA AGROPECUÁRIA','SINÔNIMO','CBO2002'),
('6210.05','PEGADOR DE ANIMAIS - NA AGROPECUÁRIA','SINÔNIMO','CBO2002'),
('6230.10','INSEMINADOR DE ANIMAIS','SINÔNIMO','CBO2002'),
('6230.05','EDUCADOR DE ANIMAIS','SINÔNIMO','CBO2002'),
('6230.05','CONDICIONADOR DE ANIMAIS','SINÔNIMO','CBO2002'),
('6230.05','DOMADOR DE ANIMAIS DOMÉSTICOS','SINÔNIMO','CBO2002'),
('6230.05','TREINADOR DE ANIMAIS DOMÉSTICOS','SINÔNIMO','CBO2002'),
('6230.05','INSTRUTOR DE ANIMAIS','SINÔNIMO','CBO2002'),
('6230.20','TRATADOR DE ANIMAIS - NA PECUÁRIA','SINÔNIMO','CBO2002'),
('6230.20','TRATADOR DE ANIMAIS (JARDIM ZOOLÓGICO)','SINÔNIMO','CBO2002'),
('6230.20','CUIDADOR DE ANIMAIS','SINÔNIMO','CBO2002'),
('6231.25','FERRADOR DE ANIMAIS (EQÜINOS)','SINÔNIMO','CBO2002'),
('6231.05','FERRADOR DE ANIMAIS (ASININOS E MUARES)','SINÔNIMO','CBO2002'),
('6231.05','ADESTRADOR DE ANIMAIS DE TRABALHO ( ASININOS E MUARES)','SINÔNIMO','CBO2002'),
('6232.05','TRATADOR DE ANIMAIS - CAPRINOS','SINÔNIMO','CBO2002'),
('7683.25','CORREEIRO (PEÇAS PARA ANIMAIS)','SINÔNIMO','CBO2002');

-- 20.03.2017
TRUNCATE TABLE estoque_tipo_movimentacao;
INSERT INTO estoque_tipo_movimentacao (id, descricao) VALUES
	  ('INV', 'ATUALIZAÇÃO DE ESTOQUE ATRAVÉS DE INVENTÁRIO')
	, ('ALM', 'ATUALIZAÇÃO DE ESTOQUE UTILIZANDO A TELA DE ALMOXARIFADO');
	, ('MOV', 'MOVIMENTAÇÃO DE ESTOQUE');
	, ('COM', 'ATUALIZAÇÃO DE ESTOQUE ATRAVÉS DE COMPRA DE PRODUTOS');

	
-- 24.03.2017
TRUNCATE TABLE `formularios`;

INSERT INTO `formularios` (`id`, `nome`, `path`, `data_cadastro`, `data_ultalt`, `status`, `grupo`, `eh_menu`, `id_menu_pai`, `css_menu`, `css_icone`, `sequencia_menu`, `url_curta`) VALUES
	(1, 'Cadastro de formulário', 'cadastro_de_formulario.aspx', '2017-01-27 15:19:18', '2017-01-27 15:19:18', 1, 10, 0, NULL, '', '', 0, 'CadastroDeFormulario'),
	(2, 'Formulários', 'pesquisa_de_formularios.aspx', '2017-01-27 15:23:27', '2017-03-23 16:32:53', 1, 10, 1, 1005, '', '', 1501, 'TodosOsFormularios'),

	(10, 'Cadastro de animal', 'cadastro_de_animal.aspx', '2017-01-27 15:19:44', '2017-01-27 15:19:44', 1, 20, 0, NULL, '', '', 0, 'CadastroDeAnimal'),
	(11, 'Animais', 'pesquisa_de_animais.aspx', '2017-01-27 15:22:50', '2017-03-23 18:00:28', 1, 20, 1, 0, 'green-dark', 'fa fa-paw', 1, 'TodosOsAnimais'),

	(20, 'Cadastro de clínica', 'cadastro_de_clinica.aspx', '2017-01-27 15:19:58', '2017-01-27 15:19:58', 1, 30, 0, NULL, '', '', 0, 'CadastroDeClinica'),
	(21, 'Clinicas', 'pesquisa_de_clinicias.aspx', '2017-01-27 15:23:04', '2017-01-27 15:23:04', 1, 30, 1, 1001, '', '', 1000, 'TodasAsClinicas'),

	(30, 'Cadastro de contato', 'cadastro_de_contato.aspx', '2017-01-27 15:20:11', '2017-01-27 15:20:11', 1, 40, 0, NULL, '', '', 0, 'CadastroDeContato'),
	(31, 'Contatos', 'pesquisa_de_contatos.aspx', '2017-01-27 15:23:15', '2017-03-23 16:48:32', 1, 40, 1, 1000, '', '', 900, 'TodosOsContatos'),

	(40, 'Cadastro de fabricante', 'cadastro_de_laboratorio.aspx', '2017-01-27 15:20:26', '2017-01-27 15:20:26', 1, 50, 0, NULL, '', '', 0, 'CadastroDeLaboratorio'),
	(41, 'Fabricantes', 'pesquisa_de_laboratorios.aspx', '2017-01-27 15:23:42', '2017-01-27 15:23:42', 1, 50, 1, 1001, '', '', 1001, 'TodosOsLaboratorios'),

	(50, 'Cadastro de perfil', 'cadastro_de_perfil.aspx', '2017-01-27 15:20:50', '2017-01-27 15:20:50', 1, 60, 0, NULL, '', '', 0, 'CadastroDePerfil'),
	(51, 'Perfil', 'pesquisa_de_perfis.aspx', '2017-01-27 15:24:40', '2017-03-23 16:32:36', 1, 60, 1, 1005, '', '', 1503, 'TodosOsPerfis'),

	(60, 'Cadastro de principio ativo', 'cadastro_de_principioativo.aspx', '2017-01-27 15:21:03', '2017-01-27 15:21:03', 1, 70, 0, NULL, '', '', 0, 'CadastroDePrincipioAtivo'),
	(61, 'Princípio ativo', 'pesquisa_de_principioativo.aspx', '2017-01-27 15:24:53', '2017-03-23 16:48:19', 1, 70, 1, 1000, '', '', 903, 'TodosPrincipioAtivo'),

	(70, 'Cadastro de raças', 'cadastro_de_racas.aspx', '2017-01-27 15:21:16', '2017-01-27 15:21:16', 1, 80, 0, NULL, '', '', 0, 'CadastroDeRaca'),
	(71, 'Raças', 'pesquisa_de_racas.aspx', '2017-01-27 15:25:49', '2017-03-23 16:47:53', 1, 80, 1, 1000, '', '', 904, 'TodasAsRacas'),

	(80, 'Cadastro de padrinho', 'cadastro_de_responsavel.aspx', '2017-01-27 15:21:28', '2017-01-27 15:21:28', 1, 90, 0, NULL, '', '', 0, 'CadastroDePadrinho'),
	(81, 'Padrinhos', 'pesquisa_de_responsaveis.aspx', '2017-01-27 15:25:59', '2017-01-27 15:25:59', 1, 90, 1, 1002, '', '', 1100, 'TodosOsPadrinhos'),

	(90, 'Cadastro de usuário', 'cadastro_de_usuario.aspx', '2017-01-27 15:21:39', '2017-01-27 15:21:39', 1, 100, 0, NULL, '', '', 0, 'CadastroDeUsuario'),
	(91, 'Usuários', 'pesquisa_de_usuarios.aspx', '2017-01-27 15:26:09', '2017-03-23 16:27:41', 1, 100, 1, 1005, '', '', 1504, 'TodosOsUsuarios'),

	(100, 'Cadastro de veterinario', 'cadastro_de_veterinario.aspx', '2017-01-27 15:22:05', '2017-01-27 15:22:05', 1, 110, 0, NULL, '', '', 0, 'CadastroDeVeterinario'),
	(101, 'Veterinários', 'pesquisa_de_veterinarios.aspx', '2017-01-27 15:26:34', '2017-01-27 15:26:34', 1, 110, 1, 1002, '', '', 1101, 'TodosOsVeterinarios'),

	(110, 'Cadastro de agendamento', 'cadastro_medicamento_animal.aspx', '2017-01-27 15:22:22', '2017-01-27 15:22:22', 1, 120, 0, NULL, '', '', 0, 'AgendarMedicamento'),
	(111, 'Agendamentos', 'pesquisa_de_medicamento_animal.aspx', '2017-01-27 15:24:01', '2017-03-23 18:03:46', 1, 120, 1, 0, 'green-dark', 'font-icon font-icon-post', 2, 'TodosOsAgendamentos'),
	
	(120, 'Cadastro de fornecedor', 'cadastro_de_fornecedor.aspx', '2017-02-16 17:49:49', '2017-02-16 17:49:49', 1, 130, 0, NULL, '', '', 0, 'CadastroDeFornecedor'),
	(121, 'Fornecedores', 'pesquisa_de_fornecedores.aspx', '2017-02-16 17:49:49', '2017-02-16 17:49:49', 1, 130, 1, 1001, '', '', 1002, 'TodosOsFornecedores'),
	
	(130, 'Cadastro de Escala em lote', 'cadastro_de_escala_lote.aspx', '2017-02-22 11:37:52', '2017-02-22 11:37:52', 1, 140, 0, NULL, '', '', 0, 'CadastroDeEscalaEmLote'),
	(131, 'Escalas', 'cadastro_de_escala.aspx', '2017-02-22 11:37:52', '2017-03-23 18:05:04', 1, 140, 1, 1004, 'blue-sky', 'font-icon font-icon-calend', 3, 'Escalas'),
	
	(140, 'Cadastro de benefício', 'cadastro_de_beneficio.aspx', '2017-03-07 15:45:34', '2017-03-07 15:45:34', 1, 150, 0, NULL, '', '', 0, 'CadastroDeBeneficio'),
	(141, 'Benefícios', 'pesquisa_de_beneficios.aspx', '2017-03-07 15:45:34', '2017-03-23 16:36:17', 1, 150, 1, 1004, '', '', 1400, 'TodosOsBeneficios'),
	
	(150, 'Cadastro de grau de parentesco', 'cadastro_de_grau_parentesco.aspx', '2017-03-07 15:45:35', '2017-03-23 16:35:25', 0, 160, 0, NULL, '', '', 0, 'CadastroDeGrauDeParentesco'),
	(151, 'Grau de parentesco', 'pesquisa_de_graus_parentesco.aspx', '2017-03-07 15:45:35', '2017-03-23 16:35:34', 0, 160, 1, 1004, '', '', 1403, 'TodosOsParentescos'),
	
	(160, 'Cadastro de CBO', 'cadastro_de_cargo_cbo.aspx', '2017-03-07 15:45:35', '2017-03-07 15:45:35', 1, 170, 0, NULL, '', '', 0, 'CadastroDeCBO'),
	(161, 'CBO', 'pesquisa_de_cargos_cbo.aspx', '2017-03-07 15:45:35', '2017-03-23 16:35:47', 1, 170, 1, 1004, '', '', 1402, 'TodosOsCBOs'),
	
	(170, 'Cadastro de cargo', 'cadastro_de_cargo.aspx', '2017-03-07 15:45:35', '2017-03-07 15:45:35', 1, 180, 0, NULL, '', '', 0, 'CadastroDeCargo'),
	(171, 'Cargos', 'pesquisa_de_cargos.aspx', '2017-03-07 15:45:35', '2017-03-23 16:34:09', 1, 180, 1, 1004, '', '', 1401, 'TodosOsCargos'),
	
	(180, 'Cadastro de marca', 'cadastro_de_marca.aspx', '2017-03-23 17:00:08', '2017-03-23 17:00:08', 1, 190, 0, 0, '', '', 0, 'CadastroDeMarca'),
	(181, 'Marcas', 'pesquisa_de_marcas.aspx', '2017-03-23 17:00:30', '2017-03-23 17:00:30', 1, 1000, 1, 190, '', '', 902, 'TodasAsMarcas'),
	
	(190, 'Cadastro de produto', 'cadastro_de_produto.aspx', '2017-03-23 18:05:47', '2017-03-23 18:05:47', 1, 200, 0, 0, 'blue-sky', 'fa fa-connectdevelop', 4, 'CadastroDeProduto'),
	(191, 'Produtos', 'pesquisa_de_produtos.aspx', '2017-03-23 18:05:47', '2017-03-23 18:05:47', 1, 200, 1, 0, 'blue-sky', 'fa fa-connectdevelop', 4, 'TodosOsProdutos'),
	
	(200, 'Cadastro de conta', 'cadastro_de_conta.aspx', '2017-03-24 15:28:23', '2017-03-24 15:28:23', 1, 210, 0, 1003, '', '', 1201, 'CadastroDeConta'),
	(201, 'Contas', 'pesquisa_de_contas.aspx', '2017-03-24 15:28:23', '2017-03-24 15:28:23', 1, 210, 1, 1003, '', '', 1201, 'TodasAsContas'),
	
	(210, 'Cadastro de centro de custos', 'cadastro_de_centro_de_custos.aspx', '2017-03-24 15:28:58', '2017-03-24 15:28:58', 1, 220, 0, 1003, '', '', 1200, 'CadastroDeCentroDeCusto'),
	(211, 'Centro de Custos', 'pesquisa_de_centro_de_custos.aspx', '2017-03-24 15:28:58', '2017-03-24 15:28:58', 1, 220, 1, 1003, '', '', 1200, 'TodosOsCentrosDeCustos'),
	
	(220, 'Cadastro de colaborador', 'cadastro_de_colaborador.aspx', '2017-03-24 15:30:06', '2017-03-24 15:30:06', 1, 230, 0, 1004, '', '', 1300, 'CadastroDeColaborador'),
	(221, 'Colaboradores', 'pesquisa_de_colaboradores.aspx', '2017-03-24 15:30:06', '2017-03-24 15:30:06', 1, 230, 1, 1004, '', '', 1300, 'TodosOsColaboradores'),

	(230, 'Configurações', 'configuracoes.aspx', '2017-02-02 17:19:13', '2017-03-23 16:33:20', 1, 240, 1, 1005, '', '', 1500, 'Configuracoes'),
	(240, 'Financeiro', 'pesquisa_de_movimentacoes.aspx', '2017-02-15 16:21:59', '2017-03-23 16:36:59', 1, 240, 1, 1003, '', '', 1202, 'TodasAsMovimentacoes'),
	(241, 'Financeiro: Conta a pagar', 'cadastro_de_conta_pagar.aspx', '2017-02-15 16:21:59', '2017-02-15 16:21:59', 1, 240, 0, NULL, '', '', 0, 'CadastroDeContasAPagar'),
	(242, 'Financeiro: Conta a receber', 'cadastro_de_conta_receber.aspx', '2017-02-15 16:21:59', '2017-02-15 16:21:59', 1, 240, 0, NULL, '', '', 0, 'CadastroDeContasAReceber'),
	(250, 'Log de acessos', 'Log.aspx', '2017-03-01 17:58:07', '2017-03-23 16:33:07', 1, 240, 1, 1005, '', '', 1502, 'LogsDeAcesso'),
	(260, 'Estoque', 'estoque_consulta.aspx', '2017-03-24 15:14:33', '2017-03-24 15:14:33', 1, 240, 1, 0, 'green-dark', 'glyphicon glyphicon-retweet', 5, 'EstoqueProduto'),
	(261, 'Almoxarifado', 'estoque_almoxarifado.aspx', '2017-03-24 15:15:41', '2017-03-24 15:15:41', 1, 240, 1, 0, 'blue-dirty', 'glyphicon glyphicon-transfer', 6, 'Almoxarifado'),
	(262, 'Inventários', 'estoque_inventarios.aspx', '2017-03-24 15:20:44', '2017-03-24 15:20:44', 1, 240, 1, 1000, '', '', 901, 'TodosOsInventarios'),
	
	(270, 'LOGAR', 'Logar.aspx', '2017-03-01 16:49:08', '2017-03-01 16:49:08', 1, 240, 0, NULL, '', '', 0, ''),

	(280, 'Adotantes', 'pesquisa_de_adotantes.aspx', '2017-03-24 15:20:44', '2017-03-24 15:20:44', 1, 280, 1, 0, '', '', 7, 'TodosOsAdotantes'),
	(281, 'Cadastro de adotante', 'cadastro_de_adotante.aspx', '2017-03-24 15:20:44', '2017-03-24 15:20:44', 1, 280, 0, 0, '', '', 0, 'CadastroDeAdotante'),

	(1000, 'Basicos', '', '2017-03-23 16:13:58', '2017-03-23 16:24:14', 1, 250, 1, 0, 'red', 'font-icon glyphicon glyphicon-bell', 70, ''),
	(1001, 'Empresas', '', '2017-03-23 16:14:09', '2017-03-23 16:24:33', 1, 250, 1, 0, 'blue', 'font-icon glyphicon glyphicon-globe', 80, ''),
	(1002, 'Pessoas', '', '2017-03-23 16:14:23', '2017-03-23 16:24:47', 1, 250, 1, 0, 'green', 'font-icon glyphicon glyphicon-user', 90, ''),
	(1003, 'Contábil', '', '2017-03-23 16:25:41', '2017-03-23 16:25:41', 1, 250, 1, 0, 'grey', 'font-icon fa fa-money', 100, ''),
	(1004, 'Dpto. Pessoal', '', '2017-03-23 16:26:07', '2017-03-23 16:26:07', 1, 250, 1, 0, 'green', 'fa fa-group', 110, ''),
	(1005, 'Configurações', '', '2017-03-23 16:26:56', '2017-03-23 16:26:56', 1, 250, 1, 0, 'brown', 'font-icon glyphicon glyphicon-adjust', 120, '');
