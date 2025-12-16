using MovingSquares;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

public class SquareList //// Зачем мы создаём дополнительный класс SquareList?
{
    public static List<Square> squares;

    public Square RemovedSquare;
    public bool SquareHasRemoved;

    //// Здесь мы снова создаём список квадратов? И снова помещаем в переменную squares? Зачем?
    //// Здесь мы снова создаём список квадратов? И снова помещаем в переменную squares? Зачем?
    ///

    public SquareList()
    {
        squares = new List<Square>();
    }

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
    public void SpawnEnemyCircle()
    {
        squares.Add(new EnemyCircle(
            new Vector2f(Mathf.Random.Next(0, 800), Mathf.Random.Next(0, 600)),
            5,
            new IntRect(0, 0, 800, 600))
            );
    }
    public void SpawnPlayerCircle()
    {
        squares.Add(new PlayerCircle(
            new Vector2f(Mathf.Random.Next(0, 800), Mathf.Random.Next(0, 600)),
            5,
            new IntRect(0, 0, 800, 600))
            );
    }
    public void SpawnBonusCircle()
    {
        squares.Add(new BonusCircle(
            new Vector2f(Mathf.Random.Next(0, 800), Mathf.Random.Next(0, 600)),
            5,
            new IntRect(0, 0, 800, 600))
            );
    }
}