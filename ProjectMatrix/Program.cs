using System;

namespace ProjectMatrix
{
    class Matrix
    {

        private int n; //Размерность
        private int[,] mass; // Создание массива

        public Matrix() { } //  Пустой конструктор
        public int N  
        {
            get { return n; }                  // Считывание элемента
            set { if (value > 0) n = value; }  // Запись значения
        }

       // Конструктор матрицы
        public Matrix(int n)
        {
            this.n = n;
            mass = new int[this.n, this.n];
        }


       // Индексатор
        public int this[int i, int j]
        {
            get
            {
                return mass[i, j];
            }
            set
            {
                mass[i, j] = value;
            }
        }

        
        public void WriteMatrix()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine("Введите элемент матрицы {0}:{1}", i + 1, j + 1);
                    mass[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        
        public void ReadMatrix()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(mass[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        
     
       // Умножаем матрицы друг на друга
        public static Matrix umn(Matrix a, Matrix b)
        {
            Matrix itogMatrix = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
                for (int j = 0; j < b.N; j++)
                    for (int k = 0; k < b.N; k++)
                        itogMatrix[i, j] += a[i, k] * b[k, j];

            return itogMatrix;
        }



        // перегрузка оператора умножения
        public static Matrix operator *(Matrix a, Matrix b)
        {
            return Matrix.umn(a, b);
        }



        // Метод вычитания матрицы Б из матрицы А
        public static Matrix razn(Matrix a, Matrix b)
        {
            Matrix itogMatrix = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < b.N; j++)
                {
                    itogMatrix[i, j] = a[i, j] - b[i, j];
                }
            }
            return itogMatrix;
        }

        // Перегрузка оператора вычитания
        public static Matrix operator -(Matrix a, Matrix b)
        {
            return Matrix.razn(a, b);
        }
        public static Matrix Sum(Matrix a, Matrix b)
        {
            Matrix itogMatrix = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < b.N; j++)
                {
                    itogMatrix[i, j] = a[i, j] + b[i, j];
                }
            }
            return itogMatrix;
        }
        // Перегрузка сложения
        public static Matrix operator +(Matrix a, Matrix b)
        {
            return Matrix.Sum(a, b);
        }
        // Деструктор 
        ~Matrix()
        {
            Console.WriteLine("Очистка");
        }

    }
    class MainProgram
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность матрицы: ");
            int nn = Convert.ToInt32(Console.ReadLine());

            Matrix mass1 = new Matrix(nn);
            Matrix mass2 = new Matrix(nn);
            Matrix mass3 = new Matrix(nn);
            Matrix mass4 = new Matrix(nn);
            Matrix mass5 = new Matrix(nn);
            Matrix mass6 = new Matrix(nn);
            Matrix mass7 = new Matrix(nn);
            Matrix mass8 = new Matrix(nn);
            Console.WriteLine("ввод Матрица А: ");
            mass1.WriteMatrix();
            Console.WriteLine("Ввод Матрица B: ");
            mass2.WriteMatrix();

            Console.WriteLine("Матрица А: ");
            mass1.ReadMatrix();
            Console.WriteLine();
            Console.WriteLine("Матрица В: ");
            Console.WriteLine();
            mass2.ReadMatrix();

            Console.WriteLine("Сложение матриц А и Б: ");
            mass4 = (mass1 + mass2);
            mass4.ReadMatrix();

            Console.WriteLine("Вычитание матриц А и Б: ");
            mass6 = (mass1 - mass2);
            mass6.ReadMatrix();

            Console.WriteLine("Умножение матриц А и Б: ");
            mass8 = (mass1 * mass2);
            mass8.ReadMatrix();


            Console.ReadKey();
        }
    }
}