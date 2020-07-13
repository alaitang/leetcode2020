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
    int maxDepth = 0;
    TreeNode result = null;
    public TreeNode LcaDeepestLeaves(TreeNode root) {
        maxDepth = 0;
        result = null;
        Helper(root,1);
        
        return result;
    }
    
    private int Helper(TreeNode root,int depth){
        if(root == null)
            return depth;
        
        var leftR = Helper(root.left,depth+1);
        var rightR = Helper(root.right,depth+1);
        
        var d =  Math.Max(leftR,rightR);
        
        maxDepth = Math.Max(d,maxDepth);
        
        if(leftR == maxDepth && rightR == maxDepth)
            result = root;
        
        return d;
    }
}