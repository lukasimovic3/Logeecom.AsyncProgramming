﻿using Logeecom.AsyncProgramming.Business.Interfaces;
using Logeecom.AsyncProgramming.Domain;

namespace Logeecom.AsyncProgramming.DataAccess.Repositories
{
    public class GenreRepositorySync : IGenreRepositorySync
    {
        private readonly DbContextEF context;

        public GenreRepositorySync(DbContextEF context)
        {
            this.context = context;
        }

        public Genre? GetGenreByName(string name)
        {
            Thread.Sleep(100);
            return this.context.Genres.FirstOrDefault(g => g.Name == name);
        }

        public void AddGenre(Genre genre)
        {
            Thread.Sleep(100);
            this.context.Genres.Add(genre);
        }
    }
}