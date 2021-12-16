using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colony_Sim
{
    static class MapUtil
    {

        static public string GetTileData(Map map, Vector2 screenToWorldMapIndex)
        {
            screenToWorldMapIndex = map.GetMapIndex(screenToWorldMapIndex);
            string tileData;
            if (map.IsWithinMapBounds(screenToWorldMapIndex))
            {
                tileData = map.MapData[(int)screenToWorldMapIndex.X, (int)screenToWorldMapIndex.Y].Type.ToString();
                return tileData;
            }
            else
                return "not within bounds";
        }
    }
}
