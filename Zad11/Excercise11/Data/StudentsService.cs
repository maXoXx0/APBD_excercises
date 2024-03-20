﻿namespace Excercise11.Data
{
    public class StudentsService
    {
        public List<Student> Students { get; }

        public StudentsService()
        {
            Students = new List<Student>() 
            {
                new Student()
                {
                    Id = 1,
                    Avatar = "data:image/png;base64,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",
                    FirstName = "Maks",
                    LastName = "Janas",
                    Birthday = DateTime.Parse("2002-03-16"),
                    Studies = "Computer Science"
                },

                new Student()
                {
                    Id = 2,
                    Avatar = "https://cdn.siasat.com/wp-content/uploads/2021/05/Discord.jpg",
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    Birthday = DateTime.Parse("2076-09-23"),
                    Studies = "Managment"
                },

                new Student()
                {
                    Id = 3,
                    Avatar = "https://cdn.nba.com/headshots/nba/latest/1040x760/2544.png",
                    FirstName = "LeBron",
                    LastName = "James",
                    Birthday = DateTime.Parse("2002-12-30"),
                    Studies = "Basketball"
                }

                
            };
        }
    }
}
