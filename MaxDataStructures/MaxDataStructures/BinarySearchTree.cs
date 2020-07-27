namespace MaxDataStructures
{
    public class BinarySearchTree
    {







        private class BinarySearchTreeNode
        {
            public int Value { get; set; }
            public BinarySearchTreeNode Left { get; set; }
            public BinarySearchTreeNode Right { get; set; }

            public BinarySearchTreeNode(int value)
            {
                Value = value;
            }
        }
    }
}
