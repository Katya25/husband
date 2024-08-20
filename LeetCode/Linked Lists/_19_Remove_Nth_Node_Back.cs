public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        // Создаем фиктивный узел для удобства работы с головой списка
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        ListNode fast = dummy;
        ListNode slow = dummy;

        //moving fast for n points
        for(int i = 0; i <= n; i++)
        {
            fast = fast.next;
        }

        while(fast != null)
        {
            fast = fast.next;
            slow = slow.next;
        }

        slow.next = slow.next.next;
        slow = head;
        return dummy.next;
    }
}