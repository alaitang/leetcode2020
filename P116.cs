/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution {
    public Node Connect(Node root) {
        if(root == null)
            return root;
        var list = new List<Node>(){root};
        
        while(list.Any()){
            var newList = new List<Node>();
            var p = new Node();
            foreach(var item in list){
                if(item.left != null)
                    newList.Add(item.left);
                if(item.right != null)
                    newList.Add(item.right);
                p.next = item;
                p = item;
            }
            
            list = newList;
        }
        
        return root;
    }
}



>>>>>>>>>>>>>>>>>>>>>>>>>>>>


public class Solution {
    public Node Connect(Node root) {
        if(root == null)
            return root;
        
        Connect(root.left);
        Connect(root.right);
        
        var left = root.left;
        var right = root.right;
        
        while(left != null){
            left.next = right;
            left = left.right;
            right = right.left;
        }
        
        return root;
    }
}