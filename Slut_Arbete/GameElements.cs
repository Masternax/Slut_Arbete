using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceShooter3;
using SpaceShooter2;
using System.Reflection.Metadata;
using static System.Net.Mime.MediaTypeNames;

namespace Slut_Arbete
{
    internal class GameElements
    {
        
        static public int tPoints;
        static Player player;
        static Background background;
        static List<Enemy> enemies;
        static PrintText printText;
        static Menu menu;
        

        public enum State { Menu, Run, HowToPlay, PrintHighScore, EnterHighScore, Quit };
        public static State currentState;
        public static void Initialize()
        {
            
        }
        public static void LoadContent(ContentManager content, GameWindow window)
        {
            player = new Player(content.Load<Texture2D>("images/player/player1"), 960, 540, 4.5f, 4.5f, content.Load<Texture2D>("images/player/bullet"));
            
            enemies = new List<Enemy>();
            Random random = new Random();
            Texture2D tmpsprite = content.Load<Texture2D>("images/enemies/mine");

            background = new Background(content.Load<Texture2D>("images/background"), window);

            for (int i = 0; i < 5; i++)
            {
                int rndX = random.Next(0, window.ClientBounds.Width - tmpsprite.Width);
                int rndY = 0;
                Mine temp = new Mine(tmpsprite, rndX, rndY);
                enemies.Add(temp);
            }

            tmpsprite = content.Load<Texture2D>("images/enemies/tripod");
            for (int i = 0; i < 5; i++)
            {
                int rndX = random.Next(0, window.ClientBounds.Width - tmpsprite.Width);
                int rndY = 0;
                Tripod temp = new Tripod(tmpsprite, rndX, rndY);
                enemies.Add(temp);
            }
            tmpsprite = content.Load<Texture2D>("images/enemies/ship");
            for (int i = 0; i < 5; i++)
            {
                int rndX = random.Next(0, window.ClientBounds.Width - tmpsprite.Width);
                int rndY = 0;
                NyEnemy temp = new NyEnemy(tmpsprite, rndX, rndY);
                enemies.Add(temp);
            }

            printText = new PrintText(content.Load<SpriteFont>("myFont4"));
            currentState = State.Menu;

            menu = new Menu((int)State.Menu);
            menu.addItem(content.Load<Texture2D>("images/menu/start"), (int)State.Run);
            menu.addItem(content.Load<Texture2D>("images/menu/highscore"), (int)State.PrintHighScore);
            menu.addItem(content.Load<Texture2D>("images/menu/HowToPlay2"), (int)State.HowToPlay);
            menu.addItem(content.Load<Texture2D>("images/menu/exit"), (int)State.Quit);
        }

        public static void skapaNya(ContentManager content, GameWindow window)
        {
            enemies.Clear();

            Random random = new Random();
            Texture2D tmpsprite = content.Load<Texture2D>("images/enemies/mine");

            for (int i = 0; i < 5; i++)
            {
                int rndX = random.Next(0, window.ClientBounds.Width - tmpsprite.Width);
                int rndY = 0;
                Mine temp = new Mine(tmpsprite, rndX, rndY);
                enemies.Add(temp);
            }

            tmpsprite = content.Load<Texture2D>("images/enemies/tripod");
            for (int i = 0; i < 5; i++)
            {
                int rndX = random.Next(0, window.ClientBounds.Width - tmpsprite.Width);
                int rndY = 0;
                Tripod temp = new Tripod(tmpsprite, rndX, rndY);
                enemies.Add(temp);
            }
            tmpsprite = content.Load<Texture2D>("images/enemies/ship");
            for (int i = 0; i < 5; i++)
            {
                int rndX = random.Next(0, window.ClientBounds.Width - tmpsprite.Width);
                int rndY = 0;
                NyEnemy temp = new NyEnemy(tmpsprite, rndX, rndY);
                enemies.Add(temp);
            }

        }

        public static State MenuUpdate(GameTime gameTime)
        {
            return (State)menu.Update(gameTime);
        }
        public static void MenuDraw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            menu.Draw(spriteBatch);
        }

        public static State HowToPlayUpdate()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                return State.Menu;
            }
            return State.HowToPlay;
        }

        public static void HowToPlayDraw(SpriteBatch spriteBatch)
        {

            printText.Print("How To Play:\n du ror dig med A W S D\n samt du skjuter med BLACKSPACE\n Du far poang genom att dod enemies", spriteBatch, 0, 0);

        }

        public static State RunUpdate(ContentManager content, GameWindow window, GameTime gameTime)
        {
           
            player.Update(window, gameTime);

            foreach (Enemy e in enemies.ToList())
            {
                foreach (Bullet b in player.Bullets)
                {
                    if (e.CheckCollision(b))
                    {
                        e.IsAlive = false;
                        player.Points++;
                    }
                }
                if (e.IsAlive)
                {
                    if (e.CheckCollision(player))
                    {
                        player.IsAlive = false;
                        e.Update(window);
                    }
                    e.Update(window);

                }
                else
                {
                    enemies.Remove(e);
                }
            }

            

            background.Update(window);

            if (enemies.Count == 0)
            {
                skapaNya(content, window);
            }

            if (!player.IsAlive)
            {
                tPoints = player.Points;
                Reset(window, content);
                return State.EnterHighScore;
            }
            return State.Run;


        }

        public static void RunDraw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            player.Draw(spriteBatch, Mouse.GetState());
            foreach (Enemy e in enemies)
            {
                e.Draw(spriteBatch);
            }
            
            printText.Print("points:" + player.Points, spriteBatch, 0, 0);

        }

        public static State HighScoreUpdate()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                return State.Menu;
            }
            return State.PrintHighScore;
        }
        public static void HighScoreDraw(SpriteBatch spriteBatch)
        {

        }

        private static void Reset(GameWindow window, ContentManager content)
        {
            player.Reset(960, 540, 4.5f, 4.5f);

            enemies.Clear();
            Random random = new Random();
            Texture2D tmpsprite = content.Load<Texture2D>("images/enemies/mine");
            for (int i = 0; i < 5; i++)
            {
                int rndX = random.Next(0, window.ClientBounds.Width - tmpsprite.Width);
                int rndY = 0;
                Mine temp = new Mine(tmpsprite, rndX, rndY);
                enemies.Add(temp);
            }
            tmpsprite = content.Load<Texture2D>("images/enemies/tripod");
            for (int i = 0; i < 5; i++)
            {
                int rndX = random.Next(0, window.ClientBounds.Width - tmpsprite.Width);
                int rndY = 0;
                Tripod temp = new Tripod(tmpsprite, rndX, rndY);
                enemies.Add(temp);
            }
            tmpsprite = content.Load<Texture2D>("images/enemies/ship");
            for (int i = 0; i < 5; i++)
            {
                int rndX = random.Next(0, window.ClientBounds.Width - tmpsprite.Width);
                int rndY = 0;
                NyEnemy temp = new NyEnemy(tmpsprite, rndX, rndY);
                enemies.Add(temp);
            }
        }

        
    }
}
