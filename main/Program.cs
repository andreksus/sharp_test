// See https://aka.ms/new-console-template for more information
using System.Transactions;

Console.WriteLine("Hello, World!");
int[] array = { 0, 1, 1, 1, 1, 1, 1, 1, 1, 2 };
Console.WriteLine(ChipDistribution.MinChipMoves(array));
public class ChipDistribution
{
    public static int MinChipMoves(int[] chips)
    {
        int n = chips.Length;
        int sum = chips.Sum();
        int avgChip = sum / n;

        int moves = 0;
        int indexCounter = 1;
        int movesCounter = 1;
        int maxChip = 0;
        int indexMaxChip = 0;

        while (chips.Max() > avgChip)
        {
            maxChip = 0;
            for (int i = 0; i < n; i++)
            {
                if (chips[i] > maxChip)
                {
                    maxChip = chips[i];
                    indexMaxChip = i;
                }
            }

            while (chips[indexMaxChip] > avgChip)
            {
                int indexNextChip = GetIndexNextChip(n, indexMaxChip, indexCounter);
                while (chips[indexNextChip] < avgChip)
                {
                    if (chips[indexMaxChip] == avgChip)
                    {
                        break;
                    }
                    chips[indexNextChip]++;
                    chips[indexMaxChip]--;
                    moves += movesCounter;
                }

                int indexPrevChip = GetIndexPrevChip(n, indexMaxChip, indexCounter);
                while (chips[indexPrevChip] < avgChip)
                {
                    if (chips[indexMaxChip] == avgChip)
                    {
                        break;
                    }
                    chips[indexPrevChip]++;
                    chips[indexMaxChip]--;
                    moves += movesCounter;
                }
                indexCounter++;
                movesCounter++;
            }
            indexCounter = 1;
            movesCounter = 1;

        }

        return moves;
    }

    public static int GetIndexNextChip(int lengthChips, int currentIndex, int indexCounter)
    {
        return (currentIndex + indexCounter) % lengthChips;
    }

    public static int GetIndexPrevChip(int lengthChips, int currentIndex, int indexCounter)
    {
        if (currentIndex < indexCounter)
        {
            return lengthChips + (currentIndex - indexCounter);
        }
        else
        {
            return currentIndex - indexCounter;
        }

    }
}