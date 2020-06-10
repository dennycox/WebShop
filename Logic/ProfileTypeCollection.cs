using DataFactory;
using DataInterfaces;
using DataInterfaces.Models;
using DataInterfaces.Repositories;
using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class ProfileTypeCollection : IProfileTypeCollection
    {
        private IProfileTypeRepository _profileTypeRepository;

        public ProfileTypeCollection(IProfileTypeRepository profileTypeRepository)
        {
            _profileTypeRepository = profileTypeRepository;
        }

        public List<IProfileType> GetAllProfiletypes()
        {
            return _profileTypeRepository.GetAllProfileTypes().Select(p => ProfileTypeDtoToProfileType(p)).ToList();
        }

        public IProfileType GetProfileTypeById(int id)
        {
            return ProfileTypeDtoToProfileType(_profileTypeRepository.GetProfileTypeById(id));
        }

        private IProfileType ProfileTypeDtoToProfileType(IProfileTypeDto profileTypeDto)
        {
            return new ProfileType()
            {
                ProfileTypeID = profileTypeDto.ProfileTypeID,
                ProfileTypeName = profileTypeDto.ProfileTypeName,
            };
        }
    }
}
