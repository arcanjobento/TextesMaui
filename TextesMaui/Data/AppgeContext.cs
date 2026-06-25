using Microsoft.EntityFrameworkCore;

namespace TextesMaui.Data;

public partial class AppgeContext : DbContext
{
    public AppgeContext()
    {
    }

    public AppgeContext(DbContextOptions<AppgeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aluno> Alunos { get; set; }

    public virtual DbSet<Ano> Anos { get; set; }

    public virtual DbSet<Chat> Chats { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<ControlDeSesao> ControlDeSesaos { get; set; }

    public virtual DbSet<Despesa> Despesas { get; set; }

    public virtual DbSet<Disciplina> Disciplinas { get; set; }

    public virtual DbSet<Documento> Documentos { get; set; }

    public virtual DbSet<DocumentosAluno> DocumentosAlunos { get; set; }

    public virtual DbSet<Encarregado> Encarregados { get; set; }

    public virtual DbSet<EncarregadoDosAluno> EncarregadoDosAlunos { get; set; }

    public virtual DbSet<Funcionario> Funcionarios { get; set; }

    public virtual DbSet<GrupoChat> GrupoChats { get; set; }

    public virtual DbSet<InforEscola> InforEscolas { get; set; }

    public virtual DbSet<Me> Mes { get; set; }

    public virtual DbSet<Membro> Membros { get; set; }

    public virtual DbSet<MiniPautum> MiniPauta { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<NotificationView> NotificationViews { get; set; }

    public virtual DbSet<OutrosPagamento> OutrosPagamentos { get; set; }

    public virtual DbSet<PagamentoEmulumento> PagamentoEmulumentos { get; set; }

    public virtual DbSet<PagamentoFuncio> PagamentoFuncios { get; set; }

    public virtual DbSet<PagamentoUniforme> PagamentoUniformes { get; set; }

    public virtual DbSet<PlanificarAula> PlanificarAulas { get; set; }

    public virtual DbSet<PresencaAluno> PresencaAlunos { get; set; }

    public virtual DbSet<PresencaFuncionario> PresencaFuncionarios { get; set; }

    public virtual DbSet<Propina> Propinas { get; set; }

    public virtual DbSet<TurmaDoAluno> TurmaDoAlunos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=appge;user=root;password=MysqlAppge051219*?", Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.3.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Aluno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("alunos")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Nome, "nome_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AlunosDescri).HasColumnName("alunos_descri");
            entity.Property(e => e.Bairrro)
                .HasMaxLength(90)
                .HasColumnName("bairrro");
            entity.Property(e => e.Casa)
                .HasMaxLength(45)
                .HasColumnName("casa");
            entity.Property(e => e.Codigo)
                .HasMaxLength(16)
                .HasColumnName("codigo");
            entity.Property(e => e.Comuna)
                .HasMaxLength(100)
                .HasColumnName("comuna");
            entity.Property(e => e.DataDoc).HasColumnName("data_doc");
            entity.Property(e => e.DataNascimento).HasColumnName("data_nascimento");
            entity.Property(e => e.DescriDoente).HasColumnName("descri_doente");
            entity.Property(e => e.Doente)
                .HasColumnType("enum('sim','não')")
                .HasColumnName("doente");
            entity.Property(e => e.Foto)
                .HasMaxLength(500)
                .HasColumnName("foto");
            entity.Property(e => e.Mae)
                .HasMaxLength(90)
                .HasColumnName("mae");
            entity.Property(e => e.Municipio)
                .HasMaxLength(90)
                .HasColumnName("municipio");
            entity.Property(e => e.MunicipioDoc)
                .HasMaxLength(100)
                .HasColumnName("municipio_doc");
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(90)
                .HasColumnName("nome");
            entity.Property(e => e.NumeroDoc)
                .HasMaxLength(100)
                .HasColumnName("numero_doc");
            entity.Property(e => e.Pai)
                .HasMaxLength(90)
                .HasColumnName("pai");
            entity.Property(e => e.ProvinciaDoc)
                .HasMaxLength(100)
                .HasColumnName("provincia_doc");
            entity.Property(e => e.Quarteirao)
                .HasMaxLength(45)
                .HasColumnName("quarteirao");
            entity.Property(e => e.Rua)
                .HasMaxLength(255)
                .HasColumnName("rua");
            entity.Property(e => e.Sexo)
                .HasColumnType("enum('F','M')")
                .HasColumnName("sexo");
            entity.Property(e => e.ValorConta)
                .HasDefaultValueSql("'0'")
                .HasColumnName("valor_conta");
        });

        modelBuilder.Entity<Ano>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("ano")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.DataCocmeco, "data_cocmeco_UNIQUE").IsUnique();

            entity.HasIndex(e => e.DataFim, "data_fim_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Nome, "nome_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Orden, "orden_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataCocmeco).HasColumnName("data_cocmeco");
            entity.Property(e => e.DataFim).HasColumnName("data_fim");
            entity.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("'actual'")
                .HasColumnType("enum('actual','passado')")
                .HasColumnName("estado");
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("nome");
            entity.Property(e => e.Orden).HasColumnName("orden");
            entity.Property(e => e.Uso)
                .IsRequired()
                .HasDefaultValueSql("'aberto'")
                .HasColumnType("enum('aberto','fechado')")
                .HasColumnName("uso");
        });

        modelBuilder.Entity<Chat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("chat")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.FuncionarioEnviou, "fk_CHAT_Funcionario1_idx");

            entity.HasIndex(e => e.GrupoChatId, "fk_CHAT_grupo_chat1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.FuncionarioEnviou).HasColumnName("Funcionario_enviou");
            entity.Property(e => e.GrupoChatId).HasColumnName("grupo_chat_id");
            entity.Property(e => e.TextMessage).HasColumnName("text_message");
            entity.Property(e => e.Visto)
                .HasDefaultValueSql("'não'")
                .HasColumnType("enum('não','sim')")
                .HasColumnName("visto");

            entity.HasOne(d => d.FuncionarioEnviouNavigation).WithMany(p => p.Chats)
                .HasForeignKey(d => d.FuncionarioEnviou)
                .HasConstraintName("fk_CHAT_Funcionario1");

            entity.HasOne(d => d.GrupoChat).WithMany(p => p.Chats)
                .HasForeignKey(d => d.GrupoChatId)
                .HasConstraintName("fk_CHAT_grupo_chat1");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("classes")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.AnoId, "fk_classes_ano1_idx");

            entity.HasIndex(e => e.Identificador, "identificador_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnoId).HasColumnName("ano_id");
            entity.Property(e => e.Exame)
                .HasColumnType("enum('não','sim')")
                .HasColumnName("exame");
            entity.Property(e => e.Identificador)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("identificador");
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(12)
                .HasColumnName("nome");
            entity.Property(e => e.Orden).HasColumnName("orden");
            entity.Property(e => e.Preco).HasColumnName("preco");
            entity.Property(e => e.Sala)
                .HasMaxLength(20)
                .HasColumnName("sala");
            entity.Property(e => e.Turma)
                .IsRequired()
                .HasMaxLength(10)
                .HasDefaultValueSql("'A'")
                .HasColumnName("turma");
            entity.Property(e => e.Turno)
                .HasColumnType("enum('MANHÃ','TARDE','NOITE')")
                .HasColumnName("turno");

            entity.HasOne(d => d.Ano).WithMany(p => p.Classes)
                .HasForeignKey(d => d.AnoId)
                .HasConstraintName("fk_classes_ano1");
        });

        modelBuilder.Entity<ControlDeSesao>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.FuncionarioId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity
                .ToTable("control_de_sesao")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Email, "email_UNIQUE").IsUnique();

            entity.HasIndex(e => e.FuncionarioId, "fk_control_de_sesao_usuario1_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.FuncionarioId).HasColumnName("funcionario_id");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("email");
            entity.Property(e => e.SecretCodeRestauro)
                .HasMaxLength(45)
                .HasColumnName("secret_code_restauro");
            entity.Property(e => e.Senha)
                .HasMaxLength(45)
                .HasColumnName("senha");

            entity.HasOne(d => d.Funcionario).WithMany(p => p.ControlDeSesaos)
                .HasForeignKey(d => d.FuncionarioId)
                .HasConstraintName("fk_control_de_sesao_usuario1");
        });

        modelBuilder.Entity<Despesa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("despesas")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.Descri).HasColumnName("descri");
            entity.Property(e => e.Nome)
                .HasMaxLength(45)
                .HasColumnName("nome");
            entity.Property(e => e.NomeFuncionario)
                .HasMaxLength(99)
                .HasColumnName("nome_funcionario");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");
            entity.Property(e => e.Valor).HasColumnName("valor");
        });

        modelBuilder.Entity<Disciplina>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("disciplina")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.AnoId, "fk_disciplina_ano1_idx");

            entity.HasIndex(e => e.ClassesId, "fk_disciplina_classes2_idx");

            entity.HasIndex(e => e.Identificador, "identificador_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnoId).HasColumnName("ano_id");
            entity.Property(e => e.ClassesId).HasColumnName("classes_id");
            entity.Property(e => e.Identificador)
                .HasMaxLength(100)
                .HasColumnName("identificador");
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(45)
                .HasColumnName("nome");
            entity.Property(e => e.Orden).HasColumnName("orden");

            entity.HasOne(d => d.Ano).WithMany(p => p.Disciplinas)
                .HasForeignKey(d => d.AnoId)
                .HasConstraintName("fk_disciplina_ano1");

            entity.HasOne(d => d.Classes).WithMany(p => p.Disciplinas)
                .HasForeignKey(d => d.ClassesId)
                .HasConstraintName("fk_disciplina_classes2");
        });

        modelBuilder.Entity<Documento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("documentos")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.ClassesId, "fk_documentos_classes1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClassesId).HasColumnName("classes_id");
            entity.Property(e => e.DocumentoDescri).HasColumnName("documento_descri");
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(90)
                .HasColumnName("nome");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");

            entity.HasOne(d => d.Classes).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.ClassesId)
                .HasConstraintName("fk_documentos_classes1");
        });

        modelBuilder.Entity<DocumentosAluno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("documentos_aluno")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.AlunosId, "fk_Documentos_aluno_alunos1_idx");

            entity.HasIndex(e => e.DocumentosId, "fk_Documentos_aluno_documentos1_idx");

            entity.HasIndex(e => e.TurmaDoAlunoId, "fk_Documentos_aluno_turma_do_aluno1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AlunosId).HasColumnName("alunos_id");
            entity.Property(e => e.DataEntrega).HasColumnName("data_entrega");
            entity.Property(e => e.Descri).HasColumnName("descri");
            entity.Property(e => e.DocumentosId).HasColumnName("documentos_id");
            entity.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("'sem documentos'")
                .HasColumnType("enum('completo','incompleto','sem documentos')")
                .HasColumnName("estado");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");
            entity.Property(e => e.TurmaDoAlunoId).HasColumnName("turma_do_aluno_id");

            entity.HasOne(d => d.Alunos).WithMany(p => p.DocumentosAlunos)
                .HasForeignKey(d => d.AlunosId)
                .HasConstraintName("fk_Documentos_aluno_alunos1");

            entity.HasOne(d => d.Documentos).WithMany(p => p.DocumentosAlunos)
                .HasForeignKey(d => d.DocumentosId)
                .HasConstraintName("fk_Documentos_aluno_documentos1");

            entity.HasOne(d => d.TurmaDoAluno).WithMany(p => p.DocumentosAlunos)
                .HasForeignKey(d => d.TurmaDoAlunoId)
                .HasConstraintName("fk_Documentos_aluno_turma_do_aluno1");
        });

        modelBuilder.Entity<Encarregado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("encarregado")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contacto1)
                .HasMaxLength(45)
                .HasColumnName("contacto1");
            entity.Property(e => e.Contacto2)
                .HasMaxLength(45)
                .HasColumnName("contacto2");
            entity.Property(e => e.Desconto)
                .HasDefaultValueSql("'0'")
                .HasColumnName("desconto");
            entity.Property(e => e.Foto)
                .HasMaxLength(255)
                .HasColumnName("foto");
            entity.Property(e => e.Nome)
                .HasMaxLength(90)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<EncarregadoDosAluno>(entity =>
        {
            entity.HasKey(e => new { e.EncarregadoId, e.AlunosId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity
                .ToTable("encarregado_dos_alunos")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.AlunosId, "fk_encarregado_has_alunos_alunos1_idx");

            entity.HasIndex(e => e.EncarregadoId, "fk_encarregado_has_alunos_encarregado1_idx");

            entity.Property(e => e.EncarregadoId).HasColumnName("encarregado_id");
            entity.Property(e => e.AlunosId).HasColumnName("alunos_id");
            entity.Property(e => e.Descri).HasColumnName("descri");
            entity.Property(e => e.GrauParentesco)
                .IsRequired()
                .HasMaxLength(45)
                .HasColumnName("grau_parentesco");

            entity.HasOne(d => d.Alunos).WithMany(p => p.EncarregadoDosAlunos)
                .HasForeignKey(d => d.AlunosId)
                .HasConstraintName("fk_encarregado_has_alunos_alunos1");

            entity.HasOne(d => d.Encarregado).WithMany(p => p.EncarregadoDosAlunos)
                .HasForeignKey(d => d.EncarregadoId)
                .HasConstraintName("fk_encarregado_has_alunos_encarregado1");
        });

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("funcionario")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Codigo, "codigo_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Nome, "nome_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Aprovado)
                .IsRequired()
                .HasDefaultValueSql("'não'")
                .HasColumnType("enum('sim','não')");
            entity.Property(e => e.AreaDaActuacao)
                .HasColumnType("enum('direção','professor','auxiliar')")
                .HasColumnName("area_da_actuacao");
            entity.Property(e => e.AreaDeFormacao)
                .HasMaxLength(45)
                .HasColumnName("area_de_formacao");
            entity.Property(e => e.Biografia).HasColumnName("biografia");
            entity.Property(e => e.Cargo)
                .HasMaxLength(45)
                .HasColumnName("cargo");
            entity.Property(e => e.Citacao).HasColumnName("citacao");
            entity.Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(14)
                .HasColumnName("codigo");
            entity.Property(e => e.Contrato)
                .HasColumnType("enum('activo','enativo')")
                .HasColumnName("contrato");
            entity.Property(e => e.DataAdesa).HasColumnName("data_adesa");
            entity.Property(e => e.DataComecoTrabalho).HasColumnName("data_comeco_trabalho");
            entity.Property(e => e.DataFimTrabalho).HasColumnName("data_fim_trabalho");
            entity.Property(e => e.Descricacao).HasColumnName("descricacao");
            entity.Property(e => e.Foto)
                .HasMaxLength(500)
                .HasColumnName("foto");
            entity.Property(e => e.Gerente)
                .IsRequired()
                .HasDefaultValueSql("'não'")
                .HasColumnType("enum('sim','não')")
                .HasColumnName("gerente");
            entity.Property(e => e.Morada)
                .HasColumnType("text")
                .HasColumnName("morada");
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(90)
                .HasColumnName("nome");
            entity.Property(e => e.Privilegio)
                .IsRequired()
                .HasDefaultValueSql("'direção'")
                .HasColumnType("enum('admin','direção','professor','Vigilante')")
                .HasColumnName("privilegio");
            entity.Property(e => e.Salario).HasColumnName("salario");
            entity.Property(e => e.Tel)
                .HasMaxLength(30)
                .HasColumnName("tel");
            entity.Property(e => e.Tel2)
                .HasMaxLength(30)
                .HasColumnName("tel_2");

            entity.HasMany(d => d.Disciplinas).WithMany(p => p.Funcionarios)
                .UsingEntity<Dictionary<string, object>>(
                    "DisciplinaLecionadoProfessor",
                    r => r.HasOne<Disciplina>().WithMany()
                        .HasForeignKey("DisciplinaId")
                        .HasConstraintName("fk_classe_lecionado_professor_disciplina1"),
                    l => l.HasOne<Funcionario>().WithMany()
                        .HasForeignKey("FuncionarioId")
                        .HasConstraintName("fk_classe_lecionado_professor_usuario1"),
                    j =>
                    {
                        j.HasKey("FuncionarioId", "DisciplinaId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j
                            .ToTable("disciplina_lecionado_professor")
                            .HasCharSet("utf8mb3")
                            .UseCollation("utf8mb3_general_ci");
                        j.HasIndex(new[] { "DisciplinaId" }, "fk_classe_lecionado_professor_disciplina1_idx");
                        j.HasIndex(new[] { "FuncionarioId" }, "fk_classe_lecionado_professor_usuario1_idx");
                        j.IndexerProperty<int>("FuncionarioId").HasColumnName("funcionario_id");
                        j.IndexerProperty<int>("DisciplinaId").HasColumnName("disciplina_id");
                    });
        });

        modelBuilder.Entity<GrupoChat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("grupo_chat")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Admin, "fk_grupo_chat_Funcionario1_idx");

            entity.HasIndex(e => e.Identificador, "identificador_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Admin).HasColumnName("admin");
            entity.Property(e => e.Foto)
                .HasMaxLength(255)
                .HasColumnName("foto");
            entity.Property(e => e.Identificador)
                .IsRequired()
                .HasMaxLength(45)
                .HasColumnName("identificador");
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("nome");

            entity.HasOne(d => d.AdminNavigation).WithMany(p => p.GrupoChats)
                .HasForeignKey(d => d.Admin)
                .HasConstraintName("fk_grupo_chat_Funcionario1");
        });

        modelBuilder.Entity<InforEscola>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("infor_escola")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .HasColumnName("codigo");
            entity.Property(e => e.CodigoTutela)
                .HasMaxLength(10)
                .HasColumnName("codigo_tutela");
            entity.Property(e => e.Contacto1)
                .HasMaxLength(255)
                .HasColumnName("contacto1");
            entity.Property(e => e.Contacto2)
                .HasMaxLength(255)
                .HasColumnName("contacto2");
            entity.Property(e => e.DataCri).HasColumnName("data_cri");
            entity.Property(e => e.DiaCobrarPropina)
                .HasDefaultValueSql("'0'")
                .HasColumnName("dia_cobrar_propina");
            entity.Property(e => e.DirGeral)
                .HasMaxLength(45)
                .HasColumnName("dir_geral");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Foto)
                .HasMaxLength(100)
                .HasColumnName("foto");
            entity.Property(e => e.Localiz)
                .HasMaxLength(255)
                .HasColumnName("localiz");
            entity.Property(e => e.MesCobrarPropina)
                .HasDefaultValueSql("'0'")
                .HasColumnName("mes_cobrar_propina");
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("nome");
            entity.Property(e => e.Tipo)
                .HasColumnType("enum('estatal','privada','estatal-privada')")
                .HasColumnName("tipo");
            entity.Property(e => e.ValorConfirmaca)
                .HasDefaultValueSql("'0'")
                .HasColumnName("valor_confirmaca");
            entity.Property(e => e.ValorMatricula)
                .HasDefaultValueSql("'0'")
                .HasColumnName("valor_matricula");
            entity.Property(e => e.ValorUniforme)
                .HasDefaultValueSql("'0'")
                .HasColumnName("valor_uniforme");
        });

        modelBuilder.Entity<Me>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("mes")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Mes, "mes_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Mes)
                .IsRequired()
                .HasColumnType("enum('janeiro','fevereiro','março','abril','maio','junho','julho','agosto','setembro','outubro','novembro','dezembro')")
                .HasColumnName("mes");
            entity.Property(e => e.Orden)
                .IsRequired()
                .HasColumnType("enum('1','2','3','4','5','6','7','8','9','10','11','12')")
                .HasColumnName("orden");
        });

        modelBuilder.Entity<Membro>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("membros")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.FuncionarioId, "fk_membros_Funcionario1_idx");

            entity.HasIndex(e => e.GrupoChatId, "fk_membros_grupo_chat1_idx");

            entity.Property(e => e.FuncionarioId).HasColumnName("Funcionario_id");
            entity.Property(e => e.GrupoChatId).HasColumnName("grupo_chat_id");

            entity.HasOne(d => d.Funcionario).WithMany()
                .HasForeignKey(d => d.FuncionarioId)
                .HasConstraintName("fk_membros_Funcionario1");

            entity.HasOne(d => d.GrupoChat).WithMany()
                .HasForeignKey(d => d.GrupoChatId)
                .HasConstraintName("fk_membros_grupo_chat1");
        });

        modelBuilder.Entity<MiniPautum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("mini_pauta")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.AlunosId, "fk_mini_pauta_alunos1_idx");

            entity.HasIndex(e => e.AnoId, "fk_mini_pauta_ano1_idx");

            entity.HasIndex(e => e.ClassesId, "fk_mini_pauta_classes1_idx");

            entity.HasIndex(e => e.DisciplinaId, "fk_mini_pauta_disciplina1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AlunosId).HasColumnName("alunos_id");
            entity.Property(e => e.AnoId).HasColumnName("ano_id");
            entity.Property(e => e.ClassesId).HasColumnName("classes_id");
            entity.Property(e => e.DataProva).HasColumnName("data_prova");
            entity.Property(e => e.Descri).HasColumnName("descri");
            entity.Property(e => e.DisciplinaId).HasColumnName("disciplina_id");
            entity.Property(e => e.Nota).HasColumnName("nota");
            entity.Property(e => e.Tipo)
                .IsRequired()
                .HasColumnType("enum('MAC','NPP','NPT','EXAM')")
                .HasColumnName("tipo");
            entity.Property(e => e.Trimestre)
                .IsRequired()
                .HasColumnType("enum('I','II','III')")
                .HasColumnName("trimestre");

            entity.HasOne(d => d.Alunos).WithMany(p => p.MiniPauta)
                .HasForeignKey(d => d.AlunosId)
                .HasConstraintName("fk_mini_pauta_alunos1");

            entity.HasOne(d => d.Ano).WithMany(p => p.MiniPauta)
                .HasForeignKey(d => d.AnoId)
                .HasConstraintName("fk_mini_pauta_ano1");

            entity.HasOne(d => d.Classes).WithMany(p => p.MiniPauta)
                .HasForeignKey(d => d.ClassesId)
                .HasConstraintName("fk_mini_pauta_classes1");

            entity.HasOne(d => d.Disciplina).WithMany(p => p.MiniPauta)
                .HasForeignKey(d => d.DisciplinaId)
                .HasConstraintName("fk_mini_pauta_disciplina1");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("notification")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.IdActo).HasColumnName("id_acto");
            entity.Property(e => e.NomeActo)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("nome_acto");
            entity.Property(e => e.NomeFuncionario)
                .HasMaxLength(255)
                .HasColumnName("nome_funcionario");
        });

        modelBuilder.Entity<NotificationView>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("notification_view")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.FuncionarioId, "fk_notification_view_Funcionario1_idx");

            entity.HasIndex(e => e.NotificationId, "fk_notification_view_notification1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FuncionarioId).HasColumnName("Funcionario_id");
            entity.Property(e => e.NotificationId).HasColumnName("notification_id");
            entity.Property(e => e.View)
                .IsRequired()
                .HasDefaultValueSql("'não'")
                .HasColumnType("enum('sim','não')")
                .HasColumnName("view");

            entity.HasOne(d => d.Funcionario).WithMany(p => p.NotificationViews)
                .HasForeignKey(d => d.FuncionarioId)
                .HasConstraintName("fk_notification_view_Funcionario1");

            entity.HasOne(d => d.Notification).WithMany(p => p.NotificationViews)
                .HasForeignKey(d => d.NotificationId)
                .HasConstraintName("fk_notification_view_notification1");
        });

        modelBuilder.Entity<OutrosPagamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("outros_pagamento")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.AlunosId, "fk_outros_pagamento_alunos1_idx");

            entity.HasIndex(e => e.AnoId, "fk_outros_pagamento_ano1_idx");

            entity.HasIndex(e => e.TransacaoPagamentoId, "id_transacao_pagamento_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AlunosId).HasColumnName("alunos_id");
            entity.Property(e => e.AnoId).HasColumnName("ano_id");
            entity.Property(e => e.DataPagamneto).HasColumnName("data_pagamneto");
            entity.Property(e => e.Desci).HasColumnName("desci");
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(99)
                .HasColumnName("nome");
            entity.Property(e => e.PagoPor)
                .IsRequired()
                .HasMaxLength(155)
                .HasColumnName("pago_por");
            entity.Property(e => e.TipoPagamento)
                .HasColumnType("mediumtext")
                .HasColumnName("tipo_pagamento");
            entity.Property(e => e.TransacaoPagamentoId).HasColumnName("transacao_pagamento_id");
            entity.Property(e => e.ValorPago).HasColumnName("valor_pago");

            entity.HasOne(d => d.Alunos).WithMany(p => p.OutrosPagamentos)
                .HasForeignKey(d => d.AlunosId)
                .HasConstraintName("fk_outros_pagamento_alunos1");

            entity.HasOne(d => d.Ano).WithMany(p => p.OutrosPagamentos)
                .HasForeignKey(d => d.AnoId)
                .HasConstraintName("fk_outros_pagamento_ano1");
        });

        modelBuilder.Entity<PagamentoEmulumento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("pagamento_emulumento")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.AlunosId, "fk_pagamento_emulumento_alunos1_idx");

            entity.HasIndex(e => e.AnoId, "fk_pagamento_emulumento_ano1_idx");

            entity.HasIndex(e => e.TransacaoPagamentoId, "id_transacao_pagamento_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AlunosId).HasColumnName("alunos_id");
            entity.Property(e => e.AnoId).HasColumnName("ano_id");
            entity.Property(e => e.DataEntrega).HasColumnName("data_entrega");
            entity.Property(e => e.DataPedido).HasColumnName("data_pedido");
            entity.Property(e => e.Feito)
                .HasColumnType("enum('sim','não')")
                .HasColumnName("feito");
            entity.Property(e => e.Identificador)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("identificador");
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("nome");
            entity.Property(e => e.PagoPor)
                .IsRequired()
                .HasMaxLength(155)
                .HasColumnName("pago_por");
            entity.Property(e => e.QuemPediu)
                .HasMaxLength(255)
                .HasColumnName("Quem_pediu");
            entity.Property(e => e.QuemRecebeu)
                .HasMaxLength(255)
                .HasColumnName("quem recebeu");
            entity.Property(e => e.TransacaoPagamentoId).HasColumnName("transacao_pagamentoId");
            entity.Property(e => e.Valor).HasColumnName("valor");

            entity.HasOne(d => d.Alunos).WithMany(p => p.PagamentoEmulumentos)
                .HasForeignKey(d => d.AlunosId)
                .HasConstraintName("fk_pagamento_emulumento_alunos1");

            entity.HasOne(d => d.Ano).WithMany(p => p.PagamentoEmulumentos)
                .HasForeignKey(d => d.AnoId)
                .HasConstraintName("fk_pagamento_emulumento_ano1");
        });

        modelBuilder.Entity<PagamentoFuncio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("pagamento_funcio")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.AnoId, "fk_pagamento_funcio_ano1_idx");

            entity.HasIndex(e => e.MesId, "fk_pagamento_funcio_mes1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnoId).HasColumnName("ano_id");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("'não pago'")
                .HasColumnType("enum('pago','não pago','incompleto')")
                .HasColumnName("estado");
            entity.Property(e => e.FuncionarioId).HasColumnName("funcionario_id");
            entity.Property(e => e.FuncionarioIdPago).HasColumnName("funcionario_id_pago");
            entity.Property(e => e.MesId).HasColumnName("mes_id");
            entity.Property(e => e.PeriodoPago).HasColumnName("periodo_pago");
            entity.Property(e => e.Valor).HasColumnName("valor");

            entity.HasOne(d => d.Ano).WithMany(p => p.PagamentoFuncios)
                .HasForeignKey(d => d.AnoId)
                .HasConstraintName("fk_pagamento_funcio_ano1");

            entity.HasOne(d => d.Mes).WithMany(p => p.PagamentoFuncios)
                .HasForeignKey(d => d.MesId)
                .HasConstraintName("fk_pagamento_funcio_mes1");
        });

        modelBuilder.Entity<PagamentoUniforme>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("pagamento_uniforme")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.AlunosId, "fk_pagamento_uniforme_alunos1_idx");

            entity.HasIndex(e => e.AnoId, "fk_pagamento_uniforme_ano1_idx");

            entity.HasIndex(e => e.TransacaoPagamentoId, "id_transacao_pagamento_UNIQUE").IsUnique();

            entity.HasIndex(e => e.TipoUniforme, "tipo_uniforme_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AlunosId).HasColumnName("alunos_id");
            entity.Property(e => e.AnoId).HasColumnName("ano_id");
            entity.Property(e => e.DataPagamento).HasColumnName("data_pagamento");
            entity.Property(e => e.Desci).HasColumnName("desci");
            entity.Property(e => e.PagoPor)
                .IsRequired()
                .HasMaxLength(155)
                .HasColumnName("pago_por");
            entity.Property(e => e.ParteDoUniforme)
                .HasMaxLength(50)
                .HasColumnName("parte_do_uniforme");
            entity.Property(e => e.Tamanho)
                .HasMaxLength(255)
                .HasColumnName("tamanho");
            entity.Property(e => e.TipoUniforme)
                .IsRequired()
                .HasColumnName("tipo_uniforme");
            entity.Property(e => e.TransacaoPagamentoId).HasColumnName("transacao_pagamentoId");
            entity.Property(e => e.ValorPago).HasColumnName("valor_pago");

            entity.HasOne(d => d.Alunos).WithMany(p => p.PagamentoUniformes)
                .HasForeignKey(d => d.AlunosId)
                .HasConstraintName("fk_pagamento_uniforme_alunos1");

            entity.HasOne(d => d.Ano).WithMany(p => p.PagamentoUniformes)
                .HasForeignKey(d => d.AnoId)
                .HasConstraintName("fk_pagamento_uniforme_ano1");
        });

        modelBuilder.Entity<PlanificarAula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("planificar_aula")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.DisciplinaId, "fk_panificar_aula_disciplina1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataAula).HasColumnName("Data_aula");
            entity.Property(e => e.DisciplinaId).HasColumnName("disciplina_id");
            entity.Property(e => e.Lesson).HasColumnName("lesson");
            entity.Property(e => e.Materia).HasColumnName("materia");
            entity.Property(e => e.ObjectivoEspecifico)
                .HasColumnType("mediumtext")
                .HasColumnName("objectivo_especifico");
            entity.Property(e => e.ObjtivoGeral)
                .HasColumnType("mediumtext")
                .HasColumnName("objtivo_geral");
            entity.Property(e => e.Tema)
                .HasMaxLength(255)
                .HasColumnName("tema");

            entity.HasOne(d => d.Disciplina).WithMany(p => p.PlanificarAulas)
                .HasForeignKey(d => d.DisciplinaId)
                .HasConstraintName("fk_panificar_aula_disciplina1");
        });

        modelBuilder.Entity<PresencaAluno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("presenca_aluno")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Data, "data_UNIQUE").IsUnique();

            entity.HasIndex(e => e.AlunosId, "fk_presenca_aluno_alunos1_idx");

            entity.HasIndex(e => e.AnoId, "fk_presenca_aluno_ano1_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AlunosId).HasColumnName("alunos_id");
            entity.Property(e => e.AnoId).HasColumnName("ano_id");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.Descricicao).HasColumnName("descricicao");
            entity.Property(e => e.Estado)
                .IsRequired()
                .HasColumnType("enum('presente','falta')")
                .HasColumnName("estado");
            entity.Property(e => e.HoraChegada)
                .HasMaxLength(5)
                .HasColumnName("hora_chegada");

            entity.HasOne(d => d.Alunos).WithMany(p => p.PresencaAlunos)
                .HasForeignKey(d => d.AlunosId)
                .HasConstraintName("fk_presenca_aluno_alunos1");

            entity.HasOne(d => d.Ano).WithMany(p => p.PresencaAlunos)
                .HasForeignKey(d => d.AnoId)
                .HasConstraintName("fk_presenca_aluno_ano1");
        });

        modelBuilder.Entity<PresencaFuncionario>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.AnoId, e.FuncionarioId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity
                .ToTable("presenca_funcionario")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Data, "data_UNIQUE").IsUnique();

            entity.HasIndex(e => e.FuncionarioId, "fk_presenca_funcionario_usuario1_idx");

            entity.HasIndex(e => e.AnoId, "fk_presenca_professores_ano1_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.AnoId).HasColumnName("ano_id");
            entity.Property(e => e.FuncionarioId).HasColumnName("funcionario_id");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.Descricacao).HasColumnName("descricacao");
            entity.Property(e => e.Estado)
                .IsRequired()
                .HasColumnType("enum('presente','falta','atraso')")
                .HasColumnName("estado");
            entity.Property(e => e.HoraChegada)
                .HasMaxLength(5)
                .HasColumnName("hora_chegada");

            entity.HasOne(d => d.Ano).WithMany(p => p.PresencaFuncionarios)
                .HasForeignKey(d => d.AnoId)
                .HasConstraintName("fk_presenca_professores_ano1");

            entity.HasOne(d => d.Funcionario).WithMany(p => p.PresencaFuncionarios)
                .HasForeignKey(d => d.FuncionarioId)
                .HasConstraintName("fk_presenca_funcionario_usuario1");
        });

        modelBuilder.Entity<Propina>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.AlunosId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity
                .ToTable("propina")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.AlunosId, "fk_propina_alunos1_idx");

            entity.HasIndex(e => e.AnoId, "fk_propina_ano1_idx");

            entity.HasIndex(e => e.MesId, "fk_propina_mes1_idx");

            entity.HasIndex(e => e.TransacaoPagamentoId, "id_transacao_pagamento_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.AlunosId).HasColumnName("alunos_id");
            entity.Property(e => e.AnoId).HasColumnName("ano_id");
            entity.Property(e => e.Conta)
                .HasDefaultValueSql("'0'")
                .HasColumnName("conta");
            entity.Property(e => e.DataInicioMes).HasColumnName("data_inicio_mes");
            entity.Property(e => e.DataPagamento).HasColumnName("data_pagamento");
            entity.Property(e => e.DataPedido).HasColumnName("data_pedido");
            entity.Property(e => e.Desconto)
                .HasDefaultValueSql("'0'")
                .HasColumnName("desconto");
            entity.Property(e => e.Descricao).HasColumnName("descricao");
            entity.Property(e => e.Estado)
                .IsRequired()
                .HasColumnType("enum('pago','dívida','prazo','pedido','trancado')")
                .HasColumnName("estado");
            entity.Property(e => e.FuncionarioPagamento)
                .HasMaxLength(90)
                .HasColumnName("funcionario_pagamento");
            entity.Property(e => e.FuncionarioPedido)
                .HasMaxLength(90)
                .HasColumnName("funcionario_pedido");
            entity.Property(e => e.MesId).HasColumnName("mes_id");
            entity.Property(e => e.Orden)
                .IsRequired()
                .HasColumnType("enum('1','2','3','4','5','6','7','8','9','10','11','12')")
                .HasColumnName("orden");
            entity.Property(e => e.PagoPor)
                .IsRequired()
                .HasMaxLength(155)
                .HasColumnName("pago_por");
            entity.Property(e => e.QuemPagou)
                .HasMaxLength(90)
                .HasColumnName("quem_pagou");
            entity.Property(e => e.QuemPediu)
                .HasMaxLength(90)
                .HasColumnName("quem_pediu");
            entity.Property(e => e.TransacaoPagamentoId).HasColumnName("transacao_pagamentoId");
            entity.Property(e => e.ValorPago).HasColumnName("valor_pago");

            entity.HasOne(d => d.Alunos).WithMany(p => p.Propinas)
                .HasForeignKey(d => d.AlunosId)
                .HasConstraintName("fk_propina_alunos1");

            entity.HasOne(d => d.Ano).WithMany(p => p.Propinas)
                .HasForeignKey(d => d.AnoId)
                .HasConstraintName("fk_propina_ano1");

            entity.HasOne(d => d.Mes).WithMany(p => p.Propinas)
                .HasForeignKey(d => d.MesId)
                .HasConstraintName("fk_propina_mes1");
        });

        modelBuilder.Entity<TurmaDoAluno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("turma_do_aluno")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.AlunosId, "fk_table1_alunos1_idx");

            entity.HasIndex(e => e.ClasseId, "fk_table1_turma_por_classe1_idx");

            entity.HasIndex(e => e.FuncionarioId, "fk_turma_do_aluno_Funcionario1_idx");

            entity.HasIndex(e => e.AnoId, "fk_turma_do_aluno_ano1_idx");

            entity.HasIndex(e => e.TransacaoPagamentoId, "id_transacao_pagamento_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AlunosId).HasColumnName("alunos_id");
            entity.Property(e => e.AnoId).HasColumnName("ano_id");
            entity.Property(e => e.ClasseId).HasColumnName("classe_id");
            entity.Property(e => e.ConfirMatri)
                .IsRequired()
                .HasColumnType("enum('matrícula','confirmação')")
                .HasColumnName("confir_matri");
            entity.Property(e => e.DataEstado).HasColumnName("data_estado");
            entity.Property(e => e.DataMatri).HasColumnName("data_matri");
            entity.Property(e => e.EstadoAluno)
                .IsRequired()
                .HasDefaultValueSql("'existente'")
                .HasColumnType("enum('existente','dexistente','transferido','anulado')")
                .HasColumnName("estado_aluno");
            entity.Property(e => e.FuncionarioId).HasColumnName("Funcionario_id");
            entity.Property(e => e.PagoPor)
                .HasMaxLength(155)
                .HasColumnName("pago_por");
            entity.Property(e => e.RepitenteClasse)
                .IsRequired()
                .HasColumnType("enum('sim','não')")
                .HasColumnName("repitente_classe");
            entity.Property(e => e.TransacaoPagamentoId).HasColumnName("transacao_pagamento_id");
            entity.Property(e => e.ValorMatrConf).HasColumnName("valor_matr_conf");

            entity.HasOne(d => d.Alunos).WithMany(p => p.TurmaDoAlunos)
                .HasForeignKey(d => d.AlunosId)
                .HasConstraintName("fk_table1_alunos1");

            entity.HasOne(d => d.Ano).WithMany(p => p.TurmaDoAlunos)
                .HasForeignKey(d => d.AnoId)
                .HasConstraintName("fk_turma_do_aluno_ano1");

            entity.HasOne(d => d.Classe).WithMany(p => p.TurmaDoAlunos)
                .HasForeignKey(d => d.ClasseId)
                .HasConstraintName("fk_table1_turma_por_classe1");

            entity.HasOne(d => d.Funcionario).WithMany(p => p.TurmaDoAlunos)
                .HasForeignKey(d => d.FuncionarioId)
                .HasConstraintName("fk_turma_do_aluno_Funcionario1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
