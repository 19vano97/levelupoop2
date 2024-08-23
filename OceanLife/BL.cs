using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

namespace OceanLife;

public class BL
{
    public static int GetRandomInt(int minValue = 0, int maxValue = int.MaxValue)
    {
        Random rnd = new Random();

        return rnd.Next(minValue, maxValue);
    }

    public static int GetKillsByIteration(Ocean oc)
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
                    showIndex++;
                }
            }
        }

        return showIndex;
    }

    ~BL()
    {}
}
