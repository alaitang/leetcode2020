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
    public ListNode RotateRight(ListNode head, int k) {
        if(k == 0)
            return head;
        var len = 0;
        
        var current = head;
        while(current != null){
            current = current.next;
            len++;
        }
        
        if(len <= 1)
            return head;
        
        k = k%len;
        
        if(k == 0)
            return head;
        
        var fast = head;
        
        while(k > 0){
            fast = fast.next;
            k--;
        }
        
        var slow = head;
        
        while(fast.next != null){
            slow = slow.next;
            fast = fast.next;
        }
        
        fast.next = head;
        var result = slow.next;
        slow.next = null;
        
        return result;
        
        
    }
}