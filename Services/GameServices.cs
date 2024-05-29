using ParImpar.Models;
using System;

namespace ParImpar.Services
{
    public class GameService
    {
        private static Player Player1 = new Player();
        private static string Player2Choice;
        private static string Result;
        private static readonly Random Random = new Random();

        public void SetPlayer1Name(string name)
        {
            Player1.Name = name;
        }

        public string PlayGame(string player1Choice)
        {
            Player1.Choice = player1Choice.ToLower();

            // Player 2 is decided by the machine
            Player2Choice = (Player1.Choice == "par") ? "impar" : "par";

            int dice1 = Random.Next(1, 7);
            int dice2 = Random.Next(1, 7);
            int sum = dice1 + dice2;
            bool isEven = sum % 2 == 0;

            if ((isEven && Player1.Choice == "par") || (!isEven && Player1.Choice == "impar"))
            {
                Result = $"{Player1.Name} wins!";
            }
            else
            {
                Result = "Player 2 wins!";
            }

            return Result;
        }

        public object GetGameState()
        {
            int dice1 = Random.Next(1, 7);
            int dice2 = Random.Next(1, 7);
            int sum = dice1 + dice2;

            return new
            {
                Player1Name = Player1.Name,
                Player1Choice = Player1.Choice,
                Player2Choice,
                Dice1 = dice1,
                Dice2 = dice2,
                Total = sum,
                Result
            };
        }


        public string GetStatus()
        {
            return Result ?? "No game has been played yet.";
        }

        public void ResetGame()
        {
            Player1.Choice = null;
            Player2Choice = null;
            Result = null;
        }
    }
}
