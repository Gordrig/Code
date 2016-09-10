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

namespace WindowsGame4
{
    class Collisions
    {
        // Castle area collision boxes
        private static Rectangle CastleWestWallNorth = new Rectangle(125, 0, 25, 150);
        private static Rectangle CastleWestWallSouth = new Rectangle(125, 225, 25, 125);
        private static Rectangle CastleSouthWallWest = new Rectangle(125, 325, 150, 25);
        private static Rectangle CastleSouthWallEast = new Rectangle(350, 325, 450, 25);
        private static Rectangle CastleNorthWall = new Rectangle(125, 0, 675, 25);
        private static Rectangle CastleEastWall = new Rectangle(775, 0, 25, 350);
        private static Rectangle CastleInnerWallNorth = new Rectangle(550, 0, 25, 125);
        private static Rectangle CastleInnerWallSouth = new Rectangle(550, 200, 25, 150);
        private static Rectangle CastleKingWallNorth = new Rectangle(675, 0, 25, 150);
        private static Rectangle CastleKingWallWest = new Rectangle(675, 175, 25, 100);
        private static Rectangle CastleKingWallSouth = new Rectangle(675, 225, 125, 25);
        private static Rectangle CastleBit1 = new Rectangle(150, 75, 25, 25);
        private static Rectangle CastleBit2 = new Rectangle(200, 0, 25, 100);
        private static Rectangle CastleBit3 = new Rectangle(200, 75, 50, 25);
        private static Rectangle CastleBit4 = new Rectangle(275, 75, 75, 25);
        private static Rectangle CastleBit5 = new Rectangle(325, 0, 25, 125);
        private static Rectangle CastleBit6 = new Rectangle(325, 100, 75, 25);
        private static Rectangle CastleBit7 = new Rectangle(425, 100, 75, 25);
        private static Rectangle CastleBit8 = new Rectangle(475, 0, 25, 125);
        private static Rectangle CastleBit9 = new Rectangle(125, 250, 50, 25);
        private static Rectangle CastleBit10 = new Rectangle(200, 250, 25, 100);
        private static Rectangle CastleBit11 = new Rectangle(350, 250, 25, 100);
        private static Rectangle CastleBit12 = new Rectangle(400, 250, 50, 25);
        private static Rectangle CastleBit13 = new Rectangle(425, 250, 25, 100);
        private static Rectangle CastleBit14 = new Rectangle(475, 250, 50, 25);
        private static Rectangle CastleBit15 = new Rectangle(500, 250, 25, 100);
        private static Rectangle CastleBit16 = new Rectangle(675, 300, 25, 25);
        private static Rectangle CastleNorthBounds = new Rectangle(0, 0, 800, 25);
        private static Rectangle CastleWestBoundsNorth = new Rectangle(0, 0, 25, 150);
        private static Rectangle CastleWestBoundsSouth = new Rectangle(0, 225, 25, 375);
        private static Rectangle CastleSouthBoundsWest = new Rectangle(0, 550, 275, 50);
        private static Rectangle CastleSouthBoundsEast = new Rectangle(350, 550, 450, 50);
        private static Rectangle CastleEastBoundsSouth = new Rectangle(775, 500, 25, 100);
        private static Rectangle CastleEastBoundsNorth = new Rectangle(775, 0, 25, 425);


        // Array to hold the castle collision boxes
        private static Rectangle[] castleRectArray = new Rectangle[34] { CastleWestWallNorth, CastleWestWallSouth, CastleSouthWallWest, CastleSouthWallEast, CastleNorthWall, CastleEastWall, CastleInnerWallNorth, CastleInnerWallSouth, CastleKingWallNorth, CastleKingWallWest, CastleKingWallSouth, CastleBit1, CastleBit2, CastleBit3, CastleBit4, CastleBit5, CastleBit6, CastleBit7, CastleBit8, CastleBit9, CastleBit10, CastleBit11, CastleBit12, CastleBit13, CastleBit14, CastleBit15, CastleBit16, CastleNorthBounds, CastleWestBoundsNorth, CastleWestBoundsSouth, CastleSouthBoundsWest, CastleSouthBoundsEast, CastleEastBoundsSouth, CastleEastBoundsNorth };

        // Plains area collision boxes
        private static Rectangle PlainsNorthBounds = new Rectangle(0, 0, 800, 25);
        private static Rectangle PlainsWestBounds = new Rectangle(0, 0, 25, 600);
        private static Rectangle PlainsSouthBounds = new Rectangle(0, 575, 800, 25);
        private static Rectangle PlainsEastBoundsSouth = new Rectangle(775, 225, 25, 375);
        private static Rectangle PlainsEastBoundsNorth = new Rectangle(775, 0, 25, 150);
        private static Rectangle PlainsBit1 = new Rectangle(75, 75, 25, 50);
        private static Rectangle PlainsBit2 = new Rectangle(100, 125, 25, 25);
        private static Rectangle PlainsBit3 = new Rectangle(125, 150, 25, 25);
        private static Rectangle PlainsBit4 = new Rectangle(150, 175, 125, 25);
        private static Rectangle PlainsBit5 = new Rectangle(250, 200, 25, 75);
        private static Rectangle PlainsBit6 = new Rectangle(250, 0, 25, 125);
        private static Rectangle PlainsBit7 = new Rectangle(175, 100, 75, 25);
        private static Rectangle PlainsBit8 = new Rectangle(150, 75, 25, 25);
        private static Rectangle PlainsBit9 = new Rectangle(0, 275, 125, 50);
        private static Rectangle PlainsBit10 = new Rectangle(0, 325, 75, 75);
        private static Rectangle PlainsBit11 = new Rectangle(150, 275, 50, 50);
        private static Rectangle PlainsBit12 = new Rectangle(200, 275, 75, 125);
        private static Rectangle PlainsBit13 = new Rectangle(0, 525, 75, 75);
        private static Rectangle PlainsBit14 = new Rectangle(200, 525, 100, 75);
        private static Rectangle PlainsBit15 = new Rectangle(250, 450, 50, 75);
        private static Rectangle PlainsBit16 = new Rectangle(250, 400, 25, 50);
        private static Rectangle PlainsBit17 = new Rectangle(300, 450, 25, 25);
        private static Rectangle PlainsBit18 = new Rectangle(350, 450, 25, 25);
        private static Rectangle PlainsBit19 = new Rectangle(375, 450, 25, 50);
        private static Rectangle PlainsBit20 = new Rectangle(375, 500, 50, 100);
        private static Rectangle PlainsBit21 = new Rectangle(300, 550, 75, 50);
        private static Rectangle PlainsBit22 = new Rectangle(100, 375, 25, 25);
        private static Rectangle PlainsBit23 = new Rectangle(150, 375, 25, 25);
        private static Rectangle PlainsBit24 = new Rectangle(50, 425, 25, 75);
        private static Rectangle PlainsBit25 = new Rectangle(100, 525, 75, 25);
        private static Rectangle PlainsBit26 = new Rectangle(200, 425, 25, 75);
        private static Rectangle PlainsBit27 = new Rectangle(425, 475, 75, 25);
        private static Rectangle PlainsBit28 = new Rectangle(475, 475, 75, 25);
        private static Rectangle PlainsBit29 = new Rectangle(525, 400, 25, 75);
        private static Rectangle PlainsBit30 = new Rectangle(550, 400, 50, 25);
        private static Rectangle PlainsBit31 = new Rectangle(650, 400, 150, 25);

        // Array to hold the plains collision boxes
        private static Rectangle[] plainsRectArray = new Rectangle[36] { PlainsNorthBounds, PlainsWestBounds, PlainsSouthBounds, PlainsEastBoundsSouth, PlainsEastBoundsNorth, PlainsBit1, PlainsBit2, PlainsBit3, PlainsBit4, PlainsBit5, PlainsBit6, PlainsBit7, PlainsBit8, PlainsBit9, PlainsBit10, PlainsBit11, PlainsBit12, PlainsBit13, PlainsBit14, PlainsBit15, PlainsBit16, PlainsBit17, PlainsBit18, PlainsBit19, PlainsBit20, PlainsBit21, PlainsBit22, PlainsBit23, PlainsBit24, PlainsBit25, PlainsBit26, PlainsBit27, PlainsBit28, PlainsBit29, PlainsBit30, PlainsBit31 };

        // Forest area collision boxes
        private static Rectangle ForestNorthBoundsWest = new Rectangle(0, 0, 275, 25);
        private static Rectangle ForestNorthBoundsEast = new Rectangle(350, 0, 450, 25);
        private static Rectangle ForestWestBounds = new Rectangle(0, 0, 25, 600);
        private static Rectangle ForestEastBounds = new Rectangle(775, 0, 25, 600);
        private static Rectangle ForestSouthBounds = new Rectangle(0, 575, 800, 25);
        private static Rectangle ForestBit1 = new Rectangle(150, 0, 25, 50);
        private static Rectangle ForestBit2 = new Rectangle(250, 0, 25, 50);
        private static Rectangle ForestBit3 = new Rectangle(200, 50, 25, 50);
        private static Rectangle ForestBit4 = new Rectangle(150, 100, 25, 75);
        private static Rectangle ForestBit5 = new Rectangle(175, 125, 75, 50);
        private static Rectangle ForestBit6 = new Rectangle(250, 100, 25, 75);
        private static Rectangle ForestBit7 = new Rectangle(275, 125, 75, 50);
        private static Rectangle ForestBit8 = new Rectangle(350, 0, 25, 175);
        private static Rectangle ForestBit9 = new Rectangle(0, 100, 50, 50);
        private static Rectangle ForestBit10 = new Rectangle(0, 150, 75, 50);
        private static Rectangle ForestBit11 = new Rectangle(125, 225, 25, 50);
        private static Rectangle ForestBit12 = new Rectangle(50, 325, 25, 50);
        private static Rectangle ForestBit13 = new Rectangle(150, 350, 25, 50);
        private static Rectangle ForestBit14 = new Rectangle(225, 300, 25, 50);
        private static Rectangle ForestBit15 = new Rectangle(275, 225, 25, 50);
        private static Rectangle ForestBit16 = new Rectangle(0, 450, 150, 50);
        private static Rectangle ForestBit17 = new Rectangle(100, 500, 25, 25);
        private static Rectangle ForestBit18 = new Rectangle(100, 550, 25, 50);
        private static Rectangle ForestBit19 = new Rectangle(225, 525, 25, 75);
        private static Rectangle ForestBit20 = new Rectangle(250, 475, 50, 125);
        private static Rectangle ForestBit21 = new Rectangle(300, 425, 50, 175);
        private static Rectangle ForestBit22 = new Rectangle(350, 375, 50, 100);
        private static Rectangle ForestBit23 = new Rectangle(400, 75, 50, 350);
        private static Rectangle ForestBit24 = new Rectangle(400, 500, 25, 50);
        private static Rectangle ForestBit25 = new Rectangle(475, 475, 25, 50);
        private static Rectangle ForestBit26 = new Rectangle(475, 375, 50, 50);
        private static Rectangle ForestBit27 = new Rectangle(550, 450, 50, 50);
        private static Rectangle ForestBit28 = new Rectangle(675, 450, 50, 50);
        private static Rectangle ForestBit29 = new Rectangle(575, 550, 25, 50);
        private static Rectangle ForestBit30 = new Rectangle(750, 525, 50, 75);
        private static Rectangle ForestBit31 = new Rectangle(475, 0, 75, 75);
        private static Rectangle ForestBit32 = new Rectangle(550, 0, 50, 50);
        private static Rectangle ForestBit33 = new Rectangle(675, 0, 50, 50);
        private static Rectangle ForestBit34 = new Rectangle(725, 0, 75, 75);
        private static Rectangle ForestBit35 = new Rectangle(750, 75, 50, 50);
        private static Rectangle ForestBit36 = new Rectangle(750, 200, 50, 225);
        private static Rectangle ForestBit37 = new Rectangle(725, 250, 25, 150);
        private static Rectangle ForestBit38 = new Rectangle(700, 275, 25, 125);
        private static Rectangle ForestBit39 = new Rectangle(675, 300, 25, 100);
        private static Rectangle ForestBit40 = new Rectangle(650, 350, 25, 50);
        private static Rectangle ForestBit41 = new Rectangle(550, 350, 75, 50);
        private static Rectangle ForestBit42 = new Rectangle(475, 300, 125, 50);
        private static Rectangle ForestBit43 = new Rectangle(475, 275, 100, 25);
        private static Rectangle ForestBit44 = new Rectangle(475, 250, 75, 25);
        private static Rectangle ForestBit45 = new Rectangle(475, 200, 50, 50);
        private static Rectangle ForestBit46 = new Rectangle(475, 125, 25, 75);
        private static Rectangle ForestBit47 = new Rectangle(475, 75, 50, 50);

        // Array to hold the forest collision boxes
        private static Rectangle[] forestRectArray = new Rectangle[52] { ForestNorthBoundsWest, ForestNorthBoundsEast, ForestWestBounds, ForestEastBounds, ForestSouthBounds, ForestBit1, ForestBit2, ForestBit3, ForestBit4, ForestBit5, ForestBit6, ForestBit7, ForestBit8, ForestBit9, ForestBit10, ForestBit11, ForestBit12, ForestBit13, ForestBit14, ForestBit15, ForestBit16, ForestBit17, ForestBit18, ForestBit19, ForestBit20, ForestBit21, ForestBit22, ForestBit23, ForestBit24, ForestBit25, ForestBit26, ForestBit27, ForestBit28, ForestBit29, ForestBit30, ForestBit31, ForestBit32, ForestBit33, ForestBit34, ForestBit35, ForestBit36, ForestBit37, ForestBit38, ForestBit39, ForestBit40, ForestBit41, ForestBit42, ForestBit43, ForestBit44, ForestBit45, ForestBit46, ForestBit47 };

        // Cave area collision boxes
        private static Rectangle CaveNorthBounds = new Rectangle(0, 0, 800, 25);
        private static Rectangle CaveWestBoundsNorth = new Rectangle(0, 0, 25, 425);
        private static Rectangle CaveWestBoundsSouth = new Rectangle(0, 500, 25, 100);
        private static Rectangle CaveEastBounds = new Rectangle(775, 0, 25, 600);
        private static Rectangle CaveSouthBounds = new Rectangle(0, 575, 800, 25);

        // Array to hold the cave collision boxes
        private static Rectangle[] caveRectArray = new Rectangle[5] { CaveNorthBounds, CaveWestBoundsNorth, CaveWestBoundsSouth, CaveEastBounds, CaveSouthBounds };

        public static Rectangle[] CastleRectArray
        {
            get { return castleRectArray; }
            set { castleRectArray = value; }
        }
        public static Rectangle[] PlainsRectArray
        {
            get { return plainsRectArray; }
            set { plainsRectArray = value; }
        }
        public static Rectangle[] ForestRectArray
        {
            get { return forestRectArray; }
            set { forestRectArray = value; }
        }
        public static Rectangle[] CaveRectArray
        {
            get { return caveRectArray; }
            set { caveRectArray = value; }
        }

        // variables for the playercheck method
        private static int counter;
        private static bool collide = false;

        /// <summary>
        /// Checks for collisions between the player and the environment.
        /// </summary>
        public static void PlayerCheck()
        {
            if (Transitions.Location == 1 && !Transitions.Trans1 && !Transitions.Trans2 && !Transitions.Trans3 && !Transitions.Trans4 && !Transitions.Trans5 && !Transitions.Trans6)
            {
                bool[] collideArray = new bool[34];
                counter = 0;
                while (counter <= 33)
                {
                    if (Game1.player1.PlayerRect.Intersects(Collisions.CastleRectArray[counter]))
                    {
                        collideArray[counter] = true;
                        collide = true;
                    }
                    counter++;
                }

                if (collide == true)
                {
                    int i = 0;
                    for (i = 0; i <= 33; i++)
                    {
                        if (collideArray[i] == true)
                        {
                            Rectangle collideRect = Rectangle.Intersect(Game1.player1.PlayerRect, Collisions.CastleRectArray[i]);

                            if (collideRect != null)
                            {
                                float pushX = (Game1.player1.PlayerRect.Center.X) - (collideRect.Center.X);
                                float pushY = (Game1.player1.PlayerRect.Center.Y) - (collideRect.Center.Y);

                                float pushHypo = (float)Math.Sqrt((Math.Pow(pushX, 2) + Math.Pow(pushY, 2)));

                                if (pushHypo > 0.01f)
                                {
                                    Game1.player1.Player_x += ((pushX / pushHypo) * 1);
                                    Game1.player1.Player_y += ((pushY / pushHypo) * 1);

                                    Game1.player1.Update();
                                }
                            }
                            collideArray[i] = false;
                        }
                    }
                    collide = false;
                }
            }
            else if (Transitions.Location == 2 && !Transitions.Trans1 && !Transitions.Trans2 && !Transitions.Trans3 && !Transitions.Trans4 && !Transitions.Trans5 && !Transitions.Trans6)
            {
                bool[] collideArray = new bool[36];
                counter = 0;
                while (counter <= 35)
                {
                    if (Game1.player1.PlayerRect.Intersects(Collisions.PlainsRectArray[counter]))
                    {
                        collideArray[counter] = true;
                        collide = true;
                    }
                    counter++;
                }

                if (collide == true)
                {
                    int i = 0;
                    for (i = 0; i <= 35; i++)
                    {
                        if (collideArray[i] == true)
                        {
                            Rectangle collideRect = Rectangle.Intersect(Game1.player1.PlayerRect, Collisions.PlainsRectArray[i]);

                            if (collideRect != null)
                            {
                                float pushX = (Game1.player1.PlayerRect.Center.X) - (collideRect.Center.X);
                                float pushY = (Game1.player1.PlayerRect.Center.Y) - (collideRect.Center.Y);

                                float pushHypo = (float)Math.Sqrt((Math.Pow(pushX, 2) + Math.Pow(pushY, 2)));

                                if (pushHypo > 0.01f)
                                {
                                    Game1.player1.Player_x += ((pushX / pushHypo) * 1);
                                    Game1.player1.Player_y += ((pushY / pushHypo) * 1);

                                    Game1.player1.Update();
                                }
                            }
                            collideArray[i] = false;
                        }
                    }
                    collide = false;
                }
            }
            else if (Transitions.Location == 3 && !Transitions.Trans1 && !Transitions.Trans2 && !Transitions.Trans3 && !Transitions.Trans4 && !Transitions.Trans5 && !Transitions.Trans6)
            {
                bool[] collideArray = new bool[52];
                counter = 0;
                while (counter <= 51)
                {
                    if (Game1.player1.PlayerRect.Intersects(Collisions.ForestRectArray[counter]))
                    {
                        collideArray[counter] = true;
                        collide = true;
                    }
                    counter++;
                }

                if (collide == true)
                {
                    int i = 0;
                    for (i = 0; i <= 51; i++)
                    {
                        if (collideArray[i] == true)
                        {
                            Rectangle collideRect = Rectangle.Intersect(Game1.player1.PlayerRect, Collisions.ForestRectArray[i]);

                            if (collideRect != null)
                            {
                                float pushX = (Game1.player1.PlayerRect.Center.X) - (collideRect.Center.X);
                                float pushY = (Game1.player1.PlayerRect.Center.Y) - (collideRect.Center.Y);

                                float pushHypo = (float)Math.Sqrt((Math.Pow(pushX, 2) + Math.Pow(pushY, 2)));

                                if (pushHypo > 0.01f)
                                {
                                    Game1.player1.Player_x += ((pushX / pushHypo) * 1);
                                    Game1.player1.Player_y += ((pushY / pushHypo) * 1);

                                    Game1.player1.Update();
                                }
                            }
                            collideArray[i] = false;
                        }
                    }
                    collide = false;
                }
            }
            else if (Transitions.Location == 4 && !Transitions.Trans1 && !Transitions.Trans2 && !Transitions.Trans3 && !Transitions.Trans4 && !Transitions.Trans5 && !Transitions.Trans6)
            {
                bool[] collideArray = new bool[5];
                counter = 0;
                while (counter <= 4)
                {
                    if (Game1.player1.PlayerRect.Intersects(Collisions.CaveRectArray[counter]))
                    {
                        collideArray[counter] = true;
                        collide = true;
                    }
                    counter++;
                }

                if (collide == true)
                {
                    int i = 0;
                    for (i = 0; i <= 4; i++)
                    {
                        if (collideArray[i] == true)
                        {
                            Rectangle collideRect = Rectangle.Intersect(Game1.player1.PlayerRect, Collisions.CaveRectArray[i]);

                            if (collideRect != null)
                            {
                                float pushX = (Game1.player1.PlayerRect.Center.X) - (collideRect.Center.X);
                                float pushY = (Game1.player1.PlayerRect.Center.Y) - (collideRect.Center.Y);

                                float pushHypo = (float)Math.Sqrt((Math.Pow(pushX, 2) + Math.Pow(pushY, 2)));

                                if (pushHypo > 0.01f)
                                {
                                    Game1.player1.Player_x += ((pushX / pushHypo) * 1);
                                    Game1.player1.Player_y += ((pushY / pushHypo) * 1);

                                    Game1.player1.Update();
                                }
                            }
                            collideArray[i] = false;
                        }
                    }
                    collide = false;
                }
            }
        }

        public static void EnemyCheck()
        {
            if (Transitions.Location == 2 && !Transitions.Trans1 && !Transitions.Trans2 && !Transitions.Trans3 && !Transitions.Trans4 && !Transitions.Trans5 && !Transitions.Trans6)
            {
                foreach (Enemy e in TheEnemy.PlainsEnemyArray)
                {
                    bool[] collideArray = new bool[36];
                    counter = 0;
                    while (counter <= 35)
                    {
                        if (e.EnemyRect.Intersects(Collisions.PlainsRectArray[counter]))
                        {
                            collideArray[counter] = true;
                            collide = true;
                        }
                        counter++;
                    }

                    if (collide == true)
                    {
                        int i = 0;
                        for (i = 0; i <= 35; i++)
                        {
                            if (collideArray[i] == true)
                            {
                                Rectangle collideRect = Rectangle.Intersect(e.EnemyRect, Collisions.PlainsRectArray[i]);

                                if (collideRect != null)
                                {
                                    float pushX = (e.EnemyRect.Center.X) - (collideRect.Center.X);
                                    float pushY = (e.EnemyRect.Center.Y) - (collideRect.Center.Y);

                                    float pushHypo = (float)Math.Sqrt((Math.Pow(pushX, 2) + Math.Pow(pushY, 2)));

                                    if (pushHypo > 0.01f)
                                    {
                                        e.Enemy_x += ((pushX / pushHypo) * 1);
                                        e.Enemy_y += ((pushY / pushHypo) * 1);

                                        e.Update();
                                    }
                                }
                                collideArray[i] = false;
                            }
                        }
                        collide = false;
                    }
                }
            }
            else if (Transitions.Location == 3 && !Transitions.Trans1 && !Transitions.Trans2 && !Transitions.Trans3 && !Transitions.Trans4 && !Transitions.Trans5 && !Transitions.Trans6)
            {
                foreach (Enemy e in TheEnemy.ForestEnemyArray)
                {
                    bool[] collideArray = new bool[52];
                    counter = 0;
                    while (counter <= 51)
                    {
                        if (e.EnemyRect.Intersects(Collisions.ForestRectArray[counter]))
                        {
                            collideArray[counter] = true;
                            collide = true;
                        }
                        counter++;
                    }

                    if (collide == true)
                    {
                        int i = 0;
                        for (i = 0; i <= 51; i++)
                        {
                            if (collideArray[i] == true)
                            {
                                Rectangle collideRect = Rectangle.Intersect(e.EnemyRect, Collisions.ForestRectArray[i]);

                                if (collideRect != null)
                                {
                                    float pushX = (e.EnemyRect.Center.X) - (collideRect.Center.X);
                                    float pushY = (e.EnemyRect.Center.Y) - (collideRect.Center.Y);

                                    float pushHypo = (float)Math.Sqrt((Math.Pow(pushX, 2) + Math.Pow(pushY, 2)));

                                    if (pushHypo > 0.01f)
                                    {
                                        e.Enemy_x += ((pushX / pushHypo) * 1);
                                        e.Enemy_y += ((pushY / pushHypo) * 1);

                                        e.Update();
                                    }
                                }
                                collideArray[i] = false;
                            }
                        }
                        collide = false;
                    }
                }
            }
            else if (Transitions.Location == 4 && !Transitions.Trans1 && !Transitions.Trans2 && !Transitions.Trans3 && !Transitions.Trans4 && !Transitions.Trans5 && !Transitions.Trans6)
            {
                /*foreach (Enemy e in TheEnemy.CaveEnemyArray)
                {
                    bool[] collideArray = new bool[5];
                    counter = 0;
                    while (counter <= 4)
                    {
                        if (e.EnemyRect.Intersects(Collisions.CaveRectArray(counter)))
                        {
                            collideArray[counter] = true;
                            collide = true;
                        }
                        counter++;
                    }

                    if (collide == true)
                    {
                        int i = 0;
                        for (i = 0; i <= 4; i++)
                        {
                            if (collideArray[i] == true)
                            {
                                Rectangle collideRect = Rectangle.Intersect(e.EnemyRect, Collisions.CaveRectArray(i));

                                if (collideRect != null)
                                {
                                    float pushX = (e.EnemyRect.Center.X) - (collideRect.Center.X);
                                    float pushY = (e.EnemyRect.Center.Y) - (collideRect.Center.Y);

                                    float pushHypo = (float)Math.Sqrt((Math.Pow(pushX, 2) + Math.Pow(pushY, 2)));

                                    if (pushHypo > 0.01f)
                                    {
                                        e.Enemy_x += ((pushX / pushHypo) * 1);
                                        e.Enemy_y += ((pushY / pushHypo) * 1);

                                        e.Update();
                                    }
                                }
                                collideArray[i] = false;
                            }
                        }
                        collide = false;
                    }
                }*/
            }
        }

        public static void Combat()
        {
            if (Transitions.Location == 2)
            {
                foreach (Enemy e in TheEnemy.PlainsEnemyArray)
                {
                    if (e.EnemyRect.Intersects(Game1.player1.PlayerRect) && (e.Health > 0))
                    {
                        float DistX = Game1.player1.PlayerRect.Center.X - e.EnemyRect.Center.X;
                        float DistY = Game1.player1.PlayerRect.Center.Y - e.EnemyRect.Center.Y;

                        float DistHypo = (float)Math.Sqrt(Math.Pow(DistX, 2) + Math.Pow(DistY, 2));

                        Game1.player1.Player_x += 5 * (DistX / DistHypo);
                        Game1.player1.Player_y += 5 * (DistY / DistHypo);
                        Game1.player1.Health -= 100;
                    }
                    if ((Spear.SpearLength > 0) && e.EnemyRect.Intersects(Spear.Spear1_Rectangle))
                    {
                        float DistX = e.EnemyRect.Center.X - Spear.Spear1_Rectangle.Center.X;
                        float DistY = e.EnemyRect.Center.Y - Spear.Spear1_Rectangle.Center.Y;

                        float DistHypo = (float)Math.Sqrt(Math.Pow(DistX, 2) + Math.Pow(DistY, 2));

                        e.Enemy_x += 10 * (DistX / DistHypo);
                        e.Enemy_y += 10 * (DistY / DistHypo);
                        e.Health -= 150;

                        Spear.SpearLength -= 1;
                    }
                    else if ((Spear.SpearLength > 1) && e.EnemyRect.Intersects(Spear.Spear2_Rectangle))
                    {
                        float DistX = e.EnemyRect.Center.X - Spear.Spear2_Rectangle.Center.X;
                        float DistY = e.EnemyRect.Center.Y - Spear.Spear2_Rectangle.Center.Y;

                        float DistHypo = (float)Math.Sqrt(Math.Pow(DistX, 2) + Math.Pow(DistY, 2));

                        e.Enemy_x += 10 * (DistX / DistHypo);
                        e.Enemy_y += 10 * (DistY / DistHypo);
                        e.Health -= 150;

                        Spear.SpearLength -= 1;
                    }
                    else if ((Spear.SpearLength > 2) && e.EnemyRect.Intersects(Spear.Spear3_Rectangle))
                    {
                        float DistX = e.EnemyRect.Center.X - Spear.Spear3_Rectangle.Center.X;
                        float DistY = e.EnemyRect.Center.Y - Spear.Spear3_Rectangle.Center.Y;

                        float DistHypo = (float)Math.Sqrt(Math.Pow(DistX, 2) + Math.Pow(DistY, 2));

                        e.Enemy_x += 10 * (DistX / DistHypo);
                        e.Enemy_y += 10 * (DistY / DistHypo);
                        e.Health -= 150;

                        Spear.SpearLength -= 1;
                    }
                    else if ((Spear.SpearLength > 3) && e.EnemyRect.Intersects(Spear.Spear4_Rectangle))
                    {
                        float DistX = e.EnemyRect.Center.X - Spear.Spear4_Rectangle.Center.X;
                        float DistY = e.EnemyRect.Center.Y - Spear.Spear4_Rectangle.Center.Y;

                        float DistHypo = (float)Math.Sqrt(Math.Pow(DistX, 2) + Math.Pow(DistY, 2));

                        e.Enemy_x += 10 * (DistX / DistHypo);
                        e.Enemy_y += 10 * (DistY / DistHypo);
                        e.Health -= 150;

                        Spear.SpearLength -= 1;
                    }
                    else if ((Spear.SpearLength > 4) && e.EnemyRect.Intersects(Spear.Spear5_Rectangle))
                    {
                        float DistX = e.EnemyRect.Center.X - Spear.Spear5_Rectangle.Center.X;
                        float DistY = e.EnemyRect.Center.Y - Spear.Spear5_Rectangle.Center.Y;

                        float DistHypo = (float)Math.Sqrt(Math.Pow(DistX, 2) + Math.Pow(DistY, 2));

                        e.Enemy_x += 10 * (DistX / DistHypo);
                        e.Enemy_y += 10 * (DistY / DistHypo);
                        e.Health -= 150;

                        Spear.SpearLength -= 1;
                    }
                    else if ((Spear.SpearLength > 5) && e.EnemyRect.Intersects(Spear.Spear6_Rectangle))
                    {
                        float DistX = e.EnemyRect.Center.X - Spear.Spear6_Rectangle.Center.X;
                        float DistY = e.EnemyRect.Center.Y - Spear.Spear6_Rectangle.Center.Y;

                        float DistHypo = (float)Math.Sqrt(Math.Pow(DistX, 2) + Math.Pow(DistY, 2));

                        e.Enemy_x += 10 * (DistX / DistHypo);
                        e.Enemy_y += 10 * (DistY / DistHypo);
                        e.Health -= 150;

                        Spear.SpearLength -= 1;
                    }
                    else if ((Spear.SpearLength > 6) && e.EnemyRect.Intersects(Spear.Spear7_Rectangle))
                    {
                        float DistX = e.EnemyRect.Center.X - Spear.Spear7_Rectangle.Center.X;
                        float DistY = e.EnemyRect.Center.Y - Spear.Spear7_Rectangle.Center.Y;

                        float DistHypo = (float)Math.Sqrt(Math.Pow(DistX, 2) + Math.Pow(DistY, 2));

                        e.Enemy_x += 10 * (DistX / DistHypo);
                        e.Enemy_y += 10 * (DistY / DistHypo);
                        e.Health -= 150;

                        Spear.SpearLength -= 1;
                    }
                }
            }
            else if (Transitions.Location == 3)
            {
                foreach (Enemy e in TheEnemy.ForestEnemyArray)
                {
                    if (e.EnemyRect.Intersects(Game1.player1.PlayerRect) && (e.Health > 0))
                    {
                        float DistX = Game1.player1.PlayerRect.Center.X - e.EnemyRect.Center.X;
                        float DistY = Game1.player1.PlayerRect.Center.Y - e.EnemyRect.Center.Y;

                        float DistHypo = (float)Math.Sqrt(Math.Pow(DistX, 2) + Math.Pow(DistY, 2));

                        Game1.player1.Player_x += 10 * (DistX / DistHypo);
                        Game1.player1.Player_y += 10 * (DistY / DistHypo);
                        Game1.player1.Health -= 100;
                    }
                    if ((Spear.SpearLength > 0) && e.EnemyRect.Intersects(Spear.Spear1_Rectangle))
                    {
                        float DistX = e.EnemyRect.Center.X - Spear.Spear1_Rectangle.Center.X;
                        float DistY = e.EnemyRect.Center.Y - Spear.Spear1_Rectangle.Center.Y;

                        float DistHypo = (float)Math.Sqrt(Math.Pow(DistX, 2) + Math.Pow(DistY, 2));

                        e.Enemy_x += 10 * (DistX / DistHypo);
                        e.Enemy_y += 10 * (DistY / DistHypo);
                        e.Health -= 150;

                        Spear.SpearLength -= 1;
                    }
                    else if ((Spear.SpearLength > 1) && e.EnemyRect.Intersects(Spear.Spear2_Rectangle))
                    {
                        float DistX = e.EnemyRect.Center.X - Spear.Spear2_Rectangle.Center.X;
                        float DistY = e.EnemyRect.Center.Y - Spear.Spear2_Rectangle.Center.Y;

                        float DistHypo = (float)Math.Sqrt(Math.Pow(DistX, 2) + Math.Pow(DistY, 2));

                        e.Enemy_x += 10 * (DistX / DistHypo);
                        e.Enemy_y += 10 * (DistY / DistHypo);
                        e.Health -= 150;

                        Spear.SpearLength -= 1;
                    }
                    else if ((Spear.SpearLength > 2) && e.EnemyRect.Intersects(Spear.Spear3_Rectangle))
                    {
                        float DistX = e.EnemyRect.Center.X - Spear.Spear3_Rectangle.Center.X;
                        float DistY = e.EnemyRect.Center.Y - Spear.Spear3_Rectangle.Center.Y;

                        float DistHypo = (float)Math.Sqrt(Math.Pow(DistX, 2) + Math.Pow(DistY, 2));

                        e.Enemy_x += 10 * (DistX / DistHypo);
                        e.Enemy_y += 10 * (DistY / DistHypo);
                        e.Health -= 150;

                        Spear.SpearLength -= 1;
                    }
                    else if ((Spear.SpearLength > 3) && e.EnemyRect.Intersects(Spear.Spear4_Rectangle))
                    {
                        float DistX = e.EnemyRect.Center.X - Spear.Spear4_Rectangle.Center.X;
                        float DistY = e.EnemyRect.Center.Y - Spear.Spear4_Rectangle.Center.Y;

                        float DistHypo = (float)Math.Sqrt(Math.Pow(DistX, 2) + Math.Pow(DistY, 2));

                        e.Enemy_x += 10 * (DistX / DistHypo);
                        e.Enemy_y += 10 * (DistY / DistHypo);
                        e.Health -= 150;

                        Spear.SpearLength -= 1;
                    }
                    else if ((Spear.SpearLength > 4) && e.EnemyRect.Intersects(Spear.Spear5_Rectangle))
                    {
                        float DistX = e.EnemyRect.Center.X - Spear.Spear5_Rectangle.Center.X;
                        float DistY = e.EnemyRect.Center.Y - Spear.Spear5_Rectangle.Center.Y;

                        float DistHypo = (float)Math.Sqrt(Math.Pow(DistX, 2) + Math.Pow(DistY, 2));

                        e.Enemy_x += 10 * (DistX / DistHypo);
                        e.Enemy_y += 10 * (DistY / DistHypo);
                        e.Health -= 150;

                        Spear.SpearLength -= 1;
                    }
                    else if ((Spear.SpearLength > 5) && e.EnemyRect.Intersects(Spear.Spear6_Rectangle))
                    {
                        float DistX = e.EnemyRect.Center.X - Spear.Spear6_Rectangle.Center.X;
                        float DistY = e.EnemyRect.Center.Y - Spear.Spear6_Rectangle.Center.Y;

                        float DistHypo = (float)Math.Sqrt(Math.Pow(DistX, 2) + Math.Pow(DistY, 2));

                        e.Enemy_x += 10 * (DistX / DistHypo);
                        e.Enemy_y += 10 * (DistY / DistHypo);
                        e.Health -= 150;

                        Spear.SpearLength -= 1;
                    }
                    else if ((Spear.SpearLength > 6) && e.EnemyRect.Intersects(Spear.Spear7_Rectangle))
                    {
                        float DistX = e.EnemyRect.Center.X - Spear.Spear7_Rectangle.Center.X;
                        float DistY = e.EnemyRect.Center.Y - Spear.Spear7_Rectangle.Center.Y;

                        float DistHypo = (float)Math.Sqrt(Math.Pow(DistX, 2) + Math.Pow(DistY, 2));

                        e.Enemy_x += 10 * (DistX / DistHypo);
                        e.Enemy_y += 10 * (DistY / DistHypo);
                        e.Health -= 150;

                        Spear.SpearLength -= 1;
                    }
                }
            }
            else if (Transitions.Location == 4)
            {
                /*foreach (Enemy e in TheEnemy.PlainsEnemyArray)
                {
                    if (e.EnemyRect.Intersects(Game1.player1.PlayerRect) && (e.Health > 0))
                    {
                        float DistX = Game1.player1.PlayerRect.Center.X - enemyRect.Center.X;
                        float DistY = Game1.player1.PlayerRect.Center.Y - enemyRect.Center.Y;

                        float DistHypo = (float)Math.Sqrt(Math.Pow(DistX, 2) + Math.Pow(DistY, 2));

                        Game1.player1.Player_x += 10 * (DistX / DistHypo);
                        Game1.player1.Player_y += 10 * (DistY / DistHypo);
                        Game1.player1.Health -= 100;
                    }
                    if ((Spear.SpearLength > 0) && e.EnemyRect.Intersects(Spear.Spear1_Rectangle))
                    {
                        float DistX = e.EnemyRect.Center.X - Spear.Spear1_Rectangle.Center.X;
                        float DistY = e.EnemyRect.Center.Y - Spear.Spear1_Rectangle.Center.Y;

                        float DistHypo = (float)Math.Sqrt(Math.Pow(DistX, 2) + Math.Pow(DistY, 2));

                        e.Enemy_x += 10 * (DistX / DistHypo);
                        e.Enemy_y += 10 * (DistY / DistHypo);
                        e.Health -= 150;

                        Spear.SpearLength -= 1;
                    }
                    else if ((Spear.SpearLength > 1) && e.EnemyRect.Intersects(Spear.Spear2_Rectangle))
                    {
                        float DistX = e.EnemyRect.Center.X - Spear.Spear2_Rectangle.Center.X;
                        float DistY = e.EnemyRect.Center.Y - Spear.Spear2_Rectangle.Center.Y;

                        float DistHypo = (float)Math.Sqrt(Math.Pow(DistX, 2) + Math.Pow(DistY, 2));

                        e.Enemy_x += 10 * (DistX / DistHypo);
                        e.Enemy_y += 10 * (DistY / DistHypo);
                        e.Health -= 150;

                        Spear.SpearLength -= 1;
                    }
                    else if ((Spear.SpearLength > 2) && e.EnemyRect.Intersects(Spear.Spear3_Rectangle))
                    {
                        float DistX = e.EnemyRect.Center.X - Spear.Spear3_Rectangle.Center.X;
                        float DistY = e.EnemyRect.Center.Y - Spear.Spear3_Rectangle.Center.Y;

                        float DistHypo = (float)Math.Sqrt(Math.Pow(DistX, 2) + Math.Pow(DistY, 2));

                        e.Enemy_x += 10 * (DistX / DistHypo);
                        e.Enemy_y += 10 * (DistY / DistHypo);
                        e.Health -= 150;

                        Spear.SpearLength -= 1;
                    }
                    else if ((Spear.SpearLength > 3) && e.EnemyRect.Intersects(Spear.Spear4_Rectangle))
                    {
                        float DistX = e.EnemyRect.Center.X - Spear.Spear4_Rectangle.Center.X;
                        float DistY = e.EnemyRect.Center.Y - Spear.Spear4_Rectangle.Center.Y;

                        float DistHypo = (float)Math.Sqrt(Math.Pow(DistX, 2) + Math.Pow(DistY, 2));

                        e.Enemy_x += 10 * (DistX / DistHypo);
                        e.Enemy_y += 10 * (DistY / DistHypo);
                        e.Health -= 150;

                        Spear.SpearLength -= 1;
                    }
                    else if ((Spear.SpearLength > 4) && e.EnemyRect.Intersects(Spear.Spear5_Rectangle))
                    {
                        float DistX = e.EnemyRect.Center.X - Spear.Spear5_Rectangle.Center.X;
                        float DistY = e.EnemyRect.Center.Y - Spear.Spear5_Rectangle.Center.Y;

                        float DistHypo = (float)Math.Sqrt(Math.Pow(DistX, 2) + Math.Pow(DistY, 2));

                        e.Enemy_x += 10 * (DistX / DistHypo);
                        e.Enemy_y += 10 * (DistY / DistHypo);
                        e.Health -= 150;

                        Spear.SpearLength -= 1;
                    }
                    else if ((Spear.SpearLength > 5) && e.EnemyRect.Intersects(Spear.Spear6_Rectangle))
                    {
                        float DistX = e.EnemyRect.Center.X - Spear.Spear6_Rectangle.Center.X;
                        float DistY = e.EnemyRect.Center.Y - Spear.Spear6_Rectangle.Center.Y;

                        float DistHypo = (float)Math.Sqrt(Math.Pow(DistX, 2) + Math.Pow(DistY, 2));

                        e.Enemy_x += 10 * (DistX / DistHypo);
                        e.Enemy_y += 10 * (DistY / DistHypo);
                        e.Health -= 150;

                        Spear.SpearLength -= 1;
                    }
                    else if ((Spear.SpearLength > 6) && e.EnemyRect.Intersects(Spear.Spear7_Rectangle))
                    {
                        float DistX = e.EnemyRect.Center.X - Spear.Spear7_Rectangle.Center.X;
                        float DistY = e.EnemyRect.Center.Y - Spear.Spear7_Rectangle.Center.Y;

                        float DistHypo = (float)Math.Sqrt(Math.Pow(DistX, 2) + Math.Pow(DistY, 2));

                        e.Enemy_x += 10 * (DistX / DistHypo);
                        e.Enemy_y += 10 * (DistY / DistHypo);
                        e.Health -= 150;

                        Spear.SpearLength -= 1;
                    }
                }*/
            }
        }
    }
}
