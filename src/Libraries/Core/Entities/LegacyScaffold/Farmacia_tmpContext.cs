//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;

//namespace Core.Entities.LegacyScaffold
//{
//    public  class Farmacia_tmpContext : DbContext
//    {
//        public Farmacia_tmpContext()
//        {
//        }

//        public Farmacia_tmpContext(DbContextOptions<Farmacia_tmpContext> options)
//            : base(options)
//        {
//        }

//        public virtual DbSet<Agenda> Agenda { get; set; }
//        public virtual DbSet<Balcon> Balcon { get; set; }
//        public virtual DbSet<Brindes> Brindes { get; set; }
//        public virtual DbSet<Cadlab> Cadlab { get; set; }
//        public virtual DbSet<Cadprom> Cadprom { get; set; }
//        public virtual DbSet<Caixa> Caixa { get; set; }
//        public virtual DbSet<Cancdia> Cancdia { get; set; }
//        public virtual DbSet<Cartao> Cartao { get; set; }
//        public virtual DbSet<Chdevol> Chdevol { get; set; }
//        public virtual DbSet<Cheque> Cheque { get; set; }
//        public virtual DbSet<CliMed> CliMed { get; set; }
//        public virtual DbSet<Clicheq> Clicheq { get; set; }
//        public virtual DbSet<Cliente> Cliente { get; set; }
//        public virtual DbSet<Clipago> Clipago { get; set; }
//        public virtual DbSet<Contas> Contas { get; set; }
//        public virtual DbSet<Conv> Conv { get; set; }
//        public virtual DbSet<Convenio> Convenio { get; set; }
//        public virtual DbSet<Debcli> Debcli { get; set; }
//        public virtual DbSet<Delivery> Delivery { get; set; }
//        public virtual DbSet<Despesas> Despesas { get; set; }
//        public virtual DbSet<Empresa> Empresa { get; set; }
//        public virtual DbSet<Encomen> Encomen { get; set; }
//        public virtual DbSet<Ent> Ent { get; set; }
//        public virtual DbSet<Entpro> Entpro { get; set; }
//        public virtual DbSet<Estq0045> Estq0045 { get; set; }
//        public virtual DbSet<Etiqperf> Etiqperf { get; set; }
//        public virtual DbSet<Etiqprom> Etiqprom { get; set; }
//        public virtual DbSet<Etiqueta> Etiqueta { get; set; }
//        public virtual DbSet<Faltas> Faltas { get; set; }
//        public virtual DbSet<Fechconv> Fechconv { get; set; }
//        public virtual DbSet<Filial> Filial { get; set; }
//        public virtual DbSet<Funcio> Funcio { get; set; }
//        public virtual DbSet<Histor> Histor { get; set; }
//        public virtual DbSet<Ibpt> Ibpt { get; set; }
//        public virtual DbSet<Invent> Invent { get; set; }
//        public virtual DbSet<Logsys> Logsys { get; set; }
//        public virtual DbSet<Malclien> Malclien { get; set; }
//        public virtual DbSet<Merctran> Merctran { get; set; }
//        public virtual DbSet<Mov> Mov { get; set; }
//        public virtual DbSet<Movm> Movm { get; set; }
//        public virtual DbSet<Movme> Movme { get; set; }
//        public virtual DbSet<Movmes> Movmes { get; set; }
//        public virtual DbSet<Movnf> Movnf { get; set; }
//        public virtual DbSet<Movpop> Movpop { get; set; }
//        public virtual DbSet<Natureza> Natureza { get; set; }
//        public virtual DbSet<Newcli> Newcli { get; set; }
//        public virtual DbSet<Newfunc> Newfunc { get; set; }
//        public virtual DbSet<Newprec> Newprec { get; set; }
//        public virtual DbSet<Newprod> Newprod { get; set; }
//        public virtual DbSet<Newtab> Newtab { get; set; }
//        public virtual DbSet<Nfe> Nfe { get; set; }
//        public virtual DbSet<Nota> Nota { get; set; }
//        public virtual DbSet<Notaf> Notaf { get; set; }
//        public virtual DbSet<Nped> Nped { get; set; }
//        public virtual DbSet<NumTmp> NumTmp { get; set; }
//        public virtual DbSet<Numped> Numped { get; set; }
//        public virtual DbSet<Ped0204> Ped0204 { get; set; }
//        public virtual DbSet<Ped0301> Ped0301 { get; set; }
//        public virtual DbSet<Ped0406> Ped0406 { get; set; }
//        public virtual DbSet<Ped1103> Ped1103 { get; set; }
//        public virtual DbSet<Ped1406> Ped1406 { get; set; }
//        public virtual DbSet<Ped1912> Ped1912 { get; set; }
//        public virtual DbSet<Pedidos> Pedidos { get; set; }
//        public virtual DbSet<Prodextr> Prodextr { get; set; }
//        public virtual DbSet<Produto> Produto { get; set; }
//        public virtual DbSet<Psico> Psico { get; set; }
//        public virtual DbSet<Rancliqt> Rancliqt { get; set; }
//        public virtual DbSet<Ranclivl> Ranclivl { get; set; }
//        public virtual DbSet<Reconst> Reconst { get; set; }
//        public virtual DbSet<Reducao> Reducao { get; set; }
//        public virtual DbSet<Relator> Relator { get; set; }
//        public virtual DbSet<ResAno> ResAno { get; set; }
//        public virtual DbSet<Retirada> Retirada { get; set; }
//        public virtual DbSet<Sal> Sal { get; set; }
//        public virtual DbSet<Secao> Secao { get; set; }
//        public virtual DbSet<Senha> Senha { get; set; }
//        public virtual DbSet<Servico> Servico { get; set; }
//        public virtual DbSet<Sistema> Sistema { get; set; }
//        public virtual DbSet<Slpharma> Slpharma { get; set; }
//        public virtual DbSet<Subsecao> Subsecao { get; set; }
//        public virtual DbSet<Tabela> Tabela { get; set; }
//        public virtual DbSet<Temp> Temp { get; set; }
//        public virtual DbSet<Tempo> Tempo { get; set; }
//        public virtual DbSet<Ticket> Ticket { get; set; }
//        public virtual DbSet<Transfer> Transfer { get; set; }
//        public virtual DbSet<Troco1> Troco1 { get; set; }
//        public virtual DbSet<Troco10> Troco10 { get; set; }
//        public virtual DbSet<Troco11> Troco11 { get; set; }
//        public virtual DbSet<Troco12> Troco12 { get; set; }
//        public virtual DbSet<Troco13> Troco13 { get; set; }
//        public virtual DbSet<Troco14> Troco14 { get; set; }
//        public virtual DbSet<Troco15> Troco15 { get; set; }
//        public virtual DbSet<Troco16> Troco16 { get; set; }
//        public virtual DbSet<Troco17> Troco17 { get; set; }
//        public virtual DbSet<Troco18> Troco18 { get; set; }
//        public virtual DbSet<Troco19> Troco19 { get; set; }
//        public virtual DbSet<Troco2> Troco2 { get; set; }
//        public virtual DbSet<Troco20> Troco20 { get; set; }
//        public virtual DbSet<Troco3> Troco3 { get; set; }
//        public virtual DbSet<Troco4> Troco4 { get; set; }
//        public virtual DbSet<Troco5> Troco5 { get; set; }
//        public virtual DbSet<Troco6> Troco6 { get; set; }
//        public virtual DbSet<Troco7> Troco7 { get; set; }
//        public virtual DbSet<Troco8> Troco8 { get; set; }
//        public virtual DbSet<Troco9> Troco9 { get; set; }
//        public virtual DbSet<Urv> Urv { get; set; }
//        public virtual DbSet<Usefarma> Usefarma { get; set; }
//        public virtual DbSet<Usoint> Usoint { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBCorelder optionsBCorelder)
//        {
//            if (!optionsBCorelder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for gCoredance on storing connection strings.
//                optionsBCorelder.UseSqlServer("Data Source=DESKTOP-FTQLVQ6;Initial Catalog=Farmacia_tmp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
//            }
//        }

//        protected override void OnModelCreating(ModelBCorelder modelBCorelder)
//        {
//            modelBCorelder.Entity<Agenda>(entity =>
//            {
//                entity.ToTable("AGENDA");

//                entity.Property(e => e.Bairro).HasColumnName("BAIRRO");

//                entity.Property(e => e.Cep).HasColumnName("CEP");

//                entity.Property(e => e.Cidade).HasColumnName("CIDADE");

//                entity.Property(e => e.Codigo).HasColumnName("CODIGO");

//                entity.Property(e => e.Endereco).HasColumnName("ENDERECO");

//                entity.Property(e => e.Fone).HasColumnName("FONE");

//                entity.Property(e => e.Nome).HasColumnName("NOME");
//            });

//            modelBCorelder.Entity<Balcon>(entity =>
//            {
//                entity.ToTable("BALCON");

//                entity.Property(e => e.Bacodi).HasColumnName("BACODI");

//                entity.Property(e => e.Bacomi).HasColumnName("BACOMI");

//                entity.Property(e => e.Badevol).HasColumnName("BADEVOL");

//                entity.Property(e => e.Banome).HasColumnName("BANOME");

//                entity.Property(e => e.ComisAce).HasColumnName("COMIS_ACE");

//                entity.Property(e => e.ComisBo).HasColumnName("COMIS_BO");

//                entity.Property(e => e.ComisEti).HasColumnName("COMIS_ETI");

//                entity.Property(e => e.ComisOut).HasColumnName("COMIS_OUT");

//                entity.Property(e => e.ComisPer).HasColumnName("COMIS_PER");

//                entity.Property(e => e.ComisPerc).HasColumnName("COMIS_PERC");

//                entity.Property(e => e.ComisVar).HasColumnName("COMIS_VAR");

//                entity.Property(e => e.Cpf).HasColumnName("CPF");

//                entity.Property(e => e.Senha).HasColumnName("SENHA");
//            });

//            modelBCorelder.Entity<Brindes>(entity =>
//            {
//                entity.ToTable("BRINDES");

//                entity.Property(e => e.Codigo).HasColumnName("CODIGO");

//                entity.Property(e => e.Nome).HasColumnName("NOME");

//                entity.Property(e => e.Pontos).HasColumnName("PONTOS");

//                entity.Property(e => e.Qtde).HasColumnName("QTDE");
//            });

//            modelBCorelder.Entity<Cadlab>(entity =>
//            {
//                entity.ToTable("CADLAB");

//                entity.Property(e => e.DtAlter)
//                    .HasColumnName("DT_ALTER")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Foapel).HasColumnName("FOAPEL");

//                entity.Property(e => e.Fobair).HasColumnName("FOBAIR");

//                entity.Property(e => e.Focepe).HasColumnName("FOCEPE");

//                entity.Property(e => e.Focida).HasColumnName("FOCIDA");

//                entity.Property(e => e.Focont).HasColumnName("FOCONT");

//                entity.Property(e => e.Foende).HasColumnName("FOENDE");

//                entity.Property(e => e.Foesta).HasColumnName("FOESTA");

//                entity.Property(e => e.Fofaxe).HasColumnName("FOFAXE");

//                entity.Property(e => e.Foibge).HasColumnName("FOIBGE");

//                entity.Property(e => e.Fonome).HasColumnName("FONOME");

//                entity.Property(e => e.Fonume).HasColumnName("FONUME");

//                entity.Property(e => e.Fotel2).HasColumnName("FOTEL2");

//                entity.Property(e => e.Fotele).HasColumnName("FOTELE");

//                entity.Property(e => e.Labrev).HasColumnName("LABREV");

//                entity.Property(e => e.Lacgce).HasColumnName("LACGCE");

//                entity.Property(e => e.Lacodi).HasColumnName("LACODI");

//                entity.Property(e => e.Lacond).HasColumnName("LACOND");

//                entity.Property(e => e.Laiest).HasColumnName("LAIEST");

//                entity.Property(e => e.Laperc).HasColumnName("LAPERC");

//                entity.Property(e => e.Latipo).HasColumnName("LATIPO");

//                entity.Property(e => e.Laulno).HasColumnName("LAULNO");

//                entity.Property(e => e.Laultc).HasColumnName("LAULTC");

//                entity.Property(e => e.Nomarq).HasColumnName("NOMARQ");
//            });

//            modelBCorelder.Entity<Cadprom>(entity =>
//            {
//                entity.ToTable("CADPROM");

//                entity.Property(e => e.Fonome).HasColumnName("FONOME");

//                entity.Property(e => e.Fotele).HasColumnName("FOTELE");

//                entity.Property(e => e.Lacodi).HasColumnName("LACODI");

//                entity.Property(e => e.Valid)
//                    .HasColumnName("VALID")
//                    .HasColumnType("datetime");
//            });

//            modelBCorelder.Entity<Caixa>(entity =>
//            {
//                entity.ToTable("CAIXA");

//                entity.Property(e => e.CxAdm).HasColumnName("CX_ADM");

//                entity.Property(e => e.CxAtend).HasColumnName("CX_ATEND");

//                entity.Property(e => e.CxCart).HasColumnName("CX_CART");

//                entity.Property(e => e.CxData)
//                    .HasColumnName("CX_DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.CxRec)
//                    .HasColumnName("CX_REC")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.CxTipo).HasColumnName("CX_TIPO");

//                entity.Property(e => e.CxValor).HasColumnName("CX_VALOR");
//            });

//            modelBCorelder.Entity<Cancdia>(entity =>
//            {
//                entity.ToTable("CANCDIA");

//                entity.Property(e => e.Codemp).HasColumnName("CODEMP");

//                entity.Property(e => e.Codfun).HasColumnName("CODFUN");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Datac)
//                    .HasColumnName("DATAC")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Filial).HasColumnName("FILIAL");

//                entity.Property(e => e.Ticket).HasColumnName("TICKET");
//            });

//            modelBCorelder.Entity<Cartao>(entity =>
//            {
//                entity.ToTable("CARTAO");

//                entity.Property(e => e.Codigo).HasColumnName("CODIGO");

//                entity.Property(e => e.Nome).HasColumnName("NOME");

//                entity.Property(e => e.Parcel).HasColumnName("PARCEL");

//                entity.Property(e => e.Prazo).HasColumnName("PRAZO");

//                entity.Property(e => e.Qtde).HasColumnName("QTDE");

//                entity.Property(e => e.Taxa).HasColumnName("TAXA");
//            });

//            modelBCorelder.Entity<Chdevol>(entity =>
//            {
//                entity.ToTable("CHDEVOL");

//                entity.Property(e => e.Agencia).HasColumnName("AGENCIA");

//                entity.Property(e => e.Banco).HasColumnName("BANCO");

//                entity.Property(e => e.Cheque).HasColumnName("CHEQUE");

//                entity.Property(e => e.Cliente).HasColumnName("CLIENTE");

//                entity.Property(e => e.Conta).HasColumnName("CONTA");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Datae)
//                    .HasColumnName("DATAE")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Valor).HasColumnName("VALOR");
//            });

//            modelBCorelder.Entity<Cheque>(entity =>
//            {
//                entity.ToTable("CHEQUE");

//                entity.Property(e => e.Agencia).HasColumnName("AGENCIA");

//                entity.Property(e => e.Baixa).HasColumnName("BAIXA");

//                entity.Property(e => e.Banco).HasColumnName("BANCO");

//                entity.Property(e => e.Cheque1).HasColumnName("CHEQUE");

//                entity.Property(e => e.Cliente).HasColumnName("CLIENTE");

//                entity.Property(e => e.Conta).HasColumnName("CONTA");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Datae)
//                    .HasColumnName("DATAE")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Filial).HasColumnName("FILIAL");

//                entity.Property(e => e.Obs).HasColumnName("OBS");

//                entity.Property(e => e.Rg).HasColumnName("RG");

//                entity.Property(e => e.Situacao).HasColumnName("SITUACAO");

//                entity.Property(e => e.Telefone).HasColumnName("TELEFONE");

//                entity.Property(e => e.Ticket).HasColumnName("TICKET");

//                entity.Property(e => e.Valor).HasColumnName("VALOR");
//            });

//            modelBCorelder.Entity<CliMed>(entity =>
//            {
//                entity.ToTable("CLI_MED");

//                entity.Property(e => e.CpfCrm).HasColumnName("CPF_CRM");

//                entity.Property(e => e.Endereco).HasColumnName("ENDERECO");

//                entity.Property(e => e.Fone).HasColumnName("FONE");

//                entity.Property(e => e.Nome).HasColumnName("NOME");

//                entity.Property(e => e.Sexo).HasColumnName("SEXO");
//            });

//            modelBCorelder.Entity<Clicheq>(entity =>
//            {
//                entity.ToTable("CLICHEQ");

//                entity.Property(e => e.Bairro).HasColumnName("BAIRRO");

//                entity.Property(e => e.Cep).HasColumnName("CEP");

//                entity.Property(e => e.Cidade).HasColumnName("CIDADE");

//                entity.Property(e => e.Codigo).HasColumnName("CODIGO");

//                entity.Property(e => e.Cpf).HasColumnName("CPF");

//                entity.Property(e => e.Datanasc)
//                    .HasColumnName("DATANASC")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Endereco).HasColumnName("ENDERECO");

//                entity.Property(e => e.Fone).HasColumnName("FONE");

//                entity.Property(e => e.Nome).HasColumnName("NOME");

//                entity.Property(e => e.Rg).HasColumnName("RG");
//            });

//            modelBCorelder.Entity<Cliente>(entity =>
//            {
//                entity.ToTable("CLIENTE");

//                entity.Property(e => e.Clbairro).HasColumnName("CLBAIRRO");

//                entity.Property(e => e.Clcep).HasColumnName("CLCEP");

//                entity.Property(e => e.Clcida).HasColumnName("CLCIDA");

//                entity.Property(e => e.Clcodi).HasColumnName("CLCODI");

//                entity.Property(e => e.Clcompra)
//                    .HasColumnName("CLCOMPRA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Clcpf).HasColumnName("CLCPF");

//                entity.Property(e => e.Clcred).HasColumnName("CLCRED");

//                entity.Property(e => e.Cldebi).HasColumnName("CLDEBI");

//                entity.Property(e => e.Cldesc).HasColumnName("CLDESC");

//                entity.Property(e => e.Cldesmed).HasColumnName("CLDESMED");

//                entity.Property(e => e.Cldesper).HasColumnName("CLDESPER");

//                entity.Property(e => e.Clende).HasColumnName("CLENDE");

//                entity.Property(e => e.Clestado).HasColumnName("CLESTADO");

//                entity.Property(e => e.Cllime).HasColumnName("CLLIME");

//                entity.Property(e => e.Clnasc)
//                    .HasColumnName("CLNASC")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Clnome).HasColumnName("CLNOME");

//                entity.Property(e => e.Clobs).HasColumnName("CLOBS");

//                entity.Property(e => e.Clpagto).HasColumnName("CLPAGTO");

//                entity.Property(e => e.Clrg).HasColumnName("CLRG");

//                entity.Property(e => e.Cltele).HasColumnName("CLTELE");

//                entity.Property(e => e.Clupagto)
//                    .HasColumnName("CLUPAGTO")
//                    .HasColumnType("datetime");
//            });

//            modelBCorelder.Entity<Clipago>(entity =>
//            {
//                entity.ToTable("CLIPAGO");

//                entity.Property(e => e.Cliente).HasColumnName("CLIENTE");

//                entity.Property(e => e.Credito).HasColumnName("CREDITO");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Valor).HasColumnName("VALOR");
//            });

//            modelBCorelder.Entity<Contas>(entity =>
//            {
//                entity.ToTable("CONTAS");

//                entity.Property(e => e.Cod).HasColumnName("COD");

//                entity.Property(e => e.Hist).HasColumnName("HIST");
//            });

//            modelBCorelder.Entity<Conv>(entity =>
//            {
//                entity.ToTable("CONV");

//                entity.Property(e => e.Cvbalc).HasColumnName("CVBALC");

//                entity.Property(e => e.Cvcomissao).HasColumnName("CVCOMISSAO");

//                entity.Property(e => e.Cvdata)
//                    .HasColumnName("CVDATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Cvdtrec)
//                    .HasColumnName("CVDTREC")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Cventrega).HasColumnName("CVENTREGA");

//                entity.Property(e => e.Cvfilial).HasColumnName("CVFILIAL");

//                entity.Property(e => e.Cvlibcom)
//                    .HasColumnName("CVLIBCOM")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Cvnota).HasColumnName("CVNOTA");

//                entity.Property(e => e.Cvobsv).HasColumnName("CVOBSV");

//                entity.Property(e => e.Cvpsuso).HasColumnName("CVPSUSO");

//                entity.Property(e => e.Cvreceita).HasColumnName("CVRECEITA");

//                entity.Property(e => e.Cvtick).HasColumnName("CVTICK");

//                entity.Property(e => e.Cvtitular).HasColumnName("CVTITULAR");

//                entity.Property(e => e.Cvvalocrz).HasColumnName("CVVALOCRZ");

//                entity.Property(e => e.Cvvalourv).HasColumnName("CVVALOURV");

//                entity.Property(e => e.Fucdem).HasColumnName("FUCDEM");

//                entity.Property(e => e.Fucodi).HasColumnName("FUCODI");
//            });

//            modelBCorelder.Entity<Convenio>(entity =>
//            {
//                entity.ToTable("CONVENIO");

//                entity.Property(e => e.Cvbalc).HasColumnName("CVBALC");

//                entity.Property(e => e.Cvcomissao).HasColumnName("CVCOMISSAO");

//                entity.Property(e => e.Cvdata)
//                    .HasColumnName("CVDATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Cvdtrec)
//                    .HasColumnName("CVDTREC")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Cventrega).HasColumnName("CVENTREGA");

//                entity.Property(e => e.Cvfilial).HasColumnName("CVFILIAL");

//                entity.Property(e => e.Cvlibcom)
//                    .HasColumnName("CVLIBCOM")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Cvmesdesc)
//                    .HasColumnName("CVMESDESC")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Cvnota).HasColumnName("CVNOTA");

//                entity.Property(e => e.Cvobsv).HasColumnName("CVOBSV");

//                entity.Property(e => e.Cvpsuso).HasColumnName("CVPSUSO");

//                entity.Property(e => e.Cvrec).HasColumnName("CVREC");

//                entity.Property(e => e.Cvreceita).HasColumnName("CVRECEITA");

//                entity.Property(e => e.Cvtick).HasColumnName("CVTICK");

//                entity.Property(e => e.Cvtitular).HasColumnName("CVTITULAR");

//                entity.Property(e => e.Cvvalocrz).HasColumnName("CVVALOCRZ");

//                entity.Property(e => e.Cvvalourv).HasColumnName("CVVALOURV");

//                entity.Property(e => e.Fucdem).HasColumnName("FUCDEM");

//                entity.Property(e => e.Fucodi).HasColumnName("FUCODI");
//            });

//            modelBCorelder.Entity<Debcli>(entity =>
//            {
//                entity.ToTable("DEBCLI");

//                entity.Property(e => e.Bacodi).HasColumnName("BACODI");

//                entity.Property(e => e.Clbalc).HasColumnName("CLBALC");

//                entity.Property(e => e.Clcodi).HasColumnName("CLCODI");

//                entity.Property(e => e.Cldata)
//                    .HasColumnName("CLDATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Cldesc).HasColumnName("CLDESC");

//                entity.Property(e => e.Clobs).HasColumnName("CLOBS");

//                entity.Property(e => e.Clpago).HasColumnName("CLPAGO");

//                entity.Property(e => e.Clqtde).HasColumnName("CLQTDE");

//                entity.Property(e => e.Cltick).HasColumnName("CLTICK");

//                entity.Property(e => e.Comissao).HasColumnName("COMISSAO");

//                entity.Property(e => e.Descomp).HasColumnName("DESCOMP");

//                entity.Property(e => e.DtPagto)
//                    .HasColumnName("DT_PAGTO")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.VlPago).HasColumnName("VL_PAGO");
//            });

//            modelBCorelder.Entity<Delivery>(entity =>
//            {
//                entity.ToTable("DELIVERY");

//                entity.Property(e => e.Acumulado).HasColumnName("ACUMULADO");

//                entity.Property(e => e.Aposentado).HasColumnName("APOSENTADO");

//                entity.Property(e => e.Bairro).HasColumnName("BAIRRO");

//                entity.Property(e => e.Balcon).HasColumnName("BALCON");

//                entity.Property(e => e.Cep).HasColumnName("CEP");

//                entity.Property(e => e.Cidade).HasColumnName("CIDADE");

//                entity.Property(e => e.Clclassi).HasColumnName("CLCLASSI");

//                entity.Property(e => e.Clobs1).HasColumnName("CLOBS1");

//                entity.Property(e => e.Clobs2).HasColumnName("CLOBS2");

//                entity.Property(e => e.Codigo).HasColumnName("CODIGO");

//                entity.Property(e => e.Cpf).HasColumnName("CPF");

//                entity.Property(e => e.Datanasc)
//                    .HasColumnName("DATANASC")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Descmed).HasColumnName("DESCMED");

//                entity.Property(e => e.Descout).HasColumnName("DESCOUT");

//                entity.Property(e => e.Dtcad)
//                    .HasColumnName("DTCAD")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Endereco).HasColumnName("ENDERECO");

//                entity.Property(e => e.Fone).HasColumnName("FONE");

//                entity.Property(e => e.Impresso).HasColumnName("IMPRESSO");

//                entity.Property(e => e.Nome).HasColumnName("NOME");

//                entity.Property(e => e.Rg).HasColumnName("RG");

//                entity.Property(e => e.UltCompra)
//                    .HasColumnName("ULT_COMPRA")
//                    .HasColumnType("datetime");
//            });

//            modelBCorelder.Entity<Despesas>(entity =>
//            {
//                entity.ToTable("DESPESAS");

//                entity.Property(e => e.Caixa).HasColumnName("CAIXA");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Historico).HasColumnName("HISTORICO");

//                entity.Property(e => e.Valor).HasColumnName("VALOR");
//            });

//            modelBCorelder.Entity<Empresa>(entity =>
//            {
//                entity.ToTable("EMPRESA");

//                entity.Property(e => e.Codgolden).HasColumnName("CODGOLDEN");

//                entity.Property(e => e.DesAce).HasColumnName("DES_ACE");

//                entity.Property(e => e.DesB).HasColumnName("DES_B");

//                entity.Property(e => e.DesEtic).HasColumnName("DES_ETIC");

//                entity.Property(e => e.DesFech).HasColumnName("DES_FECH");

//                entity.Property(e => e.DesNota).HasColumnName("DES_NOTA");

//                entity.Property(e => e.DesPerf).HasColumnName("DES_PERF");

//                entity.Property(e => e.DesRest).HasColumnName("DES_REST");

//                entity.Property(e => e.DesTick).HasColumnName("DES_TICK");

//                entity.Property(e => e.DesVar).HasColumnName("DES_VAR");

//                entity.Property(e => e.Descplac).HasColumnName("DESCPLAC");

//                entity.Property(e => e.Embair).HasColumnName("EMBAIR");

//                entity.Property(e => e.Embloq).HasColumnName("EMBLOQ");

//                entity.Property(e => e.Emcep).HasColumnName("EMCEP");

//                entity.Property(e => e.Emcgce).HasColumnName("EMCGCE");

//                entity.Property(e => e.Emcida).HasColumnName("EMCIDA");

//                entity.Property(e => e.Emcodi).HasColumnName("EMCODI");

//                entity.Property(e => e.Emcont).HasColumnName("EMCONT");

//                entity.Property(e => e.Emcontrato).HasColumnName("EMCONTRATO");

//                entity.Property(e => e.Emdebito).HasColumnName("EMDEBITO");

//                entity.Property(e => e.Emende).HasColumnName("EMENDE");

//                entity.Property(e => e.Emesta).HasColumnName("EMESTA");

//                entity.Property(e => e.Emetico).HasColumnName("EMETICO");

//                entity.Property(e => e.Emfax).HasColumnName("EMFAX");

//                entity.Property(e => e.Emfech).HasColumnName("EMFECH");

//                entity.Property(e => e.Emfilial).HasColumnName("EMFILIAL");

//                entity.Property(e => e.EmgCorea).HasColumnName("EMGCoreA");

//                entity.Property(e => e.Eminsc).HasColumnName("EMINSC");

//                entity.Property(e => e.Emlimite).HasColumnName("EMLIMITE");

//                entity.Property(e => e.Emnume).HasColumnName("EMNUME");

//                entity.Property(e => e.Emobs).HasColumnName("EMOBS");

//                entity.Property(e => e.Emobs1).HasColumnName("EMOBS1");

//                entity.Property(e => e.Emperf).HasColumnName("EMPERF");

//                entity.Property(e => e.Emprint).HasColumnName("EMPRINT");

//                entity.Property(e => e.Emraso).HasColumnName("EMRASO");

//                entity.Property(e => e.Emreceita).HasColumnName("EMRECEITA");

//                entity.Property(e => e.Emtele).HasColumnName("EMTELE");

//                entity.Property(e => e.Ibgeest).HasColumnName("IBGEEST");

//                entity.Property(e => e.Ibgemun).HasColumnName("IBGEMUN");

//                entity.Property(e => e.Libperf).HasColumnName("LIBPERF");

//                entity.Property(e => e.PercDesc).HasColumnName("PERC_DESC");

//                entity.Property(e => e.Vidaav).HasColumnName("VIDAAV");

//                entity.Property(e => e.Vidalk).HasColumnName("VIDALK");

//                entity.Property(e => e.Vidapc).HasColumnName("VIDAPC");
//            });

//            modelBCorelder.Entity<Encomen>(entity =>
//            {
//                entity.ToTable("ENCOMEN");

//                entity.Property(e => e.Endata)
//                    .HasColumnName("ENDATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Enqtde).HasColumnName("ENQTDE");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");
//            });

//            modelBCorelder.Entity<Ent>(entity =>
//            {
//                entity.ToTable("ENT");

//                entity.Property(e => e.Descfin).HasColumnName("DESCFIN");

//                entity.Property(e => e.Desconto).HasColumnName("DESCONTO");

//                entity.Property(e => e.Descrep).HasColumnName("DESCREP");

//                entity.Property(e => e.Endata)
//                    .HasColumnName("ENDATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Enqtde).HasColumnName("ENQTDE");

//                entity.Property(e => e.Envalo).HasColumnName("ENVALO");

//                entity.Property(e => e.Envalodes).HasColumnName("ENVALODES");

//                entity.Property(e => e.Estant).HasColumnName("ESTANT");

//                entity.Property(e => e.Etiqueta).HasColumnName("ETIQUETA");

//                entity.Property(e => e.Fornec).HasColumnName("FORNEC");

//                entity.Property(e => e.Impresso).HasColumnName("IMPRESSO");

//                entity.Property(e => e.Impretq).HasColumnName("IMPRETQ");

//                entity.Property(e => e.Notafis).HasColumnName("NOTAFIS");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prfabr).HasColumnName("PRFABR");

//                entity.Property(e => e.Soetiq).HasColumnName("SOETIQ");

//                entity.Property(e => e.Usuario).HasColumnName("USUARIO");
//            });

//            modelBCorelder.Entity<Entpro>(entity =>
//            {
//                entity.ToTable("ENTPRO");

//                entity.Property(e => e.Descfin).HasColumnName("DESCFIN");

//                entity.Property(e => e.Desconto).HasColumnName("DESCONTO");

//                entity.Property(e => e.Descrep).HasColumnName("DESCREP");

//                entity.Property(e => e.Emissnf)
//                    .HasColumnName("EMISSNF")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Endata)
//                    .HasColumnName("ENDATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Enqtde).HasColumnName("ENQTDE");

//                entity.Property(e => e.Envalo).HasColumnName("ENVALO");

//                entity.Property(e => e.Envalodes).HasColumnName("ENVALODES");

//                entity.Property(e => e.Estant).HasColumnName("ESTANT");

//                entity.Property(e => e.Etiqueta).HasColumnName("ETIQUETA");

//                entity.Property(e => e.Fornec).HasColumnName("FORNEC");

//                entity.Property(e => e.Impresso).HasColumnName("IMPRESSO");

//                entity.Property(e => e.Impretq).HasColumnName("IMPRETQ");

//                entity.Property(e => e.Lote).HasColumnName("LOTE");

//                entity.Property(e => e.Notafis).HasColumnName("NOTAFIS");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prfabr).HasColumnName("PRFABR");

//                entity.Property(e => e.Soetiq).HasColumnName("SOETIQ");

//                entity.Property(e => e.Usuario).HasColumnName("USUARIO");
//            });

//            modelBCorelder.Entity<Estq0045>(entity =>
//            {
//                entity.ToTable("ESTQ0045");

//                entity.Property(e => e.EstMinimo).HasColumnName("EST_MINIMO");

//                entity.Property(e => e.Prbarra).HasColumnName("PRBARRA");

//                entity.Property(e => e.Prcdse).HasColumnName("PRCDSE");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prdesc).HasColumnName("PRDESC");

//                entity.Property(e => e.Prestq).HasColumnName("PRESTQ");

//                entity.Property(e => e.Secao).HasColumnName("SECAO");
//            });

//            modelBCorelder.Entity<Etiqperf>(entity =>
//            {
//                entity.ToTable("ETIQPERF");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prcons).HasColumnName("PRCONS");

//                entity.Property(e => e.Prconsf).HasColumnName("PRCONSF");

//                entity.Property(e => e.Prdesc1).HasColumnName("PRDESC1");

//                entity.Property(e => e.Prdesc2).HasColumnName("PRDESC2");
//            });

//            modelBCorelder.Entity<Etiqprom>(entity =>
//            {
//                entity.ToTable("ETIQPROM");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prcons).HasColumnName("PRCONS");

//                entity.Property(e => e.Prconsf).HasColumnName("PRCONSF");

//                entity.Property(e => e.Prdesc1).HasColumnName("PRDESC1");

//                entity.Property(e => e.Prdesc2).HasColumnName("PRDESC2");
//            });

//            modelBCorelder.Entity<Etiqueta>(entity =>
//            {
//                entity.ToTable("ETIQUETA");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prcons).HasColumnName("PRCONS");

//                entity.Property(e => e.Prdesc1).HasColumnName("PRDESC1");

//                entity.Property(e => e.Prdesc2).HasColumnName("PRDESC2");
//            });

//            modelBCorelder.Entity<Faltas>(entity =>
//            {
//                entity.ToTable("FALTAS");

//                entity.Property(e => e.Balcon).HasColumnName("BALCON");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");
//            });

//            modelBCorelder.Entity<Fechconv>(entity =>
//            {
//                entity.ToTable("FECHCONV");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Fucdem).HasColumnName("FUCDEM");

//                entity.Property(e => e.Valor).HasColumnName("VALOR");
//            });

//            modelBCorelder.Entity<Filial>(entity =>
//            {
//                entity.ToTable("FILIAL");

//                entity.Property(e => e.Aplica1).HasColumnName("APLICA1");

//                entity.Property(e => e.Aplica10).HasColumnName("APLICA10");

//                entity.Property(e => e.Aplica2).HasColumnName("APLICA2");

//                entity.Property(e => e.Aplica3).HasColumnName("APLICA3");

//                entity.Property(e => e.Aplica4).HasColumnName("APLICA4");

//                entity.Property(e => e.Aplica5).HasColumnName("APLICA5");

//                entity.Property(e => e.Aplica6).HasColumnName("APLICA6");

//                entity.Property(e => e.Aplica7).HasColumnName("APLICA7");

//                entity.Property(e => e.Aplica8).HasColumnName("APLICA8");

//                entity.Property(e => e.Aplica9).HasColumnName("APLICA9");

//                entity.Property(e => e.Desc1).HasColumnName("DESC1");

//                entity.Property(e => e.Desc10).HasColumnName("DESC10");

//                entity.Property(e => e.Desc2).HasColumnName("DESC2");

//                entity.Property(e => e.Desc3).HasColumnName("DESC3");

//                entity.Property(e => e.Desc4).HasColumnName("DESC4");

//                entity.Property(e => e.Desc5).HasColumnName("DESC5");

//                entity.Property(e => e.Desc6).HasColumnName("DESC6");

//                entity.Property(e => e.Desc7).HasColumnName("DESC7");

//                entity.Property(e => e.Desc8).HasColumnName("DESC8");

//                entity.Property(e => e.Desc9).HasColumnName("DESC9");

//                entity.Property(e => e.Filcep).HasColumnName("FILCEP");

//                entity.Property(e => e.Filcgce).HasColumnName("FILCGCE");

//                entity.Property(e => e.Filcida).HasColumnName("FILCIDA");

//                entity.Property(e => e.Filcodi).HasColumnName("FILCODI");

//                entity.Property(e => e.Filcont).HasColumnName("FILCONT");

//                entity.Property(e => e.Filende).HasColumnName("FILENDE");

//                entity.Property(e => e.Filesta).HasColumnName("FILESTA");

//                entity.Property(e => e.Filfax).HasColumnName("FILFAX");

//                entity.Property(e => e.Filinsc).HasColumnName("FILINSC");

//                entity.Property(e => e.Filnome).HasColumnName("FILNOME");

//                entity.Property(e => e.Filtele).HasColumnName("FILTELE");

//                entity.Property(e => e.Subsec1).HasColumnName("SUBSEC1");

//                entity.Property(e => e.Subsec10).HasColumnName("SUBSEC10");

//                entity.Property(e => e.Subsec2).HasColumnName("SUBSEC2");

//                entity.Property(e => e.Subsec3).HasColumnName("SUBSEC3");

//                entity.Property(e => e.Subsec4).HasColumnName("SUBSEC4");

//                entity.Property(e => e.Subsec5).HasColumnName("SUBSEC5");

//                entity.Property(e => e.Subsec6).HasColumnName("SUBSEC6");

//                entity.Property(e => e.Subsec7).HasColumnName("SUBSEC7");

//                entity.Property(e => e.Subsec8).HasColumnName("SUBSEC8");

//                entity.Property(e => e.Subsec9).HasColumnName("SUBSEC9");
//            });

//            modelBCorelder.Entity<Funcio>(entity =>
//            {
//                entity.ToTable("FUNCIO");

//                entity.Property(e => e.Codgolden).HasColumnName("CODGOLDEN");

//                entity.Property(e => e.Datademi)
//                    .HasColumnName("DATADEMI")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Demitido).HasColumnName("DEMITIDO");

//                entity.Property(e => e.Fubai).HasColumnName("FUBAI");

//                entity.Property(e => e.Fubloq).HasColumnName("FUBLOQ");

//                entity.Property(e => e.Fucdem).HasColumnName("FUCDEM");

//                entity.Property(e => e.Fucep).HasColumnName("FUCEP");

//                entity.Property(e => e.Fucid).HasColumnName("FUCID");

//                entity.Property(e => e.Fucodi).HasColumnName("FUCODI");

//                entity.Property(e => e.Fudata)
//                    .HasColumnName("FUDATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Fudepto).HasColumnName("FUDEPTO");

//                entity.Property(e => e.Fuend).HasColumnName("FUEND");

//                entity.Property(e => e.Fuest).HasColumnName("FUEST");

//                entity.Property(e => e.Fufone).HasColumnName("FUFONE");

//                entity.Property(e => e.FCoredent).HasColumnName("FCoreDENT");

//                entity.Property(e => e.Fulimite).HasColumnName("FULIMITE");

//                entity.Property(e => e.Funome).HasColumnName("FUNOME");

//                entity.Property(e => e.Fuobs1).HasColumnName("FUOBS1");

//                entity.Property(e => e.Fuobs2).HasColumnName("FUOBS2");

//                entity.Property(e => e.Fuobs3).HasColumnName("FUOBS3");

//                entity.Property(e => e.Fuplano).HasColumnName("FUPLANO");

//                entity.Property(e => e.Fusit).HasColumnName("FUSIT");

//                entity.Property(e => e.Impresso).HasColumnName("IMPRESSO");

//                entity.Property(e => e.Totdebcr).HasColumnName("TOTDEBCR");

//                entity.Property(e => e.Totdebsr).HasColumnName("TOTDEBSR");
//            });

//            modelBCorelder.Entity<Histor>(entity =>
//            {
//                entity.ToTable("HISTOR");

//                entity.Property(e => e.Desconto).HasColumnName("DESCONTO");

//                entity.Property(e => e.Distrib).HasColumnName("DISTRIB");

//                entity.Property(e => e.Notafis).HasColumnName("NOTAFIS");

//                entity.Property(e => e.Pedido).HasColumnName("PEDIDO");

//                entity.Property(e => e.Recebto)
//                    .HasColumnName("RECEBTO")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Total).HasColumnName("TOTAL");

//                entity.Property(e => e.Vencto)
//                    .HasColumnName("VENCTO")
//                    .HasColumnType("datetime");
//            });

//            modelBCorelder.Entity<Ibpt>(entity =>
//            {
//                entity.ToTable("IBPT");

//                entity.Property(e => e.Codigo).HasColumnName("CODIGO");

//                entity.Property(e => e.Imp1).HasColumnName("IMP1");

//                entity.Property(e => e.Imp2).HasColumnName("IMP2");
//            });

//            modelBCorelder.Entity<Invent>(entity =>
//            {
//                entity.ToTable("INVENT");

//                entity.Property(e => e.Lote).HasColumnName("LOTE");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prdesc).HasColumnName("PRDESC");

//                entity.Property(e => e.Prreg).HasColumnName("PRREG");

//                entity.Property(e => e.Qtde).HasColumnName("QTDE");

//                entity.Property(e => e.Tpmed).HasColumnName("TPMED");
//            });

//            modelBCorelder.Entity<Logsys>(entity =>
//            {
//                entity.ToTable("LOGSYS");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Nivel).HasColumnName("NIVEL");

//                entity.Property(e => e.Opcao).HasColumnName("OPCAO");

//                entity.Property(e => e.Time).HasColumnName("TIME");

//                entity.Property(e => e.Usuario).HasColumnName("USUARIO");
//            });

//            modelBCorelder.Entity<Malclien>(entity =>
//            {
//                entity.ToTable("MALCLIEN");

//                entity.Property(e => e.Acumulado).HasColumnName("ACUMULADO");

//                entity.Property(e => e.Aposentado).HasColumnName("APOSENTADO");

//                entity.Property(e => e.Bairro).HasColumnName("BAIRRO");

//                entity.Property(e => e.Balcon).HasColumnName("BALCON");

//                entity.Property(e => e.Cep).HasColumnName("CEP");

//                entity.Property(e => e.Cidade).HasColumnName("CIDADE");

//                entity.Property(e => e.Clclassi).HasColumnName("CLCLASSI");

//                entity.Property(e => e.Clobs1).HasColumnName("CLOBS1");

//                entity.Property(e => e.Clobs2).HasColumnName("CLOBS2");

//                entity.Property(e => e.Codigo).HasColumnName("CODIGO");

//                entity.Property(e => e.Cpf).HasColumnName("CPF");

//                entity.Property(e => e.Datanasc)
//                    .HasColumnName("DATANASC")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Descmed).HasColumnName("DESCMED");

//                entity.Property(e => e.Descout).HasColumnName("DESCOUT");

//                entity.Property(e => e.Dtcad)
//                    .HasColumnName("DTCAD")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Endereco).HasColumnName("ENDERECO");

//                entity.Property(e => e.Filial).HasColumnName("FILIAL");

//                entity.Property(e => e.Fone).HasColumnName("FONE");

//                entity.Property(e => e.Impresso).HasColumnName("IMPRESSO");

//                entity.Property(e => e.Nome).HasColumnName("NOME");

//                entity.Property(e => e.Rg).HasColumnName("RG");

//                entity.Property(e => e.UltCompra)
//                    .HasColumnName("ULT_COMPRA")
//                    .HasColumnType("datetime");
//            });

//            modelBCorelder.Entity<Merctran>(entity =>
//            {
//                entity.ToTable("MERCTRAN");

//                entity.Property(e => e.Comissao).HasColumnName("COMISSAO");

//                entity.Property(e => e.Desconto).HasColumnName("DESCONTO");

//                entity.Property(e => e.Descricao).HasColumnName("DESCRICAO");

//                entity.Property(e => e.Estoque).HasColumnName("ESTOQUE");

//                entity.Property(e => e.Etiqueta).HasColumnName("ETIQUETA");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prcons).HasColumnName("PRCONS");

//                entity.Property(e => e.Prconsd).HasColumnName("PRCONSD");

//                entity.Property(e => e.Qtde).HasColumnName("QTDE");

//                entity.Property(e => e.VlTotal).HasColumnName("VL_TOTAL");
//            });

//            modelBCorelder.Entity<Mov>(entity =>
//            {
//                entity.ToTable("MOV");

//                entity.Property(e => e.Admcart).HasColumnName("ADMCART");

//                entity.Property(e => e.Bacodi).HasColumnName("BACODI");

//                entity.Property(e => e.Caixa).HasColumnName("CAIXA");

//                entity.Property(e => e.Cancelado).HasColumnName("CANCELADO");

//                entity.Property(e => e.Cartaoc).HasColumnName("CARTAOC");

//                entity.Property(e => e.Cheque).HasColumnName("CHEQUE");

//                entity.Property(e => e.Chequepre).HasColumnName("CHEQUEPRE");

//                entity.Property(e => e.Codcli).HasColumnName("CODCLI");

//                entity.Property(e => e.Cpf).HasColumnName("CPF");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Dinheiro).HasColumnName("DINHEIRO");

//                entity.Property(e => e.Ecf).HasColumnName("ECF");

//                entity.Property(e => e.Hora).HasColumnName("HORA");

//                entity.Property(e => e.NFiscal).HasColumnName("N_FISCAL");

//                entity.Property(e => e.Nome).HasColumnName("NOME");

//                entity.Property(e => e.Popular).HasColumnName("POPULAR");

//                entity.Property(e => e.Ticket).HasColumnName("TICKET");

//                entity.Property(e => e.Tipo).HasColumnName("TIPO");

//                entity.Property(e => e.TotAnt).HasColumnName("TOT_ANT");

//                entity.Property(e => e.TotVen).HasColumnName("TOT_VEN");

//                entity.Property(e => e.Tpvd).HasColumnName("TPVD");
//            });

//            modelBCorelder.Entity<Movm>(entity =>
//            {
//                entity.ToTable("MOVM");

//                entity.Property(e => e.Admcart).HasColumnName("ADMCART");

//                entity.Property(e => e.Bacodi).HasColumnName("BACODI");

//                entity.Property(e => e.Caixa).HasColumnName("CAIXA");

//                entity.Property(e => e.Cancelado).HasColumnName("CANCELADO");

//                entity.Property(e => e.Cartaoc).HasColumnName("CARTAOC");

//                entity.Property(e => e.Cheque).HasColumnName("CHEQUE");

//                entity.Property(e => e.Chequepre).HasColumnName("CHEQUEPRE");

//                entity.Property(e => e.Codcli).HasColumnName("CODCLI");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Dinheiro).HasColumnName("DINHEIRO");

//                entity.Property(e => e.Hora).HasColumnName("HORA");

//                entity.Property(e => e.NFiscal).HasColumnName("N_FISCAL");

//                entity.Property(e => e.Ticket).HasColumnName("TICKET");

//                entity.Property(e => e.Tipo).HasColumnName("TIPO");

//                entity.Property(e => e.TotAnt).HasColumnName("TOT_ANT");

//                entity.Property(e => e.TotVen).HasColumnName("TOT_VEN");

//                entity.Property(e => e.Tpvd).HasColumnName("TPVD");
//            });

//            modelBCorelder.Entity<Movme>(entity =>
//            {
//                entity.ToTable("MOVME");

//                entity.Property(e => e.Bacodi).HasColumnName("BACODI");

//                entity.Property(e => e.Cancelado).HasColumnName("CANCELADO");

//                entity.Property(e => e.Codcli).HasColumnName("CODCLI");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Pedido).HasColumnName("PEDIDO");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");

//                entity.Property(e => e.Ticket).HasColumnName("TICKET");

//                entity.Property(e => e.Tipo).HasColumnName("TIPO");

//                entity.Property(e => e.TotComis).HasColumnName("TOT_COMIS");

//                entity.Property(e => e.TotDescon).HasColumnName("TOT_DESCON");

//                entity.Property(e => e.Tpvd).HasColumnName("TPVD");

//                entity.Property(e => e.VlTot).HasColumnName("VL_TOT");

//                entity.Property(e => e.VlUnit).HasColumnName("VL_UNIT");

//                entity.Property(e => e.VlliqCored).HasColumnName("VLLIQCoreD");
//            });

//            modelBCorelder.Entity<Movmes>(entity =>
//            {
//                entity.ToTable("MOVMES");

//                entity.Property(e => e.Bacodi).HasColumnName("BACODI");

//                entity.Property(e => e.Cancelado).HasColumnName("CANCELADO");

//                entity.Property(e => e.Codcli).HasColumnName("CODCLI");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Ecf).HasColumnName("ECF");

//                entity.Property(e => e.Pedido).HasColumnName("PEDIDO");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");

//                entity.Property(e => e.Ticket).HasColumnName("TICKET");

//                entity.Property(e => e.Tipo).HasColumnName("TIPO");

//                entity.Property(e => e.TotComis).HasColumnName("TOT_COMIS");

//                entity.Property(e => e.TotDescon).HasColumnName("TOT_DESCON");

//                entity.Property(e => e.Tpvd).HasColumnName("TPVD");

//                entity.Property(e => e.VlTot).HasColumnName("VL_TOT");

//                entity.Property(e => e.VlUnit).HasColumnName("VL_UNIT");

//                entity.Property(e => e.VlliqCored).HasColumnName("VLLIQCoreD");
//            });

//            modelBCorelder.Entity<Movnf>(entity =>
//            {
//                entity.ToTable("MOVNF");

//                entity.Property(e => e.Cancelado).HasColumnName("CANCELADO");

//                entity.Property(e => e.Cpf).HasColumnName("CPF");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Descricao).HasColumnName("DESCRICAO");

//                entity.Property(e => e.Ecf).HasColumnName("ECF");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");

//                entity.Property(e => e.Ticket).HasColumnName("TICKET");

//                entity.Property(e => e.VlTot).HasColumnName("VL_TOT");

//                entity.Property(e => e.VlUnit).HasColumnName("VL_UNIT");
//            });

//            modelBCorelder.Entity<Movpop>(entity =>
//            {
//                entity.ToTable("MOVPOP");

//                entity.Property(e => e.BalcCpf).HasColumnName("BALC_CPF");

//                entity.Property(e => e.Cancelado).HasColumnName("CANCELADO");

//                entity.Property(e => e.Compdia).HasColumnName("COMPDIA");

//                entity.Property(e => e.Compmes).HasColumnName("COMPMES");

//                entity.Property(e => e.Cpfcli).HasColumnName("CPFCLI");

//                entity.Property(e => e.Crm).HasColumnName("CRM");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Datarec)
//                    .HasColumnName("DATAREC")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Ecf).HasColumnName("ECF");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");

//                entity.Property(e => e.Senha).HasColumnName("SENHA");

//                entity.Property(e => e.Ticket).HasColumnName("TICKET");

//                entity.Property(e => e.TotDescon).HasColumnName("TOT_DESCON");

//                entity.Property(e => e.VlTot).HasColumnName("VL_TOT");

//                entity.Property(e => e.VlUnit).HasColumnName("VL_UNIT");

//                entity.Property(e => e.VlliqCored).HasColumnName("VLLIQCoreD");
//            });

//            modelBCorelder.Entity<Natureza>(entity =>
//            {
//                entity.ToTable("NATUREZA");

//                entity.Property(e => e.Codigo).HasColumnName("CODIGO");

//                entity.Property(e => e.Nome).HasColumnName("NOME");
//            });

//            modelBCorelder.Entity<Newcli>(entity =>
//            {
//                entity.ToTable("NEWCLI");

//                entity.Property(e => e.Bairro).HasColumnName("BAIRRO");

//                entity.Property(e => e.Cep).HasColumnName("CEP");

//                entity.Property(e => e.Cidade).HasColumnName("CIDADE");

//                entity.Property(e => e.Clclassi).HasColumnName("CLCLASSI");

//                entity.Property(e => e.Codigo).HasColumnName("CODIGO");

//                entity.Property(e => e.Datanasc)
//                    .HasColumnName("DATANASC")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Desconto).HasColumnName("DESCONTO");

//                entity.Property(e => e.Endereco).HasColumnName("ENDERECO");

//                entity.Property(e => e.Fone).HasColumnName("FONE");

//                entity.Property(e => e.Impresso).HasColumnName("IMPRESSO");

//                entity.Property(e => e.Nome).HasColumnName("NOME");

//                entity.Property(e => e.Rg).HasColumnName("RG");

//                entity.Property(e => e.Tipo).HasColumnName("TIPO");

//                entity.Property(e => e.UltCompra)
//                    .HasColumnName("ULT_COMPRA")
//                    .HasColumnType("datetime");
//            });

//            modelBCorelder.Entity<Newfunc>(entity =>
//            {
//                entity.ToTable("NEWFUNC");

//                entity.Property(e => e.Codgolden).HasColumnName("CODGOLDEN");

//                entity.Property(e => e.Datademi)
//                    .HasColumnName("DATADEMI")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Demitido).HasColumnName("DEMITIDO");

//                entity.Property(e => e.Fubai).HasColumnName("FUBAI");

//                entity.Property(e => e.Fubloq).HasColumnName("FUBLOQ");

//                entity.Property(e => e.Fucdem).HasColumnName("FUCDEM");

//                entity.Property(e => e.Fucep).HasColumnName("FUCEP");

//                entity.Property(e => e.Fucid).HasColumnName("FUCID");

//                entity.Property(e => e.Fucodi).HasColumnName("FUCODI");

//                entity.Property(e => e.Fudata)
//                    .HasColumnName("FUDATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Fudepto).HasColumnName("FUDEPTO");

//                entity.Property(e => e.Fuend).HasColumnName("FUEND");

//                entity.Property(e => e.Fuest).HasColumnName("FUEST");

//                entity.Property(e => e.Fufone).HasColumnName("FUFONE");

//                entity.Property(e => e.Fulimite).HasColumnName("FULIMITE");

//                entity.Property(e => e.Funome).HasColumnName("FUNOME");

//                entity.Property(e => e.Fuobs1).HasColumnName("FUOBS1");

//                entity.Property(e => e.Fuobs2).HasColumnName("FUOBS2");

//                entity.Property(e => e.Fuobs3).HasColumnName("FUOBS3");

//                entity.Property(e => e.Fusit).HasColumnName("FUSIT");

//                entity.Property(e => e.Impresso).HasColumnName("IMPRESSO");

//                entity.Property(e => e.Totdebcr).HasColumnName("TOTDEBCR");

//                entity.Property(e => e.Totdebsr).HasColumnName("TOTDEBSR");
//            });

//            modelBCorelder.Entity<Newprec>(entity =>
//            {
//                entity.ToTable("NEWPREC");

//                entity.Property(e => e.Prcddt)
//                    .HasColumnName("PRCDDT")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Prcdlucr).HasColumnName("PRCDLUCR");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prcons).HasColumnName("PRCONS");

//                entity.Property(e => e.Prconscv).HasColumnName("PRCONSCV");

//                entity.Property(e => e.Prfabr).HasColumnName("PRFABR");
//            });

//            modelBCorelder.Entity<Newprod>(entity =>
//            {
//                entity.ToTable("NEWPROD");

//                entity.Property(e => e.Coddcb).HasColumnName("CODDCB");

//                entity.Property(e => e.Codesta).HasColumnName("CODESTA");

//                entity.Property(e => e.Codfis).HasColumnName("CODFIS");

//                entity.Property(e => e.Comissao).HasColumnName("COMISSAO");

//                entity.Property(e => e.DescMax).HasColumnName("DESC_MAX");

//                entity.Property(e => e.EstMinimo).HasColumnName("EST_MINIMO");

//                entity.Property(e => e.Etbarra).HasColumnName("ETBARRA");

//                entity.Property(e => e.Etgraf).HasColumnName("ETGRAF");

//                entity.Property(e => e.Prbarra).HasColumnName("PRBARRA");

//                entity.Property(e => e.Prcddt)
//                    .HasColumnName("PRCDDT")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Prcdimp).HasColumnName("PRCDIMP");

//                entity.Property(e => e.Prcdimp2).HasColumnName("PRCDIMP2");

//                entity.Property(e => e.Prcdla).HasColumnName("PRCDLA");

//                entity.Property(e => e.Prcdlucr).HasColumnName("PRCDLUCR");

//                entity.Property(e => e.Prcdse).HasColumnName("PRCDSE");

//                entity.Property(e => e.Prclas).HasColumnName("PRCLAS");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prcons).HasColumnName("PRCONS");

//                entity.Property(e => e.Prconscv).HasColumnName("PRCONSCV");

//                entity.Property(e => e.Prdata)
//                    .HasColumnName("PRDATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Prdesc).HasColumnName("PRDESC");

//                entity.Property(e => e.Prdesconv).HasColumnName("PRDESCONV");

//                entity.Property(e => e.Prdtul)
//                    .HasColumnName("PRDTUL")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Premb).HasColumnName("PREMB");

//                entity.Property(e => e.Prentr).HasColumnName("PRENTR");

//                entity.Property(e => e.Prestq).HasColumnName("PRESTQ");

//                entity.Property(e => e.Pretiq).HasColumnName("PRETIQ");

//                entity.Property(e => e.Prfabr).HasColumnName("PRFABR");

//                entity.Property(e => e.Pricms).HasColumnName("PRICMS");

//                entity.Property(e => e.Prloca).HasColumnName("PRLOCA");

//                entity.Property(e => e.Prmesant).HasColumnName("PRMESANT");

//                entity.Property(e => e.Prneutro).HasColumnName("PRNEUTRO");

//                entity.Property(e => e.Prnola).HasColumnName("PRNOLA");

//                entity.Property(e => e.Prnose).HasColumnName("PRNOSE");

//                entity.Property(e => e.Prpis).HasColumnName("PRPIS");

//                entity.Property(e => e.Prpopular).HasColumnName("PRPOPULAR");

//                entity.Property(e => e.Prporta).HasColumnName("PRPORTA");

//                entity.Property(e => e.Prpos).HasColumnName("PRPOS");

//                entity.Property(e => e.Prpret).HasColumnName("PRPRET");

//                entity.Property(e => e.Prreg).HasColumnName("PRREG");

//                entity.Property(e => e.Prsal).HasColumnName("PRSAL");

//                entity.Property(e => e.Prsitu).HasColumnName("PRSITU");

//                entity.Property(e => e.Prtestq).HasColumnName("PRTESTQ");

//                entity.Property(e => e.Prulte).HasColumnName("PRULTE");

//                entity.Property(e => e.Secao).HasColumnName("SECAO");

//                entity.Property(e => e.Tipo).HasColumnName("TIPO");

//                entity.Property(e => e.UlVen)
//                    .HasColumnName("UL_VEN")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Ultfor).HasColumnName("ULTFOR");

//                entity.Property(e => e.Ultped)
//                    .HasColumnName("ULTPED")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Vendant).HasColumnName("VENDANT");

//                entity.Property(e => e.Vendatu).HasColumnName("VENDATU");
//            });

//            modelBCorelder.Entity<Newtab>(entity =>
//            {
//                entity.ToTable("NEWTAB");

//                entity.Property(e => e.Mesano).HasColumnName("MESANO");

//                entity.Property(e => e.Newtab1).HasColumnName("NEWTAB");
//            });

//            modelBCorelder.Entity<Nfe>(entity =>
//            {
//                entity.ToTable("NFE");

//                entity.Property(e => e.Campo).HasColumnName("CAMPO");

//                entity.Property(e => e.Codigo).HasColumnName("CODIGO");

//                entity.Property(e => e.Descricao).HasColumnName("DESCRICAO");

//                entity.Property(e => e.Icms).HasColumnName("ICMS");

//                entity.Property(e => e.Imp).HasColumnName("IMP");

//                entity.Property(e => e.Ncm).HasColumnName("NCM");

//                entity.Property(e => e.Prcdimp).HasColumnName("PRCDIMP");

//                entity.Property(e => e.Qtde).HasColumnName("QTDE");

//                entity.Property(e => e.Valor).HasColumnName("VALOR");

//                entity.Property(e => e.Vltot).HasColumnName("VLTOT");
//            });

//            modelBCorelder.Entity<Nota>(entity =>
//            {
//                entity.ToTable("NOTA");

//                entity.Property(e => e.Base).HasColumnName("BASE");

//                entity.Property(e => e.Basesub).HasColumnName("BASESUB");

//                entity.Property(e => e.Cliente).HasColumnName("CLIENTE");

//                entity.Property(e => e.Icms).HasColumnName("ICMS");

//                entity.Property(e => e.Icmssub).HasColumnName("ICMSSUB");

//                entity.Property(e => e.NFiscal).HasColumnName("N_FISCAL");

//                entity.Property(e => e.NNatu).HasColumnName("N_NATU");

//                entity.Property(e => e.Natureza).HasColumnName("NATUREZA");

//                entity.Property(e => e.Nbase12).HasColumnName("NBASE12");

//                entity.Property(e => e.Nbase18).HasColumnName("NBASE18");

//                entity.Property(e => e.Nbase25).HasColumnName("NBASE25");

//                entity.Property(e => e.Nbase7).HasColumnName("NBASE7");

//                entity.Property(e => e.Ncancelada).HasColumnName("NCANCELADA");

//                entity.Property(e => e.Ndata)
//                    .HasColumnName("NDATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Nicms12).HasColumnName("NICMS12");

//                entity.Property(e => e.Nicms18).HasColumnName("NICMS18");

//                entity.Property(e => e.Nicms25).HasColumnName("NICMS25");

//                entity.Property(e => e.Nicms7).HasColumnName("NICMS7");

//                entity.Property(e => e.Nvalor).HasColumnName("NVALOR");
//            });

//            modelBCorelder.Entity<Notaf>(entity =>
//            {
//                entity.ToTable("NOTAF");

//                entity.Property(e => e.NumNota).HasColumnName("NUM_NOTA");
//            });

//            modelBCorelder.Entity<Nped>(entity =>
//            {
//                entity.ToTable("NPED");

//                entity.Property(e => e.Numped).HasColumnName("NUMPED");
//            });

//            modelBCorelder.Entity<NumTmp>(entity =>
//            {
//                entity.ToTable("NUM_TMP");

//                entity.Property(e => e.Numero).HasColumnName("NUMERO");
//            });

//            modelBCorelder.Entity<Numped>(entity =>
//            {
//                entity.ToTable("NUMPED");

//                entity.Property(e => e.Desconto).HasColumnName("DESCONTO");

//                entity.Property(e => e.Fornec).HasColumnName("FORNEC");

//                entity.Property(e => e.Numero).HasColumnName("NUMERO");

//                entity.Property(e => e.Przentrega).HasColumnName("PRZENTREGA");

//                entity.Property(e => e.Przpagto).HasColumnName("PRZPAGTO");
//            });

//            modelBCorelder.Entity<Ped0204>(entity =>
//            {
//                entity.ToTable("PED0204");

//                entity.Property(e => e.Codint).HasColumnName("CODINT");

//                entity.Property(e => e.Eloja1).HasColumnName("ELOJA1");

//                entity.Property(e => e.Eloja2).HasColumnName("ELOJA2");

//                entity.Property(e => e.Eloja3).HasColumnName("ELOJA3");

//                entity.Property(e => e.Eloja4).HasColumnName("ELOJA4");

//                entity.Property(e => e.Forn).HasColumnName("FORN");

//                entity.Property(e => e.Mloja1).HasColumnName("MLOJA1");

//                entity.Property(e => e.Mloja2).HasColumnName("MLOJA2");

//                entity.Property(e => e.Mloja3).HasColumnName("MLOJA3");

//                entity.Property(e => e.Mloja4).HasColumnName("MLOJA4");

//                entity.Property(e => e.Nloja1).HasColumnName("NLOJA1");

//                entity.Property(e => e.Nloja2).HasColumnName("NLOJA2");

//                entity.Property(e => e.Nloja3).HasColumnName("NLOJA3");

//                entity.Property(e => e.Nloja4).HasColumnName("NLOJA4");

//                entity.Property(e => e.Prbarra).HasColumnName("PRBARRA");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prdesc).HasColumnName("PRDESC");

//                entity.Property(e => e.Valor).HasColumnName("VALOR");
//            });

//            modelBCorelder.Entity<Ped0301>(entity =>
//            {
//                entity.ToTable("PED0301");

//                entity.Property(e => e.Codint).HasColumnName("CODINT");

//                entity.Property(e => e.Eloja1).HasColumnName("ELOJA1");

//                entity.Property(e => e.Eloja2).HasColumnName("ELOJA2");

//                entity.Property(e => e.Eloja3).HasColumnName("ELOJA3");

//                entity.Property(e => e.Eloja4).HasColumnName("ELOJA4");

//                entity.Property(e => e.Forn).HasColumnName("FORN");

//                entity.Property(e => e.Mloja1).HasColumnName("MLOJA1");

//                entity.Property(e => e.Mloja2).HasColumnName("MLOJA2");

//                entity.Property(e => e.Mloja3).HasColumnName("MLOJA3");

//                entity.Property(e => e.Mloja4).HasColumnName("MLOJA4");

//                entity.Property(e => e.Nloja1).HasColumnName("NLOJA1");

//                entity.Property(e => e.Nloja2).HasColumnName("NLOJA2");

//                entity.Property(e => e.Nloja3).HasColumnName("NLOJA3");

//                entity.Property(e => e.Nloja4).HasColumnName("NLOJA4");

//                entity.Property(e => e.Prbarra).HasColumnName("PRBARRA");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prdesc).HasColumnName("PRDESC");

//                entity.Property(e => e.Valor).HasColumnName("VALOR");
//            });

//            modelBCorelder.Entity<Ped0406>(entity =>
//            {
//                entity.ToTable("PED0406");

//                entity.Property(e => e.Codint).HasColumnName("CODINT");

//                entity.Property(e => e.Eloja1).HasColumnName("ELOJA1");

//                entity.Property(e => e.Eloja2).HasColumnName("ELOJA2");

//                entity.Property(e => e.Eloja3).HasColumnName("ELOJA3");

//                entity.Property(e => e.Eloja4).HasColumnName("ELOJA4");

//                entity.Property(e => e.Forn).HasColumnName("FORN");

//                entity.Property(e => e.Mloja1).HasColumnName("MLOJA1");

//                entity.Property(e => e.Mloja2).HasColumnName("MLOJA2");

//                entity.Property(e => e.Mloja3).HasColumnName("MLOJA3");

//                entity.Property(e => e.Mloja4).HasColumnName("MLOJA4");

//                entity.Property(e => e.Nloja1).HasColumnName("NLOJA1");

//                entity.Property(e => e.Nloja2).HasColumnName("NLOJA2");

//                entity.Property(e => e.Nloja3).HasColumnName("NLOJA3");

//                entity.Property(e => e.Nloja4).HasColumnName("NLOJA4");

//                entity.Property(e => e.Prbarra).HasColumnName("PRBARRA");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prdesc).HasColumnName("PRDESC");

//                entity.Property(e => e.Valor).HasColumnName("VALOR");
//            });

//            modelBCorelder.Entity<Ped1103>(entity =>
//            {
//                entity.ToTable("PED1103");

//                entity.Property(e => e.Codint).HasColumnName("CODINT");

//                entity.Property(e => e.Eloja1).HasColumnName("ELOJA1");

//                entity.Property(e => e.Eloja2).HasColumnName("ELOJA2");

//                entity.Property(e => e.Eloja3).HasColumnName("ELOJA3");

//                entity.Property(e => e.Eloja4).HasColumnName("ELOJA4");

//                entity.Property(e => e.Forn).HasColumnName("FORN");

//                entity.Property(e => e.Mloja1).HasColumnName("MLOJA1");

//                entity.Property(e => e.Mloja2).HasColumnName("MLOJA2");

//                entity.Property(e => e.Mloja3).HasColumnName("MLOJA3");

//                entity.Property(e => e.Mloja4).HasColumnName("MLOJA4");

//                entity.Property(e => e.Nloja1).HasColumnName("NLOJA1");

//                entity.Property(e => e.Nloja2).HasColumnName("NLOJA2");

//                entity.Property(e => e.Nloja3).HasColumnName("NLOJA3");

//                entity.Property(e => e.Nloja4).HasColumnName("NLOJA4");

//                entity.Property(e => e.Prbarra).HasColumnName("PRBARRA");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prdesc).HasColumnName("PRDESC");

//                entity.Property(e => e.Valor).HasColumnName("VALOR");
//            });

//            modelBCorelder.Entity<Ped1406>(entity =>
//            {
//                entity.ToTable("PED1406");

//                entity.Property(e => e.Codint).HasColumnName("CODINT");

//                entity.Property(e => e.Eloja1).HasColumnName("ELOJA1");

//                entity.Property(e => e.Eloja2).HasColumnName("ELOJA2");

//                entity.Property(e => e.Eloja3).HasColumnName("ELOJA3");

//                entity.Property(e => e.Eloja4).HasColumnName("ELOJA4");

//                entity.Property(e => e.Forn).HasColumnName("FORN");

//                entity.Property(e => e.Mloja1).HasColumnName("MLOJA1");

//                entity.Property(e => e.Mloja2).HasColumnName("MLOJA2");

//                entity.Property(e => e.Mloja3).HasColumnName("MLOJA3");

//                entity.Property(e => e.Mloja4).HasColumnName("MLOJA4");

//                entity.Property(e => e.Nloja1).HasColumnName("NLOJA1");

//                entity.Property(e => e.Nloja2).HasColumnName("NLOJA2");

//                entity.Property(e => e.Nloja3).HasColumnName("NLOJA3");

//                entity.Property(e => e.Nloja4).HasColumnName("NLOJA4");

//                entity.Property(e => e.Prbarra).HasColumnName("PRBARRA");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prdesc).HasColumnName("PRDESC");

//                entity.Property(e => e.Valor).HasColumnName("VALOR");
//            });

//            modelBCorelder.Entity<Ped1912>(entity =>
//            {
//                entity.ToTable("PED1912");

//                entity.Property(e => e.Codint).HasColumnName("CODINT");

//                entity.Property(e => e.Eloja1).HasColumnName("ELOJA1");

//                entity.Property(e => e.Eloja2).HasColumnName("ELOJA2");

//                entity.Property(e => e.Eloja3).HasColumnName("ELOJA3");

//                entity.Property(e => e.Eloja4).HasColumnName("ELOJA4");

//                entity.Property(e => e.Forn).HasColumnName("FORN");

//                entity.Property(e => e.Mloja1).HasColumnName("MLOJA1");

//                entity.Property(e => e.Mloja2).HasColumnName("MLOJA2");

//                entity.Property(e => e.Mloja3).HasColumnName("MLOJA3");

//                entity.Property(e => e.Mloja4).HasColumnName("MLOJA4");

//                entity.Property(e => e.Nloja1).HasColumnName("NLOJA1");

//                entity.Property(e => e.Nloja2).HasColumnName("NLOJA2");

//                entity.Property(e => e.Nloja3).HasColumnName("NLOJA3");

//                entity.Property(e => e.Nloja4).HasColumnName("NLOJA4");

//                entity.Property(e => e.Prbarra).HasColumnName("PRBARRA");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prdesc).HasColumnName("PRDESC");

//                entity.Property(e => e.Valor).HasColumnName("VALOR");
//            });

//            modelBCorelder.Entity<Pedidos>(entity =>
//            {
//                entity.ToTable("PEDIDOS");

//                entity.Property(e => e.Prcdla).HasColumnName("PRCDLA");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prdata)
//                    .HasColumnName("PRDATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Prfabr).HasColumnName("PRFABR");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");

//                entity.Property(e => e.Status).HasColumnName("STATUS");
//            });

//            modelBCorelder.Entity<Prodextr>(entity =>
//            {
//                entity.ToTable("PRODEXTR");

//                entity.Property(e => e.Concor1).HasColumnName("CONCOR1");

//                entity.Property(e => e.Concor2).HasColumnName("CONCOR2");

//                entity.Property(e => e.Concor3).HasColumnName("CONCOR3");

//                entity.Property(e => e.Concor4).HasColumnName("CONCOR4");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prcons).HasColumnName("PRCONS");

//                entity.Property(e => e.Prdesc).HasColumnName("PRDESC");
//            });

//            modelBCorelder.Entity<Produto>(entity =>
//            {
//                entity.ToTable("PRODUTO");

//                entity.Property(e => e.Coddcb).HasColumnName("CODDCB");

//                entity.Property(e => e.Codesta).HasColumnName("CODESTA");

//                entity.Property(e => e.Codfis).HasColumnName("CODFIS");

//                entity.Property(e => e.Comissao).HasColumnName("COMISSAO");

//                entity.Property(e => e.DescMax).HasColumnName("DESC_MAX");

//                entity.Property(e => e.EstMinimo).HasColumnName("EST_MINIMO");

//                entity.Property(e => e.Etbarra).HasColumnName("ETBARRA");

//                entity.Property(e => e.Etgraf).HasColumnName("ETGRAF");

//                entity.Property(e => e.Prbarra).HasColumnName("PRBARRA");

//                entity.Property(e => e.Prcddt)
//                    .HasColumnName("PRCDDT")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Prcdimp).HasColumnName("PRCDIMP");

//                entity.Property(e => e.Prcdimp2).HasColumnName("PRCDIMP2");

//                entity.Property(e => e.Prcdla).HasColumnName("PRCDLA");

//                entity.Property(e => e.Prcdlucr).HasColumnName("PRCDLUCR");

//                entity.Property(e => e.Prcdse).HasColumnName("PRCDSE");

//                entity.Property(e => e.Prclas).HasColumnName("PRCLAS");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prcons).HasColumnName("PRCONS");

//                entity.Property(e => e.Prconscv).HasColumnName("PRCONSCV");

//                entity.Property(e => e.Prdata)
//                    .HasColumnName("PRDATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Prdesc).HasColumnName("PRDESC");

//                entity.Property(e => e.Prdesconv).HasColumnName("PRDESCONV");

//                entity.Property(e => e.Prdtul)
//                    .HasColumnName("PRDTUL")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Premb).HasColumnName("PREMB");

//                entity.Property(e => e.Prentr).HasColumnName("PRENTR");

//                entity.Property(e => e.Prestq).HasColumnName("PRESTQ");

//                entity.Property(e => e.Pretiq).HasColumnName("PRETIQ");

//                entity.Property(e => e.Prfabr).HasColumnName("PRFABR");

//                entity.Property(e => e.Prfinal).HasColumnName("PRFINAL");

//                entity.Property(e => e.Prfixa).HasColumnName("PRFIXA");

//                entity.Property(e => e.Pricms).HasColumnName("PRICMS");

//                entity.Property(e => e.Prinicial).HasColumnName("PRINICIAL");

//                entity.Property(e => e.Prloca).HasColumnName("PRLOCA");

//                entity.Property(e => e.Prlote).HasColumnName("PRLOTE");

//                entity.Property(e => e.Prmesant).HasColumnName("PRMESANT");

//                entity.Property(e => e.Prncms).HasColumnName("PRNCMS");

//                entity.Property(e => e.Prneutro).HasColumnName("PRNEUTRO");

//                entity.Property(e => e.Prnola).HasColumnName("PRNOLA");

//                entity.Property(e => e.Prnose).HasColumnName("PRNOSE");

//                entity.Property(e => e.Prpis).HasColumnName("PRPIS");

//                entity.Property(e => e.Prpopular).HasColumnName("PRPOPULAR");

//                entity.Property(e => e.Prporta).HasColumnName("PRPORTA");

//                entity.Property(e => e.Prpos).HasColumnName("PRPOS");

//                entity.Property(e => e.Prpret).HasColumnName("PRPRET");

//                entity.Property(e => e.Prprinci).HasColumnName("PRPRINCI");

//                entity.Property(e => e.Prpromo).HasColumnName("PRPROMO");

//                entity.Property(e => e.Prreg).HasColumnName("PRREG");

//                entity.Property(e => e.Prsal).HasColumnName("PRSAL");

//                entity.Property(e => e.Prsitu).HasColumnName("PRSITU");

//                entity.Property(e => e.Prtestq).HasColumnName("PRTESTQ");

//                entity.Property(e => e.Prulte).HasColumnName("PRULTE");

//                entity.Property(e => e.Prun).HasColumnName("PRUN");

//                entity.Property(e => e.Prvalid)
//                    .HasColumnName("PRVALID")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Secao).HasColumnName("SECAO");

//                entity.Property(e => e.Tipo).HasColumnName("TIPO");

//                entity.Property(e => e.UlVen)
//                    .HasColumnName("UL_VEN")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Ultfor).HasColumnName("ULTFOR");

//                entity.Property(e => e.Ultped)
//                    .HasColumnName("ULTPED")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Ultpreco).HasColumnName("ULTPRECO");

//                entity.Property(e => e.Vendant).HasColumnName("VENDANT");

//                entity.Property(e => e.Vendatu).HasColumnName("VENDATU");

//                entity.Property(e => e.Vlcomis).HasColumnName("VLCOMIS");
//            });

//            modelBCorelder.Entity<Psico>(entity =>
//            {
//                entity.ToTable("PSICO");

//                entity.Property(e => e.Barras).HasColumnName("BARRAS");

//                entity.Property(e => e.Cid).HasColumnName("CID");

//                entity.Property(e => e.Cnpj).HasColumnName("CNPJ");

//                entity.Property(e => e.Crm).HasColumnName("CRM");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Emissao)
//                    .HasColumnName("EMISSAO")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Fone).HasColumnName("FONE");

//                entity.Property(e => e.Fornec).HasColumnName("FORNEC");

//                entity.Property(e => e.Idade).HasColumnName("IDADE");

//                entity.Property(e => e.Lote).HasColumnName("LOTE");

//                entity.Property(e => e.Motivo).HasColumnName("MOTIVO");

//                entity.Property(e => e.Nasc)
//                    .HasColumnName("NASC")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Nf).HasColumnName("NF");

//                entity.Property(e => e.Nome).HasColumnName("NOME");

//                entity.Property(e => e.Nomemed).HasColumnName("NOMEMED");

//                entity.Property(e => e.Orgao).HasColumnName("ORGAO");

//                entity.Property(e => e.Paciente).HasColumnName("PACIENTE");

//                entity.Property(e => e.Porta).HasColumnName("PORTA");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prdesc).HasColumnName("PRDESC");

//                entity.Property(e => e.Prolong).HasColumnName("PROLONG");

//                entity.Property(e => e.Prreg).HasColumnName("PRREG");

//                entity.Property(e => e.Qtde).HasColumnName("QTDE");

//                entity.Property(e => e.Receita).HasColumnName("RECEITA");

//                entity.Property(e => e.Rg).HasColumnName("RG");

//                entity.Property(e => e.Sexo).HasColumnName("SEXO");

//                entity.Property(e => e.Ticket).HasColumnName("TICKET");

//                entity.Property(e => e.Tipo).HasColumnName("TIPO");

//                entity.Property(e => e.Tpcons).HasColumnName("TPCONS");

//                entity.Property(e => e.Tpidade).HasColumnName("TPIDADE");

//                entity.Property(e => e.Tpmed).HasColumnName("TPMED");

//                entity.Property(e => e.Tpreceita).HasColumnName("TPRECEITA");

//                entity.Property(e => e.Uf).HasColumnName("UF");

//                entity.Property(e => e.Ufcons).HasColumnName("UFCONS");

//                entity.Property(e => e.Unidade).HasColumnName("UNIDADE");

//                entity.Property(e => e.Usomed).HasColumnName("USOMED");
//            });

//            modelBCorelder.Entity<Rancliqt>(entity =>
//            {
//                entity.ToTable("RANCLIQT");

//                entity.Property(e => e.Bacodi).HasColumnName("BACODI");

//                entity.Property(e => e.Cancelado).HasColumnName("CANCELADO");

//                entity.Property(e => e.Codcli).HasColumnName("CODCLI");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");

//                entity.Property(e => e.Ticket).HasColumnName("TICKET");

//                entity.Property(e => e.Tipo).HasColumnName("TIPO");

//                entity.Property(e => e.TotComis).HasColumnName("TOT_COMIS");

//                entity.Property(e => e.TotDescon).HasColumnName("TOT_DESCON");

//                entity.Property(e => e.VlTot).HasColumnName("VL_TOT");

//                entity.Property(e => e.VlUnit).HasColumnName("VL_UNIT");
//            });

//            modelBCorelder.Entity<Ranclivl>(entity =>
//            {
//                entity.ToTable("RANCLIVL");

//                entity.Property(e => e.Bacodi).HasColumnName("BACODI");

//                entity.Property(e => e.Caixa).HasColumnName("CAIXA");

//                entity.Property(e => e.Cancelado).HasColumnName("CANCELADO");

//                entity.Property(e => e.Codcli).HasColumnName("CODCLI");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Hora).HasColumnName("HORA");

//                entity.Property(e => e.NFiscal).HasColumnName("N_FISCAL");

//                entity.Property(e => e.Ticket).HasColumnName("TICKET");

//                entity.Property(e => e.Tipo).HasColumnName("TIPO");

//                entity.Property(e => e.TotVen).HasColumnName("TOT_VEN");
//            });

//            modelBCorelder.Entity<Reconst>(entity =>
//            {
//                entity.ToTable("RECONST");

//                entity.Property(e => e.ArqCorevo).HasColumnName("ARQCoreVO");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Necessita).HasColumnName("NECESSITA");

//                entity.Property(e => e.Posicao).HasColumnName("POSICAO");
//            });

//            modelBCorelder.Entity<Reducao>(entity =>
//            {
//                entity.ToTable("REDUCAO");

//                entity.Property(e => e.Acresc).HasColumnName("ACRESC");

//                entity.Property(e => e.Acresfin).HasColumnName("ACRESFIN");

//                entity.Property(e => e.Aliquota).HasColumnName("ALIQUOTA");

//                entity.Property(e => e.Cancela).HasColumnName("CANCELA");

//                entity.Property(e => e.Cns).HasColumnName("CNS");

//                entity.Property(e => e.Cnsi).HasColumnName("CNSI");

//                entity.Property(e => e.Coo).HasColumnName("COO");

//                entity.Property(e => e.Data).HasColumnName("DATA");

//                entity.Property(e => e.Desconto).HasColumnName("DESCONTO");

//                entity.Property(e => e.Gtda).HasColumnName("GTDA");

//                entity.Property(e => e.Nsi).HasColumnName("NSI");

//                entity.Property(e => e.Rzaut).HasColumnName("RZAUT");

//                entity.Property(e => e.Sangria).HasColumnName("SANGRIA");

//                entity.Property(e => e.Supri).HasColumnName("SUPRI");

//                entity.Property(e => e.Tributo).HasColumnName("TRIBUTO");
//            });

//            modelBCorelder.Entity<Relator>(entity =>
//            {
//                entity.ToTable("relator");

//                entity.Property(e => e.Nivel).HasColumnName("NIVEL");

//                entity.Property(e => e.Relatorio).HasColumnName("RELATORIO");
//            });

//            modelBCorelder.Entity<ResAno>(entity =>
//            {
//                entity.ToTable("RES_ANO");

//                entity.Property(e => e.CliAtds).HasColumnName("CLI_ATDS");

//                entity.Property(e => e.Descrec).HasColumnName("DESCREC");

//                entity.Property(e => e.Diastrab).HasColumnName("DIASTRAB");

//                entity.Property(e => e.Entradas).HasColumnName("ENTRADAS");

//                entity.Property(e => e.MesRef).HasColumnName("MES_REF");

//                entity.Property(e => e.RecFiado).HasColumnName("REC_FIADO");

//                entity.Property(e => e.TotEstoq).HasColumnName("TOT_ESTOQ");

//                entity.Property(e => e.VdaConv).HasColumnName("VDA_CONV");

//                entity.Property(e => e.VdaVista).HasColumnName("VDA_VISTA");

//                entity.Property(e => e.VenFiado).HasColumnName("VEN_FIADO");

//                entity.Property(e => e.VenMes).HasColumnName("VEN_MES");
//            });

//            modelBCorelder.Entity<Retirada>(entity =>
//            {
//                entity.ToTable("RETIRADA");

//                entity.Property(e => e.Caixa).HasColumnName("CAIXA");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Hora).HasColumnName("HORA");

//                entity.Property(e => e.Valorch).HasColumnName("VALORCH");

//                entity.Property(e => e.Valordh).HasColumnName("VALORDH");
//            });

//            modelBCorelder.Entity<Sal>(entity =>
//            {
//                entity.ToTable("SAL");

//                entity.Property(e => e.Salcod).HasColumnName("SALCOD");

//                entity.Property(e => e.Salnome).HasColumnName("SALNOME");
//            });

//            modelBCorelder.Entity<Secao>(entity =>
//            {
//                entity.ToTable("SECAO");

//                entity.Property(e => e.Secodi).HasColumnName("SECODI");

//                entity.Property(e => e.Senome).HasColumnName("SENOME");
//            });

//            modelBCorelder.Entity<Senha>(entity =>
//            {
//                entity.ToTable("SENHA");

//                entity.Property(e => e.Sen).HasColumnName("SEN");

//                entity.Property(e => e.Sencheq).HasColumnName("SENCHEQ");

//                entity.Property(e => e.Sencit).HasColumnName("SENCIT");

//                entity.Property(e => e.Senclich).HasColumnName("SENCLICH");

//                entity.Property(e => e.Senclip).HasColumnName("SENCLIP");

//                entity.Property(e => e.Sencont).HasColumnName("SENCONT");

//                entity.Property(e => e.Sendate)
//                    .HasColumnName("SENDATE")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Sendefa).HasColumnName("SENDEFA");

//                entity.Property(e => e.Sendesc).HasColumnName("SENDESC");

//                entity.Property(e => e.Sendesc1).HasColumnName("SENDESC1");

//                entity.Property(e => e.Sendesc2).HasColumnName("SENDESC2");

//                entity.Property(e => e.Sendesc3).HasColumnName("SENDESC3");

//                entity.Property(e => e.Sendesc4).HasColumnName("SENDESC4");

//                entity.Property(e => e.Sendesc5).HasColumnName("SENDESC5");

//                entity.Property(e => e.Sendesc6).HasColumnName("SENDESC6");

//                entity.Property(e => e.Sendia).HasColumnName("SENDIA");

//                entity.Property(e => e.Senestq).HasColumnName("SENESTQ");

//                entity.Property(e => e.Senetq).HasColumnName("SENETQ");

//                entity.Property(e => e.Senetqb).HasColumnName("SENETQB");

//                entity.Property(e => e.Senetqe).HasColumnName("SENETQE");

//                entity.Property(e => e.Senetqp).HasColumnName("SENETQP");

//                entity.Property(e => e.Senfia).HasColumnName("SENFIA");

//                entity.Property(e => e.Senfiacr).HasColumnName("SENFIACR");

//                entity.Property(e => e.Senfiatr).HasColumnName("SENFIATR");

//                entity.Property(e => e.Senfis).HasColumnName("SENFIS");

//                entity.Property(e => e.Senlin).HasColumnName("SENLIN");

//                entity.Property(e => e.Senman).HasColumnName("SENMAN");

//                entity.Property(e => e.Senmdprint).HasColumnName("SENMDPRINT");

//                entity.Property(e => e.Senmulta).HasColumnName("SENMULTA");

//                entity.Property(e => e.Senniv).HasColumnName("SENNIV");

//                entity.Property(e => e.Senpar).HasColumnName("SENPAR");

//                entity.Property(e => e.Senpcli)
//                    .HasColumnName("SENPCLI")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Senpme).HasColumnName("SENPME");

//                entity.Property(e => e.Senponto).HasColumnName("SENPONTO");

//                entity.Property(e => e.Senport).HasColumnName("SENPORT");

//                entity.Property(e => e.Senprint).HasColumnName("SENPRINT");

//                entity.Property(e => e.Senprot).HasColumnName("SENPROT");

//                entity.Property(e => e.Senrec).HasColumnName("SENREC");

//                entity.Property(e => e.Senrel).HasColumnName("SENREL");

//                entity.Property(e => e.Senrepete).HasColumnName("SENREPETE");

//                entity.Property(e => e.Senver).HasColumnName("SENVER");

//                entity.Property(e => e.Senvlpon).HasColumnName("SENVLPON");
//            });

//            modelBCorelder.Entity<Servico>(entity =>
//            {
//                entity.ToTable("SERVICO");

//                entity.Property(e => e.Svcodi).HasColumnName("SVCODI");

//                entity.Property(e => e.Svcomb).HasColumnName("SVCOMB");

//                entity.Property(e => e.Svdesc).HasColumnName("SVDESC");

//                entity.Property(e => e.Svpr01).HasColumnName("SVPR01");

//                entity.Property(e => e.Svpr02).HasColumnName("SVPR02");

//                entity.Property(e => e.Svpr03).HasColumnName("SVPR03");

//                entity.Property(e => e.Svpr04).HasColumnName("SVPR04");

//                entity.Property(e => e.Svpr05).HasColumnName("SVPR05");

//                entity.Property(e => e.Svprec).HasColumnName("SVPREC");

//                entity.Property(e => e.Svven1).HasColumnName("SVVEN1");

//                entity.Property(e => e.Svven2).HasColumnName("SVVEN2");
//            });

//            modelBCorelder.Entity<Sistema>(entity =>
//            {
//                entity.ToTable("SISTEMA");

//                entity.Property(e => e.Ticket).HasColumnName("TICKET");

//                entity.Property(e => e.Usuario).HasColumnName("USUARIO");
//            });

//            modelBCorelder.Entity<Slpharma>(entity =>
//            {
//                entity.ToTable("SLPHARMA");

//                entity.Property(e => e.Reconst).HasColumnName("RECONST");
//            });

//            modelBCorelder.Entity<Subsecao>(entity =>
//            {
//                entity.ToTable("SUBSECAO");

//                entity.Property(e => e.Secaopert).HasColumnName("SECAOPERT");

//                entity.Property(e => e.Subimpost).HasColumnName("SUBIMPOST");

//                entity.Property(e => e.Subncm).HasColumnName("SUBNCM");

//                entity.Property(e => e.Subsecodi).HasColumnName("SUBSECODI");

//                entity.Property(e => e.Subselucr).HasColumnName("SUBSELUCR");

//                entity.Property(e => e.Subsenome).HasColumnName("SUBSENOME");

//                entity.Property(e => e.Subseprec).HasColumnName("SUBSEPREC");

//                entity.Property(e => e.Valrec).HasColumnName("VALREC");
//            });

//            modelBCorelder.Entity<Tabela>(entity =>
//            {
//                entity.ToTable("TABELA");

//                entity.Property(e => e.Abc).HasColumnName("ABC");

//                entity.Property(e => e.Barra).HasColumnName("BARRA");

//                entity.Property(e => e.Ctr).HasColumnName("CTR");

//                entity.Property(e => e.Custom).HasColumnName("CUSTOM");

//                entity.Property(e => e.Des).HasColumnName("DES");

//                entity.Property(e => e.Dtvig)
//                    .HasColumnName("DTVIG")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Fra1).HasColumnName("FRA1");

//                entity.Property(e => e.Ipi).HasColumnName("IPI");

//                entity.Property(e => e.LabNom).HasColumnName("LAB_NOM");

//                entity.Property(e => e.MedApr).HasColumnName("MED_APR");

//                entity.Property(e => e.MedDes).HasColumnName("MED_DES");

//                entity.Property(e => e.MedPrinci).HasColumnName("MED_PRINCI");

//                entity.Property(e => e.MedRegims).HasColumnName("MED_REGIMS");

//                entity.Property(e => e.Negpos).HasColumnName("NEGPOS");

//                entity.Property(e => e.Neutro).HasColumnName("NEUTRO");

//                entity.Property(e => e.Nom).HasColumnName("NOM");

//                entity.Property(e => e.Pco1).HasColumnName("PCO1");

//                entity.Property(e => e.Pla1).HasColumnName("PLA1");

//                entity.Property(e => e.Uni).HasColumnName("UNI");
//            });

//            modelBCorelder.Entity<Temp>(entity =>
//            {
//                entity.ToTable("TEMP");

//                entity.Property(e => e.Desconto).HasColumnName("DESCONTO");

//                entity.Property(e => e.Descricao).HasColumnName("DESCRICAO");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prcons).HasColumnName("PRCONS");

//                entity.Property(e => e.Prconsd).HasColumnName("PRCONSD");

//                entity.Property(e => e.Qtde).HasColumnName("QTDE");

//                entity.Property(e => e.VlTotal).HasColumnName("VL_TOTAL");
//            });

//            modelBCorelder.Entity<Tempo>(entity =>
//            {
//                entity.ToTable("TEMPO");

//                entity.Property(e => e.Desconto).HasColumnName("DESCONTO");

//                entity.Property(e => e.Descricao).HasColumnName("DESCRICAO");

//                entity.Property(e => e.Estoque).HasColumnName("ESTOQUE");

//                entity.Property(e => e.Pedido).HasColumnName("PEDIDO");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prcons).HasColumnName("PRCONS");

//                entity.Property(e => e.Prconsd).HasColumnName("PRCONSD");

//                entity.Property(e => e.Qtde).HasColumnName("QTDE");

//                entity.Property(e => e.VlTotal).HasColumnName("VL_TOTAL");
//            });

//            modelBCorelder.Entity<Ticket>(entity =>
//            {
//                entity.ToTable("TICKET");

//                entity.Property(e => e.Ecf).HasColumnName("ECF");

//                entity.Property(e => e.Ticket1).HasColumnName("TICKET");
//            });

//            modelBCorelder.Entity<Transfer>(entity =>
//            {
//                entity.ToTable("TRANSFER");

//                entity.Property(e => e.Balcon).HasColumnName("BALCON");

//                entity.Property(e => e.Etiqueta).HasColumnName("ETIQUETA");

//                entity.Property(e => e.Filcodi).HasColumnName("FILCODI");

//                entity.Property(e => e.Hora).HasColumnName("HORA");

//                entity.Property(e => e.Impresso).HasColumnName("IMPRESSO");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prcons).HasColumnName("PRCONS");

//                entity.Property(e => e.Qtde).HasColumnName("QTDE");

//                entity.Property(e => e.Trdata)
//                    .HasColumnName("TRDATA")
//                    .HasColumnType("datetime");
//            });

//            modelBCorelder.Entity<Troco1>(entity =>
//            {
//                entity.ToTable("TROCO1");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Initroco).HasColumnName("INITROCO");

//                entity.Property(e => e.TrocoIni).HasColumnName("TROCO_INI");
//            });

//            modelBCorelder.Entity<Troco10>(entity =>
//            {
//                entity.ToTable("TROCO10");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Initroco).HasColumnName("INITROCO");

//                entity.Property(e => e.TrocoIni).HasColumnName("TROCO_INI");
//            });

//            modelBCorelder.Entity<Troco11>(entity =>
//            {
//                entity.ToTable("TROCO11");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Initroco).HasColumnName("INITROCO");

//                entity.Property(e => e.TrocoIni).HasColumnName("TROCO_INI");
//            });

//            modelBCorelder.Entity<Troco12>(entity =>
//            {
//                entity.ToTable("TROCO12");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Initroco).HasColumnName("INITROCO");

//                entity.Property(e => e.TrocoIni).HasColumnName("TROCO_INI");
//            });

//            modelBCorelder.Entity<Troco13>(entity =>
//            {
//                entity.ToTable("TROCO13");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Initroco).HasColumnName("INITROCO");

//                entity.Property(e => e.TrocoIni).HasColumnName("TROCO_INI");
//            });

//            modelBCorelder.Entity<Troco14>(entity =>
//            {
//                entity.ToTable("TROCO14");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Initroco).HasColumnName("INITROCO");

//                entity.Property(e => e.TrocoIni).HasColumnName("TROCO_INI");
//            });

//            modelBCorelder.Entity<Troco15>(entity =>
//            {
//                entity.ToTable("TROCO15");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Initroco).HasColumnName("INITROCO");

//                entity.Property(e => e.TrocoIni).HasColumnName("TROCO_INI");
//            });

//            modelBCorelder.Entity<Troco16>(entity =>
//            {
//                entity.ToTable("TROCO16");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Initroco).HasColumnName("INITROCO");

//                entity.Property(e => e.TrocoIni).HasColumnName("TROCO_INI");
//            });

//            modelBCorelder.Entity<Troco17>(entity =>
//            {
//                entity.ToTable("TROCO17");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Initroco).HasColumnName("INITROCO");

//                entity.Property(e => e.TrocoIni).HasColumnName("TROCO_INI");
//            });

//            modelBCorelder.Entity<Troco18>(entity =>
//            {
//                entity.ToTable("TROCO18");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Initroco).HasColumnName("INITROCO");

//                entity.Property(e => e.TrocoIni).HasColumnName("TROCO_INI");
//            });

//            modelBCorelder.Entity<Troco19>(entity =>
//            {
//                entity.ToTable("TROCO19");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Initroco).HasColumnName("INITROCO");

//                entity.Property(e => e.TrocoIni).HasColumnName("TROCO_INI");
//            });

//            modelBCorelder.Entity<Troco2>(entity =>
//            {
//                entity.ToTable("TROCO2");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Initroco).HasColumnName("INITROCO");

//                entity.Property(e => e.TrocoIni).HasColumnName("TROCO_INI");
//            });

//            modelBCorelder.Entity<Troco20>(entity =>
//            {
//                entity.ToTable("TROCO20");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Initroco).HasColumnName("INITROCO");

//                entity.Property(e => e.TrocoIni).HasColumnName("TROCO_INI");
//            });

//            modelBCorelder.Entity<Troco3>(entity =>
//            {
//                entity.ToTable("TROCO3");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Initroco).HasColumnName("INITROCO");

//                entity.Property(e => e.TrocoIni).HasColumnName("TROCO_INI");
//            });

//            modelBCorelder.Entity<Troco4>(entity =>
//            {
//                entity.ToTable("TROCO4");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Initroco).HasColumnName("INITROCO");

//                entity.Property(e => e.TrocoIni).HasColumnName("TROCO_INI");
//            });

//            modelBCorelder.Entity<Troco5>(entity =>
//            {
//                entity.ToTable("TROCO5");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Initroco).HasColumnName("INITROCO");

//                entity.Property(e => e.TrocoIni).HasColumnName("TROCO_INI");
//            });

//            modelBCorelder.Entity<Troco6>(entity =>
//            {
//                entity.ToTable("TROCO6");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Initroco).HasColumnName("INITROCO");

//                entity.Property(e => e.TrocoIni).HasColumnName("TROCO_INI");
//            });

//            modelBCorelder.Entity<Troco7>(entity =>
//            {
//                entity.ToTable("TROCO7");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Initroco).HasColumnName("INITROCO");

//                entity.Property(e => e.TrocoIni).HasColumnName("TROCO_INI");
//            });

//            modelBCorelder.Entity<Troco8>(entity =>
//            {
//                entity.ToTable("TROCO8");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Initroco).HasColumnName("INITROCO");

//                entity.Property(e => e.TrocoIni).HasColumnName("TROCO_INI");
//            });

//            modelBCorelder.Entity<Troco9>(entity =>
//            {
//                entity.ToTable("TROCO9");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Initroco).HasColumnName("INITROCO");

//                entity.Property(e => e.TrocoIni).HasColumnName("TROCO_INI");
//            });

//            modelBCorelder.Entity<Urv>(entity =>
//            {
//                entity.ToTable("URV");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Valor).HasColumnName("VALOR");
//            });

//            modelBCorelder.Entity<Usefarma>(entity =>
//            {
//                entity.ToTable("USEFARMA");

//                entity.Property(e => e.Acesso1).HasColumnName("ACESSO1");

//                entity.Property(e => e.Acesso10).HasColumnName("ACESSO10");

//                entity.Property(e => e.Acesso2).HasColumnName("ACESSO2");

//                entity.Property(e => e.Acesso3).HasColumnName("ACESSO3");

//                entity.Property(e => e.Acesso4).HasColumnName("ACESSO4");

//                entity.Property(e => e.Acesso5).HasColumnName("ACESSO5");

//                entity.Property(e => e.Acesso6).HasColumnName("ACESSO6");

//                entity.Property(e => e.Acesso7).HasColumnName("ACESSO7");

//                entity.Property(e => e.Acesso8).HasColumnName("ACESSO8");

//                entity.Property(e => e.Acesso9).HasColumnName("ACESSO9");

//                entity.Property(e => e.Nivel).HasColumnName("NIVEL");

//                entity.Property(e => e.Nome).HasColumnName("NOME");

//                entity.Property(e => e.Senha).HasColumnName("SENHA");
//            });

//            modelBCorelder.Entity<Usoint>(entity =>
//            {
//                entity.ToTable("USOINT");

//                entity.Property(e => e.Data)
//                    .HasColumnName("DATA")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Qtde).HasColumnName("QTDE");
//            });

//            OnModelCreating(modelBCorelder);
//        }

//         void OnModelCreating(ModelBCorelder modelBCorelder);
//    }
//}
