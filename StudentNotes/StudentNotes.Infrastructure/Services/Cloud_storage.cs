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
        public void InitializeDB()
        {
            //connectionStr.Database.EnsureCreated();
            //EFContext.Database.EnsureCreated();
            EFcontext.Database.EnsureDeleted();
            EFcontext.Database.EnsureCreated();

            var user = new User {};
            EFContext.Users.Add(user);
            EFcontext.SaveChanges();

            var role = new Role {};
            EFContext.Roles.Add(role);
            EFcontext.SaveChanges();

            var user_token = new UserToken {};
            EFContext.UserTokens.Add(user_token);
            EFcontext.SaveChanges();

            var file_note = new FileNote {};
            EFContext.FileNotes.Add(file_note);
            EFcontext.SaveChanges();

            var txt_note = new TextNote {};
            EFContext.TextNotes.Add(txt_note);
            EFcontext.SaveChanges();

            var note_base = new NoteBase {};
            EFContext.NoteBases.Add(note_base);
            EFcontext.SaveChanges();

            var type = new Core.Entities.Type {};
            EFContext.Types.Add(type);
            EFcontext.SaveChanges();

            var teacher = new Teacher {};
            EFContext.Teachers.Add(teacher);
            EFcontext.SaveChanges();

            var group = new Group {};
            EFContext.Groups.Add(group);
            EFcontext.SaveChanges();

            var subj = new Subject {};
            EFContext.Subjects.Add(subj);
            EFcontext.SaveChanges();

            var file = new Core.Entities.File {};
            EFContext.Files.Add(file);
            EFcontext.SaveChanges();

        }
        public async Task<string> UploadAsync()
        {
            
        }
    }
}