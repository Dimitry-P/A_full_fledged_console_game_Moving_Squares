using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace MovingSquares
{
    public static class Mathf
    {
        public static Random Random = new Random();

        public static Vector2f MoveTowards(Vector2f current, Vector2f target, int maxDistanceDelta)
        {
            Vector2f dir = target - current; // это вектор направления, 
            float magnitude = (float)Math.Sqrt(dir.X * dir.X + dir.Y * dir.Y); // длина вектора нормализованная
            if (magnitude <= maxDistanceDelta || magnitude == 0f)
            {
                return target; // если длина вектора равна минимальному шагу, то тогда позиция равна целевой позиции
            }

            // в противном случае до целевой точки мы должны двигать наш квадрат:
            return current + dir / magnitude * maxDistanceDelta;
        }
    }
}
