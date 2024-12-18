using LLMU;
using System.Diagnostics;

GridWorld env = new GridWorld(4, 4);
QLearningAgent agent = new QLearningAgent();

int numEpisodes = 100;
double alpha = 0.3, gamma = 0.7, epsilon = 0.1;

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

        //System.Threading.Thread.Sleep(100);
    }

    epsilon = Math.Max(0.01, epsilon * 0.99);

    Console.WriteLine("Goal Reached!");
    Console.WriteLine();
}


GridWorld gridWorld = new GridWorld(6, 6);
double epsilon2 = 0.1;

for (int episode = 0; episode < numEpisodes; episode++)
{
    Console.WriteLine($"Episode {episode + 1}");

    gridWorld.AgentPosition = (0, 0);
    int state = 0;

    while (!gridWorld.IsGoalState())
    {
        gridWorld.PrintGrid();

        string action = agent.ChooseAction(state, epsilon2);
        var (nextState, reward) = gridWorld.TakeAction(action);
        agent.UpdateQValue(state, action, reward, nextState, alpha, gamma);
        state = nextState;

        //System.Threading.Thread.Sleep(100);
    }

    epsilon2 = Math.Max(0.01, epsilon2 * 0.99);

    Console.WriteLine("Global 2 Reached");
    Console.WriteLine();
}

GridWorld gridWorld2 = new GridWorld(8, 8);
double epsilon3 = 0.1;

for (int episode = 0; episode < numEpisodes; episode++)
{
    Console.WriteLine($"Episode {episode + 1}");

    gridWorld2.AgentPosition = (0, 0);
    int state = 0;

    while (!gridWorld2.IsGoalState())
    {
        gridWorld2.PrintGrid();

        string action = agent.ChooseAction(state, epsilon3);
        var (nextState, reward) = gridWorld2.TakeAction(action);
        agent.UpdateQValue(state, action, reward, nextState, alpha, gamma);
        state = nextState;

        //System.Threading.Thread.Sleep(100);
    }

    epsilon3 = Math.Max(0.01, epsilon3 * 0.99);

    Console.WriteLine("Global 2 Reached");
    Console.WriteLine();
}

GridWorld gridWorld3 = new GridWorld(5, 5);
double epsilon4 = 0.1;

Stopwatch stopwatch = new Stopwatch();

stopwatch.Start();

for (int episode = 0; episode < 1; episode++)
{
    Console.WriteLine($"Episode {episode + 1}");

    gridWorld3.AgentPosition = (0, 0);
    int state = 0;

    while (!gridWorld3.IsGoalState())
    {
        gridWorld3.PrintGrid();

        string action = agent.ChooseAction(state, epsilon4);
        var (nextState, reward) = gridWorld3.TakeAction(action);
        agent.UpdateQValue(state, action, reward, nextState, alpha, gamma);
        state = nextState;

        System.Threading.Thread.Sleep(200);
    }

    epsilon4 = Math.Max(0.01, epsilon4 * 0.99);

    Console.WriteLine("Global 2 Reached");
    Console.WriteLine();
}

stopwatch.Stop();

Console.WriteLine($"Time Of Ex for : {stopwatch.ElapsedMilliseconds}");