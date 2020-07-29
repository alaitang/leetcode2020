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
    int maxSum = 0;
    public int[] FindFrequentTreeSum(TreeNode root) {
        var result = new List<int>();
        Helper(root,new Dictionary<int,int>(),result);
        
        return result.ToArray();
    }
    
    private int Helper(TreeNode root,Dictionary<int,int> mapping,List<int> result){
        if(root == null)
            return 0;
        
        var sum = Helper(root.left,mapping,result)
            + root.val
            + Helper(root.right,mapping,result);
        
        if(!mapping.ContainsKey(sum))
            mapping[sum] = 0;
        mapping[sum]++;
        
        if(mapping[sum] > maxSum)
        {
            result.Clear();
            result.Add(sum);
            maxSum = mapping[sum];
        }else if(mapping[sum] == maxSum){
            result.Add(sum);
        }
        
        return sum;
    }
}