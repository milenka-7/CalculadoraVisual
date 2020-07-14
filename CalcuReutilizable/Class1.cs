using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcuReutilizable
{
    class Class1
        {
            public enum Operador {OPERANDO, PIZQ, PDER, SUMARES, MULTDIV, POW};
            public StringBuilder convertir_pos(string Ei)
            {
                char[] cadena = new char[Ei.Length];
                int tam = Ei.Length;
                Pila<int> stack = new Pila<int>(tam);
                int i, pos = 0;
                for (i=0; i<cadena.Length;i++)
                {
                    char car = Ei[i];
                    Operador actual = Tipo_y_Precedencia(car);
                    switch (actual)
                    {
                        case Operador.OPERANDO: cadena[pos++] = car; break;
                        case Operador.SUMARES:
                            {
                                while(!stack.Empty && Tipo_y_Precedencia((char)stack.Tope()) >= actual)
                                {
                                    cadena[pos++] = (char)stack.Pop();
                                }
                                stack.Push(car);
                            }
                            break;
                        case Operador.MULTDIV:
                            {
                                while(!stack.Empty && Tipo_y_Precedencia((char)stack.Tope()) >= actual)
                                {
                                    cadena[pos++] = (char)stack.Pop();
                                }
                                stack.Push(car);
                            }break;
                        case Operador.POW: {
                                while (!stack.Empty && Tipo_y_Precedencia((char)stack.Tope()) >= actual)
                                {
                                    cadena[pos++] = (char)stack.Pop();
                                }
                                stack.Push(car);
                            }break;
                        case Operador.PIZQ: stack.Push(car);break;
                        case Operador.PDER:
                            {
                                char x = (char)stack.Pop();
                                while (Tipo_y_Precedencia(x) != Operador.PIZQ)
                                {
                                    cadena[pos++] = x;
                                    x = (char)stack.Pop();

                                }
                            }break;
                    }
                }
                while (!stack.Empty)
                {
                    if (pos < cadena.Length)
                        cadena[pos++] = (char)stack.Pop();
                    else
                        break;
                }
            
            StringBuilder regresa = new StringBuilder(Ei);

            for(int r=0; r< cadena.Length;r++)
                regresa [r]=cadena[r];
                return regresa;
        }
            public Operador Tipo_y_Precedencia (char s)
            {
                Operador simbolo;
                switch (s)
                {
                    case '+': simbolo = Operador.SUMARES;break;
                    case '-': simbolo = Operador.SUMARES; break;
                    case '*': simbolo = Operador.MULTDIV; break;
                    case '/': simbolo = Operador.MULTDIV; break;
                    case '(': simbolo = Operador.PIZQ; break;
                    case ')': simbolo = Operador.PDER; break;
                    case '^': simbolo = Operador.POW; break;
                    default: simbolo = Operador.OPERANDO; break;
                }
                return simbolo;
            }
    }
}

