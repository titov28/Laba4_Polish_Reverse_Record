using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Node
    {
        public Token x;
        public Node next;


        public Node()
        {
            x = default(Token);
            next = null;
        }
    }
   

    public class Stack
    {
        private Node head;

        public Stack()
        {
            head = null;
        }

        public void Push(Token element)
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

       public Token Pop()
        {
            Node temp;

            if (head == null)
            {
                //Console.WriteLine("Стек пуст.");
                return default(Token);
            }
            else
            {
                temp = head;
                head = head.next;

                return temp.x;
            }
            

        }



        public Token GetHead()
        {
            if(head != null)
            {
                return head.x;
            }
            else
            {
                return default(Token);
            }
        }

        public bool IsEmpty()
        {
            if(head == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Show()
        {
            Console.Write("\n");
            Console.WriteLine("Содержимое стека: ");

            Node temp = head;


            while (temp != null)
            {
                Console.WriteLine(temp.x.Element);

                temp = temp.next;
            }

        }
    }
}
