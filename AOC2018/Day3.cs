using System.Collections.Generic;

namespace AOC2018
{
    public class Day3 : DayBase
    {
        public override string Part1(string claims)
        {
            var santaFabric = new Dictionary<int, Dictionary<int, int>>();
            const int clothDimensions = 1000;
            var overlap = 0;

            foreach (var claimStr in claims.Split('\n'))
            {
                var c = new Claim(claimStr); //parse and create object.
                for (var x = c.LeftEdgeSpan; x < c.LeftEdgeSpan + c.Width; ++x)
                for (var y = c.TopEdgeSpan; y < c.TopEdgeSpan + c.Height; ++y)
                {
                    if (!santaFabric.TryGetValue(x, out var clothY))
                    {
                        //We haven't hit this cord yet, set new set at location
                        clothY = new Dictionary<int, int>();
                        santaFabric[x] = clothY;
                    }

                    //If we don't have height cords setup, 
                    if (!clothY.TryGetValue(y, out var gridAtLocation)) gridAtLocation = 0;

                    ++gridAtLocation;
                    clothY[y] = gridAtLocation;
                }
            }

            //Traverse Santa's fabric square 1 increment at a time, first right and then down
            for (var x = 0; x < clothDimensions; ++x)
            for (var y = 0; y < clothDimensions; ++y)
            {
                if (!santaFabric.TryGetValue(x, out var xLookup))
                    continue; //No Hit, don't count
                if (!xLookup.TryGetValue(y, out var yLookup))
                    continue; //No Hit, don't count
                if (yLookup > 1) overlap++; //Overlapping cord.
            }

            return overlap.ToString();
        }

        public override string Part2(string input)
        {
            return null;
        }

        public class Claim
        {
            public int Height;
            public int Id;
            public int LeftEdgeSpan;
            public int TopEdgeSpan;
            public int Width;

            public Claim(string claimLine)
            {
                var parts = claimLine.Split(' ');
                var claim = parts[2].Remove(parts[2].Length - 1, 1).Split(',');
                var size = parts[3].Split('x');

                Id = int.Parse(parts[0].Remove(0, 1));
                LeftEdgeSpan = int.Parse(claim[0]);
                TopEdgeSpan = int.Parse(claim[1]);
                Width = int.Parse(size[0]);
                Height = int.Parse(size[1]);
            }
        }
    }
}