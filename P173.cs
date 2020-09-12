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
public class BSTIterator {
Stack<TreeNode> stack = new Stack<TreeNode>();
    public BSTIterator(TreeNode root) {
        if(root != null)
            stack.Push(root);
        
        while(stack.Any() && stack.Peek().left != null)
            stack.Push(stack.Peek().left);
    }
    
    /** @return the next smallest number */
    public int Next() {
        var top = stack.Pop();
        
        if(top.right != null)
        {
            stack.Push(top.right);
            
            while(stack.Any() && stack.Peek().left != null)
                stack.Push(stack.Peek().left);
        }
        
        return top.val;
    }
    
    /** @return whether we have a next smallest number */
    public bool HasNext() {
        return stack.Any();
    }
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */