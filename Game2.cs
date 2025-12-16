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
    public class Game2
    {
        //public const string Filename = "D:\\Visual Studio\\MovingSquares - Моё задание То, что сдал. Окончательный\\MovingSquares\\bin\\Debug";
        public Font mainFont;
        public static int Scores2;  // кол-во очков
        public static bool IsLost;  // проиграли или нет?

        public Text scoreText;
        public Text loseText;
        public int MaxScore;

        public SquareList2 squares = new SquareList2();

        public Game2() //// Для чего нам здесь нужен конструктор, ведь мы здесь не создаём никакого объекта?
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

            Reset(); //// Зачем здесь писать метод Reset?
        }

        //// Почему у нас 2 метода Reset?
        public void Reset()   // будет чистить список квадратов
        {
            squares.Reset();  // сбрасываем очки
            Scores2 = 0;
            IsLost = false;

            squares.SpawnPlayerSquare();
            squares.SpawnEnemySquare();
        }
        protected Clock bonusClock = new Clock();
        protected float bonusSpawnInterval = 15f;
        public static int timer = 0;

        public void Update(RenderWindow window)  //// Зачем нам 2 метода public void Update?
        {
            if (IsLost == true)
            {
                window.Draw(loseText);
                if (Scores2 > MaxScore)
                    MaxScore = Scores2;  // обновляем максимальные очки

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
                    squares.SpawnBonusSquare();
                    timer++;

                    bonusClock.Restart();
                    bonusSpawnInterval = new Random().Next(10, 20);
                    squares.Update(window);
                }

                if (squares.SquareHasRemoved == true && squares.RemovedSquare is PlayerSquare)
                {
                    squares.SpawnPlayerSquare();
                }
            }

            scoreText.DisplayedString = "Score: " + Scores2.ToString() + "\nMax: " + MaxScore.ToString();
            window.Draw(scoreText);
        }
    }
}
