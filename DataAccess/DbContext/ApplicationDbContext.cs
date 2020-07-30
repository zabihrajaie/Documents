using Entities.DocumentType;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttributeTypes>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AttributeTypes", "DocumentType");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Attributes>(entity =>
            {
                entity.ToTable("Attributes", "DocumentType");

                entity.HasIndex(e => e.DocumentTypeId)
                    .HasName("IX_FK_DocumentTypeAttribute");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.Attributes)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentTypeAttribute");
            });

            modelBuilder.Entity<DocEvents>(entity =>
            {
                entity.ToTable("DocEvents", "DocumentType");

                entity.HasIndex(e => e.DocumentId)
                    .HasName("IX_FK_DocumentEvent");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_FK_EventUser");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.DocEvents)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentEvent");
            });

            modelBuilder.Entity<DocumentTypes>(entity =>
            {
                entity.ToTable("DocumentTypes", "DocumentType");

                entity.HasIndex(e => e.ScopeId)
                    .HasName("IX_FK_ScopeDocumentType");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Scope)
                    .WithMany(p => p.DocumentTypes)
                    .HasForeignKey(d => d.ScopeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ScopeDocumentType");
            });

            modelBuilder.Entity<Documents>(entity =>
            {
                entity.ToTable("Documents", "DocumentType");

                entity.HasIndex(e => e.DocumentTypeId)
                    .HasName("IX_FK_DocumentTypeDocument");

                entity.Property(e => e.DataAsJson).IsRequired();

                entity.Property(e => e.ExpireDate).HasColumnType("datetime");

                entity.Property(e => e.FullInquiryId)
                    .IsRequired()
                    .HasMaxLength(21);

                entity.Property(e => e.ImageId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IssueDate).HasColumnType("datetime");

                entity.Property(e => e.NextVersion).HasMaxLength(21);

                entity.Property(e => e.PrevVersion).HasMaxLength(21);

                entity.Property(e => e.RegistrationUserId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentTypeDocument");
            });

            modelBuilder.Entity<DomainScope>(entity =>
            {
                entity.HasKey(e => new { e.DomainsId, e.ScopesId });

                entity.ToTable("DomainScope", "DocumentType");

                entity.HasIndex(e => e.ScopesId)
                    .HasName("IX_FK_DomainScope_Scope");

                entity.Property(e => e.DomainsId).HasColumnName("Domains_Id");

                entity.Property(e => e.ScopesId).HasColumnName("Scopes_Id");

                entity.HasOne(d => d.Domains)
                    .WithMany(p => p.DomainScope)
                    .HasForeignKey(d => d.DomainsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DomainScope_Domain");

                entity.HasOne(d => d.Scopes)
                    .WithMany(p => p.DomainScope)
                    .HasForeignKey(d => d.ScopesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DomainScope_Scope");
            });

            modelBuilder.Entity<Domains>(entity =>
            {
                entity.ToTable("Domains", "DocumentType");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<HasA1>(entity =>
            {
                entity.ToTable("HasA1", "DocumentType");

                entity.HasIndex(e => e.ChildDocumentTypeId)
                    .HasName("IX_FK_DocumentTypeHasA12");

                entity.HasIndex(e => e.ParrentDocumentTypeId)
                    .HasName("IX_FK_DocumentTypeHasA11");

                entity.HasOne(d => d.ChildDocumentType)
                    .WithMany(p => p.HasA1ChildDocumentType)
                    .HasForeignKey(d => d.ChildDocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentTypeHasA12");

                entity.HasOne(d => d.ParrentDocumentType)
                    .WithMany(p => p.HasA1ParrentDocumentType)
                    .HasForeignKey(d => d.ParrentDocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentTypeHasA11");
            });

            modelBuilder.Entity<HasAns>(entity =>
            {
                entity.ToTable("HasANs", "DocumentType");

                entity.HasIndex(e => e.ChildDocumentTypeId)
                    .HasName("IX_FK_DocumentTypeHasA1");

                entity.HasIndex(e => e.ParentDocumentTypeId)
                    .HasName("IX_FK_DocumentTypeHasA");

                entity.HasOne(d => d.ChildDocumentType)
                    .WithMany(p => p.HasAnsChildDocumentType)
                    .HasForeignKey(d => d.ChildDocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentTypeHasA1");

                entity.HasOne(d => d.ParentDocumentType)
                    .WithMany(p => p.HasAnsParentDocumentType)
                    .HasForeignKey(d => d.ParentDocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentTypeHasA");
            });

            modelBuilder.Entity<IsAs>(entity =>
            {
                entity.ToTable("IsAs", "DocumentType");

                entity.HasIndex(e => e.SubDocumentTypeId1)
                    .HasName("IX_FK_DocumentTypeIsA");

                entity.HasIndex(e => e.SuperDocumentTypeId)
                    .HasName("IX_FK_DocumentTypeIsA1");

                entity.Property(e => e.SubDocumentTypeId1).HasColumnName("SubDocumentType_Id");

                entity.HasOne(d => d.SubDocumentTypeId1Navigation)
                    .WithMany(p => p.IsAsSubDocumentTypeId1Navigation)
                    .HasForeignKey(d => d.SubDocumentTypeId1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentTypeIsA");

                entity.HasOne(d => d.SuperDocumentType)
                    .WithMany(p => p.IsAsSuperDocumentType)
                    .HasForeignKey(d => d.SuperDocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentTypeIsA1");
            });

            modelBuilder.Entity<PolicyOnChange>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PolicyOnChange", "DocumentType");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RelatedToes>(entity =>
            {
                entity.ToTable("RelatedToes", "DocumentType");

                entity.HasIndex(e => e.LeftDocumentTypeId)
                    .HasName("IX_FK_DocumentTypeRelatedTo1");

                entity.HasIndex(e => e.RightDocumentTypeId)
                    .HasName("IX_FK_DocumentTypeRelatedTo");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.LeftDocumentType)
                    .WithMany(p => p.RelatedToesLeftDocumentType)
                    .HasForeignKey(d => d.LeftDocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentTypeRelatedTo1");

                entity.HasOne(d => d.RightDocumentType)
                    .WithMany(p => p.RelatedToesRightDocumentType)
                    .HasForeignKey(d => d.RightDocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentTypeRelatedTo");
            });

            modelBuilder.Entity<Scopes>(entity =>
            {
                entity.ToTable("Scopes", "DocumentType");

                entity.Property(e => e.Name).IsRequired();
            });
        }
    }
}