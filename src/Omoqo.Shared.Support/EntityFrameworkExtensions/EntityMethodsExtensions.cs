using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Omoqo.Shared.Support.EntityMethodsExtensions
{
    public static class EntityMethodsExtensions
    {
        private const string UseNolockHint = "Use NOLOCK";
        public static IQueryable<TEntity> UseNolock<TEntity>(this IQueryable<TEntity> query)
        {
            query = query.TagWith(UseNolockHint);
            return query;
        }

        public static PropertyBuilder<string> IsVarchar(this PropertyBuilder<string> propertyBuilder, int size)
        {
            return propertyBuilder.HasColumnType($"VARCHAR({size})");
        }

        public static PropertyBuilder<string> IsVarcharMax(this PropertyBuilder<string> propertyBuilder)
        {
            return propertyBuilder.HasColumnType($"VARCHAR(MAX)");
        }

    }
}
