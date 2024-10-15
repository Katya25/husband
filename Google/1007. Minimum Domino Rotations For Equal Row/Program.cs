using System;
/*
In a row of dominoes, tops[i] and bottoms[i] represent the top and bottom halves of the i'th domino. 
(A domino is a tile with two numbers from 1 to 6 - one on each half of the tile.)
We may rotate the i'th domino, so that tops[i] and bottoms[i] swap values.
Return the minimum number of rotations so that all the values in tops are the same, 
or all the values in bottoms are the same.

If it cannot be done, return -1.
*/
class Program
{
    public static int MinDominoRotations(int[] tops, int[] bottoms) {
        if(tops.Length != bottoms.Length) return -1;
        int len = tops.Length;

        int minRot = int.MaxValue;

        int t = tops[0];
        int b = bottoms[0];

        int copy = 0;

        int tCountTop = 0;
        int tCountBot = 0;
        int bCountBot = 0;
        int bCountTop = 0;

        bool isT = true;
        bool isB = true;

        for(int i = 0; i < len; i++)
        {
            if(tops[i] == bottoms[i]) copy++;
            if(isT && (tops[i] == t || bottoms[i] == t))
            {
                if(tops[i] == t) tCountTop++;
                if(bottoms[i] == t) tCountBot++;
            }
            else isT = false;
            if(isB && (tops[i] == b || bottoms[i] == b))
            {
                if(tops[i] == b) bCountTop++;
                if(bottoms[i] == b) bCountBot++;
            }
            else isB = false;
        }

        if(isT)
        {
            minRot = Math.Min(minRot, Math.Min(tCountTop-copy, tCountBot-copy));
        }
        if(isB)
        {
            minRot = Math.Min(minRot, Math.Min(bCountTop-copy, bCountBot-copy));
        }
        if(minRot == int.MaxValue) minRot = -1;

        return minRot;
    }
    static void Main()
    {
        int[] tops = { 2, 1, 2, 4, 2, 2};
        int[] bottoms = { 5, 2, 6, 2, 3, 2};
        int res = MinDominoRotations(tops, bottoms);
    }
}
