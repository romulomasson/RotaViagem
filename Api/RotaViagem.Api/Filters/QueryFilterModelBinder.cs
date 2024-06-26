using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RotaViagem.Domain.Entities;
using RotaViagem.Domain.Entities;

namespace RotaViagem.Api.Filters;

public class QueryFilterModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext.ModelType != typeof(QueryFilter))
            throw new ArgumentNullException(nameof(bindingContext));

        var queryString = bindingContext.ActionContext
            .HttpContext.Request.Query
            .ToDictionary(x => x.Key, x => x.Value);


        var query = new QueryFilter
        {
            Limit = GetLimit(queryString),
            Start = GetStart(queryString),
            Sorts = GetSorter(queryString)
        };
        GetFilter(queryString, query);

        bindingContext.Result = ModelBindingResult.Success(query);
        return Task.CompletedTask;
    }

    private static int GetStart(Dictionary<string, StringValues> queryString) => !queryString.ContainsKey("start") ? 0 : Convert.ToInt32(queryString["start"]);

    private static int GetLimit(Dictionary<string, StringValues> queryString) => !queryString.ContainsKey("limit") ? 0 : Convert.ToInt32(queryString["limit"]);

    private static void GetFilter(Dictionary<string, StringValues> queryString, QueryFilter filter)
    {
        queryString.Remove("start");
        queryString.Remove("limit");
        queryString.Remove("_");

        foreach (var item in queryString)
            filter.AddFilter(item.Key, item.Value, true);
    }

    private static List<QueryFilter.SorterContainer> GetSorter(Dictionary<string, StringValues> queryString)
    {
        if (queryString.ContainsKey("sort"))
            return JsonConvert.DeserializeObject<IEnumerable<QueryFilter.SorterContainer>>(queryString["sort"]).ToList();

        return null;
    }
}








