using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slut_Arbete
{
    class Bullet : PhysicalObject
    {
        public Bullet(Texture2D texture, float x, float y) : base(texture, x, y, 0, 3f)
        {

        }
        public void Update()
        {
            
            
            vector.Y -= speed.Y;


            if (vector.Y < 0)
            {
                isAlive = false;
            }
        }
    }
}
