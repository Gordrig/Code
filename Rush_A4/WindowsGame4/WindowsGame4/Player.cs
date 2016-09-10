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
    public class Player
    {
        private Texture2D player_texture;
        private int health;
        private double player_x;
        private double player_y;
        private float player_rotation;
        private Rectangle playerRect;
        private int spearCounter;
        private int healthCounter;
        private int playerLevel;
        private int experience;

        public Player()
        {
            health = 1000;
            playerLevel = 1;
            player_x = 313;
            player_y = 363;
            player_rotation = 0f;
            playerRect = new Rectangle((int)player_x - 13, (int)player_y - 13, 23, 23);
        }

        public void Update()
        {
            playerRect = new Rectangle((int)player_x - 13, (int)player_y - 13, 23, 23);
            spearCounter++;
            healthCounter++;
            if (spearCounter == 40)
            {
                spearCounter = 0;
                if (Spear.SpearLength < (2 + playerLevel))
                {
                    Spear.SpearLength++;
                }
            }
            if (health <= 0)
            {
                Transitions.Location = 1;
                Transitions.Musicplaying = false;
                health = 250;
                player_x = 313;
                player_y = 363;
                player_rotation = 0f;
            }
            if (healthCounter == 100)
            {
                healthCounter = 0;
                if (health < 1000)
                {
                    health += 10;
                }
            }
            if (health > 1000)
            {
                health = 1000;
            }
            if (experience >= 500)
            {
                experience -= 500;
                playerLevel++;
            }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public double Player_x
        {
            get { return player_x; }
            set { player_x = value; }
        }

        public double Player_y
        {
            get { return player_y; }
            set { player_y = value; }
        }

        public float Player_rotation
        {
            get { return player_rotation; }
            set { player_rotation = value; }
        }

        public Texture2D Player_texture
        {
            get { return player_texture; }
            set { player_texture = value; }
        }

        public Rectangle PlayerRect
        {
            get { return playerRect; }
            set { playerRect = value; }
        }

        public int PlayerLevel
        {
            get { return playerLevel; }
            set { playerLevel = value; }
        }

        public int Experience
        {
            get { return experience; }
            set { experience = value; }
        }
    }
}
