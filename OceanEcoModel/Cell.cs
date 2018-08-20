using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanEcoModel
{
    class Cell
    {
        public char DefaultPreyImage = 'o';
        public static Ocean _owner;
        public char DefaultImage = '-';
        public char _image;
        protected Coordinate _offset;

        public Cell(Coordinate aCoord)
        {
            _image = DefaultImage;
            _offset = aCoord;
        }

        public Coordinate getOffSet()
        {
            return _offset;
        }

        //Устанавливает смещение в aCoord
        public void setOffSet(Coordinate anOffset)
        {
            _offset = anOffset;
        }

        //Возвращает изображение
        public char getImage()
        {
            return _image;
        }

        //Перемещает в соседнюю ячейку используя определенные правила (в зависимости от подкласса)
        public virtual void Process() { }


        //Ищет пустую соседнюю ячейку(север-юг-запад-восто)
        public Coordinate getEmptyNeightborCoord()
        {
            return getNeightborWithImage(DefaultImage).getOffSet();
        }

        //Ищет соседнюю ячейку с добычей(север-юг-запад-восто)
        public Coordinate getPreyNeightborCoord()
        {
            return getNeightborWithImage(DefaultPreyImage).getOffSet();
        }

        Cell getNeightborWithImage(char animage)
        {
            Cell[] neightbor = new Cell[4];
            int count = 0;
            if (north().getImage() == animage) { neightbor[count++] = north(); }
            if (south().getImage() == animage) { neightbor[count++] = south(); }
            if (east().getImage() == animage) { neightbor[count++] = east(); }
            if (west().getImage() == animage) { neightbor[count++] = west(); }

            if (count == 0) { return this; }
            else { return neightbor[_owner._random.Next(0, count - 1)]; }
        }

        //Возращает ячейку с координатами aCoord в массиве cell из Ocean1
        public Cell getCellAt(Coordinate aCoord)
        {
            return _owner._cells[aCoord.getY(), aCoord.getX()];
        }

        //Помещает ячейку aCell в место с координатами aCoord в массиве cell из Ocean1
        public void assignCellAt(Coordinate aCoord, Cell aCell)
        {
            _owner._cells[aCoord.getY(), aCoord.getX()] = aCell;
        }

        //возращает ячейку которая находится на востоке
        Cell east()
        {
            int xvalue;
            xvalue = (_offset.getX() + 1) % _owner._numCols;
            return _owner._cells[_offset.getY(), xvalue];
        }

        Cell west()
        {
            int xvalue;
            xvalue = (_offset.getX() > 0) ? (_offset.getX() - 1) : (_owner._numCols - 1);
            return _owner._cells[_offset.getY(), xvalue];
        }

        Cell south()
        {
            int yvalue;
            yvalue = (_offset.getY() + 1) % _owner._numRows;
            return _owner._cells[yvalue, _offset.getX()];
        }

        Cell north()
        {
            int yvalue;
            yvalue = (_offset.getY() > 0) ? (_offset.getY() - 1) : (_owner._numRows - 1);
            return _owner._cells[yvalue, _offset.getX()];
        }

        //методы обработки и отбражения
        public virtual Cell reproduce(Coordinate anOffSet)
        {
            Cell temp = new Cell(anOffSet);
            return temp;
        }

        //Выводит изображение по соотвествующему смещению
        public void display()
        {
            Console.WriteLine(_image);
        }
    }
}
