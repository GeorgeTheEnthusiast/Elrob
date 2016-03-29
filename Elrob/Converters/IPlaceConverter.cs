using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Converters
{
    public interface IPlaceConverter
    {
        List<Place> Convert(List<Domain.Place> input);

        Domain.Place Convert(Place place);
    }
}
