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
            if (Root.Balance > 1)
            {
                if (Root.Left.Balance > 0)
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
                if (Root.Right.Balance < 0)
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
        public string PreOrder()
        {
            return Root.PreOrderPrint();
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
            if (Left.Balance > 1)
            {
                //left node violates balance property
                if (Left.Left.Balance > 0)
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
            }
            else if (Left.Balance < -1)
            {
                //left node violates balance property
                if (Left.Right.Balance < 0)
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
            }
            else if (Right.Balance > 1)
            {
                //right node violates balance property
                if (Right.Left.Balance > 0)
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
                if (Right.Right.Balance < 0)
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
    }
}
