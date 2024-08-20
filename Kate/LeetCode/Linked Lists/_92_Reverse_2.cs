/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     } :3
 * }
 */
public class Solution {
    public ListNode ReverseBetween(ListNode head, int left, int right) {
        // Если список пуст или left == right (т.е. нет смысла разворачивать), то вернем голову
        if (head == null || left == right) {
            return head;
        }

        // Создаем фиктивный узел, который указывает на голову
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        
       // Найдем узел перед `left` и сам `left` узел
        ListNode beforeLeft = dummy;
        for (int i = 1; i < left; i++) {
            beforeLeft = beforeLeft.next;
        }

        // Начнем разворот
        ListNode current = beforeLeft.next;
        ListNode prev = null;
        for (int i = left; i <= right; i++) {
            ListNode next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }
        // Соединяем части списка
        beforeLeft.next.next = current; // Связь узла на позиции `right` с `afterRight`
        beforeLeft.next = prev;         // Связь `beforeLeft` с узлом на позиции `right`

        // Возвращаем новую голову (которая может быть той же, если left > 1)
        return dummy.next;
    }
}