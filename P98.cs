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
    public bool IsValidBST(TreeNode root) {
        return Helper(root, ((long)int.MinValue)-1, ((long)int.MaxValue)+1);
    }
    
    public bool Helper(TreeNode root,long low,long high){
        if(root == null)
            return true;
        else if(root.val <= low || root.val >= high)
            return false;
        
        
        return Helper(root.left,low,root.val )
            && Helper(root.right,root.val,high);
    }
}