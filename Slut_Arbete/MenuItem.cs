using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter3
{
    class MenuItem
    {
        Texture2D texture;
        Vector2 position;
        int currentState;

        public MenuItem(Texture2D texture, Vector2 position, int currentState)
        {
            this.texture = texture;
            this.position = position;
            this.currentState = currentState;
        }

        public Texture2D Texture
        {
            get { return texture; }
        }
        public Vector2 Position
        {
            get { return position; }
        }
        public int State
        {
            get { return currentState; }
        }
    }

}
