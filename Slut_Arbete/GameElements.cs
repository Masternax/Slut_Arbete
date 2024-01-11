using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Slut_Arbete
{
    internal class GameElements
    {
        static Player player;
        
        
        public static void Initialize()
        {

        }
        public static void LoadContent(ContentManager content, GameWindow window)
        {
            player = new Player(content.Load<Texture2D>("images/player/player1"), 960, 540, 2.5f, 4.5f, content.Load<Texture2D>("images/player/bullet"));
        }
        public static void RunUpdate(ContentManager content, GameWindow window, GameTime gameTime)
        {
            
            player.Update(window, gameTime);
        }
        public static void RunDraw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch, Mouse.GetState());
        }
    }
}
