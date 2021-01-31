﻿using System.Linq;
using OnlineCinema.Data;

namespace OnlineCinema.Models
{
    public static class Initializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Movies.Any())
            {
                context.Movies.AddRange(
                    new Movie
                    {
                        Name = "Соник в кино!",
                        Description =
                            "Отвязный ярко-синий ёжик Соник из параллельного мира вместе с новообретённым лучшим другом-человеком по имени Том знакомится со сложностями жизни на Земле и противостоит злодейскому доктору Роботнику, который хочет пленить Соника и использовать его безграничные суперсилы для завоевания мирового господства.",
                        ReleaseYear = "2021",
                        Producer = "Джефф Фаулер",
                        Image = "4079b5aa-c65c-4133-bdd6-70ea533a6ab7.jpg"
                    },
                    new Movie
                    {
                        Name = "Бладшот",
                        Description =
                            "Военный Рэй Гаррисон возвращается из очередной горячей точки к любимой красавице-жене. Супруги проводят отпуск в Европе, но счастье длится недолго — террористы, не сумев вытянуть из Рэя нужную им информацию, убивают жену, а затем и его самого. Но вскоре корпорация RST возвращает его к жизни. Армия нанороботов в крови превратила Рэя в бессмертного Бладшота, и теперь солдат наделен сверхсилой и способностью мгновенно самоисцеляться, вот только память оставляет желать лучшего. Но вскоре воспоминания о последних мгновениях жизни возвращаются, и Бладшот отправляется мстить за смерть жены.",
                        ReleaseYear = "2020",
                        Producer = "Дэйв Уилсон",
                        Image = "520fb20b-c49c-471f-8830-4086f8049c66.jpg"
                    },
                    new Movie
                    {
                        Name = "Зов предков",
                        Description =
                            "История Бака, дружелюбного пса, чья размеренная домашняя жизнь перевернулась с ног на голову во времена золотой лихорадки в 1880-х, когда его вырвали из дома в Калифорнии и перевезли в дикую и холодную Аляску. Будучи новичком в упряжке почтовой службы, а впоследствии лидером, Бак попадает в невероятное приключение, находит свое место в мире и становится хозяином своей жизни.",
                        ReleaseYear = "2020",
                        Producer = "Крис Сандерс",
                        Image = "6da700ca-bfa1-42ee-82b1-310556d4bae3.jpg"
                    },
                    new Movie
                    {
                        Name = "Спутник",
                        Description =
                            "СССР, 1983 год. На землю возвращается космический аппарат, но от людей скрывают, что из двух космонавтов живым можно считать только одного. Что произошло на борту, остается загадкой, но факты указывают на то, что космонавты столкнулись с новой формой жизни, и выживший вернулся не совсем один. На засекреченную военную базу, где космонавт Константин Вешняков содержится под строгим контролем и наблюд",
                        ReleaseYear = "2020",
                        Producer = "Егор Абраменко",
                        Image = "d5ea8288-1cc5-4383-9624-063317a0f0f2.jpg"
                    },
                    new Movie
                    {
                        Name = "Чёрная Вдова",
                        Description =
                            "Наташе Романофф предстоит лицом к лицу встретиться со своим прошлым. Чёрной Вдове придется вспомнить о том, что было в её жизни задолго до присоединения к команде Мстителей, и узнать об опасном заговоре, в который оказываются втянуты её старые знакомые — Елена, Алексей, также известный как Красный Страж, и Мелина.",
                        ReleaseYear = "2020",
                        Producer = "Кейт Шортланд",
                        Image = "070d53ec-cca6-49e8-aa8a-79db700a0060.jpg"
                    }
                );
                context.SaveChanges();
            }

            //if (!context.Users.Any())
            //{
            //    context.Users.AddRange(
            //        new IdentityUser
            //        {
            //            UserName = "admin@mail.ru",
            //            Email = "admin@mail.ru",
            //            EmailConfirmed = true
            //        },
            //        new IdentityUser
            //        {
            //            UserName = "user@mail.ru",
            //            Email = "user@mail.ru",
            //            EmailConfirmed = true
            //        }
            //    );
            //    context.SaveChanges();
            //}
        }
    }
}