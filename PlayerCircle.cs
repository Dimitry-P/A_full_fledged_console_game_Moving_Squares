using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace MovingSquares
{
    public class PlayerCircle : Square  // делаем класс дочерним от класса Square
    { // если я создаю экземпляр класса PlayerSquare, то по сути я создаю класс Square. Чтобы его создать, нужны данные из конструктора. 
        private static Color color = new Color(50, 50, 50);
        private static float SizeStep = 10;
        private static float MinSize = 30;
        public static float BlackSquareMaxSize = 200;
        public static bool getBigger = true;
        public static bool getBiggest = false;

        public PlayerCircle(Vector2f position, int movementSpeed, IntRect movementBounds) :
            base(position, movementSpeed, movementBounds)   // вызываем родительский конструктор //// Зачем вызываем родительский конструктор?
        {
            shape.FillColor = color; // задаём серый цвет
        }

        //        //переопределяем метод OnClick
        protected override void OnClick()  //// Зачем переопределять этот метод?
        {
            Game.Scores++;
            shape.Size -= new Vector2f(30, 30); // уменьшаем размер нашего квадрата
            if (shape.Size.X < 30)
            {
                IsActive = false; // выключаем квадрат
                getBigger = true;
                return;
            }

            UpdateMovementTarget();  // обновляем координаты позиции  //// Почему этот метод встречается несколько раз в разных файлах?
            shape.Position = movementTarget; // перемещаем туда квадрат
        }

        protected override void OnReachedTarget()
        {
            if (getBiggest == true)
            {
                shape.Size = new Vector2f(200, 200);
                getBiggest = false;
            }

            if (getBigger == true && Game.timer > 0 && shape.Size.X < BlackSquareMaxSize)
                shape.Size += new Vector2f(SizeStep, SizeStep);
            if (shape.Size.X >= BlackSquareMaxSize) getBigger = false;
        }
    }
}
