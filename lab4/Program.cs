namespace exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4, m = 3, h;
            int l, r; //диапазон который будет вводить пользователь
            l = Convert.ToInt32(Console.ReadLine());
            r = Convert.ToInt32(Console.ReadLine());
            int[,] A = new int[n, m];
            Random rnd =new Random();
            //Иниицилизация матрицы
            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j<m; i++)
                {
                   
                    h = rnd.Next(l, r);
                    A[i,j] = h;
                }
            }
            Matrix m1 = new Matrix(n, m, A);
        }

    }

    public class Matrix
    {
        private int n, m;
        int[,] A;
        public Matrix(int n, int m, int[,] A)
        {
            this.n = n;
            this.m = m;
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; i++)
                {
                    this.A[i, j] = A[i, j];
                }
            }
        }
        public int this[int i, int j]
        {
            get
            {
                return A[i, j];
            }
            set
            {
                A[i, j] = value;
            }
        }

        public static Matrix operator +(Matrix a, Matrix b)
        { 
                for (int i = 0; i < a.n; i++)
                {
                    for (int j = 0; j < a.m; j++)
                    {
                        a[i, j] += b[i, j];
                    }
                }
            return a;
        }

  
        public static Matrix operator -(Matrix a, Matrix b)
        {
            for (int i = 0; i < a.n; i++)
            {
                for (int j = 0; j < a.m; j++)
                {
                    a[i, j] -= b[i, j];
                }
            }
            return a;
        }


        public static Matrix operator *(Matrix a, Matrix b)
        {
            for (int i = 0; i < a.n; i++)
            {
                for (int j = 0; j < a.m; j++)
                {
                    a[i, j] *= b[i, j];
                }
            }
            return a;
        }


        public static Matrix operator *(Matrix a, int k)
        {
            for (int i = 0; i < a.n; i++)
            {
                for (int j = 0; j < a.m; j++)
                {
                    a[i, j] *= k;
                }
            }
            return a;
        }

        public static Matrix operator /(Matrix a, int k)
        {
            for (int i = 0; i < a.n; i++)
            {
                for (int j = 0; j < a.m; j++)
                {
                    a[i, j] /= k;
                }
            }
            return a;
        }
    }
}

