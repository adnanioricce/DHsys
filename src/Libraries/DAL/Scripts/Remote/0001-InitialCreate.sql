IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [Addresses] (
        [Id] int NOT NULL IDENTITY,
        [UniqueCode] nvarchar(max) NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedAt] datetimeoffset NOT NULL,
        [LastUpdatedOn] datetimeoffset NOT NULL,
        [FirstAddressLine] nvarchar(max) NULL,
        [SecondAddressLine] nvarchar(max) NULL,
        [Zipcode] nvarchar(max) NULL,
        [Addressnumber] nvarchar(max) NULL,
        [City] nvarchar(max) NULL,
        [AddressState] nvarchar(max) NULL,
        [District] nvarchar(max) NULL,
        CONSTRAINT [PK_Addresses] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [AGENDA] (
        [Id] int NOT NULL IDENTITY,
        [UniqueCode] nvarchar(max) NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedAt] datetimeoffset NOT NULL,
        [LastUpdatedOn] datetimeoffset NOT NULL,
        [CODIGO] nvarchar(max) NULL,
        [NOME] nvarchar(max) NULL,
        [ENDERECO] nvarchar(max) NULL,
        [CIDADE] nvarchar(max) NULL,
        [BAIRRO] nvarchar(max) NULL,
        [CEP] nvarchar(max) NULL,
        [FONE] nvarchar(max) NULL,
        CONSTRAINT [PK_AGENDA] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [BALCON] (
        [Id] int NOT NULL IDENTITY,
        [BACODI] nvarchar(max) NULL,
        [BANOME] nvarchar(max) NULL,
        [BACOMI] float NULL,
        [BADEVOL] float NULL,
        [CPF] nvarchar(max) NULL,
        [SENHA] nvarchar(max) NULL,
        [COMIS_BO] float NULL,
        [COMIS_PER] float NULL,
        [COMIS_ACE] float NULL,
        [COMIS_VAR] float NULL,
        [COMIS_ETI] float NULL,
        [COMIS_PERC] float NULL,
        [COMIS_OUT] float NULL,
        CONSTRAINT [PK_BALCON] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [Billings] (
        [Id] int NOT NULL IDENTITY,
        [UniqueCode] nvarchar(max) NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedAt] datetimeoffset NOT NULL,
        [LastUpdatedOn] datetimeoffset NOT NULL,
        [BeneficiaryId] int NOT NULL,
        [BeneficiaryName] nvarchar(max) NULL,
        [PersonType] int NOT NULL,
        [EndDate] datetime2 NULL,
        [Price] decimal(18,2) NOT NULL,
        [Discount] decimal(18,2) NULL,
        [IsPaid] bit NOT NULL,
        CONSTRAINT [PK_Billings] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [BRINDES] (
        [Id] int NOT NULL IDENTITY,
        [CODIGO] nvarchar(max) NULL,
        [NOME] nvarchar(max) NULL,
        [PONTOS] float NULL,
        [QTDE] float NULL,
        CONSTRAINT [PK_BRINDES] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [CADLAB] (
        [Id] int NOT NULL IDENTITY,
        [LACODI] nvarchar(max) NULL,
        [FONOME] nvarchar(max) NULL,
        [FOAPEL] nvarchar(max) NULL,
        [FOCONT] nvarchar(max) NULL,
        [FOTELE] nvarchar(max) NULL,
        [FOTEL2] nvarchar(max) NULL,
        [FOFAXE] nvarchar(max) NULL,
        [FOENDE] nvarchar(max) NULL,
        [FONUME] nvarchar(max) NULL,
        [FOCEPE] nvarchar(max) NULL,
        [FOCIDA] nvarchar(max) NULL,
        [FOBAIR] nvarchar(max) NULL,
        [FOIBGE] nvarchar(max) NULL,
        [FOESTA] nvarchar(max) NULL,
        [LAIEST] nvarchar(max) NULL,
        [LACGCE] nvarchar(max) NULL,
        [LABREV] nvarchar(max) NULL,
        [LAULTC] nvarchar(max) NULL,
        [LACOND] nvarchar(max) NULL,
        [LAPERC] float NULL,
        [LAULNO] nvarchar(max) NULL,
        [LATIPO] nvarchar(max) NULL,
        [NOMARQ] nvarchar(max) NULL,
        [DT_ALTER] datetime NULL,
        CONSTRAINT [PK_CADLAB] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [CADPROM] (
        [Id] int NOT NULL IDENTITY,
        [LACODI] nvarchar(max) NULL,
        [FONOME] nvarchar(max) NULL,
        [FOTELE] nvarchar(max) NULL,
        [VALID] datetime NULL,
        CONSTRAINT [PK_CADPROM] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [CAIXA] (
        [Id] int NOT NULL IDENTITY,
        [CX_ATEND] nvarchar(max) NULL,
        [CX_DATA] datetime NULL,
        [CX_VALOR] float NULL,
        [CX_REC] datetime NULL,
        [CX_ADM] nvarchar(max) NULL,
        [CX_CART] float NULL,
        [CX_TIPO] nvarchar(max) NULL,
        CONSTRAINT [PK_CAIXA] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [CANCDIA] (
        [Id] int NOT NULL IDENTITY,
        [FILIAL] nvarchar(max) NULL,
        [TICKET] nvarchar(max) NULL,
        [CODEMP] nvarchar(max) NULL,
        [CODFUN] nvarchar(max) NULL,
        [DATA] datetime NULL,
        [DATAC] datetime NULL,
        CONSTRAINT [PK_CANCDIA] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [CARTAO] (
        [Id] int NOT NULL IDENTITY,
        [CODIGO] nvarchar(max) NULL,
        [NOME] nvarchar(max) NULL,
        [PRAZO] nvarchar(max) NULL,
        [PARCEL] nvarchar(max) NULL,
        [QTDE] float NULL,
        [TAXA] float NULL,
        CONSTRAINT [PK_CARTAO] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [CHDEVOL] (
        [Id] int NOT NULL IDENTITY,
        [CHEQUE] nvarchar(max) NULL,
        [AGENCIA] nvarchar(max) NULL,
        [BANCO] nvarchar(max) NULL,
        [CONTA] nvarchar(max) NULL,
        [VALOR] float NULL,
        [DATAE] datetime NULL,
        [DATA] datetime NULL,
        [CLIENTE] nvarchar(max) NULL,
        CONSTRAINT [PK_CHDEVOL] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [Cheque] (
        [Id] int NOT NULL IDENTITY,
        [CHEQUE] nvarchar(max) NULL,
        [AGENCIA] nvarchar(max) NULL,
        [BANCO] nvarchar(max) NULL,
        [CONTA] nvarchar(max) NULL,
        [VALOR] float NULL,
        [DATAE] datetime NULL,
        [DATA] datetime NULL,
        [SITUACAO] nvarchar(max) NULL,
        [BAIXA] nvarchar(max) NULL,
        [TICKET] nvarchar(max) NULL,
        [FILIAL] nvarchar(max) NULL,
        [TELEFONE] nvarchar(max) NULL,
        [RG] nvarchar(max) NULL,
        [OBS] nvarchar(max) NULL,
        [CLIENTE] nvarchar(max) NULL,
        CONSTRAINT [PK_Cheque] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [CLICHEQ] (
        [Id] int NOT NULL IDENTITY,
        [CODIGO] nvarchar(max) NULL,
        [NOME] nvarchar(max) NULL,
        [ENDERECO] nvarchar(max) NULL,
        [DATANASC] datetime NULL,
        [CIDADE] nvarchar(max) NULL,
        [BAIRRO] nvarchar(max) NULL,
        [CEP] nvarchar(max) NULL,
        [FONE] nvarchar(max) NULL,
        [RG] nvarchar(max) NULL,
        [CPF] nvarchar(max) NULL,
        CONSTRAINT [PK_CLICHEQ] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [CLIENTE] (
        [Id] int NOT NULL IDENTITY,
        [CLCODI] nvarchar(max) NULL,
        [CLNOME] nvarchar(max) NULL,
        [CLENDE] nvarchar(max) NULL,
        [CLESTADO] nvarchar(max) NULL,
        [CLCEP] nvarchar(max) NULL,
        [CLTELE] nvarchar(max) NULL,
        [CLDEBI] float NULL,
        [CLPAGTO] float NULL,
        [CLLIME] float NULL,
        [CLCOMPRA] datetime NULL,
        [CLUPAGTO] datetime NULL,
        [CLCIDA] nvarchar(max) NULL,
        [CLDESC] nvarchar(max) NULL,
        [CLDESMED] float NULL,
        [CLDESPER] float NULL,
        [CLBAIRRO] nvarchar(max) NULL,
        [CLNASC] datetime NULL,
        [CLRG] nvarchar(max) NULL,
        [CLOBS] nvarchar(max) NULL,
        [CLCPF] nvarchar(max) NULL,
        [CLCRED] float NULL,
        CONSTRAINT [PK_CLIENTE] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [CliMed] (
        [Id] int NOT NULL IDENTITY,
        [CPF_CRM] nvarchar(max) NULL,
        [NOME] nvarchar(max) NULL,
        [ENDERECO] nvarchar(max) NULL,
        [SEXO] nvarchar(max) NULL,
        [FONE] nvarchar(max) NULL,
        CONSTRAINT [PK_CliMed] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [CLIPAGO] (
        [Id] int NOT NULL IDENTITY,
        [CLIENTE] nvarchar(max) NULL,
        [DATA] datetime NULL,
        [VALOR] float NULL,
        [CREDITO] float NULL,
        CONSTRAINT [PK_CLIPAGO] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [CONTAS] (
        [Id] int NOT NULL IDENTITY,
        [COD] nvarchar(max) NULL,
        [HIST] nvarchar(max) NULL,
        CONSTRAINT [PK_CONTAS] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [CONV] (
        [Id] int NOT NULL IDENTITY,
        [FUCDEM] nvarchar(max) NULL,
        [FUCODI] nvarchar(max) NULL,
        [CVNOTA] nvarchar(max) NULL,
        [CVBALC] nvarchar(max) NULL,
        [CVDATA] datetime NULL,
        [CVVALOURV] float NULL,
        [CVOBSV] nvarchar(max) NULL,
        [CVTICK] nvarchar(max) NULL,
        [CVRECEITA] nvarchar(max) NULL,
        [CVDTREC] datetime NULL,
        [CVPSUSO] nvarchar(max) NULL,
        [CVENTREGA] nvarchar(max) NULL,
        [CVVALOCRZ] float NULL,
        [CVCOMISSAO] float NULL,
        [CVLIBCOM] datetime NULL,
        [CVFILIAL] nvarchar(max) NULL,
        [CVTITULAR] nvarchar(max) NULL,
        CONSTRAINT [PK_CONV] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [CONVENIO] (
        [Id] int NOT NULL IDENTITY,
        [FUCDEM] nvarchar(max) NULL,
        [FUCODI] nvarchar(max) NULL,
        [CVNOTA] nvarchar(max) NULL,
        [CVBALC] nvarchar(max) NULL,
        [CVDATA] datetime NULL,
        [CVMESDESC] datetime NULL,
        [CVVALOURV] float NULL,
        [CVOBSV] nvarchar(max) NULL,
        [CVTICK] nvarchar(max) NULL,
        [CVRECEITA] nvarchar(max) NULL,
        [CVREC] nvarchar(max) NULL,
        [CVDTREC] datetime NULL,
        [CVPSUSO] nvarchar(max) NULL,
        [CVENTREGA] nvarchar(max) NULL,
        [CVVALOCRZ] float NULL,
        [CVCOMISSAO] float NULL,
        [CVLIBCOM] datetime NULL,
        [CVFILIAL] nvarchar(max) NULL,
        [CVTITULAR] nvarchar(max) NULL,
        CONSTRAINT [PK_CONVENIO] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [DEBCLI] (
        [Id] int NOT NULL IDENTITY,
        [CLCODI] nvarchar(max) NULL,
        [BACODI] nvarchar(max) NULL,
        [PRCODI] nvarchar(max) NULL,
        [CLDATA] datetime NULL,
        [CLQTDE] float NULL,
        [CLPAGO] nvarchar(max) NULL,
        [CLDESC] float NULL,
        [CLTICK] nvarchar(max) NULL,
        [CLBALC] nvarchar(max) NULL,
        [CLOBS] nvarchar(max) NULL,
        [DESCOMP] nvarchar(max) NULL,
        [COMISSAO] float NULL,
        [VL_PAGO] float NULL,
        [DT_PAGTO] datetime NULL,
        CONSTRAINT [PK_DEBCLI] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [DELIVERY] (
        [Id] int NOT NULL IDENTITY,
        [CODIGO] nvarchar(max) NULL,
        [NOME] nvarchar(max) NULL,
        [ENDERECO] nvarchar(max) NULL,
        [DATANASC] datetime NULL,
        [CIDADE] nvarchar(max) NULL,
        [BAIRRO] nvarchar(max) NULL,
        [CEP] nvarchar(max) NULL,
        [FONE] nvarchar(max) NULL,
        [BALCON] nvarchar(max) NULL,
        [DTCAD] datetime NULL,
        [RG] nvarchar(max) NULL,
        [CPF] nvarchar(max) NULL,
        [IMPRESSO] nvarchar(max) NULL,
        [ACUMULADO] float NULL,
        [APOSENTADO] nvarchar(max) NULL,
        [DESCMED] float NULL,
        [DESCOUT] float NULL,
        [CLCLASSI] nvarchar(max) NULL,
        [CLOBS1] nvarchar(max) NULL,
        [CLOBS2] nvarchar(max) NULL,
        [ULT_COMPRA] datetime NULL,
        CONSTRAINT [PK_DELIVERY] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [DESPESAS] (
        [Id] int NOT NULL IDENTITY,
        [DATA] datetime NULL,
        [HISTORICO] nvarchar(max) NULL,
        [VALOR] float NULL,
        [CAIXA] nvarchar(max) NULL,
        CONSTRAINT [PK_DESPESAS] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [EMPRESA] (
        [Id] int NOT NULL IDENTITY,
        [EMCODI] nvarchar(max) NULL,
        [EMRASO] nvarchar(max) NULL,
        [EMENDE] nvarchar(max) NULL,
        [EMNUME] nvarchar(max) NULL,
        [EMCIDA] nvarchar(max) NULL,
        [EMBAIR] nvarchar(max) NULL,
        [EMESTA] nvarchar(max) NULL,
        [EMCONT] nvarchar(max) NULL,
        [EMTELE] nvarchar(max) NULL,
        [EMCGCE] nvarchar(max) NULL,
        [EMINSC] nvarchar(max) NULL,
        [EMFAX] nvarchar(max) NULL,
        [EMCEP] nvarchar(max) NULL,
        [EMFILIAL] nvarchar(max) NULL,
        [EMLIMITE] float NULL,
        [DES_TICK] nvarchar(max) NULL,
        [PERC_DESC] float NULL,
        [DES_NOTA] float NULL,
        [DES_FECH] float NULL,
        [EMPERF] nvarchar(max) NULL,
        [EMPRINT] nvarchar(max) NULL,
        [DES_PERF] float NULL,
        [DES_REST] float NULL,
        [DES_ETIC] float NULL,
        [DES_B] float NULL,
        [DES_VAR] float NULL,
        [DES_ACE] float NULL,
        [DESCPLAC] nvarchar(max) NULL,
        [LIBPERF] nvarchar(max) NULL,
        [EMCONTRATO] nvarchar(max) NULL,
        [CODGOLDEN] nvarchar(max) NULL,
        [EMDEBITO] float NULL,
        [EMFECH] nvarchar(max) NULL,
        [EMGCoreA] nvarchar(max) NULL,
        [EMETICO] nvarchar(max) NULL,
        [EMOBS] nvarchar(max) NULL,
        [EMOBS1] nvarchar(max) NULL,
        [EMBLOQ] nvarchar(max) NULL,
        [VIDALK] nvarchar(max) NULL,
        [VIDAAV] nvarchar(max) NULL,
        [VIDAPC] nvarchar(max) NULL,
        [IBGEEST] nvarchar(max) NULL,
        [IBGEMUN] nvarchar(max) NULL,
        [EMRECEITA] nvarchar(max) NULL,
        CONSTRAINT [PK_EMPRESA] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [ENCOMEN] (
        [Id] int NOT NULL IDENTITY,
        [ENQTDE] float NULL,
        [ENDATA] datetime NULL,
        [PRCODI] nvarchar(max) NULL,
        CONSTRAINT [PK_ENCOMEN] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [ENT] (
        [Id] int NOT NULL IDENTITY,
        [ENDATA] datetime NULL,
        [PRCODI] nvarchar(max) NULL,
        [ENQTDE] float NULL,
        [ENVALO] float NULL,
        [PRFABR] float NULL,
        [IMPRESSO] nvarchar(max) NULL,
        [IMPRETQ] nvarchar(max) NULL,
        [ETIQUETA] nvarchar(max) NULL,
        [SOETIQ] nvarchar(max) NULL,
        [USUARIO] nvarchar(max) NULL,
        [ESTANT] float NULL,
        [DESCONTO] float NULL,
        [DESCFIN] float NULL,
        [DESCREP] float NULL,
        [ENVALODES] float NULL,
        [FORNEC] nvarchar(max) NULL,
        [NOTAFIS] nvarchar(max) NULL,
        CONSTRAINT [PK_ENT] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [ENTPRO] (
        [Id] int NOT NULL IDENTITY,
        [ENDATA] datetime NULL,
        [PRCODI] nvarchar(max) NULL,
        [ENQTDE] float NULL,
        [ENVALO] float NULL,
        [PRFABR] float NULL,
        [IMPRESSO] nvarchar(max) NULL,
        [IMPRETQ] nvarchar(max) NULL,
        [ETIQUETA] nvarchar(max) NULL,
        [SOETIQ] nvarchar(max) NULL,
        [USUARIO] nvarchar(max) NULL,
        [ESTANT] float NULL,
        [DESCONTO] float NULL,
        [DESCFIN] float NULL,
        [DESCREP] float NULL,
        [ENVALODES] float NULL,
        [FORNEC] nvarchar(max) NULL,
        [LOTE] nvarchar(max) NULL,
        [EMISSNF] datetime NULL,
        [NOTAFIS] nvarchar(max) NULL,
        CONSTRAINT [PK_ENTPRO] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [ESTQ0045] (
        [Id] int NOT NULL IDENTITY,
        [PRCODI] nvarchar(max) NULL,
        [PRBARRA] nvarchar(max) NULL,
        [PRDESC] nvarchar(max) NULL,
        [PRESTQ] float NULL,
        [EST_MINIMO] float NULL,
        [SECAO] nvarchar(max) NULL,
        [PRCDSE] nvarchar(max) NULL,
        CONSTRAINT [PK_ESTQ0045] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [ETIQPERF] (
        [Id] int NOT NULL IDENTITY,
        [PRCODI] nvarchar(max) NULL,
        [PRDESC1] nvarchar(max) NULL,
        [PRDESC2] nvarchar(max) NULL,
        [PRCONS] float NULL,
        [PRCONSF] float NULL,
        CONSTRAINT [PK_ETIQPERF] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [ETIQPROM] (
        [Id] int NOT NULL IDENTITY,
        [PRCODI] nvarchar(max) NULL,
        [PRDESC1] nvarchar(max) NULL,
        [PRDESC2] nvarchar(max) NULL,
        [PRCONS] float NULL,
        [PRCONSF] float NULL,
        CONSTRAINT [PK_ETIQPROM] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [ETIQUETA] (
        [Id] int NOT NULL IDENTITY,
        [PRCODI] nvarchar(max) NULL,
        [PRDESC1] nvarchar(max) NULL,
        [PRDESC2] nvarchar(max) NULL,
        [PRCONS] float NULL,
        CONSTRAINT [PK_ETIQUETA] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [FALTAS] (
        [Id] int NOT NULL IDENTITY,
        [PRCODI] nvarchar(max) NULL,
        [DATA] datetime NULL,
        [BALCON] nvarchar(max) NULL,
        CONSTRAINT [PK_FALTAS] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [FECHCONV] (
        [Id] int NOT NULL IDENTITY,
        [FUCDEM] nvarchar(max) NULL,
        [DATA] datetime NULL,
        [VALOR] float NULL,
        CONSTRAINT [PK_FECHCONV] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [FILIAL] (
        [Id] int NOT NULL IDENTITY,
        [FILCODI] nvarchar(max) NULL,
        [FILNOME] nvarchar(max) NULL,
        [FILENDE] nvarchar(max) NULL,
        [FILCIDA] nvarchar(max) NULL,
        [FILESTA] nvarchar(max) NULL,
        [FILCONT] nvarchar(max) NULL,
        [FILTELE] nvarchar(max) NULL,
        [FILCGCE] nvarchar(max) NULL,
        [FILINSC] nvarchar(max) NULL,
        [FILFAX] nvarchar(max) NULL,
        [FILCEP] nvarchar(max) NULL,
        [SUBSEC1] nvarchar(max) NULL,
        [DESC1] float NULL,
        [APLICA1] nvarchar(max) NULL,
        [SUBSEC2] nvarchar(max) NULL,
        [DESC2] float NULL,
        [APLICA2] nvarchar(max) NULL,
        [SUBSEC3] nvarchar(max) NULL,
        [DESC3] float NULL,
        [APLICA3] nvarchar(max) NULL,
        [SUBSEC4] nvarchar(max) NULL,
        [DESC4] float NULL,
        [APLICA4] nvarchar(max) NULL,
        [SUBSEC5] nvarchar(max) NULL,
        [DESC5] float NULL,
        [APLICA5] nvarchar(max) NULL,
        [SUBSEC6] nvarchar(max) NULL,
        [DESC6] float NULL,
        [APLICA6] nvarchar(max) NULL,
        [SUBSEC7] nvarchar(max) NULL,
        [DESC7] float NULL,
        [APLICA7] nvarchar(max) NULL,
        [SUBSEC8] nvarchar(max) NULL,
        [DESC8] float NULL,
        [APLICA8] nvarchar(max) NULL,
        [SUBSEC9] nvarchar(max) NULL,
        [DESC9] float NULL,
        [APLICA9] nvarchar(max) NULL,
        [SUBSEC10] nvarchar(max) NULL,
        [DESC10] float NULL,
        [APLICA10] nvarchar(max) NULL,
        CONSTRAINT [PK_FILIAL] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [FUNCIO] (
        [Id] int NOT NULL IDENTITY,
        [FUCDEM] nvarchar(max) NULL,
        [FUCODI] nvarchar(max) NULL,
        [FUNOME] nvarchar(max) NULL,
        [FUEND] nvarchar(max) NULL,
        [FUBAI] nvarchar(max) NULL,
        [FUCID] nvarchar(max) NULL,
        [FUEST] nvarchar(max) NULL,
        [FUCEP] nvarchar(max) NULL,
        [FUFONE] nvarchar(max) NULL,
        [FUSIT] nvarchar(max) NULL,
        [FUPLANO] nvarchar(max) NULL,
        [FCoreDENT] nvarchar(max) NULL,
        [FUDEPTO] nvarchar(max) NULL,
        [TOTDEBCR] float NULL,
        [TOTDEBSR] float NULL,
        [DEMITIDO] nvarchar(max) NULL,
        [DATADEMI] datetime NULL,
        [IMPRESSO] nvarchar(max) NULL,
        [FULIMITE] float NULL,
        [FUOBS1] nvarchar(max) NULL,
        [FUOBS2] nvarchar(max) NULL,
        [FUOBS3] nvarchar(max) NULL,
        [FUBLOQ] nvarchar(max) NULL,
        [CODGOLDEN] nvarchar(max) NULL,
        [FUDATA] datetime NULL,
        CONSTRAINT [PK_FUNCIO] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [HISTOR] (
        [Id] int NOT NULL IDENTITY,
        [DISTRIB] nvarchar(max) NULL,
        [NOTAFIS] nvarchar(max) NULL,
        [VENCTO] datetime NULL,
        [RECEBTO] datetime NULL,
        [PEDIDO] nvarchar(max) NULL,
        [TOTAL] float NULL,
        [DESCONTO] float NULL,
        CONSTRAINT [PK_HISTOR] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [IBPT] (
        [Id] int NOT NULL IDENTITY,
        [CODIGO] nvarchar(max) NULL,
        [IMP1] nvarchar(max) NULL,
        [IMP2] nvarchar(max) NULL,
        CONSTRAINT [PK_IBPT] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [INVENT] (
        [Id] int NOT NULL IDENTITY,
        [PRCODI] nvarchar(max) NULL,
        [PRREG] nvarchar(max) NULL,
        [PRDESC] nvarchar(max) NULL,
        [LOTE] nvarchar(max) NULL,
        [QTDE] float NULL,
        [TPMED] nvarchar(max) NULL,
        CONSTRAINT [PK_INVENT] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [LOGSYS] (
        [Id] int NOT NULL IDENTITY,
        [DATA] datetime NULL,
        [USUARIO] nvarchar(max) NULL,
        [TIME] nvarchar(max) NULL,
        [NIVEL] nvarchar(max) NULL,
        [OPCAO] nvarchar(max) NULL,
        CONSTRAINT [PK_LOGSYS] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [MALCLIEN] (
        [Id] int NOT NULL IDENTITY,
        [CODIGO] nvarchar(max) NULL,
        [NOME] nvarchar(max) NULL,
        [ENDERECO] nvarchar(max) NULL,
        [DATANASC] datetime NULL,
        [CIDADE] nvarchar(max) NULL,
        [BAIRRO] nvarchar(max) NULL,
        [CEP] nvarchar(max) NULL,
        [FONE] nvarchar(max) NULL,
        [BALCON] nvarchar(max) NULL,
        [DTCAD] datetime NULL,
        [RG] nvarchar(max) NULL,
        [CPF] nvarchar(max) NULL,
        [IMPRESSO] nvarchar(max) NULL,
        [ACUMULADO] float NULL,
        [APOSENTADO] nvarchar(max) NULL,
        [DESCMED] float NULL,
        [DESCOUT] float NULL,
        [CLCLASSI] nvarchar(max) NULL,
        [CLOBS1] nvarchar(max) NULL,
        [CLOBS2] nvarchar(max) NULL,
        [FILIAL] nvarchar(max) NULL,
        [ULT_COMPRA] datetime NULL,
        CONSTRAINT [PK_MALCLIEN] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [MERCTRAN] (
        [Id] int NOT NULL IDENTITY,
        [PRCODI] nvarchar(max) NULL,
        [DESCRICAO] nvarchar(max) NULL,
        [QTDE] float NULL,
        [PRCONS] float NULL,
        [DESCONTO] float NULL,
        [ESTOQUE] float NULL,
        [ETIQUETA] nvarchar(max) NULL,
        [PRCONSD] float NULL,
        [COMISSAO] nvarchar(max) NULL,
        [VL_TOTAL] float NULL,
        CONSTRAINT [PK_MERCTRAN] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [MOV] (
        [Id] int NOT NULL IDENTITY,
        [N_FISCAL] nvarchar(max) NULL,
        [TICKET] nvarchar(max) NULL,
        [TOT_VEN] float NULL,
        [TOT_ANT] float NULL,
        [TIPO] nvarchar(max) NULL,
        [TPVD] nvarchar(max) NULL,
        [ECF] nvarchar(max) NULL,
        [CPF] nvarchar(max) NULL,
        [NOME] nvarchar(max) NULL,
        [DATA] datetime NULL,
        [BACODI] nvarchar(max) NULL,
        [CANCELADO] nvarchar(max) NULL,
        [CAIXA] nvarchar(max) NULL,
        [HORA] nvarchar(max) NULL,
        [DINHEIRO] float NULL,
        [CHEQUE] float NULL,
        [CHEQUEPRE] float NULL,
        [CARTAOC] float NULL,
        [POPULAR] float NULL,
        [ADMCART] nvarchar(max) NULL,
        [CODCLI] nvarchar(max) NULL,
        CONSTRAINT [PK_MOV] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [MOVM] (
        [Id] int NOT NULL IDENTITY,
        [N_FISCAL] nvarchar(max) NULL,
        [TICKET] nvarchar(max) NULL,
        [TOT_VEN] float NULL,
        [TOT_ANT] float NULL,
        [TIPO] nvarchar(max) NULL,
        [TPVD] nvarchar(max) NULL,
        [DATA] datetime NULL,
        [BACODI] nvarchar(max) NULL,
        [CANCELADO] nvarchar(max) NULL,
        [CAIXA] nvarchar(max) NULL,
        [HORA] nvarchar(max) NULL,
        [DINHEIRO] float NULL,
        [CHEQUE] float NULL,
        [CHEQUEPRE] float NULL,
        [CARTAOC] float NULL,
        [ADMCART] nvarchar(max) NULL,
        [CODCLI] nvarchar(max) NULL,
        CONSTRAINT [PK_MOVM] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [MOVME] (
        [Id] int NOT NULL IDENTITY,
        [PRCODI] nvarchar(max) NULL,
        [PRQTDE] float NULL,
        [VL_UNIT] float NULL,
        [VLLIQCoreD] float NULL,
        [TOT_DESCON] float NULL,
        [TICKET] nvarchar(max) NULL,
        [BACODI] nvarchar(max) NULL,
        [DATA] datetime NULL,
        [TIPO] nvarchar(max) NULL,
        [TPVD] nvarchar(max) NULL,
        [CANCELADO] nvarchar(max) NULL,
        [VL_TOT] float NULL,
        [TOT_COMIS] float NULL,
        [PEDIDO] nvarchar(max) NULL,
        [CODCLI] nvarchar(max) NULL,
        CONSTRAINT [PK_MOVME] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [MOVMES] (
        [Id] int NOT NULL IDENTITY,
        [PRCODI] nvarchar(max) NULL,
        [PRQTDE] float NULL,
        [VL_UNIT] float NULL,
        [VLLIQCoreD] float NULL,
        [TOT_DESCON] float NULL,
        [TICKET] nvarchar(max) NULL,
        [BACODI] nvarchar(max) NULL,
        [DATA] datetime NULL,
        [TIPO] nvarchar(max) NULL,
        [TPVD] nvarchar(max) NULL,
        [ECF] nvarchar(max) NULL,
        [CANCELADO] nvarchar(max) NULL,
        [VL_TOT] float NULL,
        [TOT_COMIS] float NULL,
        [PEDIDO] nvarchar(max) NULL,
        [CODCLI] nvarchar(max) NULL,
        CONSTRAINT [PK_MOVMES] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [MOVNF] (
        [Id] int NOT NULL IDENTITY,
        [PRCODI] nvarchar(max) NULL,
        [PRQTDE] float NULL,
        [VL_UNIT] float NULL,
        [TICKET] nvarchar(max) NULL,
        [DATA] datetime NULL,
        [ECF] nvarchar(max) NULL,
        [DESCRICAO] nvarchar(max) NULL,
        [CANCELADO] nvarchar(max) NULL,
        [CPF] nvarchar(max) NULL,
        [VL_TOT] float NULL,
        CONSTRAINT [PK_MOVNF] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [MOVPOP] (
        [Id] int NOT NULL IDENTITY,
        [PRCODI] nvarchar(max) NULL,
        [PRQTDE] float NULL,
        [VL_UNIT] float NULL,
        [VLLIQCoreD] float NULL,
        [TOT_DESCON] float NULL,
        [TICKET] nvarchar(max) NULL,
        [DATA] datetime NULL,
        [DATAREC] datetime NULL,
        [ECF] nvarchar(max) NULL,
        [CANCELADO] nvarchar(max) NULL,
        [VL_TOT] float NULL,
        [COMPDIA] float NULL,
        [COMPMES] float NULL,
        [BALC_CPF] nvarchar(max) NULL,
        [CPFCLI] nvarchar(max) NULL,
        [SENHA] nvarchar(max) NULL,
        [CRM] nvarchar(max) NULL,
        CONSTRAINT [PK_MOVPOP] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [NATUREZA] (
        [Id] int NOT NULL IDENTITY,
        [CODIGO] nvarchar(max) NULL,
        [NOME] nvarchar(max) NULL,
        CONSTRAINT [PK_NATUREZA] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [NEWCLI] (
        [Id] int NOT NULL IDENTITY,
        [CODIGO] nvarchar(max) NULL,
        [NOME] nvarchar(max) NULL,
        [ENDERECO] nvarchar(max) NULL,
        [CIDADE] nvarchar(max) NULL,
        [BAIRRO] nvarchar(max) NULL,
        [CEP] nvarchar(max) NULL,
        [FONE] nvarchar(max) NULL,
        [RG] nvarchar(max) NULL,
        [DATANASC] datetime NULL,
        [TIPO] nvarchar(max) NULL,
        [IMPRESSO] nvarchar(max) NULL,
        [DESCONTO] float NULL,
        [CLCLASSI] nvarchar(max) NULL,
        [ULT_COMPRA] datetime NULL,
        CONSTRAINT [PK_NEWCLI] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [NEWFUNC] (
        [Id] int NOT NULL IDENTITY,
        [FUCDEM] nvarchar(max) NULL,
        [FUCODI] nvarchar(max) NULL,
        [FUNOME] nvarchar(max) NULL,
        [FUEND] nvarchar(max) NULL,
        [FUBAI] nvarchar(max) NULL,
        [FUCID] nvarchar(max) NULL,
        [FUEST] nvarchar(max) NULL,
        [FUCEP] nvarchar(max) NULL,
        [FUFONE] nvarchar(max) NULL,
        [FUSIT] nvarchar(max) NULL,
        [FUDEPTO] nvarchar(max) NULL,
        [TOTDEBCR] float NULL,
        [TOTDEBSR] float NULL,
        [DEMITIDO] nvarchar(max) NULL,
        [DATADEMI] datetime NULL,
        [IMPRESSO] nvarchar(max) NULL,
        [FULIMITE] float NULL,
        [FUOBS1] nvarchar(max) NULL,
        [FUOBS2] nvarchar(max) NULL,
        [FUOBS3] nvarchar(max) NULL,
        [FUBLOQ] nvarchar(max) NULL,
        [CODGOLDEN] nvarchar(max) NULL,
        [FUDATA] datetime NULL,
        CONSTRAINT [PK_NEWFUNC] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [NEWPREC] (
        [Id] int NOT NULL IDENTITY,
        [PRCODI] nvarchar(max) NULL,
        [PRCONS] float NULL,
        [PRCONSCV] float NULL,
        [PRFABR] float NULL,
        [PRCDDT] datetime NULL,
        [PRCDLUCR] float NULL,
        CONSTRAINT [PK_NEWPREC] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [NEWPROD] (
        [Id] int NOT NULL IDENTITY,
        [PRCODI] nvarchar(max) NULL,
        [PRBARRA] nvarchar(max) NULL,
        [PRREG] nvarchar(max) NULL,
        [PRDESC] nvarchar(max) NULL,
        [PRPOS] nvarchar(max) NULL,
        [PRSAL] nvarchar(max) NULL,
        [PRNEUTRO] nvarchar(max) NULL,
        [PRCDLA] nvarchar(max) NULL,
        [PRNOLA] nvarchar(max) NULL,
        [PRCONS] float NULL,
        [PRCONSCV] float NULL,
        [PRFABR] float NULL,
        [PRESTQ] float NULL,
        [PRTESTQ] float NULL,
        [PRCDSE] nvarchar(max) NULL,
        [PRLOCA] nvarchar(max) NULL,
        [CODDCB] nvarchar(max) NULL,
        [PRNOSE] nvarchar(max) NULL,
        [PRETIQ] nvarchar(max) NULL,
        [ETBARRA] nvarchar(max) NULL,
        [ETGRAF] nvarchar(max) NULL,
        [PRPRET] nvarchar(max) NULL,
        [PRPORTA] nvarchar(max) NULL,
        [PRSITU] nvarchar(max) NULL,
        [PRULTE] float NULL,
        [PRDTUL] datetime NULL,
        [PRCDDT] datetime NULL,
        [PRDATA] datetime NULL,
        [PRCDLUCR] float NULL,
        [PRICMS] float NULL,
        [TIPO] nvarchar(max) NULL,
        [DESC_MAX] float NULL,
        [COMISSAO] float NULL,
        [EST_MINIMO] float NULL,
        [PRCDIMP] nvarchar(max) NULL,
        [PRCDIMP2] nvarchar(max) NULL,
        [PREMB] float NULL,
        [PRENTR] float NULL,
        [UL_VEN] datetime NULL,
        [ULTPED] datetime NULL,
        [ULTFOR] nvarchar(max) NULL,
        [PRCLAS] nvarchar(max) NULL,
        [PRMESANT] float NULL,
        [PRDESCONV] nvarchar(max) NULL,
        [PRPOPULAR] nvarchar(max) NULL,
        [CODESTA] nvarchar(max) NULL,
        [CODFIS] nvarchar(max) NULL,
        [SECAO] nvarchar(max) NULL,
        [PRPIS] nvarchar(max) NULL,
        [VENDATU] float NULL,
        [VENDANT] float NULL,
        CONSTRAINT [PK_NEWPROD] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [NEWTAB] (
        [Id] int NOT NULL IDENTITY,
        [NEWTAB] nvarchar(max) NULL,
        [MESANO] nvarchar(max) NULL,
        CONSTRAINT [PK_NEWTAB] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [NFE] (
        [Id] int NOT NULL IDENTITY,
        [CAMPO] nvarchar(max) NULL,
        [CODIGO] nvarchar(max) NULL,
        [DESCRICAO] nvarchar(max) NULL,
        [QTDE] nvarchar(max) NULL,
        [VALOR] nvarchar(max) NULL,
        [VLTOT] nvarchar(max) NULL,
        [NCM] nvarchar(max) NULL,
        [IMP] nvarchar(max) NULL,
        [ICMS] nvarchar(max) NULL,
        [PRCDIMP] nvarchar(max) NULL,
        CONSTRAINT [PK_NFE] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [NOTA] (
        [Id] int NOT NULL IDENTITY,
        [N_FISCAL] nvarchar(max) NULL,
        [CLIENTE] nvarchar(max) NULL,
        [NVALOR] float NULL,
        [BASE] float NULL,
        [ICMS] float NULL,
        [BASESUB] float NULL,
        [ICMSSUB] float NULL,
        [NBASE7] float NULL,
        [NICMS7] float NULL,
        [NBASE12] float NULL,
        [NICMS12] float NULL,
        [NBASE18] float NULL,
        [NICMS18] float NULL,
        [NBASE25] float NULL,
        [NICMS25] float NULL,
        [NATUREZA] nvarchar(max) NULL,
        [N_NATU] nvarchar(max) NULL,
        [NDATA] datetime NULL,
        [NCANCELADA] nvarchar(max) NULL,
        CONSTRAINT [PK_NOTA] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [NOTAF] (
        [Id] int NOT NULL IDENTITY,
        [NUM_NOTA] nvarchar(max) NULL,
        CONSTRAINT [PK_NOTAF] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [NPED] (
        [Id] int NOT NULL IDENTITY,
        [NUMPED] nvarchar(max) NULL,
        CONSTRAINT [PK_NPED] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [NUMPED] (
        [Id] int NOT NULL IDENTITY,
        [FORNEC] nvarchar(max) NULL,
        [PRZPAGTO] nvarchar(max) NULL,
        [DESCONTO] float NULL,
        [NUMERO] nvarchar(max) NULL,
        [PRZENTREGA] nvarchar(max) NULL,
        CONSTRAINT [PK_NUMPED] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [NumTmp] (
        [Id] int NOT NULL IDENTITY,
        [NUMERO] nvarchar(max) NULL,
        CONSTRAINT [PK_NumTmp] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [PED0204] (
        [Id] int NOT NULL IDENTITY,
        [PRCODI] nvarchar(max) NULL,
        [PRBARRA] nvarchar(max) NULL,
        [PRDESC] nvarchar(max) NULL,
        [CODINT] nvarchar(max) NULL,
        [MLOJA1] float NULL,
        [ELOJA1] float NULL,
        [NLOJA1] float NULL,
        [MLOJA2] float NULL,
        [ELOJA2] float NULL,
        [NLOJA2] float NULL,
        [MLOJA3] float NULL,
        [ELOJA3] float NULL,
        [NLOJA3] float NULL,
        [MLOJA4] float NULL,
        [ELOJA4] float NULL,
        [NLOJA4] float NULL,
        [VALOR] float NULL,
        [FORN] nvarchar(max) NULL,
        CONSTRAINT [PK_PED0204] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [PED0301] (
        [Id] int NOT NULL IDENTITY,
        [PRCODI] nvarchar(max) NULL,
        [PRBARRA] nvarchar(max) NULL,
        [PRDESC] nvarchar(max) NULL,
        [CODINT] nvarchar(max) NULL,
        [MLOJA1] float NULL,
        [ELOJA1] float NULL,
        [NLOJA1] float NULL,
        [MLOJA2] float NULL,
        [ELOJA2] float NULL,
        [NLOJA2] float NULL,
        [MLOJA3] float NULL,
        [ELOJA3] float NULL,
        [NLOJA3] float NULL,
        [MLOJA4] float NULL,
        [ELOJA4] float NULL,
        [NLOJA4] float NULL,
        [VALOR] float NULL,
        [FORN] nvarchar(max) NULL,
        CONSTRAINT [PK_PED0301] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [PED0406] (
        [Id] int NOT NULL IDENTITY,
        [PRCODI] nvarchar(max) NULL,
        [PRBARRA] nvarchar(max) NULL,
        [PRDESC] nvarchar(max) NULL,
        [CODINT] nvarchar(max) NULL,
        [MLOJA1] float NULL,
        [ELOJA1] float NULL,
        [NLOJA1] float NULL,
        [MLOJA2] float NULL,
        [ELOJA2] float NULL,
        [NLOJA2] float NULL,
        [MLOJA3] float NULL,
        [ELOJA3] float NULL,
        [NLOJA3] float NULL,
        [MLOJA4] float NULL,
        [ELOJA4] float NULL,
        [NLOJA4] float NULL,
        [VALOR] float NULL,
        [FORN] nvarchar(max) NULL,
        CONSTRAINT [PK_PED0406] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [PED1103] (
        [Id] int NOT NULL IDENTITY,
        [PRCODI] nvarchar(max) NULL,
        [PRBARRA] nvarchar(max) NULL,
        [PRDESC] nvarchar(max) NULL,
        [CODINT] nvarchar(max) NULL,
        [MLOJA1] float NULL,
        [ELOJA1] float NULL,
        [NLOJA1] float NULL,
        [MLOJA2] float NULL,
        [ELOJA2] float NULL,
        [NLOJA2] float NULL,
        [MLOJA3] float NULL,
        [ELOJA3] float NULL,
        [NLOJA3] float NULL,
        [MLOJA4] float NULL,
        [ELOJA4] float NULL,
        [NLOJA4] float NULL,
        [VALOR] float NULL,
        [FORN] nvarchar(max) NULL,
        CONSTRAINT [PK_PED1103] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [PED1406] (
        [Id] int NOT NULL IDENTITY,
        [PRCODI] nvarchar(max) NULL,
        [PRBARRA] nvarchar(max) NULL,
        [PRDESC] nvarchar(max) NULL,
        [CODINT] nvarchar(max) NULL,
        [MLOJA1] float NULL,
        [ELOJA1] float NULL,
        [NLOJA1] float NULL,
        [MLOJA2] float NULL,
        [ELOJA2] float NULL,
        [NLOJA2] float NULL,
        [MLOJA3] float NULL,
        [ELOJA3] float NULL,
        [NLOJA3] float NULL,
        [MLOJA4] float NULL,
        [ELOJA4] float NULL,
        [NLOJA4] float NULL,
        [VALOR] float NULL,
        [FORN] nvarchar(max) NULL,
        CONSTRAINT [PK_PED1406] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [PED1912] (
        [Id] int NOT NULL IDENTITY,
        [PRCODI] nvarchar(max) NULL,
        [PRBARRA] nvarchar(max) NULL,
        [PRDESC] nvarchar(max) NULL,
        [CODINT] nvarchar(max) NULL,
        [MLOJA1] float NULL,
        [ELOJA1] float NULL,
        [NLOJA1] float NULL,
        [MLOJA2] float NULL,
        [ELOJA2] float NULL,
        [NLOJA2] float NULL,
        [MLOJA3] float NULL,
        [ELOJA3] float NULL,
        [NLOJA3] float NULL,
        [MLOJA4] float NULL,
        [ELOJA4] float NULL,
        [NLOJA4] float NULL,
        [VALOR] float NULL,
        [FORN] nvarchar(max) NULL,
        CONSTRAINT [PK_PED1912] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [PEDIDOS] (
        [Id] int NOT NULL IDENTITY,
        [PRCODI] nvarchar(max) NULL,
        [PRQTDE] float NULL,
        [PRCDLA] nvarchar(max) NULL,
        [PRFABR] float NULL,
        [STATUS] nvarchar(max) NULL,
        [PRDATA] datetime NULL,
        CONSTRAINT [PK_PEDIDOS] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [PRODEXTR] (
        [Id] int NOT NULL IDENTITY,
        [PRCODI] nvarchar(max) NULL,
        [PRDESC] nvarchar(max) NULL,
        [PRCONS] float NULL,
        [CONCOR1] float NULL,
        [CONCOR2] float NULL,
        [CONCOR3] float NULL,
        [CONCOR4] float NULL,
        CONSTRAINT [PK_PRODEXTR] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [PRODUTO] (
        [Id] int NOT NULL IDENTITY,
        [UniqueCode] nvarchar(max) NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedAt] datetimeoffset NOT NULL,
        [LastUpdatedOn] datetimeoffset NOT NULL,
        [PRCODI] nvarchar(max) NULL,
        [PRBARRA] nvarchar(max) NULL,
        [PRREG] nvarchar(max) NULL,
        [PRDESC] nvarchar(max) NULL,
        [PRLOTE] nvarchar(max) NULL,
        [PRPOS] nvarchar(max) NULL,
        [PRSAL] nvarchar(max) NULL,
        [PRNEUTRO] nvarchar(max) NULL,
        [PRCDLA] nvarchar(max) NULL,
        [PRNOLA] nvarchar(max) NULL,
        [PRCONS] float NULL,
        [PRCONSCV] float NULL,
        [PRFABR] float NULL,
        [PRFIXA] nvarchar(max) NULL,
        [PRPROMO] float NULL,
        [VLCOMIS] float NULL,
        [PRESTQ] float NULL,
        [PRINICIAL] float NULL,
        [PRFINAL] float NULL,
        [PRTESTQ] float NULL,
        [PRCDSE] nvarchar(max) NULL,
        [PRLOCA] nvarchar(max) NULL,
        [PRNOSE] nvarchar(max) NULL,
        [PRETIQ] nvarchar(max) NULL,
        [CODDCB] nvarchar(max) NULL,
        [ETBARRA] nvarchar(max) NULL,
        [ETGRAF] nvarchar(max) NULL,
        [PRPRET] nvarchar(max) NULL,
        [PRPORTA] nvarchar(max) NULL,
        [PRSITU] nvarchar(max) NULL,
        [PRULTE] float NULL,
        [PRDTUL] datetime NULL,
        [PRCDDT] datetime NULL,
        [PRDATA] datetime NULL,
        [PRCDLUCR] float NULL,
        [PRICMS] float NULL,
        [TIPO] nvarchar(max) NULL,
        [DESC_MAX] float NULL,
        [COMISSAO] float NULL,
        [EST_MINIMO] float NULL,
        [PRCDIMP] nvarchar(max) NULL,
        [PRCDIMP2] nvarchar(max) NULL,
        [PREMB] float NULL,
        [PRENTR] float NULL,
        [UL_VEN] datetime NULL,
        [ULTPED] datetime NULL,
        [ULTFOR] nvarchar(max) NULL,
        [PRCLAS] nvarchar(max) NULL,
        [PRMESANT] float NULL,
        [ULTPRECO] float NULL,
        [PRDESCONV] nvarchar(max) NULL,
        [PRPOPULAR] nvarchar(max) NULL,
        [CODESTA] nvarchar(max) NULL,
        [PRPRINCI] nvarchar(max) NULL,
        [CODFIS] nvarchar(max) NULL,
        [SECAO] nvarchar(max) NULL,
        [PRPIS] nvarchar(max) NULL,
        [PRUN] nvarchar(max) NULL,
        [PRNCMS] nvarchar(max) NULL,
        [PRVALID] datetime NULL,
        [VENDATU] float NULL,
        [VENDANT] float NULL,
        CONSTRAINT [PK_PRODUTO] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [PSICO] (
        [Id] int NOT NULL IDENTITY,
        [PRCODI] nvarchar(max) NULL,
        [TICKET] nvarchar(max) NULL,
        [PRREG] nvarchar(max) NULL,
        [BARRAS] nvarchar(max) NULL,
        [PRDESC] nvarchar(max) NULL,
        [RECEITA] nvarchar(max) NULL,
        [TPRECEITA] nvarchar(max) NULL,
        [CRM] nvarchar(max) NULL,
        [NOMEMED] nvarchar(max) NULL,
        [TPCONS] nvarchar(max) NULL,
        [UFCONS] nvarchar(max) NULL,
        [LOTE] nvarchar(max) NULL,
        [QTDE] float NULL,
        [DATA] datetime NULL,
        [TIPO] nvarchar(max) NULL,
        [MOTIVO] nvarchar(max) NULL,
        [USOMED] nvarchar(max) NULL,
        [PORTA] nvarchar(max) NULL,
        [RG] nvarchar(max) NULL,
        [ORGAO] nvarchar(max) NULL,
        [PACIENTE] nvarchar(max) NULL,
        [UF] nvarchar(max) NULL,
        [EMISSAO] datetime NULL,
        [NF] nvarchar(max) NULL,
        [CNPJ] nvarchar(max) NULL,
        [FORNEC] nvarchar(max) NULL,
        [FONE] nvarchar(max) NULL,
        [NOME] nvarchar(max) NULL,
        [TPMED] nvarchar(max) NULL,
        [SEXO] nvarchar(max) NULL,
        [CID] nvarchar(max) NULL,
        [IDADE] nvarchar(max) NULL,
        [TPIDADE] nvarchar(max) NULL,
        [PROLONG] nvarchar(max) NULL,
        [UNIDADE] nvarchar(max) NULL,
        [NASC] datetime NULL,
        CONSTRAINT [PK_PSICO] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [RANCLIQT] (
        [Id] int NOT NULL IDENTITY,
        [PRCODI] nvarchar(max) NULL,
        [PRQTDE] float NULL,
        [VL_UNIT] float NULL,
        [TOT_DESCON] float NULL,
        [TICKET] nvarchar(max) NULL,
        [BACODI] nvarchar(max) NULL,
        [DATA] datetime NULL,
        [TIPO] nvarchar(max) NULL,
        [CANCELADO] nvarchar(max) NULL,
        [VL_TOT] float NULL,
        [TOT_COMIS] float NULL,
        [CODCLI] nvarchar(max) NULL,
        CONSTRAINT [PK_RANCLIQT] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [RANCLIVL] (
        [Id] int NOT NULL IDENTITY,
        [N_FISCAL] nvarchar(max) NULL,
        [TICKET] nvarchar(max) NULL,
        [TOT_VEN] float NULL,
        [TIPO] nvarchar(max) NULL,
        [DATA] datetime NULL,
        [BACODI] nvarchar(max) NULL,
        [CANCELADO] nvarchar(max) NULL,
        [CAIXA] nvarchar(max) NULL,
        [HORA] nvarchar(max) NULL,
        [CODCLI] nvarchar(max) NULL,
        CONSTRAINT [PK_RANCLIVL] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [RECONST] (
        [Id] int NOT NULL IDENTITY,
        [ARQCoreVO] nvarchar(max) NULL,
        [POSICAO] nvarchar(max) NULL,
        [DATA] datetime NULL,
        [NECESSITA] nvarchar(max) NULL,
        CONSTRAINT [PK_RECONST] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [REDUCAO] (
        [Id] int NOT NULL IDENTITY,
        [RZAUT] nvarchar(max) NULL,
        [GTDA] nvarchar(max) NULL,
        [CANCELA] nvarchar(max) NULL,
        [DESCONTO] nvarchar(max) NULL,
        [TRIBUTO] nvarchar(max) NULL,
        [SUPRI] nvarchar(max) NULL,
        [NSI] nvarchar(max) NULL,
        [CNSI] nvarchar(max) NULL,
        [COO] nvarchar(max) NULL,
        [CNS] nvarchar(max) NULL,
        [ALIQUOTA] nvarchar(max) NULL,
        [DATA] nvarchar(max) NULL,
        [ACRESC] nvarchar(max) NULL,
        [ACRESFIN] nvarchar(max) NULL,
        [SANGRIA] nvarchar(max) NULL,
        CONSTRAINT [PK_REDUCAO] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [relator] (
        [Id] int NOT NULL IDENTITY,
        [RELATORIO] nvarchar(max) NULL,
        [NIVEL] nvarchar(max) NULL,
        CONSTRAINT [PK_relator] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [ResAno] (
        [Id] int NOT NULL IDENTITY,
        [MES_REF] nvarchar(max) NULL,
        [CLI_ATDS] float NULL,
        [VEN_MES] float NULL,
        [TOT_ESTOQ] float NULL,
        [DIASTRAB] float NULL,
        [ENTRADAS] float NULL,
        [DESCREC] float NULL,
        [VEN_FIADO] float NULL,
        [REC_FIADO] float NULL,
        [VDA_VISTA] float NULL,
        [VDA_CONV] float NULL,
        CONSTRAINT [PK_ResAno] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [RETIRADA] (
        [Id] int NOT NULL IDENTITY,
        [DATA] datetime NULL,
        [VALORDH] float NULL,
        [VALORCH] float NULL,
        [HORA] nvarchar(max) NULL,
        [CAIXA] nvarchar(max) NULL,
        CONSTRAINT [PK_RETIRADA] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [SAL] (
        [Id] int NOT NULL IDENTITY,
        [SALCOD] nvarchar(max) NULL,
        [SALNOME] nvarchar(max) NULL,
        CONSTRAINT [PK_SAL] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [SECAO] (
        [Id] int NOT NULL IDENTITY,
        [SECODI] nvarchar(max) NULL,
        [SENOME] nvarchar(max) NULL,
        CONSTRAINT [PK_SECAO] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [SENHA] (
        [Id] int NOT NULL IDENTITY,
        [SEN] nvarchar(max) NULL,
        [SENCHEQ] nvarchar(max) NULL,
        [SENCIT] nvarchar(max) NULL,
        [SENCLICH] nvarchar(max) NULL,
        [SENCLIP] nvarchar(max) NULL,
        [SENCONT] nvarchar(max) NULL,
        [SENDATE] datetime NULL,
        [SENDEFA] nvarchar(max) NULL,
        [SENDESC] float NULL,
        [SENDESC1] float NULL,
        [SENDESC2] float NULL,
        [SENDESC3] float NULL,
        [SENDESC4] float NULL,
        [SENDESC5] float NULL,
        [SENDESC6] float NULL,
        [SENDIA] float NULL,
        [SENESTQ] nvarchar(max) NULL,
        [SENETQ] nvarchar(max) NULL,
        [SENETQB] nvarchar(max) NULL,
        [SENETQE] nvarchar(max) NULL,
        [SENETQP] nvarchar(max) NULL,
        [SENFIA] nvarchar(max) NULL,
        [SENFIACR] float NULL,
        [SENFIATR] float NULL,
        [SENFIS] nvarchar(max) NULL,
        [SENLIN] float NULL,
        [SENMAN] nvarchar(max) NULL,
        [SENMDPRINT] float NULL,
        [SENMULTA] float NULL,
        [SENNIV] nvarchar(max) NULL,
        [SENPAR] nvarchar(max) NULL,
        [SENPCLI] datetime NULL,
        [SENPME] float NULL,
        [SENPONTO] float NULL,
        [SENPORT] nvarchar(max) NULL,
        [SENPRINT] nvarchar(max) NULL,
        [SENPROT] nvarchar(max) NULL,
        [SENREC] nvarchar(max) NULL,
        [SENREL] nvarchar(max) NULL,
        [SENREPETE] nvarchar(max) NULL,
        [SENVER] nvarchar(max) NULL,
        [SENVLPON] float NULL,
        CONSTRAINT [PK_SENHA] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [SERVICO] (
        [Id] int NOT NULL IDENTITY,
        [SVCODI] nvarchar(max) NULL,
        [SVDESC] nvarchar(max) NULL,
        [SVPREC] float NULL,
        [SVVEN1] float NULL,
        [SVVEN2] float NULL,
        [SVCOMB] float NULL,
        [SVPR01] nvarchar(max) NULL,
        [SVPR02] nvarchar(max) NULL,
        [SVPR03] nvarchar(max) NULL,
        [SVPR04] nvarchar(max) NULL,
        [SVPR05] nvarchar(max) NULL,
        CONSTRAINT [PK_SERVICO] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [SISTEMA] (
        [Id] int NOT NULL IDENTITY,
        [USUARIO] nvarchar(max) NULL,
        [TICKET] nvarchar(max) NULL,
        CONSTRAINT [PK_SISTEMA] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [SLPHARMA] (
        [Id] int NOT NULL IDENTITY,
        [RECONST] nvarchar(max) NULL,
        CONSTRAINT [PK_SLPHARMA] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [SUBSECAO] (
        [Id] int NOT NULL IDENTITY,
        [SUBSECODI] nvarchar(max) NULL,
        [SUBSENOME] nvarchar(max) NULL,
        [SUBSEPREC] nvarchar(max) NULL,
        [SECAOPERT] nvarchar(max) NULL,
        [SUBSELUCR] float NULL,
        [VALREC] float NULL,
        [SUBIMPOST] float NULL,
        [SUBNCM] nvarchar(max) NULL,
        CONSTRAINT [PK_SUBSECAO] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [TABELA] (
        [Id] int NOT NULL IDENTITY,
        [ABC] nvarchar(max) NULL,
        [CTR] nvarchar(max) NULL,
        [NOM] nvarchar(max) NULL,
        [DES] nvarchar(max) NULL,
        [PLA1] float NULL,
        [PCO1] float NULL,
        [FRA1] float NULL,
        [UNI] float NULL,
        [IPI] float NULL,
        [DTVIG] datetime NULL,
        [NEUTRO] nvarchar(max) NULL,
        [NEGPOS] nvarchar(max) NULL,
        [CUSTOM] nvarchar(max) NULL,
        [MED_DES] nvarchar(max) NULL,
        [MED_APR] nvarchar(max) NULL,
        [MED_PRINCI] nvarchar(max) NULL,
        [MED_REGIMS] nvarchar(max) NULL,
        [LAB_NOM] nvarchar(max) NULL,
        [BARRA] float NULL,
        CONSTRAINT [PK_TABELA] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [TEMP] (
        [Id] int NOT NULL IDENTITY,
        [PRCODI] nvarchar(max) NULL,
        [DESCRICAO] nvarchar(max) NULL,
        [PRCONS] float NULL,
        [DESCONTO] float NULL,
        [PRCONSD] float NULL,
        [VL_TOTAL] float NULL,
        [QTDE] float NULL,
        CONSTRAINT [PK_TEMP] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [TEMPO] (
        [Id] int NOT NULL IDENTITY,
        [PRCODI] nvarchar(max) NULL,
        [DESCRICAO] nvarchar(max) NULL,
        [QTDE] float NULL,
        [PRCONS] float NULL,
        [DESCONTO] float NULL,
        [ESTOQUE] float NULL,
        [PEDIDO] nvarchar(max) NULL,
        [PRCONSD] float NULL,
        [VL_TOTAL] float NULL,
        CONSTRAINT [PK_TEMPO] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [TICKET] (
        [Id] int NOT NULL IDENTITY,
        [TICKET] nvarchar(max) NULL,
        [ECF] nvarchar(max) NULL,
        CONSTRAINT [PK_TICKET] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [TRANSFER] (
        [Id] int NOT NULL IDENTITY,
        [TRDATA] datetime NULL,
        [BALCON] nvarchar(max) NULL,
        [PRCODI] nvarchar(max) NULL,
        [QTDE] float NULL,
        [PRCONS] float NULL,
        [ETIQUETA] nvarchar(max) NULL,
        [IMPRESSO] nvarchar(max) NULL,
        [FILCODI] nvarchar(max) NULL,
        [HORA] nvarchar(max) NULL,
        CONSTRAINT [PK_TRANSFER] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [TROCO1] (
        [Id] int NOT NULL IDENTITY,
        [TROCO_INI] float NULL,
        [INITROCO] nvarchar(max) NULL,
        [DATA] datetime NULL,
        CONSTRAINT [PK_TROCO1] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [TROCO10] (
        [Id] int NOT NULL IDENTITY,
        [TROCO_INI] float NULL,
        [INITROCO] nvarchar(max) NULL,
        [DATA] datetime NULL,
        CONSTRAINT [PK_TROCO10] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [TROCO11] (
        [Id] int NOT NULL IDENTITY,
        [TROCO_INI] float NULL,
        [INITROCO] nvarchar(max) NULL,
        [DATA] datetime NULL,
        CONSTRAINT [PK_TROCO11] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [TROCO12] (
        [Id] int NOT NULL IDENTITY,
        [TROCO_INI] float NULL,
        [INITROCO] nvarchar(max) NULL,
        [DATA] datetime NULL,
        CONSTRAINT [PK_TROCO12] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [TROCO13] (
        [Id] int NOT NULL IDENTITY,
        [TROCO_INI] float NULL,
        [INITROCO] nvarchar(max) NULL,
        [DATA] datetime NULL,
        CONSTRAINT [PK_TROCO13] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [TROCO14] (
        [Id] int NOT NULL IDENTITY,
        [TROCO_INI] float NULL,
        [INITROCO] nvarchar(max) NULL,
        [DATA] datetime NULL,
        CONSTRAINT [PK_TROCO14] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [TROCO15] (
        [Id] int NOT NULL IDENTITY,
        [TROCO_INI] float NULL,
        [INITROCO] nvarchar(max) NULL,
        [DATA] datetime NULL,
        CONSTRAINT [PK_TROCO15] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [TROCO16] (
        [Id] int NOT NULL IDENTITY,
        [TROCO_INI] float NULL,
        [INITROCO] nvarchar(max) NULL,
        [DATA] datetime NULL,
        CONSTRAINT [PK_TROCO16] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [TROCO17] (
        [Id] int NOT NULL IDENTITY,
        [TROCO_INI] float NULL,
        [INITROCO] nvarchar(max) NULL,
        [DATA] datetime NULL,
        CONSTRAINT [PK_TROCO17] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [TROCO18] (
        [Id] int NOT NULL IDENTITY,
        [TROCO_INI] float NULL,
        [INITROCO] nvarchar(max) NULL,
        [DATA] datetime NULL,
        CONSTRAINT [PK_TROCO18] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [TROCO19] (
        [Id] int NOT NULL IDENTITY,
        [TROCO_INI] float NULL,
        [INITROCO] nvarchar(max) NULL,
        [DATA] datetime NULL,
        CONSTRAINT [PK_TROCO19] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [TROCO2] (
        [Id] int NOT NULL IDENTITY,
        [TROCO_INI] float NULL,
        [INITROCO] nvarchar(max) NULL,
        [DATA] datetime NULL,
        CONSTRAINT [PK_TROCO2] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [TROCO20] (
        [Id] int NOT NULL IDENTITY,
        [TROCO_INI] float NULL,
        [INITROCO] nvarchar(max) NULL,
        [DATA] datetime NULL,
        CONSTRAINT [PK_TROCO20] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [TROCO3] (
        [Id] int NOT NULL IDENTITY,
        [TROCO_INI] float NULL,
        [INITROCO] nvarchar(max) NULL,
        [DATA] datetime NULL,
        CONSTRAINT [PK_TROCO3] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [TROCO4] (
        [Id] int NOT NULL IDENTITY,
        [TROCO_INI] float NULL,
        [INITROCO] nvarchar(max) NULL,
        [DATA] datetime NULL,
        CONSTRAINT [PK_TROCO4] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [TROCO5] (
        [Id] int NOT NULL IDENTITY,
        [TROCO_INI] float NULL,
        [INITROCO] nvarchar(max) NULL,
        [DATA] datetime NULL,
        CONSTRAINT [PK_TROCO5] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [TROCO6] (
        [Id] int NOT NULL IDENTITY,
        [TROCO_INI] float NULL,
        [INITROCO] nvarchar(max) NULL,
        [DATA] datetime NULL,
        CONSTRAINT [PK_TROCO6] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [TROCO7] (
        [Id] int NOT NULL IDENTITY,
        [TROCO_INI] float NULL,
        [INITROCO] nvarchar(max) NULL,
        [DATA] datetime NULL,
        CONSTRAINT [PK_TROCO7] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [TROCO8] (
        [Id] int NOT NULL IDENTITY,
        [TROCO_INI] float NULL,
        [INITROCO] nvarchar(max) NULL,
        [DATA] datetime NULL,
        CONSTRAINT [PK_TROCO8] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [TROCO9] (
        [Id] int NOT NULL IDENTITY,
        [TROCO_INI] float NULL,
        [INITROCO] nvarchar(max) NULL,
        [DATA] datetime NULL,
        CONSTRAINT [PK_TROCO9] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [URV] (
        [Id] int NOT NULL IDENTITY,
        [DATA] datetime NULL,
        [VALOR] float NULL,
        CONSTRAINT [PK_URV] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [USEFARMA] (
        [Id] int NOT NULL IDENTITY,
        [NOME] nvarchar(max) NULL,
        [SENHA] nvarchar(max) NULL,
        [NIVEL] nvarchar(max) NULL,
        [ACESSO1] nvarchar(max) NULL,
        [ACESSO2] nvarchar(max) NULL,
        [ACESSO3] nvarchar(max) NULL,
        [ACESSO4] nvarchar(max) NULL,
        [ACESSO5] nvarchar(max) NULL,
        [ACESSO6] nvarchar(max) NULL,
        [ACESSO7] nvarchar(max) NULL,
        [ACESSO8] nvarchar(max) NULL,
        [ACESSO9] nvarchar(max) NULL,
        [ACESSO10] nvarchar(max) NULL,
        CONSTRAINT [PK_USEFARMA] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [USOINT] (
        [Id] int NOT NULL IDENTITY,
        [DATA] datetime NULL,
        [PRCODI] nvarchar(max) NULL,
        [QTDE] float NULL,
        CONSTRAINT [PK_USOINT] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [Client] (
        [Id] int NOT NULL IDENTITY,
        [UniqueCode] nvarchar(max) NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedAt] datetimeoffset NOT NULL,
        [LastUpdatedOn] datetimeoffset NOT NULL,
        [Name] nvarchar(max) NULL,
        [AddressId] int NULL,
        [Cpf] nvarchar(max) NULL,
        CONSTRAINT [PK_Client] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Client_Addresses_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [Addresses] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [Manufacturers] (
        [Id] int NOT NULL IDENTITY,
        [UniqueCode] nvarchar(max) NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedAt] datetimeoffset NOT NULL,
        [LastUpdatedOn] datetimeoffset NOT NULL,
        [Name] nvarchar(max) NULL,
        [AddressId] int NULL,
        [Cnpj] nvarchar(max) NULL,
        CONSTRAINT [PK_Manufacturers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Manufacturers_Addresses_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [Addresses] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [Supplier] (
        [Id] int NOT NULL IDENTITY,
        [UniqueCode] nvarchar(max) NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedAt] datetimeoffset NOT NULL,
        [LastUpdatedOn] datetimeoffset NOT NULL,
        [AddressId] int NULL,
        [SupplierName] nvarchar(max) NULL,
        [Cnpj] nvarchar(max) NULL,
        CONSTRAINT [PK_Supplier] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Supplier_Addresses_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [Addresses] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [StockEntries] (
        [Id] int NOT NULL IDENTITY,
        [UniqueCode] nvarchar(max) NULL,
        [IsDeleted] bit NOT NULL,
        [LastUpdatedOn] datetimeoffset NOT NULL,
        [SupplierId] int NULL,
        [Quantity] int NULL,
        [CreatedAt] datetime2 NULL,
        [DrugMaturityDate] datetime2 NULL,
        [NfNumber] nvarchar(max) NULL,
        [NfEmissionDate] datetime2 NULL,
        [Totalcost] decimal(18,2) NULL,
        [LotCode] nvarchar(max) NULL,
        CONSTRAINT [PK_StockEntries] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_StockEntries_Supplier_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [Supplier] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [Products] (
        [Id] int NOT NULL IDENTITY,
        [UniqueCode] nvarchar(max) NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedAt] datetimeoffset NOT NULL,
        [LastUpdatedOn] datetimeoffset NOT NULL,
        [Ncm] nvarchar(max) NULL,
        [QuantityInStock] int NULL,
        [ReorderLevel] int NULL,
        [ReorderQuantity] int NULL,
        [EndCustomerPrice] decimal(18,2) NULL,
        [CostPrice] decimal(18,2) NOT NULL,
        [SavingPercentage] decimal(18,2) NOT NULL,
        [BarCode] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [Section] nvarchar(max) NULL,
        [MaxDiscountPercentage] decimal(18,2) NOT NULL,
        [DiscountValue] decimal(18,2) NOT NULL,
        [Commission] nvarchar(max) NULL,
        [ICMS] decimal(18,2) NOT NULL,
        [MinimumStock] int NOT NULL,
        [MainSupplierName] nvarchar(max) NULL,
        [ProdutoId] int NULL,
        [Discriminator] nvarchar(max) NOT NULL,
        [BaseDrugId] int NULL,
        [SupplierId] int NULL,
        [PrCdse] nvarchar(max) NULL,
        [ManufacturerId] int NULL,
        [ManufacturerName] nvarchar(max) NULL,
        [DrugName] nvarchar(max) NULL,
        [CommercialName] nvarchar(max) NULL,
        [Classification] nvarchar(max) NULL,
        [DrugCost] decimal(18,2) NULL,
        [Dosage] nvarchar(max) NULL,
        [AbsoluteDosageInMg] float NULL,
        [ActivePrinciple] nvarchar(max) NULL,
        [LotNumber] nvarchar(max) NULL,
        [PrescriptionNeeded] bit NULL,
        [IsPriceFixed] bit NULL,
        [DigitalBuleLink] nvarchar(max) NULL,
        [StockEntryId] int NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Products_StockEntries_StockEntryId] FOREIGN KEY ([StockEntryId]) REFERENCES [StockEntries] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Products_PRODUTO_ProdutoId] FOREIGN KEY ([ProdutoId]) REFERENCES [PRODUTO] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [DrugInformation] (
        [Id] int NOT NULL IDENTITY,
        [UniqueCode] nvarchar(max) NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedAt] datetimeoffset NOT NULL,
        [LastUpdatedOn] datetimeoffset NOT NULL,
        [DrugId] int NULL,
        [Indication] nvarchar(max) NULL,
        [CounterIndication] nvarchar(max) NULL,
        [HowWorks] nvarchar(max) NULL,
        [HowToUse] nvarchar(max) NULL,
        [TypeOfUse] nvarchar(max) NULL,
        [MinimalAgeOfUse] int NULL,
        [Substances] nvarchar(max) NULL,
        [UserBule] nvarchar(max) NULL,
        [ProfessionalBule] nvarchar(max) NULL,
        CONSTRAINT [PK_DrugInformation] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_DrugInformation_Products_DrugId] FOREIGN KEY ([DrugId]) REFERENCES [Products] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [ProductPrice] (
        [Id] int NOT NULL IDENTITY,
        [UniqueCode] nvarchar(max) NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedAt] datetimeoffset NOT NULL,
        [LastUpdatedOn] datetimeoffset NOT NULL,
        [ProductId] int NOT NULL,
        [Pricestartdate] datetimeoffset NULL,
        [EndCustomerDrugPrice] decimal(18,2) NOT NULL,
        [CostPrice] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_ProductPrice] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ProductPrice_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [ProductShelfLife] (
        [Id] int NOT NULL IDENTITY,
        [UniqueCode] nvarchar(max) NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedAt] datetimeoffset NOT NULL,
        [LastUpdatedOn] datetimeoffset NOT NULL,
        [ProductId] int NOT NULL,
        [StockEntryId] int NOT NULL,
        [StartDate] datetime2 NULL,
        [EndDate] datetime2 NULL,
        CONSTRAINT [PK_ProductShelfLife] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ProductShelfLife_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [ProductStockEntry] (
        [Id] int NOT NULL IDENTITY,
        [UniqueCode] nvarchar(max) NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedAt] datetimeoffset NOT NULL,
        [LastUpdatedOn] datetimeoffset NOT NULL,
        [ProductId] int NOT NULL,
        [StockEntryId] int NOT NULL,
        CONSTRAINT [PK_ProductStockEntry] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ProductStockEntry_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ProductStockEntry_StockEntries_StockEntryId] FOREIGN KEY ([StockEntryId]) REFERENCES [StockEntries] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE TABLE [ProductSupplier] (
        [Id] int NOT NULL IDENTITY,
        [UniqueCode] nvarchar(max) NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedAt] datetimeoffset NOT NULL,
        [LastUpdatedOn] datetimeoffset NOT NULL,
        [ProductId] int NOT NULL,
        [SupplierId] int NOT NULL,
        CONSTRAINT [PK_ProductSupplier] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ProductSupplier_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ProductSupplier_Supplier_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [Supplier] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BeneficiaryId', N'BeneficiaryName', N'CreatedAt', N'Discount', N'EndDate', N'IsDeleted', N'IsPaid', N'LastUpdatedOn', N'PersonType', N'Price', N'UniqueCode') AND [object_id] = OBJECT_ID(N'[Billings]'))
        SET IDENTITY_INSERT [Billings] ON;
    INSERT INTO [Billings] ([Id], [BeneficiaryId], [BeneficiaryName], [CreatedAt], [Discount], [EndDate], [IsDeleted], [IsPaid], [LastUpdatedOn], [PersonType], [Price], [UniqueCode])
    VALUES (1, 0, N'empresa', '0001-01-01T00:00:00.0000000+00:00', NULL, '2020-06-04T23:45:43.4731681Z', CAST(0 AS bit), CAST(0 AS bit), '2020-06-04T23:45:43.4731022+00:00', 0, 12.99, NULL);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BeneficiaryId', N'BeneficiaryName', N'CreatedAt', N'Discount', N'EndDate', N'IsDeleted', N'IsPaid', N'LastUpdatedOn', N'PersonType', N'Price', N'UniqueCode') AND [object_id] = OBJECT_ID(N'[Billings]'))
        SET IDENTITY_INSERT [Billings] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BeneficiaryId', N'BeneficiaryName', N'CreatedAt', N'Discount', N'EndDate', N'IsDeleted', N'IsPaid', N'LastUpdatedOn', N'PersonType', N'Price', N'UniqueCode') AND [object_id] = OBJECT_ID(N'[Billings]'))
        SET IDENTITY_INSERT [Billings] ON;
    INSERT INTO [Billings] ([Id], [BeneficiaryId], [BeneficiaryName], [CreatedAt], [Discount], [EndDate], [IsDeleted], [IsPaid], [LastUpdatedOn], [PersonType], [Price], [UniqueCode])
    VALUES (2, 0, N'empresa 2', '0001-01-01T00:00:00.0000000+00:00', NULL, '2020-06-04T23:45:43.4733824Z', CAST(0 AS bit), CAST(0 AS bit), '2020-06-04T23:45:43.4733817+00:00', 0, 22.99, NULL);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BeneficiaryId', N'BeneficiaryName', N'CreatedAt', N'Discount', N'EndDate', N'IsDeleted', N'IsPaid', N'LastUpdatedOn', N'PersonType', N'Price', N'UniqueCode') AND [object_id] = OBJECT_ID(N'[Billings]'))
        SET IDENTITY_INSERT [Billings] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE INDEX [IX_Client_AddressId] ON [Client] ([AddressId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE INDEX [IX_DrugInformation_DrugId] ON [DrugInformation] ([DrugId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE INDEX [IX_Manufacturers_AddressId] ON [Manufacturers] ([AddressId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE INDEX [IX_ProductPrice_ProductId] ON [ProductPrice] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE INDEX [IX_Products_StockEntryId] ON [Products] ([StockEntryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE INDEX [IX_Products_ProdutoId] ON [Products] ([ProdutoId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE INDEX [IX_ProductShelfLife_ProductId] ON [ProductShelfLife] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE INDEX [IX_ProductStockEntry_ProductId] ON [ProductStockEntry] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE INDEX [IX_ProductStockEntry_StockEntryId] ON [ProductStockEntry] ([StockEntryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE INDEX [IX_ProductSupplier_ProductId] ON [ProductSupplier] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE INDEX [IX_ProductSupplier_SupplierId] ON [ProductSupplier] ([SupplierId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE INDEX [IX_StockEntries_SupplierId] ON [StockEntries] ([SupplierId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    CREATE INDEX [IX_Supplier_AddressId] ON [Supplier] ([AddressId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604234544_InitialCreate-04-06-20-local')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200604234544_InitialCreate-04-06-20-local', N'3.1.3');
END;

GO

