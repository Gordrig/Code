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
    class Enemy
    {
        private Texture2D enemy_texture;
        private int health;
        private double enemy_x;
        private double enemy_y;
        private float enemy_rotation;
        private Rectangle enemyRect;
        private bool isDead;

        public Enemy(double x, double y, float rotation, int health, Texture2D enemyTexture)
        {
            this.health = health;
            enemy_x = x;
            enemy_y = y;
            enemy_rotation = rotation;
            enemyRect = new Rectangle((int)enemy_x, (int)enemy_y, 23, 23);
            enemy_texture = enemyTexture;
            isDead = false;
        }

        public void Move()
        {
            float DistX = Game1.player1.PlayerRect.Center.X - enemyRect.Center.X;
            float DistY = Game1.player1.PlayerRect.Center.Y - enemyRect.Center.Y;

            float DistHypo = (float)Math.Sqrt(Math.Pow(DistX, 2) + Math.Pow(DistY, 2));

            if (DistHypo <= 125)
            {
                enemy_x += (DistX / DistHypo);
                enemy_y += (DistY / DistHypo);
                if (DistY < 0)
                {
                    enemy_rotation = (float)Math.Atan(DistX / -DistY);
                }
                else if (DistX > 0)
                {
                    enemy_rotation = (float)Math.Atan(DistY / DistX) + (float)(Math.PI/2);
                }
                else if (DistX < 0)
                {
                    enemy_rotation = (float)Math.Atan(DistY / DistX) - (float)(Math.PI / 2);
                }
            }
        }

        public void Update()
        {
            enemyRect = new Rectangle((int)this.enemy_x - 13, (int)this.enemy_y - 13, 23, 23);
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public double Enemy_x
        {
            get { return enemy_x; }
            set { enemy_x = value; }
        }

        public double Enemy_y
        {
            get { return enemy_y; }
            set { enemy_y = value; }
        }

        public float Enemy_rotation
        {
            get { return enemy_rotation; }
            set { enemy_rotation = value; }
        }

        public Texture2D Enemy_texture
        {
            get { return enemy_texture; }
            set { enemy_texture = value; }
        }

        public Rectangle EnemyRect
        {
            get { return enemyRect; }
            set { enemyRect = value; }
        }

        public bool IsDead
        {
            get { return isDead; }
            set { isDead = value; }
        }
    }
}
