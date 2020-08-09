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
        var p = root;
        
        while(p != null){
            var prev = new Node(-1);
            var current = prev;
            
            while(p != null){
                if(p.left != null){
                    current.next = p.left;
                    current = current.next;
                }
                
                if(p.right != null){
                    current.next = p.right;
                    current = current.next;
                }
                p = p.next;
            }
            
            p = prev.next;
            
        }
        
        return root;
    }
}