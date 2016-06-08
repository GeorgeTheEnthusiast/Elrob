using GroupDto = Elrob.Webservice.Dto.Group;
using GroupDomain = Elrob.Common.Domain.Group;
using PermissionDto = Elrob.Webservice.Dto.Permission;
using PermissionDomain = Elrob.Common.Domain.Permission;

namespace Elrob.Webservice.Converters.Implementations
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;

    using Elrob.Webservice.Converters.Interfaces;

    public class GroupConverter : IGroupConverter
    {
        private IMapper _mapper;

        public GroupConverter()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<GroupDomain, GroupDto>();
                x.CreateMap<PermissionDomain, PermissionDto>();

                x.CreateMap<GroupDto, GroupDomain>();
                x.CreateMap<PermissionDto, PermissionDomain>();
            });

            this._mapper = mapperConfiguration.CreateMapper();
        }

        public List<GroupDto> Convert(List<GroupDomain> input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            return this._mapper.Map<List<GroupDto>>(input);
        }

        public GroupDomain Convert(GroupDto group)
        {
            if (@group == null)
            {
                throw new ArgumentNullException(nameof(@group));
            }

            return this._mapper.Map<GroupDomain>(group);
        }
    }
}
