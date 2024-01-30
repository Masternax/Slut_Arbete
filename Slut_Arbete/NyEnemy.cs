using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceShooter2;

namespace Slut_Arbete
{
    class NyEnemy : Enemy
    {
        public NyEnemy(Texture2D texture, float X, float Y) : base(texture, X, Y, 5f, 5f)
        {

        }
        public override void Update(GameWindow window)
        {
            vector.X += speed.X;
            vector.Y += speed.Y;

            if (vector.X > window.ClientBounds.Width - texture.Width || vector.X < 0)
            {
                speed.X *= -1;
            }
            vector.Y += speed.Y;
            if (vector.Y > window.ClientBounds.Height)
            {
                isAlive = false;
            }
        }
    }
}
