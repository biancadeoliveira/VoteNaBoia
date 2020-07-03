CREATE DATABASE VoteNaBoia
GO

use VoteNaBoia
GO

CREATE TABLE Alunos(
	 ID_Aluno		Integer		 NOT NULL Identity(1,1) PRIMARY KEY
	,NM_Aluno		Varchar(100) NOT NULL
	,Email			Varchar(255) NOT NULL
	,Senha			Varchar(255) NOT NULL
	,SN_Envia_Email Char(1) DEFAULT('S') 
	,SN_Ativo		Char(1) DEFAULT('S')
	,CONSTRAINT chk_alunos_sn_envia_email CHECK (SN_Envia_Email IN ('S', 'N'))
	,CONSTRAINT chk_alunos_sn_ativo CHECK (SN_Ativo IN ('S', 'N')))
GO

CREATE TABLE Turmas(
	 ID_Turma	Integer		 NOT NULL Identity(1,1) PRIMARY KEY
	,NM_Turma	Varchar(255) NOT NULL
	,CD_Turma	Integer		 NOT NULL Unique 
	,DT_Criacao Datetime	 NOT NULL)
GO

CREATE TABLE Turma_Aluno(
	 ID_Turma_Aluno	INTEGER  NOT NULL Identity(1,1) PRIMARY KEY
	,ID_Aluno		INTEGER  NOT NULL
	,ID_Turma		INTEGER  NOT NULL
	,DT_Vinculo		DATETIME NOT NULL
	,SN_Aprovado	CHAR(1)  NOT NULL DEFAULT('N')
	,SN_Moderador	CHAR(1)  NOT NULL DEFAULT('N')
	,CONSTRAINT chk_turma_alunos_sn_aprovado CHECK (SN_Aprovado IN ('S', 'N'))
	,CONSTRAINT chk_turma_alunos_sn_moderador CHECK (SN_Moderador IN ('S', 'N'))
    ,CONSTRAINT fk_turma_aluno_alunos FOREIGN KEY (ID_Aluno) REFERENCES Alunos (ID_Aluno)	
	,CONSTRAINT fk_turma_aluno_turmas FOREIGN KEY (ID_Turma) REFERENCES Turmas (ID_Turma))
GO

CREATE TABLE Restaurantes(
	 ID_Restaurante	Integer		 NOT NULL Identity(1,1) PRIMARY KEY
	,ID_Turma		Integer		 NOT NULL
	,NM_Restaurante Varchar(100) NOT NULL
	,NM_Tipo		Varchar(100) NOT NULL
	,Endereco		Varchar(255) NOT NULL
	,NO_Telefone	Varchar(12)
	,Link			Varchar(255)
	,Email			Varchar(255)
	,SN_Ativo		Char(1)		 NOT NULL DEFAULT('S')
	,CONSTRAINT chk_restaurantes_sn_ativo CHECK (SN_Ativo IN ('S', 'N'))
	,CONSTRAINT fk_restaurantes_turmas FOREIGN KEY (ID_Turma) REFERENCES Turmas (ID_Turma))
GO

CREATE TABLE Avaliacoes(
	 ID_Avaliacao	Integer NOT NULL Identity(1,1) PRIMARY KEY
	,ID_Restaurante Integer NOT NULL
	,ID_Turma_Aluno Integer NOT NULL
	,Nota			Integer NOT NULL
	,CONSTRAINT chk_avaliacoes_nota CHECK (Nota >= 1 AND Nota <= 5)
	,CONSTRAINT fk_avaliacoes_restaurantes FOREIGN KEY (ID_Restaurante) REFERENCES Restaurantes (ID_Restaurante)
	,CONSTRAINT fk_avaliacoes_turma_aluno FOREIGN KEY (ID_Turma_Aluno) REFERENCES Turma_Aluno (ID_Turma_Aluno))
GO

CREATE TABLE Formas_Pagamento(
	 ID_Forma_Pagamento Integer NOT NULL Identity(1,1) PRIMARY KEY
	,NM_Forma_Pagamento Varchar(30) NOT NULL
)
GO

CREATE TABLE Pagamento_Restaurante(
	 ID_Pagamento_Restaurante Integer NOT NULL Identity(1,1) PRIMARY KEY
	,ID_Restaurante	Integer	NOT NULL
	,ID_Forma_Pagamento Integer NOT NULL
	,CONSTRAINT fk_pagamento_restaurante_restaurante FOREIGN KEY (ID_Restaurante) REFERENCES Restaurantes (ID_Restaurante)
	,CONSTRAINT fk_pagamento_restaurante_forma_pagamento FOREIGN KEY (ID_Forma_Pagamento) REFERENCES Formas_Pagamento (ID_Forma_Pagamento)
)
GO

CREATE TABLE Periodos(
	 ID_Periodo		Integer	NOT NULL Identity(1,1) PRIMARY KEY
	,ID_Turma		Integer NOT NULL
	,DH_Inicio		Datetime NOT NULL
	,DH_Fim			Datetime NOT NULL
	,SN_Ativo		Char(1)	NOT NULL DEFAULT('S')
	,SN_Processado	Char(1)	NOT NULL DEFAULT('S')
	,CONSTRAINT chk_periodos_sn_ativo CHECK (SN_Ativo IN ('S', 'N'))
	,CONSTRAINT chk_periodos_sn_processado CHECK (SN_Ativo IN ('S', 'N'))
	,CONSTRAINT fk_periodos_turmas FOREIGN KEY (ID_Turma) REFERENCES Turmas(ID_Turma)
)

CREATE TABLE Votos_Semanais(
	 ID_Voto_Semanal Integer NOT NULL Identity(1,1) PRIMARY KEY
	,ID_Restaurante	 Integer NOT NULL 
	,ID_Periodo		 Integer NOT NULL 
	,ID_Turma_Aluno	 Integer NOT NULL 
	,DH_Inclusao     Datetime NOT NULL
	,CONSTRAINT fk_votos_semanais_restaurantes FOREIGN KEY (ID_Restaurante) REFERENCES Restaurantes(ID_Restaurante)
	,CONSTRAINT fk_votos_semanais_periodos FOREIGN KEY (ID_Periodo) REFERENCES Periodos(ID_Periodo)
	,CONSTRAINT fk_votos_semanais_turma_alunos FOREIGN KEY (ID_Turma_Aluno) REFERENCES Turma_Aluno(ID_Turma_Aluno)
)


CREATE TABLE Periodos_Resultados(
	 ID_Periodo_Resultado Integer  NOT NULL Identity(1,1) PRIMARY KEY
	,ID_Restaurante		  Integer  NOT NULL 
	,ID_Periodo			  Integer  NOT NULL 
	,NO_Votos			  Integer  NOT NULL 
	,SN_Visitado		  Char(1)  NOT NULL DEFAULT('N')
	,DT_Visita			  Datetime NOT NULL 
	,CONSTRAINT chk_periodos_resultados_sn_visitado CHECK (SN_Visitado IN ('S','N'))
	,CONSTRAINT fk_periodos_resultados_restaurantes FOREIGN KEY (ID_Restaurante) REFERENCES Restaurantes(ID_Restaurante)
	,CONSTRAINT fk_periodos_resultados_periodos FOREIGN KEY (ID_Periodo) REFERENCES Periodos(ID_Periodo)
)

CREATE TABLE Periodos_Diarios(
	 ID_Periodo_Diario	Integer	NOT NULL Identity(1,1) PRIMARY KEY
	,ID_Periodo			Integer NOT NULL
	,DH_Inicio	Datetime NOT NULL
	,DH_Fim		Datetime NOT NULL
	,SN_Ativo	Char(1)	NOT NULL DEFAULT('S')
	,CONSTRAINT chk_periodos_diarios_sn_ativo CHECK (SN_Ativo IN ('S', 'N'))
	,CONSTRAINT fk_periodos_diarios_periodos FOREIGN KEY (ID_Periodo) REFERENCES Periodos(ID_Periodo)
)

CREATE TABLE Votos_Diarios(
	 ID_Voto_Diario			Integer  NOT NULL Identity(1,1) PRIMARY KEY
	,ID_Periodo_Resultado	Integer	 NOT NULL
	,ID_Turma_Aluno			Integer	 NOT NULL
	,DH_Inclusao			Datetime NOT NULL
	,ID_Periodo_Diario		Integer  NOT NULL
	,CONSTRAINT fk_votos_diarios_periodos_resultados FOREIGN KEY (ID_Periodo_Resultado) REFERENCES Periodos_Resultados(ID_Periodo_Resultado)
	,CONSTRAINT fk_votos_diarios_turma_aluno FOREIGN KEY (ID_Turma_Aluno) REFERENCES Turma_Aluno(ID_Turma_Aluno)
	,CONSTRAINT fk_votos_diarios_periodos_diarios FOREIGN KEY (ID_Periodo_Diario) REFERENCES Periodos_Diarios(ID_Periodo_Diario)
)

CREATE TABLE Turma_Configuracoes(
	 ID_Turma_Config					Integer		NOT NULL Identity(1,1) PRIMARY KEY
	,ID_Turma							Integer		NOT NULL 
	,SN_Segunda							CHAR(1)		NOT NULL DEFAULT('S')
	,SN_Terca							CHAR(1)		NOT NULL DEFAULT('S')
	,SN_Quarta							CHAR(1)		NOT NULL DEFAULT('S')
	,SN_Quinta							CHAR(1)		NOT NULL DEFAULT('S')
	,SN_Sexta							CHAR(1)		NOT NULL DEFAULT('S')
	,SN_Sabado							CHAR(1)		NOT NULL DEFAULT('N')
	,NO_Restaurantes_Desc_VT_Semanal	INTEGER		NOT NULL DEFAULT(2)
	,NO_Dia_VT_Semanal					INTEGER		NOT NULL DEFAULT(2)
	,DH_Inicio_VT_Semanal				TIME		NOT NULL DEFAULT('15:00:00')
	,DH_Termino_VT_Semanal				TIME		NOT NULL DEFAULT('15:00:00')
	,DH_Inicio_VT_Diaria				TIME		NOT NULL DEFAULT('15:00:00')
	,DH_Termino_VT_Diaria				TIME		NOT NULL DEFAULT('11:00:00')
)

--// Inserir dados principais

DECLARE  @ID_Turma Integer
		,@ID_Aluno Integer;

INSERT INTO Turmas(NM_Turma, CD_Turma, DT_Criacao)
VALUES('Pós Engenharia', 100, GETDATE())

SET @ID_Turma = @@IDENTITY

INSERT INTO Turma_Configuracoes(ID_Turma)
VALUES(@ID_Turma)

INSERT INTO Alunos(NM_Aluno, Email, Senha)
VALUES('Bianca Oliveira', 'bianca.oliveira24@fatec.sp.gov.br', '12345')

SET @ID_Aluno = @@IDENTITY

INSERT INTO Turma_Aluno(ID_Aluno, ID_Turma, DT_Vinculo, SN_Aprovado, SN_Moderador)
VALUES(@ID_Aluno, @ID_Turma, GETDATE(), 'S', 'S')