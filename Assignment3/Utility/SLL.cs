using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
	public class SLL : ILinkedListADT
	{
		public Node head { get; set; }
		public Node tail { get; set; }
		public int count { get; set; }

		/// <summary>
		/// Checks if the list is empty.
		/// </summary>
		/// <returns>True if it is empty.</returns>
		public bool IsEmpty()
		{
			if (head == null)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		/// <summary>
		/// Clears the list.
		/// </summary>
		public void Clear()
		{
			head = null;
			tail = null;
			count = 0;
		}

		/// <summary>
		/// Adds to the end of the list.
		/// </summary>
		/// <param name="value">Value to append.</param>
		public void AddLast(User value)
		{
			Node newNode = new Node(value);
			if (head == null)
			{
				head = newNode;
			}
			else
			{
				Node current = head;
				while (current.address != null)
				{
					current = current.address;
				}
				current.address = newNode;
			}
			count++;
		}

		/// <summary>
		/// Prepends (adds to beginning) value to the list.
		/// </summary>
		/// <param name="value">Value to store inside element.</param>
		public void AddFirst(User value)
		{
			Node newNode = new Node(value);
			newNode.address = head;
			head = newNode;
			count++;
		}

		/// <summary>
		/// Adds a new element at a specific position.
		/// </summary>
		/// <param name="value">Value that element is to contain.</param>
		/// <param name="index">Index to add new element at.</param>
		/// <exception cref="IndexOutOfRangeException">Thrown if index is negative or past the size of the list.</exception>
		public void Add(User value, int index)
		{
			Node newNode = new Node(value);
			if (index < 0 || index >= count)
			{
				throw new IndexOutOfRangeException("Index out of the range");
			}
			else
			{
				Node current = head;
				for (int i = 0; i < index; i++)
				{
					current = current.address;
				}
				newNode.address = current.address;
				current.address = newNode;
				count++;
			}
		}

		/// <summary>
		/// Replaces the value  at index.
		/// </summary>
		/// <param name="value">Value to replace.</param>
		/// <param name="index">Index of element to replace.</param>
		/// <exception cref="IndexOutOfRangeException">Thrown if index is negative or larger than size - 1 of list.</exception>
		public void Replace(User value, int index)
		{
			Node newNode = new Node(value);
			if (index < 0 || index >= count)
			{
				throw new IndexOutOfRangeException("Index out of the range");
			}
			else
			{
				Node current = head;
				for (int i = 0; i < index + 1; i++)
				{
					current = current.address;
					if (i == index - 1) { current.address = newNode; }
					if (i == index + 1) { newNode.address = current.address; }
				}
			}
		}

		/// <summary>
		/// Gets the number of elements in the list.
		/// </summary>
		/// <returns>Size of list (0 meaning empty)</returns>
		public int Count()
		{
			int listCount = 0;
			for (int i = 1; i < count; i++)
			{
				listCount++;
			}
			return listCount;
		}

		/// <summary>
		/// Removes first element from list
		/// </summary>
		/// <exception cref="CannotRemoveException">Thrown if list is empty.</exception>
		public void RemoveFirst()
		{
            bool empty = IsEmpty();
            try
            {
				head = head.address;
			}
			catch
			{

			}
			if (empty == true)
			{ 
				throw new CannotRemoveException("Cannot remove the specified item as the list is empty"); 
			} 
			else
			{
				head = head.address;
				count--;
			}
		}

		/// <summary>
		/// Removes last element from list
		/// </summary>
		/// <exception cref="CannotRemoveException">Thrown if list is empty.</exception>
		public void RemoveLast()
		{
			bool empty = IsEmpty();
			if (empty == true)
			{
				throw new CannotRemoveException("Cannot remove the specified item as the list is empty");
			}
			else
			{
				Node current = head;
				Node previous = null;
				while (current.address != null)
				{
					previous = current;
					current = current.address;
				}
				previous.address = null;
				count--;
			}
		}

		/// <summary>
		/// Removes element at index from list, reducing the size.
		/// </summary>
		/// <param name="index">Index of element to remove.</param>
		/// <exception cref="IndexOutOfRangeException">Thrown if index is negative or larger than size - 1 of list.</exception>
		public void Remove(int index)
		{
			if (index < 0 || index >= count)
			{
				throw new IndexOutOfRangeException("Index out of the range");
			}
			else
			{
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
		}

		/// <summary>
		/// Gets the value at the specified index.
		/// </summary>
		/// <param name="index">Index of element to get.</param>
		/// <returns>Value of node at index</returns>
		/// <exception cref="IndexOutOfRangeException">Thrown if index is negative or larger than size - 1 of list.</exception>
		public User GetValue(int index)
		{
			if (index < 0 || index >= count)
			{
				throw new IndexOutOfRangeException("Index out of the range");
			}
			else
			{
				Node current = head;
				for (int i = 0; i < index; i++)
				{
					current = current.address;
				}
				return current.data;
			}
		}

		/// <summary>
		/// Gets the first index of element containing value.
		/// </summary>
		/// <param name="value">Value to find index of.</param>
		/// <returns>First of index of node with matching value or -1 if not found.</returns>
		public int IndexOf(User value)
		{
			int index = -1;
			Node current = head;
			for (int i = 0; i < count; i++)
			{
				if (current.data == value)
				{
					index = i;
					break;
				}
				current = current.address;
			}
			if (index == -1)
			{
				return -1;
			}
			else
			{
				return index;
			}
		}

		/// <summary>
		/// Go through nodes and check if one has value.
		/// </summary>
		/// <param name="value">Value to find index of.</param>
		/// <returns>True if element exists with value.</returns>
		public bool Contains(User value)
		{
			int index = -1;
			Node current = head;
			for (int i = 0; i < count; i++)
			{
				if (current.data == value)
				{
					index = i;
					break;
				}
				current = current.address;
			}
			if (index == -1)
			{
				return false;
			}
			else
			{
				return true;
			}
		}


	}
}
