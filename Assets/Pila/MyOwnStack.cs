using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyOwnStack<T>
{
    public class Node
    {
        public T Value { get; set; }
        public Node Previous { get; set; }
        public Node Next { get; set; }

        public Node(T value)
        {
            Value = value;
            Previous = null;
            Next = null;
        }
    }

    public Node head;
    public Node top;
    public int Count { get; private set; } = 0;

    public void Push(T value)
    {
        Node newNode = new Node(value);
        if (top == null)
        {
            head = newNode;
            top = newNode;
        }
        else
        {
            top.Next = newNode;
            newNode.Previous = top;
            top = newNode;
        }
        Count++;
    }

    public T Pop()
    {
        if (top == null)
        {
            throw new System.NullReferenceException("La pila está vacía");
        }
        Node previousNode = top.Previous;
        T value = top.Value;
        if (previousNode != null)
        {
            previousNode.Next = null;
            top.Previous = null;
            top = previousNode;
        }
        else
        {
            head = null;
            top = null;
        }
        Count--;
        return value;
    }

    public void PrintAllNodes()
    {
        Node tmp = head;
        while (tmp != null)
        {
            Debug.Log(tmp.Value);
            tmp = tmp.Next;
        }
    }
}


