using System;
using System.Collections.Generic;
using System.Text;

namespace FirstTask
{
    class Coordinate
    {
        public List<string> ListCoordinate { get; set; }

        public Coordinate(List<string> listCoordinate)
        {
            ListCoordinate = listCoordinate;
        }

        public override string ToString()
        {
            string coordinatesAfterValid = string.Empty;
            foreach (var item in ListCoordinate)
            {
                string[] coordinate = item.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if(coordinate.Length == 2)
                {
                    float x = float.Parse(coordinate[0].Replace('.', ','));
                    float y = float.Parse(coordinate[1].Replace('.', ','));
                    coordinatesAfterValid += $"X: {x} Y: {y}" + "\n";
                }
            }

            return coordinatesAfterValid;
        }
    }
}
