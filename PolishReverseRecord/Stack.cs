using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Node
    {
        public int x;
        public Node next;
    }
   

    public class Stack
    {
        private Node head;

        public Stack()
        {
            head = null;
        }

        public void Push(int element)
        {
            if(head == null)
            {
                head = new Node();
                head.x = element;
                head.next = null;
            }
            else
            {
                Node temp = new Node();
                temp.x = element;
                temp.next = head;

                head = temp;

                temp = null;
            }

        }

       public int Pop()
        {
            Node temp;
            if(head != null)
            {
                temp = head.next;

                head = temp;

                return temp.x;
            }
            else
            {
                Console.WriteLine("Стек пуст.");
            }

            return -1;
        }

        public void Show()
        {
            Console.Write("\n");
            Console.WriteLine("Содержимое стека: ");

            Node temp = head;


            while (temp != null)
            {
                Console.WriteLine(temp.x);

                temp = temp.next;
            }

        }
    }
}
