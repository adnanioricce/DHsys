using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations.Remote
{
    public partial class InitialCreate040620local : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false),
                    FirstAddressLine = table.Column<string>(nullable: true),
                    SecondAddressLine = table.Column<string>(nullable: true),
                    Zipcode = table.Column<string>(nullable: true),
                    Addressnumber = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    AddressState = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AGENDA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false),
                    CODIGO = table.Column<string>(nullable: true),
                    NOME = table.Column<string>(nullable: true),
                    ENDERECO = table.Column<string>(nullable: true),
                    CIDADE = table.Column<string>(nullable: true),
                    BAIRRO = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true),
                    FONE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGENDA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BALCON",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BACODI = table.Column<string>(nullable: true),
                    BANOME = table.Column<string>(nullable: true),
                    BACOMI = table.Column<double>(nullable: true),
                    BADEVOL = table.Column<double>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    SENHA = table.Column<string>(nullable: true),
                    COMIS_BO = table.Column<double>(nullable: true),
                    COMIS_PER = table.Column<double>(nullable: true),
                    COMIS_ACE = table.Column<double>(nullable: true),
                    COMIS_VAR = table.Column<double>(nullable: true),
                    COMIS_ETI = table.Column<double>(nullable: true),
                    COMIS_PERC = table.Column<double>(nullable: true),
                    COMIS_OUT = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BALCON", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Billings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false),
                    BeneficiaryId = table.Column<int>(nullable: false),
                    BeneficiaryName = table.Column<string>(nullable: true),
                    PersonType = table.Column<int>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Discount = table.Column<decimal>(nullable: true),
                    IsPaid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BRINDES",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODIGO = table.Column<string>(nullable: true),
                    NOME = table.Column<string>(nullable: true),
                    PONTOS = table.Column<double>(nullable: true),
                    QTDE = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRINDES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CADLAB",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LACODI = table.Column<string>(nullable: true),
                    FONOME = table.Column<string>(nullable: true),
                    FOAPEL = table.Column<string>(nullable: true),
                    FOCONT = table.Column<string>(nullable: true),
                    FOTELE = table.Column<string>(nullable: true),
                    FOTEL2 = table.Column<string>(nullable: true),
                    FOFAXE = table.Column<string>(nullable: true),
                    FOENDE = table.Column<string>(nullable: true),
                    FONUME = table.Column<string>(nullable: true),
                    FOCEPE = table.Column<string>(nullable: true),
                    FOCIDA = table.Column<string>(nullable: true),
                    FOBAIR = table.Column<string>(nullable: true),
                    FOIBGE = table.Column<string>(nullable: true),
                    FOESTA = table.Column<string>(nullable: true),
                    LAIEST = table.Column<string>(nullable: true),
                    LACGCE = table.Column<string>(nullable: true),
                    LABREV = table.Column<string>(nullable: true),
                    LAULTC = table.Column<string>(nullable: true),
                    LACOND = table.Column<string>(nullable: true),
                    LAPERC = table.Column<double>(nullable: true),
                    LAULNO = table.Column<string>(nullable: true),
                    LATIPO = table.Column<string>(nullable: true),
                    NOMARQ = table.Column<string>(nullable: true),
                    DT_ALTER = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CADLAB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CADPROM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LACODI = table.Column<string>(nullable: true),
                    FONOME = table.Column<string>(nullable: true),
                    FOTELE = table.Column<string>(nullable: true),
                    VALID = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CADPROM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CAIXA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CX_ATEND = table.Column<string>(nullable: true),
                    CX_DATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    CX_VALOR = table.Column<double>(nullable: true),
                    CX_REC = table.Column<DateTime>(type: "datetime", nullable: true),
                    CX_ADM = table.Column<string>(nullable: true),
                    CX_CART = table.Column<double>(nullable: true),
                    CX_TIPO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAIXA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CANCDIA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FILIAL = table.Column<string>(nullable: true),
                    TICKET = table.Column<string>(nullable: true),
                    CODEMP = table.Column<string>(nullable: true),
                    CODFUN = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    DATAC = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CANCDIA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CARTAO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODIGO = table.Column<string>(nullable: true),
                    NOME = table.Column<string>(nullable: true),
                    PRAZO = table.Column<string>(nullable: true),
                    PARCEL = table.Column<string>(nullable: true),
                    QTDE = table.Column<double>(nullable: true),
                    TAXA = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARTAO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CHDEVOL",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CHEQUE = table.Column<string>(nullable: true),
                    AGENCIA = table.Column<string>(nullable: true),
                    BANCO = table.Column<string>(nullable: true),
                    CONTA = table.Column<string>(nullable: true),
                    VALOR = table.Column<double>(nullable: true),
                    DATAE = table.Column<DateTime>(type: "datetime", nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    CLIENTE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHDEVOL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cheque",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CHEQUE = table.Column<string>(nullable: true),
                    AGENCIA = table.Column<string>(nullable: true),
                    BANCO = table.Column<string>(nullable: true),
                    CONTA = table.Column<string>(nullable: true),
                    VALOR = table.Column<double>(nullable: true),
                    DATAE = table.Column<DateTime>(type: "datetime", nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    SITUACAO = table.Column<string>(nullable: true),
                    BAIXA = table.Column<string>(nullable: true),
                    TICKET = table.Column<string>(nullable: true),
                    FILIAL = table.Column<string>(nullable: true),
                    TELEFONE = table.Column<string>(nullable: true),
                    RG = table.Column<string>(nullable: true),
                    OBS = table.Column<string>(nullable: true),
                    CLIENTE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cheque", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLICHEQ",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODIGO = table.Column<string>(nullable: true),
                    NOME = table.Column<string>(nullable: true),
                    ENDERECO = table.Column<string>(nullable: true),
                    DATANASC = table.Column<DateTime>(type: "datetime", nullable: true),
                    CIDADE = table.Column<string>(nullable: true),
                    BAIRRO = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true),
                    FONE = table.Column<string>(nullable: true),
                    RG = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLICHEQ", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLIENTE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CLCODI = table.Column<string>(nullable: true),
                    CLNOME = table.Column<string>(nullable: true),
                    CLENDE = table.Column<string>(nullable: true),
                    CLESTADO = table.Column<string>(nullable: true),
                    CLCEP = table.Column<string>(nullable: true),
                    CLTELE = table.Column<string>(nullable: true),
                    CLDEBI = table.Column<double>(nullable: true),
                    CLPAGTO = table.Column<double>(nullable: true),
                    CLLIME = table.Column<double>(nullable: true),
                    CLCOMPRA = table.Column<DateTime>(type: "datetime", nullable: true),
                    CLUPAGTO = table.Column<DateTime>(type: "datetime", nullable: true),
                    CLCIDA = table.Column<string>(nullable: true),
                    CLDESC = table.Column<string>(nullable: true),
                    CLDESMED = table.Column<double>(nullable: true),
                    CLDESPER = table.Column<double>(nullable: true),
                    CLBAIRRO = table.Column<string>(nullable: true),
                    CLNASC = table.Column<DateTime>(type: "datetime", nullable: true),
                    CLRG = table.Column<string>(nullable: true),
                    CLOBS = table.Column<string>(nullable: true),
                    CLCPF = table.Column<string>(nullable: true),
                    CLCRED = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CliMed",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF_CRM = table.Column<string>(nullable: true),
                    NOME = table.Column<string>(nullable: true),
                    ENDERECO = table.Column<string>(nullable: true),
                    SEXO = table.Column<string>(nullable: true),
                    FONE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CliMed", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLIPAGO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CLIENTE = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    VALOR = table.Column<double>(nullable: true),
                    CREDITO = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIPAGO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CONTAS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COD = table.Column<string>(nullable: true),
                    HIST = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTAS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CONV",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FUCDEM = table.Column<string>(nullable: true),
                    FUCODI = table.Column<string>(nullable: true),
                    CVNOTA = table.Column<string>(nullable: true),
                    CVBALC = table.Column<string>(nullable: true),
                    CVDATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    CVVALOURV = table.Column<double>(nullable: true),
                    CVOBSV = table.Column<string>(nullable: true),
                    CVTICK = table.Column<string>(nullable: true),
                    CVRECEITA = table.Column<string>(nullable: true),
                    CVDTREC = table.Column<DateTime>(type: "datetime", nullable: true),
                    CVPSUSO = table.Column<string>(nullable: true),
                    CVENTREGA = table.Column<string>(nullable: true),
                    CVVALOCRZ = table.Column<double>(nullable: true),
                    CVCOMISSAO = table.Column<double>(nullable: true),
                    CVLIBCOM = table.Column<DateTime>(type: "datetime", nullable: true),
                    CVFILIAL = table.Column<string>(nullable: true),
                    CVTITULAR = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONV", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CONVENIO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FUCDEM = table.Column<string>(nullable: true),
                    FUCODI = table.Column<string>(nullable: true),
                    CVNOTA = table.Column<string>(nullable: true),
                    CVBALC = table.Column<string>(nullable: true),
                    CVDATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    CVMESDESC = table.Column<DateTime>(type: "datetime", nullable: true),
                    CVVALOURV = table.Column<double>(nullable: true),
                    CVOBSV = table.Column<string>(nullable: true),
                    CVTICK = table.Column<string>(nullable: true),
                    CVRECEITA = table.Column<string>(nullable: true),
                    CVREC = table.Column<string>(nullable: true),
                    CVDTREC = table.Column<DateTime>(type: "datetime", nullable: true),
                    CVPSUSO = table.Column<string>(nullable: true),
                    CVENTREGA = table.Column<string>(nullable: true),
                    CVVALOCRZ = table.Column<double>(nullable: true),
                    CVCOMISSAO = table.Column<double>(nullable: true),
                    CVLIBCOM = table.Column<DateTime>(type: "datetime", nullable: true),
                    CVFILIAL = table.Column<string>(nullable: true),
                    CVTITULAR = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONVENIO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DEBCLI",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CLCODI = table.Column<string>(nullable: true),
                    BACODI = table.Column<string>(nullable: true),
                    PRCODI = table.Column<string>(nullable: true),
                    CLDATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    CLQTDE = table.Column<double>(nullable: true),
                    CLPAGO = table.Column<string>(nullable: true),
                    CLDESC = table.Column<double>(nullable: true),
                    CLTICK = table.Column<string>(nullable: true),
                    CLBALC = table.Column<string>(nullable: true),
                    CLOBS = table.Column<string>(nullable: true),
                    DESCOMP = table.Column<string>(nullable: true),
                    COMISSAO = table.Column<double>(nullable: true),
                    VL_PAGO = table.Column<double>(nullable: true),
                    DT_PAGTO = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEBCLI", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DELIVERY",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODIGO = table.Column<string>(nullable: true),
                    NOME = table.Column<string>(nullable: true),
                    ENDERECO = table.Column<string>(nullable: true),
                    DATANASC = table.Column<DateTime>(type: "datetime", nullable: true),
                    CIDADE = table.Column<string>(nullable: true),
                    BAIRRO = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true),
                    FONE = table.Column<string>(nullable: true),
                    BALCON = table.Column<string>(nullable: true),
                    DTCAD = table.Column<DateTime>(type: "datetime", nullable: true),
                    RG = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    IMPRESSO = table.Column<string>(nullable: true),
                    ACUMULADO = table.Column<double>(nullable: true),
                    APOSENTADO = table.Column<string>(nullable: true),
                    DESCMED = table.Column<double>(nullable: true),
                    DESCOUT = table.Column<double>(nullable: true),
                    CLCLASSI = table.Column<string>(nullable: true),
                    CLOBS1 = table.Column<string>(nullable: true),
                    CLOBS2 = table.Column<string>(nullable: true),
                    ULT_COMPRA = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DELIVERY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DESPESAS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    HISTORICO = table.Column<string>(nullable: true),
                    VALOR = table.Column<double>(nullable: true),
                    CAIXA = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DESPESAS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EMPRESA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMCODI = table.Column<string>(nullable: true),
                    EMRASO = table.Column<string>(nullable: true),
                    EMENDE = table.Column<string>(nullable: true),
                    EMNUME = table.Column<string>(nullable: true),
                    EMCIDA = table.Column<string>(nullable: true),
                    EMBAIR = table.Column<string>(nullable: true),
                    EMESTA = table.Column<string>(nullable: true),
                    EMCONT = table.Column<string>(nullable: true),
                    EMTELE = table.Column<string>(nullable: true),
                    EMCGCE = table.Column<string>(nullable: true),
                    EMINSC = table.Column<string>(nullable: true),
                    EMFAX = table.Column<string>(nullable: true),
                    EMCEP = table.Column<string>(nullable: true),
                    EMFILIAL = table.Column<string>(nullable: true),
                    EMLIMITE = table.Column<double>(nullable: true),
                    DES_TICK = table.Column<string>(nullable: true),
                    PERC_DESC = table.Column<double>(nullable: true),
                    DES_NOTA = table.Column<double>(nullable: true),
                    DES_FECH = table.Column<double>(nullable: true),
                    EMPERF = table.Column<string>(nullable: true),
                    EMPRINT = table.Column<string>(nullable: true),
                    DES_PERF = table.Column<double>(nullable: true),
                    DES_REST = table.Column<double>(nullable: true),
                    DES_ETIC = table.Column<double>(nullable: true),
                    DES_B = table.Column<double>(nullable: true),
                    DES_VAR = table.Column<double>(nullable: true),
                    DES_ACE = table.Column<double>(nullable: true),
                    DESCPLAC = table.Column<string>(nullable: true),
                    LIBPERF = table.Column<string>(nullable: true),
                    EMCONTRATO = table.Column<string>(nullable: true),
                    CODGOLDEN = table.Column<string>(nullable: true),
                    EMDEBITO = table.Column<double>(nullable: true),
                    EMFECH = table.Column<string>(nullable: true),
                    EMGCoreA = table.Column<string>(nullable: true),
                    EMETICO = table.Column<string>(nullable: true),
                    EMOBS = table.Column<string>(nullable: true),
                    EMOBS1 = table.Column<string>(nullable: true),
                    EMBLOQ = table.Column<string>(nullable: true),
                    VIDALK = table.Column<string>(nullable: true),
                    VIDAAV = table.Column<string>(nullable: true),
                    VIDAPC = table.Column<string>(nullable: true),
                    IBGEEST = table.Column<string>(nullable: true),
                    IBGEMUN = table.Column<string>(nullable: true),
                    EMRECEITA = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPRESA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ENCOMEN",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENQTDE = table.Column<double>(nullable: true),
                    ENDATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    PRCODI = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENCOMEN", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ENT",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENDATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    PRCODI = table.Column<string>(nullable: true),
                    ENQTDE = table.Column<double>(nullable: true),
                    ENVALO = table.Column<double>(nullable: true),
                    PRFABR = table.Column<double>(nullable: true),
                    IMPRESSO = table.Column<string>(nullable: true),
                    IMPRETQ = table.Column<string>(nullable: true),
                    ETIQUETA = table.Column<string>(nullable: true),
                    SOETIQ = table.Column<string>(nullable: true),
                    USUARIO = table.Column<string>(nullable: true),
                    ESTANT = table.Column<double>(nullable: true),
                    DESCONTO = table.Column<double>(nullable: true),
                    DESCFIN = table.Column<double>(nullable: true),
                    DESCREP = table.Column<double>(nullable: true),
                    ENVALODES = table.Column<double>(nullable: true),
                    FORNEC = table.Column<string>(nullable: true),
                    NOTAFIS = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ENTPRO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENDATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    PRCODI = table.Column<string>(nullable: true),
                    ENQTDE = table.Column<double>(nullable: true),
                    ENVALO = table.Column<double>(nullable: true),
                    PRFABR = table.Column<double>(nullable: true),
                    IMPRESSO = table.Column<string>(nullable: true),
                    IMPRETQ = table.Column<string>(nullable: true),
                    ETIQUETA = table.Column<string>(nullable: true),
                    SOETIQ = table.Column<string>(nullable: true),
                    USUARIO = table.Column<string>(nullable: true),
                    ESTANT = table.Column<double>(nullable: true),
                    DESCONTO = table.Column<double>(nullable: true),
                    DESCFIN = table.Column<double>(nullable: true),
                    DESCREP = table.Column<double>(nullable: true),
                    ENVALODES = table.Column<double>(nullable: true),
                    FORNEC = table.Column<string>(nullable: true),
                    LOTE = table.Column<string>(nullable: true),
                    EMISSNF = table.Column<DateTime>(type: "datetime", nullable: true),
                    NOTAFIS = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENTPRO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ESTQ0045",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRCODI = table.Column<string>(nullable: true),
                    PRBARRA = table.Column<string>(nullable: true),
                    PRDESC = table.Column<string>(nullable: true),
                    PRESTQ = table.Column<double>(nullable: true),
                    EST_MINIMO = table.Column<double>(nullable: true),
                    SECAO = table.Column<string>(nullable: true),
                    PRCDSE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTQ0045", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ETIQPERF",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRCODI = table.Column<string>(nullable: true),
                    PRDESC1 = table.Column<string>(nullable: true),
                    PRDESC2 = table.Column<string>(nullable: true),
                    PRCONS = table.Column<double>(nullable: true),
                    PRCONSF = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ETIQPERF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ETIQPROM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRCODI = table.Column<string>(nullable: true),
                    PRDESC1 = table.Column<string>(nullable: true),
                    PRDESC2 = table.Column<string>(nullable: true),
                    PRCONS = table.Column<double>(nullable: true),
                    PRCONSF = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ETIQPROM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ETIQUETA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRCODI = table.Column<string>(nullable: true),
                    PRDESC1 = table.Column<string>(nullable: true),
                    PRDESC2 = table.Column<string>(nullable: true),
                    PRCONS = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ETIQUETA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FALTAS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRCODI = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    BALCON = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FALTAS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FECHCONV",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FUCDEM = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    VALOR = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FECHCONV", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FILIAL",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FILCODI = table.Column<string>(nullable: true),
                    FILNOME = table.Column<string>(nullable: true),
                    FILENDE = table.Column<string>(nullable: true),
                    FILCIDA = table.Column<string>(nullable: true),
                    FILESTA = table.Column<string>(nullable: true),
                    FILCONT = table.Column<string>(nullable: true),
                    FILTELE = table.Column<string>(nullable: true),
                    FILCGCE = table.Column<string>(nullable: true),
                    FILINSC = table.Column<string>(nullable: true),
                    FILFAX = table.Column<string>(nullable: true),
                    FILCEP = table.Column<string>(nullable: true),
                    SUBSEC1 = table.Column<string>(nullable: true),
                    DESC1 = table.Column<double>(nullable: true),
                    APLICA1 = table.Column<string>(nullable: true),
                    SUBSEC2 = table.Column<string>(nullable: true),
                    DESC2 = table.Column<double>(nullable: true),
                    APLICA2 = table.Column<string>(nullable: true),
                    SUBSEC3 = table.Column<string>(nullable: true),
                    DESC3 = table.Column<double>(nullable: true),
                    APLICA3 = table.Column<string>(nullable: true),
                    SUBSEC4 = table.Column<string>(nullable: true),
                    DESC4 = table.Column<double>(nullable: true),
                    APLICA4 = table.Column<string>(nullable: true),
                    SUBSEC5 = table.Column<string>(nullable: true),
                    DESC5 = table.Column<double>(nullable: true),
                    APLICA5 = table.Column<string>(nullable: true),
                    SUBSEC6 = table.Column<string>(nullable: true),
                    DESC6 = table.Column<double>(nullable: true),
                    APLICA6 = table.Column<string>(nullable: true),
                    SUBSEC7 = table.Column<string>(nullable: true),
                    DESC7 = table.Column<double>(nullable: true),
                    APLICA7 = table.Column<string>(nullable: true),
                    SUBSEC8 = table.Column<string>(nullable: true),
                    DESC8 = table.Column<double>(nullable: true),
                    APLICA8 = table.Column<string>(nullable: true),
                    SUBSEC9 = table.Column<string>(nullable: true),
                    DESC9 = table.Column<double>(nullable: true),
                    APLICA9 = table.Column<string>(nullable: true),
                    SUBSEC10 = table.Column<string>(nullable: true),
                    DESC10 = table.Column<double>(nullable: true),
                    APLICA10 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FILIAL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FUNCIO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FUCDEM = table.Column<string>(nullable: true),
                    FUCODI = table.Column<string>(nullable: true),
                    FUNOME = table.Column<string>(nullable: true),
                    FUEND = table.Column<string>(nullable: true),
                    FUBAI = table.Column<string>(nullable: true),
                    FUCID = table.Column<string>(nullable: true),
                    FUEST = table.Column<string>(nullable: true),
                    FUCEP = table.Column<string>(nullable: true),
                    FUFONE = table.Column<string>(nullable: true),
                    FUSIT = table.Column<string>(nullable: true),
                    FUPLANO = table.Column<string>(nullable: true),
                    FCoreDENT = table.Column<string>(nullable: true),
                    FUDEPTO = table.Column<string>(nullable: true),
                    TOTDEBCR = table.Column<double>(nullable: true),
                    TOTDEBSR = table.Column<double>(nullable: true),
                    DEMITIDO = table.Column<string>(nullable: true),
                    DATADEMI = table.Column<DateTime>(type: "datetime", nullable: true),
                    IMPRESSO = table.Column<string>(nullable: true),
                    FULIMITE = table.Column<double>(nullable: true),
                    FUOBS1 = table.Column<string>(nullable: true),
                    FUOBS2 = table.Column<string>(nullable: true),
                    FUOBS3 = table.Column<string>(nullable: true),
                    FUBLOQ = table.Column<string>(nullable: true),
                    CODGOLDEN = table.Column<string>(nullable: true),
                    FUDATA = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FUNCIO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HISTOR",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DISTRIB = table.Column<string>(nullable: true),
                    NOTAFIS = table.Column<string>(nullable: true),
                    VENCTO = table.Column<DateTime>(type: "datetime", nullable: true),
                    RECEBTO = table.Column<DateTime>(type: "datetime", nullable: true),
                    PEDIDO = table.Column<string>(nullable: true),
                    TOTAL = table.Column<double>(nullable: true),
                    DESCONTO = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HISTOR", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IBPT",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODIGO = table.Column<string>(nullable: true),
                    IMP1 = table.Column<string>(nullable: true),
                    IMP2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IBPT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "INVENT",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRCODI = table.Column<string>(nullable: true),
                    PRREG = table.Column<string>(nullable: true),
                    PRDESC = table.Column<string>(nullable: true),
                    LOTE = table.Column<string>(nullable: true),
                    QTDE = table.Column<double>(nullable: true),
                    TPMED = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVENT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LOGSYS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    USUARIO = table.Column<string>(nullable: true),
                    TIME = table.Column<string>(nullable: true),
                    NIVEL = table.Column<string>(nullable: true),
                    OPCAO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOGSYS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MALCLIEN",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODIGO = table.Column<string>(nullable: true),
                    NOME = table.Column<string>(nullable: true),
                    ENDERECO = table.Column<string>(nullable: true),
                    DATANASC = table.Column<DateTime>(type: "datetime", nullable: true),
                    CIDADE = table.Column<string>(nullable: true),
                    BAIRRO = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true),
                    FONE = table.Column<string>(nullable: true),
                    BALCON = table.Column<string>(nullable: true),
                    DTCAD = table.Column<DateTime>(type: "datetime", nullable: true),
                    RG = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    IMPRESSO = table.Column<string>(nullable: true),
                    ACUMULADO = table.Column<double>(nullable: true),
                    APOSENTADO = table.Column<string>(nullable: true),
                    DESCMED = table.Column<double>(nullable: true),
                    DESCOUT = table.Column<double>(nullable: true),
                    CLCLASSI = table.Column<string>(nullable: true),
                    CLOBS1 = table.Column<string>(nullable: true),
                    CLOBS2 = table.Column<string>(nullable: true),
                    FILIAL = table.Column<string>(nullable: true),
                    ULT_COMPRA = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MALCLIEN", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MERCTRAN",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRCODI = table.Column<string>(nullable: true),
                    DESCRICAO = table.Column<string>(nullable: true),
                    QTDE = table.Column<double>(nullable: true),
                    PRCONS = table.Column<double>(nullable: true),
                    DESCONTO = table.Column<double>(nullable: true),
                    ESTOQUE = table.Column<double>(nullable: true),
                    ETIQUETA = table.Column<string>(nullable: true),
                    PRCONSD = table.Column<double>(nullable: true),
                    COMISSAO = table.Column<string>(nullable: true),
                    VL_TOTAL = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MERCTRAN", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MOV",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_FISCAL = table.Column<string>(nullable: true),
                    TICKET = table.Column<string>(nullable: true),
                    TOT_VEN = table.Column<double>(nullable: true),
                    TOT_ANT = table.Column<double>(nullable: true),
                    TIPO = table.Column<string>(nullable: true),
                    TPVD = table.Column<string>(nullable: true),
                    ECF = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    NOME = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    BACODI = table.Column<string>(nullable: true),
                    CANCELADO = table.Column<string>(nullable: true),
                    CAIXA = table.Column<string>(nullable: true),
                    HORA = table.Column<string>(nullable: true),
                    DINHEIRO = table.Column<double>(nullable: true),
                    CHEQUE = table.Column<double>(nullable: true),
                    CHEQUEPRE = table.Column<double>(nullable: true),
                    CARTAOC = table.Column<double>(nullable: true),
                    POPULAR = table.Column<double>(nullable: true),
                    ADMCART = table.Column<string>(nullable: true),
                    CODCLI = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOV", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MOVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_FISCAL = table.Column<string>(nullable: true),
                    TICKET = table.Column<string>(nullable: true),
                    TOT_VEN = table.Column<double>(nullable: true),
                    TOT_ANT = table.Column<double>(nullable: true),
                    TIPO = table.Column<string>(nullable: true),
                    TPVD = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    BACODI = table.Column<string>(nullable: true),
                    CANCELADO = table.Column<string>(nullable: true),
                    CAIXA = table.Column<string>(nullable: true),
                    HORA = table.Column<string>(nullable: true),
                    DINHEIRO = table.Column<double>(nullable: true),
                    CHEQUE = table.Column<double>(nullable: true),
                    CHEQUEPRE = table.Column<double>(nullable: true),
                    CARTAOC = table.Column<double>(nullable: true),
                    ADMCART = table.Column<string>(nullable: true),
                    CODCLI = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MOVME",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRCODI = table.Column<string>(nullable: true),
                    PRQTDE = table.Column<double>(nullable: true),
                    VL_UNIT = table.Column<double>(nullable: true),
                    VLLIQCoreD = table.Column<double>(nullable: true),
                    TOT_DESCON = table.Column<double>(nullable: true),
                    TICKET = table.Column<string>(nullable: true),
                    BACODI = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    TIPO = table.Column<string>(nullable: true),
                    TPVD = table.Column<string>(nullable: true),
                    CANCELADO = table.Column<string>(nullable: true),
                    VL_TOT = table.Column<double>(nullable: true),
                    TOT_COMIS = table.Column<double>(nullable: true),
                    PEDIDO = table.Column<string>(nullable: true),
                    CODCLI = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOVME", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MOVMES",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRCODI = table.Column<string>(nullable: true),
                    PRQTDE = table.Column<double>(nullable: true),
                    VL_UNIT = table.Column<double>(nullable: true),
                    VLLIQCoreD = table.Column<double>(nullable: true),
                    TOT_DESCON = table.Column<double>(nullable: true),
                    TICKET = table.Column<string>(nullable: true),
                    BACODI = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    TIPO = table.Column<string>(nullable: true),
                    TPVD = table.Column<string>(nullable: true),
                    ECF = table.Column<string>(nullable: true),
                    CANCELADO = table.Column<string>(nullable: true),
                    VL_TOT = table.Column<double>(nullable: true),
                    TOT_COMIS = table.Column<double>(nullable: true),
                    PEDIDO = table.Column<string>(nullable: true),
                    CODCLI = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOVMES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MOVNF",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRCODI = table.Column<string>(nullable: true),
                    PRQTDE = table.Column<double>(nullable: true),
                    VL_UNIT = table.Column<double>(nullable: true),
                    TICKET = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    ECF = table.Column<string>(nullable: true),
                    DESCRICAO = table.Column<string>(nullable: true),
                    CANCELADO = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    VL_TOT = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOVNF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MOVPOP",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRCODI = table.Column<string>(nullable: true),
                    PRQTDE = table.Column<double>(nullable: true),
                    VL_UNIT = table.Column<double>(nullable: true),
                    VLLIQCoreD = table.Column<double>(nullable: true),
                    TOT_DESCON = table.Column<double>(nullable: true),
                    TICKET = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    DATAREC = table.Column<DateTime>(type: "datetime", nullable: true),
                    ECF = table.Column<string>(nullable: true),
                    CANCELADO = table.Column<string>(nullable: true),
                    VL_TOT = table.Column<double>(nullable: true),
                    COMPDIA = table.Column<double>(nullable: true),
                    COMPMES = table.Column<double>(nullable: true),
                    BALC_CPF = table.Column<string>(nullable: true),
                    CPFCLI = table.Column<string>(nullable: true),
                    SENHA = table.Column<string>(nullable: true),
                    CRM = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOVPOP", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NATUREZA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODIGO = table.Column<string>(nullable: true),
                    NOME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NATUREZA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NEWCLI",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODIGO = table.Column<string>(nullable: true),
                    NOME = table.Column<string>(nullable: true),
                    ENDERECO = table.Column<string>(nullable: true),
                    CIDADE = table.Column<string>(nullable: true),
                    BAIRRO = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true),
                    FONE = table.Column<string>(nullable: true),
                    RG = table.Column<string>(nullable: true),
                    DATANASC = table.Column<DateTime>(type: "datetime", nullable: true),
                    TIPO = table.Column<string>(nullable: true),
                    IMPRESSO = table.Column<string>(nullable: true),
                    DESCONTO = table.Column<double>(nullable: true),
                    CLCLASSI = table.Column<string>(nullable: true),
                    ULT_COMPRA = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NEWCLI", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NEWFUNC",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FUCDEM = table.Column<string>(nullable: true),
                    FUCODI = table.Column<string>(nullable: true),
                    FUNOME = table.Column<string>(nullable: true),
                    FUEND = table.Column<string>(nullable: true),
                    FUBAI = table.Column<string>(nullable: true),
                    FUCID = table.Column<string>(nullable: true),
                    FUEST = table.Column<string>(nullable: true),
                    FUCEP = table.Column<string>(nullable: true),
                    FUFONE = table.Column<string>(nullable: true),
                    FUSIT = table.Column<string>(nullable: true),
                    FUDEPTO = table.Column<string>(nullable: true),
                    TOTDEBCR = table.Column<double>(nullable: true),
                    TOTDEBSR = table.Column<double>(nullable: true),
                    DEMITIDO = table.Column<string>(nullable: true),
                    DATADEMI = table.Column<DateTime>(type: "datetime", nullable: true),
                    IMPRESSO = table.Column<string>(nullable: true),
                    FULIMITE = table.Column<double>(nullable: true),
                    FUOBS1 = table.Column<string>(nullable: true),
                    FUOBS2 = table.Column<string>(nullable: true),
                    FUOBS3 = table.Column<string>(nullable: true),
                    FUBLOQ = table.Column<string>(nullable: true),
                    CODGOLDEN = table.Column<string>(nullable: true),
                    FUDATA = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NEWFUNC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NEWPREC",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRCODI = table.Column<string>(nullable: true),
                    PRCONS = table.Column<double>(nullable: true),
                    PRCONSCV = table.Column<double>(nullable: true),
                    PRFABR = table.Column<double>(nullable: true),
                    PRCDDT = table.Column<DateTime>(type: "datetime", nullable: true),
                    PRCDLUCR = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NEWPREC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NEWPROD",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRCODI = table.Column<string>(nullable: true),
                    PRBARRA = table.Column<string>(nullable: true),
                    PRREG = table.Column<string>(nullable: true),
                    PRDESC = table.Column<string>(nullable: true),
                    PRPOS = table.Column<string>(nullable: true),
                    PRSAL = table.Column<string>(nullable: true),
                    PRNEUTRO = table.Column<string>(nullable: true),
                    PRCDLA = table.Column<string>(nullable: true),
                    PRNOLA = table.Column<string>(nullable: true),
                    PRCONS = table.Column<double>(nullable: true),
                    PRCONSCV = table.Column<double>(nullable: true),
                    PRFABR = table.Column<double>(nullable: true),
                    PRESTQ = table.Column<double>(nullable: true),
                    PRTESTQ = table.Column<double>(nullable: true),
                    PRCDSE = table.Column<string>(nullable: true),
                    PRLOCA = table.Column<string>(nullable: true),
                    CODDCB = table.Column<string>(nullable: true),
                    PRNOSE = table.Column<string>(nullable: true),
                    PRETIQ = table.Column<string>(nullable: true),
                    ETBARRA = table.Column<string>(nullable: true),
                    ETGRAF = table.Column<string>(nullable: true),
                    PRPRET = table.Column<string>(nullable: true),
                    PRPORTA = table.Column<string>(nullable: true),
                    PRSITU = table.Column<string>(nullable: true),
                    PRULTE = table.Column<double>(nullable: true),
                    PRDTUL = table.Column<DateTime>(type: "datetime", nullable: true),
                    PRCDDT = table.Column<DateTime>(type: "datetime", nullable: true),
                    PRDATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    PRCDLUCR = table.Column<double>(nullable: true),
                    PRICMS = table.Column<double>(nullable: true),
                    TIPO = table.Column<string>(nullable: true),
                    DESC_MAX = table.Column<double>(nullable: true),
                    COMISSAO = table.Column<double>(nullable: true),
                    EST_MINIMO = table.Column<double>(nullable: true),
                    PRCDIMP = table.Column<string>(nullable: true),
                    PRCDIMP2 = table.Column<string>(nullable: true),
                    PREMB = table.Column<double>(nullable: true),
                    PRENTR = table.Column<double>(nullable: true),
                    UL_VEN = table.Column<DateTime>(type: "datetime", nullable: true),
                    ULTPED = table.Column<DateTime>(type: "datetime", nullable: true),
                    ULTFOR = table.Column<string>(nullable: true),
                    PRCLAS = table.Column<string>(nullable: true),
                    PRMESANT = table.Column<double>(nullable: true),
                    PRDESCONV = table.Column<string>(nullable: true),
                    PRPOPULAR = table.Column<string>(nullable: true),
                    CODESTA = table.Column<string>(nullable: true),
                    CODFIS = table.Column<string>(nullable: true),
                    SECAO = table.Column<string>(nullable: true),
                    PRPIS = table.Column<string>(nullable: true),
                    VENDATU = table.Column<double>(nullable: true),
                    VENDANT = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NEWPROD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NEWTAB",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NEWTAB = table.Column<string>(nullable: true),
                    MESANO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NEWTAB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NFE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CAMPO = table.Column<string>(nullable: true),
                    CODIGO = table.Column<string>(nullable: true),
                    DESCRICAO = table.Column<string>(nullable: true),
                    QTDE = table.Column<string>(nullable: true),
                    VALOR = table.Column<string>(nullable: true),
                    VLTOT = table.Column<string>(nullable: true),
                    NCM = table.Column<string>(nullable: true),
                    IMP = table.Column<string>(nullable: true),
                    ICMS = table.Column<string>(nullable: true),
                    PRCDIMP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NFE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NOTA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_FISCAL = table.Column<string>(nullable: true),
                    CLIENTE = table.Column<string>(nullable: true),
                    NVALOR = table.Column<double>(nullable: true),
                    BASE = table.Column<double>(nullable: true),
                    ICMS = table.Column<double>(nullable: true),
                    BASESUB = table.Column<double>(nullable: true),
                    ICMSSUB = table.Column<double>(nullable: true),
                    NBASE7 = table.Column<double>(nullable: true),
                    NICMS7 = table.Column<double>(nullable: true),
                    NBASE12 = table.Column<double>(nullable: true),
                    NICMS12 = table.Column<double>(nullable: true),
                    NBASE18 = table.Column<double>(nullable: true),
                    NICMS18 = table.Column<double>(nullable: true),
                    NBASE25 = table.Column<double>(nullable: true),
                    NICMS25 = table.Column<double>(nullable: true),
                    NATUREZA = table.Column<string>(nullable: true),
                    N_NATU = table.Column<string>(nullable: true),
                    NDATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    NCANCELADA = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NOTAF",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NUM_NOTA = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTAF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NPED",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NUMPED = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NPED", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NUMPED",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FORNEC = table.Column<string>(nullable: true),
                    PRZPAGTO = table.Column<string>(nullable: true),
                    DESCONTO = table.Column<double>(nullable: true),
                    NUMERO = table.Column<string>(nullable: true),
                    PRZENTREGA = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NUMPED", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NumTmp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NUMERO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumTmp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PED0204",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRCODI = table.Column<string>(nullable: true),
                    PRBARRA = table.Column<string>(nullable: true),
                    PRDESC = table.Column<string>(nullable: true),
                    CODINT = table.Column<string>(nullable: true),
                    MLOJA1 = table.Column<double>(nullable: true),
                    ELOJA1 = table.Column<double>(nullable: true),
                    NLOJA1 = table.Column<double>(nullable: true),
                    MLOJA2 = table.Column<double>(nullable: true),
                    ELOJA2 = table.Column<double>(nullable: true),
                    NLOJA2 = table.Column<double>(nullable: true),
                    MLOJA3 = table.Column<double>(nullable: true),
                    ELOJA3 = table.Column<double>(nullable: true),
                    NLOJA3 = table.Column<double>(nullable: true),
                    MLOJA4 = table.Column<double>(nullable: true),
                    ELOJA4 = table.Column<double>(nullable: true),
                    NLOJA4 = table.Column<double>(nullable: true),
                    VALOR = table.Column<double>(nullable: true),
                    FORN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PED0204", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PED0301",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRCODI = table.Column<string>(nullable: true),
                    PRBARRA = table.Column<string>(nullable: true),
                    PRDESC = table.Column<string>(nullable: true),
                    CODINT = table.Column<string>(nullable: true),
                    MLOJA1 = table.Column<double>(nullable: true),
                    ELOJA1 = table.Column<double>(nullable: true),
                    NLOJA1 = table.Column<double>(nullable: true),
                    MLOJA2 = table.Column<double>(nullable: true),
                    ELOJA2 = table.Column<double>(nullable: true),
                    NLOJA2 = table.Column<double>(nullable: true),
                    MLOJA3 = table.Column<double>(nullable: true),
                    ELOJA3 = table.Column<double>(nullable: true),
                    NLOJA3 = table.Column<double>(nullable: true),
                    MLOJA4 = table.Column<double>(nullable: true),
                    ELOJA4 = table.Column<double>(nullable: true),
                    NLOJA4 = table.Column<double>(nullable: true),
                    VALOR = table.Column<double>(nullable: true),
                    FORN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PED0301", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PED0406",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRCODI = table.Column<string>(nullable: true),
                    PRBARRA = table.Column<string>(nullable: true),
                    PRDESC = table.Column<string>(nullable: true),
                    CODINT = table.Column<string>(nullable: true),
                    MLOJA1 = table.Column<double>(nullable: true),
                    ELOJA1 = table.Column<double>(nullable: true),
                    NLOJA1 = table.Column<double>(nullable: true),
                    MLOJA2 = table.Column<double>(nullable: true),
                    ELOJA2 = table.Column<double>(nullable: true),
                    NLOJA2 = table.Column<double>(nullable: true),
                    MLOJA3 = table.Column<double>(nullable: true),
                    ELOJA3 = table.Column<double>(nullable: true),
                    NLOJA3 = table.Column<double>(nullable: true),
                    MLOJA4 = table.Column<double>(nullable: true),
                    ELOJA4 = table.Column<double>(nullable: true),
                    NLOJA4 = table.Column<double>(nullable: true),
                    VALOR = table.Column<double>(nullable: true),
                    FORN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PED0406", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PED1103",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRCODI = table.Column<string>(nullable: true),
                    PRBARRA = table.Column<string>(nullable: true),
                    PRDESC = table.Column<string>(nullable: true),
                    CODINT = table.Column<string>(nullable: true),
                    MLOJA1 = table.Column<double>(nullable: true),
                    ELOJA1 = table.Column<double>(nullable: true),
                    NLOJA1 = table.Column<double>(nullable: true),
                    MLOJA2 = table.Column<double>(nullable: true),
                    ELOJA2 = table.Column<double>(nullable: true),
                    NLOJA2 = table.Column<double>(nullable: true),
                    MLOJA3 = table.Column<double>(nullable: true),
                    ELOJA3 = table.Column<double>(nullable: true),
                    NLOJA3 = table.Column<double>(nullable: true),
                    MLOJA4 = table.Column<double>(nullable: true),
                    ELOJA4 = table.Column<double>(nullable: true),
                    NLOJA4 = table.Column<double>(nullable: true),
                    VALOR = table.Column<double>(nullable: true),
                    FORN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PED1103", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PED1406",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRCODI = table.Column<string>(nullable: true),
                    PRBARRA = table.Column<string>(nullable: true),
                    PRDESC = table.Column<string>(nullable: true),
                    CODINT = table.Column<string>(nullable: true),
                    MLOJA1 = table.Column<double>(nullable: true),
                    ELOJA1 = table.Column<double>(nullable: true),
                    NLOJA1 = table.Column<double>(nullable: true),
                    MLOJA2 = table.Column<double>(nullable: true),
                    ELOJA2 = table.Column<double>(nullable: true),
                    NLOJA2 = table.Column<double>(nullable: true),
                    MLOJA3 = table.Column<double>(nullable: true),
                    ELOJA3 = table.Column<double>(nullable: true),
                    NLOJA3 = table.Column<double>(nullable: true),
                    MLOJA4 = table.Column<double>(nullable: true),
                    ELOJA4 = table.Column<double>(nullable: true),
                    NLOJA4 = table.Column<double>(nullable: true),
                    VALOR = table.Column<double>(nullable: true),
                    FORN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PED1406", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PED1912",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRCODI = table.Column<string>(nullable: true),
                    PRBARRA = table.Column<string>(nullable: true),
                    PRDESC = table.Column<string>(nullable: true),
                    CODINT = table.Column<string>(nullable: true),
                    MLOJA1 = table.Column<double>(nullable: true),
                    ELOJA1 = table.Column<double>(nullable: true),
                    NLOJA1 = table.Column<double>(nullable: true),
                    MLOJA2 = table.Column<double>(nullable: true),
                    ELOJA2 = table.Column<double>(nullable: true),
                    NLOJA2 = table.Column<double>(nullable: true),
                    MLOJA3 = table.Column<double>(nullable: true),
                    ELOJA3 = table.Column<double>(nullable: true),
                    NLOJA3 = table.Column<double>(nullable: true),
                    MLOJA4 = table.Column<double>(nullable: true),
                    ELOJA4 = table.Column<double>(nullable: true),
                    NLOJA4 = table.Column<double>(nullable: true),
                    VALOR = table.Column<double>(nullable: true),
                    FORN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PED1912", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PEDIDOS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRCODI = table.Column<string>(nullable: true),
                    PRQTDE = table.Column<double>(nullable: true),
                    PRCDLA = table.Column<string>(nullable: true),
                    PRFABR = table.Column<double>(nullable: true),
                    STATUS = table.Column<string>(nullable: true),
                    PRDATA = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEDIDOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PRODEXTR",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRCODI = table.Column<string>(nullable: true),
                    PRDESC = table.Column<string>(nullable: true),
                    PRCONS = table.Column<double>(nullable: true),
                    CONCOR1 = table.Column<double>(nullable: true),
                    CONCOR2 = table.Column<double>(nullable: true),
                    CONCOR3 = table.Column<double>(nullable: true),
                    CONCOR4 = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODEXTR", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PRODUTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false),
                    PRCODI = table.Column<string>(nullable: true),
                    PRBARRA = table.Column<string>(nullable: true),
                    PRREG = table.Column<string>(nullable: true),
                    PRDESC = table.Column<string>(nullable: true),
                    PRLOTE = table.Column<string>(nullable: true),
                    PRPOS = table.Column<string>(nullable: true),
                    PRSAL = table.Column<string>(nullable: true),
                    PRNEUTRO = table.Column<string>(nullable: true),
                    PRCDLA = table.Column<string>(nullable: true),
                    PRNOLA = table.Column<string>(nullable: true),
                    PRCONS = table.Column<double>(nullable: true),
                    PRCONSCV = table.Column<double>(nullable: true),
                    PRFABR = table.Column<double>(nullable: true),
                    PRFIXA = table.Column<string>(nullable: true),
                    PRPROMO = table.Column<double>(nullable: true),
                    VLCOMIS = table.Column<double>(nullable: true),
                    PRESTQ = table.Column<double>(nullable: true),
                    PRINICIAL = table.Column<double>(nullable: true),
                    PRFINAL = table.Column<double>(nullable: true),
                    PRTESTQ = table.Column<double>(nullable: true),
                    PRCDSE = table.Column<string>(nullable: true),
                    PRLOCA = table.Column<string>(nullable: true),
                    PRNOSE = table.Column<string>(nullable: true),
                    PRETIQ = table.Column<string>(nullable: true),
                    CODDCB = table.Column<string>(nullable: true),
                    ETBARRA = table.Column<string>(nullable: true),
                    ETGRAF = table.Column<string>(nullable: true),
                    PRPRET = table.Column<string>(nullable: true),
                    PRPORTA = table.Column<string>(nullable: true),
                    PRSITU = table.Column<string>(nullable: true),
                    PRULTE = table.Column<double>(nullable: true),
                    PRDTUL = table.Column<DateTime>(type: "datetime", nullable: true),
                    PRCDDT = table.Column<DateTime>(type: "datetime", nullable: true),
                    PRDATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    PRCDLUCR = table.Column<double>(nullable: true),
                    PRICMS = table.Column<double>(nullable: true),
                    TIPO = table.Column<string>(nullable: true),
                    DESC_MAX = table.Column<double>(nullable: true),
                    COMISSAO = table.Column<double>(nullable: true),
                    EST_MINIMO = table.Column<double>(nullable: true),
                    PRCDIMP = table.Column<string>(nullable: true),
                    PRCDIMP2 = table.Column<string>(nullable: true),
                    PREMB = table.Column<double>(nullable: true),
                    PRENTR = table.Column<double>(nullable: true),
                    UL_VEN = table.Column<DateTime>(type: "datetime", nullable: true),
                    ULTPED = table.Column<DateTime>(type: "datetime", nullable: true),
                    ULTFOR = table.Column<string>(nullable: true),
                    PRCLAS = table.Column<string>(nullable: true),
                    PRMESANT = table.Column<double>(nullable: true),
                    ULTPRECO = table.Column<double>(nullable: true),
                    PRDESCONV = table.Column<string>(nullable: true),
                    PRPOPULAR = table.Column<string>(nullable: true),
                    CODESTA = table.Column<string>(nullable: true),
                    PRPRINCI = table.Column<string>(nullable: true),
                    CODFIS = table.Column<string>(nullable: true),
                    SECAO = table.Column<string>(nullable: true),
                    PRPIS = table.Column<string>(nullable: true),
                    PRUN = table.Column<string>(nullable: true),
                    PRNCMS = table.Column<string>(nullable: true),
                    PRVALID = table.Column<DateTime>(type: "datetime", nullable: true),
                    VENDATU = table.Column<double>(nullable: true),
                    VENDANT = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PSICO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRCODI = table.Column<string>(nullable: true),
                    TICKET = table.Column<string>(nullable: true),
                    PRREG = table.Column<string>(nullable: true),
                    BARRAS = table.Column<string>(nullable: true),
                    PRDESC = table.Column<string>(nullable: true),
                    RECEITA = table.Column<string>(nullable: true),
                    TPRECEITA = table.Column<string>(nullable: true),
                    CRM = table.Column<string>(nullable: true),
                    NOMEMED = table.Column<string>(nullable: true),
                    TPCONS = table.Column<string>(nullable: true),
                    UFCONS = table.Column<string>(nullable: true),
                    LOTE = table.Column<string>(nullable: true),
                    QTDE = table.Column<double>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    TIPO = table.Column<string>(nullable: true),
                    MOTIVO = table.Column<string>(nullable: true),
                    USOMED = table.Column<string>(nullable: true),
                    PORTA = table.Column<string>(nullable: true),
                    RG = table.Column<string>(nullable: true),
                    ORGAO = table.Column<string>(nullable: true),
                    PACIENTE = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true),
                    EMISSAO = table.Column<DateTime>(type: "datetime", nullable: true),
                    NF = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true),
                    FORNEC = table.Column<string>(nullable: true),
                    FONE = table.Column<string>(nullable: true),
                    NOME = table.Column<string>(nullable: true),
                    TPMED = table.Column<string>(nullable: true),
                    SEXO = table.Column<string>(nullable: true),
                    CID = table.Column<string>(nullable: true),
                    IDADE = table.Column<string>(nullable: true),
                    TPIDADE = table.Column<string>(nullable: true),
                    PROLONG = table.Column<string>(nullable: true),
                    UNIDADE = table.Column<string>(nullable: true),
                    NASC = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSICO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RANCLIQT",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRCODI = table.Column<string>(nullable: true),
                    PRQTDE = table.Column<double>(nullable: true),
                    VL_UNIT = table.Column<double>(nullable: true),
                    TOT_DESCON = table.Column<double>(nullable: true),
                    TICKET = table.Column<string>(nullable: true),
                    BACODI = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    TIPO = table.Column<string>(nullable: true),
                    CANCELADO = table.Column<string>(nullable: true),
                    VL_TOT = table.Column<double>(nullable: true),
                    TOT_COMIS = table.Column<double>(nullable: true),
                    CODCLI = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RANCLIQT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RANCLIVL",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_FISCAL = table.Column<string>(nullable: true),
                    TICKET = table.Column<string>(nullable: true),
                    TOT_VEN = table.Column<double>(nullable: true),
                    TIPO = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    BACODI = table.Column<string>(nullable: true),
                    CANCELADO = table.Column<string>(nullable: true),
                    CAIXA = table.Column<string>(nullable: true),
                    HORA = table.Column<string>(nullable: true),
                    CODCLI = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RANCLIVL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RECONST",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ARQCoreVO = table.Column<string>(nullable: true),
                    POSICAO = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    NECESSITA = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RECONST", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "REDUCAO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RZAUT = table.Column<string>(nullable: true),
                    GTDA = table.Column<string>(nullable: true),
                    CANCELA = table.Column<string>(nullable: true),
                    DESCONTO = table.Column<string>(nullable: true),
                    TRIBUTO = table.Column<string>(nullable: true),
                    SUPRI = table.Column<string>(nullable: true),
                    NSI = table.Column<string>(nullable: true),
                    CNSI = table.Column<string>(nullable: true),
                    COO = table.Column<string>(nullable: true),
                    CNS = table.Column<string>(nullable: true),
                    ALIQUOTA = table.Column<string>(nullable: true),
                    DATA = table.Column<string>(nullable: true),
                    ACRESC = table.Column<string>(nullable: true),
                    ACRESFIN = table.Column<string>(nullable: true),
                    SANGRIA = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REDUCAO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "relator",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RELATORIO = table.Column<string>(nullable: true),
                    NIVEL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_relator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResAno",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MES_REF = table.Column<string>(nullable: true),
                    CLI_ATDS = table.Column<double>(nullable: true),
                    VEN_MES = table.Column<double>(nullable: true),
                    TOT_ESTOQ = table.Column<double>(nullable: true),
                    DIASTRAB = table.Column<double>(nullable: true),
                    ENTRADAS = table.Column<double>(nullable: true),
                    DESCREC = table.Column<double>(nullable: true),
                    VEN_FIADO = table.Column<double>(nullable: true),
                    REC_FIADO = table.Column<double>(nullable: true),
                    VDA_VISTA = table.Column<double>(nullable: true),
                    VDA_CONV = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResAno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RETIRADA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    VALORDH = table.Column<double>(nullable: true),
                    VALORCH = table.Column<double>(nullable: true),
                    HORA = table.Column<string>(nullable: true),
                    CAIXA = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RETIRADA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SAL",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SALCOD = table.Column<string>(nullable: true),
                    SALNOME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SECAO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SECODI = table.Column<string>(nullable: true),
                    SENOME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SECAO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SENHA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SEN = table.Column<string>(nullable: true),
                    SENCHEQ = table.Column<string>(nullable: true),
                    SENCIT = table.Column<string>(nullable: true),
                    SENCLICH = table.Column<string>(nullable: true),
                    SENCLIP = table.Column<string>(nullable: true),
                    SENCONT = table.Column<string>(nullable: true),
                    SENDATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    SENDEFA = table.Column<string>(nullable: true),
                    SENDESC = table.Column<double>(nullable: true),
                    SENDESC1 = table.Column<double>(nullable: true),
                    SENDESC2 = table.Column<double>(nullable: true),
                    SENDESC3 = table.Column<double>(nullable: true),
                    SENDESC4 = table.Column<double>(nullable: true),
                    SENDESC5 = table.Column<double>(nullable: true),
                    SENDESC6 = table.Column<double>(nullable: true),
                    SENDIA = table.Column<double>(nullable: true),
                    SENESTQ = table.Column<string>(nullable: true),
                    SENETQ = table.Column<string>(nullable: true),
                    SENETQB = table.Column<string>(nullable: true),
                    SENETQE = table.Column<string>(nullable: true),
                    SENETQP = table.Column<string>(nullable: true),
                    SENFIA = table.Column<string>(nullable: true),
                    SENFIACR = table.Column<double>(nullable: true),
                    SENFIATR = table.Column<double>(nullable: true),
                    SENFIS = table.Column<string>(nullable: true),
                    SENLIN = table.Column<double>(nullable: true),
                    SENMAN = table.Column<string>(nullable: true),
                    SENMDPRINT = table.Column<double>(nullable: true),
                    SENMULTA = table.Column<double>(nullable: true),
                    SENNIV = table.Column<string>(nullable: true),
                    SENPAR = table.Column<string>(nullable: true),
                    SENPCLI = table.Column<DateTime>(type: "datetime", nullable: true),
                    SENPME = table.Column<double>(nullable: true),
                    SENPONTO = table.Column<double>(nullable: true),
                    SENPORT = table.Column<string>(nullable: true),
                    SENPRINT = table.Column<string>(nullable: true),
                    SENPROT = table.Column<string>(nullable: true),
                    SENREC = table.Column<string>(nullable: true),
                    SENREL = table.Column<string>(nullable: true),
                    SENREPETE = table.Column<string>(nullable: true),
                    SENVER = table.Column<string>(nullable: true),
                    SENVLPON = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SENHA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SERVICO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SVCODI = table.Column<string>(nullable: true),
                    SVDESC = table.Column<string>(nullable: true),
                    SVPREC = table.Column<double>(nullable: true),
                    SVVEN1 = table.Column<double>(nullable: true),
                    SVVEN2 = table.Column<double>(nullable: true),
                    SVCOMB = table.Column<double>(nullable: true),
                    SVPR01 = table.Column<string>(nullable: true),
                    SVPR02 = table.Column<string>(nullable: true),
                    SVPR03 = table.Column<string>(nullable: true),
                    SVPR04 = table.Column<string>(nullable: true),
                    SVPR05 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERVICO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SISTEMA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USUARIO = table.Column<string>(nullable: true),
                    TICKET = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SISTEMA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SLPHARMA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RECONST = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SLPHARMA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SUBSECAO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SUBSECODI = table.Column<string>(nullable: true),
                    SUBSENOME = table.Column<string>(nullable: true),
                    SUBSEPREC = table.Column<string>(nullable: true),
                    SECAOPERT = table.Column<string>(nullable: true),
                    SUBSELUCR = table.Column<double>(nullable: true),
                    VALREC = table.Column<double>(nullable: true),
                    SUBIMPOST = table.Column<double>(nullable: true),
                    SUBNCM = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUBSECAO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TABELA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ABC = table.Column<string>(nullable: true),
                    CTR = table.Column<string>(nullable: true),
                    NOM = table.Column<string>(nullable: true),
                    DES = table.Column<string>(nullable: true),
                    PLA1 = table.Column<double>(nullable: true),
                    PCO1 = table.Column<double>(nullable: true),
                    FRA1 = table.Column<double>(nullable: true),
                    UNI = table.Column<double>(nullable: true),
                    IPI = table.Column<double>(nullable: true),
                    DTVIG = table.Column<DateTime>(type: "datetime", nullable: true),
                    NEUTRO = table.Column<string>(nullable: true),
                    NEGPOS = table.Column<string>(nullable: true),
                    CUSTOM = table.Column<string>(nullable: true),
                    MED_DES = table.Column<string>(nullable: true),
                    MED_APR = table.Column<string>(nullable: true),
                    MED_PRINCI = table.Column<string>(nullable: true),
                    MED_REGIMS = table.Column<string>(nullable: true),
                    LAB_NOM = table.Column<string>(nullable: true),
                    BARRA = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TABELA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TEMP",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRCODI = table.Column<string>(nullable: true),
                    DESCRICAO = table.Column<string>(nullable: true),
                    PRCONS = table.Column<double>(nullable: true),
                    DESCONTO = table.Column<double>(nullable: true),
                    PRCONSD = table.Column<double>(nullable: true),
                    VL_TOTAL = table.Column<double>(nullable: true),
                    QTDE = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEMP", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TEMPO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRCODI = table.Column<string>(nullable: true),
                    DESCRICAO = table.Column<string>(nullable: true),
                    QTDE = table.Column<double>(nullable: true),
                    PRCONS = table.Column<double>(nullable: true),
                    DESCONTO = table.Column<double>(nullable: true),
                    ESTOQUE = table.Column<double>(nullable: true),
                    PEDIDO = table.Column<string>(nullable: true),
                    PRCONSD = table.Column<double>(nullable: true),
                    VL_TOTAL = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEMPO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TICKET",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TICKET = table.Column<string>(nullable: true),
                    ECF = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TICKET", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TRANSFER",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TRDATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    BALCON = table.Column<string>(nullable: true),
                    PRCODI = table.Column<string>(nullable: true),
                    QTDE = table.Column<double>(nullable: true),
                    PRCONS = table.Column<double>(nullable: true),
                    ETIQUETA = table.Column<string>(nullable: true),
                    IMPRESSO = table.Column<string>(nullable: true),
                    FILCODI = table.Column<string>(nullable: true),
                    HORA = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRANSFER", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TROCO1",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TROCO_INI = table.Column<double>(nullable: true),
                    INITROCO = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TROCO1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TROCO10",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TROCO_INI = table.Column<double>(nullable: true),
                    INITROCO = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TROCO10", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TROCO11",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TROCO_INI = table.Column<double>(nullable: true),
                    INITROCO = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TROCO11", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TROCO12",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TROCO_INI = table.Column<double>(nullable: true),
                    INITROCO = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TROCO12", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TROCO13",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TROCO_INI = table.Column<double>(nullable: true),
                    INITROCO = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TROCO13", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TROCO14",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TROCO_INI = table.Column<double>(nullable: true),
                    INITROCO = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TROCO14", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TROCO15",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TROCO_INI = table.Column<double>(nullable: true),
                    INITROCO = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TROCO15", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TROCO16",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TROCO_INI = table.Column<double>(nullable: true),
                    INITROCO = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TROCO16", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TROCO17",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TROCO_INI = table.Column<double>(nullable: true),
                    INITROCO = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TROCO17", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TROCO18",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TROCO_INI = table.Column<double>(nullable: true),
                    INITROCO = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TROCO18", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TROCO19",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TROCO_INI = table.Column<double>(nullable: true),
                    INITROCO = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TROCO19", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TROCO2",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TROCO_INI = table.Column<double>(nullable: true),
                    INITROCO = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TROCO2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TROCO20",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TROCO_INI = table.Column<double>(nullable: true),
                    INITROCO = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TROCO20", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TROCO3",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TROCO_INI = table.Column<double>(nullable: true),
                    INITROCO = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TROCO3", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TROCO4",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TROCO_INI = table.Column<double>(nullable: true),
                    INITROCO = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TROCO4", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TROCO5",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TROCO_INI = table.Column<double>(nullable: true),
                    INITROCO = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TROCO5", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TROCO6",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TROCO_INI = table.Column<double>(nullable: true),
                    INITROCO = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TROCO6", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TROCO7",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TROCO_INI = table.Column<double>(nullable: true),
                    INITROCO = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TROCO7", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TROCO8",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TROCO_INI = table.Column<double>(nullable: true),
                    INITROCO = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TROCO8", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TROCO9",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TROCO_INI = table.Column<double>(nullable: true),
                    INITROCO = table.Column<string>(nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TROCO9", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "URV",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    VALOR = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_URV", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USEFARMA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(nullable: true),
                    SENHA = table.Column<string>(nullable: true),
                    NIVEL = table.Column<string>(nullable: true),
                    ACESSO1 = table.Column<string>(nullable: true),
                    ACESSO2 = table.Column<string>(nullable: true),
                    ACESSO3 = table.Column<string>(nullable: true),
                    ACESSO4 = table.Column<string>(nullable: true),
                    ACESSO5 = table.Column<string>(nullable: true),
                    ACESSO6 = table.Column<string>(nullable: true),
                    ACESSO7 = table.Column<string>(nullable: true),
                    ACESSO8 = table.Column<string>(nullable: true),
                    ACESSO9 = table.Column<string>(nullable: true),
                    ACESSO10 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USEFARMA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USOINT",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    PRCODI = table.Column<string>(nullable: true),
                    QTDE = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USOINT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: true),
                    Cpf = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Client_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: true),
                    Cnpj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manufacturers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false),
                    AddressId = table.Column<int>(nullable: true),
                    SupplierName = table.Column<string>(nullable: true),
                    Cnpj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplier_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false),
                    SupplierId = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    DrugMaturityDate = table.Column<DateTime>(nullable: true),
                    NfNumber = table.Column<string>(nullable: true),
                    NfEmissionDate = table.Column<DateTime>(nullable: true),
                    Totalcost = table.Column<decimal>(nullable: true),
                    LotCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockEntries_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false),
                    Ncm = table.Column<string>(nullable: true),
                    QuantityInStock = table.Column<int>(nullable: true),
                    ReorderLevel = table.Column<int>(nullable: true),
                    ReorderQuantity = table.Column<int>(nullable: true),
                    EndCustomerPrice = table.Column<decimal>(nullable: true),
                    CostPrice = table.Column<decimal>(nullable: false),
                    SavingPercentage = table.Column<decimal>(nullable: false),
                    BarCode = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Section = table.Column<string>(nullable: true),
                    MaxDiscountPercentage = table.Column<decimal>(nullable: false),
                    DiscountValue = table.Column<decimal>(nullable: false),
                    Commission = table.Column<string>(nullable: true),
                    ICMS = table.Column<decimal>(nullable: false),
                    MinimumStock = table.Column<int>(nullable: false),
                    MainSupplierName = table.Column<string>(nullable: true),
                    ProdutoId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    BaseDrugId = table.Column<int>(nullable: true),
                    SupplierId = table.Column<int>(nullable: true),
                    PrCdse = table.Column<string>(nullable: true),
                    ManufacturerId = table.Column<int>(nullable: true),
                    ManufacturerName = table.Column<string>(nullable: true),
                    DrugName = table.Column<string>(nullable: true),
                    CommercialName = table.Column<string>(nullable: true),
                    Classification = table.Column<string>(nullable: true),
                    DrugCost = table.Column<decimal>(nullable: true),
                    Dosage = table.Column<string>(nullable: true),
                    AbsoluteDosageInMg = table.Column<double>(nullable: true),
                    ActivePrinciple = table.Column<string>(nullable: true),
                    LotNumber = table.Column<string>(nullable: true),
                    PrescriptionNeeded = table.Column<bool>(nullable: true),
                    IsPriceFixed = table.Column<bool>(nullable: true),
                    DigitalBuleLink = table.Column<string>(nullable: true),
                    StockEntryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_StockEntries_StockEntryId",
                        column: x => x.StockEntryId,
                        principalTable: "StockEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_PRODUTO_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "PRODUTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DrugInformation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false),
                    DrugId = table.Column<int>(nullable: true),
                    Indication = table.Column<string>(nullable: true),
                    CounterIndication = table.Column<string>(nullable: true),
                    HowWorks = table.Column<string>(nullable: true),
                    HowToUse = table.Column<string>(nullable: true),
                    TypeOfUse = table.Column<string>(nullable: true),
                    MinimalAgeOfUse = table.Column<int>(nullable: true),
                    Substances = table.Column<string>(nullable: true),
                    UserBule = table.Column<string>(nullable: true),
                    ProfessionalBule = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrugInformation_Products_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductPrice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Pricestartdate = table.Column<DateTimeOffset>(nullable: true),
                    EndCustomerDrugPrice = table.Column<decimal>(nullable: false),
                    CostPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPrice_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductShelfLife",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    StockEntryId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductShelfLife", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductShelfLife_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductStockEntry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    StockEntryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStockEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductStockEntry_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductStockEntry_StockEntries_StockEntryId",
                        column: x => x.StockEntryId,
                        principalTable: "StockEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSupplier",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    SupplierId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSupplier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSupplier_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductSupplier_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Billings",
                columns: new[] { "Id", "BeneficiaryId", "BeneficiaryName", "CreatedAt", "Discount", "EndDate", "IsDeleted", "IsPaid", "LastUpdatedOn", "PersonType", "Price", "UniqueCode" },
                values: new object[] { 1, 0, "empresa", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTime(2020, 6, 4, 23, 45, 43, 473, DateTimeKind.Utc).AddTicks(1681), false, false, new DateTimeOffset(new DateTime(2020, 6, 4, 23, 45, 43, 473, DateTimeKind.Unspecified).AddTicks(1022), new TimeSpan(0, 0, 0, 0, 0)), 0, 12.99m, null });

            migrationBuilder.InsertData(
                table: "Billings",
                columns: new[] { "Id", "BeneficiaryId", "BeneficiaryName", "CreatedAt", "Discount", "EndDate", "IsDeleted", "IsPaid", "LastUpdatedOn", "PersonType", "Price", "UniqueCode" },
                values: new object[] { 2, 0, "empresa 2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTime(2020, 6, 4, 23, 45, 43, 473, DateTimeKind.Utc).AddTicks(3824), false, false, new DateTimeOffset(new DateTime(2020, 6, 4, 23, 45, 43, 473, DateTimeKind.Unspecified).AddTicks(3817), new TimeSpan(0, 0, 0, 0, 0)), 0, 22.99m, null });

            migrationBuilder.CreateIndex(
                name: "IX_Client_AddressId",
                table: "Client",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugInformation_DrugId",
                table: "DrugInformation",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_AddressId",
                table: "Manufacturers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrice_ProductId",
                table: "ProductPrice",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StockEntryId",
                table: "Products",
                column: "StockEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProdutoId",
                table: "Products",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductShelfLife_ProductId",
                table: "ProductShelfLife",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStockEntry_ProductId",
                table: "ProductStockEntry",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStockEntry_StockEntryId",
                table: "ProductStockEntry",
                column: "StockEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSupplier_ProductId",
                table: "ProductSupplier",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSupplier_SupplierId",
                table: "ProductSupplier",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_StockEntries_SupplierId",
                table: "StockEntries",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_AddressId",
                table: "Supplier",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AGENDA");

            migrationBuilder.DropTable(
                name: "BALCON");

            migrationBuilder.DropTable(
                name: "Billings");

            migrationBuilder.DropTable(
                name: "BRINDES");

            migrationBuilder.DropTable(
                name: "CADLAB");

            migrationBuilder.DropTable(
                name: "CADPROM");

            migrationBuilder.DropTable(
                name: "CAIXA");

            migrationBuilder.DropTable(
                name: "CANCDIA");

            migrationBuilder.DropTable(
                name: "CARTAO");

            migrationBuilder.DropTable(
                name: "CHDEVOL");

            migrationBuilder.DropTable(
                name: "Cheque");

            migrationBuilder.DropTable(
                name: "CLICHEQ");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "CLIENTE");

            migrationBuilder.DropTable(
                name: "CliMed");

            migrationBuilder.DropTable(
                name: "CLIPAGO");

            migrationBuilder.DropTable(
                name: "CONTAS");

            migrationBuilder.DropTable(
                name: "CONV");

            migrationBuilder.DropTable(
                name: "CONVENIO");

            migrationBuilder.DropTable(
                name: "DEBCLI");

            migrationBuilder.DropTable(
                name: "DELIVERY");

            migrationBuilder.DropTable(
                name: "DESPESAS");

            migrationBuilder.DropTable(
                name: "DrugInformation");

            migrationBuilder.DropTable(
                name: "EMPRESA");

            migrationBuilder.DropTable(
                name: "ENCOMEN");

            migrationBuilder.DropTable(
                name: "ENT");

            migrationBuilder.DropTable(
                name: "ENTPRO");

            migrationBuilder.DropTable(
                name: "ESTQ0045");

            migrationBuilder.DropTable(
                name: "ETIQPERF");

            migrationBuilder.DropTable(
                name: "ETIQPROM");

            migrationBuilder.DropTable(
                name: "ETIQUETA");

            migrationBuilder.DropTable(
                name: "FALTAS");

            migrationBuilder.DropTable(
                name: "FECHCONV");

            migrationBuilder.DropTable(
                name: "FILIAL");

            migrationBuilder.DropTable(
                name: "FUNCIO");

            migrationBuilder.DropTable(
                name: "HISTOR");

            migrationBuilder.DropTable(
                name: "IBPT");

            migrationBuilder.DropTable(
                name: "INVENT");

            migrationBuilder.DropTable(
                name: "LOGSYS");

            migrationBuilder.DropTable(
                name: "MALCLIEN");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "MERCTRAN");

            migrationBuilder.DropTable(
                name: "MOV");

            migrationBuilder.DropTable(
                name: "MOVM");

            migrationBuilder.DropTable(
                name: "MOVME");

            migrationBuilder.DropTable(
                name: "MOVMES");

            migrationBuilder.DropTable(
                name: "MOVNF");

            migrationBuilder.DropTable(
                name: "MOVPOP");

            migrationBuilder.DropTable(
                name: "NATUREZA");

            migrationBuilder.DropTable(
                name: "NEWCLI");

            migrationBuilder.DropTable(
                name: "NEWFUNC");

            migrationBuilder.DropTable(
                name: "NEWPREC");

            migrationBuilder.DropTable(
                name: "NEWPROD");

            migrationBuilder.DropTable(
                name: "NEWTAB");

            migrationBuilder.DropTable(
                name: "NFE");

            migrationBuilder.DropTable(
                name: "NOTA");

            migrationBuilder.DropTable(
                name: "NOTAF");

            migrationBuilder.DropTable(
                name: "NPED");

            migrationBuilder.DropTable(
                name: "NUMPED");

            migrationBuilder.DropTable(
                name: "NumTmp");

            migrationBuilder.DropTable(
                name: "PED0204");

            migrationBuilder.DropTable(
                name: "PED0301");

            migrationBuilder.DropTable(
                name: "PED0406");

            migrationBuilder.DropTable(
                name: "PED1103");

            migrationBuilder.DropTable(
                name: "PED1406");

            migrationBuilder.DropTable(
                name: "PED1912");

            migrationBuilder.DropTable(
                name: "PEDIDOS");

            migrationBuilder.DropTable(
                name: "PRODEXTR");

            migrationBuilder.DropTable(
                name: "ProductPrice");

            migrationBuilder.DropTable(
                name: "ProductShelfLife");

            migrationBuilder.DropTable(
                name: "ProductStockEntry");

            migrationBuilder.DropTable(
                name: "ProductSupplier");

            migrationBuilder.DropTable(
                name: "PSICO");

            migrationBuilder.DropTable(
                name: "RANCLIQT");

            migrationBuilder.DropTable(
                name: "RANCLIVL");

            migrationBuilder.DropTable(
                name: "RECONST");

            migrationBuilder.DropTable(
                name: "REDUCAO");

            migrationBuilder.DropTable(
                name: "relator");

            migrationBuilder.DropTable(
                name: "ResAno");

            migrationBuilder.DropTable(
                name: "RETIRADA");

            migrationBuilder.DropTable(
                name: "SAL");

            migrationBuilder.DropTable(
                name: "SECAO");

            migrationBuilder.DropTable(
                name: "SENHA");

            migrationBuilder.DropTable(
                name: "SERVICO");

            migrationBuilder.DropTable(
                name: "SISTEMA");

            migrationBuilder.DropTable(
                name: "SLPHARMA");

            migrationBuilder.DropTable(
                name: "SUBSECAO");

            migrationBuilder.DropTable(
                name: "TABELA");

            migrationBuilder.DropTable(
                name: "TEMP");

            migrationBuilder.DropTable(
                name: "TEMPO");

            migrationBuilder.DropTable(
                name: "TICKET");

            migrationBuilder.DropTable(
                name: "TRANSFER");

            migrationBuilder.DropTable(
                name: "TROCO1");

            migrationBuilder.DropTable(
                name: "TROCO10");

            migrationBuilder.DropTable(
                name: "TROCO11");

            migrationBuilder.DropTable(
                name: "TROCO12");

            migrationBuilder.DropTable(
                name: "TROCO13");

            migrationBuilder.DropTable(
                name: "TROCO14");

            migrationBuilder.DropTable(
                name: "TROCO15");

            migrationBuilder.DropTable(
                name: "TROCO16");

            migrationBuilder.DropTable(
                name: "TROCO17");

            migrationBuilder.DropTable(
                name: "TROCO18");

            migrationBuilder.DropTable(
                name: "TROCO19");

            migrationBuilder.DropTable(
                name: "TROCO2");

            migrationBuilder.DropTable(
                name: "TROCO20");

            migrationBuilder.DropTable(
                name: "TROCO3");

            migrationBuilder.DropTable(
                name: "TROCO4");

            migrationBuilder.DropTable(
                name: "TROCO5");

            migrationBuilder.DropTable(
                name: "TROCO6");

            migrationBuilder.DropTable(
                name: "TROCO7");

            migrationBuilder.DropTable(
                name: "TROCO8");

            migrationBuilder.DropTable(
                name: "TROCO9");

            migrationBuilder.DropTable(
                name: "URV");

            migrationBuilder.DropTable(
                name: "USEFARMA");

            migrationBuilder.DropTable(
                name: "USOINT");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "StockEntries");

            migrationBuilder.DropTable(
                name: "PRODUTO");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
