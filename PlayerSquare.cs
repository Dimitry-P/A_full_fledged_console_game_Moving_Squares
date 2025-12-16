using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace MovingSquares
{
    public class PlayerSquare : Circle  // делаем класс дочерним от класса Square
    { // если я создаю экземпляр класса PlayerSquare, то по сути я создаю класс Square. Чтобы его создать, нужны данные из конструктора. 
        private static Color Color = new Color(50, 50, 50);
        private static float SizeStep = 10;
        private static float MinSize = 30;
        private static float BlackSquareMaxSize = 200;
        public static bool getBigger = true;
        public static bool getBiggest = false;

        public PlayerSquare(Vector2f position, int movementSpeed, IntRect movementBounds) :
            base(position, movementSpeed, movementBounds)   // вызываем родительский конструктор //// Зачем вызываем родительский конструктор?
        {
            shape.FillColor = new Color(50, 50, 50); // задаём серый цвет
        }

        // переопределяем метод OnClick 
        protected override void OnClick()  //// Зачем переопределять этот метод?
        {
            Game2.Scores2++;
            shape.Radius -= 30; // уменьшаем размер нашего квадрата
            if (shape.Radius < 30)
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
                shape.Radius = 200;
                getBiggest = false;
            }
            if (getBigger == true && Game2.timer > 0 && shape.Radius < BlackSquareMaxSize)
                shape.Radius += SizeStep;
            if (shape.Radius >= BlackSquareMaxSize) getBigger = false;
        }
    }
}
