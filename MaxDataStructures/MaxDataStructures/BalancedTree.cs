using System;

namespace MaxDataStructures
{
    public class BalancedTree
    {

        //TODO: I implemented the balance and height via a recursive check, but this adds alot of unnecessary overhead. MUCH BETTER would be to update the height attributes on insertion, rotation, and removal, then simply calculate the balance based on the heights of the children.
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
        public BalancedTree()
        {

        }
        public BalancedTree(IComparable Value)
        {
            Root = new BalancedTreeNode(Value);
        }
        public void Insert(IComparable Value)
        {
            if (Root == null)
            {
                Root = new BalancedTreeNode(Value);
                return;
            }
            Root.Insert(Value);
            CheckAndBalance();
        }
        public string PreOrder()
        {
            return Root.PreOrderPrint();
        }
        public void Remove(IComparable value)
        {
            if (value.Equals(Root.Value))
            {
                if (Root.IsLeaf())
                {
                    Root = null;
                }
                else if (Root.Left == null && Root.Right != null)
                {
                    Root = Root.Right;
                }
                else if (Root.Left != null && Root.Right == null)
                {
                    Root = Root.Left;
                }
                else
                {
                    if (Root.Left.Right != null)
                    {
                        IComparable temp = Root.Left.Right.Value;
                        Root.Left.Remove(temp, Root);
                        Root.Value = temp;
                    }
                    else
                    {
                        IComparable temp = Root.Left.Value;
                        Root.Value = temp;
                        Root.Left.Remove(temp, Root);
                    }
                }
            }
            else if (value.CompareTo(Root.Value) > 0)
            {
                Root.Right.Remove(value, Root);
            }
            else
            {
                Root.Left.Remove(value, Root);
            }
            CheckAndBalance();
        }
        private void CheckAndBalance()
        {
            if (Root.Balance > 1)
            {
                if (Root.Left.Balance >= 0)
                {
                    Root = Root.RightRotate();
                }
                else
                {
                    Root.Left = Root.Left.LeftRotate();
                    Root = Root.RightRotate();
                }
            }
            else if (Root.Balance < -1)
            {
                if (Root.Right.Balance <= 0)
                {
                    Root = Root.LeftRotate();
                }
                else
                {
                    Root.Right = Root.Right.RightRotate();
                    Root = Root.LeftRotate();
                }
            }
        }
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
                else if (Right != null && Left == null)
                {
                    return -1 - Right.Height;
                }
                else if (Left != null && Right == null)
                {
                    return Left.Height + 1;
                }
                else
                {
                    return 0;
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
            CheckAndBalance();
        }
        private void CheckAndBalance()
        {
            if (Left != null)
            {
                if (Left.Balance > 1)
                {
                    //left node violates balance property
                    if (Left.Left.Balance >= 0)
                    {
                        //left left
                        Left = Left.RightRotate();
                    }
                    else
                    {
                        //left-right case
                        Left.Left = Left.Left.LeftRotate();
                        Left = Left.RightRotate();
                    }
                    return;
                }
                else if (Left.Balance < -1)
                {
                    //left node violates balance property
                    if (Left.Right.Balance <= 0)
                    {
                        //right-right
                        Left = Left.LeftRotate();
                    }
                    else
                    {
                        //right-left case
                        Left.Right = Left.Right.RightRotate();
                        Left = Left.LeftRotate();
                    }
                    return;
                }
            }
            if (Right != null)
            {
                if (Right.Balance > 1)
                {
                    //right node violates balance property
                    if (Right.Left.Balance >= 0)
                    {
                        //left-left
                        Right = Right.RightRotate();
                    }
                    else
                    {
                        //left-right case
                        Right.Left = Right.Left.LeftRotate();
                        Right = Right.RightRotate();
                    }
                }
                else if (Right.Balance < -1)
                {
                    if (Right.Right.Balance <= 0)
                    {
                        //right-right
                        Right = Right.LeftRotate();
                    }
                    else
                    {
                        //right-left
                        Right.Right = Right.Right.RightRotate();
                        Right = Right.LeftRotate();
                    }
                }
            }
        }
        public BalancedTreeNode RightRotate()
        {
            BalancedTreeNode newRoot = Left;
            Left = Left.Right;
            newRoot.Right = this;
            return newRoot;
        }
        public BalancedTreeNode LeftRotate()
        {
            BalancedTreeNode newRoot = Right;
            Right = Right.Left;
            newRoot.Left = this;
            return newRoot;
        }
        public string PreOrderPrint()
        {
            string str = "";
            str += Value;
            if (Left != null)
            {
                str += Left.PreOrderPrint();
            }
            if (Right != null)
            {
                str += Right.PreOrderPrint();
            }
            return str;
        }
        public void Remove(IComparable val, BalancedTreeNode Previous)
        {
            bool wentLeft = val.CompareTo(Previous.Value) <= 0;
            if (Value.Equals(val))
            {
                if (IsLeaf())
                {
                    if (wentLeft)
                    {
                        Previous.Left = null;
                    }
                    else
                    {
                        Previous.Right = null;
                    }
                }
                else if (Left != null && Right == null)
                {
                    if (wentLeft)
                    {
                        Previous.Left = Left;
                    }
                    else
                    {
                        Previous.Right = Left;
                    }
                }
                else if (Right != null && Left == null)
                {
                    if (wentLeft)
                    {
                        Previous.Left = Right;
                    }
                    else
                    {
                        Previous.Right = Right;
                    }
                }
                else
                {
                    if (Left.Right != null)
                    {
                        IComparable temp = Left.Right.Value;
                        Left.Remove(temp, this);
                        Value = temp;
                    }
                    else
                    {
                        IComparable temp = Left.Value;
                        Left.Remove(temp, this);
                        Value = temp;
                    }
                }
            }
            else if (val.CompareTo(Value) > 0)
            {
                Right.Remove(val, this);
            }
            else
            {
                Left.Remove(val, this);
            }
            CheckAndBalance();
        }
        public bool IsLeaf()
        {
            if (Left == null && Right == null)
            {
                return true;
            }
            return false;
        }
    }
}
