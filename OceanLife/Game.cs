namespace OceanLife;

public class Game
{
    public Game()
    {
        Ocean oc = new Ocean();

        // TODO: input num of iterations manually

        //def
        int iteration = Consts.OCEAN_ITERATION;
        int totalKills = 0;

        oc.Init();

        do
        {
            Console.Clear();

            oc.MoveAnimals();

            UI.DisplayCells(oc);
            UI.DisplayStats(oc, iteration);
            UI.DisplayKills(oc);

            totalKills += BL.GetKillsByIteration(oc);

            oc.Update();
            oc.MoveNextIteration();
            iteration--;

            Thread.Sleep(100);
            
        } while (iteration != 0);
        // } while (iteration != 0 | oc.NumPrey != 0 | oc.NumPredator != 0);

        Console.Clear();
        System.Console.WriteLine("Total kills: {0}", totalKills);
    }

    ~Game()
    {}
}
