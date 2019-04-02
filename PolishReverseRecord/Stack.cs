using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Node<T>
    {
        public T x;
        public Node<T> next;
    }
   

    public class Stack<T>
    {
        private Node<T> head;

        public Stack()
        {
            head = null;
        }

        public void Push(T element)
        {
            if(head == null)
            {
                head = new Node<T>();
                head.x = element;
                head.next = null;
            }
            else
            {
                Node<T> temp = new Node<T>();
                temp.x = element;
                temp.next = head;

                head = temp;

                temp = null;
            }

        }

       public T Pop()
        {
            Node<T> temp;
            if(head != null)
            {
                temp = head.next;

                head = temp;

                return temp.x;
            }
            else
            {
                Console.WriteLine("Стек пуст.");
                return default(T);
            }

            
        }

        public void Show()
        {
            Console.Write("\n");
            Console.WriteLine("Содержимое стека: ");

            Node<T> temp = head;


            while (temp != null)
            {
                Console.WriteLine(temp.x);

                temp = temp.next;
            }

        }
    }
}
