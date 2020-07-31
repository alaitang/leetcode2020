/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode[] SplitListToParts(ListNode root, int k) {
        var len = 0;
        var current = root;
        while(current != null){
            current = current.next;
            len++;
        }
        
        root = new ListNode(-1){next = root};
        
        var result = new ListNode[k];
        var avg = len/k;
        var add = len%k;
        for(int i = 0;i<k;i++){
            var pr = root;
            result[i] = root?.next;
            
            for(int j = 0;j<avg;j++){
                root = root.next;
            }
            
            if(i < add)
                root = root.next;
            
            if(pr!=null)
                pr.next = null;
        }
        
        
        return result;
    }
}