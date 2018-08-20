using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanEcoModel
{
    class Predator : Prey
    {
        public char DefaultPredImage = '>';
        protected int _timeToFeed;

        #region CTORs
        // Переустанавливает экземпляр переменной image
        public Predator(Coordinate aCoord)
            : base(aCoord)
        {
            _offset = aCoord;
            _image = DefaultPredImage;
            _timeToFeed = 6;
        }
        #endregion

        public override void Process()
        {
            Coordinate toCoord;
            if (--_timeToFeed <= 0)//хищник умирает
            {
                assignCellAt(_offset, new Cell(_offset));
                //assignCellAt(_offset, null);
                _owner.setNumPredators(_owner.getNumPredators() - 1);
            }
            else
            {
                toCoord = getPreyNeightborCoord();
                if (toCoord != _offset)
                {
                    _owner.setNumPrey(_owner.getNumPrey() - 1);
                    _timeToFeed = 6;//_timeToFeed = _timeToFeed
                    moveFrom(_offset, toCoord);
                }
                else //если возможно перемещается в пустую ячейку(с-ю-з-в) и --timeToReproduce
                {
                    //--_timeToReproduce;
                    base.Process();
                }
            }
        }

        //воспроизводит себя в ячейке с координатами anOffSet в массиве cell из Ocean1
        public override Cell reproduce(Coordinate anOffSet)
        {
            Predator temp = new Predator(anOffSet);
            _owner.setNumPredators(_owner.getNumPredators() + 1);
            return (Cell)temp;
        }
    }
}
