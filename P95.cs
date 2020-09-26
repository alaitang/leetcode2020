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
    public IList<TreeNode> GenerateTrees(int n) {
        if(n == 0)
            return new List<TreeNode>();
        return Helper(1,n,new Dictionary<string,List<TreeNode>>());
    }
    
    private IList<TreeNode> Helper(int low,int high, Dictionary<string,List<TreeNode>> mapping){
        if(low > high)
            return new List<TreeNode>(){null};
        var key = $"{low},{high}";
        
        if(!mapping.ContainsKey(key)){
            mapping[key] = new List<TreeNode>();
            
            for(int i = low;i<=high;i++){
                var leftR = Helper(low,i-1,mapping);
                var righR = Helper(i+1,high,mapping);
                
                foreach(var l in leftR){
                    foreach(var r in righR){
                        var root = new TreeNode(i){left=l,right=r};
                        mapping[key].Add(root);
                    }
                }
            }
        }
        
        return mapping[key];
    }
}