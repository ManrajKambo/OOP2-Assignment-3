using System;
using System.Runtime.Serialization;

namespace Assignment3.Utility
{
    [DataContract]
    public class Node
    {
        [DataMember]
        public User data { get; set; }

        [DataMember]
        public Node address { get; set; }

        public Node(User Data)
        {
            this.data = Data;
            this.address = null;
        }
    }
}