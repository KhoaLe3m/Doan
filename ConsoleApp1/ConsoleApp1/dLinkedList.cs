using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace DoAn
{
    public class DoubleLinkedList
    {
        public Node2 header;
        public DoubleLinkedList()
        {
            header = new Node2(new MonHoc("MH00", "Header", 0, "Header", new DateTime(0001, 01, 01), new DateTime(0001, 01, 01), "Header", "HD"));
        }
        private Node2 Find(string ID)
        {
            Node2 current = new Node2();
            current = header;
            while (current.element.GetID() != ID)
            {
                current = current.flink;    
            }
            return current;
        }
        public void Insert(MonHoc newelement, string ID)
        {
            Node2 current = new Node2();
            Node2 newnode = new Node2(newelement);
            current = Find(ID);
            newnode.flink = current.flink;
            newnode.blink = current;    
            current.flink = newnode;
        }
        public void AddLast(MonHoc newelement)
        {
            Node2 current = FindLast();
            Node2 newnode = new Node2(newelement);
            current.flink = newnode;
            newnode.blink = current;
            newnode.flink = null;
        }
        public void Remove(string ID)
        {
            Node2 current = Find(ID);
            if (current.flink != null)
            {
                current.blink.flink = current.flink;
                current.flink.blink = current.blink;
                current.flink = null;
                current.blink = null;
            }
            else
            {
                current.blink.flink = null;
                current.blink = null;
            }
        }
        public int GetCount()
        {
            Node2 current = new Node2();
            current = FindLast();
            int count = 0;
            while (!(current.blink == null))
            {
                count++;
                current = current.blink;
            }
            return count;
        }
        public Node2 FindLast()
        {
            Node2 current = new Node2();
            current = header;
            while (!(current.flink == null))
                current = current.flink;
            return current;
        }
        public void Print()
        {
            Node2 current = new Node2();
            current = header.flink;
            while (!(current == null))
            {
                Console.WriteLine(current.element);
                current = current.flink;
            }
        }
    }
}