/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
    public IList<IList<int>> LevelOrder(Node root) {
        var result = new List<IList<int>>();
        if(root == null)
            return result;
        var pool = new List<Node>(){root};
        while(pool.Any()){
            var newpool = new List<Node>();
            var r = new List<int>();
            foreach(var item in pool){
                r.Add(item.val);
                foreach(var c in item.children){
                    newpool.Add(c);
                }
            }
                pool = newpool;
            result.Add(r);
        }
        
        return result;
    }
}