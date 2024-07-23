using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
	public class Node
	{
		public User data { get; set; }
		public Node address { get; set; }

		public Node(User Data)
		{
			this.data = Data;
			this.address = null;
		}
	}
}
