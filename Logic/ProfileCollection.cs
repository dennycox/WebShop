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
    public class ProfileCollection : IProfileCollection
    {
        private IProfileRepository _profileRepository;

        public ProfileCollection(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public IProfile GetProfileById(int id)
        {
            var profile = _profileRepository.GetProfileById(id);

            if(profile == null)
            {
                return null;
            }

            return ProfileDtoToProfile(_profileRepository.GetProfileById(id));
        }

        private IProfile ProfileDtoToProfile(IProfileDto profileDto)
        {
            return new Profile()
            {
                ID = profileDto.ID,
                Email = profileDto.Email,
                FirstName = profileDto.FirstName,
                Insertion = profileDto.Insertion,
                LastName = profileDto.LastName,
                ZipCode = profileDto.ZipCode,
                HouseNumber = profileDto.HouseNumber,
                HouseNumberAddition = profileDto.HouseNumberAddition,
                Password = profileDto.Password,
                ProfileTypeID = profileDto.ProfileTypeID,
            };
        }
    }
}
