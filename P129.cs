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
    public int SumNumbers(TreeNode root) {
        return Helper(root,0);
    }
    
    public int Helper(TreeNode root,int v){
        if(root == null)
            return 0;
        
        v = v*10 + root.val;
        if(root.left == null && root.right == null)
            return v;
        
        return Helper(root.left,v)+Helper(root.right,v);
    }
}

>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

public class Solution {
    
    public int SumNumbers(TreeNode root) {
        if(root == null)
            return 0;
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        var vq = new Queue<int>();
        vq.Enqueue(0);
        var result = 0;
        
        while(q.Any()){
            var node = q.Dequeue();
            var v = vq.Dequeue();
            
            var newv = v*10 + node.val;
            
            if(node.left == null && node.right == null)
                result += newv;
            else{
                if(node.left != null)
                {
                    q.Enqueue(node.left);
                    vq.Enqueue(newv);
                }
                if(node.right != null)
                {
                    q.Enqueue(node.right);
                    vq.Enqueue(newv);
                }
            }
        }
        
        return result;
    }
    
}