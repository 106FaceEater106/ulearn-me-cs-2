using System;

namespace Inheritance.DataStructure
{
    class Category : IComparable
    {
        public string Product { get; set; }
        public MessageType Type { get; set; }
        public MessageTopic Topic { get; set; }

        public Category(string product, MessageType type, MessageTopic topic)
        {
            Product = product ?? "";
            Type = type;
            Topic = topic;
        }

        public int CompareTo(object toCompare)
        {
            if (!(toCompare is Category)) return -1;
            Category c = (Category)toCompare;
            int result = Product.CompareTo(c.Product);
            if (result == 0) result = Type.CompareTo(c.Type);
            if (result == 0) result = Topic.CompareTo(c.Topic);
            return result;
        }

        public override int GetHashCode()
        {
            int code = 0;
            foreach (var item in Product.ToCharArray())
                code += item * 81;
            code += (int)Type * 14;
            code += (int)Topic * 456;
            return code;
        }

        public override string ToString() => $"{Product}.{Type}.{Topic}";
        public override bool Equals(object toCompare) => CompareTo(toCompare) == 0;

        public static bool operator >=(Category c1, Category c2) => c1.CompareTo(c2) >= 0;
        public static bool operator <=(Category c1, Category c2) => c1.CompareTo(c2) <= 0;
        public static bool operator <(Category c1, Category c2) => c1.CompareTo(c2) < 0;
        public static bool operator >(Category c1, Category c2) => c1.CompareTo(c2) > 0;
    }
}
