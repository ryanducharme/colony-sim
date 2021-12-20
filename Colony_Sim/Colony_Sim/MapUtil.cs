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

        static public Tile GetTileData(Map map, Vector2 screenToWorldMapIndex)
        {
            screenToWorldMapIndex = map.GetMapIndex(screenToWorldMapIndex);
            Tile tileData;
            if (map.IsWithinMapBounds(screenToWorldMapIndex))
            {
                tileData = map.TerrainLayer[(int)screenToWorldMapIndex.X, (int)screenToWorldMapIndex.Y];
                return tileData;
            }
            else
                return new Tile(TileType.Empty);
        }
    }
}
