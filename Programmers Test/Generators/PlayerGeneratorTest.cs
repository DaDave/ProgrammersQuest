using NUnit.Framework;
using Programmers_Quest.Generators;
using Programmers_Quest.Models;

namespace Programmers_Test.Generators
{
    [TestFixture]
    public class PlayerGeneratorTest
    {
        [Test]
        public void ShouldReturnGivenPlayerNameWhenGenerateMethodWasCalledWithGivenName()
        {
            var playerName = "Test";
            var resultingPlayer = PlayerGenerator.Generate(playerName, DifficultyEnum.Easy);
            Assert.AreEqual(playerName, resultingPlayer.Name);
        }
        
        [Test]
        public void ShouldReturnPlayerWithHpHundredWhenGenerateMethodWasCalledWithDifficultyEasy()
        {
            var resultingPlayer = PlayerGenerator.Generate("Test", DifficultyEnum.Easy);
            Assert.AreEqual(100, resultingPlayer.Hp);
        }

        [Test] public void ShouldReturnPlayerWithHpFiftyWhenGenerateMethodWasCalledWithDifficultyMedium()
        {
            var resultingPlayer = PlayerGenerator.Generate("Test", DifficultyEnum.Medium);
            Assert.AreEqual(50, resultingPlayer.Hp);
        }
        
        [Test]
        public void ShouldReturnPlayerWithHpTwentyfiveWhenGenerateMethodWasCalledWithDifficultyHard()
        {
            var resultingPlayer = PlayerGenerator.Generate("Test", DifficultyEnum.Hard);
            Assert.AreEqual(25, resultingPlayer.Hp);
        }
        
        [Test]
        public void ShouldReturnPlayerWithHpOneWhenGenerateMethodWasCalledWithDifficultyImpossible()
        {
            var resultingPlayer = PlayerGenerator.Generate("Test", DifficultyEnum.Medium);
            Assert.AreEqual(1, resultingPlayer.Hp);
        }
        
        [Test]
        public void ShouldReturnPlayerWithAttackTwelveWhenGenerateMethodWasCalledWithDifficultyEasy()
        {
            var resultingPlayer = PlayerGenerator.Generate("Test", DifficultyEnum.Easy);
            Assert.AreEqual(12, resultingPlayer.Attack);
        }

        [Test] public void ShouldReturnPlayerWithAttackSixWhenGenerateMethodWasCalledWithDifficultyMedium()
        {
            var resultingPlayer = PlayerGenerator.Generate("Test", DifficultyEnum.Medium);
            Assert.AreEqual(6, resultingPlayer.Attack);
        }
        
        [Test]
        public void ShouldReturnPlayerWithAttackThreeWhenGenerateMethodWasCalledWithDifficultyHard()
        {
            var resultingPlayer = PlayerGenerator.Generate("Test", DifficultyEnum.Hard);
            Assert.AreEqual(3, resultingPlayer.Attack);
        }
        
        [Test]
        public void ShouldReturnPlayerWithAttackOneWhenGenerateMethodWasCalledWithDifficultyImpossible()
        {
            var resultingPlayer = PlayerGenerator.Generate("Test", DifficultyEnum.Medium);
            Assert.AreEqual(1, resultingPlayer.Attack);
        }
        
        [Test]
        public void ShouldReturnPlayerWithDefenseTwelveWhenGenerateMethodWasCalledWithDifficultyEasy()
        {
            var resultingPlayer = PlayerGenerator.Generate("Test", DifficultyEnum.Easy);
            Assert.AreEqual(12, resultingPlayer.Defense);
        }

        [Test] public void ShouldReturnPlayerWithDefenseSixWhenGenerateMethodWasCalledWithDifficultyMedium()
        {
            var resultingPlayer = PlayerGenerator.Generate("Test", DifficultyEnum.Medium);
            Assert.AreEqual(6, resultingPlayer.Defense);
        }
        
        [Test]
        public void ShouldReturnPlayerWithDefenseThreeWhenGenerateMethodWasCalledWithDifficultyHard()
        {
            var resultingPlayer = PlayerGenerator.Generate("Test", DifficultyEnum.Hard);
            Assert.AreEqual(3, resultingPlayer.Defense);
        }
        
        [Test]
        public void ShouldReturnPlayerWithDefenseOneWhenGenerateMethodWasCalledWithDifficultyImpossible()
        {
            var resultingPlayer = PlayerGenerator.Generate("Test", DifficultyEnum.Medium);
            Assert.AreEqual(1, resultingPlayer.Defense);
        }
    }
}