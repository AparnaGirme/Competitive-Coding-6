/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
    {
        IList<IList<int>> result = new List<IList<int>>();
        if (root == null)
        { //3
            return result;
        }

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);//3
        int dir = 1;
        int level = 0;
        // result.Add(new List<int>());
        while (queue.Count > 0)
        {
            int size = queue.Count; //2
            result.Add(new List<int>());
            for (int i = 0; i < size; i++)
            {
                var node = queue.Dequeue();//7
                result[level].Add(node.val);//[[3],[9,20],[15, 7]]

                if (node.left != null)
                { //15
                    queue.Enqueue(node.left);
                }
                if (node.right != null)
                { //7
                    queue.Enqueue(node.right);
                }
            }
            if (dir == -1)
            {
                result[level] = result[level].Reverse().ToList(); ////[[3],[20,9],[15,7]]
            }
            dir *= -1; //-1
            level++;//3
        }
        return result;
    }
}