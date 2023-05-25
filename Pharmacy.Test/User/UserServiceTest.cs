using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Pharmacy.DataAccess.Abstract;
using Pharmacy.DataAccess.Concrete.AdoNet;

namespace Pharmacy.Test.User
{
    [TestClass()]
    public class UserServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task CreateAsync()
        {
            IUserRepository userRepository = new AdoNetUserRepository();
           var result = await   userRepository.CreateAsync(new Core.Entities.Users.User
            {
                TCKN = "12345678901",
                Email = "example@gmail.com",
                Name = "test",
                Surname = "test",
            });
        }
    }
}