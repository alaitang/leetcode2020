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
    public int MaxSumBST(TreeNode root) {
        Helper(root);
        return rr;
    }
    
    private int[] Helper(TreeNode root){
        int[] result = new int[]{1,0,0,0};
        
        if(root == null)
            return result;
        
        
        result[1] = root.val;
        result[2] = root.val;
        result[3] = root.val;
        
        if(root.left != null){
            
            var r = Helper(root.left);
            
            if(r[0] == 0 || r[2] >= root.val){
                result[0] = 0;
            }
            result[1] = r[1];
            result[3] += r[3];
        }
        
        if(root.right != null){
            
            var r = Helper(root.right);
            
            if(r[0] == 0 || r[1] <= root.val){
                result[0] = 0;
            }
            
            result[2] = r[2];
            result[3] += r[3];
        }
        if(result[0] == 1)
            rr = Math.Max(rr,result[3]);
        
        return result;
    }
}