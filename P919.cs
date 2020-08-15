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
public class CBTInserter {

    Queue<TreeNode> list = new Queue<TreeNode>();
    TreeNode root = null;
    
    public CBTInserter(TreeNode root) {
        this.root = root;
        
        var pool = new Queue<TreeNode>();
        
        pool.Enqueue(root);
        
        while(pool.Any()){
            var top = pool.Dequeue();
            
            if(top.left ==null || top.right == null)
            {
                list.Enqueue(top);
            }
            if(top.left != null){
                pool.Enqueue(top.left);
            }
            if(top.right != null){
                pool.Enqueue(top.right);
            }
        }
        
    }
    
    public int Insert(int v) {
        var newNode = new TreeNode(v);
        var result = list.Peek().val;
        if(list.Peek().left == null ){
            list.Peek().left = newNode;
        }else{
            list.Dequeue().right = newNode;
        }
        
        list.Enqueue(newNode);
        return result;
    }
    
    public TreeNode Get_root() {
        return root;
    }
}

/**
 * Your CBTInserter object will be instantiated and called as such:
 * CBTInserter obj = new CBTInserter(root);
 * int param_1 = obj.Insert(v);
 * TreeNode param_2 = obj.Get_root();
 */