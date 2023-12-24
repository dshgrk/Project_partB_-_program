using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace partB
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InitializeProcedures_ShouldCreateProceduresList()
        {
            // Arrange
            List<Procedure> procedures;

            // Act
            Program.InitializeProcedures(out procedures);

            // Assert
            Assert.IsNotNull(procedures);
            Assert.AreEqual(9, procedures.Count); // Змініть це значення, якщо кількість процедур може змінитися
        }

        [TestMethod]
        public void InitializeSpecialists_ShouldCreateSpecialistsList()
        {
            // Arrange
            List<Procedure> procedures;
            List<BeautySpecialist> specialists;

            // Act
            Program.InitializeProcedures(out procedures);
            Program.InitializeSpecialists(procedures, out specialists);

            // Assert
            Assert.IsNotNull(specialists);
            Assert.AreEqual(9, specialists.Count); // Змініть це значення, якщо кількість майстрів може змінитися
        }

        // Додайте додаткові тести для інших частин вашого коду

        [TestMethod]
        public void MethodForClient_AddClient_ShouldAddClientToList()
        {
            // Arrange
            List<Client> clients = new List<Client>();
            Client client = new Client("Ім'я", 25);

            // Act
            Program.MethodForClient(1, ref client, ref clients);

            // Assert
            Assert.IsNotNull(clients);
            Assert.AreEqual(1, clients.Count);
        }



        //[TestMethod]
        //public void WrongAddClientName()
        //{
        //    //arrange
        //    string name = "/";
        //    int age = 18;

        //    //act
        //    Client client = new Client(name, age);

        //    //assert
        //    Assert.IsNull(client);
        //}

        //[TestMethod]
        //public void WrongAddClientAge()
        //{
        //    //arrange
        //    string name = "Даша";
        //    int age = -1;

        //    //act
        //    Client client = new Client(name, age);

        //    //assert
        //    Assert.IsNull(client);
        //}


    }
}