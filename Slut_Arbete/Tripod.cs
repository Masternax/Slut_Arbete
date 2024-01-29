using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter2
{
    class Tripod : Enemy
    {
        public Tripod(Texture2D texture, float X, float Y) : base(texture, X, Y, 0f, 6f)
        {

        }
        public override void Update(GameWindow window)
        {
            vector.Y += speed.Y;
            if(vector.Y > window.ClientBounds.Height)
            {
                isAlive = false;
            }
        }
    }
}
