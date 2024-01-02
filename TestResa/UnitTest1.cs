using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ReservationService.Controllers;
using ReservationService.Datas.Entities;
using ReservationService.Datas.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestResa
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestGetExistingUser()
        {
            var InMemoryDb = new List<Utilisateur>
            {
                new Utilisateur()
                {
                    Id = 1,
                    Nom = "Gagak",
                    Prenom = "gougk",
                    Email = "Agagag.gougk@Email.com"

                },
                new Utilisateur()
                {
                    Id = 2,
                    Nom = "test",
                    Prenom = "testUser",
                    Email = "Agagag.gougk@Email.com"
                }
            };
            var repo = new Mock<IUtilisateurRepository>();

            // Lorsque le mock repo.getUserById reçois un int, il retourne pour cet int un user de la bd en mémoire.
            repo.Setup(x => x.GetUserById(It.IsAny<int>()))
               .ReturnsAsync((int i) => InMemoryDb.Single(user => user.Id == i));

            var userDb = repo.Object;

            var existingUser = await userDb.GetUserById(1);
            Assert.IsNotNull(existingUser);
            Assert.AreEqual(1, existingUser.Id);

            try
            {
                userDb.GetUserById(17);
                Assert.Fail();
            }
            catch (Exception e)
            {

            }
        }
        [TestMethod]
        public void TestNonExistingUser()
        {
            var user = new Utilisateur
            {
                Id = -1,
                Nom = "Gagak",
                Prenom = "gougk",
                Email = "Agagag.gougk@Email.com",

            };

            var mockrepo = new Mock<IUtilisateurRepository>();
            Assert.AreNotEqual(mockrepo.Setup(repo => repo.GetUserById(-1)), user);

        }

    }
}