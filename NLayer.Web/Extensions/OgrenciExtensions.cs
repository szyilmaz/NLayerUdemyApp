using NLayer.Core;
using NLayer.Core.DTOs;

namespace NLayer.Web.Extensions
{
    public static class OgrenciExtensions
    {
        public static IQueryable<OgrenciWithDersDto> Sort(this IQueryable<OgrenciWithDersDto> query, string orderBy)
        {
            if (string.IsNullOrWhiteSpace(orderBy)) return query.OrderBy(c => c.Adi);

            query = orderBy switch
            {
                "soyadi" => query.OrderBy(p => p.Soyadi),
                _ => query.OrderBy(c => c.Adi)
            };
            return query;
        }

        public static IQueryable<OgrenciWithDersDto> Search(this IQueryable<OgrenciWithDersDto> query, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) return query;
            var lowerCaseSearchTerm = searchTerm.Trim().ToLower();
            return query.Where(c => c.Adi.ToLower().Contains(lowerCaseSearchTerm));
        }

        public static IQueryable<OgrenciWithDersDto> Filter(this IQueryable<OgrenciWithDersDto> query, string dersler)
        {
            var dersList = new List<string>();

            if (!string.IsNullOrEmpty(dersler))
                dersList.AddRange(dersler.ToLower().Split(",").ToList());

            query = query.Where(c => dersList.Count == 0);

            return query;
        }
    }
}