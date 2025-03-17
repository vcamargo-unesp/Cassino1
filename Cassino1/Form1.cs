using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cassino1
{
    public partial class Form1 : Form
    {
        int[] roleta;
        int[] tempos;
        Label[] tela;
        Random r;
        public Form1()
        {
            InitializeComponent();
            roleta = new int[3];
            tela = new Label[] { lbl1, lbl2, lbl3 };
            r = new Random();

            for(int i = 0; i < roleta.Length; i++)
            {
                roleta[i] = r.Next(0, 10);
                Atualizar(tela[i], roleta[i]);
            }
        }

        void Atualizar(Label l, int num)
        {
            l.Text = num.ToString();
        }

        private void btGirar_Click(object sender, EventArgs e)
        {
            tempos = new int[3];
            for (int i = 0; i < roleta.Length; i++)
            {
                tempos[i] = r.Next(0, 50);
                tela[i].ForeColor = Color.Black;
            }
            btGirar.Enabled = false;
            tmrGiro.Enabled = true;
        }

        private void tmrGiro_Tick(object sender, EventArgs e)
        {
            bool girando = false;
            for(int i = 0; i < roleta.Length; i++)
            {
                if (tempos[i] > 0)
                {
                    girando |= true;
                    tempos[i]--;
                    if (tempos[i] == 0)
                        tela[i].ForeColor = Color.Red;
                    roleta[i]++;
                    if (roleta[i] == 10) 
                        roleta[i] = 0;
                    Atualizar(tela[i], roleta[i]);
                }
            }
            if (!girando)
            {
                btGirar.Enabled = true;
                tmrGiro.Enabled = false;
            }
        }
    }
}
