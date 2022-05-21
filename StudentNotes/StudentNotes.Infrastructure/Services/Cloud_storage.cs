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

            #region  variables
            // * Users
            User headmannExample;
            User user1, user2, user3, user4, user5, user6, user7, user8, user9;

            // * Roles
            Role roleHeadmann;
            Role roleStudent;

            // * File Notes
            List<File> filesPhysics = new List<File>();
            List<File> filesEnglish = new List<File>();
            List<File> filesMath = new List<File>();
            List<File> filesHypertext = new List<File>();
            List<File> filesProgramming = new List<File>();

            // * Notes Types
            Type lab;
            Type practice;
            Type lecture;
            Type exam;
            Type homework;
            Type helperFile;

            // * Teachers
            Teacher teacherMath1;
            Teacher teacherMath2;
            Teacher teacherPs1;
            Teacher teacherPs2;
            Teacher teacherPs3;
            Teacher teacherProgr;
            Teacher teacherHyper;
            Teacher teacherEngl;

            // * Subjects
            Subject physics;
            Subject english;
            Subject math;
            Subject programming;
            Subject hypertext;

            #endregion

            #region users
            var passwordHasher = new PasswordHasher();
            
            var passwordHash = passwordHasher.Hash("cool-vanya");

            headmannExample = new User
            {
                Name = "Іван Бургард",
                Email = "ivan@gmail.com",
                PasswordHash = passwordHash,
                Avatar = "https://media.istockphoto.com/photos/businessman-silhouette-as-avatar-or-default-profile-picture-picture-id476085198?b=1&k=20&m=476085198&s=170667a&w=0&h=Ct4e1kIOdCOrEgvsQg4A1qeuQv944pPFORUQcaGw4oI=",
                Group = groupExample,
                Role = roleHeadmann
            };

            passwordHash = passwordHasher.Hash("great-vika");

            user1 = new User {
                Name = "Вікторія Вовченко",
                Email = "vika.vovchenkoo@gmail.com",
                PasswordHash = passwordHash,
                Avatar = "https://media.istockphoto.com/photos/businessman-silhouette-as-avatar-or-default-profile-picture-picture-id476085198?b=1&k=20&m=476085198&s=170667a&w=0&h=Ct4e1kIOdCOrEgvsQg4A1qeuQv944pPFORUQcaGw4oI=",
                Group = groupExample,
                Role = roleStudent
            };

            passwordHash = passwordHasher.Hash("awesome-sergey");

            user2 = new User {
                Name = "Сергій Щоголєв",
                Email = "serg@gmail.com",
                PasswordHash = passwordHash,
                Avatar = "https://media.istockphoto.com/photos/businessman-silhouette-as-avatar-or-default-profile-picture-picture-id476085198?b=1&k=20&m=476085198&s=170667a&w=0&h=Ct4e1kIOdCOrEgvsQg4A1qeuQv944pPFORUQcaGw4oI=",
                Group = groupExample,
                Role = roleStudent
            };

            passwordHash = passwordHasher.Hash("beautiful-liza");

            user3 = new User {
                Name = "Елизавета Бойко",
                Email = "liza@gmail.com",
                PasswordHash = passwordHash,
                Avatar = "https://media.istockphoto.com/photos/businessman-silhouette-as-avatar-or-default-profile-picture-picture-id476085198?b=1&k=20&m=476085198&s=170667a&w=0&h=Ct4e1kIOdCOrEgvsQg4A1qeuQv944pPFORUQcaGw4oI=",
                Group = groupExample,
                Role = roleStudent
            };

            passwordHash = passwordHasher.Hash("pretty-polina");

            user4 = new User {
                Name = "Поліна Павленко",
                Email = "polina@gmail.com",
                PasswordHash = passwordHash,
                Avatar = "https://media.istockphoto.com/photos/businessman-silhouette-as-avatar-or-default-profile-picture-picture-id476085198?b=1&k=20&m=476085198&s=170667a&w=0&h=Ct4e1kIOdCOrEgvsQg4A1qeuQv944pPFORUQcaGw4oI=",
                Group = groupExample,
                Role = roleStudent
            };

            passwordHash = passwordHasher.Hash("pretty-polina");

            user5 = new User {
                Name = "Поліна Павленко",
                Email = "polina@gmail.com",
                PasswordHash = passwordHash,
                Avatar = "https://media.istockphoto.com/photos/businessman-silhouette-as-avatar-or-default-profile-picture-picture-id476085198?b=1&k=20&m=476085198&s=170667a&w=0&h=Ct4e1kIOdCOrEgvsQg4A1qeuQv944pPFORUQcaGw4oI=",
                Group = groupExample,
                Role = roleStudent
            };

            passwordHash = passwordHasher.Hash("breathtaking-misha");

            user6 = new User {
                Name = "Михайло Білодід",
                Email = "misha@gmail.com",
                PasswordHash = passwordHash,
                Avatar = "https://media.istockphoto.com/photos/businessman-silhouette-as-avatar-or-default-profile-picture-picture-id476085198?b=1&k=20&m=476085198&s=170667a&w=0&h=Ct4e1kIOdCOrEgvsQg4A1qeuQv944pPFORUQcaGw4oI=",
                Group = groupExample,
                Role = roleStudent
            };

            passwordHash = passwordHasher.Hash("stunning-vitalik");

            user7 = new User {
                Name = "Віталій Красноруцький",
                Email = "vitalik@gmail.com",
                PasswordHash = passwordHash,
                Avatar = "https://media.istockphoto.com/photos/businessman-silhouette-as-avatar-or-default-profile-picture-picture-id476085198?b=1&k=20&m=476085198&s=170667a&w=0&h=Ct4e1kIOdCOrEgvsQg4A1qeuQv944pPFORUQcaGw4oI=",
                Group = groupExample,
                Role = roleStudent
            };

            passwordHash = passwordHasher.Hash("wonderful-nikita");

            user8 = new User {
                Name = "Микита Дубовий",
                Email = "nikita@gmail.com",
                PasswordHash = passwordHash,
                Avatar = "https://media.istockphoto.com/photos/businessman-silhouette-as-avatar-or-default-profile-picture-picture-id476085198?b=1&k=20&m=476085198&s=170667a&w=0&h=Ct4e1kIOdCOrEgvsQg4A1qeuQv944pPFORUQcaGw4oI=",
                Group = groupExample,
                Role = roleStudent
            };

            passwordHash = passwordHasher.Hash("clever-misha");

            user9 = new User {
                Name = "Михайло Овчаренко",
                Email = "mischao@gmail.com",
                PasswordHash = passwordHash,
                Avatar = "https://media.istockphoto.com/photos/businessman-silhouette-as-avatar-or-default-profile-picture-picture-id476085198?b=1&k=20&m=476085198&s=170667a&w=0&h=Ct4e1kIOdCOrEgvsQg4A1qeuQv944pPFORUQcaGw4oI=",
                Group = groupExample,
                Role = roleStudent
            };

            сontext.Users.Add(headmannExample);
            сontext.Users.Add(user1);
            сontext.Users.Add(user2);
            сontext.Users.Add(user3);
            сontext.Users.Add(user4);
            сontext.Users.Add(user5);
            сontext.Users.Add(user6);
            сontext.Users.Add(user7);
            сontext.Users.Add(user8);
            сontext.Users.Add(user9);

            context.SaveChanges();
        # endregion

            #region roles
            roleHeadmann = new Role { Name = "Headmann"};
            roleStudent = new Role { Name = "Student"};
            // role proforg ?

            var role = new Role {roleHeadmann};
            сontext.Roles.Add(role);
            context.SaveChanges();
            #endregion

            #region  token

            var userToken = new UserToken {};
            context.UserTokens.Add(userToken);
            context.SaveChanges();
            #endregion

            #region notes types
            lab = new Type {Name = "Лабораторна робота"};
            practice = new Type {Name = "Практична робота"};
            lecture = new Type {Name = "Лекція"};
            exam = new Type {Name = "Екзамен"};
            homework = new Type {Name = "Домашнє завдання"};
            helperFile = new Type {Name = "Допоміжний файл"};
            #endregion

            #region file notes

            filesPhysics.Add(new File { 
                Name = "Фізика Кінематика розбір задач", 
                Subject = physics,
                Author = user5,
                Type = helperFile,
                Link = "https://educationalportal.blob.core.windows.net/student-notes/%D0%A4%D1%96%D0%B7%D0%B8%D0%BA%D0%B0%20%D0%9A%D0%B8%D0%BD%D0%B5%D0%BC%D0%B0%D1%82%D0%B8%D0%BA%D0%B0%20%D0%B7%D0%B0%D0%B4%D0%B0%D1%87%D0%B8%20%D1%80%D0%B0%D0%B7%D0%B1%D0%BE%D1%80.pdf"});
            
            filesPhysics.Add(new File {
                Name = "Фізика Контрольні завдання", 
                Subject = physics,
                Author = user3,
                Type = homework,
                Deadline = new DateTime(2022, 7, 1),
                UsersCompleted = new List<User> {user4, user7, user9},
                Link = "https://educationalportal.blob.core.windows.net/student-notes/%D0%A4%D1%96%D0%B7%D0%B8%D0%BA%D0%B0%20%D0%9A%D0%BE%D0%BD%D1%82%D1%80%D0%BE%D0%BB%D1%8C%D0%BD%D1%96%20%D0%B7%D0%B0%D0%B2%D0%B4%D0%B0%D0%BD%D0%BD%D1%8F.pdf"});
            
            filesPhysics.Add(new File {
                Name = "Фізика Условия ИДЗ", 
                Subject = physics,
                Author = user6,
                Type = homework,
                Deadline = new DateTime(2022, 7, 10),
                UsersCompleted = new List<User> {user2},
                Link = "https://educationalportal.blob.core.windows.net/student-notes/%D0%A4%D1%96%D0%B7%D0%B8%D0%BA%D0%B0%20%D0%A3%D1%81%D0%BB%D0%BE%D0%B2%D0%B8%D1%8F%20%D0%98%D0%94%D0%97.pdf"});
            
            filesEnglish.Add(new File {
                Name = "Англійська мова 1-2 курс", 
                Subject = english,
                Author = headmannExample,
                Type = helperFile,
                Link = "https://educationalportal.blob.core.windows.net/student-notes/%D0%90%D0%BD%D0%B3%D0%BB%D1%96%D0%B9%D1%81%D1%8C%D0%BA%D0%B0%20%D0%BC%D0%BE%D0%B2%D0%B0(1-2%20%D0%BA%D1%83%D1%80%D1%81).pdf"});

            filesMath.Add(new File {
                Name = "ВМ Конспекти лекцій", 
                Subject = math,
                Author = headmannExample,
                Type = helperFile,
                Link = "https://educationalportal.blob.core.windows.net/student-notes/%D0%92%D0%9C%20%D0%9A%D0%BE%D0%BD%D1%81%D0%BF%D0%B5%D0%BA%D1%82%D0%B8%20%D0%BB%D0%B5%D0%BA%D1%86%D1%96%D0%B9.pdf"});
            
            filesMath.Add(new File { 
                Name = "ВМ Ч2 Вища математика у прикладах та задачахю Інтегральне численняю Литвин", 
                Subject = math,
                Author = user3,
                Type = homework,
                Deadline = new DateTime(2022, 6, 21),
                UsersCompleted = new List<User> {user2},
                Link = "https://educationalportal.blob.core.windows.net/student-notes/%D0%92%D0%9C%20%D0%A72%20%D0%92%D0%B8%D1%89%D0%B0%20%D0%BC%D0%B0%D1%82%D0%B5%D0%BC%D0%B0%D1%82%D0%B8%D0%BA%D0%B0%20%D1%83%20%D0%BF%D1%80%D0%B8%D0%BA%D0%BB%D0%B0%D0%B4%D0%B0%D1%85%20%D1%82%D0%B0%20%D0%B7%D0%B0%D0%B4%D0%B0%D1%87%D0%B0%D1%85%D1%8E%20%D0%86%D0%BD%D1%82%D0%B5%D0%B3%D1%80%D0%B0%D0%BB%D1%8C%D0%BD%D0%B5%20%D1%87%D0%B8%D1%81%D0%BB%D0%B5%D0%BD%D0%BD%D1%8F%D1%8E%20%D0%9B%D0%B8%D1%82%D0%B2%D0%B8%D0%BD.pdf"});
            
            filesMath.Add(new File { 
                Name = "ВМ Ч2 Сборник задач Інтегральне числення", 
                Subject = math,
                Author = user5,
                Type = helperFile,
                Link = "https://educationalportal.blob.core.windows.net/student-notes/%D0%92%D0%9C%20%D0%A72%20%D0%A1%D0%B1%D0%BE%D1%80%D0%BD%D0%B8%D0%BA%20%D0%B7%D0%B0%D0%B4%D0%B0%D1%87%20%D0%86%D0%BD%D1%82%D0%B5%D0%B3%D1%80%D0%B0%D0%BB%D1%8C%D0%BD%D0%B5%20%D1%87%D0%B8%D1%81%D0%BB%D0%B5%D0%BD%D0%BD%D1%8F.pdf"});

            filesHypertext.Add(new File {
                Name = "ГТГМ Методичні вказівки до лабораторних робіт", 
                Subject = hypertext,
                Author = user9,
                Type = lab,
                Deadline = new DateTime(2022, 5, 25),
                UsersCompleted = new List<User> {user4, user7},
                Link = "https://educationalportal.blob.core.windows.net/student-notes/%D0%93%D0%A2%D0%93%D0%9C%20%D0%9C%D0%B5%D1%82%D0%BE%D0%B4%D0%B8%D1%87%D0%BD%D1%96%20%D0%B2%D0%BA%D0%B0%D0%B7%D1%96%D0%B2%D0%BA%D0%B8%20%D0%B4%D0%BE%20%D0%BB%D0%B0%D0%B1%D0%BE%D1%80%D0%B0%D1%82%D0%BE%D1%80%D0%BD%D0%B8%D1%85%20%D1%80%D0%BE%D0%B1%D1%96%D1%82.pdf"});

            filesHypertext.Add(new File {
                Name = "ГТГМ_силабус_2020_2021", 
                Subject = hypertext,
                Author = user8,
                Type = helperFile,
                Link = "https://educationalportal.blob.core.windows.net/student-notes/%D0%93%D0%A2%D0%93%D0%9C_%D1%81%D0%B8%D0%BB%D0%B0%D0%B1%D1%83%D1%81_2020_2021.pdf"});
            
            filesProgramming.Add(new File {
                Name = "ООП програма", 
                Author = user4,
                Type = helperFile,
                Link = "https://educationalportal.blob.core.windows.net/student-notes/%D0%9E%D0%9E%D0%9F%20%D0%BF%D1%80%D0%BE%D0%B3%D1%80%D0%B0%D0%BC%D0%B0.pdf"});

            context.FileNotes.Add(new FileNote {Files = filesPhysics});
            context.FileNotes.Add(new FileNote {Files = filesMath});
            context.FileNotes.Add(new FileNote {Files = filesEnglish});
            context.FileNotes.Add(new FileNote {Files = filesHypertext});
            context.FileNotes.Add(new FileNote {Files = filesProgramming});

            context.SaveChanges();

            #endregion

            #region  text notes

            context.TextNotes.Add(new TextNote {
                Name = "Курсовая показ", 
                Subject = programming,
                Author = user1,
                Type = exam,
                UsersCompleted = new List<User> {user4, user7, user2, headmannExample},
                Deadline = new DateTime(2022, 6, 1),
                Text = "Доделать и показать курсовую"});

            context.TextNotes.Add(new TextNote {
                Name = "Экзамен ВМ", 
                Subject = math,
                Author = user2,
                Type = exam,
                Deadline = new DateTime(2022, 6, 21),
                Text = "Хорошо сдать экзамен по ВМ, сделать идз"});

            context.TextNotes.Add(new TextNote {
                Name = "ИРЗ физика",
                Subject = physics,
                Author = user3,
                Type = homework,
                UsersCompleted = new List<User> {user1, user4, user9, user2, user3},
                Deadline = new DateTime(2022, 7, 1),
                Text = "Сделать ИРЗ по физике"});

            context.TextNotes.Add(new TextNote {
                Name = "Зачёт ГТГМ", 
                Subject = hypertext,
                Author = user4,
                Type = homework,
                UsersCompleted = new List<User> {user2, user5, user1, headmannExample},
                Deadline = new DateTime(2022, 7, 15),
                Text = "Пройти курсы на коурсере"});

            context.TextNotes.Add(new TextNote {
                Name = "ДЗ английский",
                Subject = english,
                Author = user5,
                Type = homework,
                UsersCompleted = new List<User> {user9},
                Deadline = new DateTime(2022, 5, 29), 
                Text = "Сделать ДЗ английский"});

            context.TextNotes.Add(new TextNote {
                Name = "Лабы ООП", 
                Subject = programming,
                Author = user6,
                Type = homework,
                UsersCompleted = new List<User> {user1, user2, headmannExample},
                Deadline = new DateTime(2022, 6, 1), 
                Text = "Отправить 3 лабы по ООП"});

            context.SaveChanges();

            #endregion

            #region teachers

            teacherMath1 = new Teacher {
                Name = "АЛЕКСАНДРА ГРИГОРЬЕВНА ЛИТВИН",
                Email = "oleksandra.litvin@nure.ua",
                Avatar = "https://nure.ua/wp-content/uploads/Employees_photo/LitvinAG.jpg",
                Subjects = {}
            };

            teacherMath2 = new Teacher {
                Name = "АННА ВИКТОРОВНА СТАДНИКОВА",
                Email = "hanna.stadnikova@nure.ua",
                Avatar = "https://nure.ua/wp-content/uploads/Employees_photo/stadnikova-ganna-viktorivna.jpg",
                Subjects = {}
            };

            teacherPs1 = new Teacher {
                Name = "ВЛАДИМИР АЛЕКСАНДРОВИЧ СТОРОЖЕНКО",
                Email = "volodymyr.storozhenko@nure.ua",
                Avatar = "https://nure.ua/wp-content/uploads/Employees_photo/Storozhenko_VO.jpg",
                Subjects = {}
            };

            teacherPs2 = new Teacher {
                Name = "АЛЕКСАНДР ВАЛЕРИЕВИЧ МЯГКИЙ",
                Email = "aleksandr.mjagky@nure.ua",
                Avatar = "https://nure.ua/wp-content/uploads/Employees_photo/Mjagky_OV.jpg",
                Subjects = {}
            };

            teacherPs3 = new Teacher {
                Name = "ЮРИЙ ДМИТРИЕВИЧ ПРИЙМАЧЕВ",
                Email = "",
                Avatar = "https://nure.ua/wp-content/uploads/Employees_photo/pimachev-jud.jpg",
                Subjects = {}
            };

            teacherEngl = new Teacher {
                Name = "ЄВГЕН ЯКОВИЧ ЛОГВІНОВ",
                Email = "evhen.logvinov@nure.ua",
                Avatar = "https://nure.ua/wp-content/uploads/Employees_photo/logvinov-ie.ja..jpg",
                Subjects = {}
            };

            teacherProgr = new Teacher {
                Name = "ЮЛИЯ ЮРЬЕВНА ЧЕРЕПАНОВА",
                Email = "yulia.cherepanova@nure.ua",
                Avatar = "https://nure.ua/wp-content/uploads/Employees_photo/cherepanova_yy-1.jpg",
                Subjects = {}
            };

            teacherHyper = new Teacher {
                Name = "ЕКАТЕРИНА ВИКТОРОВНА ЗЫБИНА",
                Email = "kateryna.zybina@nure.ua",
                Avatar = "https://nure.ua/wp-content/uploads/Employees_photo/zybina_kv-1.jpg",
                Subjects = {}
            };

            
            context.Teachers.Add(teacherMath1);
            context.Teachers.Add(teacherMath2);
            context.Teachers.Add(teacherPs1);
            context.Teachers.Add(teacherPs2);
            context.Teachers.Add(teacherPs3);
            context.Teachers.Add(teacherEngl);
            context.Teachers.Add(teacherProgr);
            context.Teachers.Add(teacherHyper);
            context.SaveChanges();

            #endregion

            #region group

            List <User> allUsers = new List<User>(headmannExample, user1, user2, user3, user4, user5, user6, user7, user8, user9);

            Group groupExample = new Group
            {
                Name = "PZPI-21-4",
                InviteCode = "b3gr90",
                Headmann = headmannExample,
                Users = allUsers
            };

            context.Groups.Add(groupExample);
            context.SaveChanges();

            #endregion

            #region subjects

            physics = new Subject {
                Name = "Фізика", 
                Teachers = new List<Teacher>() {teacherPs1, teacherPs2, teacherPs3}};
            
            math = new Subject {
                Name = "Вища математика", 
                Teachers = new List<Teacher>() {teacherMath1, teacherMath2}};
            
            english = new Subject {
                Name = "Англійська мова", 
                Teachers = new List<Teacher>() {teacherEngl}};
            
            programming = new Subject {
                Name = "Об'єктно-орієнтоване програмування", 
                Teachers = new List<Teacher>() {teacherProgr}};
            
            hypertext = new Subject {
                Name = "Гіпертекст та гіпермедіа", 
                Teachers = new List<Teacher>() {teacherHyper}};
            

            context.Subjects.Add(math);
            context.Subjects.Add(physics);
            context.Subjects.Add(english);
            context.Subjects.Add(programming);
            context.Subjects.Add(hypertext);

            context.SaveChanges();

            #endregion

        }
        
    }
}