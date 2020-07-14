using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcuReutilizable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Class1 nota;
        private Pila<int> pila2;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            nota = new Class1();
            if (textBox1.Text != "")
            {
                textBox3.Clear();
                textBox2.Text = nota.convertir_pos(textBox1.Text).ToString();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

            pila2 = new Pila<int>(textBox2.Text.Length);
            try
            {
                string cad = textBox2.Text;
                for(int i = 0; i < cad.Length; i++)
                {
                    if(cad[i]>=48 && cad[i] <= 57)
                    {
                        int num = cad[i] - 48;
                        pila2.Push(num);
                    }
                    else
                    {
                        int resp = 0;
                        int num1 = pila2.Pop();
                        int num2 = num1;
                        num1 = pila2.Pop();
                        switch (cad[i])
                        {
                            case '+':resp = num1 + num2;
                                break;
                            case '-':
                                resp = num1 - num2;
                                break;
                            case '*':
                                resp = num1 * num2;
                                break;
                            case '/':
                                resp = num1 / num2;
                                break;
                            
                            case '^':
                                {
                                    resp = num1;
                                    int j = 1;
                                    while(j<num2){
                                        resp = resp * num1;
                                        j++;
                                    }
                                }
                                break;
                        }
                        pila2.Push(resp);
                        textBox3.Text = resp.ToString();
                    }
                }

            }
            catch
            {
                MessageBox.Show("Error al ingresar caracteres!!", "Erro!");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
