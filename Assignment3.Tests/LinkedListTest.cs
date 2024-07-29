using Assignment3.Utility;
using NUnit.Framework;

namespace Assignment3.Tests
{
    public class LinkedListTest
    {
        private ILinkedListADT list;

        [SetUp]
        public void SetUp()
        {
            list = new SLL();
        }

        [Test]
        public void TestIsEmpty()
        {
            Assert.IsTrue(list.IsEmpty());
        }

        [Test]
        public void TestAddLast()
        {
            User user = new User(1, "Test User", "test@example.com", "password");
            list.AddLast(user);
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(user, list.GetValue(0));
        }

        [Test]
        public void TestAddFirst()
        {
            User user = new User(1, "Test User", "test@example.com", "password");
            list.AddFirst(user);
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(user, list.GetValue(0));
        }

        [Test]
        public void TestAddAtIndex()
        {
            User user1 = new User(1, "Test User 1", "test1@example.com", "password1");
            User user2 = new User(2, "Test User 2", "test2@example.com", "password2");
            User user3 = new User(3, "Test User 3", "test3@example.com", "password3");
            list.AddLast(user1);
            list.AddLast(user3);
            list.Add(user2, 1);
            Assert.AreEqual(3, list.Count());
            Assert.AreEqual(user1, list.GetValue(0));
            Assert.AreEqual(user2, list.GetValue(1));
            Assert.AreEqual(user3, list.GetValue(2));
        }

        [Test]
        public void TestReplace()
        {
            User user1 = new User(1, "Test User 1", "test1@example.com", "password1");
            User user2 = new User(2, "Test User 2", "test2@example.com", "password2");
            list.AddLast(user1);
            list.Replace(user2, 0);
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(user2, list.GetValue(0));
        }

        [Test]
        public void TestRemoveFirst()
        {
            User user1 = new User(1, "Test User 1", "test1@example.com", "password1");
            User user2 = new User(2, "Test User 2", "test2@example.com", "password2");
            list.AddLast(user1);
            list.AddLast(user2);
            list.RemoveFirst();
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(user2, list.GetValue(0));
        }

        [Test]
        public void TestRemoveLast()
        {
            User user1 = new User(1, "Test User 1", "test1@example.com", "password1");
            User user2 = new User(2, "Test User 2", "test2@example.com", "password2");
            list.AddLast(user1);
            list.AddLast(user2);
            list.RemoveLast();
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(user1, list.GetValue(0));
        }

        [Test]
        public void TestRemoveAtIndex()
        {
            User user1 = new User(1, "Test User 1", "test1@example.com", "password1");
            User user2 = new User(2, "Test User 2", "test2@example.com", "password2");
            User user3 = new User(3, "Test User 3", "test3@example.com", "password3");
            list.AddLast(user1);
            list.AddLast(user2);
            list.AddLast(user3);
            list.Remove(1);
            Assert.AreEqual(2, list.Count());
            Assert.AreEqual(user1, list.GetValue(0));
            Assert.AreEqual(user3, list.GetValue(1));
        }

        [Test]
        public void TestGetValue()
        {
            User user = new User(1, "Test User", "test@example.com", "password");
            list.AddLast(user);
            Assert.AreEqual(user, list.GetValue(0));
        }

        [Test]
        public void TestIndexOf()
        {
            User user = new User(1, "Test User", "test@example.com", "password");
            list.AddLast(user);
            Assert.AreEqual(0, list.IndexOf(user));
        }

        [Test]
        public void TestContains()
        {
            User user = new User(1, "Test User", "test@example.com", "password");
            list.AddLast(user);
            Assert.IsTrue(list.Contains(user));
        }

        [Test]
        public void TestClear()
        {
            User user = new User(1, "Test User", "test@example.com", "password");
            list.AddLast(user);
            list.Clear();
            Assert.IsTrue(list.IsEmpty());
        }

        [Test]
        public void TestCount()
        {
            User user1 = new User(1, "Test User 1", "test1@example.com", "password1");
            User user2 = new User(2, "Test User 2", "test2@example.com", "password2");
            list.AddLast(user1);
            list.AddLast(user2);
            Assert.AreEqual(2, list.Count());
        }
    }
}