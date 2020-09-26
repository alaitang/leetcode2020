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
    public bool IsCompleteTree(TreeNode root) {
        if(root == null || root.left == null && root.right == null)
            return true;
        
        var pool = new List<TreeNode>(){root};
        
            var empty = false;
        while(pool.Any()){
            var newPool = new List<TreeNode>();
            foreach(var item in pool){
                if(empty && item.left != null)
                    return false;
                else if(!empty && item.left != null){
                    newPool.Add(item.left);
                }else if(!empty){
                    empty = true;
                }
                
                if(empty && item.right != null)
                    return false;
                else if(!empty && item.right != null){
                    newPool.Add(item.right);
                }else if(!empty){
                    empty = true;
                }
            }
            
            pool = newPool;
        }
        
        return true;
    }
}