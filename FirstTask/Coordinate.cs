using System;
using System.Collections.Generic;
using System.Text;

namespace FirstTask
{
    class Coordinate
    {
        private List<string> _listCoordinate;

        public Coordinate(List<string> listCoordinate)
        {
            _listCoordinate = listCoordinate;
        }

        private string GetParseToFloatOrEmptyString()
        {
            string coordinatesAfterValid = string.Empty;
            foreach (var item in _listCoordinate)
            {
                string[] coordinate = item.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (coordinate.Length == 2)
                {
                    if(float.TryParse(coordinate[0].Replace('.', ','), out float x)
                        && float.TryParse(coordinate[1].Replace('.', ','), out float y))
                    {
                        x = float.Parse(coordinate[0].Replace('.', ','));
                        y = float.Parse(coordinate[1].Replace('.', ','));
                        coordinatesAfterValid += $"X: {x} Y: {y}" + "\n";
                    }
                }
            }

            return coordinatesAfterValid;
        }

        public override string ToString()
        {
            return GetParseToFloatOrEmptyString();
        }
    }
}
