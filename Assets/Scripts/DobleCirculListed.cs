using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Nodo
{
    public string Valor { get; set; }
    public Nodo Siguiente { get; set; }
    public Nodo Anterior { get; set; }

    public Nodo(string valor)
    {
        Valor = valor;
        Siguiente = null;
        Anterior = null;
    }
}
public class DobleCirculListed
{
    public Nodo Cabeza { get; set; }
    private Nodo nodoActual;

    public DobleCirculListed()
    {
        Cabeza = null;
        nodoActual = null;
    }

    public void Añadir(string valor)
    {
        Nodo nuevoNodo = new Nodo(valor);
        if (Cabeza == null)
        {
            Cabeza = nuevoNodo;
            Cabeza.Siguiente = Cabeza;
            Cabeza.Anterior = Cabeza;
            nodoActual = Cabeza;
        }
        else
        {
            Nodo cola = Cabeza.Anterior;
            cola.Siguiente = nuevoNodo;
            nuevoNodo.Anterior = cola;
            nuevoNodo.Siguiente = Cabeza;
            Cabeza.Anterior = nuevoNodo;
        }
    }

    public string ObtenerValorActual()
    {
        return nodoActual?.Valor;
    }

    public void Siguiente()
    {
        if (nodoActual != null)
        {
            nodoActual = nodoActual.Siguiente;
        }
    }

    public void Anterior()
    {
        if (nodoActual != null)
        {
            nodoActual = nodoActual.Anterior;
        }
    }
}
