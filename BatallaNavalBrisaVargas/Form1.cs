using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*Maria Brisa Vargas*/

/*Batalla naval - Formulario que tenga 3 arrays: uno para un barco grande (array de 4 elementos),
 * otro para uno mediano (array de 3 elementos) y uno pequeño (array de 2 elementos).
Los valores de los elementos del array surgen de combinar de manera aleatoria números 
del 0 al 5 y letras de la A a la F.
Debe existir 2 groupbox de RadioButton con los números del 0 al 5 y otro con las letras de la
A a la F.
Al seleccionar letra y número y presionar el boton "atacar" debe decir si hemos acertado en 
algúno de los barcos.*/


namespace BatallaNavalBrisaVargas
{

    public partial class Form1 : Form
    {
        public string[] barco1 = new string[4];
        public string[] barco2 = new string[3];
        public string[] barco3 = new string[2];
        public Boolean[] ocupados = new Boolean[36];
        public Form1()
        {
            InitializeComponent();
            crearBarcos();
        }
        
        public void crearBarcos()
        {
           string[] tablero = new string[36]
            {
                "A0","A1","A2","A3","A4","A5",
                "B0","B1","B2","B3","B4","B5",
                "C0","C1","C2","C3","C4","C5",
                "D0","D1","D2","D3","D4","D5",
                "E0","E1","E2","E3","E4","E5",
                "F0","F1","F2","F3","F4","F5"
            };

            
            //asignar valores para barco1
            for (int s=0; s<4;s++)
            { 
                int i = new Random().Next(0, 35);
                if (ocupados[i] == false)
                {
                    barco1[s] = tablero[i];
                    ocupados[i] = true;
                    //label1.Text += "random"+i+barco1[s]+" - ";
                }
                else { s--; }
            }
            //asignar valores para barco2
            for (int s = 0; s < 3; s++)
            {
                int i = new Random().Next(0, 36);
                if (ocupados[i] == false)
                {
                    barco2[s] = tablero[i];
                    ocupados[i] = true;
                    //label1.Text += barco2[s];
                }
                else { s--; }
            }
            //asignar valores para barco3
            for (int s = 0; s < 2; s++)
            {
                int i = new Random().Next(0, 36);
                if (ocupados[i] == false)
                {
                    barco3[s] = tablero[i];
                    ocupados[i] = true;
                    //label1.Text += barco3[s];
                }
                else { s--; }

            }
        }

        public void marcarX(string posicion)
        {
            foreach (Label l in groupBox1.Controls)
            {
                if (l.Name == posicion)
                {
                    l.Text = "X";
                }
            }
        }

        public void vaciar()
        {
            foreach (RadioButton rb in fila.Controls)
            {
                rb.Checked = false;
            }
            foreach (RadioButton rb in columna.Controls)
            {
                rb.Checked = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try {
                string f = "";
                string c = "";
                Boolean valF = false;
                Boolean valC = false;
                foreach (RadioButton rb in fila.Controls)
                {
                    if (rb.Checked)
                    {
                        f = rb.Text;
                        valF = true;
                    }
                }
                foreach (RadioButton rb in columna.Controls)
                {
                    if (rb.Checked)
                    {
                        c = rb.Text;
                        valC = true;
                    }
                }
                if (valF && valC)
                {
                    string posicion = f + c;
                    /*se debe ver si corresponde a algun elemento de los arreglos*/
                    Boolean ataque = false;

                    for (int s = 0; s < 4; s++)
                    {
                        if (barco1[s] == posicion)
                        {
                            //MessageBox.Show("Averiado");
                            ataque = true;
                            //hacer que la label en esa posicion se marque como x
                            marcarX(posicion);

                        }

                    }

                    for (int s = 0; s < 3; s++)
                    {
                        if (barco2[s] == posicion)
                        {
                            //MessageBox.Show("Averiado");
                            ataque = true;
                            //hacer que la label en esa posicion se marque como x
                            marcarX(posicion);
                        }

                    }

                    for (int s = 0; s < 2; s++)
                    {
                        if (barco3[s] == posicion)
                        {
                            //MessageBox.Show("Averiado");
                            ataque = true;
                            //hacer que la label en esa posicion se marque como x
                            marcarX(posicion);
                        }

                    }

                    if (ataque == false)
                    {
                        foreach (Label l in groupBox1.Controls)
                        {
                            if (l.Name == posicion)
                            {
                                l.Text = "O";
                            }
                        }
                    }
                    vaciar();
                }
                else
                {
                    MessageBox.Show("Complete al menos una fila y una columna");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error");
            }
        }
        
    }
}
