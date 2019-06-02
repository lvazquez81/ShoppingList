using NUnit.Framework;
using ShippingListLib;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    [Category("Basic")]
    public class SimpleTests
    {
        [Test]
        public void OnAddItem_returnsIdValue()
        {
            IShoppingList list = new VolatileShoppingList();
            int id = list.AddItem("foo");

            Assert.IsTrue(id > 0);
        }

        [Test]
        public void OnAddItem_isIncludedInList()
        {
            IShoppingList list = new VolatileShoppingList();
            list.AddItem("foo");

            IList<string> items = list.GetList();

            CollectionAssert.Contains(items, "foo");
        }

        [Test]
        public void OnRemoveItem_returnsTrue()
        {
            IShoppingList list = new VolatileShoppingList();
            int id = list.AddItem("foo");

            bool result = list.RemoveItem(id);

            Assert.IsTrue(result);
        }

        [Test]
        public void OnRemoveItem_notIncludedInList()
        {
            IShoppingList list = new VolatileShoppingList();
            int id = list.AddItem("foo");

            list.RemoveItem(id);

            IList<string> items = list.GetList();

            CollectionAssert.DoesNotContain(items, "foo");
        }
    }
}