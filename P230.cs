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
public class Solution {
    
    public int KthSmallest(TreeNode root, int k) {
        var stack = new Stack<TreeNode>();
        stack.Push(root);
        while(stack.Any() && stack.Peek().left != null)
            stack.Push(stack.Peek().left);
        
        
        while(k > 1){
            var top = stack.Pop();
            
            if(top.right != null){
                stack.Push(top.right);
                while(stack.Any() && stack.Peek().left != null)
                    stack.Push(stack.Peek().left);
            }
            
            k--;
        }
        
        if(stack.Any())
            return stack.Peek().val;
        return -1;
    }
}