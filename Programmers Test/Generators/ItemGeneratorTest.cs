using System.Collections.Generic;
using NUnit.Framework;
using Programmers_Quest.Generators;
using Programmers_Quest.Models;

namespace Programmers_Test.Generators
{
    [TestFixture]
    public class ItemGeneratorTest
    {
        [Test]
        public void ShouldReturnOneItemWhenGenerateMethodWasCalledOnce()
        {
            var itemGenerator = new ItemGenerator();
            var resultingItem = itemGenerator.Generate();
            Assert.IsNotNull(resultingItem);
        }
        
        [Test]
        public void ShouldAlwaysReturnTwoDifferentItemNamesWhenGenerateMethodWasCalledTwice()
        {
            var itemGenerator = new ItemGenerator();
            var resultingItemA = itemGenerator.Generate();
            var resultingItemB = itemGenerator.Generate();
            Assert.AreNotEqual(resultingItemA.Name, resultingItemB.Name);
        }
        
        [Test]
        public void ShouldAlwaysReturnTwoDifferentItemIdsWhenGenerateMethodWasCalledTwice()
        {
            var itemGenerator = new ItemGenerator();
            var resultingItemA = itemGenerator.Generate();
            var resultingItemB = itemGenerator.Generate();
            Assert.AreNotEqual(resultingItemA.Id, resultingItemB.Id);
        }
        
        [Test]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(15)]
        [TestCase(20)]
        [TestCase(23)]
        public void ShouldReturnSameAmountOfItemsWhenGenerateMethodWasCalledNotMoreTimesThanItemsInList(int itemAmount)
        {
            var itemGenerator = new ItemGenerator();
            var items = new List<Item>();
            for (var i = 0; i < itemAmount; i++)
            {
                var item = itemGenerator.Generate();
                if (item != null)
                {
                    items.Add(item);
                }
            }
            Assert.AreEqual(itemAmount, items.Count);
        }
        
        [Test]
        [TestCase(24)]
        [TestCase(50)]
        public void ShouldReturnNotSameAmountOfItemsWhenGenerateMethodWasCalledMoreTimesThanItemsInList(int itemAmount)
        {
            var itemGenerator = new ItemGenerator();
            var items = new List<Item>();
            for (var i = 0; i < itemAmount; i++)
            {
                var item = itemGenerator.Generate();
                if (item != null)
                {
                    items.Add(item);
                }
            }
            Assert.AreNotEqual(itemAmount, items.Count);
        }
    }
}