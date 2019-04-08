using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Queue
    {
        Node head;
        Node prev;

        public Queue()
        {
            prev = null;
            head = null;
        }

        public void Push(Token element)
        {
            Node temp = new Node();
            temp.x = element;
            temp.next = null;

            if (head == null)
            {
                head = temp;
            }
            else if(prev == null)
            {
                prev = temp;
                head.next = prev;
            }
            else
            {
                prev.next = temp;
                prev = temp;
            }
        }

        public Token Pop()
        {
            Node temp;

            if (head == null)
            {
                prev = null;

                //Console.WriteLine("Очередь пуста.");
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
            if (head != null)
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
            Console.WriteLine("Содержимое очереди: ");

            Node temp = head;


            while (temp != null)
            {
                if (temp.x.OperationFlag)
                {
                    Console.WriteLine(temp.x.Operation);
                    
                }
                else
                {
                    Console.WriteLine(temp.x.Number);
                }

                    
                temp = temp.next;
            }

        }

    }
}
