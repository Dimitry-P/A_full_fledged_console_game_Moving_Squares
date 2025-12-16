using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace MovingSquares
{
    public class BonusSquare : Circle
    {
        public static bool perem = true;
        private static float MaxMovementSpeed = 3;

        public int MovementStepRed = 1;

        private static Color color = new Color(30, 250, 20);

        public BonusSquare(Vector2f position, int movementSpeed, IntRect movementBounds) : base(position, movementSpeed, movementBounds)
        {
            shape.FillColor = color;
        }

        protected override void OnClick()
        {
            Console.WriteLine(EnemySquare.movementSpeedEnemySquare);
            if (Mouse.IsButtonPressed(Mouse.Button.Left) == true && perem)

                EnemySquare.movementSpeedEnemySquare -= 1;
            if (EnemySquare.movementSpeedEnemySquare == 0)
                EnemySquare.movementSpeedEnemySquare = 5;
            perem = false;

            PlayerSquare.getBiggest = true;
            IsActive = false;
            Game2.timer--;
        }
    }
}
