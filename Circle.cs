using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using MovingSquares;
using SFML.Graphics;
using SFML.System;

namespace MovingSquares
{
    public class Circle //// Для чего вообще нам нужен этот класс?
    {
        public static int DefaultSize = 100;
        public bool IsActive = true;

        public CircleShape shape; //// Мы же уже сделали список квадратов, зачем нам еще раз делать квадрат?
                                  //// Мы же уже сделали список квадратов, зачем нам еще раз делать квадрат?
        public int movementSpeed;
        protected Vector2f movementTarget;
        protected IntRect movementBounds;

        public Circle(Vector2f position, int movementSpeed, IntRect movementBounds)  //// Что делает этот конструктор?
        {
            shape = new CircleShape(DefaultSize);

            //// Зачем нам создавать DefaultSize? Можно ли размеры задать сразу в RectangleShape?
            shape.Position = position;

            this.movementSpeed = movementSpeed;
            this.movementBounds = movementBounds;

            UpdateMovementTarget();
        }

        public virtual void Move()
        {
            shape.Position = Mathf.MoveTowards(shape.Position, movementTarget, movementSpeed);
            if (shape.Position == movementTarget)
            {
                OnReachedTarget();
                UpdateMovementTarget(); // обновляем положение нашего таргета
            }
        }

        public void Draw(RenderWindow window)// передаём в метод Draw то место, где мы хотим его нарисовать
        {
            if (IsActive == false) return;
            window.Draw(shape);  // подаю в этот метод свой shape
        }

        // метод, который будет проверять позицию:
        public void CheckMousePosition(Vector2i mousePos) // подаём в вметод позицию мышки
        {
            if (IsActive == false) return; // если квадрат неактивен, то мы выходим из метода
            if (mousePos.X > shape.Position.X && mousePos.X < shape.Position.X + shape.Radius * 2 &&
                mousePos.Y > shape.Position.Y && mousePos.Y < shape.Position.Y + shape.Radius * 2)
                OnClick();
        }

        protected void UpdateMovementTarget() //// Не понятно, что мы делаем здесь?
        {
            movementTarget.X = Mathf.Random.Next(movementBounds.Left, movementBounds.Left + movementBounds.Width);
            movementTarget.Y = Mathf.Random.Next(movementBounds.Top, movementBounds.Top + movementBounds.Height);
        }
        // Создаём 2 виртуальных метода, 
        //которые будут вызываться при клике на квадрат и при достижении цели
        protected virtual void OnClick()
        {

        }  //// Не понятно, что мы делаем здесь?
        protected virtual void OnReachedTarget() { } //// Не понятно, что мы делаем здесь?
    }
}
