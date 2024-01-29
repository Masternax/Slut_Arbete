using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Slut_Arbete
{
    internal class Background
    {
        BackgroundSprite[,] background;
        int nrBackgroundsX, nrBackgroundsY;

        public Background(Texture2D texture, GameWindow window)
        {

            double tmpX = (double)window.ClientBounds.Width / texture.Width;
            nrBackgroundsX = (int)Math.Ceiling(tmpX);
            double tmpY = (double)window.ClientBounds.Height / texture.Height;
            nrBackgroundsY = (int)Math.Ceiling(tmpY) + 1;
            background = new BackgroundSprite[nrBackgroundsX, nrBackgroundsY];

            for (int i = 0; i < nrBackgroundsX; i++)
            {
                for (int j = 0; j < nrBackgroundsY; j++)
                {
                    int posX = i * texture.Width;
                    int posY = j * texture.Height - texture.Height;
                    background[i, j] = new BackgroundSprite(texture, posX, posY);
                }
            }
        }

        public void Update(GameWindow window)
        {
            for (int i = 0; i < nrBackgroundsX; i++)
            {
                for (int j = 0; j < nrBackgroundsY; j++)
                {
                    background[i, j].Update(window, nrBackgroundsY);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < nrBackgroundsX; i++)
            {
                for (int j = 0; j < nrBackgroundsY; j++)
                {
                    background[i, j].Draw(spriteBatch);
                }
            }
        }
    }
}
