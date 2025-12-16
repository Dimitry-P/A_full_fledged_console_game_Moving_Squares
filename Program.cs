using System;
using System.Windows.Shapes;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace MovingSquares
{
    public class Program
    {
        static RenderWindow window;
        public static bool john = false;

        public static void Main()
        {
            window = new RenderWindow(new VideoMode(800, 600), "Game");
            window.Closed += Window_Closed;
            window.SetFramerateLimit(60);

            CircleShape circleqqq = new CircleShape(100);
            RectangleShape rectangleqqq = new RectangleShape(new Vector2f(200, 200));
            Game2 game2 = new Game2();
            Game game = new Game();

            while (window.IsOpen == true)
            {
                window.Clear(new Color(230, 230, 230));

                window.DispatchEvents();
                circleqqq.FillColor = Color.Cyan;
                circleqqq.Position = new SFML.System.Vector2f(100, 100);
                window.Draw(circleqqq);
                rectangleqqq.FillColor = Color.Red;
                rectangleqqq.Position = new SFML.System.Vector2f(450, 100);
                window.Draw(rectangleqqq);

                for (float i = ((circleqqq.Radius + circleqqq.Position.X) - circleqqq.Radius); i <= (circleqqq.Radius + circleqqq.Position.X + circleqqq.Radius); i++)
                {
                    for (float l = ((circleqqq.Radius + circleqqq.Position.Y) - circleqqq.Radius); l <= (circleqqq.Radius + circleqqq.Position.Y + circleqqq.Radius); l++)
                    {
                        if ((i - (circleqqq.Radius + circleqqq.Position.X)) * (i - (circleqqq.Radius + circleqqq.Position.X)) + (l - (circleqqq.Radius + circleqqq.Position.Y)) * (l - (circleqqq.Radius + circleqqq.Position.Y)) <= circleqqq.Radius * circleqqq.Radius && Mouse.IsButtonPressed(Mouse.Button.Left) == true && Mouse.GetPosition(window).X == i && Mouse.GetPosition(window).Y == l)
                        {
                            while (window.IsOpen == true)
                            {
                                window.Clear(new Color(230, 230, 230));

                                window.DispatchEvents();

                                game2.Update(window);

                                window.Display();
                            }
                        }
                    }
                }
                if (Mouse.IsButtonPressed(Mouse.Button.Left) == true && Mouse.GetPosition(window).X >= rectangleqqq.Position.X && Mouse.GetPosition(window).X <= rectangleqqq.Position.X + rectangleqqq.Size.X &&
                               Mouse.GetPosition(window).Y >= rectangleqqq.Position.Y && Mouse.GetPosition(window).Y <= rectangleqqq.Position.Y + rectangleqqq.Size.Y)
                {

                    while (window.IsOpen == true)
                    {
                        window.Clear(new Color(230, 230, 230));

                        window.DispatchEvents();

                        game.Update(window);

                        window.Display();
                    }
                }
                window.Display();
            }
        }
        private static void Window_Closed(object sender, EventArgs e)
        {
            window.Close();
        }
    }
}

