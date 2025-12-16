using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using SFML.Graphics;
using SFML.System;

namespace MovingSquares
{
    public class EnemySquare : Circle // делаем класс дочерним от класса Square
    {
        private static Color color = new Color(230, 50, 50);

        private float MaxSize = 150;
        private float SizeStep = 10;
        private float RedSquareMinSize = 70;
        public static int movementSpeedEnemySquare;

        public EnemySquare(Vector2f position, int movementSpeed, IntRect movementBounds) :
            base(position, movementSpeed, movementBounds)
        {
            shape.FillColor = color; // задаём серый цвет
            movementSpeedEnemySquare = movementSpeed;
        }

        public override void Move()
        {
            shape.Position = Mathf.MoveTowards(shape.Position, movementTarget, movementSpeedEnemySquare);

            if (shape.Position == movementTarget)
            {

                OnReachedTarget();
                UpdateMovementTarget(); // обновляем положение нашего таргета
                if (BonusSquare.perem == false)
                    BonusSquare.perem = true;
            }
        }

        protected override void OnClick()
        {
            if (shape.Radius > RedSquareMinSize)
            {
                shape.Radius -= SizeStep;
            }
            else
            {
                Game2.IsLost = true; // Если размер слишком мал, проигрываем
            }
        }

        protected override void OnReachedTarget() // при достижении цели выполнится код
        {
            if (Game2.timer > 0 && Game2.timer <= 3 && shape.Radius > RedSquareMinSize)
                shape.Radius -= SizeStep;
            if (shape.Radius < MaxSize && Game2.timer == 0)
                shape.Radius += SizeStep;
            if (shape.Radius <= MaxSize && Game.timer == 4)
                shape.Radius += SizeStep;
        }
    }
}
