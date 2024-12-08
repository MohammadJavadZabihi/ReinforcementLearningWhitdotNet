using LLMU;

GridWorld env = new GridWorld(4, 4);
QLearningAgent agent = new QLearningAgent();

int numEpisodes = 1000;
double alpha = 0.1, gamma = 0.9, epsilon = 0.1;

for (int episode = 0; episode < numEpisodes; episode++)
{
    env.AgentPosition = (0, 0);
    int state = 0;

    Console.WriteLine($"Episode {episode + 1}");
    while (!env.IsGoalState())
    {
        env.PrintGrid();

        string action = agent.ChooseAction(state, epsilon);
        var (nextState, reward) = env.TakeAction(action);
        agent.UpdateQValue(state, action, reward, nextState, alpha, gamma);
        state = nextState;

        System.Threading.Thread.Sleep(100);
    }

    Console.WriteLine("Goal Reached!");
    Console.WriteLine();
}

