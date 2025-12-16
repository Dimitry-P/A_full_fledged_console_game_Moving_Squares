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
    public class EnemyCircle : Square // делаем класс дочерним от класса Square
    {
        private static Color color = new Color(230, 50, 50);

        private float MaxSize = 250;
        private float SizeStep = 30;
        private float RedSquareMinSize = 100;
        public static int movementSpeedEnemySquare;

        public EnemyCircle(Vector2f position, int movementSpeed, IntRect movementBounds) :
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
                if (BonusCircle.perem == false)
                    BonusCircle.perem = true;
            }
        }

        protected override void OnClick()
        {
            if (shape.Size.X > RedSquareMinSize)
            {
                shape.Size -= new Vector2f(SizeStep, SizeStep);
            }
            else
            {
                Game.IsLost = true; // Если размер слишком мал, проигрываем
            }
        }

        protected override void OnReachedTarget() // при достижении цели выполнится код
        {
            if (Game.timer > 0 && Game.timer <= 3 && shape.Size.X > RedSquareMinSize)
                shape.Size -= new Vector2f(SizeStep, SizeStep);
            if (shape.Size.X < MaxSize && Game.timer == 0)
                shape.Size += new Vector2f(SizeStep, SizeStep);
            if (shape.Size.X <= MaxSize && Game.timer == 4)
                shape.Size += new Vector2f(SizeStep, SizeStep);
        }
    }
}
