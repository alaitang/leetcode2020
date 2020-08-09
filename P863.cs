/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public IList<int> DistanceK(TreeNode root, TreeNode target, int K) {
        var result = new List<int>();
        
        Helper(root,target,result,K);
        
        return result;
    }
    
    private int Helper(TreeNode root, TreeNode target,List<int> result,int K){
        if(root == null)
            return -1;
        
        if(root == target)
        {
            Helper(root,K,result);
            return 1;
        }
        
        var leftR = Helper(root.left,target,result,K);
        var rightR = Helper(root.right,target,result,K);
        
        
        if(leftR == -1 && rightR == -1)
            return -1;
        else if(leftR == -1 && rightR != -1){
            if(rightR == K){
                result.Add(root.val);
            }else if(rightR < K)
                Helper(root.left,K-rightR-1,result);
            return rightR+1;
        }else{
            if(leftR == K){
                result.Add(root.val);
            }else if(leftR < K)
                Helper(root.right,K-leftR-1,result);
            return leftR+1;
        }
    }
    
    private void Helper(TreeNode root,int depth,List<int> result){
        if(root == null || depth < 0)
            return;
        
        if(depth == 0){
            result.Add(root.val);
            return;
        }
        
        Helper(root.left,depth-1,result);
        Helper(root.right,depth-1,result);
    }
}