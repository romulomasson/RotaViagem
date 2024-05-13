using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using RotaViagem.Domain.Entities;
using RotaViagem.Api.Filters;
using RotaViagem.Domain.Entities;

namespace RotaViagem.Api.Filters;

public class ProviderModelBinder : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        if (context == null)
            throw new ArgumentNullException(nameof(context));

        if (context.Metadata.ModelType == typeof(QueryFilter))
            return new BinderTypeModelBinder(typeof(QueryFilterModelBinder));

        return null;
    }
}








