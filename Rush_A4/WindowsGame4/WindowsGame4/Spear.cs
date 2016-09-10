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
    public static class Spear
    {
        private static int spearLength = 3;
        private static float spearRotation = 0f;
        private static float spearCenterX;
        private static float spearCenterY;
        private static int spearHeight;
        private static Rectangle spearRectangle;

        private static Texture2D spear_Texture;

        private static Texture2D spear1_Texture;
        private static Texture2D spear2_Texture;
        private static Texture2D spear3_Texture;
        private static Texture2D spear4_Texture;
        private static Texture2D spear5_Texture;
        private static Texture2D spear6_Texture;
        private static Texture2D spear7_Texture;

        private static Rectangle spear1_Rectangle;
        private static Rectangle spear2_Rectangle;
        private static Rectangle spear3_Rectangle;
        private static Rectangle spear4_Rectangle;
        private static Rectangle spear5_Rectangle;
        private static Rectangle spear6_Rectangle;
        private static Rectangle spear7_Rectangle;

        public static Texture2D Spear_Texture
        {
            get { return spear_Texture; }
            set { spear_Texture = value; }
        }
        public static Texture2D Spear1_Texture
        {
            get { return spear1_Texture; }
            set { spear1_Texture = value; }
        }
        public static Texture2D Spear2_Texture
        {
            get { return spear2_Texture; }
            set { spear2_Texture = value; }
        }
        public static Texture2D Spear3_Texture
        {
            get { return spear3_Texture; }
            set { spear3_Texture = value; }
        }
        public static Texture2D Spear4_Texture
        {
            get { return spear4_Texture; }
            set { spear4_Texture = value; }
        }
        public static Texture2D Spear5_Texture
        {
            get { return spear5_Texture; }
            set { spear5_Texture = value; }
        }
        public static Texture2D Spear6_Texture
        {
            get { return spear6_Texture; }
            set { spear6_Texture = value; }
        }
        public static Texture2D Spear7_Texture
        {
            get { return spear7_Texture; }
            set { spear7_Texture = value; }
        }

        public static int SpearLength
        {
            get { return spearLength; }
            set { spearLength = value; }
        }
        public static float SpearRotation
        {
            get { return spearRotation; }
            set { spearRotation = value; }
        }
        public static float SpearCenterX
        {
            get { return spearCenterX; }
            set { spearCenterX = value; }
        }
        public static float SpearCenterY
        {
            get { return spearCenterY; }
            set { spearCenterY = value; }
        }
        public static int SpearHeight
        {
            get { return spearHeight; }
            set { spearHeight = value; }
        }
        public static Rectangle SpearRectangle
        {
            get { return spearRectangle; }
            set { spearRectangle = value; }
        }

        public static Rectangle Spear1_Rectangle
        {
            get { return spear1_Rectangle; }
            set { spear1_Rectangle = value; }
        }
        public static Rectangle Spear2_Rectangle
        {
            get { return spear2_Rectangle; }
            set { spear2_Rectangle = value; }
        }
        public static Rectangle Spear3_Rectangle
        {
            get { return spear3_Rectangle; }
            set { spear3_Rectangle = value; }
        }
        public static Rectangle Spear4_Rectangle
        {
            get { return spear4_Rectangle; }
            set { spear4_Rectangle = value; }
        }
        public static Rectangle Spear5_Rectangle
        {
            get { return spear5_Rectangle; }
            set { spear5_Rectangle = value; }
        }
        public static Rectangle Spear6_Rectangle
        {
            get { return spear6_Rectangle; }
            set { spear6_Rectangle = value; }
        }
        public static Rectangle Spear7_Rectangle
        {
            get { return spear7_Rectangle; }
            set { spear7_Rectangle = value; }
        }

        public static void Update()
        {
            spearRotation = Game1.player1.Player_rotation;

            spear1_Rectangle = new Rectangle((int)((-13 * Math.Sin(Game1.player1.Player_rotation)) - 2) + (int)Game1.player1.Player_x, (int)((-13 * Math.Cos(Game1.player1.Player_rotation)) - 2) + (int)Game1.player1.Player_y, 5, 5);
            spear2_Rectangle = new Rectangle((int)((-17 * Math.Sin(Game1.player1.Player_rotation)) - 2) + (int)Game1.player1.Player_x, (int)((-17 * Math.Cos(Game1.player1.Player_rotation)) - 2) + (int)Game1.player1.Player_y, 5, 5);
            spear3_Rectangle = new Rectangle((int)((-21 * Math.Sin(Game1.player1.Player_rotation)) - 2) + (int)Game1.player1.Player_x, (int)((-21 * Math.Cos(Game1.player1.Player_rotation)) - 2) + (int)Game1.player1.Player_y, 5, 5);
            spear4_Rectangle = new Rectangle((int)((-25 * Math.Sin(Game1.player1.Player_rotation)) - 2) + (int)Game1.player1.Player_x, (int)((-25 * Math.Cos(Game1.player1.Player_rotation)) - 2) + (int)Game1.player1.Player_y, 5, 5);
            spear5_Rectangle = new Rectangle((int)((-29 * Math.Sin(Game1.player1.Player_rotation)) - 2) + (int)Game1.player1.Player_x, (int)((-29 * Math.Cos(Game1.player1.Player_rotation)) - 2) + (int)Game1.player1.Player_y, 5, 5);
            spear6_Rectangle = new Rectangle((int)((-33 * Math.Sin(Game1.player1.Player_rotation)) - 2) + (int)Game1.player1.Player_x, (int)((-33 * Math.Cos(Game1.player1.Player_rotation)) - 2) + (int)Game1.player1.Player_y, 5, 5);
            spear7_Rectangle = new Rectangle((int)((-37 * Math.Sin(Game1.player1.Player_rotation)) - 2) + (int)Game1.player1.Player_x, (int)((-37 * Math.Cos(Game1.player1.Player_rotation)) - 2) + (int)Game1.player1.Player_y, 5, 5);

            spearHeight = 4 + (4 * spearLength);

            spearRectangle = new Rectangle((int)spearCenterX, (int)spearCenterY, 5, spearHeight);

            if (spearLength == 1)
            {
                spear_Texture = spear1_Texture;
            }
            else if (spearLength == 2)
            {
                spear_Texture = spear2_Texture;
            }
            else if (spearLength == 3)
            {
                spear_Texture = spear3_Texture;
            }
            else if (spearLength == 4)
            {
                spear_Texture = spear4_Texture;
            }
            else if (spearLength == 5)
            {
                spear_Texture = spear5_Texture;
            }
            else if (spearLength == 6)
            {
                spear_Texture = spear6_Texture;
            }
            else if (spearLength == 7)
            {
                spear_Texture = spear7_Texture;
            }

            spearCenterX = (Game1.player1.PlayerRect.Center.X - (float)(((Game1.player1.PlayerRect.Height + spear_Texture.Height) / 2) * Math.Sin(spearRotation)));
            spearCenterY = (Game1.player1.PlayerRect.Center.Y - (float)(((Game1.player1.PlayerRect.Height + spear_Texture.Height) / 2) * Math.Cos(spearRotation)));
        }
    }
}
