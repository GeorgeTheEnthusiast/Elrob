using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Converters
{
    public interface IPermissionConverter
    {
        List<Permission> Convert(List<Domain.Permission> input);

        List<Domain.Permission> Convert(List<Permission> input);
    }
}
