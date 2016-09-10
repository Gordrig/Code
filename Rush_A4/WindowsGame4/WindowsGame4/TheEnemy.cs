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
    class TheEnemy
    {
        private static Texture2D enemyBrown;
        private static Texture2D enemyGreenBrown;
        private static Texture2D enemyNormal;
        private static Texture2D enemyGuard;
        private static Texture2D enemyKnight;
        private static Texture2D enemyEliteKnight;

        private static Enemy[] castleEnemyArray;
        private static Enemy[] plainsEnemyArray;
        private static Enemy[] caveEnemyArray;

        // the plains area enemies
        private static Enemy plainsEnemy1;
        private static Enemy plainsEnemy2;
        private static Enemy plainsEnemy3;
        private static Enemy plainsEnemy4;
        private static Enemy plainsEnemy5;
        private static Enemy plainsEnemy6;
        private static Enemy plainsEnemy7;
        private static Enemy plainsEnemy8;
        private static Enemy plainsEnemy9;
        private static Enemy plainsEnemy10;
        private static Enemy plainsEnemy11;
        private static Enemy plainsEnemy12;
        private static Enemy plainsEnemy13;
        private static Enemy plainsEnemy14;
        
        // the forest area enemies
        private static Enemy forestEnemy1;
        private static Enemy forestEnemy2;
        private static Enemy forestEnemy3;
        private static Enemy forestEnemy4;
        private static Enemy forestEnemy5;
        private static Enemy forestEnemy6;
        private static Enemy forestEnemy7;
        private static Enemy forestEnemy8;
        private static Enemy forestEnemy9;
        private static Enemy forestEnemy10;
        private static Enemy forestEnemy11;
        private static Enemy forestEnemy12;

        // an array to hold the forest area enemies
        private static Enemy[] forestEnemyArray;


        public static Enemy[] PlainsEnemyArray
        {
            get { return plainsEnemyArray; }
            set { plainsEnemyArray = value; }
        }
        public static Enemy[] ForestEnemyArray
        {
            get { return forestEnemyArray;}
            set { forestEnemyArray = value; }
        }

        public static Texture2D EnemyBrown
        {
            get { return enemyBrown; }
            set { enemyBrown = value; }
        }
        public static Texture2D EnemyGreenBrown
        {
            get { return enemyGreenBrown; }
            set { enemyGreenBrown = value; }
        }
        public static Texture2D EnemyNormal
        {
            get { return enemyNormal; }
            set { enemyNormal = value; }
        }
        public static Texture2D EnemyGuard
        {
            get { return enemyGuard; }
            set { enemyGuard = value; }
        }
        public static Texture2D EnemyKnight
        {
            get { return enemyKnight; }
            set { enemyKnight = value; }
        }
        public static Texture2D EnemyEliteKnight
        {
            get { return enemyEliteKnight; }
            set { enemyEliteKnight = value; }
        }

        public static void Initialize()
        {
            // plains enemies
            plainsEnemy1 = new Enemy(525 + 13, 75 + 13, (float)((2 * Math.PI) / 2), 100, enemyBrown);
            plainsEnemy2 = new Enemy(450 + 13, 150 + 13, (float)((Math.PI) / 2), 100, enemyBrown);
            plainsEnemy3 = new Enemy(450 + 13, 250 + 13, 0, 100, enemyBrown);
            plainsEnemy4 = new Enemy(375 + 13, 325 + 13, (float)((Math.PI) / 2), 100, enemyBrown);
            plainsEnemy5 = new Enemy(475 + 13, 350 + 13, (float)((Math.PI) / 2), 100, enemyBrown);
            plainsEnemy6 = new Enemy(725 + 13, 425 + 13, (float)((2 * Math.PI) / 2), 200, enemyGreenBrown);
            plainsEnemy7 = new Enemy(625 + 13, 475 + 13, 0, 200, enemyGreenBrown);
            plainsEnemy8 = new Enemy(500 + 13, 525 + 13, (float)((Math.PI) / 2), 200, enemyGreenBrown);
            plainsEnemy9 = new Enemy(275 + 13, 100 + 13, (float)((Math.PI) / 2), 325, enemyNormal);
            plainsEnemy10 = new Enemy(275 + 13, 175 + 13, (float)((Math.PI) / 2), 325, enemyNormal);
            plainsEnemy11 = new Enemy(200 + 13, 50 + 13, (float)((2 * Math.PI) / 2), 325, enemyNormal);
            plainsEnemy12 = new Enemy(200 + 13, 225 + 13, 0, 325, enemyNormal);
            plainsEnemy13 = new Enemy(50 + 13, 200 + 13, 0, 325, enemyNormal);
            plainsEnemy14 = new Enemy(125 + 13, 450 + 13, 0, 1000, enemyKnight);

            plainsEnemyArray = new Enemy[14] { plainsEnemy1, plainsEnemy2, plainsEnemy3, plainsEnemy4, plainsEnemy5, plainsEnemy6, plainsEnemy7, plainsEnemy8, plainsEnemy9, plainsEnemy10, plainsEnemy11, plainsEnemy12, plainsEnemy13, plainsEnemy14 };
            
            // forest enemies
            forestEnemy1 = new Enemy(50 + 13, 50 + 13, (float)((Math.PI) / 2), 500, enemyGreenBrown);
            forestEnemy2 = new Enemy(50 + 13, 250 + 13, (float)((Math.PI) / 2), 500, enemyGreenBrown);
            forestEnemy3 = new Enemy(200 + 13, 250 + 13, 0, 500, enemyGreenBrown);
            forestEnemy4 = new Enemy(325 + 13, 200 + 13, (float)((3 * Math.PI) / 2), 500, enemyGreenBrown);
            forestEnemy5 = new Enemy(300 + 13, 325 + 13, (float)((3 * Math.PI) / 2), 500, enemyGreenBrown);
            forestEnemy6 = new Enemy(225 + 13, 400 + 13, 0, 500, enemyGreenBrown);
            forestEnemy7 = new Enemy(350 + 13, 500 + 13, (float)((Math.PI) / 2), 750, enemyGuard);
            forestEnemy8 = new Enemy(500 + 13, 525 + 13, (float)((3 * Math.PI) / 2), 750, enemyGuard);
            forestEnemy9 = new Enemy(675 + 13, 525 + 13, (float)((3 * Math.PI) / 2), 750, enemyGuard);
            forestEnemy10 = new Enemy(600 + 13, 400 + 13, (float)((2 * Math.PI) / 2), 1250, enemyKnight);
            forestEnemy11 = new Enemy(650 + 13, 400 + 13, (float)((2 * Math.PI) / 2), 1250, enemyKnight);
            forestEnemy12 = new Enemy(625 + 13, 75 + 13, (float)((2 * Math.PI) / 2), 3000, enemyEliteKnight);

            forestEnemyArray = new Enemy[12] { forestEnemy1, forestEnemy2, forestEnemy3, forestEnemy4, forestEnemy5, forestEnemy6, forestEnemy7, forestEnemy8, forestEnemy9, forestEnemy10, forestEnemy11, forestEnemy12 };
        }

        public static void Update()
        {
            if (Transitions.Location == 2)
            {
                foreach (Enemy e in TheEnemy.PlainsEnemyArray)
                {
                    if (e.Health <= 0)
                    {
                        e.EnemyRect = Rectangle.Empty;
                    }
                    else
                    {
                        e.Move();
                        e.Update();
                    }
                    if (e.Health <= 0 && !e.IsDead)
                    {
                        Game1.player1.Experience += 50;
                        e.IsDead = true;
                    }
                }
            }
            else if (Transitions.Location == 3)
            {
                foreach (Enemy e in TheEnemy.ForestEnemyArray)
                {
                    if (e.Health <= 0)
                    {
                        e.EnemyRect = Rectangle.Empty;
                    }
                    else
                    {
                        e.Move();
                        e.Update();
                    }
                }
            }
            else if (Transitions.Location == 4)
            {
                /*foreach (Enemy e in TheEnemy.CaveEnemyArray)
                {
                    if (e.Health <= 0)
                    {
                        e.EnemyRect = Rectangle.Empty;
                    }
                    else
                    {
                        e.Move();
                        e.Update();
                    }
                }*/
            }
        }
    }
}
