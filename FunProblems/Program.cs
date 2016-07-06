using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            Trees tree = new Trees();
            char[] ino = { 'a', 'a', 'a'};
            char[] pre = { 'a', 'a', 'a'};

            //       tree.constructTreeFromPreAndIn(ino, pre);

            TreeNode root = tree.constructTreeFromPreAndIn(ino, pre);
            tree.printInorder(root);

            Console.ReadKey();
        }
    }
}
