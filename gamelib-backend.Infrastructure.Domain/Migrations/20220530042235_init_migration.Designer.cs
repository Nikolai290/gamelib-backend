// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using gamelib_backend.Infrastructure.Domain;

#nullable disable

namespace gamelib_backend.Infrastructure.Domain.Migrations
{
    [DbContext(typeof(PostgresDbContext))]
    [Migration("20220530042235_init_migration")]
    partial class init_migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GameGenre", b =>
                {
                    b.Property<int>("GamesId")
                        .HasColumnType("integer")
                        .HasColumnName("games_id");

                    b.Property<int>("GenresId")
                        .HasColumnType("integer")
                        .HasColumnName("genres_id");

                    b.HasKey("GamesId", "GenresId")
                        .HasName("pk_game_genre");

                    b.HasIndex("GenresId")
                        .HasDatabaseName("ix_game_genre_genres_id");

                    b.ToTable("game_genre", (string)null);
                });

            modelBuilder.Entity("gamelib_backend.Domain.Core.DbEntities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_companies");

                    b.ToTable("companies", (string)null);
                });

            modelBuilder.Entity("gamelib_backend.Domain.Core.DbEntities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer")
                        .HasColumnName("company_id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_games");

                    b.HasIndex("CompanyId")
                        .HasDatabaseName("ix_games_company_id");

                    b.ToTable("games", (string)null);
                });

            modelBuilder.Entity("gamelib_backend.Domain.Core.DbEntities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_genres");

                    b.ToTable("genres", (string)null);
                });

            modelBuilder.Entity("GameGenre", b =>
                {
                    b.HasOne("gamelib_backend.Domain.Core.DbEntities.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_game_genre_games_games_id");

                    b.HasOne("gamelib_backend.Domain.Core.DbEntities.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_game_genre_genres_genres_id");
                });

            modelBuilder.Entity("gamelib_backend.Domain.Core.DbEntities.Game", b =>
                {
                    b.HasOne("gamelib_backend.Domain.Core.DbEntities.Company", "Company")
                        .WithMany("Games")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_games_companies_company_id");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("gamelib_backend.Domain.Core.DbEntities.Company", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
