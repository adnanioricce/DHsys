//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;

//namespace Core.Entities.Scaffolded
//{
//    public partial class Farmacia_dbContext : DbContext
//    {
//        public Farmacia_dbContext()
//        {
//        }

//        public Farmacia_dbContext(DbContextOptions<Farmacia_dbContext> options)
//            : base(options)
//        {
//        }

//        public virtual DbSet<Agenda> Agenda { get; set; }
//        public virtual DbSet<Balcon> Balcon { get; set; }
//        public virtual DbSet<Brindes> Brindes { get; set; }
//        public virtual DbSet<Cartao> Cartao { get; set; }
//        public virtual DbSet<CliMed> CliMed { get; set; }
//        public virtual DbSet<Contas> Contas { get; set; }
//        public virtual DbSet<Empresa> Empresa { get; set; }
//        public virtual DbSet<Estq0045> Estq0045 { get; set; }
//        public virtual DbSet<Etiqperf> Etiqperf { get; set; }
//        public virtual DbSet<Etiqprom> Etiqprom { get; set; }
//        public virtual DbSet<Etiqueta> Etiqueta { get; set; }
//        public virtual DbSet<Filial> Filial { get; set; }
//        public virtual DbSet<Ibpt> Ibpt { get; set; }
//        public virtual DbSet<Invent> Invent { get; set; }
//        public virtual DbSet<Merctran> Merctran { get; set; }
//        public virtual DbSet<Natureza> Natureza { get; set; }
//        public virtual DbSet<Newtab> Newtab { get; set; }
//        public virtual DbSet<Nfe> Nfe { get; set; }
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
//        public virtual DbSet<Prodextr> Prodextr { get; set; }
//        public virtual DbSet<Reducao> Reducao { get; set; }
//        public virtual DbSet<ResAno> ResAno { get; set; }
//        public virtual DbSet<Sal> Sal { get; set; }
//        public virtual DbSet<Secao> Secao { get; set; }
//        public virtual DbSet<Servico> Servico { get; set; }
//        public virtual DbSet<Sistema> Sistema { get; set; }
//        public virtual DbSet<Slpharma> Slpharma { get; set; }
//        public virtual DbSet<Subsecao> Subsecao { get; set; }
//        public virtual DbSet<Temp> Temp { get; set; }
//        public virtual DbSet<Tempo> Tempo { get; set; }
//        public virtual DbSet<Ticket> Ticket { get; set; }
//        public virtual DbSet<Usefarma> Usefarma { get; set; }
//        public virtual DbSet<Vend0100> Vend0100 { get; set; }
//        public virtual DbSet<Vend0101> Vend0101 { get; set; }
//        public virtual DbSet<Vend0102> Vend0102 { get; set; }
//        public virtual DbSet<Vend0103> Vend0103 { get; set; }
//        public virtual DbSet<Vend0104> Vend0104 { get; set; }
//        public virtual DbSet<Vend0105> Vend0105 { get; set; }
//        public virtual DbSet<Vend0106> Vend0106 { get; set; }
//        public virtual DbSet<Vend0107> Vend0107 { get; set; }
//        public virtual DbSet<Vend0108> Vend0108 { get; set; }
//        public virtual DbSet<Vend0109> Vend0109 { get; set; }
//        public virtual DbSet<Vend0110> Vend0110 { get; set; }
//        public virtual DbSet<Vend0111> Vend0111 { get; set; }
//        public virtual DbSet<Vend0112> Vend0112 { get; set; }
//        public virtual DbSet<Vend0113> Vend0113 { get; set; }
//        public virtual DbSet<Vend0114> Vend0114 { get; set; }
//        public virtual DbSet<Vend0115> Vend0115 { get; set; }
//        public virtual DbSet<Vend0116> Vend0116 { get; set; }
//        public virtual DbSet<Vend0117> Vend0117 { get; set; }
//        public virtual DbSet<Vend0118> Vend0118 { get; set; }
//        public virtual DbSet<Vend0119> Vend0119 { get; set; }
//        public virtual DbSet<Vend0120> Vend0120 { get; set; }
//        public virtual DbSet<Vend0171> Vend0171 { get; set; }
//        public virtual DbSet<Vend0194> Vend0194 { get; set; }
//        public virtual DbSet<Vend0197> Vend0197 { get; set; }
//        public virtual DbSet<Vend0199> Vend0199 { get; set; }
//        public virtual DbSet<Vend0200> Vend0200 { get; set; }
//        public virtual DbSet<Vend0201> Vend0201 { get; set; }
//        public virtual DbSet<Vend0202> Vend0202 { get; set; }
//        public virtual DbSet<Vend0203> Vend0203 { get; set; }
//        public virtual DbSet<Vend0204> Vend0204 { get; set; }
//        public virtual DbSet<Vend0205> Vend0205 { get; set; }
//        public virtual DbSet<Vend0206> Vend0206 { get; set; }
//        public virtual DbSet<Vend0207> Vend0207 { get; set; }
//        public virtual DbSet<Vend0208> Vend0208 { get; set; }
//        public virtual DbSet<Vend0209> Vend0209 { get; set; }
//        public virtual DbSet<Vend0210> Vend0210 { get; set; }
//        public virtual DbSet<Vend0211> Vend0211 { get; set; }
//        public virtual DbSet<Vend0212> Vend0212 { get; set; }
//        public virtual DbSet<Vend0213> Vend0213 { get; set; }
//        public virtual DbSet<Vend0214> Vend0214 { get; set; }
//        public virtual DbSet<Vend0215> Vend0215 { get; set; }
//        public virtual DbSet<Vend0216> Vend0216 { get; set; }
//        public virtual DbSet<Vend0217> Vend0217 { get; set; }
//        public virtual DbSet<Vend0218> Vend0218 { get; set; }
//        public virtual DbSet<Vend0219> Vend0219 { get; set; }
//        public virtual DbSet<Vend0220> Vend0220 { get; set; }
//        public virtual DbSet<Vend0271> Vend0271 { get; set; }
//        public virtual DbSet<Vend0300> Vend0300 { get; set; }
//        public virtual DbSet<Vend0301> Vend0301 { get; set; }
//        public virtual DbSet<Vend0302> Vend0302 { get; set; }
//        public virtual DbSet<Vend0303> Vend0303 { get; set; }
//        public virtual DbSet<Vend0304> Vend0304 { get; set; }
//        public virtual DbSet<Vend0305> Vend0305 { get; set; }
//        public virtual DbSet<Vend0306> Vend0306 { get; set; }
//        public virtual DbSet<Vend0307> Vend0307 { get; set; }
//        public virtual DbSet<Vend0308> Vend0308 { get; set; }
//        public virtual DbSet<Vend0309> Vend0309 { get; set; }
//        public virtual DbSet<Vend0310> Vend0310 { get; set; }
//        public virtual DbSet<Vend0311> Vend0311 { get; set; }
//        public virtual DbSet<Vend0312> Vend0312 { get; set; }
//        public virtual DbSet<Vend0313> Vend0313 { get; set; }
//        public virtual DbSet<Vend0314> Vend0314 { get; set; }
//        public virtual DbSet<Vend0315> Vend0315 { get; set; }
//        public virtual DbSet<Vend0316> Vend0316 { get; set; }
//        public virtual DbSet<Vend0317> Vend0317 { get; set; }
//        public virtual DbSet<Vend0318> Vend0318 { get; set; }
//        public virtual DbSet<Vend0319> Vend0319 { get; set; }
//        public virtual DbSet<Vend0394> Vend0394 { get; set; }
//        public virtual DbSet<Vend0400> Vend0400 { get; set; }
//        public virtual DbSet<Vend0401> Vend0401 { get; set; }
//        public virtual DbSet<Vend0402> Vend0402 { get; set; }
//        public virtual DbSet<Vend0403> Vend0403 { get; set; }
//        public virtual DbSet<Vend0404> Vend0404 { get; set; }
//        public virtual DbSet<Vend0405> Vend0405 { get; set; }
//        public virtual DbSet<Vend0406> Vend0406 { get; set; }
//        public virtual DbSet<Vend0407> Vend0407 { get; set; }
//        public virtual DbSet<Vend0408> Vend0408 { get; set; }
//        public virtual DbSet<Vend0409> Vend0409 { get; set; }
//        public virtual DbSet<Vend0410> Vend0410 { get; set; }
//        public virtual DbSet<Vend0411> Vend0411 { get; set; }
//        public virtual DbSet<Vend0412> Vend0412 { get; set; }
//        public virtual DbSet<Vend0413> Vend0413 { get; set; }
//        public virtual DbSet<Vend0414> Vend0414 { get; set; }
//        public virtual DbSet<Vend0415> Vend0415 { get; set; }
//        public virtual DbSet<Vend0416> Vend0416 { get; set; }
//        public virtual DbSet<Vend0417> Vend0417 { get; set; }
//        public virtual DbSet<Vend0418> Vend0418 { get; set; }
//        public virtual DbSet<Vend0419> Vend0419 { get; set; }
//        public virtual DbSet<Vend0494> Vend0494 { get; set; }
//        public virtual DbSet<Vend0500> Vend0500 { get; set; }
//        public virtual DbSet<Vend0501> Vend0501 { get; set; }
//        public virtual DbSet<Vend0502> Vend0502 { get; set; }
//        public virtual DbSet<Vend0503> Vend0503 { get; set; }
//        public virtual DbSet<Vend0504> Vend0504 { get; set; }
//        public virtual DbSet<Vend0505> Vend0505 { get; set; }
//        public virtual DbSet<Vend0506> Vend0506 { get; set; }
//        public virtual DbSet<Vend0507> Vend0507 { get; set; }
//        public virtual DbSet<Vend0508> Vend0508 { get; set; }
//        public virtual DbSet<Vend0509> Vend0509 { get; set; }
//        public virtual DbSet<Vend0510> Vend0510 { get; set; }
//        public virtual DbSet<Vend0511> Vend0511 { get; set; }
//        public virtual DbSet<Vend0512> Vend0512 { get; set; }
//        public virtual DbSet<Vend0513> Vend0513 { get; set; }
//        public virtual DbSet<Vend0514> Vend0514 { get; set; }
//        public virtual DbSet<Vend0515> Vend0515 { get; set; }
//        public virtual DbSet<Vend0516> Vend0516 { get; set; }
//        public virtual DbSet<Vend0517> Vend0517 { get; set; }
//        public virtual DbSet<Vend0518> Vend0518 { get; set; }
//        public virtual DbSet<Vend0519> Vend0519 { get; set; }
//        public virtual DbSet<Vend0594> Vend0594 { get; set; }
//        public virtual DbSet<Vend0600> Vend0600 { get; set; }
//        public virtual DbSet<Vend0601> Vend0601 { get; set; }
//        public virtual DbSet<Vend0602> Vend0602 { get; set; }
//        public virtual DbSet<Vend0603> Vend0603 { get; set; }
//        public virtual DbSet<Vend0604> Vend0604 { get; set; }
//        public virtual DbSet<Vend0605> Vend0605 { get; set; }
//        public virtual DbSet<Vend0606> Vend0606 { get; set; }
//        public virtual DbSet<Vend0607> Vend0607 { get; set; }
//        public virtual DbSet<Vend0608> Vend0608 { get; set; }
//        public virtual DbSet<Vend0609> Vend0609 { get; set; }
//        public virtual DbSet<Vend0610> Vend0610 { get; set; }
//        public virtual DbSet<Vend0611> Vend0611 { get; set; }
//        public virtual DbSet<Vend0612> Vend0612 { get; set; }
//        public virtual DbSet<Vend0613> Vend0613 { get; set; }
//        public virtual DbSet<Vend0614> Vend0614 { get; set; }
//        public virtual DbSet<Vend0615> Vend0615 { get; set; }
//        public virtual DbSet<Vend0616> Vend0616 { get; set; }
//        public virtual DbSet<Vend0617> Vend0617 { get; set; }
//        public virtual DbSet<Vend0618> Vend0618 { get; set; }
//        public virtual DbSet<Vend0619> Vend0619 { get; set; }
//        public virtual DbSet<Vend0694> Vend0694 { get; set; }
//        public virtual DbSet<Vend0700> Vend0700 { get; set; }
//        public virtual DbSet<Vend0701> Vend0701 { get; set; }
//        public virtual DbSet<Vend0702> Vend0702 { get; set; }
//        public virtual DbSet<Vend0703> Vend0703 { get; set; }
//        public virtual DbSet<Vend0704> Vend0704 { get; set; }
//        public virtual DbSet<Vend0705> Vend0705 { get; set; }
//        public virtual DbSet<Vend0706> Vend0706 { get; set; }
//        public virtual DbSet<Vend0707> Vend0707 { get; set; }
//        public virtual DbSet<Vend0708> Vend0708 { get; set; }
//        public virtual DbSet<Vend0709> Vend0709 { get; set; }
//        public virtual DbSet<Vend0710> Vend0710 { get; set; }
//        public virtual DbSet<Vend0711> Vend0711 { get; set; }
//        public virtual DbSet<Vend0712> Vend0712 { get; set; }
//        public virtual DbSet<Vend0713> Vend0713 { get; set; }
//        public virtual DbSet<Vend0714> Vend0714 { get; set; }
//        public virtual DbSet<Vend0715> Vend0715 { get; set; }
//        public virtual DbSet<Vend0716> Vend0716 { get; set; }
//        public virtual DbSet<Vend0717> Vend0717 { get; set; }
//        public virtual DbSet<Vend0718> Vend0718 { get; set; }
//        public virtual DbSet<Vend0719> Vend0719 { get; set; }
//        public virtual DbSet<Vend0794> Vend0794 { get; set; }
//        public virtual DbSet<Vend0800> Vend0800 { get; set; }
//        public virtual DbSet<Vend0801> Vend0801 { get; set; }
//        public virtual DbSet<Vend0802> Vend0802 { get; set; }
//        public virtual DbSet<Vend0803> Vend0803 { get; set; }
//        public virtual DbSet<Vend0804> Vend0804 { get; set; }
//        public virtual DbSet<Vend0805> Vend0805 { get; set; }
//        public virtual DbSet<Vend0806> Vend0806 { get; set; }
//        public virtual DbSet<Vend0807> Vend0807 { get; set; }
//        public virtual DbSet<Vend0808> Vend0808 { get; set; }
//        public virtual DbSet<Vend0809> Vend0809 { get; set; }
//        public virtual DbSet<Vend0810> Vend0810 { get; set; }
//        public virtual DbSet<Vend0811> Vend0811 { get; set; }
//        public virtual DbSet<Vend0812> Vend0812 { get; set; }
//        public virtual DbSet<Vend0813> Vend0813 { get; set; }
//        public virtual DbSet<Vend0814> Vend0814 { get; set; }
//        public virtual DbSet<Vend0815> Vend0815 { get; set; }
//        public virtual DbSet<Vend0816> Vend0816 { get; set; }
//        public virtual DbSet<Vend0817> Vend0817 { get; set; }
//        public virtual DbSet<Vend0818> Vend0818 { get; set; }
//        public virtual DbSet<Vend0819> Vend0819 { get; set; }
//        public virtual DbSet<Vend0894> Vend0894 { get; set; }
//        public virtual DbSet<Vend0900> Vend0900 { get; set; }
//        public virtual DbSet<Vend0901> Vend0901 { get; set; }
//        public virtual DbSet<Vend0902> Vend0902 { get; set; }
//        public virtual DbSet<Vend0903> Vend0903 { get; set; }
//        public virtual DbSet<Vend0904> Vend0904 { get; set; }
//        public virtual DbSet<Vend0905> Vend0905 { get; set; }
//        public virtual DbSet<Vend0906> Vend0906 { get; set; }
//        public virtual DbSet<Vend0907> Vend0907 { get; set; }
//        public virtual DbSet<Vend0908> Vend0908 { get; set; }
//        public virtual DbSet<Vend0909> Vend0909 { get; set; }
//        public virtual DbSet<Vend0910> Vend0910 { get; set; }
//        public virtual DbSet<Vend0911> Vend0911 { get; set; }
//        public virtual DbSet<Vend0912> Vend0912 { get; set; }
//        public virtual DbSet<Vend0913> Vend0913 { get; set; }
//        public virtual DbSet<Vend0914> Vend0914 { get; set; }
//        public virtual DbSet<Vend0915> Vend0915 { get; set; }
//        public virtual DbSet<Vend0916> Vend0916 { get; set; }
//        public virtual DbSet<Vend0917> Vend0917 { get; set; }
//        public virtual DbSet<Vend0918> Vend0918 { get; set; }
//        public virtual DbSet<Vend0919> Vend0919 { get; set; }
//        public virtual DbSet<Vend0994> Vend0994 { get; set; }
//        public virtual DbSet<Vend1000> Vend1000 { get; set; }
//        public virtual DbSet<Vend1001> Vend1001 { get; set; }
//        public virtual DbSet<Vend1002> Vend1002 { get; set; }
//        public virtual DbSet<Vend1003> Vend1003 { get; set; }
//        public virtual DbSet<Vend1004> Vend1004 { get; set; }
//        public virtual DbSet<Vend1005> Vend1005 { get; set; }
//        public virtual DbSet<Vend1006> Vend1006 { get; set; }
//        public virtual DbSet<Vend1007> Vend1007 { get; set; }
//        public virtual DbSet<Vend1008> Vend1008 { get; set; }
//        public virtual DbSet<Vend1009> Vend1009 { get; set; }
//        public virtual DbSet<Vend1010> Vend1010 { get; set; }
//        public virtual DbSet<Vend1011> Vend1011 { get; set; }
//        public virtual DbSet<Vend1012> Vend1012 { get; set; }
//        public virtual DbSet<Vend1013> Vend1013 { get; set; }
//        public virtual DbSet<Vend1014> Vend1014 { get; set; }
//        public virtual DbSet<Vend1015> Vend1015 { get; set; }
//        public virtual DbSet<Vend1016> Vend1016 { get; set; }
//        public virtual DbSet<Vend1017> Vend1017 { get; set; }
//        public virtual DbSet<Vend1018> Vend1018 { get; set; }
//        public virtual DbSet<Vend1019> Vend1019 { get; set; }
//        public virtual DbSet<Vend1100> Vend1100 { get; set; }
//        public virtual DbSet<Vend1101> Vend1101 { get; set; }
//        public virtual DbSet<Vend1102> Vend1102 { get; set; }
//        public virtual DbSet<Vend1103> Vend1103 { get; set; }
//        public virtual DbSet<Vend1104> Vend1104 { get; set; }
//        public virtual DbSet<Vend1105> Vend1105 { get; set; }
//        public virtual DbSet<Vend1106> Vend1106 { get; set; }
//        public virtual DbSet<Vend1107> Vend1107 { get; set; }
//        public virtual DbSet<Vend1108> Vend1108 { get; set; }
//        public virtual DbSet<Vend1109> Vend1109 { get; set; }
//        public virtual DbSet<Vend1110> Vend1110 { get; set; }
//        public virtual DbSet<Vend1111> Vend1111 { get; set; }
//        public virtual DbSet<Vend1112> Vend1112 { get; set; }
//        public virtual DbSet<Vend1113> Vend1113 { get; set; }
//        public virtual DbSet<Vend1114> Vend1114 { get; set; }
//        public virtual DbSet<Vend1115> Vend1115 { get; set; }
//        public virtual DbSet<Vend1116> Vend1116 { get; set; }
//        public virtual DbSet<Vend1117> Vend1117 { get; set; }
//        public virtual DbSet<Vend1118> Vend1118 { get; set; }
//        public virtual DbSet<Vend1119> Vend1119 { get; set; }
//        public virtual DbSet<Vend1170> Vend1170 { get; set; }
//        public virtual DbSet<Vend1200> Vend1200 { get; set; }
//        public virtual DbSet<Vend1201> Vend1201 { get; set; }
//        public virtual DbSet<Vend1202> Vend1202 { get; set; }
//        public virtual DbSet<Vend1203> Vend1203 { get; set; }
//        public virtual DbSet<Vend1204> Vend1204 { get; set; }
//        public virtual DbSet<Vend1205> Vend1205 { get; set; }
//        public virtual DbSet<Vend1206> Vend1206 { get; set; }
//        public virtual DbSet<Vend1207> Vend1207 { get; set; }
//        public virtual DbSet<Vend1208> Vend1208 { get; set; }
//        public virtual DbSet<Vend1209> Vend1209 { get; set; }
//        public virtual DbSet<Vend1210> Vend1210 { get; set; }
//        public virtual DbSet<Vend1211> Vend1211 { get; set; }
//        public virtual DbSet<Vend1212> Vend1212 { get; set; }
//        public virtual DbSet<Vend1213> Vend1213 { get; set; }
//        public virtual DbSet<Vend1214> Vend1214 { get; set; }
//        public virtual DbSet<Vend1215> Vend1215 { get; set; }
//        public virtual DbSet<Vend1216> Vend1216 { get; set; }
//        public virtual DbSet<Vend1217> Vend1217 { get; set; }
//        public virtual DbSet<Vend1218> Vend1218 { get; set; }
//        public virtual DbSet<Vend1219> Vend1219 { get; set; }
//        public virtual DbSet<Vend1270> Vend1270 { get; set; }
//        public virtual DbSet<Vend1293> Vend1293 { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBCore.Entities.Scaffoldedlder optionsBCore.Entities.Scaffoldedlder)
//        {
//            if (!optionsBCore.Entities.Scaffoldedlder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for gCore.Entities.Scaffoldeddance on storing connection strings.
//                optionsBCore.Entities.Scaffoldedlder.UseSqlServer("Data Source=DESKTOP-FTQLVQ6;Initial Catalog=Farmacia_db;Integrated Security=True;Pooling=False");
//            }
//        }

//        protected override void OnModelCreating(ModelBCore.Entities.Scaffoldedlder modelBCore.Entities.Scaffoldedlder)
//        {
//            modelBCore.Entities.Scaffoldedlder.Entity<Agenda>(entity =>
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

//            modelBCore.Entities.Scaffoldedlder.Entity<Balcon>(entity =>
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

//            modelBCore.Entities.Scaffoldedlder.Entity<Brindes>(entity =>
//            {
//                entity.ToTable("BRINDES");

//                entity.Property(e => e.Codigo).HasColumnName("CODIGO");

//                entity.Property(e => e.Nome).HasColumnName("NOME");

//                entity.Property(e => e.Pontos).HasColumnName("PONTOS");

//                entity.Property(e => e.Qtde).HasColumnName("QTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Cartao>(entity =>
//            {
//                entity.ToTable("CARTAO");

//                entity.Property(e => e.Codigo).HasColumnName("CODIGO");

//                entity.Property(e => e.Nome).HasColumnName("NOME");

//                entity.Property(e => e.Parcel).HasColumnName("PARCEL");

//                entity.Property(e => e.Prazo).HasColumnName("PRAZO");

//                entity.Property(e => e.Qtde).HasColumnName("QTDE");

//                entity.Property(e => e.Taxa).HasColumnName("TAXA");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<CliMed>(entity =>
//            {
//                entity.ToTable("CLI_MED");

//                entity.Property(e => e.CpfCrm).HasColumnName("CPF_CRM");

//                entity.Property(e => e.Endereco).HasColumnName("ENDERECO");

//                entity.Property(e => e.Fone).HasColumnName("FONE");

//                entity.Property(e => e.Nome).HasColumnName("NOME");

//                entity.Property(e => e.Sexo).HasColumnName("SEXO");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Contas>(entity =>
//            {
//                entity.ToTable("CONTAS");

//                entity.Property(e => e.Cod).HasColumnName("COD");

//                entity.Property(e => e.Hist).HasColumnName("HIST");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Empresa>(entity =>
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

//                entity.Property(e => e.EmgCore.Entities.Scaffoldeda).HasColumnName("EMGCore.Entities.ScaffoldedA");

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

//            modelBCore.Entities.Scaffoldedlder.Entity<Estq0045>(entity =>
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

//            modelBCore.Entities.Scaffoldedlder.Entity<Etiqperf>(entity =>
//            {
//                entity.ToTable("ETIQPERF");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prcons).HasColumnName("PRCONS");

//                entity.Property(e => e.Prconsf).HasColumnName("PRCONSF");

//                entity.Property(e => e.Prdesc1).HasColumnName("PRDESC1");

//                entity.Property(e => e.Prdesc2).HasColumnName("PRDESC2");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Etiqprom>(entity =>
//            {
//                entity.ToTable("ETIQPROM");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prcons).HasColumnName("PRCONS");

//                entity.Property(e => e.Prconsf).HasColumnName("PRCONSF");

//                entity.Property(e => e.Prdesc1).HasColumnName("PRDESC1");

//                entity.Property(e => e.Prdesc2).HasColumnName("PRDESC2");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Etiqueta>(entity =>
//            {
//                entity.ToTable("ETIQUETA");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prcons).HasColumnName("PRCONS");

//                entity.Property(e => e.Prdesc1).HasColumnName("PRDESC1");

//                entity.Property(e => e.Prdesc2).HasColumnName("PRDESC2");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Filial>(entity =>
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

//            modelBCore.Entities.Scaffoldedlder.Entity<Ibpt>(entity =>
//            {
//                entity.ToTable("IBPT");

//                entity.Property(e => e.Codigo).HasColumnName("CODIGO");

//                entity.Property(e => e.Imp1).HasColumnName("IMP1");

//                entity.Property(e => e.Imp2).HasColumnName("IMP2");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Invent>(entity =>
//            {
//                entity.ToTable("INVENT");

//                entity.Property(e => e.Lote).HasColumnName("LOTE");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prdesc).HasColumnName("PRDESC");

//                entity.Property(e => e.Prreg).HasColumnName("PRREG");

//                entity.Property(e => e.Qtde).HasColumnName("QTDE");

//                entity.Property(e => e.Tpmed).HasColumnName("TPMED");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Merctran>(entity =>
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

//            modelBCore.Entities.Scaffoldedlder.Entity<Natureza>(entity =>
//            {
//                entity.ToTable("NATUREZA");

//                entity.Property(e => e.Codigo).HasColumnName("CODIGO");

//                entity.Property(e => e.Nome).HasColumnName("NOME");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Newtab>(entity =>
//            {
//                entity.ToTable("NEWTAB");

//                entity.Property(e => e.Mesano).HasColumnName("MESANO");

//                entity.Property(e => e.Newtab1).HasColumnName("NEWTAB");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Nfe>(entity =>
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

//            modelBCore.Entities.Scaffoldedlder.Entity<Notaf>(entity =>
//            {
//                entity.ToTable("NOTAF");

//                entity.Property(e => e.NumNota).HasColumnName("NUM_NOTA");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Nped>(entity =>
//            {
//                entity.ToTable("NPED");

//                entity.Property(e => e.Numped).HasColumnName("NUMPED");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<NumTmp>(entity =>
//            {
//                entity.ToTable("NUM_TMP");

//                entity.Property(e => e.Numero).HasColumnName("NUMERO");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Numped>(entity =>
//            {
//                entity.ToTable("NUMPED");

//                entity.Property(e => e.Desconto).HasColumnName("DESCONTO");

//                entity.Property(e => e.Fornec).HasColumnName("FORNEC");

//                entity.Property(e => e.Numero).HasColumnName("NUMERO");

//                entity.Property(e => e.Przentrega).HasColumnName("PRZENTREGA");

//                entity.Property(e => e.Przpagto).HasColumnName("PRZPAGTO");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Ped0204>(entity =>
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

//            modelBCore.Entities.Scaffoldedlder.Entity<Ped0301>(entity =>
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

//            modelBCore.Entities.Scaffoldedlder.Entity<Ped0406>(entity =>
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

//            modelBCore.Entities.Scaffoldedlder.Entity<Ped1103>(entity =>
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

//            modelBCore.Entities.Scaffoldedlder.Entity<Ped1406>(entity =>
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

//            modelBCore.Entities.Scaffoldedlder.Entity<Ped1912>(entity =>
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

//            modelBCore.Entities.Scaffoldedlder.Entity<Prodextr>(entity =>
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

//            modelBCore.Entities.Scaffoldedlder.Entity<Reducao>(entity =>
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

//            modelBCore.Entities.Scaffoldedlder.Entity<ResAno>(entity =>
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

//            modelBCore.Entities.Scaffoldedlder.Entity<Sal>(entity =>
//            {
//                entity.ToTable("SAL");

//                entity.Property(e => e.Salcod).HasColumnName("SALCOD");

//                entity.Property(e => e.Salnome).HasColumnName("SALNOME");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Secao>(entity =>
//            {
//                entity.ToTable("SECAO");

//                entity.Property(e => e.Secodi).HasColumnName("SECODI");

//                entity.Property(e => e.Senome).HasColumnName("SENOME");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Servico>(entity =>
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

//            modelBCore.Entities.Scaffoldedlder.Entity<Sistema>(entity =>
//            {
//                entity.ToTable("SISTEMA");

//                entity.Property(e => e.Ticket).HasColumnName("TICKET");

//                entity.Property(e => e.Usuario).HasColumnName("USUARIO");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Slpharma>(entity =>
//            {
//                entity.ToTable("SLPHARMA");

//                entity.Property(e => e.Reconst).HasColumnName("RECONST");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Subsecao>(entity =>
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

//            modelBCore.Entities.Scaffoldedlder.Entity<Temp>(entity =>
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

//            modelBCore.Entities.Scaffoldedlder.Entity<Tempo>(entity =>
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

//            modelBCore.Entities.Scaffoldedlder.Entity<Ticket>(entity =>
//            {
//                entity.ToTable("TICKET");

//                entity.Property(e => e.Ecf).HasColumnName("ECF");

//                entity.Property(e => e.Ticket1).HasColumnName("TICKET");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Usefarma>(entity =>
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

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0100>(entity =>
//            {
//                entity.ToTable("VEND0100");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0101>(entity =>
//            {
//                entity.ToTable("VEND0101");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0102>(entity =>
//            {
//                entity.ToTable("VEND0102");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0103>(entity =>
//            {
//                entity.ToTable("VEND0103");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0104>(entity =>
//            {
//                entity.ToTable("VEND0104");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0105>(entity =>
//            {
//                entity.ToTable("VEND0105");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0106>(entity =>
//            {
//                entity.ToTable("VEND0106");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0107>(entity =>
//            {
//                entity.ToTable("VEND0107");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0108>(entity =>
//            {
//                entity.ToTable("VEND0108");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0109>(entity =>
//            {
//                entity.ToTable("VEND0109");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0110>(entity =>
//            {
//                entity.ToTable("VEND0110");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0111>(entity =>
//            {
//                entity.ToTable("VEND0111");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0112>(entity =>
//            {
//                entity.ToTable("VEND0112");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0113>(entity =>
//            {
//                entity.ToTable("VEND0113");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0114>(entity =>
//            {
//                entity.ToTable("VEND0114");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0115>(entity =>
//            {
//                entity.ToTable("VEND0115");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0116>(entity =>
//            {
//                entity.ToTable("VEND0116");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0117>(entity =>
//            {
//                entity.ToTable("VEND0117");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0118>(entity =>
//            {
//                entity.ToTable("VEND0118");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0119>(entity =>
//            {
//                entity.ToTable("VEND0119");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0120>(entity =>
//            {
//                entity.ToTable("VEND0120");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0171>(entity =>
//            {
//                entity.ToTable("VEND0171");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0194>(entity =>
//            {
//                entity.ToTable("VEND0194");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0197>(entity =>
//            {
//                entity.ToTable("VEND0197");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0199>(entity =>
//            {
//                entity.ToTable("VEND0199");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0200>(entity =>
//            {
//                entity.ToTable("VEND0200");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0201>(entity =>
//            {
//                entity.ToTable("VEND0201");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0202>(entity =>
//            {
//                entity.ToTable("VEND0202");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0203>(entity =>
//            {
//                entity.ToTable("VEND0203");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0204>(entity =>
//            {
//                entity.ToTable("VEND0204");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0205>(entity =>
//            {
//                entity.ToTable("VEND0205");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0206>(entity =>
//            {
//                entity.ToTable("VEND0206");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0207>(entity =>
//            {
//                entity.ToTable("VEND0207");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0208>(entity =>
//            {
//                entity.ToTable("VEND0208");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0209>(entity =>
//            {
//                entity.ToTable("VEND0209");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0210>(entity =>
//            {
//                entity.ToTable("VEND0210");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0211>(entity =>
//            {
//                entity.ToTable("VEND0211");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0212>(entity =>
//            {
//                entity.ToTable("VEND0212");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0213>(entity =>
//            {
//                entity.ToTable("VEND0213");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0214>(entity =>
//            {
//                entity.ToTable("VEND0214");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0215>(entity =>
//            {
//                entity.ToTable("VEND0215");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0216>(entity =>
//            {
//                entity.ToTable("VEND0216");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0217>(entity =>
//            {
//                entity.ToTable("VEND0217");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0218>(entity =>
//            {
//                entity.ToTable("VEND0218");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0219>(entity =>
//            {
//                entity.ToTable("VEND0219");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0220>(entity =>
//            {
//                entity.ToTable("VEND0220");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0271>(entity =>
//            {
//                entity.ToTable("VEND0271");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0300>(entity =>
//            {
//                entity.ToTable("VEND0300");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0301>(entity =>
//            {
//                entity.ToTable("VEND0301");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0302>(entity =>
//            {
//                entity.ToTable("VEND0302");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0303>(entity =>
//            {
//                entity.ToTable("VEND0303");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0304>(entity =>
//            {
//                entity.ToTable("VEND0304");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0305>(entity =>
//            {
//                entity.ToTable("VEND0305");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0306>(entity =>
//            {
//                entity.ToTable("VEND0306");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0307>(entity =>
//            {
//                entity.ToTable("VEND0307");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0308>(entity =>
//            {
//                entity.ToTable("VEND0308");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0309>(entity =>
//            {
//                entity.ToTable("VEND0309");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0310>(entity =>
//            {
//                entity.ToTable("VEND0310");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0311>(entity =>
//            {
//                entity.ToTable("VEND0311");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0312>(entity =>
//            {
//                entity.ToTable("VEND0312");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0313>(entity =>
//            {
//                entity.ToTable("VEND0313");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0314>(entity =>
//            {
//                entity.ToTable("VEND0314");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0315>(entity =>
//            {
//                entity.ToTable("VEND0315");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0316>(entity =>
//            {
//                entity.ToTable("VEND0316");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0317>(entity =>
//            {
//                entity.ToTable("VEND0317");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0318>(entity =>
//            {
//                entity.ToTable("VEND0318");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0319>(entity =>
//            {
//                entity.ToTable("VEND0319");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0394>(entity =>
//            {
//                entity.ToTable("VEND0394");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0400>(entity =>
//            {
//                entity.ToTable("VEND0400");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0401>(entity =>
//            {
//                entity.ToTable("VEND0401");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0402>(entity =>
//            {
//                entity.ToTable("VEND0402");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0403>(entity =>
//            {
//                entity.ToTable("VEND0403");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0404>(entity =>
//            {
//                entity.ToTable("VEND0404");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0405>(entity =>
//            {
//                entity.ToTable("VEND0405");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0406>(entity =>
//            {
//                entity.ToTable("VEND0406");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0407>(entity =>
//            {
//                entity.ToTable("VEND0407");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0408>(entity =>
//            {
//                entity.ToTable("VEND0408");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0409>(entity =>
//            {
//                entity.ToTable("VEND0409");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0410>(entity =>
//            {
//                entity.ToTable("VEND0410");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0411>(entity =>
//            {
//                entity.ToTable("VEND0411");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0412>(entity =>
//            {
//                entity.ToTable("VEND0412");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0413>(entity =>
//            {
//                entity.ToTable("VEND0413");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0414>(entity =>
//            {
//                entity.ToTable("VEND0414");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0415>(entity =>
//            {
//                entity.ToTable("VEND0415");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0416>(entity =>
//            {
//                entity.ToTable("VEND0416");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0417>(entity =>
//            {
//                entity.ToTable("VEND0417");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0418>(entity =>
//            {
//                entity.ToTable("VEND0418");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0419>(entity =>
//            {
//                entity.ToTable("VEND0419");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0494>(entity =>
//            {
//                entity.ToTable("VEND0494");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0500>(entity =>
//            {
//                entity.ToTable("VEND0500");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0501>(entity =>
//            {
//                entity.ToTable("VEND0501");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0502>(entity =>
//            {
//                entity.ToTable("VEND0502");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0503>(entity =>
//            {
//                entity.ToTable("VEND0503");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0504>(entity =>
//            {
//                entity.ToTable("VEND0504");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0505>(entity =>
//            {
//                entity.ToTable("VEND0505");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0506>(entity =>
//            {
//                entity.ToTable("VEND0506");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0507>(entity =>
//            {
//                entity.ToTable("VEND0507");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0508>(entity =>
//            {
//                entity.ToTable("VEND0508");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0509>(entity =>
//            {
//                entity.ToTable("VEND0509");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0510>(entity =>
//            {
//                entity.ToTable("VEND0510");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0511>(entity =>
//            {
//                entity.ToTable("VEND0511");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0512>(entity =>
//            {
//                entity.ToTable("VEND0512");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0513>(entity =>
//            {
//                entity.ToTable("VEND0513");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0514>(entity =>
//            {
//                entity.ToTable("VEND0514");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0515>(entity =>
//            {
//                entity.ToTable("VEND0515");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0516>(entity =>
//            {
//                entity.ToTable("VEND0516");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0517>(entity =>
//            {
//                entity.ToTable("VEND0517");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0518>(entity =>
//            {
//                entity.ToTable("VEND0518");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0519>(entity =>
//            {
//                entity.ToTable("VEND0519");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0594>(entity =>
//            {
//                entity.ToTable("VEND0594");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0600>(entity =>
//            {
//                entity.ToTable("VEND0600");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0601>(entity =>
//            {
//                entity.ToTable("VEND0601");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0602>(entity =>
//            {
//                entity.ToTable("VEND0602");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0603>(entity =>
//            {
//                entity.ToTable("VEND0603");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0604>(entity =>
//            {
//                entity.ToTable("VEND0604");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0605>(entity =>
//            {
//                entity.ToTable("VEND0605");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0606>(entity =>
//            {
//                entity.ToTable("VEND0606");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0607>(entity =>
//            {
//                entity.ToTable("VEND0607");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0608>(entity =>
//            {
//                entity.ToTable("VEND0608");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0609>(entity =>
//            {
//                entity.ToTable("VEND0609");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0610>(entity =>
//            {
//                entity.ToTable("VEND0610");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0611>(entity =>
//            {
//                entity.ToTable("VEND0611");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0612>(entity =>
//            {
//                entity.ToTable("VEND0612");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0613>(entity =>
//            {
//                entity.ToTable("VEND0613");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0614>(entity =>
//            {
//                entity.ToTable("VEND0614");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0615>(entity =>
//            {
//                entity.ToTable("VEND0615");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0616>(entity =>
//            {
//                entity.ToTable("VEND0616");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0617>(entity =>
//            {
//                entity.ToTable("VEND0617");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0618>(entity =>
//            {
//                entity.ToTable("VEND0618");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0619>(entity =>
//            {
//                entity.ToTable("VEND0619");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0694>(entity =>
//            {
//                entity.ToTable("VEND0694");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0700>(entity =>
//            {
//                entity.ToTable("VEND0700");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0701>(entity =>
//            {
//                entity.ToTable("VEND0701");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0702>(entity =>
//            {
//                entity.ToTable("VEND0702");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0703>(entity =>
//            {
//                entity.ToTable("VEND0703");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0704>(entity =>
//            {
//                entity.ToTable("VEND0704");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0705>(entity =>
//            {
//                entity.ToTable("VEND0705");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0706>(entity =>
//            {
//                entity.ToTable("VEND0706");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0707>(entity =>
//            {
//                entity.ToTable("VEND0707");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0708>(entity =>
//            {
//                entity.ToTable("VEND0708");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0709>(entity =>
//            {
//                entity.ToTable("VEND0709");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0710>(entity =>
//            {
//                entity.ToTable("VEND0710");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0711>(entity =>
//            {
//                entity.ToTable("VEND0711");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0712>(entity =>
//            {
//                entity.ToTable("VEND0712");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0713>(entity =>
//            {
//                entity.ToTable("VEND0713");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0714>(entity =>
//            {
//                entity.ToTable("VEND0714");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0715>(entity =>
//            {
//                entity.ToTable("VEND0715");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0716>(entity =>
//            {
//                entity.ToTable("VEND0716");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0717>(entity =>
//            {
//                entity.ToTable("VEND0717");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0718>(entity =>
//            {
//                entity.ToTable("VEND0718");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0719>(entity =>
//            {
//                entity.ToTable("VEND0719");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0794>(entity =>
//            {
//                entity.ToTable("VEND0794");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0800>(entity =>
//            {
//                entity.ToTable("VEND0800");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0801>(entity =>
//            {
//                entity.ToTable("VEND0801");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0802>(entity =>
//            {
//                entity.ToTable("VEND0802");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0803>(entity =>
//            {
//                entity.ToTable("VEND0803");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0804>(entity =>
//            {
//                entity.ToTable("VEND0804");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0805>(entity =>
//            {
//                entity.ToTable("VEND0805");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0806>(entity =>
//            {
//                entity.ToTable("VEND0806");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0807>(entity =>
//            {
//                entity.ToTable("VEND0807");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0808>(entity =>
//            {
//                entity.ToTable("VEND0808");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0809>(entity =>
//            {
//                entity.ToTable("VEND0809");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0810>(entity =>
//            {
//                entity.ToTable("VEND0810");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0811>(entity =>
//            {
//                entity.ToTable("VEND0811");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0812>(entity =>
//            {
//                entity.ToTable("VEND0812");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0813>(entity =>
//            {
//                entity.ToTable("VEND0813");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0814>(entity =>
//            {
//                entity.ToTable("VEND0814");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0815>(entity =>
//            {
//                entity.ToTable("VEND0815");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0816>(entity =>
//            {
//                entity.ToTable("VEND0816");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0817>(entity =>
//            {
//                entity.ToTable("VEND0817");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0818>(entity =>
//            {
//                entity.ToTable("VEND0818");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0819>(entity =>
//            {
//                entity.ToTable("VEND0819");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0894>(entity =>
//            {
//                entity.ToTable("VEND0894");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0900>(entity =>
//            {
//                entity.ToTable("VEND0900");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0901>(entity =>
//            {
//                entity.ToTable("VEND0901");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0902>(entity =>
//            {
//                entity.ToTable("VEND0902");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0903>(entity =>
//            {
//                entity.ToTable("VEND0903");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0904>(entity =>
//            {
//                entity.ToTable("VEND0904");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0905>(entity =>
//            {
//                entity.ToTable("VEND0905");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0906>(entity =>
//            {
//                entity.ToTable("VEND0906");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0907>(entity =>
//            {
//                entity.ToTable("VEND0907");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0908>(entity =>
//            {
//                entity.ToTable("VEND0908");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0909>(entity =>
//            {
//                entity.ToTable("VEND0909");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0910>(entity =>
//            {
//                entity.ToTable("VEND0910");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0911>(entity =>
//            {
//                entity.ToTable("VEND0911");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0912>(entity =>
//            {
//                entity.ToTable("VEND0912");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0913>(entity =>
//            {
//                entity.ToTable("VEND0913");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0914>(entity =>
//            {
//                entity.ToTable("VEND0914");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0915>(entity =>
//            {
//                entity.ToTable("VEND0915");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0916>(entity =>
//            {
//                entity.ToTable("VEND0916");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0917>(entity =>
//            {
//                entity.ToTable("VEND0917");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0918>(entity =>
//            {
//                entity.ToTable("VEND0918");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0919>(entity =>
//            {
//                entity.ToTable("VEND0919");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend0994>(entity =>
//            {
//                entity.ToTable("VEND0994");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1000>(entity =>
//            {
//                entity.ToTable("VEND1000");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1001>(entity =>
//            {
//                entity.ToTable("VEND1001");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1002>(entity =>
//            {
//                entity.ToTable("VEND1002");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1003>(entity =>
//            {
//                entity.ToTable("VEND1003");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1004>(entity =>
//            {
//                entity.ToTable("VEND1004");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1005>(entity =>
//            {
//                entity.ToTable("VEND1005");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1006>(entity =>
//            {
//                entity.ToTable("VEND1006");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1007>(entity =>
//            {
//                entity.ToTable("VEND1007");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1008>(entity =>
//            {
//                entity.ToTable("VEND1008");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1009>(entity =>
//            {
//                entity.ToTable("VEND1009");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1010>(entity =>
//            {
//                entity.ToTable("VEND1010");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1011>(entity =>
//            {
//                entity.ToTable("VEND1011");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1012>(entity =>
//            {
//                entity.ToTable("VEND1012");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1013>(entity =>
//            {
//                entity.ToTable("VEND1013");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1014>(entity =>
//            {
//                entity.ToTable("VEND1014");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1015>(entity =>
//            {
//                entity.ToTable("VEND1015");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1016>(entity =>
//            {
//                entity.ToTable("VEND1016");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1017>(entity =>
//            {
//                entity.ToTable("VEND1017");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1018>(entity =>
//            {
//                entity.ToTable("VEND1018");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1019>(entity =>
//            {
//                entity.ToTable("VEND1019");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1100>(entity =>
//            {
//                entity.ToTable("VEND1100");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1101>(entity =>
//            {
//                entity.ToTable("VEND1101");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1102>(entity =>
//            {
//                entity.ToTable("VEND1102");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1103>(entity =>
//            {
//                entity.ToTable("VEND1103");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1104>(entity =>
//            {
//                entity.ToTable("VEND1104");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1105>(entity =>
//            {
//                entity.ToTable("VEND1105");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1106>(entity =>
//            {
//                entity.ToTable("VEND1106");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1107>(entity =>
//            {
//                entity.ToTable("VEND1107");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1108>(entity =>
//            {
//                entity.ToTable("VEND1108");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1109>(entity =>
//            {
//                entity.ToTable("VEND1109");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1110>(entity =>
//            {
//                entity.ToTable("VEND1110");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1111>(entity =>
//            {
//                entity.ToTable("VEND1111");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1112>(entity =>
//            {
//                entity.ToTable("VEND1112");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1113>(entity =>
//            {
//                entity.ToTable("VEND1113");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1114>(entity =>
//            {
//                entity.ToTable("VEND1114");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1115>(entity =>
//            {
//                entity.ToTable("VEND1115");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1116>(entity =>
//            {
//                entity.ToTable("VEND1116");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1117>(entity =>
//            {
//                entity.ToTable("VEND1117");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1118>(entity =>
//            {
//                entity.ToTable("VEND1118");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1119>(entity =>
//            {
//                entity.ToTable("VEND1119");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1170>(entity =>
//            {
//                entity.ToTable("VEND1170");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1200>(entity =>
//            {
//                entity.ToTable("VEND1200");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1201>(entity =>
//            {
//                entity.ToTable("VEND1201");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1202>(entity =>
//            {
//                entity.ToTable("VEND1202");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1203>(entity =>
//            {
//                entity.ToTable("VEND1203");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1204>(entity =>
//            {
//                entity.ToTable("VEND1204");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1205>(entity =>
//            {
//                entity.ToTable("VEND1205");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1206>(entity =>
//            {
//                entity.ToTable("VEND1206");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1207>(entity =>
//            {
//                entity.ToTable("VEND1207");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1208>(entity =>
//            {
//                entity.ToTable("VEND1208");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1209>(entity =>
//            {
//                entity.ToTable("VEND1209");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1210>(entity =>
//            {
//                entity.ToTable("VEND1210");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1211>(entity =>
//            {
//                entity.ToTable("VEND1211");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1212>(entity =>
//            {
//                entity.ToTable("VEND1212");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1213>(entity =>
//            {
//                entity.ToTable("VEND1213");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1214>(entity =>
//            {
//                entity.ToTable("VEND1214");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1215>(entity =>
//            {
//                entity.ToTable("VEND1215");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1216>(entity =>
//            {
//                entity.ToTable("VEND1216");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1217>(entity =>
//            {
//                entity.ToTable("VEND1217");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1218>(entity =>
//            {
//                entity.ToTable("VEND1218");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1219>(entity =>
//            {
//                entity.ToTable("VEND1219");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1270>(entity =>
//            {
//                entity.ToTable("VEND1270");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            modelBCore.Entities.Scaffoldedlder.Entity<Vend1293>(entity =>
//            {
//                entity.ToTable("VEND1293");

//                entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

//                entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");
//            });

//            OnModelCreatingPartial(modelBCore.Entities.Scaffoldedlder);
//        }

//        partial void OnModelCreatingPartial(ModelBCore.Entities.Scaffoldedlder modelBCore.Entities.Scaffoldedlder);
//    }
//}
