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
    long total = 0;
    long result = long.MinValue;
    public int MaxProduct(TreeNode root) {
        total = Helper(root);
        Helper1(root);
        return (int)(result%1000000007);
    }
    
    private long Helper1(TreeNode root){
        if(root == null)
            return 0;
        
        long current = Helper1(root.left) + root.val + Helper1(root.right);
        
        result = Math.Max(result, current * (total-current) );
        
        return current;
    }
    
    private long Helper(TreeNode root){
        if(root == null)
            return 0;
        
        return Helper(root.left) + root.val + Helper(root.right);
    }
    
    
}