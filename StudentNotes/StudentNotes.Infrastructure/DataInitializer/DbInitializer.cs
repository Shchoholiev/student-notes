using StudentNotes.Core.Entities;
using StudentNotes.Core.Entities.Identity;
using StudentNotes.Core.Entities.Notes;
using StudentNotes.Infrastructure.ApplicationContext;
using StudentNotes.Infrastructure.Services;

namespace StudentNotes.Infrastructure.DataInitializer
{
    public static class DbInitializer
    {
        public static void Initialize(EFContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();


            #region group


            // added in users region

            #endregion

            #region roles
            var roleHeadmann = new Role { Name = "Headman" };
            var roleStudent = new Role { Name = "Student" };
            // role proforg ?

            //var role = new Role { roleHeadmann };
            context.Roles.Add(roleHeadmann);
            context.Roles.Add(roleStudent);
            context.SaveChanges();

            #endregion

            #region users

            var passwordHasher = new PasswordHasher();

            var passwordHash = passwordHasher.Hash("cool-vanya");

            var headmannExample = new User
            {
                Name = "Іван Бургард",
                Email = "ivan@gmail.com",
                PasswordHash = passwordHash,
                Avatar = "https://media.istockphoto.com/photos/businessman-silhouette-as-avatar-or-default-profile-picture-picture-id476085198?b=1&k=20&m=476085198&s=170667a&w=0&h=Ct4e1kIOdCOrEgvsQg4A1qeuQv944pPFORUQcaGw4oI=",
                Roles = new List<Role> { roleHeadmann, roleStudent }
            };

            passwordHash = passwordHasher.Hash("great-vika");

            var user1 = new User
            {
                Name = "Вікторія Вовченко",
                Email = "vika.vovchenkoo@gmail.com",
                PasswordHash = passwordHash,
                Avatar = "https://media.istockphoto.com/photos/businessman-silhouette-as-avatar-or-default-profile-picture-picture-id476085198?b=1&k=20&m=476085198&s=170667a&w=0&h=Ct4e1kIOdCOrEgvsQg4A1qeuQv944pPFORUQcaGw4oI=",
                Roles = new List<Role> { roleStudent }
            };

            passwordHash = passwordHasher.Hash("awesome-sergey");

            var user2 = new User
            {
                Name = "Сергій Щоголєв",
                Email = "serg@gmail.com",
                PasswordHash = passwordHash,
                Avatar = "https://media.istockphoto.com/photos/businessman-silhouette-as-avatar-or-default-profile-picture-picture-id476085198?b=1&k=20&m=476085198&s=170667a&w=0&h=Ct4e1kIOdCOrEgvsQg4A1qeuQv944pPFORUQcaGw4oI=",
                Roles = new List<Role> { roleStudent }
            };

            passwordHash = passwordHasher.Hash("beautiful-liza");

            var user3 = new User
            {
                Name = "Елизавета Бойко",
                Email = "liza@gmail.com",
                PasswordHash = passwordHash,
                Avatar = "https://media.istockphoto.com/photos/businessman-silhouette-as-avatar-or-default-profile-picture-picture-id476085198?b=1&k=20&m=476085198&s=170667a&w=0&h=Ct4e1kIOdCOrEgvsQg4A1qeuQv944pPFORUQcaGw4oI=",
                Roles = new List<Role> { roleStudent }
            };

            passwordHash = passwordHasher.Hash("pretty-polina");

            var user4 = new User
            {
                Name = "Поліна Павленко",
                Email = "polina@gmail.com",
                PasswordHash = passwordHash,
                Avatar = "https://media.istockphoto.com/photos/businessman-silhouette-as-avatar-or-default-profile-picture-picture-id476085198?b=1&k=20&m=476085198&s=170667a&w=0&h=Ct4e1kIOdCOrEgvsQg4A1qeuQv944pPFORUQcaGw4oI=",
                Roles = new List<Role> { roleStudent }
            };

            passwordHash = passwordHasher.Hash("lovely-eva");

            var user5 = new User
            {
                Name = "Ева Довженко",
                Email = "polina@gmail.com",
                PasswordHash = passwordHash,
                Avatar = "https://media.istockphoto.com/photos/businessman-silhouette-as-avatar-or-default-profile-picture-picture-id476085198?b=1&k=20&m=476085198&s=170667a&w=0&h=Ct4e1kIOdCOrEgvsQg4A1qeuQv944pPFORUQcaGw4oI=",
                Roles = new List<Role> { roleStudent }
            };

            passwordHash = passwordHasher.Hash("misha");

            var user6 = new User
            {
                Name = "Михайло Білодід",
                Email = "misha@gmail.com",
                PasswordHash = passwordHash,
                Avatar = "https://media.istockphoto.com/photos/businessman-silhouette-as-avatar-or-default-profile-picture-picture-id476085198?b=1&k=20&m=476085198&s=170667a&w=0&h=Ct4e1kIOdCOrEgvsQg4A1qeuQv944pPFORUQcaGw4oI=",
                Roles = new List<Role> { roleStudent }
            };

            passwordHash = passwordHasher.Hash("stunning-vitalik");

            var user7 = new User
            {
                Name = "Віталій Красноруцький",
                Email = "vitalik@gmail.com",
                PasswordHash = passwordHash,
                Avatar = "https://media.istockphoto.com/photos/businessman-silhouette-as-avatar-or-default-profile-picture-picture-id476085198?b=1&k=20&m=476085198&s=170667a&w=0&h=Ct4e1kIOdCOrEgvsQg4A1qeuQv944pPFORUQcaGw4oI=",
                Roles = new List<Role> { roleStudent }
            };

            passwordHash = passwordHasher.Hash("wonderful-nikita");

            var user8 = new User
            {
                Name = "Микита Дубовий",
                Email = "nikita@gmail.com",
                PasswordHash = passwordHash,
                Avatar = "https://media.istockphoto.com/photos/businessman-silhouette-as-avatar-or-default-profile-picture-picture-id476085198?b=1&k=20&m=476085198&s=170667a&w=0&h=Ct4e1kIOdCOrEgvsQg4A1qeuQv944pPFORUQcaGw4oI=",
                Roles = new List<Role> { roleStudent }
            };

            passwordHash = passwordHasher.Hash("clever-misha");

            var user9 = new User
            {
                Name = "Михайло Овчаренко",
                Email = "mischao@gmail.com",
                PasswordHash = passwordHash,
                Avatar = "https://media.istockphoto.com/photos/businessman-silhouette-as-avatar-or-default-profile-picture-picture-id476085198?b=1&k=20&m=476085198&s=170667a&w=0&h=Ct4e1kIOdCOrEgvsQg4A1qeuQv944pPFORUQcaGw4oI=",
                Roles = new List<Role> { roleStudent }
            };

            context.Users.Add(headmannExample);
            context.Users.Add(user1);
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.Users.Add(user4);
            context.Users.Add(user5);
            context.Users.Add(user6);
            context.Users.Add(user7);
            context.Users.Add(user8);
            context.Users.Add(user9);

            context.SaveChanges();

            var groupExample = new Group
            {
                Name = "PZPI-21-4",
                InviteCode = "b3gr90",
                Users = new List<User> { headmannExample, user1, user2, user3, user4, user5, user6, user7, user8, user9 }
            };

            context.Groups.Add(groupExample);
            context.SaveChanges();

            // add all to group

            #endregion

            #region notes types

            var lab = new Core.Entities.Type { Name = "Лабораторна робота" };
            var practice = new Core.Entities.Type { Name = "Практична робота" };
            var lecture = new Core.Entities.Type { Name = "Лекція" };
            var exam = new Core.Entities.Type { Name = "Екзамен" };
            var homework = new Core.Entities.Type { Name = "Домашнє завдання" };
            var helperFile = new Core.Entities.Type { Name = "Допоміжний файл" };

            #endregion

            #region subjects

            var physics = new Subject
            {
                Name = "Фізика"
            };

            var math = new Subject
            {
                Name = "Вища математика"
            };

            var english = new Subject
            {
                Name = "Англійська мова"
            };

            var programming = new Subject
            {
                Name = "Об'єктно-орієнтоване програмування"
            };

            var hypertext = new Subject
            {
                Name = "Гіпертекст та гіпермедіа"
            };

            context.Subjects.Add(math);
            context.Subjects.Add(physics);
            context.Subjects.Add(english);
            context.Subjects.Add(programming);
            context.Subjects.Add(hypertext);
            // added at teachers region


            #endregion

            #region file notes


            var filesPhysics = new FileNote
            {
                Files = new List<Core.Entities.File> {new Core.Entities.File {
                        Name = "Фізика Кінематика розбір задач",
                        Link = "https://educationalportal.blob.core.windows.net/student-notes/%D0%A4%D1%96%D0%B7%D0%B8%D0%BA%D0%B0%20%D0%9A%D0%B8%D0%BD%D0%B5%D0%BC%D0%B0%D1%82%D0%B8%D0%BA%D0%B0%20%D0%B7%D0%B0%D0%B4%D0%B0%D1%87%D0%B8%20%D1%80%D0%B0%D0%B7%D0%B1%D0%BE%D1%80.pdf"
                    },
                    new Core.Entities.File {
                        Name = "Фізика Контрольні завдання",
                        Link = "https://educationalportal.blob.core.windows.net/student-notes/%D0%A4%D1%96%D0%B7%D0%B8%D0%BA%D0%B0%20%D0%9A%D0%BE%D0%BD%D1%82%D1%80%D0%BE%D0%BB%D1%8C%D0%BD%D1%96%20%D0%B7%D0%B0%D0%B2%D0%B4%D0%B0%D0%BD%D0%BD%D1%8F.pdf"
                    },
                    new Core.Entities.File {
                        Name = "Фізика Условия ИДЗ",
                        Link = "https://educationalportal.blob.core.windows.net/student-notes/%D0%A4%D1%96%D0%B7%D0%B8%D0%BA%D0%B0%20%D0%A3%D1%81%D0%BB%D0%BE%D0%B2%D0%B8%D1%8F%20%D0%98%D0%94%D0%97.pdf"
                    }
                },
                Subject = physics,
                DeadLine = new DateTime(2022, 7, 1),
                Author = user5,
                Group = groupExample,
                Type = homework,
                UsersCompleted = new List<User> { user1, user3, user6 }
            };

            var filesEnglish = new FileNote
            {
                Files = new List<Core.Entities.File> {new Core.Entities.File {
                        Name = "Англійська мова 1-2 курс",
                        Link = "https://educationalportal.blob.core.windows.net/student-notes/%D0%90%D0%BD%D0%B3%D0%BB%D1%96%D0%B9%D1%81%D1%8C%D0%BA%D0%B0%20%D0%BC%D0%BE%D0%B2%D0%B0(1-2%20%D0%BA%D1%83%D1%80%D1%81).pdf"
                    }
                },
                Subject = english,
                DeadLine = new DateTime(2022, 7, 1),
                Group = groupExample,
                Author = headmannExample,
                Type = helperFile
            };

            var filesMath = new FileNote
            {
                Files = new List<Core.Entities.File> {new Core.Entities.File {
                        Name = "ВМ Конспекти лекцій",
                        Link = "https://educationalportal.blob.core.windows.net/student-notes/%D0%92%D0%9C%20%D0%9A%D0%BE%D0%BD%D1%81%D0%BF%D0%B5%D0%BA%D1%82%D0%B8%20%D0%BB%D0%B5%D0%BA%D1%86%D1%96%D0%B9.pdf"
                    },
                    new Core.Entities.File {
                        Name = "ВМ Ч2 Сборник задач Інтегральне числення",
                        Link = "https://educationalportal.blob.core.windows.net/student-notes/%D0%92%D0%9C%20%D0%A72%20%D0%A1%D0%B1%D0%BE%D1%80%D0%BD%D0%B8%D0%BA%20%D0%B7%D0%B0%D0%B4%D0%B0%D1%87%20%D0%86%D0%BD%D1%82%D0%B5%D0%B3%D1%80%D0%B0%D0%BB%D1%8C%D0%BD%D0%B5%20%D1%87%D0%B8%D1%81%D0%BB%D0%B5%D0%BD%D0%BD%D1%8F.pdf"
                    },
                    new Core.Entities.File {
                        Name = "ВМ Ч2 Вища математика у прикладах та задачахю Інтегральне численняю Литвин",
                        Link = "https://educationalportal.blob.core.windows.net/student-notes/%D0%92%D0%9C%20%D0%A72%20%D0%92%D0%B8%D1%89%D0%B0%20%D0%BC%D0%B0%D1%82%D0%B5%D0%BC%D0%B0%D1%82%D0%B8%D0%BA%D0%B0%20%D1%83%20%D0%BF%D1%80%D0%B8%D0%BA%D0%BB%D0%B0%D0%B4%D0%B0%D1%85%20%D1%82%D0%B0%20%D0%B7%D0%B0%D0%B4%D0%B0%D1%87%D0%B0%D1%85%D1%8E%20%D0%86%D0%BD%D1%82%D0%B5%D0%B3%D1%80%D0%B0%D0%BB%D1%8C%D0%BD%D0%B5%20%D1%87%D0%B8%D1%81%D0%BB%D0%B5%D0%BD%D0%BD%D1%8F%D1%8E%20%D0%9B%D0%B8%D1%82%D0%B2%D0%B8%D0%BD.pdf"
                    }
                },
                Subject = math,
                DeadLine = new DateTime(2022, 6, 21),
                Author = user7,
                Group = groupExample,
                Type = helperFile,
                UsersCompleted = new List<User> { user9 }
            };

            var filesHypertext = new FileNote
            {
                Files = new List<Core.Entities.File> {new Core.Entities.File {
                        Name = "ГТГМ Методичні вказівки до лабораторних робіт",
                        Link = "https://educationalportal.blob.core.windows.net/student-notes/%D0%93%D0%A2%D0%93%D0%9C%20%D0%9C%D0%B5%D1%82%D0%BE%D0%B4%D0%B8%D1%87%D0%BD%D1%96%20%D0%B2%D0%BA%D0%B0%D0%B7%D1%96%D0%B2%D0%BA%D0%B8%20%D0%B4%D0%BE%20%D0%BB%D0%B0%D0%B1%D0%BE%D1%80%D0%B0%D1%82%D0%BE%D1%80%D0%BD%D0%B8%D1%85%20%D1%80%D0%BE%D0%B1%D1%96%D1%82.pdf"
                    },
                    new Core.Entities.File {
                        Name = "ГТГМ_силабус_2020_2021",
                        Link = "https://educationalportal.blob.core.windows.net/student-notes/%D0%93%D0%A2%D0%93%D0%9C_%D1%81%D0%B8%D0%BB%D0%B0%D0%B1%D1%83%D1%81_2020_2021.pdf"
                    }
                },
                Subject = hypertext,
                DeadLine = new DateTime(2022, 7, 1),
                Author = user4,
                Group = groupExample,
                Type = lab,
                UsersCompleted = new List<User> { user3, user7 }
            };

            var filesProgramming = new FileNote
            {
                Files = new List<Core.Entities.File> {new Core.Entities.File {
                        Name = "ООП програма",
                        Link = "https://educationalportal.blob.core.windows.net/student-notes/%D0%9E%D0%9E%D0%9F%20%D0%BF%D1%80%D0%BE%D0%B3%D1%80%D0%B0%D0%BC%D0%B0.pdf"
                    }
                },
                Subject = hypertext,
                DeadLine = new DateTime(2022, 7, 1),
                Author = user4,
                Group = groupExample,
                Type = lab,
                UsersCompleted = new List<User> { user3, user7 }
            };


            context.FileNotes.Add(filesProgramming);
            context.FileNotes.Add(filesMath);
            context.FileNotes.Add(filesHypertext);
            context.FileNotes.Add(filesEnglish);
            context.FileNotes.Add(filesPhysics);

            context.SaveChanges();

            #endregion

            #region  text notes

            context.TextNotes.Add(new TextNote
            {
                Name = "Курсовая показ",
                Subject = programming,
                Author = user1,
                Type = exam,
                UsersCompleted = new List<User> { user4, user7, user2, headmannExample },
                DeadLine = new DateTime(2022, 6, 1),
                Group = groupExample,
                Text = "Доделать и показать курсовую"
            });

            context.TextNotes.Add(new TextNote
            {
                Name = "Экзамен ВМ",
                Subject = math,
                Author = user2,
                Type = exam,
                DeadLine = new DateTime(2022, 6, 21),
                Group = groupExample,
                Text = "Хорошо сдать экзамен по ВМ, сделать идз"
            });

            context.TextNotes.Add(new TextNote
            {
                Name = "ИРЗ физика",
                Subject = physics,
                Author = user3,
                Type = homework,
                UsersCompleted = new List<User> { user1, user4, user9, user2, user3 },
                DeadLine = new DateTime(2022, 7, 1),
                Group = groupExample,
                Text = "Сделать ИРЗ по физике"
            });

            context.TextNotes.Add(new TextNote
            {
                Name = "Зачёт ГТГМ",
                Subject = hypertext,
                Author = user4,
                Type = homework,
                UsersCompleted = new List<User> { user2, user5, user1, headmannExample },
                DeadLine = new DateTime(2022, 7, 15),
                Group = groupExample,
                Text = "Пройти курсы на коурсере"
            });

            context.TextNotes.Add(new TextNote
            {
                Name = "ДЗ английский",
                Subject = english,
                Author = user5,
                Type = homework,
                UsersCompleted = new List<User> { user9 },
                DeadLine = new DateTime(2022, 5, 29),
                Group = groupExample,
                Text = "Сделать ДЗ английский"
            });

            context.TextNotes.Add(new TextNote
            {
                Name = "Лабы ООП",
                Subject = programming,
                Author = user6,
                Type = homework,
                UsersCompleted = new List<User> { user1, user2, headmannExample },
                DeadLine = new DateTime(2022, 6, 1),
                Group = groupExample,
                Text = "Отправить 3 лабы по ООП"
            });

            context.SaveChanges();

            #endregion

            #region teachers

            var teacherMath1 = new Teacher
            {
                Name = "АЛЕКСАНДРА ГРИГОРЬЕВНА ЛИТВИН",
                Email = "oleksandra.litvin@nure.ua",
                Avatar = "https://nure.ua/wp-content/uploads/Employees_photo/LitvinAG.jpg",
                Subjects = new List<Subject> { math }
            };

            var teacherMath2 = new Teacher
            {
                Name = "АННА ВИКТОРОВНА СТАДНИКОВА",
                Email = "hanna.stadnikova@nure.ua",
                Avatar = "https://nure.ua/wp-content/uploads/Employees_photo/stadnikova-ganna-viktorivna.jpg",
                Subjects = new List<Subject> { math }
            };

            var teacherPs1 = new Teacher
            {
                Name = "ВЛАДИМИР АЛЕКСАНДРОВИЧ СТОРОЖЕНКО",
                Email = "volodymyr.storozhenko@nure.ua",
                Avatar = "https://nure.ua/wp-content/uploads/Employees_photo/Storozhenko_VO.jpg",
                Subjects = new List<Subject> { physics }
            };

            var teacherPs2 = new Teacher
            {
                Name = "АЛЕКСАНДР ВАЛЕРИЕВИЧ МЯГКИЙ",
                Email = "aleksandr.mjagky@nure.ua",
                Avatar = "https://nure.ua/wp-content/uploads/Employees_photo/Mjagky_OV.jpg",
                Subjects = new List<Subject> { math, physics }
            };

            var teacherPs3 = new Teacher
            {
                Name = "ЮРИЙ ДМИТРИЕВИЧ ПРИЙМАЧЕВ",
                Email = "",
                Avatar = "https://nure.ua/wp-content/uploads/Employees_photo/pimachev-jud.jpg",
                Subjects = new List<Subject> { physics }
            };

            var teacherEngl = new Teacher
            {
                Name = "ЄВГЕН ЯКОВИЧ ЛОГВІНОВ",
                Email = "evhen.logvinov@nure.ua",
                Avatar = "https://nure.ua/wp-content/uploads/Employees_photo/logvinov-ie.ja..jpg",
                Subjects = new List<Subject> { english }
            };

            var teacherProgr = new Teacher
            {
                Name = "ЮЛИЯ ЮРЬЕВНА ЧЕРЕПАНОВА",
                Email = "yulia.cherepanova@nure.ua",
                Avatar = "https://nure.ua/wp-content/uploads/Employees_photo/cherepanova_yy-1.jpg",
                Subjects = new List<Subject> { programming }
            };

            var teacherHyper = new Teacher
            {
                Name = "ЕКАТЕРИНА ВИКТОРОВНА ЗЫБИНА",
                Email = "kateryna.zybina@nure.ua",
                Avatar = "https://nure.ua/wp-content/uploads/Employees_photo/zybina_kv-1.jpg",
                Subjects = new List<Subject> { hypertext }
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

            // add subjects

            physics.Teachers = new List<Teacher>() { teacherPs1, teacherPs2, teacherPs3 };
            math.Teachers = new List<Teacher>() { teacherMath1, teacherMath2 };
            english.Teachers = new List<Teacher>() { teacherEngl };
            programming.Teachers = new List<Teacher>() { teacherProgr };
            hypertext.Teachers = new List<Teacher>() { teacherHyper };



            context.SaveChanges();

            #endregion

        }
    }
}
