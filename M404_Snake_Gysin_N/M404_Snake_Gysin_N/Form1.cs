//INF2018.d, Noah Gysin, 22.05.2019

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M404_Snake_Gysin_N
{
    public partial class Form1 : Form
    {
        private int directionx = 25;
        private int directiony = 0;
        List<System.Windows.Forms.PictureBox> snake = new List<System.Windows.Forms.PictureBox>();
        List<int> pointHistory = new List<int>();
        private PictureBox snakeHead;
        private PictureBox[] apples = new PictureBox[10];
        private int score = 0;
        private int bodiesToAdd = 0;
        string rootDir;
        int lastDirectionX = 25;
        int lastDirectionY = 0;

        public Form1()
        {
            InitializeComponent();
            string workingDir = Environment.CurrentDirectory;            //Hier wird der working Pfad (also /bin/debug) geholt
            rootDir = Directory.GetParent(workingDir).Parent.FullName;   //und hier dann den root Pfad des Projekts um dann unten auf die Bilder zuzugreifen können
            addApples();
            this.BringToFront();
            this.Focus();
            this.KeyPreview = true;
            txt_score.Text = "0";
            addSnake();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            snakeHead = snake[snake.Count -1];
            int x = snakeHead.Location.X + directionx;
            int y = snakeHead.Location.Y + directiony;
            PictureBox newSnake = addSnake();
            newSnake.Location = new Point(x, y);
            newSnake.BringToFront();
            drawLastSnake(newSnake);
            if (bodiesToAdd > 0)
            {
                bodiesToAdd -= 1;
            }
            else
            {
                pnl_game.Controls.Remove(snake[0]);
                snake.RemoveAt(0);
                PictureBox lastSnake = snake[0];
                if (snake.Count() > 1)
                {
                    if (lastSnake.Location.X < snake[1].Location.X)
                    {
                        lastSnake.Image = Image.FromFile(rootDir + "\\Properties\\Images\\Schlange\\SchlangenEndeLinks.jpg");
                    }
                    if (lastSnake.Location.X > snake[1].Location.X)
                    {
                        lastSnake.Image = Image.FromFile(rootDir + "\\Properties\\Images\\Schlange\\SchlangenEndeRechts.jpg");
                    }
                    if (lastSnake.Location.Y > snake[1].Location.Y)
                    {
                        lastSnake.Image = Image.FromFile(rootDir + "\\Properties\\Images\\Schlange\\SchlangenEndeUnten.jpg");
                    }
                    if (lastSnake.Location.Y < snake[1].Location.Y)
                    {
                        lastSnake.Image = Image.FromFile(rootDir + "\\Properties\\Images\\Schlange\\SchlangenEndeOben.jpg");
                    }
                }

            }
            if (newSnake.Location.X + 25 > pnl_game.Width || newSnake.Location.Y + 25 > pnl_game.Height || newSnake.Location.X + 1 < 0 || newSnake.Location.Y + 1 < 0)
            {
                timer1.Enabled = false;
                btn_addPoints.Enabled = true;
            }
            for (int i=0; i<10; i++)
            {
                PictureBox apple = apples[i];
                if (apple != null)
                {
                    if (apple.Location.X == snakeHead.Location.X && apple.Location.Y == snakeHead.Location.Y)
                    {
                        apples[i] = null;
                        pnl_game.Controls.Remove(apple);
                        int a = i+1;
                        score += a;
                        txt_score.Text = score.ToString();
                        bodiesToAdd += a;
                        if (!addApples())
                        {
                            addApples();
                        }
                    }
                }
            }
            for (int i = 0; i < snake.Count(); i++)
            {
                PictureBox snakeBody = snake[i];
                if (!(snakeBody == newSnake))
                {
                    if (snakeBody.Location.X == newSnake.Location.X && snakeBody.Location.Y == newSnake.Location.Y)
                    {
                        timer1.Enabled = false;
                        btn_addPoints.Enabled = true;
                    }
                }
            }
            lastDirectionX = directionx;
            lastDirectionY = directiony;
        }

        private void drawLastSnake(PictureBox newSnake)
        {
            if (snakeHead.Location.X < newSnake.Location.X)
            {
                snakeHead.Image = Image.FromFile(rootDir + "\\Properties\\Images\\Schlange\\SchlangeHorizontal.jpg");
            }
            if (snakeHead.Location.X > newSnake.Location.X)
            {
                snakeHead.Image = Image.FromFile(rootDir + "\\Properties\\Images\\Schlange\\SchlangeHorizontal.jpg");
            }
            if (snakeHead.Location.Y > newSnake.Location.Y)
            {
                snakeHead.Image = Image.FromFile(rootDir + "\\Properties\\Images\\Schlange\\SchlangeVertikal.jpg");
            }
            if (snakeHead.Location.Y < newSnake.Location.Y)
            {
                snakeHead.Image = Image.FromFile(rootDir + "\\Properties\\Images\\Schlange\\SchlangeVertikal.jpg");
            }
            if ((directionx == 25 && lastDirectionY == -25) || (directiony == 25 && lastDirectionX == -25))
            {
                snakeHead.Image = Image.FromFile(rootDir + "\\Properties\\Images\\Schlange\\SchlangeRechts_Unten.jpg");
            }
            if ((directionx == 25 && lastDirectionY == 25) || (directiony == -25 && lastDirectionX == -25))
            {
                snakeHead.Image = Image.FromFile(rootDir + "\\Properties\\Images\\Schlange\\SchlangeRechts_Oben.jpg");
            }
            if ((directionx == -25 && lastDirectionY == -25) || (directiony == 25 && lastDirectionX == 25))
            {
                snakeHead.Image = Image.FromFile(rootDir + "\\Properties\\Images\\Schlange\\SchlangeLinks_Unten.jpg");
            }
            if ((directionx == -25 && lastDirectionY == 25) || (directiony == -25 && lastDirectionX == 25))
            {
                snakeHead.Image = Image.FromFile(rootDir + "\\Properties\\Images\\Schlange\\SchlangeLinks_Oben.jpg");
            }
        }


        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'w' && directiony != 25)
            {
                directiony = -25;
                directionx = 0;
            }
            if (e.KeyChar == 's' && directiony != -25)
            {
                directiony = 25;
                directionx = 0;
            }
            if (e.KeyChar == 'a' && directionx != 25)
            {
                directionx = -25;
                directiony = 0;
            }
            if (e.KeyChar == 'd' && directionx != -25)
            {
                directionx = 25;
                directiony = 0;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up && directiony != 25)
            {
                directiony = -25;
                directionx = 0;
            }
            if (e.KeyData == Keys.Down && directiony != -25)
            {
                directiony = 25;
                directionx = 0;
            }
            if (e.KeyData == Keys.Left && directionx != 25)
            {
                directionx = -25;
                directiony = 0;
            }
            if (e.KeyData == Keys.Right && directionx != -25)
            {
                directionx = 25;
                directiony = 0;
            }
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            btn_start.Enabled = false;
            btn_addPoints.Enabled = false;
        }

        private System.Windows.Forms.PictureBox addSnake()
        {
            Image img = null;
            if (directionx == 25)
            {
                img = Image.FromFile(rootDir + "\\Properties\\Images\\Schlange\\SchlangenKopfRechts.jpg");
            }
            if (directionx == -25)
            {
                img = Image.FromFile(rootDir + "\\Properties\\Images\\Schlange\\SchlangenKopfLinks.jpg");
            }
            if (directiony == 25)
            {
                img = Image.FromFile(rootDir + "\\Properties\\Images\\Schlange\\SchlangenKopfUnten.jpg");
            }
            if (directiony == -25)
            {
                img = Image.FromFile(rootDir + "\\Properties\\Images\\Schlange\\SchlangenKopfOben.jpg");
            }

            PictureBox snakeBody = new PictureBox
            {
                Size = new Size(25, 25),
                Image = img,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            snake.Add(snakeBody);
            pnl_game.Controls.Add(snakeBody);
            return snakeBody;
        }

        private bool addApples()
        {
            Image img = Image.FromFile(rootDir + "\\Properties\\Images\\Aepfel\\Apfel1.jpg"); //Hier wird der root Pfad verwednet, damit die Bilder auch auf anderen PC's geholt werden können wo der Pfad nicht identisch ist
            Random random = new Random();
            int x = random.Next(575/25) * 25;
            int y = random.Next(450/25) * 25;
            for (int i = 0; i < snake.Count(); i++)
            {
                if (snake[i].Location.X == x && snake[i].Location.Y == y)
                {
                    return false;
                }
            }

            PictureBox apple = new PictureBox
            {
                Size = new Size(25, 25),
                Image = img,
                Location = new Point(x, y),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            pnl_game.Controls.Add(apple);
            apples[0] = apple;
            return true;
        }

        private void resetSnake()
        {
            for (int i = 0; i<snake.Count(); i++)
            {
                PictureBox x = snake[i];
                pnl_game.Controls.Remove(x);
            }
            snake.Clear();
        }

        private void resetApples()
        {
            for (int i = 0; i < 10; i++)
            {
                PictureBox x = apples[i];
                pnl_game.Controls.Remove(x);
                apples[i] = null;
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Enabled = false;
            }
            timer1.Interval = 200;
            bodiesToAdd = 0;
            score = 0;
            txt_score.Text = "0";
            directionx = 25;
            directiony = 0;
            resetSnake();
            resetApples();
            addSnake().BackColor = Color.GreenYellow;
            addApples();
            btn_start.Enabled = true;
            if (btn_addPoints.Enabled)
            {
                btn_addPoints.Enabled = false;
            }
        }

        private void btn_addPoints_Click(object sender, EventArgs e)
        {
            btn_addPoints.Enabled = false;
            pointHistory.Insert(0, score); //Hier wird insert verwedet, damit die zuletzt eingetragene Punktzahl immer zu oberst angezeigt wird.
            for (int i = 0; i < pointHistory.Count(); i++)
            {
                Label scoreBox = new Label
                {
                    Size = new Size(pnl_points.Width, 20),
                    Text = pointHistory[i].ToString(),
                    Location = new Point(5, i * 20)
                };
                pnl_points.Controls.Add(scoreBox);
                scoreBox.BringToFront();
            }
        }
    }
}
