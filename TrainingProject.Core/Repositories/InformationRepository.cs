using System;
using System.Collections.Generic;
using System.Linq;
using TrainingProject.Core.Entities;

namespace TrainingProject.Core.Repositories
{
    internal interface IInformationRepository
    {
        Models.Information Add(Models.Information information);
        Models.Information Update(Models.Information information);
        void Delete(int id);
        IList<Models.Information> Get();
        IList<Models.Information> Search(string searchText);
        Models.Information Get(int id);
    }

    internal class InformationRepository : IInformationRepository
    {
        private TrainingProjectDbContext DbContext { get; }
        public InformationRepository(TrainingProjectDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public Models.Information Add(Models.Information information)
        {
            var entity = DbContext.Information.Add(new Entities.Information
            {
                Title = information.Title,
                Description = information.Description
            }).Entity;
            DbContext.SaveChanges();

            return MapToModel(entity);
        }

        public Models.Information Update(Models.Information information)
        {
            var entity = DbContext.Information.Find(information.Id);
            PopulateToEntity(information, entity);
            DbContext.SaveChanges();

            return MapToModel(entity);
        }

        public void Delete(int id)
        {
            var entity = DbContext.Information.Find(id);
            DbContext.Information.Remove(entity);
            DbContext.SaveChanges();
        }

        public IList<Models.Information> Get()
        {
            var entities = DbContext.Information.ToList();
            return entities.Select(MapToModel).ToList();
        }

        public Models.Information Get(int id)
        {
            var entity = DbContext.Information.Find(id);
            return MapToModel(entity);
        }

        public Models.Information MapToModel(Entities.Information entity)
        {
            return new Models.Information
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description
            };
        }

        public void PopulateToEntity(Models.Information model, Entities.Information entity)
        {
            entity.Title = model.Title;
            entity.Description = model.Description;
        }

        public IList<Models.Information> Search(string searchText)
        {
            var entities = DbContext.Information
                .Where(info => info.Title.Contains(searchText) || info.Description.Contains(searchText))
                .ToList();

            return entities.Select(MapToModel).ToList();
        }
    }
}
