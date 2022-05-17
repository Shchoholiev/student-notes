using System;
using System.Data.SqlClient;
using EducationalPortal.Core.Entities;
using EducationalPortal.Core.Entities.EducationalMaterials;
using EducationalPortal.Core.Entities.EducationalMaterials.Properties;
using EducationalPortal.Core.Entities.JoinEntities;
using EducationalPortal.Infrastructure.EF;
using EducationalPortal.Infrastructure.Identity;

namespace StudentNotes.Infrastructure.Services
{
    public class Cloud_storage : ICloudStorageService
    {
        // connection str from databse from azure 
        // login: Vika
        // pass: bla-bla-bla#01
        public string connectionStr = "Server=tcp:vika-server.database.windows.net,1433;Initial Catalog=student-noted-db;Persist Security Info=False;User ID=Vika;Password=bla-bla-bla#01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        // ApplicationContext context / EFContext
        public void InitializeDB(ApplicationContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var user = new User {};
            сontext.Users.Add(user);
            context.SaveChanges();

            var role = new Role {};
            сontext.Roles.Add(role);
            context.SaveChanges();

            var userToken = new UserToken {};
            context.UserTokens.Add(userToken);
            context.SaveChanges();

            var fileNote = new FileNote {};
            context.FileNotes.Add(fileNote);
            context.SaveChanges();

            var txtNote = new TextNote {};
            context.TextNotes.Add(txtNote);
            context.SaveChanges();

            var noteBase = new NoteBase {};
            context.NoteBases.Add(noteBase);
            context.SaveChanges();

            var type = new Core.Entities.Type {};
            context.Types.Add(type);
            context.SaveChanges();

            var teacher = new Teacher {};
            context.Teachers.Add(teacher);
            context.SaveChanges();

            var group = new Group {};
            context.Groups.Add(group);
            context.SaveChanges();

            var subj = new Subject {};
            context.Subjects.Add(subj);
            context.SaveChanges();

            var file = new Core.Entities.File {};
            context.Files.Add(file);
            context.SaveChanges();

        }
        public async Task<string> UploadAsync()
        {
            
        }
    }
}