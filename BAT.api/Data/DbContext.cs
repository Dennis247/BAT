using BAT.api.Helpers;
using BAT.api.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BAT.api.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IHttpContextAccessor _context;
        public  IDbConnection connection;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor context, IConfiguration configuration) : base(options)
        {
            _context = context;
            connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));


        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Audit> AuditLogs { get; set; }

        public DbSet<ProvisionedAdmin> ProvisionedAdmins { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        public DbSet<TeamPermission> TeamPermissions { get; set; }
        public DbSet<AdminTeam> AdminTeams { get; set; }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<UserActivation> UserActivations { get; set; }
        public DbSet<FileUpload> FileUploads { get; set; }
        public DbSet<UserData> UserDatas { get; set; }
        public DbSet<ProcessedFileDetails> ProcessedFileDetails { get; set; }
        public DbSet<AnalyzeData> AnalyzeDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new DbInitializer(modelBuilder).Seed();
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            OnBeforeSaveChanges();
            var result = await base.SaveChangesAsync();
            return result;
        }
        private void OnBeforeSaveChanges()
        {
            Account User = (Account)_context.HttpContext.Items["Account"];

            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;
                var auditEntry = new AuditEntry(entry);
                auditEntry.TableName = entry.Entity.GetType().Name;
                auditEntry.UserId = User.Id;
                auditEntry.BrowserInfo = _context.HttpContext.Request.Headers["User-Agent"].ToString();
                auditEntry.HttpMethod = _context.HttpContext.Request.Method;
                auditEntry.AreaAccessed = _context.HttpContext.Request.Path.Value;
                auditEntry.TraceId = _context.HttpContext.TraceIdentifier;
                auditEntry.UserName = User.Email;

                auditEntries.Add(auditEntry);
                foreach (var property in entry.Properties)
                {
                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.AuditType = AuditType.Create;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            break;
                        case EntityState.Deleted:
                            auditEntry.AuditType = AuditType.Delete;
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            break;
                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditEntry.ChangedColumns.Add(propertyName);
                                auditEntry.AuditType = AuditType.Update;
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                            }
                            break;
                    }
                }
            }
            foreach (var auditEntry in auditEntries)
            {
                AuditLogs.Add(auditEntry.ToAudit());
            }
        }



        //public void BulkInsert(DataTable table)
        //{
        //    using (var bulkInsert = new SqlBulkCopy(connection.ConnectionString))
        //    {
        //        bulkInsert.DestinationTableName = table.TableName;
        //        bulkInsert.WriteToServer(table);
        //    }
        //}

    }



}
