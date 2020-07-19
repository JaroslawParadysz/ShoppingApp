using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ShoppingApp.Infrastructure.SqlServer.SeedWork
{
    public static class EfCoreExtensions
    {
        public static IQueryable<TEntity> IncludePath<TEntity>([NotNullAttribute] this IQueryable<TEntity> source, params string[] options) where TEntity : class
        {
            string path = String.Join('.', options);
            return source.Include(path);
        }
    }
}
