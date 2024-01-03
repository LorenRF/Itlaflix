﻿using Itlaflix.Core.Application.Interfaces.Repositories;
using Itlaflix.Core.Application.ViewModel;
using Itlaflix.Core.Domain.Entities;
using Itlaflix.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;


namespace Itlaflix.Infrastructure.Persistence.Repositories
{
    public class DirectorRepository : GenericRepository<Director>, IDirectorRepository
    {
        private readonly ApplicationContext dbcontext;
        public DirectorRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            dbcontext = applicationContext;
        }
    }
}
