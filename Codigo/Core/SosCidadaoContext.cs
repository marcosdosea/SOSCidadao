﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Core
{
    public partial class SosCidadaoContext : DbContext
    {
        public SosCidadaoContext()
        {
        }

        public SosCidadaoContext(DbContextOptions<SosCidadaoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anexo> Anexo { get; set; }
        public virtual DbSet<Aspnetroleclaims> Aspnetroleclaims { get; set; }
        public virtual DbSet<Aspnetroles> Aspnetroles { get; set; }
        public virtual DbSet<Aspnetuserclaims> Aspnetuserclaims { get; set; }
        public virtual DbSet<Aspnetuserlogins> Aspnetuserlogins { get; set; }
        public virtual DbSet<Aspnetuserroles> Aspnetuserroles { get; set; }
        public virtual DbSet<Aspnetusers> Aspnetusers { get; set; }
        public virtual DbSet<Aspnetusertokens> Aspnetusertokens { get; set; }
        public virtual DbSet<Atendimentoocorrencia> Atendimentoocorrencia { get; set; }
        public virtual DbSet<Comentario> Comentario { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistory { get; set; }
        public virtual DbSet<Identityuser> Identityuser { get; set; }
        public virtual DbSet<Local> Local { get; set; }
        public virtual DbSet<Ocorrencia> Ocorrencia { get; set; }
        public virtual DbSet<Ocorrenciatipoocorrencia> Ocorrenciatipoocorrencia { get; set; }
        public virtual DbSet<Organizacao> Organizacao { get; set; }
        public virtual DbSet<Pertence> Pertence { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<Tipoocorrencia> Tipoocorrencia { get; set; }
        public virtual DbSet<Tipopertence> Tipopertence { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anexo>(entity =>
            {
                entity.HasKey(e => e.IdAnexoPertence)
                    .HasName("PRIMARY");

                entity.ToTable("anexo");

                entity.HasIndex(e => e.IdOcorrencia)
                    .HasName("fk_Anexo_Ocorrencia_idx");

                entity.HasIndex(e => e.IdPessoa)
                    .HasName("fk_Anexo_Pessoa1_idx");

                entity.Property(e => e.IdAnexoPertence)
                    .HasColumnName("idAnexoPertence")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdOcorrencia)
                    .HasColumnName("idOcorrencia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdPessoa)
                    .HasColumnName("idPessoa")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(250);

                entity.Property(e => e.UrlArquivo)
                    .IsRequired()
                    .HasColumnName("urlArquivo")
                    .HasMaxLength(250);

                entity.HasOne(d => d.IdOcorrenciaNavigation)
                    .WithMany(p => p.Anexo)
                    .HasForeignKey(d => d.IdOcorrencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Anexo_Ocorrencia");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Anexo)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Anexo_Pessoa1");
            });

            modelBuilder.Entity<Aspnetroleclaims>(entity =>
            {
                entity.ToTable("aspnetroleclaims");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(85);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetroleclaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
            });

            modelBuilder.Entity<Aspnetroles>(entity =>
            {
                entity.ToTable("aspnetroles");

                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(85);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(85);
            });

            modelBuilder.Entity<Aspnetuserclaims>(entity =>
            {
                entity.ToTable("aspnetuserclaims");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserClaims_UserId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(85);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserclaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserlogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PRIMARY");

                entity.ToTable("aspnetuserlogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(85);

                entity.Property(e => e.ProviderKey).HasMaxLength(85);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(85);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserlogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserroles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PRIMARY");

                entity.ToTable("aspnetuserroles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetUserRoles_RoleId");

                entity.Property(e => e.UserId).HasMaxLength(85);

                entity.Property(e => e.RoleId).HasMaxLength(85);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetusers>(entity =>
            {
                entity.ToTable("aspnetusers");

                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Aspnetusertokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PRIMARY");

                entity.ToTable("aspnetusertokens");

                entity.Property(e => e.UserId).HasMaxLength(85);

                entity.Property(e => e.LoginProvider).HasMaxLength(85);

                entity.Property(e => e.Name).HasMaxLength(85);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetusertokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Atendimentoocorrencia>(entity =>
            {
                entity.HasKey(e => e.IdAtendimentoOcorrencia)
                    .HasName("PRIMARY");

                entity.ToTable("atendimentoocorrencia");

                entity.HasIndex(e => e.IdOcorrencia)
                    .HasName("fk_AtendimentoOcorrencia_Ocorrencia1_idx");

                entity.HasIndex(e => e.IdPessoa)
                    .HasName("fk_AtendimentoOcorrencia_Pessoa1_idx");

                entity.Property(e => e.IdAtendimentoOcorrencia)
                    .HasColumnName("idAtendimentoOcorrencia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdOcorrencia)
                    .HasColumnName("idOcorrencia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdPessoa)
                    .HasColumnName("idPessoa")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdOcorrenciaNavigation)
                    .WithMany(p => p.Atendimentoocorrencia)
                    .HasForeignKey(d => d.IdOcorrencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AtendimentoOcorrencia_Ocorrencia1");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Atendimentoocorrencia)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AtendimentoOcorrencia_Pessoa1");
            });

            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.HasKey(e => e.IdComentario)
                    .HasName("PRIMARY");

                entity.ToTable("comentario");

                entity.HasIndex(e => e.IdOcorrencia)
                    .HasName("fk_Comentario_Ocorrencia1_idx");

                entity.HasIndex(e => e.IidPessoa)
                    .HasName("fk_Comentario_Pessoa1_idx");

                entity.Property(e => e.IdComentario)
                    .HasColumnName("idComentario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao");

                entity.Property(e => e.IdOcorrencia)
                    .HasColumnName("idOcorrencia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IidPessoa)
                    .HasColumnName("iidPessoa")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdOcorrenciaNavigation)
                    .WithMany(p => p.Comentario)
                    .HasForeignKey(d => d.IdOcorrencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Comentario_Ocorrencia1");

                entity.HasOne(d => d.IidPessoaNavigation)
                    .WithMany(p => p.Comentario)
                    .HasForeignKey(d => d.IidPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Comentario_Pessoa1");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Identityuser>(entity =>
            {
                entity.ToTable("identityuser");

                entity.Property(e => e.Id).HasMaxLength(85);

                entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(85);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(85);
            });

            modelBuilder.Entity<Local>(entity =>
            {
                entity.HasKey(e => e.IdLocal)
                    .HasName("PRIMARY");

                entity.ToTable("local");

                entity.HasIndex(e => e.IdOrganizacao)
                    .HasName("fk_Local_Organizacao1_idx");

                entity.Property(e => e.IdLocal)
                    .HasColumnName("idLocal")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Bairro)
                    .HasColumnName("bairro")
                    .HasMaxLength(250);

                entity.Property(e => e.Cep)
                    .HasColumnName("cep")
                    .HasMaxLength(10);

                entity.Property(e => e.Cidade)
                    .HasColumnName("cidade")
                    .HasMaxLength(250);

                entity.Property(e => e.IdOrganizacao)
                    .HasColumnName("idOrganizacao")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(250);

                entity.Property(e => e.NumeroEndereco)
                    .HasColumnName("numeroEndereco")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Rua)
                    .HasColumnName("rua")
                    .HasMaxLength(250);

                entity.Property(e => e.Uf)
                    .HasColumnName("uf")
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.HasOne(d => d.IdOrganizacaoNavigation)
                    .WithMany(p => p.Local)
                    .HasForeignKey(d => d.IdOrganizacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Local_Organizacao1");
            });

            modelBuilder.Entity<Ocorrencia>(entity =>
            {
                entity.HasKey(e => e.IdOcorrencia)
                    .HasName("PRIMARY");

                entity.ToTable("ocorrencia");

                entity.HasIndex(e => e.IdLocal)
                    .HasName("fk_Ocorrencia_Local1_idx");

                entity.HasIndex(e => e.IdPessoaSolicitante)
                    .HasName("fk_Ocorrencia_Pessoa1_idx");

                entity.Property(e => e.IdOcorrencia)
                    .HasColumnName("idOcorrencia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descricao).HasColumnName("descricao");

                entity.Property(e => e.Emergencia)
                    .HasColumnName("emergencia")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.IdLocal)
                    .HasColumnName("idLocal")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdPessoaSolicitante)
                    .HasColumnName("idPessoaSolicitante")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StatusOcorrencia)
                    .IsRequired()
                    .HasColumnName("statusOcorrencia")
                    .HasColumnType("enum('Em andamento','Em aberto','Arquivada','Atendida','Inativa')")
                    .HasDefaultValueSql("'Em aberto'");

                entity.Property(e => e.TelefoneContato)
                    .HasColumnName("telefoneContato")
                    .HasMaxLength(15);

                entity.HasOne(d => d.IdLocalNavigation)
                    .WithMany(p => p.Ocorrencia)
                    .HasForeignKey(d => d.IdLocal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Ocorrencia_Local1");

                entity.HasOne(d => d.IdPessoaSolicitanteNavigation)
                    .WithMany(p => p.Ocorrencia)
                    .HasForeignKey(d => d.IdPessoaSolicitante)
                    .HasConstraintName("fk_Ocorrencia_Pessoa1");
            });

            modelBuilder.Entity<Ocorrenciatipoocorrencia>(entity =>
            {
                entity.HasKey(e => e.IdOcorrenciaTipoOcorrencia)
                    .HasName("PRIMARY");

                entity.ToTable("ocorrenciatipoocorrencia");

                entity.HasIndex(e => e.IdOcorrencia)
                    .HasName("fk_OcorrenciaTipoOcorrencia_Ocorrencia1_idx");

                entity.HasIndex(e => e.IdTipoOcorrencia)
                    .HasName("fk_OcorrenciaTipoOcorrencia_TipoOcorrencia1_idx");

                entity.Property(e => e.IdOcorrenciaTipoOcorrencia)
                    .HasColumnName("idOcorrenciaTipoOcorrencia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdOcorrencia)
                    .HasColumnName("idOcorrencia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTipoOcorrencia)
                    .HasColumnName("idTipoOcorrencia")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdOcorrenciaNavigation)
                    .WithMany(p => p.Ocorrenciatipoocorrencia)
                    .HasForeignKey(d => d.IdOcorrencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_OcorrenciaTipoOcorrencia_Ocorrencia1");

                entity.HasOne(d => d.IdTipoOcorrenciaNavigation)
                    .WithMany(p => p.Ocorrenciatipoocorrencia)
                    .HasForeignKey(d => d.IdTipoOcorrencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_OcorrenciaTipoOcorrencia_TipoOcorrencia1");
            });

            modelBuilder.Entity<Organizacao>(entity =>
            {
                entity.HasKey(e => e.IdOrganizacao)
                    .HasName("PRIMARY");

                entity.ToTable("organizacao");

                entity.HasIndex(e => e.Cnpj)
                    .HasName("cpj_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdPessoa)
                    .HasName("fk_Organizacao_Pessoa1_idx");

                entity.Property(e => e.IdOrganizacao)
                    .HasColumnName("idOrganizacao")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasColumnName("bairro")
                    .HasMaxLength(250);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnName("cep")
                    .HasMaxLength(10);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("cidade")
                    .HasMaxLength(250);

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("cnpj")
                    .HasMaxLength(14);

                entity.Property(e => e.IdPessoa)
                    .HasColumnName("idPessoa")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasColumnName("nomeFantasia")
                    .HasMaxLength(250);

                entity.Property(e => e.NomeRazao)
                    .IsRequired()
                    .HasColumnName("nomeRazao")
                    .HasMaxLength(250);

                entity.Property(e => e.NumeroEndereco)
                    .HasColumnName("numeroEndereco")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Rua)
                    .IsRequired()
                    .HasColumnName("rua")
                    .HasMaxLength(250);

                entity.Property(e => e.Uf)
                    .IsRequired()
                    .HasColumnName("uf")
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Organizacao)
                    .HasForeignKey(d => d.IdPessoa)
                    .HasConstraintName("fk_Organizacao_Pessoa1");
            });

            modelBuilder.Entity<Pertence>(entity =>
            {
                entity.HasKey(e => e.IdPertence)
                    .HasName("PRIMARY");

                entity.ToTable("pertence");

                entity.HasIndex(e => e.IdOcorrencia)
                    .HasName("fk_Pertence_Ocorrencia1_idx");

                entity.HasIndex(e => e.IdTipoPertence)
                    .HasName("fk_Pertence_TipoPertence1_idx");

                entity.Property(e => e.IdPertence)
                    .HasColumnName("idPertence")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descricao).HasColumnName("descricao");

                entity.Property(e => e.IdOcorrencia)
                    .HasColumnName("idOcorrencia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTipoPertence)
                    .HasColumnName("idTipoPertence")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(250);

                entity.Property(e => e.StatusPertence)
                    .IsRequired()
                    .HasColumnName("statusPertence")
                    .HasColumnType("enum('Em análise','Arquivado','Encontrado','Entregue')")
                    .HasDefaultValueSql("'Em análise'");

                entity.HasOne(d => d.IdOcorrenciaNavigation)
                    .WithMany(p => p.Pertence)
                    .HasForeignKey(d => d.IdOcorrencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Pertence_Ocorrencia1");

                entity.HasOne(d => d.IdTipoPertenceNavigation)
                    .WithMany(p => p.Pertence)
                    .HasForeignKey(d => d.IdTipoPertence)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Pertence_TipoPertence1");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(e => e.IdPessoa)
                    .HasName("PRIMARY");

                entity.ToTable("pessoa");

                entity.HasIndex(e => e.Cpf)
                    .HasName("cpf_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("email_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdOrganizacao)
                    .HasName("fk_Pessoa_Organizacao1_idx");

                entity.Property(e => e.IdPessoa)
                    .HasColumnName("idPessoa")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasColumnName("bairro")
                    .HasMaxLength(250);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnName("cep")
                    .HasMaxLength(10);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("cidade")
                    .HasMaxLength(250);

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("cpf")
                    .HasMaxLength(15);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(250);

                entity.Property(e => e.IdOrganizacao)
                    .HasColumnName("idOrganizacao")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(250);

                entity.Property(e => e.NumeroEndereco)
                    .HasColumnName("numeroEndereco")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Rua)
                    .IsRequired()
                    .HasColumnName("rua")
                    .HasMaxLength(250);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasColumnName("sexo")
                    .HasColumnType("enum('F','M')")
                    .HasDefaultValueSql("'M'");

                entity.Property(e => e.StatusPessoa)
                    .IsRequired()
                    .HasColumnName("statusPessoa")
                    .HasColumnType("enum('Ativo','Inativo','Excluido')")
                    .HasDefaultValueSql("'Ativo'");

                entity.Property(e => e.Telefone)
                    .HasColumnName("telefone")
                    .HasMaxLength(16);

                entity.Property(e => e.TipoPessoa)
                    .IsRequired()
                    .HasColumnName("tipoPessoa")
                    .HasColumnType("enum('Pessoa','Agente','Administrador')")
                    .HasDefaultValueSql("'Pessoa'");

                entity.Property(e => e.Uf)
                    .IsRequired()
                    .HasColumnName("uf")
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.HasOne(d => d.IdOrganizacaoNavigation)
                    .WithMany(p => p.Pessoa)
                    .HasForeignKey(d => d.IdOrganizacao)
                    .HasConstraintName("fk_Pessoa_Organizacao1");
            });

            modelBuilder.Entity<Tipoocorrencia>(entity =>
            {
                entity.HasKey(e => e.IdTipoOcorrencia)
                    .HasName("PRIMARY");

                entity.ToTable("tipoocorrencia");

                entity.HasIndex(e => e.IdOrganizacao)
                    .HasName("fk_TipoOcorrencia_Organizacao1_idx");

                entity.HasIndex(e => e.Nome)
                    .HasName("nome_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdTipoOcorrencia)
                    .HasColumnName("idTipoOcorrencia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdOrganizacao)
                    .HasColumnName("idOrganizacao")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45);

                entity.HasOne(d => d.IdOrganizacaoNavigation)
                    .WithMany(p => p.Tipoocorrencia)
                    .HasForeignKey(d => d.IdOrganizacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TipoOcorrencia_Organizacao1");
            });

            modelBuilder.Entity<Tipopertence>(entity =>
            {
                entity.HasKey(e => e.IdTipoPertence)
                    .HasName("PRIMARY");

                entity.ToTable("tipopertence");

                entity.HasIndex(e => e.IdOrganizacao)
                    .HasName("fk_TipoPertence_Organizacao1_idx");

                entity.Property(e => e.IdTipoPertence)
                    .HasColumnName("idTipoPertence")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdOrganizacao)
                    .HasColumnName("idOrganizacao")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45);

                entity.HasOne(d => d.IdOrganizacaoNavigation)
                    .WithMany(p => p.Tipopertence)
                    .HasForeignKey(d => d.IdOrganizacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TipoPertence_Organizacao1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
