using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanEcoModel
{
    class Coordinate
    {
        public int X;
        public int Y;

        public Coordinate(int aX, int aY)
        {
            X = aX;
            Y = aY;
        }

        public Coordinate()
        {
            X = 0;
            Y = 0;
        }

        public Coordinate(Coordinate aCoord)
        {
            X = aCoord.X;
            Y = aCoord.Y;
        }

        //методы доступа
        public int getX()
        {
            return X;
        }

        public int getY()
        {
            return Y;
        }

        public void setX(int aX)
        {
            X = aX;
        }

        public void setY(int aY)
        {
            Y = aY;
        }

        //методы присвоения и сравнения
        //public static Cell operator =(Coordinate aCoord)
        //{
        //    X = aCoord.X;
        //    Y = aCoord.Y;
        //}

        //int operator ==(Coordinate c)
        //{
        //    return (X == c.X && Y == c.Y);
        //}

        //int operator !=(Coordinate c)
        //{
        //    return (X != c.X || Y != c.Y);
        //}

    }
}
