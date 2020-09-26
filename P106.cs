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
    public TreeNode BuildTree(int[] inorder, int[] postorder) {
        var mapping = new Dictionary<int,int[]>();
        var len = inorder.Length;
        
        for(int i = 0;i<len;i++){
            if(!mapping.ContainsKey(inorder[i]))
                mapping[inorder[i]] = new int[2];
            mapping[inorder[i]][0] = i;
            
            if(!mapping.ContainsKey(postorder[i]))
                mapping[postorder[i]] = new int[2];
            mapping[postorder[i]][1] = i;
        }
        
        return Helper(inorder,postorder,mapping, 0,len-1,0,len-1);
    }
    
    private TreeNode Helper(int[] inorder,int[] postorder, Dictionary<int,int[]> mapping,
                            int low_inorder,int high_inorder,
                            int low_postorder,int high_postorder){
        if(low_inorder > high_inorder || low_postorder > high_postorder)
            return null;
        
        var root = new TreeNode(postorder[high_postorder]);
        
        var rootIndex = mapping[postorder[high_postorder]][0];
        
        root.left = Helper(inorder,postorder,mapping,low_inorder,rootIndex-1, low_postorder , low_postorder + rootIndex-1-low_inorder);
        root.right = Helper(inorder,postorder,mapping,rootIndex+1,high_inorder, high_postorder-1-(high_inorder-(rootIndex+1)) ,high_postorder-1 );
        
        return root;
    }
}