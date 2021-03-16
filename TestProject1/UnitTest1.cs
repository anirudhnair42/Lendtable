using System;
using FinalSolution;
using Moq;
using Xunit;

//One automated test that verifies some aspect of the program works correctly.
//Aspect that is checked: If the program throws an exception if an invalid Integer iD is given to it.
namespace TestProject1
{
    public class UnitTest1
    {
        public readonly Mock<IDatabaseAccess> _dataBaseRepoMock;

        
        public UnitTest1()
        {
            _dataBaseRepoMock = new Mock<IDatabaseAccess>(MockBehavior.Strict);
        }
        
        [Fact]
        public void ShouldTestWhenInvalidIdIsSubmitted()
        {
            int id = 3;
            var identity = new Models.Identity();
            
            _dataBaseRepoMock.Setup(u => u.GetUser(id))
                .Returns((Func<Models.Identity>) null);

            DBManager db = new DBManager(_dataBaseRepoMock.Object);
            
            Assert.Throws<Exception>(() => db.GetUser(id));
            
        }
    }
}