using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Threading;

namespace MovingSquares
{
    public class Game
    {
        //public const string Filename = "D:\\Visual Studio\\MovingSquares - Моё задание То, что сдал. Окончательный\\MovingSquares\\bin\\Debug";
        public SquareList squares = new SquareList();
        public static int Scores;  // кол-во очков
        public static bool IsLost;  // проиграли или нет?

        public Font mainFont;
        public Text scoreText;
        public Text loseText;
        public int MaxScore;

        public Square RemovedSquare;

        public Game()
        {
            mainFont = new Font("john.ttf");
            scoreText = new Text();
            scoreText.Font = mainFont;
            scoreText.FillColor = Color.Black;
            scoreText.CharacterSize = 16;
            scoreText.Position = new Vector2f(10, 10);

            loseText = new Text();
            loseText.Font = mainFont;
            loseText.FillColor = Color.Black;
            loseText.DisplayedString = "Ты проиграл, нажми R, чтобы перезапустить игру";
            loseText.Position = new Vector2f(20, 290);

            Reset();
        }

        //// Почему у нас 2 метода Reset?
        public void Reset()   // будет чистить список квадратов
        {
            squares.Reset();  // сбрасываем очки
            Scores = 0;
            IsLost = false;

            squares.SpawnPlayerCircle();

            squares.SpawnEnemyCircle();
        }
        private Clock bonusClock = new Clock();
        private float bonusSpawnInterval = 15f;
        public static int timer = 0;

        public void Update(RenderWindow window)  //// Зачем нам 2 метода public void Update?
        {
            if (IsLost == true)
            {
                window.Draw(loseText);

                if (Scores > MaxScore)
                    MaxScore = Scores;  // обновляем максимальные очки

                if (Keyboard.IsKeyPressed(Keyboard.Key.R) == true)
                {
                    Reset();
                    timer = 0;
                }
            }
            else
            {
                // пробросим обновление списка квадратов в методе апдейт
                //  то есть апдейт игры будет вызывать апдейт списка квадратов, а апдейт списка квадратов будет вызывать у всех квадратов методы Move и Draw

                squares.Update(window);

                if (bonusClock.ElapsedTime.AsSeconds() >= bonusSpawnInterval && timer < 4)
                {
                    squares.SpawnBonusCircle();
                    timer++;

                    bonusClock.Restart();
                    bonusSpawnInterval = new Random().Next(10, 20);
                    squares.Update(window);
                }

                if (squares.SquareHasRemoved == true && squares.RemovedSquare is PlayerCircle)
                {
                    squares.SpawnPlayerCircle();
                }
            }

            scoreText.DisplayedString = "Score: " + Scores.ToString() + "\nMax: " + MaxScore.ToString();
            window.Draw(scoreText);
        }
    }
}
