using System;
using System.Threading;

class Program
{
    static void Main()
    {
        int dinoPosition = 5;
        int obstaclePosition = 20;
        int obstacleWidth = 3;
        bool isJumping = false;
        int jumpHeight = 0;

        Console.Clear();
        Console.CursorVisible = false;

        while (true)
        {
            // Очистка экрана
            Console.Clear();

            // Проверка на столкновение
            if (obstaclePosition <= dinoPosition + obstacleWidth)
            {
                if (isJumping == false)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Game Over!");
                    break;
                }
            }

            // Рисование динозавра
            Console.SetCursorPosition(dinoPosition, 8 - jumpHeight);
            Console.Write("Dino");

            // Рисование препятствия
            for (int i = 0; i < obstacleWidth; i++)
            {
                Console.SetCursorPosition(obstaclePosition + i, 9);
                Console.Write("#");
            }

            // Управление
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Spacebar && isJumping == false)
                {
                    isJumping = true;
                    jumpHeight = 3;
                }
            }

            // Логика прыжка
            if (isJumping)
            {
                jumpHeight--;
                if (jumpHeight < 0)
                {
                    isJumping = false;
                }
            }

            // Движение препятствия
            obstaclePosition--;

            if (obstaclePosition < -obstacleWidth)
            {
                obstaclePosition = 20; // Сброс позиции препятствия
            }

            // Задержка для управления скоростью игры
            Thread.Sleep(100);
        }
    }
}
 