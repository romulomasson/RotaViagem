using AutoMapper;
using RotaViagem.Domain.Entities;
using RotaViagem.Domain.Interfaces;
using RotaViagem.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RotaViagem.Domain.Interfaces;
using RotaViagem.Domain.Entities;

namespace RotaViagem.Api.AutoMapper
{
    public class PagedListConverter<TEntity, TViewModel> //: ITypeConverter<PagedList<TEntity>, PagedList<TViewModel>>
    {        
        public PagedList<TViewModel> Convert(IPagedList<TEntity> source, IMapper _mapper)
        {
            var vm = source.Data.Select(item => _mapper.Map<TViewModel>(item)).ToList();
            return new PagedList<TViewModel>(vm, source.Total);
        }
    }
}








