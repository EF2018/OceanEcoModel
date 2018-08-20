using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanEcoModel
{
    class Prey : Cell
    {
        protected int _timeToReproduce;
        //public char DefaultPreyImage = 'f';

        public Prey(Coordinate aCoord) : base(aCoord)//, char image) :base(offset, image)
        {
            _offset = aCoord;
            _image = DefaultPreyImage;
            _timeToReproduce = 6;
        }


        //Методы отображения и выполнения
        //Перемещается, если возможно  в пустую ячейку (север-юг-запад-восто), уменьшает timeToReoproduce на 1
        public override void Process()
        {
            Coordinate toCoord;
            toCoord = getEmptyNeightborCoord();
            moveFrom(_offset, toCoord);
        }

        //Перемещает из координат from в координаты to в массиве cells из Ocean1 
        public void moveFrom(Coordinate from, Coordinate to)
        {
            Cell toCell;
            --_timeToReproduce;
            if (to != from)
            {
                toCell = getCellAt(to);
                setOffSet(to);//в ячейку устанавливаются новые координаты ячейки в которую перемещаемся 
                assignCellAt(to, this);
                if (_timeToReproduce <= 0)
                {
                    _timeToReproduce = 6;//_timeToReproduce = _timeToReproduce
                    assignCellAt(from, reproduce(from));
                }
                else
                {
                    assignCellAt(from, new Cell(from));
                }
            }
        }

        //Воспроизводит себя в ячейке с координатами anOffSet в массиве cells из Ocean1
        public override Cell reproduce(Coordinate anOffSet)
        {
            Prey temp = new Prey(anOffSet);
            _owner.setNumPrey(_owner.getNumPrey() + 1);
            return (Cell)temp;
        }
    }
}
