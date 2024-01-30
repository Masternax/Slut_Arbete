using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static Slut_Arbete.GameElements;

namespace Slut_Arbete
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        HighScore highscore;
        SpriteFont myFont4;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.ApplyChanges();
            this.IsMouseVisible= true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            GameElements.currentState = GameElements.State.Run;
            highscore = new HighScore(100);
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            GameElements.LoadContent(Content, Window);
            myFont4 = Content.Load<SpriteFont>("myFont4");

            highscore.LoadFromFile("highscore.txt");
            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            highscore.SaveToFile("highscore.txt");

            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                this.Exit();
            }
            switch (GameElements.currentState)
            {
                case GameElements.State.Run:
                    GameElements.currentState = GameElements.RunUpdate(Content, Window, gameTime);
                    break;
                case GameElements.State.EnterHighScore:
                    if (highscore.EnterUpdate(gameTime, tPoints))
                        GameElements.currentState = GameElements.State.PrintHighScore;
                    break;
                case GameElements.State.PrintHighScore:
                    KeyboardState keyboardState = Keyboard.GetState();
                    if (keyboardState.IsKeyDown(Keys.Escape))
                    {
                        currentState = State.Menu;
                    }
                    break;

                case GameElements.State.HowToPlay:
                    GameElements.currentState = GameElements.HowToPlayUpdate();
                    break;


                case GameElements.State.Quit:
                    this.Exit();
                    break;
                default:
                    GameElements.currentState = GameElements.MenuUpdate(gameTime);
                    break;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            switch (GameElements.currentState)
            {
                case GameElements.State.Run:
                    GameElements.RunDraw(spriteBatch);
                    break;

                case GameElements.State.EnterHighScore:
                    highscore.EnterDraw(spriteBatch, myFont4);
                    break;

                case GameElements.State.PrintHighScore:
                    highscore.PrintDraw(spriteBatch, myFont4);
                    break;

                case GameElements.State.HowToPlay:
                    GameElements.HowToPlayDraw(spriteBatch);
                    break;

                case GameElements.State.Quit:
                    this.Exit();
                    break;

                default:
                    GameElements.MenuDraw(spriteBatch);
                    break;
            }

            spriteBatch.End();

            base.Draw(gameTime);

            
        }
    }
}