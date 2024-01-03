using Itlaflix.Core.Application.ViewModel.gender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itlaflix.Core.Application.Interfaces.Services
{
    public interface IGenderService : IGenericService<SaveGenderViewModel, GenderViewModel>
    {

    }
}
