using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Queue<T>
    {
        Node<T> head;
        Node<T> prev;

        public Queue()
        {
            prev = null;
            head = null;
        }

        public void Push(T element)
        {
            Node<T> temp = new Node<T>();
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

        public T Pop()
        {
            Node<T> temp;

            if (head == null)
            {
                prev = null;

                Console.WriteLine("Очередь пуста.");
                return default(T);
            }
            else
            {
                temp = head;
                head = head.next;

                return temp.x;
            }
        }

        public void Show()
        {
            Console.Write("\n");
            Console.WriteLine("Содержимое очереди: ");

            Node<T> temp = head;


            while (temp != null)
            {
                Console.WriteLine(temp.x);

                temp = temp.next;
            }

        }

    }
}
