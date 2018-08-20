using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanEcoModel
{
    class Ocean
    {
        //static public Ocean _owner = new Ocean();

        static int _MaxRows = 25;
        static int _MaxCols = 70;
        int DefaultNumIterations = 10000;
        int DefaultNumObstacles = 75;
        int DefaultNumPredators = 20;
        int DefaultNumPrey = 150;
        public int _numRows;
        public int _numCols;
        int _size;
        int _numPrey;
        int _numPredators;
        int _numObstacles;
        public Random _random = new Random();

        public Cell[,] _cells = new Cell[_MaxRows, _MaxCols];

        public char DefaultImage = '-';

        void AddEmptyCells()
        {
            // _random.NextDouble   // получение случайного вещественного числа
            for (int row = 0; row < _numRows; row++)
            {
                for (int col = 0; col < _numCols; col++)
                {
                    _cells[row, col] = new Cell(new Coordinate(col, row));
                }
            }
        }

        //устанавливает numObstacles преград в океане int numObstacles
        public void AddObstacles()
        {
            Coordinate empty;
            for (int count = 0; count < _numObstacles; count++)
            {
                empty = getEmptyCellCoord();
                _cells[empty.getY(), empty.getX()] = new Obstacle(empty);
            }
        }

        //устанавливает numPreditors хищников в океане int numPreditors
        public void AddPreditors()
        {
            Coordinate empty;
            for (int count = 0; count < _numPredators; count++)
            {
                empty = getEmptyCellCoord();
                _cells[empty.getY(), empty.getX()] = new Predator(empty);
            }
        }

        //int numPrey Устанавливает numPrey добычи в океане
        public void AddPrey()
        {
            Coordinate empty;
            for (int count = 0; count < _numPrey; count++)
            {
                empty = getEmptyCellCoord();
                _cells[empty.getY(), empty.getX()] = new Prey(empty);
            }
        }

        Coordinate getEmptyCellCoord()//получаем случайные координаты 
        {
            int x, y;
            do
            {
                x = _random.Next(0, _numCols - 1);
                y = _random.Next(0, _numRows - 1);
            }
            while (_cells[y, x].getImage() != DefaultImage);//*/;    // is / as//(_cells[y, x] != null)
            return new Coordinate(x, y);
        }

        //возвращает количество добычи
        public int getNumPrey()
        {
            return _numPrey;
        }

        //устанавливает количество добычи в aNumber
        public void setNumPrey(int aNumber)
        {
            _numPrey = aNumber;
        }

        //возвращает количество хищников
        public int getNumPredators()
        {
            return _numPredators;
        }

        //устанавливает количество хищников в aNumber
        public void setNumPredators(int aNumber)
        {
            _numPredators = aNumber;
        }

        //инициализирует счетчик случайных чисел и размеры окна. устанавливает по умолчанию количество хищников, добычи и преград
        public void inizialize()
        {
            //_random.inizialize();
            _numRows = _MaxRows;
            _numCols = _MaxCols;
            _size = _numRows * _numCols;

            _numObstacles = DefaultNumObstacles;
            _numPredators = DefaultNumPredators;
            _numPrey = DefaultNumPrey;

            initCells();
        }

        //запрашивает количество преград, добычи хищников и вставляет их в океан.
        void initCells()
        {
            AddEmptyCells();
            Console.WriteLine("Enter number of obstacles (default =75):");
            _numObstacles = Convert.ToInt32(Console.ReadLine());
            if (_numObstacles == _size)
            {
                _numObstacles = _size;
                Console.WriteLine("Number NumObstacle accepted ={0}", _numObstacles);
            }

            Console.WriteLine("Enter number of predators (default=20:");
            _numPredators = Convert.ToInt32(Console.ReadLine());
            if (_numPredators == _size - _numObstacles)
            {
                _numPredators = _size - _numObstacles;
                Console.WriteLine("Number NumOPredators accepted ={0}", _numPredators);
            }

            Console.WriteLine("Enter number of prey (default=150:");
            _numPrey = Convert.ToInt32(Console.ReadLine());
            if (_numPrey == _size - _numObstacles - _numPredators)
            {
                _numPredators = _size - _numObstacles - _numPredators;
                Console.WriteLine("Number NumOPredators accepted ={0}", _numPrey);
            }

            AddObstacles();
            AddPreditors();
            AddPrey();
            //displayStats(-1);
            displayCells();
            displayBorder();
            Cell._owner = this;//Ocean Ocean1 = this прикрепление инициализированный океан ко всем ячейкам
        }

        //МЕТОДЫ ОТОБРАЖЕНИЯ
        //отображает максимальную ограниченную область океана. Первоначально это только горизонтальная граница 
        void displayBorder()
        {
            for (int col = 0; col < _numCols; col++)
            {
                Console.Write("*");
            }
        }

        //пересчитывает и выводит массив cells.
        void displayCells()
        {
            for (int row = 0; row < _numRows; row++)
            {
                for (int col = 0; col < _numCols; col++)
                {
                    if (_cells[row, col] != null)
                    {
                        Console.SetCursorPosition(col, row);
                        _cells[row, col].display();
                    }
                    else
                    {
                        //    Console.Write(' ');
                    }
                    //Console.WriteLine("\n\n");
                }
            }
        }

        //обновляет отображаемый номер итерации, количество преград, хищников и добычи
        void displayStats(int iteration)
        {
            Console.SetCursorPosition(0, _MaxRows + 2);
            Console.WriteLine("                                             ");
            Console.WriteLine("                                             ");
            Console.WriteLine("                                             ");
            Console.WriteLine("                                             ");
            Console.SetCursorPosition(0, _MaxRows + 2);
            Console.WriteLine("Iteration number {0}", iteration);
            Console.WriteLine("Obstacles: {0}", _numObstacles);
            Console.WriteLine("Predators: {0}", _numPredators);
            Console.WriteLine("Prey: {0}", _numPrey);
            displayBorder();
        }

        //МЕТОДЫ ЗАПУСКА ПРОЦЕССА МОДЕЛИРОВАНИЯ
        public void run()//запрашивает у пользователя колчичество итераций и начинает моделирование
        {
            int numiteration = DefaultNumIterations;
            Console.Write("\nEnter number of iterations (default max = 1000):");
            numiteration = Convert.ToInt32(Console.ReadLine());
            if (numiteration > 10000)
            {
                numiteration = 10000;
                Console.WriteLine("\n Number iteration = 10000 \nbegin run...\n");
            }

            int[] mas = new int[numiteration];

            for (int iteration = 0; iteration < numiteration; iteration++)
            {
                if (_numPredators > 0 && _numPrey > 0)
                {
                    for (int row = 0; row < _numRows; row++)
                    {
                        for (int col = 0; col < _numCols; col++)
                        {
                            _cells[row, col].Process();
                        }
                    }
                    displayStats(iteration);
                    displayCells();
                    displayBorder();
                    mas[iteration] = _numPredators;

                }
            }
            Console.SetCursorPosition(0, _numRows + 7);
            Console.WriteLine("End of Simulation");

            Console.ReadLine();
        }
    }
}
