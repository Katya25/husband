public class ListNode {
    public int val;
     public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}

public class Solution {
    public ListNode ReverseList(ListNode head) {
        if (head == null) return head;

        ListNode dummy = null;
        ListNode cur = head;
        while (cur != null) {
            ListNode next = cur.next;
            cur.next = dummy;
            dummy = cur;
            cur = next;
        }

        return dummy;
    }
}

public class Program {
    public static void Main(string[] args) {
        // Создаем односвязный список: 1 -> 2 -> 3 -> 4 -> 5
        ListNode head = new ListNode(1);
        head.next = new ListNode(2);
        head.next.next = new ListNode(3);
        head.next.next.next = new ListNode(4);
        head.next.next.next.next = new ListNode(5);

        Console.WriteLine("Исходный список:");
        PrintList(head);

        // Реверсируем список
        Solution solution = new Solution();
        ListNode reversedHead = solution.ReverseList(head);

        Console.WriteLine("Реверсированный список:");
        PrintList(reversedHead);
    }

    // Метод для печати списка
    public static void PrintList(ListNode head) {
        ListNode current = head;
        while (current != null) {
            Console.Write(current.val + " -> ");
            current = current.next;
        }
        Console.WriteLine("null"); // Конец списка
    }
}