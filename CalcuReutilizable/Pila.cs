using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcuReutilizable
{
    class Pila<X>
    {
        X[] vec;
        int tam;
        int tope;
        bool vacia;
        bool llena;

        public Pila (int n)
        {
            tam = n;
            vec = new X[tam];
            tope = 0;
            vacia = true;
            llena = false;

        }
        public void Push(X valor)
        {
            vacia = false;
            vec[tope++] = valor;
            if (tope == tam)
                llena = true;
        }
        public X Pop()
        {
            llena = false;
            if(--tope==0)
            {
                vacia = true;
            }
            return vec[tope];
        }
        public bool esta_Vacia()
        {
            return vacia;

        }
        public bool esta_Llena()
        {
            return llena;

        }
        public X Tope()
        {
            return vec[tope - 1];
        }
        public bool Full
        {
            get { return tope == vec.Length; }
        }
        public bool Empty
        {
            get { return tope == 0; }
        }

    }
}
