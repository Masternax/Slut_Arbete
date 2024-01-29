using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Slut_Arbete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter2
{
    abstract class Enemy : PhysicalObject
    {



        public Enemy(Texture2D texture, float X, float Y, float speedX, float speedY) : base(texture, X, Y, speedX, speedY)
        {

        }
        public abstract void Update(GameWindow window);
        //{
        //    vector.X += speed.X;
        //    if (vector.X > window.ClientBounds.Width - texture.Width || vector.X < 0)
        //    {
        //        speed.X *= -1;
        //    }
        //    vector.Y += speed.Y;
        //    if (vector.Y > window.ClientBounds.Height)
        //    {
        //        isAlive = false;
        //    }
        //}
        
    }
}
