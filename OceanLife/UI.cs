namespace OceanLife;

public class UI
{
    public static void DisplayBorder()
    {}

    public static void DisplayCells(Ocean oc)
    {
        Console.Clear();

        for (int i = 0; i < oc.Cells.GetLength(0); i++)
        {
            for (int k = 0; k < oc.Cells.GetLength(1); k++)
            {   
                if (oc.Cells[i, k] == null)
                {
                    Console.SetCursorPosition(i, k);

                    System.Console.Write((char)Image.Cell);
                }
                else
                {
                    Console.SetCursorPosition(i, k);
                    System.Console.Write((char)oc.Cells[i, k].DefaultImage);
                }
            }
        }
    }

    public static void DisplayStats(Ocean oc, int iterations)
    {
        int x = oc.Cells.GetLength(0);
        int y = oc.Cells.GetLength(1);

        Console.SetCursorPosition(x + 10, 0);

        System.Console.WriteLine("Preys: {0}", oc.NumPrey);

        Console.SetCursorPosition(x + 10, 1);
        System.Console.WriteLine("Predators: {0}", oc.NumPredator);

        Console.SetCursorPosition(x + 10, 2);
        System.Console.WriteLine("Obstacles: {0}", oc.NumObstacles);

        Console.SetCursorPosition(x + 10, 3);
        System.Console.WriteLine("Iterations: {0}", iterations);
    }

    public static void DisplayKills(Ocean oc)
    {
        int x = oc.Cells.GetLength(0);
        int y = oc.Cells.GetLength(1);

        int showIndex = 1;

        for (int i = 0; i < x; i++)
        {
            for (int k = 0; k < y; k++)
            {
                if (oc.Cells[i, k] is Predator && oc.Cells[i, k].DoesShartkillInIteration() == true)
                {
                    IShowKill predator = (Predator)oc.Cells[i, k] as Predator;

                    Console.SetCursorPosition(x + 30, showIndex);
                    
                    System.Console.WriteLine("[{0}, {1}] {2}  killed {3}", predator.KillPlace.X, predator.KillPlace.Y, 
                                predator.Killer, predator.Victim);

                    showIndex++;
                }
            }
        }

        Console.SetCursorPosition(x + 30, 0);
        System.Console.WriteLine("Total kills in the current iteration: {0}", showIndex);
    }
}
