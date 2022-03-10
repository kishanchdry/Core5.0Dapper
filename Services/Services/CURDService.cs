using AutoMapper;
using Data.IRepository.IGeneric;
using Services.Generic;
using Services.IServices;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CURDService : GenericService<CURDModel, CURDModel>, ICURDService
    {
        public CURDService(IGenericDataRepository<CURDModel> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
