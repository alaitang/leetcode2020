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
    
    public int DeepestLeavesSum(TreeNode root) {
        
        var pool = new List<TreeNode>(){root};
        
        while(pool.Any()){
            var newpool = new List<TreeNode>();
            var a = 0;
            foreach(var item in pool){
                a += item.val;
                if(item.left != null)
                {
                    newpool.Add(item.left);
                }
                if(item.right != null)
                {
                    newpool.Add(item.right);
                }
            }
            pool = newpool;
            
            if(!pool.Any())
                return a;
        }
        
        return 0;
        
    }
    
}


>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

public class Solution {
    int depth = 0;
    int result = 0;
    public int DeepestLeavesSum(TreeNode root) {
        Helper(root,1);
        return result;
    }
    
    private void Helper(TreeNode root, int d){
        if(root == null)
            return;
        
        if(d > depth){
            result = 0;
            depth = d;
        }
        
        if(d == depth)
            result += root.val;
        
        Helper(root.left,d+1);
        Helper(root.right,d+1);
        
    }
}