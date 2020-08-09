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
    public int CountNodes(TreeNode root) {
        if(root == null)
            return 0;
        var current = root.left;
        var left = 0;
        var right = 0;
        while(current != null){
            left++;
            current = current.left;
        }
        
        current = root.right;
        while(current != null){
            right++;
            current = current.right;
        }
        
        if(left == right){
            return (1 << (left+1))-1;
        }else{
            return CountNodes(root.left)+CountNodes(root.right)+1;
        }
    }
    
    
}