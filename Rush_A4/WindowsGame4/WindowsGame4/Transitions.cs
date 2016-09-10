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
    class Transitions
    {

        private static Song castleBGM;
        private static Song plainsBGM;
        private static Song forestBGM;
        private static Song caveBGM;

        private static int location = 1;
        private static int transCounter = 0;

        private static bool trans1 = false;
        private static bool trans2 = false;
        private static bool trans3 = false;
        private static bool trans4 = false;
        private static bool trans5 = false;
        private static bool trans6 = false;
        private static bool musicplaying = false;

        // these rectangles define the transition paths between areas
        private static Rectangle CatoPl = new Rectangle(0, 150, 1, 75);
        private static Rectangle PltoCa = new Rectangle(799, 150, 1, 75);
        private static Rectangle CatoFr = new Rectangle(275, 599, 75, 1);
        private static Rectangle FrtoCa = new Rectangle(275, 0, 75, 1);
        private static Rectangle CatoCv = new Rectangle(799, 425, 1, 75);
        private static Rectangle CvtoCA = new Rectangle(0, 425, 1, 75);

        /// <summary>
        /// Handles background music and checks for collisions with the portals to other locations.
        /// </summary>
        public static void Places()
        {
            if (location == 1 && !trans1 && !trans3 && !trans5)
            {
                if (musicplaying == false)
                {
                    MediaPlayer.Play(castleBGM);
                    musicplaying = true;
                }
                if (Game1.player1.PlayerRect.Intersects(CatoPl))
                {
                    trans1 = true;
                    MediaPlayer.Stop();
                    musicplaying = false;
                }
                else if (Game1.player1.PlayerRect.Intersects(CatoFr))
                {
                    trans3 = true;
                    MediaPlayer.Stop();
                    musicplaying = false;
                }
                else if (Game1.player1.PlayerRect.Intersects(CatoCv))
                {
                    trans5 = true;
                    MediaPlayer.Stop();
                    musicplaying = false;
                }
            }
            else if (location == 2 && !trans2)
            {
                if (musicplaying == false)
                {
                    MediaPlayer.Play(plainsBGM);
                    musicplaying = true;
                }
                if (Game1.player1.PlayerRect.Intersects(PltoCa))
                {
                    trans2 = true;
                    MediaPlayer.Stop();
                    musicplaying = false;
                }
            }
            else if (location == 3 && !trans4)
            {
                if (musicplaying == false)
                {
                    MediaPlayer.Play(forestBGM);
                    musicplaying = true;
                }
                if (Game1.player1.PlayerRect.Intersects(FrtoCa))
                {
                    trans4 = true;
                    MediaPlayer.Stop();
                    musicplaying = false;
                }
            }
            else if (location == 4 && !trans6)
            {
                if (musicplaying == false)
                {
                    MediaPlayer.Play(caveBGM);
                    musicplaying = true;
                }
                if (Game1.player1.PlayerRect.Intersects(CvtoCA))
                {
                    trans6 = true;
                    MediaPlayer.Stop();
                    musicplaying = false;
                }
            }
        }

        /// <summary>
        /// Handles the transition animations.
        /// </summary>
        public static void Transition()
        {
            if (trans1 == true)
            {
                Game1.player1.Player_rotation = (float)(Math.PI / 2);
                Game1.player1.Player_x += 15;
                transCounter++;
                if (transCounter == 50)
                {
                    trans1 = false;
                    location = 2;
                    musicplaying = false;
                    transCounter = 0;
                }
            }
            else if (trans2 == true)
            {
                Game1.player1.Player_rotation = (float)(3 * Math.PI / 2);
                Game1.player1.Player_x -= 15;
                transCounter++;
                if (transCounter == 50)
                {
                    trans2 = false;
                    location = 1;
                    musicplaying = false;
                    transCounter = 0;
                }
            }
            else if (trans3 == true)
            {
                Game1.player1.Player_rotation = (float)(Math.PI);
                Game1.player1.Player_y -= 11;
                transCounter++;
                if (transCounter == 50)
                {
                    trans3 = false;
                    location = 3;
                    musicplaying = false;
                    transCounter = 0;
                }
            }
            else if (trans4 == true)
            {
                Game1.player1.Player_rotation = (float)(0);
                Game1.player1.Player_y += 11;
                transCounter++;
                if (transCounter == 50)
                {
                    trans4 = false;
                    location = 1;
                    musicplaying = false;
                    transCounter = 0;
                }
            }
            else if (trans5 == true)
            {
                Game1.player1.Player_rotation = (float)(3 * Math.PI / 2);
                Game1.player1.Player_x -= 15;
                transCounter++;
                if (transCounter == 50)
                {
                    trans5 = false;
                    location = 4;
                    musicplaying = false;
                    transCounter = 0;
                }
            }
            else if (trans6 == true)
            {
                Game1.player1.Player_rotation = (float)(Math.PI / 2);
                Game1.player1.Player_x += 15;
                transCounter++;
                if (transCounter == 50)
                {
                    trans6 = false;
                    location = 1;
                    musicplaying = false;
                    transCounter = 0;
                }
            }
        }

        public static int Location
        {
            get { return location; }
            set { location = value; }
        }

        public static bool Trans1
        {
            get { return trans1; }
            set { trans1 = value; }
        }
        public static bool Trans2
        {
            get { return trans2; }
            set { trans2 = value; }
        }
        public static bool Trans3
        {
            get { return trans3; }
            set { trans3 = value; }
        }
        public static bool Trans4
        {
            get { return trans4; }
            set { trans4 = value; }
        }
        public static bool Trans5
        {
            get { return trans5; }
            set { trans5 = value; }
        }
        public static bool Trans6
        {
            get { return trans6; }
            set { trans6 = value; }
        }

        public static int TransCounter
        {
            get { return transCounter; }
            set { transCounter = value; }
        }

        public static Song CastleBGM
        {
            get {return castleBGM;}
            set {castleBGM = value;}
        }
        public static Song PlainsBGM
        {
            get { return plainsBGM; }
            set { plainsBGM = value; }
        }
        public static Song ForestBGM
        {
            get { return forestBGM; }
            set { forestBGM = value; }
        }
        public static Song CaveBGM
        {
            get { return caveBGM; }
            set { caveBGM = value; }
        }

        public static bool Musicplaying
        {
            get { return musicplaying; }
            set { musicplaying = value; }
        }
    }
}
