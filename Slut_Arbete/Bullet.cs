using Microsoft.Xna.Framework;
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
        Vector2 direction;

        public Bullet(Texture2D texture, float x, float y, Vector2 direction) : base(texture, x, y, 15f, 15f)
        {
            this.direction = direction;
        }

        public void Update()
        {

            vector += speed * direction;
        }
    }
}
