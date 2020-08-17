using System;

namespace MaxDataStructures
{
    public class BalancedTree
    {
        private BalancedTreeNode Root { get; set; }
        public int Balance
        {
            get
            {
                return Root.Balance;
            }
        }
        public int Height
        {
            get
            {
                return Root.Height;
            }

        }
        public BalancedTree(IComparable Value)
        {
            Root = new BalancedTreeNode(Value);
        }
        public void Insert(IComparable Value)
        {
            Root.Insert(Value);
        }

        public class BalancedTreeNode
        {
            public IComparable Value { get; set; }
            public BalancedTreeNode Left { get; set; }
            public BalancedTreeNode Right { get; set; }
            public int Height
            {
                get
                {
                    if (Left == null && Right == null)
                    {
                        return 0;
                    }
                    else if (Left == null && Right != null)
                    {
                        return 1 + Right.Height;
                    }
                    else if (Left != null && Right == null)
                    {
                        return 1 + Left.Height;
                    }
                    else
                    {
                        return 1 + Math.Max(Left.Height, Right.Height);
                    }
                }
            }
            public int Balance
            {
                get
                {
                    if (Left != null && Right != null)
                    {
                        return Left.Height - Right.Height;
                    }
                    else if (Left == null && Right == null)
                    {
                        return 0;
                    }
                    else if (Right != null && Left == null)
                    {
                        return -Right.Height;
                    }
                    else if (Left != null && Right == null)
                    {
                        return Left.Height;
                    }
                    else
                    {
                        return Left.Height - Right.Height;
                    }
                }
            }
            public BalancedTreeNode(IComparable Value)
            {
                this.Value = Value;
            }
            public void Insert(IComparable newValue)
            {

                if (newValue.CompareTo(Value) <= 0)
                {
                    if (Left == null)
                    {
                        Left = new BalancedTreeNode(newValue);
                    }
                    else
                    {
                        Left.Insert(newValue);
                    }
                }
                else
                {
                    if (Right == null)
                    {
                        Right = new BalancedTreeNode(newValue);
                    }
                    else
                    {
                        Right.Insert(newValue);
                    }
                }
            }

        }
    }
}
