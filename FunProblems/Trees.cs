using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunProblems
{
    public class Trees
    {
        static int preIndex = 0;
        static TreeNode tail; 

        internal TreeNode constructTreeFromPreAndIn(char[] inorderList, char[] preorderList)
        {
            if (inorderList == null 
                || preorderList == null
                || inorderList.Length == 0 
                || preorderList.Length == 0
                || inorderList.Length != preorderList.Length)
            return null;

            return constructTreeFromPreAndIntil(inorderList, preorderList, 0, inorderList.Length - 1);
        }

        internal TreeNode constructTreeFromPostAndIn(char[] inorderList, char[] postOrderList)
        {

            if (inorderList == null
                || postOrderList == null
                || inorderList.Length == 0
                || postOrderList.Length == 0
                || inorderList.Length != postOrderList.Length)
                return null;
            
            return constructTreeFromPostAndIntil(inorderList, postOrderList, 0, inorderList.Length - 1);
        }

        internal void printInorder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            printInorder(root.left);
            Console.WriteLine(root.data);
            printInorder(root.right);
        }

        private TreeNode constructTreeFromPostAndIntil(char[] inorderList, char[] postOrderList, int inStart, int inEnd)
        {
            if (inEnd < inStart)
            {
                return null;
            }

            int rootIndex = _searchNode(inorderList, postOrderList[preIndex--]);
            TreeNode node = new TreeNode(inorderList[rootIndex]);

            if (inStart == inEnd)
                return node;

            node.left = constructTreeFromPreAndIntil(inorderList, postOrderList, inStart, rootIndex - 1);
            node.right = constructTreeFromPreAndIntil(inorderList, postOrderList, rootIndex + 1, inEnd);

            return node;
        }

        private TreeNode constructTreeFromPreAndIntil(char[] inorderList, char[] preorderList, int inStart, int inEnd)
        {
            if(inEnd < inStart)
            {
                return null;
            }

            int rootIndex = _searchNode(inorderList, preorderList[preIndex++]);
            TreeNode node = new TreeNode(inorderList[rootIndex]);

            if (inStart == inEnd)
                return node;    

            node.left = constructTreeFromPreAndIntil(inorderList, preorderList, inStart, rootIndex -1);
            node.right = constructTreeFromPreAndIntil(inorderList, preorderList, rootIndex + 1, inEnd);

            return node;
        }

        internal bool AreTwoTreesMirrorOfEachOther(TreeNode root1, TreeNode root2)
        {
            if(root1 == null && root2 != null ||
               root2 == null && root1 != null)
            {
                return false;
            }
            if(root1 == null && root2 == null)
            {
                return true;
            }

            return root1.data == root2.data &&
                   AreTwoTreesMirrorOfEachOther(root1.left, root2.right) &&
                   AreTwoTreesMirrorOfEachOther(root1.right, root2.left);
            
        }

        internal TreeNode FindLowestCommonAncestor(TreeNode node1, TreeNode node2, TreeNode root)
        {
            if (root == null)
                return null;

            // if any of the nodes is an immidiate child of the root, return the root. 
            if (root.left == node1
                || root.right == node1
                || root.left == node2
                || root.right == node2)
                return root;

            // recurse on the left subtree, to find the lowest common
            TreeNode leftSubTree = FindLowestCommonAncestor(node1, node2, root.left);

            //recurse on the right subtree , to find the lowest common 
            TreeNode rightSubTree = FindLowestCommonAncestor(node1, node2, root.right);

            // if both subtrees or not null, then return the parent. 
            //This means that the two nodes are in different subtrees
            if (leftSubTree != null && rightSubTree != null)
            {
                return root;
            }

            // else return the tree which is not null. 
            return leftSubTree != null ? leftSubTree : rightSubTree;
        }

        internal TreeNode ConvertTreeToDoublyLinkedList(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }

            pushToDoubleLinkedList(root);

            ConvertTreeToDoublyLinkedList(root.left);
            ConvertTreeToDoublyLinkedList(root.right);
            return tail;
        }

        private void pushToDoubleLinkedList(TreeNode node)
        {
            if (tail != null)
            {
                tail = node;
                node.left = node.right = null;
                return;
            }

            tail.right = node;
            node.left = tail;
            tail = tail.right;
        }

        private int _searchNode(char[] inorderList, int root)
        {
            for(int i = 0; i < inorderList.Length;  i++)
            {
                if (inorderList[i] == root)
                    return i;
            }

            throw new Exception("something wrong with tree");
        }

    }

    internal class TreeNode
    {
        internal TreeNode(char data)
        {
            this.data = data;
        }

        internal TreeNode left;
        internal TreeNode right;
        internal char data;
    }
}
