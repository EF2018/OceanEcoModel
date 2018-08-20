using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanEcoModel
{
    class Obstacle : Cell
    {
        char ObstacleImage = '#';

        public Obstacle(Coordinate aCoord)
            : base(aCoord)
        {
            _offset = aCoord;
            _image = ObstacleImage;
        }

        public Obstacle(Obstacle source)
            : base(source._offset)
        {
            //_offset = aCoord;
            //_image = ObstacleImage;
        }

        public override void Process()
        {
            // color
            //throw new NotImplementedException();
        }

        public override Cell reproduce(Coordinate anOffSet)
        {
            return new Obstacle(this);
            //throw new NotImplementedException();
        }

    }
}
