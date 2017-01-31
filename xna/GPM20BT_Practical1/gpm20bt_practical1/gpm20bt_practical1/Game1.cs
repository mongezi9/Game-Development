/*
 Name & Surname: Emmanuel Mthimunye
 Date: 2013 Sept 5
 Implementing Artificial Intelligent level 1,2,3 and 4 in Game design
 * Main Class
 */

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

namespace GPM20BT_Practical1
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        const int size = 50;
        const int numImages = 50;
        int action = 0;
        int windowWidth = 1000;
        int windowHeight = 800;
        MouseState pastMouse;
        int currentView = 1;
        Button[] myButton = new Button[50];
        float bullDistace = 0f;
        int enemy;
        int me;
        double newAngle;
        Random rand = new Random();
        const int numUnits = 4;
        int camX = 0;
        int camY = 0;
        bool fight = false;
        int score = 0;
        int frames = 0;
        int numFrames = 14;
        bool save = false;
        string textString;
        KeyboardState oldKeyboardState;
        KeyboardState currentKeyboardState;
        bool entered = false;
        string gameNames = "Saved.txt";
        string savedGames;
        float volume = 0f;
        KeyboardState pastkey;
        int bulletsCounter = 0;
        string ipAddress;
        Network network;
        float distance = 0;
        bool plotUnits = false;
        bool plotTiles = false;
        int unitPic;
        const int numTiles = 4;
        const int numMapTiles = 60;
        const int numButtons = 15;
        const int row = 60;
        const int col = 60;
        string Map_GameName = "gameNames.txt";
        string map_GameNames = "gameNames.txt";
        int vWSize = 0;
        int sPosX;
        int posYY = -300;
        int sPosY;
        bool map_Save = false;
        bool map_Load = false;
        Color myColor;
        string lineForGameNames;
        int mapAction;
        int type;
        string error;
        bool error_Active = false;
        int posX = 770;
        int posY = 600;
        Point startPos;
        Point end;
        int selectedUnit;
        bool[,] unitsMap = new bool[60, 60];
        int tank = 1;
        int ship = 2;
        int plane = 3;
        int car = 4;
        Path p = new Path();
        int unitType;
        List<Units> mapUnits;
        List<Units> units;
        List<Bullets> myBullets;
        const int numNetButtons = 4;
        List<MyButtonPics> loadButtons;
        int netAction = 0;
        bool showNet = false;
        bool showNetConnect = false;
        bool chat = false;
        bool findPath = false;
        int Unitside = 0;
        bool showShop;
        bool moveUnit = false;
        bool showGameNames = false;
        bool loadAct = false;
        bool shift = false;
        int loadAction;
        float scale = 1;

        Texture2D[] tiles = new Texture2D[numButtons];
        MapTiles[,] myTiles = new MapTiles[row, col];
        MyButtonPics[] buttons = new MyButtonPics[numButtons];
        Texture2D loadButton;
        Texture2D minimap;
        Texture2D input;
        Texture2D InterFace;
        Texture2D[] minMapSprite = new Texture2D[5];
        Texture2D connected;
        Texture2D messageBox2;
        Texture2D head;
        Texture2D GameOver;
        Texture2D storyLineBack;
        Texture2D input2;
        Matrix SpriteScale;
        String GameNames = "GameNamesFile";
        Texture2D win;
        Button[] netButtons = new Button[numNetButtons];
        Texture2D[] explode = new Texture2D[15];
        Texture2D[] netBtPics = new Texture2D[7];
        Texture2D networkMenu;
        Texture2D messageBox;
        Texture2D[] BigUnits = new Texture2D[4];
        Texture2D[] life = new Texture2D[10];
        Texture2D[] side = new Texture2D[10];
        Texture2D whiteCircle;
        Texture2D back2;
        Texture2D shop;
        Texture2D btnLoad;
        Texture2D mapInterFace;
        Texture2D[] unitsPics = new Texture2D[numUnits];
        Texture2D[] myButtonPictures = new Texture2D[numImages];
        Texture2D bullet;
        Texture2D game;
        SoundEffect[] mouseClick = new SoundEffect[8];
        SoundEffectInstance control;
        SoundEffectInstance control2;
        SoundEffect bulletSound;
        SoundEffectInstance bulletInstance;
        SoundEffect bulletSound2;
        SoundEffectInstance bulletS2;
        Texture2D gameBack;
        SoundEffect start;
        SoundEffectInstance start1;
        SoundEffect menu;
        SoundEffectInstance menuInstance;
        SoundEffect[] explotions = new SoundEffect[4];
        SoundEffectInstance explotionsIn;
        SpriteFont myFont;
        SoundEffect backmusic;
        SoundEffectInstance backmusicInstace;
        Texture2D storyLine;
        Texture2D saveButton;
        SpriteFont mapFont;
        SpriteFont Font;
        SpriteFont ipFont;


      

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = windowHeight;
            graphics.PreferredBackBufferWidth = windowWidth;
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            loadButtons = new List<MyButtonPics>();
            buttons[0] = new MyButtonPics(new Vector2(265, 735), 0, 1);
            buttons[1] = new MyButtonPics(new Vector2(326, 735), 1, 2);
            buttons[2] = new MyButtonPics(new Vector2(390, 735), 2, 3);
            buttons[3] = new MyButtonPics(new Vector2(454, 735), 3, 4);
            buttons[4] = new MyButtonPics(new Vector2(515, 735), 4, 5);
            buttons[5] = new MyButtonPics(new Vector2(770, 592), 5, 6);
            buttons[6] = new MyButtonPics(new Vector2(920, 592), 6, 7);
            buttons[7] = new MyButtonPics(new Vector2(845, 620), 7, 8);
            buttons[8] = new MyButtonPics(new Vector2(265, 660), 8, 9);
            buttons[9] = new MyButtonPics(new Vector2(326, 660), 9, 10);
            buttons[10] = new MyButtonPics(new Vector2(390, 660), 10, 11);
            buttons[11] = new MyButtonPics(new Vector2(454, 660), 11, 12);
            vWSize = row * 40;
            network = new Network();
            ipAddress = "127.0.0.1";
            mapUnits = new List<Units>();
            units = new List<Units>();
            textString = "";
            myBullets = new List<Bullets>();
            for (int x = 0; x < col; x++)
            {
                for (int y = 0; y < row; y++)
                {
                    myTiles[x, y] = new MapTiles(0, new Vector2(-vWSize / 2 + x * 50, -vWSize / 2 + y * 50));
                }

            }
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //Map Editor;
            mapInterFace = Content.Load<Texture2D>(@"image\Map\MapInterface");
            mapFont = Content.Load<SpriteFont>(@"Image\Map\myFont");
            Font = Content.Load<SpriteFont>(@"Image\Map\sprite1");
            input = Content.Load<Texture2D>(@"image\Map\input");
            saveButton = Content.Load<Texture2D>(@"image\Map\type6");
            loadButton = Content.Load<Texture2D>(@"image\Map\type7");
            minimap = Content.Load<Texture2D>(@"image\Map\minimap");
            InterFace = Content.Load<Texture2D>(@"image\Map\interface");
            networkMenu = Content.Load<Texture2D>(@"image\Map\netMenu");
            connected = Content.Load<Texture2D>(@"image\Network\pic5");
            messageBox = Content.Load<Texture2D>(@"image\Network\pic7");
            messageBox2 = Content.Load<Texture2D>(@"image\Network\pic6");
            ipFont = Content.Load<SpriteFont>(@"image\Network\ipFont");
            whiteCircle = Content.Load<Texture2D>(@"image\cycle");
            shop = Content.Load<Texture2D>(@"image\shop");
            back2 = Content.Load<Texture2D>(@"image\back2");
            bullet = Content.Load<Texture2D>(@"image\Bullets");
            btnLoad = Content.Load<Texture2D>(@"image\Map\input");
            head = Content.Load<Texture2D>(@"image\head");
            GameOver = Content.Load<Texture2D>(@"image\gameOver");
            win = Content.Load<Texture2D>(@"image\win");
            

            storyLineBack = Content.Load<Texture2D>(@"image\storyline");
            showNet = false;

            float screenscale = graphics.GraphicsDevice.Viewport.Width / 1000f;
            SpriteScale = Matrix.CreateScale(screenscale, screenscale, 1);

            for (int x = 0; x < 4; x++)
            {
                BigUnits[x] = Content.Load<Texture2D>(@"image\Units\unit" + (x + 1).ToString());
            }
            for (int x = 0; x < 2; x++)
            {
                side[x] = Content.Load<Texture2D>(@"image\life\side" + (x + 1).ToString());
            }
            for (int x = 0; x < 12; x++)
            {
                tiles[x] = Content.Load<Texture2D>(@"image\Map\type" + (x + 1).ToString());
            }
            tiles[13] = Content.Load<Texture2D>(@"image\Map\input");
            sPosX = Window.ClientBounds.Width / 2 - saveButton.Width / 2;
            sPosY = Window.ClientBounds.Height / 2 - input.Height / 2 + 30;
            //End of map
            for (int x = 0; x < 15; x++)
            {
                explode[x] = Content.Load<Texture2D>((@"image\explode3\screen" + (x + 1).ToString()));
            }

            for (int i = 0; i < 38; i++)
            {
                myButtonPictures[i] = Content.Load<Texture2D>(@"image\Buttons\pic" + (i + 1).ToString());
            }
            for (int i = 0; i < 4; i++)
            {
                netBtPics[i] = Content.Load<Texture2D>(@"image\Network\pic" + (i + 1).ToString());
            }
            netBtPics[4] = Content.Load<Texture2D>(@"image\Network\pic8");
            netBtPics[5] = Content.Load<Texture2D>(@"image\Network\pic9");
            netBtPics[6] = Content.Load<Texture2D>(@"image\Network\pic10");

            for (int i = 0; i < 5; i++)
            {
                minMapSprite[i] = Content.Load<Texture2D>(@"image\map\minSprite" + (i + 1).ToString());
            }
            for (int i = 0; i < numUnits; i++)
            {
                unitsPics[i] = Content.Load<Texture2D>(@"image\Units\pic" + (i + 1).ToString());
            }
            for (int i = 0; i < 10; i++)
            {
                life[i] = Content.Load<Texture2D>(@"image\life\life" + (i + 1).ToString());
            }
            for (int m = 0; m < 8; m++)
            {
                mouseClick[m] = Content.Load<SoundEffect>(@"Sound\mouseclick\mouseclick" + (m + 1).ToString());
                control2 = mouseClick[m].CreateInstance();
            }
            gameBack = Content.Load<Texture2D>(@"image\mainBack");
            for (int m = 0; m < 4; m++)
            {
                explotions[m] = Content.Load<SoundEffect>(@"Sound\Bullets\explosion" + (m + 1).ToString());

            }
            explotionsIn = explotions[1].CreateInstance();
            start = Content.Load<SoundEffect>(@"Sound\Music\Numb");
            start1 = start.CreateInstance();


            menu = Content.Load<SoundEffect>(@"Sound\Music\Numb0");
            menuInstance = menu.CreateInstance();

            backmusic = Content.Load<SoundEffect>(@"Sound\Music\sound0");
            backmusicInstace = backmusic.CreateInstance();

            bulletSound = Content.Load<SoundEffect>(@"Sound\Bullets\shoot1");
            bulletInstance = bulletSound.CreateInstance();
            input2 = Content.Load<Texture2D>(@"image\Map\input2");

            start1.Play();
            //Buttons
            myButton[0] = new Button(new Vector2(Window.ClientBounds.Width / 2 - myButtonPictures[1].Width / 2, 420), 0, 1, 1, 1, mouseClick);
            myButton[28] = new Button(new Vector2(Window.ClientBounds.Width / 2 - myButtonPictures[1].Width / 2, 660), 18, 19, 30, 1, mouseClick);
            myButton[1] = new Button(new Vector2(Window.ClientBounds.Width / 2 - myButtonPictures[2].Width / 2, 500), 2, 3, 2, 1, mouseClick);
            myButton[2] = new Button(new Vector2(Window.ClientBounds.Width / 2 - myButtonPictures[4].Width / 2, 580), 4, 5, 3, 1, mouseClick);
            myButton[3] = new Button(new Vector2(Window.ClientBounds.Width / 2 - myButtonPictures[6].Width / 2, 740), 6, 7, 4, 1, mouseClick);
            myButton[4] = new Button(new Vector2(Window.ClientBounds.Width / 2 - myButtonPictures[8].Width / 2, 440), 8, 9, 5, 2, mouseClick);
            myButton[5] = new Button(new Vector2(Window.ClientBounds.Width / 2 - myButtonPictures[10].Width / 2, 520), 10, 11, 6, 2, mouseClick);
            myButton[6] = new Button(new Vector2(Window.ClientBounds.Width / 2 - myButtonPictures[12].Width / 2, 620), 22, 23, 7, 2, mouseClick);
            myButton[7] = new Button(new Vector2(Window.ClientBounds.Width / 2 - myButtonPictures[14].Width / 2, 420), 14, 15, 8, 3, mouseClick);
            myButton[8] = new Button(new Vector2(Window.ClientBounds.Width / 2 - myButtonPictures[16].Width / 2, 500), 16, 17, 9, 3, mouseClick);
            myButton[9] = new Button(new Vector2(Window.ClientBounds.Width / 2 - myButtonPictures[22].Width / 2, 600), 22, 23, 10, 3, mouseClick);
            myButton[10] = new Button(new Vector2(Window.ClientBounds.Width / 2 - myButtonPictures[20].Width / 2, 420), 20, 21, 11, 4, mouseClick);
            myButton[11] = new Button(new Vector2(Window.ClientBounds.Width / 2 - myButtonPictures[22].Width / 2, 700), 22, 23, 12, 4, mouseClick);
            myButton[15] = new Button(new Vector2(Window.ClientBounds.Width / 2 - myButtonPictures[12].Width / 2, 540), 28, 29, 16, 4, mouseClick);
            myButton[16] = new Button(new Vector2(Window.ClientBounds.Width / 2 - myButtonPictures[12].Width / 2, 620), 30, 31, 17, 4, mouseClick);
            myButton[12] = new Button(new Vector2(Window.ClientBounds.Width / 2 - myButtonPictures[24].Width / 2, 420), 24, 25, 13, 5, mouseClick);
            myButton[13] = new Button(new Vector2(Window.ClientBounds.Width / 2 - myButtonPictures[26].Width / 2, 500), 26, 27, 14, 5, mouseClick);
            myButton[14] = new Button(new Vector2(Window.ClientBounds.Width / 2 - myButtonPictures[12].Width / 2, 580), 22, 23, 15, 5, mouseClick);
            myButton[17] = new Button(new Vector2(Window.ClientBounds.Width / 2 - myButtonPictures[12].Width / 2, 600), 22, 23, 18, 6, mouseClick);
            myButton[18] = new Button(new Vector2(Window.ClientBounds.Width / 2 - myButtonPictures[32].Width / 2, 400), 32, 32, 19, 6, mouseClick);
            myButton[19] = new Button(new Vector2(550, 480), 35, 35, 20, 6, mouseClick);
            myButton[20] = new Button(new Vector2(Window.ClientBounds.Width / 2 - myButtonPictures[12].Width / 2, 500), 22, 23, 21, 7, mouseClick);
            myButton[21] = new Button(new Vector2(Window.ClientBounds.Width / 2 - myButtonPictures[32].Width / 2, 420), 32, 32, 22, 7, mouseClick);
            myButton[22] = new Button(new Vector2(Window.ClientBounds.Width / 2 - myButtonPictures[22].Width / 2, 420), 36, 37, 23, 10, mouseClick);
            myButton[23] = new Button(new Vector2(Window.ClientBounds.Width / 2 - myButtonPictures[22].Width / 2, 500), 4, 5, 24, 10, mouseClick);
            myButton[24] = new Button(new Vector2(360, 400), 33, 33, 25, 11, mouseClick);
            myButton[25] = new Button(new Vector2(460, 480), 34, 34, 27, 11, mouseClick);
            myButton[26] = new Button(new Vector2(Window.ClientBounds.Width / 2 - myButtonPictures[12].Width / 2, 520), 22, 23, 26, 11, mouseClick);
            myButton[27] = new Button(new Vector2(Window.ClientBounds.Width / 2 - myButtonPictures[12].Width / 2, 420), 22, 23, 28, 12, mouseClick);

            netButtons[0] = new Button(new Vector2(220, 30), 0, 1, 1, 8, mouseClick);
            netButtons[1] = new Button(new Vector2(220, 60), 2, 3, 2, 8, mouseClick);
            netButtons[2] = new Button(new Vector2(400, 65), 0, 1, 3, 8, mouseClick);
            netButtons[3] = new Button(new Vector2(400, 95), 4, 5, 4, 8, mouseClick);


            myButton[29] = new Button(new Vector2(Window.ClientBounds.Width / 2 - myButtonPictures[1].Width / 2, 300), 0, 1, 29, 14, mouseClick);
            myButton[30] = new Button(new Vector2(Window.ClientBounds.Width / 2 - myButtonPictures[12].Width / 2, 460), 24, 25, 31, 14, mouseClick);
            // TODO: use this.Content to load your game content here

        }

        protected override void UnloadContent()
        {
            Content.Unload();
            netButtons[0] = new Button(new Vector2(220, 30), 22, 23, 28, 12, mouseClick);
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            MoveCam();
            menuS();
            //netWorkMenu();


            UpdateInput();


            base.Update(gameTime);
        }
        int posXX = -1000;
        int posXX2 = 1000;
        int storyPosY = 500;
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            //spriteBatch.Begin(SpriteSortMode.Texture, SpriteSortMode.Deferred, SamplerState.PointClamp, DepthStencilState.Default
            // , SpriteScale);
            //Draw Buttons
            //spriteBatch.Begin(SpriteSortMode.FrontToBack,BlendState.AlphaBlend,SamplerState.PointClamp,DepthStencilState.Default,null, null, SpriteScale);
            bool skip = false;

            if (Keyboard.GetState().IsKeyDown(Keys.Enter))

                skip = true;

            if (storyPosY + 495 >= 0)
            {
                storyPosY--;


                // spriteBatch.Draw(storyLineBack, new Vector2(0, 0), Color.White);
                spriteBatch.Draw(storyLineBack, new Vector2(Window.ClientBounds.Width / 2 - storyLineBack.Width / 2, storyPosY), Color.White);
                if (skip == true)
                {
                    storyPosY = -500;
                }

            }


            if (storyPosY + 495 < 0)
            {
                //spriteBatch.Begin(SpriteSortMode.FrontToBack,BlendState.AlphaBlend,SamplerState.PointClamp,null,null, null,globalScale);

                if (currentView == 1)
                {
                    spriteBatch.Draw(gameBack, new Vector2(0, 0), Color.White);
                }
                if (currentView == 2)
                {
                    spriteBatch.Draw(gameBack, new Vector2(0, 0), Color.White);
                }
                if (currentView == 14)
                {
                    if (posXX < 0)
                    {
                        posXX += 100;

                    }
                    spriteBatch.Draw(gameBack, new Vector2(posXX, 0), Color.White);

                }
                if (currentView == 15)
                {
                    posXX = -1000;
                    //  saveAndload();

                    if (posXX2 > 0)
                    {
                        posXX2 -= 100;

                    }
                    spriteBatch.Draw(gameBack, new Vector2(posXX2, 0), Color.White);
                    if (showGameNames == false)
                    {
                        if (posY >= 0)
                        {
                            posYY -= 20;

                        }
                        spriteBatch.Draw(shop, new Vector2(Window.ClientBounds.Width / 2 - shop.Width / 2, posYY), Color.White);
                    }

                    if (showGameNames == true)
                    {
                        if (posYY < 0)
                        {
                            posYY += 20;
                        }
                        spriteBatch.Draw(shop, new Vector2(Window.ClientBounds.Width / 2 - shop.Width / 2, posYY), Color.White);

                    }

                    if (entered == true && map_Load == true)
                    {
                        spriteBatch.Draw(loadButton, new Vector2(Window.ClientBounds.Width / 2 - loadButton.Width / 2, Window.ClientBounds.Height / 2 - loadButton.Height / 2 + 30), Color.White);
                        spriteBatch.Draw(input, new Vector2(Window.ClientBounds.Width / 2 - input.Width / 2, Window.ClientBounds.Height / 2 - input.Height / 2), Color.White);
                        spriteBatch.DrawString(mapFont, "Enter the name from the list of the map you want to load", new Vector2(Window.ClientBounds.Width / 2 - input.Width / 2, 360), Color.White);
                        spriteBatch.DrawString(mapFont, textString, new Vector2(Window.ClientBounds.Width / 2 - input.Width / 2 + 3, Window.ClientBounds.Height / 2 - input.Height / 2 + 2), Color.Red);
                    }
                    else
                    {
                        textString = "";
                    }
                    if (map_Load == true)
                    {
                        loadMenu();
                        //   map_Load = false;

                    }


                }
                if (currentView == 7)
                {
                    spriteBatch.Draw(gameBack, new Vector2(0, 0), Color.White);
                    if (map_Load == true)
                    {
                        loadMenu();
                    }

                }
                if (currentView == 3)
                {

                }
                if (currentView == 4 || currentView == 5 || currentView == 6
                    || currentView == 9 || currentView == 10 || currentView == 11 || currentView == 12)
                {
                    spriteBatch.Draw(gameBack, new Vector2(0, 0), Color.White);
                }

                for (int h = 0; h < 31; h++)
                {
                    action = myButton[h].inputButton(new Vector2(Mouse.GetState().X, Mouse.GetState().Y), myButtonPictures, mouseClick);
                    myButton[h].myDraw(spriteBatch, myButtonPictures, currentView);

                }

                if (currentView == 13)
                {
                    start1.Stop();
                    backmusicInstace.Pause();
                    menuInstance.Play();
                    mapDraw();

                    if (error_Active == true)
                    {
                        spriteBatch.DrawString(mapFont, "No name entered", new Vector2(Window.ClientBounds.Width / 2 - input.Width / 2, 450), Color.Red);
                    }


                }
                if (currentView == 6)
                {
                    start1.Stop();
                    backmusicInstace.Pause();
                    menuInstance.Play();

                    spriteBatch.DrawString(ipFont, textString, new Vector2(Window.ClientBounds.Width / 2 - input.Width / 2 + 3,
                        Window.ClientBounds.Height / 2 - input.Height / 2 + 20), Color.Red);
                    //spriteBatch.DrawString(mapFont, textString, 
                    //    new Vector2(Window.ClientBounds.Width / 2 - input.Width / 2 + 3, 
                    //        Window.ClientBounds.Height / 2 - input.Height / 2 + 20), Color.Red);



                }
                if (currentView == 8)
                {
                    start1.Stop();
                    backmusicInstace.Play();
                    menuInstance.Pause();

                    posXX2 = 1000;
                    posXX = -1000;
                    mainGame();
                }

            }
            pastkey = Keyboard.GetState();
            spriteBatch.End();
            base.Draw(gameTime);
        }

        protected void loadMapForMainGame(string mapName)
        {
            try
            {
                if (units.Count > 0)
                {
                    for (int x = 0; x < units.Count; x++)
                    {
                        units.RemoveAt(x);
                    }
                }
                string gameMap = mapName;
                System.IO.StreamReader file = new System.IO.StreamReader(@"" + gameMap + ".txt");
                String lines = null;
                int count = 0;
                while ((lines = file.ReadLine()) != null)
                {
                    string[] tp = lines.Split(',');
                    int count2 = 0;
                    foreach (string w in tp)
                    {
                        if (count2 < 60 && count < 60)
                            myTiles[count, count2++].type = Convert.ToInt32(w);
                    }
                    count++;
                }
                file.Close();
                System.IO.StreamReader fileUnits = new System.IO.StreamReader(@"" + mapName + "units.txt");
                String lines2 = null;
                map_Load = false;
                entered = false;
                error_Active = false;
                while ((lines2 = fileUnits.ReadLine()) != null)
                {
                    string[] words = lines2.Split(',');
                    units.Add(new Units(new Vector2((float)Convert.ToDouble(words[1]), (float)Convert.ToDouble(words[2])),
                        new Point(Convert.ToInt32(words[6]), Convert.ToInt32(words[7])), Convert.ToInt32(words[4]), 10, Convert.ToInt32(words[5]), Convert.ToInt32(words[8])
                        , myTiles, Convert.ToInt32(words[3]), Convert.ToInt32(words[9])));
                    if (Convert.ToInt32(words[4]) == 1)
                    {
                        me++;
                    }
                    else
                    {
                        enemy++;
                    }
                }


                fileUnits.Close();


            }
            catch (Exception e)
            {

            }

        }
       
        protected void mainGame()
        {
            spriteBatch.Draw(back2, new Vector2(0, 0), Color.White);
            menu8();
            for (int x = 0; x < row; x++)
            {
                for (int y = 0; y < col; y++)
                {
                    myTiles[x, y].drawTile(graphics, spriteBatch, tiles, camX, camY);
                    for (int z = 0; z < units.Count; z++)
                    {
                        if (units[z].typeOfUnit == tank)
                        {

                            if (units[z].position == myTiles[x, y].position || units[z].Position == new Point(x, y))
                            {
                                myTiles[x, y].Blocked = true;
                                myTiles[x, y].thereIsUnit = true;

                            }
                            else
                            {
                                myTiles[x, y].Blocked = false;
                                myTiles[x, y].thereIsUnit = false;
                            }
                        }
                    }

                    if (myBullets.Count > 0)
                    {
                        for (bulletsCounter = 0; bulletsCounter < myBullets.Count; bulletsCounter++)
                        {


                            if ((myBullets[bulletsCounter].bulletRect.Intersects(myTiles[x, y].Position)
                                && myTiles[x, y].type == 4 && myBullets[bulletsCounter].status == 1)
                                || myBullets[bulletsCounter].bullDistaceFrom > 500)
                            {
                                myBullets[bulletsCounter].status = 0;
                            }
                        }
                    }
                }
            }
            Bullets();
            try
            {
                for (bulletsCounter = 0; bulletsCounter < myBullets.Count; bulletsCounter++)
                {
                    if (myBullets[bulletsCounter].status == 1)
                    {

                        myBullets[bulletsCounter].drawBullet(graphics, spriteBatch, unitsPics, camX, camY);
                        for (int b = 0; b < units.Count; b++)
                        {


                            if ((myBullets[bulletsCounter].bulletRect.Intersects(units[b].unitRect) && units[b].side != myBullets[bulletsCounter].side
                                   && units[b].life > 0) || Keyboard.GetState().IsKeyDown(Keys.K))
                            {
                                units[b].life--;
                                myBullets[bulletsCounter].status = 0;

                            }
                            myBullets[bulletsCounter].bullDistaceFrom = Vector2.Distance(new Vector2(units[b].position.X - camX
                            + graphics.PreferredBackBufferWidth / 2 + unitsPics[units[b].imageUsed].Width / 2 - 20,
                            units[b].position.Y - camY + graphics.PreferredBackBufferHeight / 2 + unitsPics[units[b].imageUsed].Height / 2 - 20),
                             new Vector2(myBullets[bulletsCounter].position.X - camX + graphics.PreferredBackBufferWidth / 2 + unitsPics[units[b].imageUsed].Width / 2 - 20,
                             myBullets[bulletsCounter].position.Y - camY + graphics.PreferredBackBufferHeight / 2 + unitsPics[units[b].imageUsed].Height / 2 - 20));


                        }
                    }
                    else if (myBullets[bulletsCounter].status == 0)
                    {
                        myBullets.RemoveAt(bulletsCounter);
                    }
                }
            }
            catch (Exception)
            {

            }
            //==========================================================================================================================================================================
            try
            {
                for (int x = 0; x < units.Count; x++)
                {
                    units[x].isSelected(camX, camY, unitsPics, graphics);
                    units[x].DrawUnit(spriteBatch, graphics, unitsPics, camX, camY, mapFont, network, x);
                    units[x].newAngle = units[x].calcAngle(units[x].position.X - camX +
                        graphics.PreferredBackBufferWidth / 2 + unitsPics[units[x].imageUsed].Width / 2 - 20,
                            units[x].position.Y - camY + graphics.PreferredBackBufferHeight / 2
                            + unitsPics[units[x].imageUsed].Height / 2 - 20,
                            units[x].destination.X, units[x].destination.Y);
                    if (units[x].life < 0)
                    {
                        units[x].life = -1;
                        
                    }
                   
                    for (int y = 0; y < units.Count; y++)
                    {

                        distance = Vector2.Distance(new Vector2(units[x].position.X - camX
                            + graphics.PreferredBackBufferWidth / 2 + unitsPics[units[x].imageUsed].Width / 2 - 20,
                            units[x].position.Y - camY + graphics.PreferredBackBufferHeight / 2 + unitsPics[units[x].imageUsed].Height / 2 - 20),
                            new Vector2(units[y].position.X - camX + graphics.PreferredBackBufferWidth / 2 + unitsPics[units[x].imageUsed].Width / 2 - 20,
                            units[y].position.Y - camY + graphics.PreferredBackBufferHeight / 2 + unitsPics[units[x].imageUsed].Height / 2 - 20));

                        if (distance <= 200 && units[y].side != units[x].side && units[y].life > 0 && units[x].life > 0)
                        {

                            {
                                units[x].attack = true;
                                units[y].attack = true;
                                units[y].findpath = true;
                                units[x].findpath = true;

                            }

                        }

                        else
                        {
                            units[x].attack = false;
                            units[y].attack = false;
                            units[y].findpath = false;
                            units[x].findpath = false;
                        }
                        if (units[x].attack == true)
                        {
                            myBullets.Add(new Bullets(5, units[x].position
                            , (float)units[x].angle, units[x].side, 1, bullet, x));
                            bulletInstance.Play();
                        }
                        if (units[x].findpath == true && units[x].pathFound)
                        {
                            BuildMap(units[x].typeOfUnit);
                            Pathfinder pF = new Pathfinder();
                            pF.FindPath(units[x].Position, units[y].Position, graphics, tiles, camX, camY, spriteBatch, myTiles, units[x].path);

                        }
                        if (units[y].findpath == true && units[x].pathFound)
                        {
                            BuildMap(units[y].typeOfUnit);
                            Pathfinder pF = new Pathfinder();
                            pF.FindPath(units[y].Position, units[x].Position, graphics, tiles, camX, camY, spriteBatch, myTiles, units[y].path);
                        }
                    }
                    //***********************************************************************************************************************************
                    if (units[x].life == 0 || Keyboard.GetState().IsKeyDown(Keys.X))
                    {
                        if (frames < numFrames)
                        {
                            spriteBatch.Draw(explode[frames], new Vector2(units[x].position.X - camX +
                                graphics.PreferredBackBufferWidth / 2 + unitsPics[units[x].imageUsed].Width / 2 - 60
                            , units[x].position.Y - camY + graphics.PreferredBackBufferHeight / 2 +
                            unitsPics[units[x].imageUsed].Width / 2 - 60), Color.White);

                            frames++;
                            explotionsIn.Play();

                        }
                        else
                        {
                            if (units[x].side == 1)
                            {
                                me--;
                            }
                            else if (units[x].side == 2)
                            {
                                enemy--;
                            }
                            units.RemoveAt(x);
                            frames = 0;
                        }
                    }
                    //**********************************************************************************************************************************
                    if (units[x].mouse_over == 1 && units[x].life > 0)
                    {
                        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        {
                            selectedUnit = x;
                            for (int y = 0; y < units.Count; y++)
                            {
                                units[y].selected = false;

                            }
                            units[selectedUnit].selected = true;
                            if (network.connected == true)
                            {

                                network.sendData("&s", selectedUnit, units[selectedUnit].position, "select", false);
                            }
                        }
                    }

                    if (units[x].selected == true && units[x].life > 0)
                    {
                        drawRectangle((int)(units[selectedUnit].position.X - camX + graphics.PreferredBackBufferWidth / 2 - 25),
                        (int)(units[selectedUnit].position.Y - camY + graphics.PreferredBackBufferHeight / 2 - 25), 50, 50, graphics,
                         spriteBatch, Color.Silver);

                    }
                }
            }
            catch (Exception)
            {

            }

            //=====================================================================================================================================
            shooping();

            try
            {
                if (findPath)
                {
                    if (units[selectedUnit].path.Count > 0)
                    {
                        for (int v = 0; v < units[selectedUnit].path.Count; v++)
                        {
                            units[selectedUnit].path.RemoveAt(v);
                        }
                    }
                    BuildMap(units[selectedUnit].typeOfUnit);
                    startPos = units[selectedUnit].Position;
                    Pathfinder pF = new Pathfinder();
                    pF.FindPath(startPos, end, graphics, tiles, camX, camY, spriteBatch, myTiles, units[selectedUnit].path);
                    findPath = false;

                }
            }
            catch (Exception)
            {

            }

            if (showNet == true)
            {
                spriteBatch.Draw(networkMenu, new Vector2(216, 25), Color.White);
                if (showNetConnect == true)
                {

                    spriteBatch.Draw(messageBox, new Vector2(392, 25), Color.White);
                    spriteBatch.Draw(networkMenu, new Vector2(392, 50), Color.White);
                    for (int h = 2; h < 4; h++)
                    {
                        UpdateInput();
                        action = netButtons[h].inputButton(new Vector2(Mouse.GetState().X, Mouse.GetState().Y), netBtPics, mouseClick);
                        netButtons[h].myDraw(spriteBatch, netBtPics, currentView);
                        spriteBatch.DrawString(ipFont, textString, new Vector2(452, 32), Color.Red);

                    }
                    //netButtons[2].myDraw(spriteBatch, netBtPics, currentView);
                }
                for (int h = 0; h < 2; h++)
                {
                    action = netButtons[h].inputButton(new Vector2(Mouse.GetState().X, Mouse.GetState().Y), netBtPics, mouseClick);
                    netButtons[h].myDraw(spriteBatch, netBtPics, currentView);

                }
            }
            if (me == 0)
            {
                spriteBatch.Draw(GameOver, new Vector2(graphics.PreferredBackBufferWidth / 2 - GameOver.Width / 2,
                    graphics.PreferredBackBufferHeight / 2 - GameOver.Height / 2), Color.White);
            }
            if (enemy == 0)
            {
                spriteBatch.Draw(win, new Vector2(graphics.PreferredBackBufferWidth / 2 - GameOver.Width / 2,
                    graphics.PreferredBackBufferHeight / 2 - GameOver.Height / 2), Color.White);
            }

            SelectStartAndEnd();
            netWorkMenu();

            spriteBatch.Draw(minimap, new Vector2(0, 640), Color.White);
            DrawMinimap();
            spriteBatch.Draw(InterFace, new Vector2(0, 0), Color.White);
            try
            {
                spriteBatch.Draw(BigUnits[units[selectedUnit].imageUsed], new Vector2(295, 660), Color.White);
                if (units[selectedUnit].life > 1)
                {
                    spriteBatch.Draw(life[units[selectedUnit].life - 1], new Vector2(390, 685), Color.White);
                }
                else
                {
                    spriteBatch.Draw(life[0], new Vector2(390, 685), Color.White);
                }
                spriteBatch.DrawString(ipFont, units[selectedUnit].life.ToString(), new Vector2(410, 675), Color.Red);
                if (units[selectedUnit].side == 1)
                {
                    spriteBatch.Draw(side[0], new Vector2(460, 670), Color.White);
                }
                else
                {
                    spriteBatch.Draw(side[1], new Vector2(455, 670), Color.White);
                }
            }
            catch (Exception)
            {

            }
            spriteBatch.DrawString(ipFont, network.message, new Vector2(260, 585), Color.Red);
            if (network.connected == true)
            {
                //network.receiveMassage(units);

                network.receiveMassage(units);

                //findPath = true;
                spriteBatch.Draw(connected, new Vector2(214, 2), Color.White);
                spriteBatch.Draw(messageBox2, new Vector2(250, 573), Color.White);

                if (network.message != "")
                {
                    spriteBatch.DrawString(ipFont, network.message, new Vector2(260, 585), Color.Red);
                }
                if (chat == true)
                {
                    spriteBatch.Draw(input2, new Vector2(320, 25), Color.White);
                    spriteBatch.Draw(netBtPics[5], new Vector2(320, 53), Color.White);
                    spriteBatch.Draw(netBtPics[6], new Vector2(435, 53), Color.White);
                    spriteBatch.DrawString(ipFont, textString, new Vector2(325, 40), Color.Red);
                }
            }
            if (Mouse.GetState().X >= 940 && Mouse.GetState().X <= 980
             && Mouse.GetState().Y >= 640 && Mouse.GetState().Y <= 674
            )
            {
                spriteBatch.Draw(whiteCircle, new Vector2(940, 640), Color.White);
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    if (showShop == false)
                    {
                        showShop = true;
                    }
                    else
                    {
                        showShop = false;
                    }

                }

                // MediaPlayer.Pause();
            }
            if (moveUnit == true)
            {
                spriteBatch.Draw(whiteCircle, new Vector2(784, 645), Color.White);
            }
            spriteBatch.DrawString(ipFont, ("Mouse PosX:" + Mouse.GetState().X.ToString()
               + " PosY: " + Mouse.GetState().Y.ToString()), new Vector2(820, 5), Color.Red);
            try
            {

                spriteBatch.DrawString(ipFont, units[selectedUnit].Position.X.ToString(), new Vector2(514, 770), Color.Red);
                spriteBatch.DrawString(ipFont, units[selectedUnit].Position.Y.ToString(), new Vector2(540, 770), Color.Red);
            }
            catch (Exception)
            {

            }
            pastMouse = Mouse.GetState();
        }

        public void Bullets()
        {
            try
            {
                if (Keyboard.GetState().IsKeyDown(Keys.K))
                {
                    units[selectedUnit].life--;
                }
                if (units.Count > 0)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.S))
                    {
                        units[selectedUnit].attack = true;
                        myBullets.Add(new Bullets(5, units[selectedUnit].position
                           , (float)units[selectedUnit].angle, units[selectedUnit].side, 1, bullet, selectedUnit));
                        bulletInstance.Play();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public void shooping()
        {
            try
            {
                if (showShop == true)
                {
                    if (posY >= 305)
                    {
                        posY -= 5;

                    }
                    spriteBatch.Draw(shop, new Vector2(posX, posY), Color.White);
                }
                if (showShop == false)
                {
                    if (posY <= 600)
                    {
                        posY += 5;

                    }
                    spriteBatch.Draw(shop, new Vector2(posX, posY), Color.White);
                }
            }
            catch (Exception)
            {

            }
        }

        protected void netWorkMenu()
        {
            for (int h = 0; h < numNetButtons; h++)
            {
                netAction = netButtons[h].inputButton(new Vector2(Mouse.GetState().X, Mouse.GetState().Y), netBtPics, mouseClick);


                switch (netAction)
                {
                    case 1:
                        if (currentView == 8 && showNet == true)
                        {
                            showNetConnect = true;
                            ipAddress = "127.0.0.1";
                            textString = ipAddress;
                            entered = true;
                            // MediaPlayer.Play(mySound);
                        }
                        break;
                    case 2:
                        if (currentView == 8 && showNet == true)
                        {
                            network.disconect();
                            currentView = 8;
                            showNet = false;
                            // MediaPlayer.Play(mySound);
                        }
                        break;
                    case 3:
                        if (currentView == 8 && showNet == true)
                        {
                            if (network.connected == false)
                            {
                                network.Initialise(textString);
                                textString = "";
                            }
                            showNet = false;
                            currentView = 8;
                            showNetConnect = false;
                            entered = false;
                            // MediaPlayer.Play(mySound);
                        }
                        break;
                    case 4:
                        if (currentView == 8 && showNet == true)
                        {

                            showNet = false;
                            currentView = 8;
                            showNetConnect = false;
                            entered = false;
                            textString = "";
                            // MediaPlayer.Play(mySound);
                        }
                        break;
                }
            }
        }

        protected void menuS()
        {
            for (int h = 0; h < 31; h++)
            {
                action = myButton[h].inputButton(new Vector2(Mouse.GetState().X, Mouse.GetState().Y), myButtonPictures, mouseClick);


                switch (action)
                {
                    case 1:
                        if (currentView == 1)
                        {
                            currentView = 14;
                            mouseClick[7].Play();
                        }

                        break;
                    case 2:
                        if (currentView == 1)
                        {
                            currentView = 2;
                            mouseClick[7].Play();
                        }
                        break;
                    case 3:
                        if (currentView == 1)
                        {
                            currentView = 5;
                            mouseClick[7].Play();
                        }
                        break;
                    case 4:
                        if (currentView == 1)
                        {
                            UnloadContent();
                            this.Exit();
                        }
                        break;
                    case 5:
                        if (currentView == 2)
                        {
                            currentView = 3;
                            mouseClick[7].Play();
                        }
                        break;
                    case 6:
                        if (currentView == 2)
                        {
                            currentView = 4;
                            mouseClick[7].Play();
                        }
                        break;
                    case 7:
                        if (currentView == 2)
                        {
                            currentView = 1;
                            mouseClick[7].Play();
                        }
                        break;

                    //......................
                    case 8:
                        if (currentView == 3)
                        {
                            currentView = 11;
                            mouseClick[7].Play();
                        }
                        break;
                    case 9:
                        if (currentView == 3)
                        {
                            currentView = 12;
                            mouseClick[7].Play();
                        }
                        break;
                    //.......................
                    case 10:
                        if (currentView == 3)
                        {
                            currentView = 2;
                            mouseClick[7].Play();

                        }
                        break;

                    case 12:
                        if (currentView == 4)
                        {
                            currentView = 2;
                            mouseClick[7].Play();
                        }
                        break;
                    case 14:
                        if (currentView == 5)
                        {
                            currentView = 6;
                            textString = "";
                            mouseClick[7].Play();
                        }

                        break;
                    case 13:
                        if (currentView == 5)
                        {
                            //put save code here
                            //string fileName = textString + ".txt";
                            System.IO.StreamReader myFile = new System.IO.StreamReader(@"" + map_GameNames);

                            lineForGameNames = myFile.ReadLine();

                            myFile.Close();
                            loadAct = true;
                            map_Load = true;
                            currentView = 7;

                            mouseClick[7].Play();
                        }
                        break;
                    case 15:
                        if (currentView == 5)
                        {
                            currentView = 1;
                            mouseClick[7].Play();
                        }
                        break;
                    case 18:
                        if (currentView == 6)
                        {
                            currentView = 5;
                            mouseClick[7].Play();
                        }
                        break;

                    case 16:
                        if (currentView == 4)
                        {
                            windowWidth = 800;
                            windowHeight = 400;
                            SetWindowSize(windowWidth, windowHeight);
                            mouseClick[7].Play();
                        }
                        break;
                    case 17:
                        if (currentView == 4)
                        {
                            windowWidth = 1000;
                            windowHeight = 800;
                            SetWindowSize(windowWidth, windowHeight);
                            mouseClick[2].Play();
                        }
                        break;

                    case 19:
                        if (currentView == 6)
                        {
                            //put save code here
                            save = true;
                            textString = "";
                            entered = true;
                            mouseClick[1].Play();
                        }
                        break;
                    case 20:
                        if (currentView == 6)
                        {

                            try
                            {


                                System.IO.StreamWriter saveGameName = new System.IO.StreamWriter(@"" + GameNames + ".txt", true);
                                saveGameName.Write(textString + ",");
                                saveGameName.Close();

                                System.IO.StreamWriter Saved = new System.IO.StreamWriter(@"" + textString + ".txt");
                                for (int x = 0; x < col; x++)
                                {
                                    for (int y = 0; y < row; y++)
                                    {

                                        Saved.Write(myTiles[x, y].type + ",");

                                    }
                                    Saved.Write("\n");
                                }
                                Saved.Close();

                                System.IO.StreamWriter SavedU = new System.IO.StreamWriter(@"" + textString + "units.txt", false);
                                for (int y = 0; y < mapUnits.Count; y++)
                                {
                                    SavedU.WriteLine(y + "," + units[y].position.X + "," + units[y].position.Y + "," + units[y].type
                                    + "," + units[y].side + "," + units[y].life + "," + units[y].Position.X + "," + units[y].Position.Y + "," + units[y].imageUsed + "," + units[y].type);
                                }
                                SavedU.Close();

                                textString = "";
                                save = false;
                                entered = false;
                            }
                            catch (Exception e)
                            {

                            }



                        }

                        break;
                    case 21:
                        if (currentView == 7)
                        {
                            currentView = 5;
                            mouseClick[1].Play();

                        }
                        break;
                    case 22:
                        if (currentView == 7)
                        {
                            try
                            {

                                System.IO.StreamReader file = new System.IO.StreamReader(@"" + map_GameNames);
                                String myline = null;
                                file.Close();
                                System.IO.StreamWriter saveGameName = new System.IO.StreamWriter(@"" + map_GameNames, true);
                                saveGameName.Write(Map_GameName + ",");
                                saveGameName.Close();
                                myline = "";

                                System.IO.StreamWriter Saved = new System.IO.StreamWriter(@"" + Map_GameName + ".txt");
                                for (int x = 0; x < col; x++)
                                {
                                    for (int y = 0; y < row; y++)
                                    {

                                        Saved.Write(myTiles[x, y].type + ",");

                                    }
                                    Saved.Write("\n");
                                }
                                Saved.Close();
                                System.IO.StreamWriter SavedU = new System.IO.StreamWriter(@"" + Map_GameName + "units.txt", false);
                                for (int y = 0; y < mapUnits.Count; y++)
                                {
                                    SavedU.WriteLine(y + "," + mapUnits[y].position.X + "," + mapUnits[y].position.Y + "," + mapUnits[y].type
                                    + "," + mapUnits[y].side + "," + mapUnits[y].life + "," + mapUnits[y].Position.X + "," + mapUnits[y].Position.Y + "," + mapUnits[y].imageUsed + "," + unitType);
                                }
                                SavedU.Close();

                                Map_GameName = "";
                                map_Save = false;
                                entered = false;
                            }
                            catch (Exception e)
                            {

                            }

                        }
                        break;
                    case 23:
                        if (currentView == 10)
                        {
                            currentView = 8;
                            mouseClick[7].Play();
                        }
                        break;
                    case 24:
                        if (currentView == 10)
                        {
                            currentView = 6;
                            mouseClick[7].Play();
                        }
                        break;
                    case 26:
                        if (currentView == 11)
                        {
                            currentView = 3;
                            mouseClick[7].Play();
                        }
                        break;
                    case 25:
                        if (currentView == 11)
                        {


                            if (control2.Volume <= 0.1f)
                            {
                                control2.Volume = 0f;

                                mouseClick[7].Play();
                            }
                            else
                            {
                                volume -= 0f;
                                control2.Volume -= 0.001f;
                            }
                        }
                        break;
                    case 27:
                        if (currentView == 11)
                        {



                            if (control2.Volume >= 0.09f)
                            {
                                control2.Volume = 1f;

                            }
                            else
                            {
                                control2.Volume += 0.001f;
                            }

                        }
                        break;
                    case 28:
                        if (currentView == 12)
                        {
                            currentView = 11;

                        }
                        break;
                    case 29:
                        {
                            if (currentView == 14)
                            {
                                if (units.Count > 0)
                                {
                                    for (int x = 0; x < units.Count; x++)
                                    {
                                        units.RemoveAt(0);
                                    }
                                }
                                loadMapForMainGame("MAP");
                                currentView = 8;
                                entered = false;
                            }

                        }
                        break;
                    case 30:
                        if (currentView == 1)
                        {
                            currentView = 13;
                            camX = 0;
                            camY = 0;
                            for (int x = 0; x < col; x++)
                            {
                                for (int y = 0; y < row; y++)
                                {
                                    myTiles[x, y].type = 0;
                                }
                            }
                        }
                        break;
                    case 31:
                        if (currentView == 14)
                        {
                            System.IO.StreamReader file1 = new System.IO.StreamReader(@"" + map_GameNames);
                            lineForGameNames = file1.ReadLine();
                            file1.Close();
                            map_Save = false;
                            showGameNames = true;
                            map_Load = true;
                            currentView = 15;


                        }
                        break;
                }

            }
        }

        public void SelectStartAndEnd()
        {

            for (int x = 0; x < col; x++)
            {
                for (int y = 0; y < row; y++)
                {

                    if ((Mouse.GetState().X > myTiles[x, y].position.X - camX + graphics.PreferredBackBufferWidth / 2 - tiles[myTiles[x, y].type].Width / 2
                        && Mouse.GetState().X < myTiles[x, y].position.X - camX + graphics.PreferredBackBufferWidth / 2 - tiles[myTiles[x, y].type].Width / 2 + 50
                        && Mouse.GetState().Y > myTiles[x, y].position.Y - camY + graphics.PreferredBackBufferHeight / 2 - tiles[myTiles[x, y].type].Height / 2
                        && Mouse.GetState().Y < myTiles[x, y].position.Y - camY + graphics.PreferredBackBufferHeight / 2 - tiles[myTiles[x, y].type].Height / 2
                        + 50 && currentView == 8 && myTiles[x, y].Blocked == false))
                    {


                        if (Mouse.GetState().LeftButton == ButtonState.Pressed && pastMouse.LeftButton == ButtonState.Released)
                        {
                            if (Mouse.GetState().X > 0 && Mouse.GetState().X < graphics.PreferredBackBufferWidth &&
                                Mouse.GetState().Y > 20 && Mouse.GetState().Y < 590 && myTiles[x, y].thereIsUnit == false && moveUnit)
                            {
                                end = new Point(x, y);
                                findPath = true;
                                drawRectangle((int)myTiles[x, y].position.X - camX + graphics.PreferredBackBufferWidth / 2
                                    - tiles[myTiles[x, y].type].Width / 2
                                , (int)myTiles[x, y].position.Y - camY + graphics.PreferredBackBufferHeight / 2 -
                                tiles[myTiles[x, y].type].Height / 2, 50, 50, graphics, spriteBatch, Color.Yellow);
                            }
                        }

                    }
                }
            }



        }

        public void SetWindowSize(int x, int y)
        {
            graphics.PreferredBackBufferWidth = x;
            graphics.PreferredBackBufferHeight = y;
            graphics.ApplyChanges();
        }

        protected void BuildMap(int unitType)
        {
            try
            {
                if (units.Count > 0)
                {
                    if (units[unitType].typeOfUnit == tank)
                    {
                        for (int a = 0; a < 60; a++)
                        {
                            for (int b = 0; b < 60; b++)
                            {
                                if (myTiles[a, b].type == 2 || myTiles[a, b].type == 4 || myTiles[a, b].type == 0)
                                {
                                    // myTiles[a, b].Blocked = true;
                                    myTiles[a, b].Blocked = true;
                                }
                                else
                                {
                                    myTiles[a, b].Blocked = false;
                                }
                            }
                        }
                    }

                    if (units[unitType].typeOfUnit == ship)
                    {
                        for (int a = 0; a < 60; a++)
                        {
                            for (int b = 0; b < 60; b++)
                            {
                                if (myTiles[a, b].type != 2)
                                {
                                    // myTiles[a, b].Blocked = true;
                                    myTiles[a, b].Blocked = true;
                                }
                                else
                                {
                                    myTiles[a, b].Blocked = false;
                                }
                            }
                        }
                    }
                    if (units[unitType].typeOfUnit == car)
                    {
                        for (int a = 0; a < 60; a++)
                        {
                            for (int b = 0; b < 60; b++)
                            {
                                if (myTiles[a, b].type == 2)
                                {
                                    // myTiles[a, b].Blocked = true;
                                    myTiles[a, b].Blocked = true;
                                }
                                else
                                {
                                    myTiles[a, b].Blocked = false;
                                }
                            }
                        }
                    }

                    if (units[unitType].typeOfUnit == plane)
                    {
                        for (int a = 0; a < 60; a++)
                        {
                            for (int b = 0; b < 60; b++)
                            {
                                if (units[selectedUnit].map[a, b].type == 0 || units[selectedUnit].map[a, b].type == 1 || units[selectedUnit].map[a, b].type == 2
                                        || units[selectedUnit].map[a, b].type == 3 || units[selectedUnit].map[a, b].type == 4)
                                {
                                    // myTiles[a, b].Blocked = true;
                                    myTiles[a, b].Blocked = true;
                                }
                                else
                                {
                                    myTiles[a, b].Blocked = false;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        protected void changeTile()
        {
            for (int x = 0; x < col; x++)
            {
                for (int y = 0; y < row; y++)
                {
                    //myTiles[x, y] = new MapTiles(0, new Vector2(xpos - camX + graphics.PreferredBackBufferWidth / 2, ypos - camY + graphics.PreferredBackBufferHeight / 2));


                    if (Mouse.GetState().X > myTiles[x, y].position.X - camX + graphics.PreferredBackBufferWidth / 2 - tiles[myTiles[x, y].type].Width / 2
                        && Mouse.GetState().X < myTiles[x, y].position.X - camX + graphics.PreferredBackBufferWidth / 2 - tiles[myTiles[x, y].type].Width / 2 + 50
                        && Mouse.GetState().Y > myTiles[x, y].position.Y - camY + graphics.PreferredBackBufferHeight / 2 - tiles[myTiles[x, y].type].Height / 2
                        && Mouse.GetState().Y < myTiles[x, y].position.Y - camY + graphics.PreferredBackBufferHeight / 2 - tiles[myTiles[x, y].type].Height / 2
                        + 50 && currentView == 13
                        && Mouse.GetState().X >= 0 && Mouse.GetState().X <= 1000 && Mouse.GetState().Y >= 0 && Mouse.GetState().Y <= 620)
                    {
                        if (plotTiles)
                        {
                            drawRectangle((int)myTiles[x, y].position.X - camX + graphics.PreferredBackBufferWidth / 2 - tiles[myTiles[x, y].type].Width / 2
                                , (int)myTiles[x, y].position.Y - camY + graphics.PreferredBackBufferHeight / 2 - tiles[myTiles[x, y].type].Height / 2,
                                tiles[myTiles[x, y].type].Width, tiles[myTiles[x, y].type].Height,
                                graphics, spriteBatch, Color.Red);
                        }
                        if (Mouse.GetState().LeftButton == ButtonState.Pressed && plotTiles == true && myTiles[x, y].Blocked == false)
                        {

                            myTiles[x, y].type = type;
                        }
                    }

                    //units
                    if (Mouse.GetState().X > myTiles[x, y].position.X - camX + graphics.PreferredBackBufferWidth / 2 - tiles[myTiles[x, y].type].Width / 2
                        && Mouse.GetState().X < myTiles[x, y].position.X - camX + graphics.PreferredBackBufferWidth / 2 - tiles[myTiles[x, y].type].Width / 2 + 50
                        && Mouse.GetState().Y > myTiles[x, y].position.Y - camY + graphics.PreferredBackBufferHeight / 2 - tiles[myTiles[x, y].type].Height / 2
                        && Mouse.GetState().Y < myTiles[x, y].position.Y - camY + graphics.PreferredBackBufferHeight / 2 - tiles[myTiles[x, y].type].Height / 2 + 50 && currentView == 13
                        && Mouse.GetState().X >= 0 && Mouse.GetState().X <= 1000 && Mouse.GetState().Y >= 0 && Mouse.GetState().Y <= 620
                       )
                    {
                        if (plotUnits)
                        {
                            drawRectangle((int)myTiles[x, y].position.X - camX + graphics.PreferredBackBufferWidth / 2 - tiles[myTiles[x, y].type].Width / 2
                                , (int)myTiles[x, y].position.Y - camY + graphics.PreferredBackBufferHeight / 2 - tiles[myTiles[x, y].type].Height / 2, tiles[myTiles[x, y].type].Width, tiles[myTiles[x, y].type].Height,
                                graphics, spriteBatch, Color.Red);
                        }
                        if (Mouse.GetState().LeftButton == ButtonState.Pressed && plotUnits == true && myTiles[x, y].Blocked == false)
                        {
                            // BuildMap();
                            if (unitType == tank && myTiles[x, y].type == 3)
                            {
                                mapUnits.Add(new Units(new Vector2((int)myTiles[x, y].position.X
                                    , (int)myTiles[x, y].position.Y)
                                    , new Point(x, y), Unitside, 1, 10, unitPic, myTiles, unitType, tank));
                                myTiles[x, y].Blocked = true;
                            }
                            if (unitType == car && myTiles[x, y].type == 3)
                            {
                                mapUnits.Add(new Units(new Vector2((int)myTiles[x, y].position.X
                                    , (int)myTiles[x, y].position.Y)
                                    , new Point(x, y), Unitside, 1, 10, unitPic, myTiles, unitType, car));
                                myTiles[x, y].Blocked = true;
                            }
                            if (unitType == plane && myTiles[x, y].type != 2)
                            {
                                mapUnits.Add(new Units(new Vector2((int)myTiles[x, y].position.X
                                    , (int)myTiles[x, y].position.Y)
                                    , new Point(x, y), Unitside, 1, 10, unitPic, myTiles, unitType, plane));
                                myTiles[x, y].Blocked = true;
                            }
                            if (unitType == 4)
                            {
                                mapUnits.Add(new Units(new Vector2((int)myTiles[x, y].position.X
                                    , (int)myTiles[x, y].position.Y)
                                    , new Point(x, y), Unitside, 1, 10, unitPic, myTiles, unitType, 4));
                                myTiles[x, y].Blocked = true;
                            }
                        }
                    }

                    for (int z = 0; z < mapUnits.Count; z++)
                    {
                        if (mapUnits[z].Position == new Point(x, y))
                        {
                            myTiles[x, y].Blocked = true;
                            mapUnits[z].parentTile = new Point(x, y);
                        }
                    }

                }


            }

        }

        protected void saveAndload()
        {


            if (Mouse.GetState().X > sPosX && Mouse.GetState().X < sPosX + saveButton.Width &&
                Mouse.GetState().Y > sPosY && Mouse.GetState().Y < sPosY + saveButton.Height
                && Mouse.GetState().LeftButton == ButtonState.Pressed && map_Save == true)
            {
                try
                {
                    System.IO.StreamReader file = new System.IO.StreamReader(@"" + map_GameNames);
                    String myline = null;
                    // myline = file.Reali
                    file.Close();
                    System.IO.StreamWriter saveGameName = new System.IO.StreamWriter(@"" + map_GameNames, true);
                    saveGameName.Write(Map_GameName + ",");
                    saveGameName.Close();
                    myline = "";

                    System.IO.StreamWriter Saved = new System.IO.StreamWriter(@"" + Map_GameName + ".txt");
                    for (int x = 0; x < col; x++)
                    {
                        for (int y = 0; y < row; y++)
                        {
                            Saved.Write(myTiles[x, y].type + ",");
                        }
                        Saved.Write("\n");
                    }
                    Saved.Close();
                    System.IO.StreamWriter SavedU = new System.IO.StreamWriter(@"" + Map_GameName + "units.txt", false);
                    for (int y = 0; y < mapUnits.Count; y++)
                    {
                        SavedU.WriteLine(y + "," + mapUnits[y].position.X + "," + mapUnits[y].position.Y + "," + mapUnits[y].type
                            + "," + mapUnits[y].side + "," + mapUnits[y].life + "," + mapUnits[y].Position.X + "," + mapUnits[y].Position.Y + "," + mapUnits[y].imageUsed + "," + unitType);
                    }
                    SavedU.Close();
                    Map_GameName = "";
                    map_Save = false;
                    entered = false;
                }
                catch (Exception e)
                {

                }
            }
            //load
            if ((Mouse.GetState().X > sPosX && Mouse.GetState().X < sPosX + loadButton.Width &&
                Mouse.GetState().Y > sPosY && Mouse.GetState().Y < sPosY + loadButton.Height
                && Mouse.GetState().LeftButton == ButtonState.Pressed && map_Load == true
                && pastMouse.LeftButton == ButtonState.Released) || loadAct == true)
            {
                try
                {
                    System.IO.StreamReader file = new System.IO.StreamReader(@"" + Map_GameName + ".txt");
                    String lines = null;
                    int count = 0;
                    while ((lines = file.ReadLine()) != null)
                    {
                        string[] tp = lines.Split(',');
                        int count2 = 0;
                        foreach (string w in tp)
                        {
                            if (count2 < 60 && count < 60)
                                myTiles[count, count2++].type = Convert.ToInt32(w);
                        }
                        count++;
                    }
                    file.Close();
                    System.IO.StreamReader fileUnits = new System.IO.StreamReader(@"" + Map_GameName + "units.txt");
                    String lines2 = "";

                    showGameNames = false;

                    if (currentView == 13)
                    {
                        while ((lines2 = fileUnits.ReadLine()) != null)
                        {
                            string[] words = lines2.Split(',');
                            mapUnits.Add(new Units(new Vector2((float)Convert.ToDouble(words[1]), (float)Convert.ToDouble(words[2])),
                                 new Point(Convert.ToInt32(words[6]), Convert.ToInt32(words[7])), Convert.ToInt32(words[4]), 10,
                                 Convert.ToInt32(words[5]), Convert.ToInt32(words[8])
                                 , myTiles, Convert.ToInt32(words[3]), Convert.ToInt32(words[9])));
                        }
                    }
                    fileUnits.Close();

                    entered = false;
                    error_Active = false;
                    loadAct = false;
                    map_Load = false;


                }
                catch (Exception e)
                {
                    map_Load = true;
                    entered = true;
                    error = e.ToString();
                    error_Active = true;
                }
            }
            Map_GameName = textString;
            pastMouse = Mouse.GetState();
        }

        protected void UpdateInput()
        {
            oldKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            Keys[] pressedKeys;
            pressedKeys = currentKeyboardState.GetPressedKeys();
            try
            {
                foreach (Keys key in pressedKeys)
                {
                    if ((Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.Right)))
                    {
                        shift = true;
                    }
                    else
                    {
                        shift = false;
                    }

                    if (oldKeyboardState.IsKeyUp(key))
                    {

                        if (key == Keys.Back) // overflows
                        {
                            textString = textString.Remove(textString.Length - 1, 1);

                        }
                        else if (key == Keys.D0 || key == Keys.NumPad0)
                        {
                            textString += "0";
                        }
                        else if (key == Keys.D1 || key == Keys.NumPad1)
                        {
                            textString += "1";
                        }
                        else if (key == Keys.D2 || key == Keys.NumPad2)
                        {
                            textString += "2";
                        }
                        else if (key == Keys.D3 || key == Keys.NumPad3)
                        {
                            textString += "3";
                        }
                        else if (key == Keys.D4 || key == Keys.NumPad4)
                        {
                            textString += "4";
                        }
                        else if (key == Keys.D5 || key == Keys.NumPad5)
                        {
                            textString += "5";
                        }
                        else if (key == Keys.D6 || key == Keys.NumPad6)
                        {
                            textString += "6";
                        }
                        else if (key == Keys.D7 || key == Keys.NumPad7)
                        {
                            textString += "7";
                        }
                        else if (key == Keys.D8 || key == Keys.NumPad8)
                        {
                            textString += "8";
                        }
                        else if (key == Keys.D9 || key == Keys.NumPad9)
                        {
                            textString += "9";
                        }
                        else if (key == Keys.OemQuestion || key == Keys.Decimal)
                        {
                            textString += ".";
                        }
                        else if (key == Keys.A)
                        {
                            if (shift)
                                textString += "A";
                            else
                                textString += "a";
                        }
                        else if (key == Keys.B)
                        {
                            if (shift)
                                textString += "B";
                            else
                                textString += "b";
                        }
                        else if (key == Keys.A)
                        {
                            if (shift)

                                textString += "C";
                            else
                                textString += "c";
                        }
                        else if (key == Keys.D)
                        {
                            if (shift)
                                textString += "D";
                            else
                                textString += "d";
                        }
                        else if (key == Keys.E)
                        {
                            if (shift)
                                textString += "E";
                            else
                                textString += "e";
                        }
                        else if (key == Keys.F)
                        {
                            if (shift)
                                textString += "F";
                            else
                                textString += "f";
                        }
                        else if (key == Keys.G)
                        {
                            if (shift)
                                textString += "G";
                            else
                                textString += "g";
                        }
                        else if (key == Keys.H)
                        {
                            if (shift)
                                textString += "H";
                            else
                                textString += "h";
                        }
                        else if (key == Keys.I)
                        {
                            if (shift)
                                textString += "I";
                            else
                                textString += "i";
                        }
                        else if (key == Keys.J)
                        {
                            if (shift)
                                textString += "J";
                            else
                                textString += "j";
                        }
                        else if (key == Keys.K)
                        {
                            if (shift)
                                textString += "K";
                            else
                                textString += "k";
                        }
                        else if (key == Keys.L)
                        {
                            if (shift)
                                textString += "L";
                            else
                                textString += "l";
                        }
                        else if (key == Keys.M)
                        {
                            if (shift)
                                textString += "M";
                            else
                                textString += "m";
                        }
                        else if (key == Keys.N)
                        {
                            if (shift)
                                textString += "N";
                            else
                                textString += "n";
                        }
                        else if (key == Keys.O)
                        {
                            if (shift)
                                textString += "O";
                            else
                                textString += "o";
                        }
                        else if (key == Keys.P)
                        {
                            if (shift)
                                textString += "P";
                            else
                                textString += "p";
                        }
                        else if (key == Keys.Q)
                        {
                            if (shift)
                                textString += "Q";
                            else
                                textString += "q";
                        }
                        else if (key == Keys.R)
                        {
                            if (shift)
                                textString += "R";
                            else
                                textString += "r";
                        }
                        else if (key == Keys.S)
                        {
                            if (shift)
                                textString += "S";
                            else
                                textString += "s";
                        }
                        else if (key == Keys.T)
                        {
                            if (shift)
                                textString += "T";
                            else
                                textString += "t";
                        }
                        else if (key == Keys.U)
                        {
                            if (shift)
                                textString += "U";
                            else
                                textString += "u";
                        }
                        else if (key == Keys.V)
                        {
                            if (shift)
                                textString += "V";
                            else
                                textString += "v";
                        }
                        else if (key == Keys.W)
                        {
                            if (shift)
                                textString += "W";
                            else
                                textString += "w";
                        }
                        else if (key == Keys.X)
                        {
                            if (shift)
                                textString += "X";
                            else
                                textString += "x";
                        }
                        else if (key == Keys.Y)
                        {
                            if (shift)
                                textString += "y";
                            else
                                textString += "y";
                        }
                        else if (key == Keys.Z)
                        {
                            if (shift)
                                textString += "Z";
                            else
                                textString += "z";
                        }
                        else if (key == Keys.Space)
                            textString = textString.Insert(textString.Length, " ");



                    }
                }
            }
            catch (Exception)
            {
                textString = "";
            }

        }

        protected void Map_Menu()
        {
            for (int h = 0; h < 12; h++)
            {
                mapAction = buttons[h].input(new Vector2(Mouse.GetState().X, Mouse.GetState().Y), tiles);

                switch (mapAction)
                {
                    case 1:
                        {
                            if (currentView == 13)
                            {

                                for (int a = 0; a < 12; a++)
                                {
                                    buttons[a].selected = false;
                                }
                                buttons[0].selected = true;
                                type = 0;
                                plotTiles = true;
                                plotUnits = false;

                            }
                            break;
                        }
                    case 2:
                        {
                            if (currentView == 13)
                            {
                                for (int a = 0; a < 12; a++)
                                {
                                    buttons[a].selected = false;
                                }
                                buttons[1].selected = true;
                                type = 1;
                                plotTiles = true;
                                plotUnits = false;
                            }
                            break;
                        }
                    case 3:
                        {
                            if (currentView == 13)
                            {
                                for (int a = 0; a < 12; a++)
                                {
                                    buttons[a].selected = false;
                                }
                                buttons[2].selected = true;
                                type = 2;
                                plotTiles = true;
                                plotUnits = false;
                            }
                            break;
                        }
                    case 4:
                        {
                            if (currentView == 13)
                            {
                                for (int a = 0; a < 12; a++)
                                {
                                    buttons[a].selected = false;
                                }
                                buttons[3].selected = true;
                                type = 3;
                                plotTiles = true;
                                plotUnits = false;
                            }
                            break;
                        }
                    case 5:
                        {
                            if (currentView == 13)
                            {
                                for (int a = 0; a < 12; a++)
                                {
                                    buttons[a].selected = false;
                                }
                                buttons[4].selected = true;
                                plotTiles = true;
                                plotUnits = false;
                                type = 4;
                            }
                            break;
                        }
                    case 6:
                        {
                            if (currentView == 13)
                            {
                                map_Save = true;
                                map_Load = false;
                                entered = true;
                                plotTiles = false;
                                plotUnits = false;
                            }
                            break;
                        }
                    case 7:
                        {
                            if (currentView == 13)
                            {
                                System.IO.StreamReader file1 = new System.IO.StreamReader(@"" + map_GameNames);
                                lineForGameNames = file1.ReadLine();
                                file1.Close();
                                map_Save = false;
                                showGameNames = true;
                                map_Load = true;
                                //entered = true;
                                plotTiles = false;
                                plotUnits = false;
                            }
                            break;
                        }
                    case 8:
                        {
                            if (currentView == 13)
                            {
                                currentView = 1;
                            }
                            break;
                        }
                    case 9:
                        {
                            if (currentView == 13)
                            {
                                for (int a = 0; a < 12; a++)
                                {
                                    buttons[a].selected = false;
                                }
                                buttons[8].selected = true;
                                plotTiles = false;
                                plotUnits = true;
                                unitType = tank;
                                unitPic = 2;
                                Unitside = 2;
                                // type = 4;
                            }
                            break;
                        }
                    case 10:
                        {
                            if (currentView == 13)
                            {
                                for (int a = 0; a < 12; a++)
                                {
                                    buttons[a].selected = false;
                                }
                                buttons[9].selected = true;
                                plotTiles = false;
                                plotUnits = true;
                                unitType = tank;
                                unitPic = 0;
                                Unitside = 2;

                                //type = 4;
                            }
                            break;
                        }
                    case 11:
                        {
                            if (currentView == 13)
                            {
                                for (int a = 0; a < 12; a++)
                                {
                                    buttons[a].selected = false;
                                }
                                buttons[10].selected = true;
                                // type = 4;
                                plotTiles = false;
                                plotUnits = true;
                                unitType = tank;
                                unitPic = 3;
                                Unitside = 1;
                            }
                            break;
                        }
                    case 12:
                        {
                            if (currentView == 13)
                            {
                                for (int a = 0; a < 12; a++)
                                {
                                    buttons[a].selected = false;
                                }
                                buttons[11].selected = true;
                                plotTiles = false;
                                plotUnits = true;
                                unitType = tank;
                                unitPic = 1;
                                Unitside = 1;

                                //type = 4;
                            }
                            break;
                        }


                }

            }
        }

        protected void MoveCam()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                camX = camX - 5;
                if (camX - graphics.PreferredBackBufferWidth / 2 <= -1250)
                {
                    camX = -1250 + graphics.PreferredBackBufferWidth / 2;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                camX = camX + 5;
                if (camX + graphics.PreferredBackBufferWidth / 2 >= 1900)
                {
                    camX = 1900 - graphics.PreferredBackBufferWidth / 2;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                camY = camY - 5;

                if (camY - graphics.PreferredBackBufferHeight / 2 <= -1275)
                {
                    camY = -1275 + graphics.PreferredBackBufferHeight / 2;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                camY = camY + 5;
                if (camY + graphics.PreferredBackBufferHeight / 2 >= 2000)
                {
                    camY = 2000 - graphics.PreferredBackBufferHeight / 2;
                }
            }

        }

        protected void menu8()
        {
            if (Mouse.GetState().X >= 0 && Mouse.GetState().X <= 100
             && Mouse.GetState().Y >= 0 && Mouse.GetState().Y <= 20
             && Mouse.GetState().LeftButton == ButtonState.Pressed && currentView == 8)
            {
                currentView = 1;
                menuInstance.Play();
                backmusicInstace.Pause();

                //MediaPlayer.Pause();
            }
            if (Mouse.GetState().X >= 110 && Mouse.GetState().X <= 210
             && Mouse.GetState().Y >= 0 && Mouse.GetState().Y <= 20
             && Mouse.GetState().LeftButton == ButtonState.Pressed && currentView == 8)
            {
                currentView = 10;
                //MediaPlayer.Pause();
            }
            if (Mouse.GetState().X >= 320 && Mouse.GetState().X <= 420
             && Mouse.GetState().Y >= 56 && Mouse.GetState().Y <= 70
             && Mouse.GetState().LeftButton == ButtonState.Pressed && currentView == 8)
            {
                entered = false;
                chat = false;
                textString = "";
                //MediaPlayer.Pause();
            }
            if (Mouse.GetState().X >= 430 && Mouse.GetState().X <= 540
             && Mouse.GetState().Y >= 56 && Mouse.GetState().Y <= 70
             && Mouse.GetState().LeftButton == ButtonState.Pressed && currentView == 8
                && pastMouse.LeftButton == ButtonState.Released)
            {
                network.sendData("&m", 0, Vector2.Zero, textString, false);
                entered = false;
                chat = false;
                textString = "";
                //MediaPlayer.Pause();
            }
            if (Mouse.GetState().X >= 216 && Mouse.GetState().X <= 316
              && Mouse.GetState().Y >= 0 && Mouse.GetState().Y <= 20
              && Mouse.GetState().LeftButton == ButtonState.Pressed && currentView == 8 && showNet == false &&
                pastMouse.LeftButton == ButtonState.Released)
            {
                showNet = true;

                // MediaPlayer.Pause();
            }
            if (Mouse.GetState().X >= 325 && Mouse.GetState().X <= 425
              && Mouse.GetState().Y >= 0 && Mouse.GetState().Y <= 20
              && Mouse.GetState().LeftButton == ButtonState.Pressed && currentView == 8 && chat == false
              && pastMouse.LeftButton == ButtonState.Released)
            {
                chat = true;
                // MediaPlayer.Pause();
            }
            else if (Mouse.GetState().X >= 325 && Mouse.GetState().X <= 425
              && Mouse.GetState().Y >= 0 && Mouse.GetState().Y <= 20
              && Mouse.GetState().LeftButton == ButtonState.Pressed && currentView == 8 && chat == true
              && pastMouse.LeftButton == ButtonState.Released)
            {
                entered = true;
                chat = false;
            }
            if (Mouse.GetState().X >= 780 && Mouse.GetState().X <= 825
             && Mouse.GetState().Y >= 640 && Mouse.GetState().Y <= 674
              && Mouse.GetState().LeftButton == ButtonState.Pressed && currentView == 8 && moveUnit == false
              && pastMouse.LeftButton == ButtonState.Released)
            {
                moveUnit = true;
                // MediaPlayer.Pause();
            }
            else if (Mouse.GetState().X >= 780 && Mouse.GetState().X <= 825
             && Mouse.GetState().Y >= 640 && Mouse.GetState().Y <= 674
              && Mouse.GetState().LeftButton == ButtonState.Pressed && currentView == 8 && moveUnit == true
                && pastMouse.LeftButton == ButtonState.Released)
            {
                moveUnit = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F) && pastkey.IsKeyUp(Keys.F) && moveUnit)
            {
                findPath = true;
            }
            pastkey = Keyboard.GetState();

            pastMouse = Mouse.GetState();
        }

        protected void drawRectangle(int x1, int y1, int width, int height, GraphicsDeviceManager graphics, SpriteBatch batch, Color color)
        {
            Rectangle spriteTextnew;
            spriteTextnew = new Rectangle(x1, y1, width, height);
            int bw = 2;
            Texture2D t;
            t = new Texture2D(graphics.GraphicsDevice, 1, 1);

            t.SetData(new[] { Color.White });

            batch.Draw(t, new Rectangle(spriteTextnew.Left, spriteTextnew.Top, bw, spriteTextnew.Height), color); // Left
            batch.Draw(t, new Rectangle(spriteTextnew.Right, spriteTextnew.Top, bw, spriteTextnew.Height), color); // Right
            batch.Draw(t, new Rectangle(spriteTextnew.Left, spriteTextnew.Top, spriteTextnew.Width, bw), color); // Top
            batch.Draw(t, new Rectangle(spriteTextnew.Left, spriteTextnew.Bottom, spriteTextnew.Width + 2, bw), color);//bottom

        }

        protected void mapDraw()
        {
            Map_Menu();
            saveAndload();

            for (int x = 0; x < row; x++)
            {
                for (int y = 0; y < col; y++)
                {
                    myTiles[x, y].drawTile(graphics, spriteBatch, tiles, camX, camY);
                }
            }
            for (int x = 0; x < mapUnits.Count; x++)
            {
                mapUnits[x].DrawUnit(spriteBatch, graphics, unitsPics, camX, camY, myFont, network, x);

            }
            changeTile();
            if (entered == true && map_Save == true)
            {
                spriteBatch.Draw(saveButton, new Vector2(Window.ClientBounds.Width / 2 - saveButton.Width / 2, Window.ClientBounds.Height / 2 - saveButton.Height / 2 + 30), Color.White);
                spriteBatch.Draw(input, new Vector2(Window.ClientBounds.Width / 2 - input.Width / 2, Window.ClientBounds.Height / 2 - input.Height / 2), Color.White);
                spriteBatch.DrawString(mapFont, "Enter the name of the map", new Vector2(Window.ClientBounds.Width / 2 - input.Width / 2, 360), Color.White);
                spriteBatch.DrawString(mapFont, textString, new Vector2(Window.ClientBounds.Width / 2 - input.Width / 2 + 3, Window.ClientBounds.Height / 2 - input.Height / 2 + 2), Color.Red);
            }
            else
            {
                textString = "";
            }
            if (map_Load == true)
            {
                loadMenu();
            }


            if (showGameNames == false)
            {
                if (posY >= 0)
                {
                    posYY -= 20;

                }
                spriteBatch.Draw(shop, new Vector2(Window.ClientBounds.Width / 2 - shop.Width / 2, posYY), Color.White);
            }
            spriteBatch.Draw(minimap, new Vector2(0, 640), Color.White);
            DrawMinimap();
            spriteBatch.Draw(mapInterFace, new Vector2(0, 0), Color.White);
            for (int i = 0; i < 12; i++)
            {
                buttons[i].myDraw(spriteBatch, tiles, graphics);
            }

        }

        protected void DrawMinimap()
        {

            for (int x = 0; x < row; x++)
            {

                for (int y = 0; y < col; y++)
                {

                    if (myTiles[x, y].type == 0)
                    {
                        spriteBatch.Draw(minMapSprite[0], new Vector2(108 + (int)myTiles[x, y].position.X /
                            (5000 / 150), 712 + (int)myTiles[x, y].position.Y / (5000 / 100)), Color.White);
                    }
                    if (myTiles[x, y].type == 1)
                    {
                        spriteBatch.Draw(minMapSprite[1], new Vector2(108 + (int)myTiles[x, y].position.X /
                            (5000 / 150), 712 + (int)myTiles[x, y].position.Y / (5000 / 100)), Color.White);
                    }
                    if (myTiles[x, y].type == 2)
                    {
                        spriteBatch.Draw(minMapSprite[2], new Vector2(108 + (int)myTiles[x, y].position.X /
                            (5000 / 150), 712 + (int)myTiles[x, y].position.Y / (5000 / 100)), Color.White);
                    }
                    if (myTiles[x, y].type == 3)
                    {
                        spriteBatch.Draw(minMapSprite[3], new Vector2(108 + (int)myTiles[x, y].position.X /
                            (5000 / 150), 712 + (int)myTiles[x, y].position.Y / (5000 / 100)), Color.White);
                    }
                    if (myTiles[x, y].type == 4)
                    {
                        spriteBatch.Draw(minMapSprite[4], new Vector2(108 + (int)myTiles[x, y].position.X /
                            (5000 / 150), 712 + (int)myTiles[x, y].position.Y / (5000 / 100)), Color.White);
                    }
                }
            }
            drawRectangle((int)(108 + (camX - graphics.PreferredBackBufferWidth / 2) / (5000 / 150)),
                          (int)(712 + (camY - graphics.PreferredBackBufferHeight / 2) / (5000 / 100)),
                          graphics.PreferredBackBufferWidth / (5000 / 150),
                          graphics.PreferredBackBufferHeight / (5000 / 100), graphics, spriteBatch, Color.Red);
        }

        protected void loadMenu()
        {
            string[] tp;
            int count = 0;
            tp = lineForGameNames.Split(',');
            try
            {




                foreach (string w in tp)
                {

                    spriteBatch.Draw(head, new Vector2(Window.ClientBounds.Width / 2 - head.Width /2, 0), Color.White);

                    loadButtons.Add(new MyButtonPics(new Vector2(Window.ClientBounds.Width / 2 - input.Width / 2,
                        (50 + (count * 30))), 13, count + 1));
                    loadButtons[count].myDraw(spriteBatch, tiles, graphics);
                    spriteBatch.DrawString(Font, tp[count], new Vector2(Window.ClientBounds.Width / 2 - input.Width / 2 + 70, (60 + (count * 30))), Color.Red);
                    count++;
                }
                count = 0;
            }
            catch (Exception e)
            {
                spriteBatch.DrawString(Font, e.ToString(), new Vector2(Window.ClientBounds.Width / 2 - input.Width / 2, (count * 40)), Color.Red);
            }
            if (loadButtons.Count > 0)
            {
                for (int x = 0; x < loadButtons.Count; x++)
                {
                    loadAction = loadButtons[x].input(new Vector2(Mouse.GetState().X, Mouse.GetState().Y), tiles);
                    switch (loadAction)
                    {
                        case 1:
                            {
                                if (tp[0] != "")
                                {
                                    if (currentView == 13)
                                    {
                                        Map_GameName = tp[0];
                                        loadAct = true;
                                        saveAndload();
                                    }
                                    else if (currentView == 15 || currentView == 7)
                                    {
                                        Map_GameName = tp[0];
                                        loadMapForMainGame(Map_GameName);
                                        currentView = 8;
                                    }
                                    break;
                                }
                            }
                            break;
                        case 2:
                            {
                                if (tp[1] != "")
                                {
                                    if (currentView == 13)
                                    {
                                        Map_GameName = tp[1];
                                        loadAct = true;
                                        saveAndload();
                                    }
                                    else if (currentView == 15 || currentView == 7)
                                    {
                                        Map_GameName = tp[1];
                                        loadMapForMainGame(Map_GameName);
                                        currentView = 8;
                                    }
                                    break;
                                }
                            }
                            break;
                        case 3:
                            {
                                if (tp[2] != "")
                                {
                                    if (currentView == 13)
                                    {
                                        Map_GameName = tp[2];
                                        loadAct = true;
                                        saveAndload();
                                    }
                                    else if (currentView == 15 || currentView == 7)
                                    {
                                        Map_GameName = tp[2];
                                        loadMapForMainGame(Map_GameName);
                                        currentView = 8;
                                    }
                                    break;
                                }
                            }
                            break;
                        case 4:
                            {
                                if (tp[3] != "")
                                {
                                    if (currentView == 13)
                                    {
                                        Map_GameName = tp[3];
                                        loadAct = true;
                                        saveAndload();
                                    }
                                    else if (currentView == 15 || currentView == 7)
                                    {
                                        Map_GameName = tp[3];
                                        loadMapForMainGame(Map_GameName);
                                        currentView = 8;
                                    }
                                    break;
                                }
                            }
                            break;
                        case 5:
                            {
                                if (tp[4] != "")
                                {
                                    if (currentView == 13)
                                    {
                                        Map_GameName = tp[4];
                                        loadAct = true;
                                        saveAndload();
                                    }
                                    else if (currentView == 15 || currentView == 7)
                                    {
                                        Map_GameName = tp[4];
                                        loadMapForMainGame(Map_GameName);
                                        currentView = 8;
                                    }
                                    break;

                                }
                            }
                            break;
                        case 6:
                            {
                                if (tp[5] != "")
                                {
                                    if (currentView == 13)
                                    {
                                        Map_GameName = tp[5];
                                        loadAct = true;
                                        saveAndload();
                                    }
                                    else if (currentView == 15 || currentView == 7)
                                    {
                                        Map_GameName = tp[5];
                                        loadMapForMainGame(Map_GameName);
                                        currentView = 8;
                                    }
                                    break;
                                }
                            }
                            break;
                        case 7:
                            {
                                if (tp[6] != "")
                                {
                                    if (currentView == 13)
                                    {
                                        Map_GameName = tp[2];
                                        loadAct = true;
                                        saveAndload();
                                    }
                                    else if (currentView == 15 || currentView == 7)
                                    {
                                        Map_GameName = tp[6];
                                        loadMapForMainGame(Map_GameName);
                                        currentView = 8;
                                    }
                                    break;
                                }
                            }
                            break;
                        case 8:
                            {
                                if (tp[7] != "")
                                {
                                    if (currentView == 13)
                                    {
                                        Map_GameName = tp[7];
                                        loadAct = true;
                                        saveAndload();
                                    }
                                    else if (currentView == 15 || currentView == 7)
                                    {
                                        Map_GameName = tp[7];
                                        loadMapForMainGame(Map_GameName);
                                        currentView = 8;
                                    }
                                    break;
                                }
                            }
                            break;
                        case 9:
                            {
                                if (tp[8] != "")
                                {
                                    if (currentView == 13)
                                    {
                                        Map_GameName = tp[8];
                                        loadAct = true;
                                        saveAndload();
                                    }
                                    else if (currentView == 15 || currentView == 7)
                                    {
                                        Map_GameName = tp[8];
                                        loadMapForMainGame(Map_GameName);
                                        currentView = 8;
                                    }
                                    break;
                                }
                            }
                            break;
                        case 10:
                            {
                                if (tp[9] != "")
                                {
                                    if (currentView == 13)
                                    {
                                        Map_GameName = tp[9];
                                        loadAct = true;
                                        saveAndload();
                                    }
                                    else if (currentView == 15 || currentView == 7)
                                    {
                                        Map_GameName = tp[9];
                                        loadMapForMainGame(Map_GameName);
                                        currentView = 8;
                                    }
                                    break;
                                }
                            }
                            break;
                       
                    }
                }
            }
        }
    }

}
