using System;
using System.Linq;
using System.IO;
using System.Threading;
using System.Collections.Generic;

namespace GameFinal
{
   
    class Game
    {

        static Random randomGenerator = new Random();       

        static int gameScore = 0;
        static int gameWidth = 40;
        static int gameHeight = 15;
        static int gameSpeed = 350;
        static int gameLevel = 1;

        static Frog GFrog = new Frog();
        static int FrogLives = 3;

        static List<Car> cars = new List<Car>();
        //static ConsoleColor[] carColors = { ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue, ConsoleColor.Cyan, ConsoleColor.White, ConsoleColor.Yellow };
        static bool collisionFlag = false;


        static void Main()
        {          
            GameSize();
            Player();
            DisplayMenu();
        }
        public static void StartNewGame()
        {
            Console.Clear();
            PrintingString(10, 6, "Сложно".ToUpper(), ConsoleColor.Yellow);
            PrintingString(10, 8, "Очень сложно".ToUpper());
            PrintingString(10, 10, "Не нажимать".ToUpper());

            Console.CursorVisible = false;
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.Enter)
            {  
                Console.Clear();
                Level1();
            }
            else
            {
                if (key.Key == ConsoleKey.DownArrow)
                {
                    PrintingString(10, 6, "Сложно".ToUpper(), ConsoleColor.White);
                    PrintingString(10, 8, "Очень сложно".ToUpper(), ConsoleColor.Yellow);
                    PrintingString(10, 10, "Не нажимать".ToUpper(), ConsoleColor.White);


                    Console.WriteLine();
                    key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        Level2();
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.DownArrow)
                        {
                            PrintingString(10, 6, "Сложно".ToUpper(), ConsoleColor.White);
                            PrintingString(10, 8, "Очень сложно".ToUpper(), ConsoleColor.White);
                            PrintingString(10, 10, "не нажимать".ToUpper(), ConsoleColor.Yellow);


                            Console.WriteLine();
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Enter)
                            {
                                Console.Clear();
                                Level3();
                            }
                            else
                            {
                                Console.Clear();
                                StartNewGame();
                            }

                        }
                        else
                        {
                            Console.Clear();
                            StartNewGame();
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    StartNewGame();
                }
            }
        }

        public static void Level1()
        {
            while (true)
            {
                Console.Clear();
                CarsMove();
                Displacement();

                CarsLev1();
                DetectCollision();

                PrintingString(40, 4, "Осталось жизней: " + FrogLives);
                PrintingString(40, 6, "Счёт: " + gameScore);
                PrintingString(40, 8, "Уровень: " + gameLevel);

                Thread.Sleep(gameSpeed);

                collisionFlag = false;
            }
        }

        public static void Level2()
        {
            while (true)
            {
                Console.Clear();
                CarsMove();
                Displacement();

                CarsLev2();
                DetectCollision();

                PrintingString(40, 4, "Осталось жизней: " + FrogLives);
                PrintingString(40, 6, "Счёт: " + gameScore);
                PrintingString(40, 8, "Уровень: " + gameLevel);

                Thread.Sleep(gameSpeed - 50);

                collisionFlag = false;
            }
        }

        public static void Level3()
        {
            while (true)
            {
                Console.Clear();
                CarsMove();
                Displacement();

                CarsLev3();
                DetectCollision();

                PrintingString(40, 4, "Осталось жизней: " + FrogLives);
                PrintingString(40, 6, "Счёт: " + gameScore);
                PrintingString(40, 8, "Уровень: " + gameLevel);

                Thread.Sleep(gameSpeed - 200);

                collisionFlag = false;
            }
        }

        static void DisplayMenu()
        {
            Console.Clear();
            PrintingString(10, 6, "Новая игра".ToUpper(), ConsoleColor.Yellow);
            PrintingString(10, 8, "Турнирная таблица".ToUpper());
            PrintingString(10, 10, "Правила игры".ToUpper());



            Console.CursorVisible = false;
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.Enter)
            {  
                Console.Clear();
                StartNewGame();
            }
            else
            {
                if (key.Key == ConsoleKey.DownArrow)
                {
                    PrintingString(10, 6, "Новая игра".ToUpper(), ConsoleColor.White);
                    PrintingString(10, 8, "Турнирная таблица".ToUpper(), ConsoleColor.Yellow);
                    PrintingString(10, 10, "Правила игры".ToUpper(), ConsoleColor.White);

                    Console.SetCursorPosition(10, 8);
                    key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        Standings();
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.DownArrow)
                        {
                            PrintingString(10, 6, "Новая игра".ToUpper(), ConsoleColor.White);
                            PrintingString(10, 8, "Турнирная таблица".ToUpper(), ConsoleColor.White);
                            PrintingString(10, 10, "Правила игры".ToUpper(), ConsoleColor.Yellow);


                            Console.WriteLine();
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Enter)
                            {
                                Console.Clear();
                                DisplayRules();
                            }
                            else
                            {
                                if (key.Key == ConsoleKey.DownArrow)
                                {
                                    PrintingString(10, 6, "Новая игра".ToUpper(), ConsoleColor.White);
                                    PrintingString(10, 8, "Турнирная таблица".ToUpper(), ConsoleColor.White);
                                    PrintingString(10, 10, "Правила игры".ToUpper(), ConsoleColor.White);


                                    Console.WriteLine();
                                    key = Console.ReadKey();
                                    if (key.Key == ConsoleKey.Enter)
                                    {
                                        Console.Clear();

                                    }
                                    else
                                    {
                                        Console.Clear();
                                        DisplayMenu();
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    DisplayMenu();
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    DisplayMenu();
                }
            }
        }



        static void DisplayRules()
        {           
            Console.Clear();
            Console.WriteLine(@"
Привет, это Жабка.
Вы - зелёная точечка посередине экрана.
Ваша задача провести жабку через автомагистраль. 
У вас есть три уровня сложноти и на каждом по три жизни.
Удачи!
            ");
            Console.WriteLine("\tНажмите Enter для выхода в главное меню\n");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                DisplayMenu();
            }
            else
            {
                DisplayRules();
            }
        }

        static void LevelUp()
        {
            if (GFrog.y == 0)
            {
                gameSpeed -= 50;
                if (gameSpeed < 100)
                {
                    gameSpeed = 100;
                }
                gameScore += 50 * gameLevel;
                cars.Clear();
                Player();
                gameLevel++;
            }
        }
        static void PrintingString(int x, int y, string str, ConsoleColor color = ConsoleColor.White)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(str);
        }
        static void Player()
        {
            GFrog.x = 15;
            GFrog.y = gameHeight;
            GFrog.bodySymbol = (char)1;
            GFrog.color = ConsoleColor.Green;
        }
        struct Frog
        {
            public int x;
            public int y;
            public char bodySymbol;
            public ConsoleColor color;
        }
        static void Displacement()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                while (Console.KeyAvailable) Console.ReadKey(true);

                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (GFrog.x > 3)
                        GFrog.x--;
                }
                if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (GFrog.x < gameWidth - 3)
                        GFrog.x++;
                }
                if (pressedKey.Key == ConsoleKey.UpArrow)
                {
                    if (GFrog.y > 0)
                    {
                        GFrog.y--;
                        gameScore++;
                    }
                }
                if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    if (GFrog.y < gameHeight)
                    {
                        GFrog.y++;
                        gameScore--;
                    }
                }
            }
            LevelUp();
            PrintAtPosition(GFrog.x, GFrog.y, GFrog.bodySymbol, GFrog.color);
        }


        static void CarsLev1()
        {
            Car newEnemyCar = new Car();
            newEnemyCar.y = randomGenerator.Next(4, 8);
            if (newEnemyCar.y % 2 == 1)
            {
                newEnemyCar.x = 1;
                newEnemyCar.vector = 1;
            }
            else
            {
                newEnemyCar.x = gameWidth - 5;
                newEnemyCar.vector = -1;
            }
            newEnemyCar.width = randomGenerator.Next(1, 3);
            newEnemyCar.color = ConsoleColor.Red;

            newEnemyCar.symbol = '█';
            cars.Add(newEnemyCar);

            foreach (Car currentCar in cars)
            {
                PrintAtPosition(currentCar.x, currentCar.y, currentCar.symbol, currentCar.color, currentCar.width);
            }
        }

        static void CarsLev2()
        {
            Car newEnemyCar = new Car();
            newEnemyCar.y = randomGenerator.Next(1, gameHeight);
            if (newEnemyCar.y % 2 == 1)
            {
                newEnemyCar.x = 3;
                newEnemyCar.vector = 1;
            }
            else
            {
                newEnemyCar.x = gameWidth - 8;
                newEnemyCar.vector = -1;
            }
            newEnemyCar.width = randomGenerator.Next(1, 4);
            newEnemyCar.color = ConsoleColor.Red;

            newEnemyCar.symbol = '█';
            cars.Add(newEnemyCar);

            foreach (Car currentCar in cars)
            {
                PrintAtPosition(currentCar.x, currentCar.y, currentCar.symbol, currentCar.color, currentCar.width);
            }
        }

        static void CarsLev3()
        {
            Car newEnemyCar = new Car();
            newEnemyCar.y = randomGenerator.Next(1, gameHeight);
            if (newEnemyCar.y % 2 == 1)
            {
                newEnemyCar.x = 3;
                newEnemyCar.vector = 4;
            }
            else
            {
                newEnemyCar.x = 22;
                newEnemyCar.vector = -2;
            }
            newEnemyCar.width = randomGenerator.Next(1, 5);
            newEnemyCar.color = ConsoleColor.Red;

            newEnemyCar.symbol = '█';
            cars.Add(newEnemyCar);

            foreach (Car currentCar in cars)
            {
                PrintAtPosition(currentCar.x, currentCar.y, currentCar.symbol, currentCar.color, currentCar.width);
            }
        }

        static void DetectCollision()
        {
            for (int i = 0; i < cars.Count; i++)
            {
                if ((GFrog.x >= cars[i].x && GFrog.x <= cars[i].x + cars[i].width - 1) && cars[i].y == GFrog.y)
                { 
                    collisionFlag = true;                  
                    FrogLives--;
                    if (FrogLives != 0)
                    {
                        PrintAtPosition(GFrog.x, GFrog.y, 'X', ConsoleColor.Red);
                    }
                    else
                    {
                        GameOver();
                    }
                }
            }
            if (collisionFlag)
            {
                Console.Beep();
                Player();
            }
        }

        static void CarsMove()
        {
            for (int i = 0; i < cars.Count; i++)
            {
                cars[i].MoveCar();

                if (cars[i].x >= gameWidth - 5 || cars[i].x <= 0)
                {
                    cars.Remove(cars[i]);
                    i--;
                }
            }
        }

        static void PrintAtPosition(int x, int y, char symbol, ConsoleColor color, int elementBodyWidth = 1)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            for (int len = 0; len < elementBodyWidth; len++)
            {
                Console.Write(symbol);
            }
        }

        static void GameSize()
        {
            Console.CursorVisible = false;
            Console.WindowWidth = gameWidth + 20;
            Console.BufferWidth = Console.WindowWidth;
            Console.WindowHeight = gameHeight + 4;
            Console.BufferHeight = gameHeight + 4;
        }

        static void Standings()
        {
            Console.WriteLine("\tТоп 10 игроков:");

            TextReader scoreReader = new StreamReader("../../Scores.txt");
            string line = scoreReader.ReadLine();
            Dictionary<string, int> scores = new Dictionary<string, int>();

            while (line != null)
            {
                string[] currentScorer = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (!scores.ContainsKey(currentScorer[0]))
                {
                    scores.Add(currentScorer[0], int.Parse(currentScorer[1]));
                }
                else
                {
                    scores[currentScorer[0]] = int.Parse(currentScorer[1]);
                }
                line = scoreReader.ReadLine();
            }

            int scorePlace = 1;
            foreach (var item in scores.OrderByDescending(key => key.Value).Select(x => string.Format("{0} - {1}", x.Key, x.Value)))
            {
                Console.WriteLine(scorePlace + ". " + item);
                scorePlace++;
                if (scorePlace > 10)
                {
                    break;
                }
            }
            scoreReader.Close();

            Console.WriteLine("\nНажмите для выхода в главное меню\n");
            ConsoleKeyInfo pressedKey = Console.ReadKey();
            if (pressedKey.Key == ConsoleKey.Enter)
            {
                DisplayMenu();
            }
            else
            {
                Console.Clear();
                Standings();
            }
        }

        static void GameOver()
        {
            
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Спасибо за игру!\nВаш счёт: " + gameScore);
            string playerName = string.Empty;
            while (true)
            {
                try
                {
                    Console.WriteLine("\nВведите ваше имя");
                    playerName = Console.ReadLine();
                    if (playerName.IndexOf(' ') >= 0)
                    {
                        throw new ArgumentException("Имя должно быть без пробелов. Попробуйте ещё раз.");
                    }
                    else if (playerName.Length <= 0)
                    {
                        throw new ArgumentException("Строка не должна остаться пустой.");
                    }
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            var scoreWriter = new StreamWriter("../../Scores.txt", true);
            scoreWriter.WriteLine(playerName + " " + gameScore);
            scoreWriter.Close();
            Console.WriteLine("\nНажмите Enter чтобы вернуться в главное меню");

            gameScore = 0;
            gameLevel = 1;
            cars.Clear();
            FrogLives = 3;
            gameSpeed = 300;

            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.Enter)
            {
                DisplayMenu();
            }
        }
    }
    class Car
    {
        public int x;
        public int y;
        public int width;
        public int vector;
        public char symbol;
        public ConsoleColor color;

        public void MoveCar()
        {
            x += vector;
        }
    }
}