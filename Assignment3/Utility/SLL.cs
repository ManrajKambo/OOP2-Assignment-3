using System;
using System.Runtime.Serialization;

namespace Assignment3.Utility
{
    [DataContract]
    public class SLL : ILinkedListADT
    {
        [DataMember]
        public Node head { get; set; }

        [DataMember]
        public Node tail { get; set; }

        [DataMember]
        public int count { get; set; }

        public bool IsEmpty()
        {
            return head == null;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void AddLast(User value)
        {
            Node newNode = new Node(value);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.address = newNode;
                tail = newNode;
            }
            count++;
        }

        public void AddFirst(User value)
        {
            Node newNode = new Node(value);
            newNode.address = head;
            head = newNode;
            if (count == 0)
            {
                tail = head;
            }
            count++;
        }

        public void Add(User value, int index)
        {
            if (index < 0 || index > count)
            {
                throw new IndexOutOfRangeException("Index out of the range");
            }

            if (index == 0)
            {
                AddFirst(value);
                return;
            }

            if (index == count)
            {
                AddLast(value);
                return;
            }

            Node newNode = new Node(value);
            Node current = head;
            for (int i = 1; i < index; i++)
            {
                current = current.address;
            }
            newNode.address = current.address;
            current.address = newNode;
            count++;
        }

        public void Replace(User value, int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index out of the range");
            }

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.address;
            }
            current.data = value;
        }

        public int Count()
        {
            return count;
        }

        public void RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new CannotRemoveException("Cannot remove the specified item as the list is empty");
            }

            head = head.address;
            count--;

            if (count == 0)
            {
                tail = null;
            }
        }

        public void RemoveLast()
        {
            if (IsEmpty())
            {
                throw new CannotRemoveException("Cannot remove the specified item as the list is empty");
            }

            if (count == 1)
            {
                head = null;
                tail = null;
            }
            else
            {
                Node current = head;
                while (current.address != tail)
                {
                    current = current.address;
                }
                current.address = null;
                tail = current;
            }
            count--;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index out of the range");
            }

            if (index == 0)
            {
                RemoveFirst();
                return;
            }

            if (index == count - 1)
            {
                RemoveLast();
                return;
            }

            Node current = head;
            Node previous = null;
            for (int i = 0; i < index; i++)
            {
                previous = current;
                current = current.address;
            }
            previous.address = current.address;
            count--;
        }

        public User GetValue(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index out of the range");
            }

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.address;
            }
            return current.data;
        }

        public int IndexOf(User value)
        {
            Node current = head;
            for (int i = 0; i < count; i++)
            {
                if (current.data.Equals(value))
                {
                    return i;
                }
                current = current.address;
            }
            return -1;
        }

        public bool Contains(User value)
        {
            return IndexOf(value) != -1;
        }
    }
}