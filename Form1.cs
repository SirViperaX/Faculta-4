namespace Faculta_4
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        public int[] x = { 0, 0, 0, 0 };
        public void rndToX(int[] x, Random rnd)
        {
            int random = rnd.Next(1000,10000);
            int i = 0;
            while (random>0)
            {

                x[i++] = random % 10;
                random /= 10;

            }
            
            while (!cifDif(x))
            {
                i = 0;
                random = rnd.Next(1000, 10000);
                while (random > 0)
                {
                    x[i++] = random % 10;
                    random /= 10;

                }
            }
            for (i = 0; i < x.Length / 2; i++)
            {
                int aux = x[i];
                x[i] = x[3 - i];
                x[3 - i] = aux;
            }

        }


        public Form1()
        {
            rndToX(x, rnd);
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int y = int.Parse(textBox1.Text);
                if (y >= 1000)
                    MessageBox.Show(cAndP(y));
            }
        }
        private bool cifDif(int[] n)
        {
            for (int i = 0; i < n.Length; i++)
            {
                for (int j = 0; j < n.Length; j++)
                {
                    if (n[i] == n[j] && i != j)
                        return false;
                }
            }
            return true;
        }
        private string cAndP(int y)
        {
            int[] n = { 0, 0, 0, 0 };
            int i = 0;
            while (y > 0)
            {
                n[i++] = y % 10;
                y /= 10;
            }
            for(i=0;i<n.Length/2;i++)
            {
                int aux = n[i];
                n[i] = n[3 - i];
                n[3 - i] = aux;

            }
            if (cifDif(n))
            {          
                int c = 0, p = 0;
                for (i = 0; i < x.Length; i++)
                {
                    if (x[i] == n[i])
                        c++;
                }
                for (i = 0; i < x.Length; i++)
                {
                    for (int j = 0; j < n.Length; j++)
                    {
                        if (x[i] == n[j])
                            p++;
                    }
                }
                p -= c;
                if (c == 4)
                {
                    return "Ai ghichit numarul";
        
                }    
                return $"Ai nimerit {c} cifre pe aceleasi pozitii si {p} pe pozitii diferite";
            }
            else
                return "Numarul nu are cifre distincte";
        }
    }
}