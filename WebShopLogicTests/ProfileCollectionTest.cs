using Data.Models;
using DataInterfaces.Repositories;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace WebShopLogicTests
{
    [TestClass]
    public class ProfileCollectionTest
    {
        private readonly ProfileCollection _sut; //Subject Under Test
        private readonly Mock<IProfileRepository> _profileRepoMock = new Mock<IProfileRepository>();

        public ProfileCollectionTest()
        {
            _sut = new ProfileCollection(_profileRepoMock.Object);
        }

        [TestMethod]
        public void GetProfileById_ProfileExists_ReturnProfile()
        {
            //Arrange
            var profileId = 5;
            var profileEmail = "henkdewit@test.nl";
            var profileFirstName = "Henk";
            var profileInsertion = "de";
            var profileLastName = "Wit";
            var profileZipCode = "1234AB";
            var profileHouseNumber = 1;
            var profileHouseNumberAddition = "B";
            var profilePassword = "wachtwoord123";
            var profileTypeId = 3;

            var profileDto = new ProfileDto
            {
                ID = profileId,
                Email = profileEmail,
                FirstName = profileFirstName,
                Insertion = profileInsertion,
                LastName = profileLastName,
                ZipCode = profileZipCode,
                HouseNumber = profileHouseNumber,
                HouseNumberAddition = profileHouseNumberAddition,
                Password = profilePassword,
                ProfileTypeID =profileTypeId,
            };

            _profileRepoMock.Setup(x => x.GetProfileById(profileId)).Returns(profileDto);

            //Act
            var profile = _sut.GetProfileById(profileId);

            //Assert
            Assert.AreEqual(profileId, profile.ID);
            Assert.AreEqual(profileEmail, profile.Email);
            Assert.AreEqual(profileFirstName, profile.FirstName);
            Assert.AreEqual(profileInsertion, profile.Insertion);
            Assert.AreEqual(profileLastName, profile.LastName);
            Assert.AreEqual(profileZipCode, profile.ZipCode);
            Assert.AreEqual(profileHouseNumber, profile.HouseNumber);
            Assert.AreEqual(profileHouseNumberAddition, profile.HouseNumberAddition);
            Assert.AreEqual(profilePassword, profile.Password);
            Assert.AreEqual(profileTypeId, profile.ProfileTypeID);
        }

        [TestMethod]
        public void GetProfileById_ProfileDoesNotExist_ReturnNull()
        {
            //Arrange
            _profileRepoMock.Setup(x => x.GetProfileById(0)).Returns(() => null);

            //Act
            var profile = _sut.GetProfileById(0);

            //Assert
            Assert.IsNull(profile);
        }
    }
}
