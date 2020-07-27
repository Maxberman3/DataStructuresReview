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
            public void Remove(int val)
            {
                if (Value == val)
                {
                    if (Right.IsLeaf())
                    {

                    }
                }
            }
            private bool IsLeaf()
            {
                if (Left == null && Right == null)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
