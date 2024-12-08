﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLMU
{
    public class GridWorld
    {
        public int[,] Grid { get; set; }
        public (int x, int y) AgentPosition { get; set; }
        public (int x, int y) GoalPosition { get; set; }
        public (int x, int y) Obstacle { get; set; }

        public GridWorld(int rows, int cols)
        {
            Random rnd = new Random();
            Grid = new int[rows, cols];
            AgentPosition = (0, 0);
            GoalPosition = (rows - 1, cols - 1);
            Obstacle = (1, 1);
        }

        public (int, double) TakeAction(string action)
        {
            (int x, int y) newPosition = AgentPosition;

            switch (action)
            {
                case "up": newPosition = (AgentPosition.x - 1, AgentPosition.y); break;
                case "down": newPosition = (AgentPosition.x + 1, AgentPosition.y); break;
                case "left": newPosition = (AgentPosition.x, AgentPosition.y - 1); break;
                case "right": newPosition = (AgentPosition.x, AgentPosition.y + 1); break;
            }

            if (newPosition.x >= 0 && newPosition.x < Grid.GetLength(0) &&
                newPosition.y >= 0 && newPosition.y < Grid.GetLength(1) &&
                newPosition != Obstacle)
            {
                AgentPosition = newPosition;
            }

            double reward = 0;

            if (AgentPosition == GoalPosition)
            {
                reward = 10;
            }
            else if (newPosition == Obstacle)
            {
                reward = -0.1;
            }
            else
            {
                reward = -0.1;
            }


            int state = AgentPosition.x * Grid.GetLength(1) + AgentPosition.y;

            return (state, reward);
        }

        public void PrintGrid()
        {
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    if (AgentPosition.x == i && AgentPosition.y == j)
                        Console.Write("A ");
                    else if (GoalPosition.x == i && GoalPosition.y == j)
                        Console.Write("G ");
                    else if (Obstacle.x == i && Obstacle.y == j)
                        Console.Write("| ");
                    else
                        Console.Write(". ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("----------------------------");
        }


        public bool IsGoalState() => AgentPosition == GoalPosition;
    }

}
