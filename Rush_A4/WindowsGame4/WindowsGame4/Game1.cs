using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
// Chad Rush
namespace WindowsGame4
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // music from Longzijun.wordpress.com

        public static Player player1 = new Player();

        Texture2D castlePlace;
        Texture2D plainsPlace;
        Texture2D plainsGrass;
        Texture2D forestPlace;
        Texture2D cavePlace;

        Texture2D allyKing;

        Texture2D metalGauge;
        Texture2D lifeGreen;
        Texture2D lifeYellowGreen;
        Texture2D lifeYellow;
        Texture2D lifeOrange;
        Texture2D lifeRed;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Transitions.CastleBGM = Content.Load<Song>("bgmusic01 (chill)");
            Transitions.PlainsBGM = Content.Load<Song>("bgmusic22 (As long as a word remains unspoken)");
            Transitions.ForestBGM = Content.Load<Song>("bgmusic17 (elegy)");
            Transitions.CaveBGM = Content.Load<Song>("bgmusic14 Arpology 2 (Ambient Synth version)");

            castlePlace = Content.Load<Texture2D>("Castle1_25x25_800x600");
            plainsPlace = Content.Load<Texture2D>("Plains1_25x25_800x600");
            plainsGrass = Content.Load<Texture2D>("GrassTop");
            forestPlace = Content.Load<Texture2D>("Forest1_25x25_800x600");
            cavePlace = Content.Load<Texture2D>("Cave1_25x25_800x600");

            metalGauge = Content.Load<Texture2D>("MetalGauge");
            lifeGreen = Content.Load<Texture2D>("LifeGreen");
            lifeYellowGreen = Content.Load<Texture2D>("LifeYellowGreen");
            lifeYellow = Content.Load<Texture2D>("LifeYellow");
            lifeOrange = Content.Load<Texture2D>("LifeOrange");
            lifeRed = Content.Load<Texture2D>("LifeRed");

            Spear.Spear1_Texture = Content.Load<Texture2D>("Spear1");
            Spear.Spear2_Texture = Content.Load<Texture2D>("Spear2");
            Spear.Spear3_Texture = Content.Load<Texture2D>("Spear3");
            Spear.Spear4_Texture = Content.Load<Texture2D>("Spear4");
            Spear.Spear5_Texture = Content.Load<Texture2D>("Spear5");
            Spear.Spear6_Texture = Content.Load<Texture2D>("Spear6");
            Spear.Spear7_Texture = Content.Load<Texture2D>("Spear7");

            TheEnemy.EnemyBrown = Content.Load<Texture2D>("enemyBrown_triangle");
            TheEnemy.EnemyGreenBrown = Content.Load<Texture2D>("enemyGreenBrown_triangle");
            TheEnemy.EnemyNormal = Content.Load<Texture2D>("enemyNormal_triangle");
            TheEnemy.EnemyGuard = Content.Load<Texture2D>("enemyGuard_triangle");
            TheEnemy.EnemyKnight = Content.Load<Texture2D>("enemyKnight_triangle");
            TheEnemy.EnemyEliteKnight = Content.Load<Texture2D>("enemyEliteKnight_triangle");

            player1.Player_texture = Content.Load<Texture2D>("player1_triangle");

            allyKing = Content.Load<Texture2D>("allyKing_triangle");

            TheEnemy.Initialize();

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            Transitions.Places();

            Transitions.Transition();

            Collisions.PlayerCheck();

            Collisions.EnemyCheck();

            Collisions.Combat();

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                player1.Player_x -= (Math.Sin(player1.Player_rotation) * 1);
                player1.Player_y -= (Math.Cos(player1.Player_rotation) * 1);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                player1.Player_x += (Math.Sin(player1.Player_rotation) * 1);
                player1.Player_y += (Math.Cos(player1.Player_rotation) * 1);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                player1.Player_rotation -= 0.05f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                player1.Player_rotation += 0.05f;
            }

            // TODO: Add your update logic here

            player1.Update();

            TheEnemy.Update();

            Spear.Update();

            base.Update(gameTime);

            this.Draw(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            int transmatrix = Transitions.TransCounter + 1;

            if (Transitions.Location == 1)
            {
                if (Transitions.Trans1 == true)
                {
                    spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Matrix.CreateTranslation(new Vector3((transmatrix * 16), 0, 0)));
                    spriteBatch.Draw(castlePlace, new Vector2(0, 0), Color.White);
                    spriteBatch.Draw(plainsPlace, new Vector2(-800, 0), Color.White);
                    spriteBatch.End();
                }
                else if (Transitions.Trans3 == true)
                {
                    spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Matrix.CreateTranslation(0, (-transmatrix * 12), 0));
                    spriteBatch.Draw(castlePlace, new Vector2(0, 0), Color.White);
                    spriteBatch.Draw(forestPlace, new Vector2(0, 600), Color.White);
                    spriteBatch.End();
                }
                else if (Transitions.Trans5 == true)
                {
                    spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Matrix.CreateTranslation(new Vector3((-transmatrix * 16), 0, 0)));
                    spriteBatch.Draw(castlePlace, new Vector2(0, 0), Color.White);
                    spriteBatch.Draw(cavePlace, new Vector2(800, 0), Color.White);
                    spriteBatch.End();
                }
                else
                {
                    spriteBatch.Begin();
                    spriteBatch.Draw(castlePlace, new Vector2(0, 0), Color.White);
                    spriteBatch.Draw(player1.Player_texture, new Rectangle((int)player1.Player_x, (int)player1.Player_y, 25, 25), null, Color.White, -(player1.Player_rotation), new Vector2(13, 13), SpriteEffects.None, 0.01f);
                    if (Spear.SpearLength > 0)
                    {
                        spriteBatch.Draw(Spear.Spear_Texture, new Rectangle((int)Spear.SpearCenterX, (int)Spear.SpearCenterY, Spear.Spear_Texture.Width, Spear.Spear_Texture.Height), null, Color.White, -(Spear.SpearRotation), new Vector2(Spear.Spear_Texture.Width / 2, Spear.Spear_Texture.Height / 2), SpriteEffects.None, 0);
                    }
                    spriteBatch.Draw(allyKing, new Rectangle(738, 63, 25, 25), null, Color.White, (float)Math.PI, new Vector2(13, 13), SpriteEffects.None, 0);
                    spriteBatch.Draw(metalGauge, new Rectangle(20, 575, 110, 25), null, Color.White);
                    switch (player1.Health/200)
                    {
                        case 5:
                        case 4:
                            spriteBatch.Draw(lifeGreen, new Rectangle(25, 580, (player1.Health/10), 15), null, Color.White);
                            break;
                        case 3:
                            spriteBatch.Draw(lifeYellowGreen, new Rectangle(25, 580, (player1.Health / 10), 15), null, Color.White);
                            break;
                        case 2:
                            spriteBatch.Draw(lifeYellow, new Rectangle(25, 580, (player1.Health / 10), 15), null, Color.White);
                            break;
                        case 1:
                            spriteBatch.Draw(lifeOrange, new Rectangle(25, 580, (player1.Health / 10), 15), null, Color.White);
                            break;
                        default:
                            spriteBatch.Draw(lifeRed, new Rectangle(25, 580, (player1.Health / 10), 15), null, Color.White);
                            break;
                    }
                    spriteBatch.End();
                }
            }
            else if (Transitions.Location == 2)
            {
                if (Transitions.Trans2 == true)
                {
                    spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Matrix.CreateTranslation(new Vector3((800 - (transmatrix * 16)), 0, 0)));
                    spriteBatch.Draw(castlePlace, new Vector2(0, 0), Color.White);
                    spriteBatch.Draw(plainsPlace, new Vector2(-800, 0), Color.White);
                    spriteBatch.End();
                }
                else
                {
                    spriteBatch.Begin();
                    spriteBatch.Draw(plainsPlace, new Vector2(0, 0), Color.White);
                    spriteBatch.Draw(player1.Player_texture, new Rectangle((int)player1.Player_x, (int)player1.Player_y, 25, 25), null, Color.White, -(player1.Player_rotation), new Vector2(13, 13), SpriteEffects.None, 0.01f);
                    if (Spear.SpearLength > 0)
                    {
                        spriteBatch.Draw(Spear.Spear_Texture, new Rectangle((int)Spear.SpearCenterX, (int)Spear.SpearCenterY, Spear.Spear_Texture.Width, Spear.Spear_Texture.Height), null, Color.White, -(Spear.SpearRotation), new Vector2(Spear.Spear_Texture.Width / 2, Spear.Spear_Texture.Height / 2), SpriteEffects.None, 0);
                    }
                    foreach (Enemy e in TheEnemy.PlainsEnemyArray)
                    {
                        if (e.Health > 0)
                        {
                            spriteBatch.Draw(e.Enemy_texture, new Rectangle((int)e.Enemy_x, (int)e.Enemy_y, 25, 25), null, Color.White, e.Enemy_rotation, new Vector2(e.EnemyRect.Width / 2, e.EnemyRect.Height / 2), SpriteEffects.None, 0.02f);
                        }
                    }
                    spriteBatch.Draw(metalGauge, new Rectangle(20, 575, 110, 25), null, Color.White);
                    switch (player1.Health / 200)
                    {
                        case 5:
                        case 4:
                            spriteBatch.Draw(lifeGreen, new Rectangle(25, 580, (player1.Health / 10), 15), null, Color.White);
                            break;
                        case 3:
                            spriteBatch.Draw(lifeYellowGreen, new Rectangle(25, 580, (player1.Health / 10), 15), null, Color.White);
                            break;
                        case 2:
                            spriteBatch.Draw(lifeYellow, new Rectangle(25, 580, (player1.Health / 10), 15), null, Color.White);
                            break;
                        case 1:
                            spriteBatch.Draw(lifeOrange, new Rectangle(25, 580, (player1.Health / 10), 15), null, Color.White);
                            break;
                        default:
                            spriteBatch.Draw(lifeRed, new Rectangle(25, 580, (player1.Health / 10), 15), null, Color.White);
                            break;
                    }
                    spriteBatch.End();
                }
            }
            else if (Transitions.Location == 3)
            {
                if (Transitions.Trans4 == true)
                {
                    spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Matrix.CreateTranslation(new Vector3(0, (-600 + (transmatrix * 12)), 0)));
                    spriteBatch.Draw(castlePlace, new Vector2(0, 0), Color.White);
                    spriteBatch.Draw(forestPlace, new Vector2(0, 600), Color.White);
                    spriteBatch.End();
                }
                else
                {
                    spriteBatch.Begin();
                    spriteBatch.Draw(forestPlace, new Vector2(0, 0), Color.White);
                    spriteBatch.Draw(player1.Player_texture, new Rectangle((int)player1.Player_x, (int)player1.Player_y, 25, 25), null, Color.White, -(player1.Player_rotation), new Vector2(13, 13), SpriteEffects.None, 0.01f);
                    if (Spear.SpearLength > 0)
                    {
                        spriteBatch.Draw(Spear.Spear_Texture, new Rectangle((int)Spear.SpearCenterX, (int)Spear.SpearCenterY, Spear.Spear_Texture.Width, Spear.Spear_Texture.Height), null, Color.White, -(Spear.SpearRotation), new Vector2(Spear.Spear_Texture.Width / 2, Spear.Spear_Texture.Height / 2), SpriteEffects.None, 0);
                    }
                    foreach (Enemy e in TheEnemy.ForestEnemyArray)
                    {
                        if (e.Health > 0)
                        {
                            spriteBatch.Draw(e.Enemy_texture, new Rectangle((int)e.Enemy_x, (int)e.Enemy_y, 25, 25), null, Color.White, e.Enemy_rotation, new Vector2(e.EnemyRect.Width / 2, e.EnemyRect.Height / 2), SpriteEffects.None, 0.02f);
                        }
                    }
                    spriteBatch.Draw(metalGauge, new Rectangle(20, 575, 110, 25), null, Color.White);
                    switch (player1.Health / 200)
                    {
                        case 5:
                        case 4:
                            spriteBatch.Draw(lifeGreen, new Rectangle(25, 580, (player1.Health / 10), 15), null, Color.White);
                            break;
                        case 3:
                            spriteBatch.Draw(lifeYellowGreen, new Rectangle(25, 580, (player1.Health / 10), 15), null, Color.White);
                            break;
                        case 2:
                            spriteBatch.Draw(lifeYellow, new Rectangle(25, 580, (player1.Health / 10), 15), null, Color.White);
                            break;
                        case 1:
                            spriteBatch.Draw(lifeOrange, new Rectangle(25, 580, (player1.Health / 10), 15), null, Color.White);
                            break;
                        default:
                            spriteBatch.Draw(lifeRed, new Rectangle(25, 580, (player1.Health / 10), 15), null, Color.White);
                            break;
                    }
                    spriteBatch.End();
                }
            }
            else if (Transitions.Location == 4)
            {
                if (Transitions.Trans6 == true)
                {
                    spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Matrix.CreateTranslation(new Vector3((-800 + (transmatrix * 16)), 0, 0)));
                    spriteBatch.Draw(castlePlace, new Vector2(0, 0), Color.White);
                    spriteBatch.Draw(cavePlace, new Vector2(800, 0), Color.White);
                    spriteBatch.End();
                }
                else
                {
                    spriteBatch.Begin();
                    spriteBatch.Draw(cavePlace, new Vector2(0, 0), Color.White);
                    spriteBatch.Draw(player1.Player_texture, new Rectangle((int)player1.Player_x, (int)player1.Player_y, 25, 25), null, Color.White, -(player1.Player_rotation), new Vector2(13, 13), SpriteEffects.None, 0.01f);
                    if (Spear.SpearLength > 0)
                    {
                        spriteBatch.Draw(Spear.Spear_Texture, new Rectangle((int)Spear.SpearCenterX, (int)Spear.SpearCenterY, Spear.Spear_Texture.Width, Spear.Spear_Texture.Height), null, Color.White, -(Spear.SpearRotation), new Vector2(Spear.Spear_Texture.Width / 2, Spear.Spear_Texture.Height / 2), SpriteEffects.None, 0);
                    }
                    spriteBatch.Draw(metalGauge, new Rectangle(20, 575, 110, 25), null, Color.White);
                    switch (player1.Health / 200)
                    {
                        case 5:
                        case 4:
                            spriteBatch.Draw(lifeGreen, new Rectangle(25, 580, (player1.Health / 10), 15), null, Color.White);
                            break;
                        case 3:
                            spriteBatch.Draw(lifeYellowGreen, new Rectangle(25, 580, (player1.Health / 10), 15), null, Color.White);
                            break;
                        case 2:
                            spriteBatch.Draw(lifeYellow, new Rectangle(25, 580, (player1.Health / 10), 15), null, Color.White);
                            break;
                        case 1:
                            spriteBatch.Draw(lifeOrange, new Rectangle(25, 580, (player1.Health / 10), 15), null, Color.White);
                            break;
                        default:
                            spriteBatch.Draw(lifeRed, new Rectangle(25, 580, (player1.Health / 10), 15), null, Color.White);
                            break;
                    }
                    spriteBatch.End();
                }
            }

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
