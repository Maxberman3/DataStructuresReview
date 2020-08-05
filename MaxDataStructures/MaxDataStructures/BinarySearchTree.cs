namespace MaxDataStructures
{
    public class BinarySearchTree
    {
        private BinarySearchTreeNode Root { get; set; }

        public void Insert(int value)
        {
            if (Root == null)
            {
                Root = new BinarySearchTreeNode(value);
            }
            else
            {
                Root.Insert(value);
            }
        }
        public bool Search(int value)
        {
            if (Root == null)
            {
                return false;
            }
            return Root.Search(value);
        }

        public void Remove(int value)
        {
            if (Root == null)
            {
                return;
            }
            if (value == Root.Value)
            {
                if (Root.IsLeaf())
                {
                    Root = null;
                }
                else if (Root.Right == null && Root.Left != null)
                {
                    Root = Root.Left;
                }
                else if (Root.Right != null && Root.Left == null)
                {
                    Root = Root.Right;
                }
                else
                {
                    int temp = Root.Right.Value;
                    Root.Right.Remove(temp, Root);
                    Root.Value = temp;
                }
            }
            else if (value > Root.Value)
            {
                Root.Right.Remove(value, Root);
            }
            else
            {
                Root.Left.Remove(value, Root);
            }
        }
        public string InOrderPrint()
        {
            return Root.InOrderPrint();
        }
        public string PreOrderPrint()
        {
            return Root.PreOrderPrint();
        }
        public string PostOrderPrint()
        {
            return Root.PostOrderPrint();
        }






        private class BinarySearchTreeNode
        {
            public int Value { get; set; }
            public BinarySearchTreeNode Left { get; set; }
            public BinarySearchTreeNode Right { get; set; }

            public BinarySearchTreeNode(int val)
            {
                Value = val;
            }
            public void Insert(int val)
            {
                if (val > Value)
                {
                    if (Right == null)
                    {
                        Right = new BinarySearchTreeNode(val);
                    }
                    else
                    {
                        Right.Insert(val);
                    }
                }
                else
                {
                    if (Left == null)
                    {
                        Left = new BinarySearchTreeNode(val);
                    }
                    else
                    {
                        Left.Insert(val);
                    }
                }
            }
            public bool Search(int val)
            {
                if (Value == val)
                {
                    return true;
                }
                else
                {
                    if (Left != null)
                    {
                        if (Left.Search(val))
                        {
                            return true;
                        }
                    }
                    if (Right != null)
                    {
                        if (Right.Search(val))
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            public void Remove(int val, BinarySearchTreeNode Previous)
            {
                bool wentLeft = Previous.Value >= Value;
                if (val == Value)
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
                    else if (Left == null && Right != null)
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
                    else
                    {
                        int temp;
                        if (wentLeft)
                        {
                            temp = Right.Value;
                            Right.Remove(temp, this);
                            Value = temp;
                        }
                        else
                        {
                            temp = Left.Value;
                            Left.Remove(temp, this);
                            Value = temp;
                        }
                    }
                }
                else if (val > Value)
                {
                    Right.Remove(val, this);
                }
                else
                {
                    Left.Remove(val, this);
                }
            }
            public bool IsLeaf()
            {
                if (Left == null && Right == null)
                {
                    return true;
                }
                return false;
            }
            public string InOrderPrint()
            {
                string str = "";
                if (Left != null)
                {
                    str += Left.InOrderPrint();
                }
                str += Value;
                if (Right != null)
                {
                    str += Right.InOrderPrint();
                }
                return str;
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
            public string PostOrderPrint()
            {
                string str = "";
                if (Left != null)
                {
                    str += Left.PostOrderPrint();
                }
                if (Right != null)
                {
                    str += Right.PostOrderPrint();
                }
                str += Value;
                return str;
            }
        }
    }
}
