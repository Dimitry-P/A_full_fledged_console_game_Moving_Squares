using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MovingSquares;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace MovingSquares
{
    public class SquareList2 //// Зачем мы создаём дополнительный класс SquareList?
    {
        public static List<Circle> squares;
        public bool SquareHasRemoved;
        public Circle RemovedSquare;

        //// Здесь мы снова создаём список квадратов? И снова помещаем в переменную squares? Зачем?
        //// Здесь мы снова создаём список квадратов? И снова помещаем в переменную squares? Зачем?
        ///

        public SquareList2()
        {
            squares = new List<Circle>();
        }

        // метод очистки
        public void Reset()
        {
            SquareHasRemoved = false;
            RemovedSquare = null;  //// Почему здесь значение null?
            squares.Clear();  //// Что делаем здесь?
        }

        public void Update(RenderWindow window) // нам нужно обновлять квадраты
        {
            SquareHasRemoved = false;
            RemovedSquare = null;

            if (Mouse.IsButtonPressed(Mouse.Button.Left) == true)
            {
                for (int i = 0; i < squares.Count; i++)
                {
                    squares[i].CheckMousePosition(Mouse.GetPosition(window));  //// Который squares используется здесь?
                }
            }

            for (int i = 0; i < squares.Count; i++)
            {
                squares[i].Move();
                squares[i].Draw(window);

                if (squares[i].IsActive == false) //// Откуда берётся переменная IsActive? И что мы здесь делаем?
                {
                    RemovedSquare = squares[i];

                    squares.Remove(squares[i]);

                    SquareHasRemoved = true;
                }
            }
        }

        public void SpawnPlayerSquare() //// что такое Add? что оно делает?
        {
            squares.Add(new PlayerSquare(new Vector2f(Mathf.Random.Next(0, 800), Mathf.Random.Next(0, 600)), 5, new IntRect(0, 0, 800, 600)));
        }

        public void SpawnEnemySquare()
        {
            squares.Add(new EnemySquare(
                new Vector2f(Mathf.Random.Next(0, 800), Mathf.Random.Next(0, 600)),
                5,
                new IntRect(0, 0, 800, 600))
                );
        }
        public void SpawnBonusSquare()
        {
            squares.Add(new BonusSquare(new Vector2f(Mathf.Random.Next(0, 800), Mathf.Random.Next(0, 600)), 5, new IntRect(0, 0, 800, 600)));

        }
    }
}

