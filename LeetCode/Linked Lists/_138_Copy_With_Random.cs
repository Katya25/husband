/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node CopyRandomList(Node head) {
        if (head == null) return null;

        Node current = head;
        while(current != null)
        {
            //копия текущего узла, чтобы потом сделать A -> A' -> B -> B' -> C -> C'
            Node newNode = new Node(current.val);
            //привязываем новый узел, чтобы его next указывал на тот же узел, что и его оригинал
            //то есть A -> B и теперь A' -> B
            newNode.next = current.next;
            //теперь оригинальный узел указывает на новый узел. Так что добились двойного связывания
            current.next = newNode;
            //карент указывает на свой изначальный следующий уровень
            current = newNode.next;
        }

        //Настраиваем random указатели для новых узлов
        current = head;
        while(current != null)
        {
            if(current.random != null)
            {
                //не понимаю почему так
                current.next.random = current.random.next;
            }
            //// Переходим к следующему оригинальному узлу (через два шага)
            current = current.next.next;
        }
        //Отделяем оригинальные и новые узлы
        Node newHead = head.next; //head.next чтобы указывал на первый A' а не A
        Node newCur = newHead;
        current = head; 
        while(current != null)
        {
            current.next = current.next.next; // Восстанавливаем оригинальный список
            if (newCur.next != null) {
                newCur.next = newCur.next.next; // Связываем новые узлы друг с другом
            }
            newCur = newCur.next;
            current = current.next;
        }

        return newHead;
    }
}