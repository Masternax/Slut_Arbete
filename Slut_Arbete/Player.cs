﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Slut_Arbete
{
    internal class Player : PhysicalObject
    {
        int points = 0;
        List<Bullet> bullets;
        Texture2D bulletTexture;
        double timeSinceLastBullet = 0;

        
        public Player(Texture2D texture, float X, float Y, float speedX, float speedY, Texture2D bulletTexture) : base(texture, X, Y, speedX, speedY)
        {
            bullets = new List<Bullet>();
            this.bulletTexture = bulletTexture;
        }
        public List<Bullet> Bullets
        {
            get { return bullets; }
        }

        public void Draw(SpriteBatch spriteBatch, MouseState mouse)
        {
            
            Vector2 distance;
            distance.X = mouse.X - X;
            distance.Y = mouse.Y - Y;
            float spriteRotation = (float)Math.Atan2(distance.Y, distance.X);

            spriteBatch.Draw(texture, new Vector2(X,Y), null, Color.White, spriteRotation, new Vector2(texture.Width / 2, texture.Height / 2), 0.5f, SpriteEffects.None, 0f);
            
            foreach (Bullet b in bullets)
            {
                b.Draw(spriteBatch);
            }

        }

        public void Reset(float X, float Y, float speedX, float speedY)
        {
            vector.X = X;
            vector.Y = Y;
            speed.X = speedX;
            speed.Y = speedY;
            bullets.Clear();
            timeSinceLastBullet = 0;
            points = 0;
            isAlive = true;
        }
        public void Update(GameWindow window, GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            
            MouseState mouse = Mouse.GetState();

            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                isAlive = false;
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                vector.X += speed.X;
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                vector.X -= speed.X;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                vector.Y += speed.Y;
            }
            if (keyboardState.IsKeyDown(Keys.W))
            {
                vector.Y -= speed.Y;
            }

            if (vector.X < 0)
            {
                vector.X = 0;
            }
            if (vector.X > window.ClientBounds.Width - texture.Width)
            {
                vector.X = window.ClientBounds.Width - texture.Width;
            }

            if (vector.Y < 0)
            {
                vector.Y = 0;
            }
            if (vector.Y > window.ClientBounds.Height - texture.Height)
            {
                vector.Y = window.ClientBounds.Height - texture.Height;
            }

            if (keyboardState.IsKeyDown(Keys.Space))
            {
                if (gameTime.TotalGameTime.TotalMilliseconds > timeSinceLastBullet + 200)
                {
                    Vector2 mousePosition = new Vector2(mouse.X, mouse.Y);
                    Vector2 directionToMouse = Vector2.Normalize(mousePosition - new Vector2(vector.X, vector.Y));

                    Bullet temp = new Bullet(bulletTexture, vector.X, vector.Y, directionToMouse);
                    bullets.Add(temp);
                    timeSinceLastBullet = gameTime.TotalGameTime.TotalMilliseconds;
                }

            }
            foreach (Bullet b in bullets.ToList())
            {
                b.Update();
                if (!b.IsAlive)
                {
                    bullets.Remove(b);
                }
            }



        }
        public int Points
        {
            get { return points; }
            set { points = value; }
        }
    }
}
