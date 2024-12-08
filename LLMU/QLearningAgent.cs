using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLMU
{
    public class QLearningAgent
    {
        private Dictionary<(int state, string action), double> QTable;
        private string[] Actions = { "up", "down", "left", "right" };
        private Random Random;

        public QLearningAgent()
        {
            QTable = new Dictionary<(int, string), double>();
            Random = new Random();
        }

        public string ChooseAction(int state, double epsilon)
        {
            if (Random.NextDouble() < epsilon)
                return Actions[Random.Next(Actions.Length)];

            var stateActions = QTable.Where(q => q.Key.state == state);
            if (stateActions.Any())
            {
                return stateActions.OrderByDescending(q => q.Value).First().Key.action;
            }
            else
            {
                return Actions[Random.Next(Actions.Length)];
            }
        }

        public void UpdateQValue(int state, string action, double reward, int nextState, double alpha, double gamma)
        {
            double maxNextQ = QTable.Where(q => q.Key.state == nextState).Select(q => q.Value).DefaultIfEmpty(0).Max();

            QTable[(state, action)] = QTable.GetValueOrDefault((state, action), 0) +
                alpha * (reward + gamma * maxNextQ - QTable.GetValueOrDefault((state, action), 0));
        }

    }

}
