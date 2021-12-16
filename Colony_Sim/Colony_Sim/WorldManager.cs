using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colony_Sim
{
    class WorldManager : IUpdateable
    {
        private Map _map;
        private Character _character;
        private Container _uiContainer;


        List<IUpdateable> updateables;
        List<IDrawable> drawables;


        public WorldManager(Map map, Character character)
        {
            _map = map;
            //_uiContainer = container;
            _character = character;

        }

        

        public void Update(GameTime time)
        {
            //MapUtil.GetTileData(_map, Camera2d.ScreenToWorldSpace(Input.GetMousePosition()));
            
        }
    }
}
