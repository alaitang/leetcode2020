/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        if(root == null)
            return "";
        
        var sb = new StringBuilder();
        
        sb.Append(root.val);
        
        var pool = new List<TreeNode>(){root};
        var nullCount = 0;
        while(pool.Any()){
            var newPool = new List<TreeNode>();
            
            foreach(var item in pool){
                if(item.left != null){
                    sb.Insert(sb.Length,",null",nullCount);
                    sb.Append($",{item.left.val}");
                    nullCount = 0;
                    newPool.Add(item.left);
                }else{
                    nullCount++;
                }
                if(item.right != null){
                    sb.Insert(sb.Length,",null",nullCount);
                    sb.Append($",{item.right.val}");
                    nullCount = 0;
                    newPool.Add(item.right);
                }else{
                    nullCount++;
                }
            }
            
            pool = newPool;
        }
        
        return sb.ToString();
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        if(data == "")
            return null;
        
        var arr = data.Split(new char[]{','});
        var queue = new Queue<TreeNode>();
        var len = arr.Length;
        var result = new TreeNode(int.Parse(arr[0]));
        queue.Enqueue(result);
        for(int i = 1;i<len;i+=2){
            var top = queue.Dequeue();
            if(arr[i] != "null"){
                top.left = new TreeNode(int.Parse(arr[i]));
                queue.Enqueue(top.left);
            }
            
            if(i+1 < len && arr[i+1] != "null"){
                top.right = new TreeNode(int.Parse(arr[i+1]));
                queue.Enqueue(top.right);
            }
        }
        
        return result;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));