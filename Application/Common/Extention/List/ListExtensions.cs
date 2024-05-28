namespace Application.Common.Extention.List;

public static class ListExtensions
{
    public static List<TEntity> PagesList<TEntity>(this List<TEntity>? query, int? page = null,
        int? perPage = null)
    {
        List<TEntity> pageList = new();
        pageList = perPage!.Value == 0
            ? Enumerable.ToList(query!)
            : Enumerable.ToList(Enumerable.Take(Enumerable.Skip(query!, (page!.Value - 1) * perPage.Value), perPage.Value));

        return pageList;
    }


    public static List<TEntity> PagesListAsync<TEntity>(this Task<List<TEntity>> query, int? page = null,
        int? perPage = null)
    {
        List<TEntity> pageList = new();
        pageList = (perPage!.Value == 0
            ? Enumerable.ToList(query!.Result)
            : Enumerable.ToList(Enumerable.Take(Enumerable.Skip(query.Result!, (page!.Value - 1) * perPage.Value), perPage.Value)));

        return pageList;
    }
}