﻿using Microsoft.Xna.Framework;
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
                tileData = map.MapData[(int)screenToWorldMapIndex.X, (int)screenToWorldMapIndex.Y];
                return tileData;
            }
            else
                return null;
        }
    }
}
