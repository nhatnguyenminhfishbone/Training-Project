using System.Collections.Generic;
using TrainingProject.Core.Models;
using TrainingProject.Core.Repositories;

namespace TrainingProject.Core.Services
{
    public interface IInformationService
    {
        Information Add(Information information);
        Information Update(Information information);
        void Delete(int id);
        IList<Models.Information> Get();
        IList<Models.Information> Search(string searchText);
        Information Get(int id);
    }

    internal class InformationService : IInformationService
    {
        IInformationRepository InformationRepository { get; }
        public InformationService(IInformationRepository informationRepository)
        {
            InformationRepository = informationRepository;
        }
        public Information Add(Information information)
        {
            return InformationRepository.Add(information);
        }

        public void Delete(int id)
        {
            InformationRepository.Delete(id);
        }

        public IList<Information> Get()
        {
            return InformationRepository.Get();
        }
        public IList<Information> Search(string searchText)
        {
            return InformationRepository.Search(searchText);
        }

        public Information Get(int id)
        {
            return InformationRepository.Get(id);
        }

        public Information Update(Information information)
        {
            return InformationRepository.Update(information);
        }
    }
}
