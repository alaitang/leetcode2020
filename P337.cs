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
    int rr = 0;
    public int Rob(TreeNode root) {
        Helper(root);
        return rr;
    }
    
    public int[] Helper(TreeNode root){
        if(root == null)
            return new int[]{0,0};
        
        var leftR = Helper(root.left);
        var rightR = Helper(root.right);
        
        var result = new int[2];
        
        result[0] = root.val + leftR[1]+rightR[1];
        
        result[1] = leftR.Max()+rightR.Max();
        
        rr = Math.Max(rr,result.Max());
        
        return result;
    }
}