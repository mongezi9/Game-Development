using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace _2D_enviro_Softwre
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D[] door = new Texture2D[16];        
        KeyboardState oldState;
        Texture2D btnEfects;
        Vector2 pos;        
        Color myCol = Color.White;
        Texture2D pnn;
        bool seen=false;
        bool seen2 = false;
        Texture2D outSde;
        Texture2D[] pn= new Texture2D [5];
        Texture2D[] led = new Texture2D[44];        
        int[] passward = new int [4];//holds the passward
        int[] pin = new int[5];
        int currentView = 0;
        Vector2 posPin;
        MouseState oldMous, newMouseStat;
        //objects
        Simulation mySimObj;
        
        btnEffects myBtnObj;
        bool ledRed = true;
        bool rstWrong;
        double hours=6;

        Texture2D [] ctrls= new Texture2D [5];

        Texture2D[] doorIn = new Texture2D [3];

        //state input
        KeyboardState KyNewState, kyOldState;
        //font
        SpriteFont Font1;
        Vector2 FontPos;
        //serial port 
       // DateTime thisdate=DateTime .Now ;
        //DateTime thisDate2;
        DateTime thisDate;
        string name = "";
        string surnam = "";
        string code = "";
        
        Texture2D initImg;
        Texture2D[] lights= new Texture2D [5];
        bool updtLight = false;
        Vector2 BtnPos;
        SerialPort portFTDI;
        SerialPort portArduino;
        string readPort2 = "com5";

        Texture2D[] satellite = new Texture2D [20];
        Texture2D CAMER;
        string reade = "";
        string readPort = "none";
        bool houseConnected = false;
        bool hasHappen = false;
        bool done = false;

        bool houseConnected2 = false;
        bool hasHappen2 = false;
        bool done2 = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 454;
            graphics.PreferredBackBufferWidth = 827;
            IsMouseVisible = true;
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
            oldState = Keyboard.GetState();
            pos.X = 184; //for btn efects
            pos.Y = 161; //for btneffects
            posPin.X = 0;
            posPin.Y = 0;
            

            BtnPos.X = 0;
            BtnPos.Y = 0;

            //initialise passward
            for (int k = 0; k < 4;k++ )
            {
                passward[k] = 0;
            }        
            base.Initialize();
            mySimObj.initImg = initImg;
            portFTDI = new SerialPort(readPort, 9600);
            portArduino = new SerialPort(readPort2 ,9600);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        /// 
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //animation buttons
            for (int i = 0; i < 14; i++)
            {
                door[i] = Content.Load<Texture2D>(@"BackPic\Door" + i);             
            }
            btnEfects = Content.Load<Texture2D>(@"button\btn1");
            pnn = Content.Load<Texture2D>(@"button\pn0");
            pn[0] = Content.Load<Texture2D>(@"button\pn0");
            pn[1] = Content.Load<Texture2D>(@"button\pn1");
            pn[2] = Content.Load<Texture2D>(@"button\pn2");
            pn[3] = Content.Load<Texture2D>(@"button\pn3");

            outSde = Content.Load < Texture2D> (@"button\out");
           for (int j = 0; j < 3;j++ )
            {
                led[j] = Content.Load<Texture2D>(@"led\led"+j);
            }
            
            mySimObj = new Simulation(currentView, outSde, led );
            mySimObj.loopDoor = 0;
            mySimObj .hasOpen =false;
            myBtnObj = new btnEffects(pos, btnEfects, currentView   );
            myBtnObj.ootS = outSde;
            myBtnObj.lld = led;
            for (int j = 0; j < 4; j++)
            {
                myBtnObj .pinPic [j] = Content.Load<Texture2D>(@"button\pn" + j);
            //    myBtnObj . light[j] = Content.Load<Texture2D>(@"button\l" + j);
            }
            //fonts
            Font1 = Content.Load<SpriteFont>("spritefont1");
            FontPos = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2,graphics.GraphicsDevice.Viewport.Height / 2);
            initImg = Content .Load <Texture2D >(@"backPic\backImg");
            //client
         
            //simulation
            for (int k = 1; k < 3;k++ )
            {
                doorIn[k] = Content.Load<Texture2D>(@"button\in" + k);
              
            }
            for (int l = 1; l < 3; l++)
            {
                myBtnObj .doorIn [l] =doorIn[l];
                
            }
            for (int k = 1; k < 5; k++)
            {
                ctrls[k] = Content.Load<Texture2D>(@"button\ctrl" + k);
               
            }
            for (int l = 1; l < 5; l++)
            {
                myBtnObj.contrls[l] = ctrls[l];
              
            }
            for (int j = 1; j < 4; j++)
            {
               
                myBtnObj.light[j] = Content.Load<Texture2D>(@"button\l" + j);
            }

            mySimObj.light = myBtnObj.light[2];
            //load satellites
            for (int i = 0; i < 13;i++ )
            {
              satellite [i]=Content .Load <Texture2D >(@"satellites\s"+i);
            }
            //send values to other class btnEfffect
            for (int i = 0; i < 13; i++)
            {
                myBtnObj.satelts[i]=satellite [i];
            }
            myBtnObj  .camer  = Content .Load <Texture2D >(@"satellites\camer");
            // TODO: use this.Content to load your game content here
        }
        //drawing rectangle
        public void drawRectangle(Vector2 where, int width, int height, Color col)
        {
            Rectangle clipingRectangle;
            Texture2D t;
            int bw = 2;
            clipingRectangle = new Rectangle((int)where.X, (int)where.Y, width, height);
            t = new Texture2D(graphics.GraphicsDevice, 1, 1);
            t.SetData(new[] { Color.White });
            spriteBatch.Draw(t, new Rectangle(clipingRectangle.Left, clipingRectangle.Top, bw, clipingRectangle.Height), col); // Left
            spriteBatch.Draw(t, new Rectangle(clipingRectangle.Right, clipingRectangle.Top, bw, clipingRectangle.Height), col); // Right
            spriteBatch.Draw(t, new Rectangle(clipingRectangle.Left, clipingRectangle.Top, clipingRectangle.Width, bw), col); // Top
            spriteBatch.Draw(t, new Rectangle(clipingRectangle.Left, clipingRectangle.Bottom, clipingRectangle.Width + 2, bw), col); // Bottom
        }
        
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        /// 

        protected void setupCom1()
        {
            //arduino
            StreamReader portName2 = new StreamReader("c://project//comm.txt");
            readPort2 = portName2.ReadLine();
            portName2.Close();//close file after reading

            portArduino.PortName = readPort2;
        }
        protected void setupCom()
        {
           
            StreamReader portName = new StreamReader ("C://project//com.txt");
            readPort =portName.ReadLine();
            portName.Close();//close file after reading

            portFTDI.PortName = readPort;
          
        }
        
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
            //thisDate2 = thisdate;
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
           
            // TODO: Add your update logic here
           
          //update time
          //  thisdate = DateTime.Today; 
            /////
          
            //clearing the btn efects at view 1
            myBtnObj.loopDoorBtn = mySimObj.loopDoor;
            if (mySimObj.loopDoor == 13)
            {
                //portArduino.WriteLine("GG");
                myBtnObj.CurV = 1;
                code = "";
                mySimObj .updtLight  = myBtnObj.updtLigh;
                portArduino.Close();

            }
            
            if(mySimObj .loopDoor==0)
            {
                
                myBtnObj.CurV = 0;
                //clear all flags in view 11
                mySimObj.flgGoOut = false ;
                myBtnObj.flgGoOut = false;
                //portsConnect();
                /*portsConnect();
                port.WriteLine("'3'".ToString ());
                //port.Close();*/
                myKeyUpdate();
                //send values of inputed passward
               
                //update the clicked key on hardware keypad
               
               
               
               // port.Close();
           
               

                mySimObj.OrigPasscode = code;//passcode setup
                

                if(myBtnObj .doneEnterinPin  )
                {
                    //setupCom1();
                     //portArduino.PortName = readPort2;
                    //portArduino.Open();
                    portsConnect();
                     if (mySimObj .mOutArea == false)
                    {
                        passward[0] = myBtnObj.passward[0];
                        passward[1] = myBtnObj.passward[1];
                        passward[2] = myBtnObj.passward[2];
                        passward[3] = myBtnObj.passward[3];

                         //if passward i wrond  reset to enter new one
                        
                        mySimObj.enterPasscode = passward[0].ToString() + passward[1].ToString() + passward[2].ToString() + passward[3].ToString();

                        if (mySimObj.enterPasscode != mySimObj.OrigPasscode && myBtnObj.doneEnterinPin && !mySimObj.ledR)
                        {
                            mySimObj.ledR = true;
                           
                                portFTDI.Close();
                                //portArduino.Open();
                                portsConnect1();
                                portArduino.WriteLine("R");

                              

                        }
                        //IF THE       data is correct do green led onf arduin

                        else if (mySimObj.enterPasscode == mySimObj.OrigPasscode && seen == false)
                            {
                             /*   portFTDI.Close();
                                portsConnect1();
                                portArduino.WriteLine("T");
                                portArduino.WriteLine("G");
                                seen = true;
                                
                                portArduino.Close();
                                portsConnect();
                                portFTDI.WriteLine("1");
                              */ 
                              
                            }
                           // portsConnect1();
                            
                           // portArduino.Close();
                           
                      
                      
                            
                           
                        
                        
                         // assignin the value of loopdoor to btnEffect lopdoor
                        myBtnObj.loopDoorBtn = mySimObj.loopDoor;
                         //reseting the wrong inout for passcode
                        
                         
                         
                     }
                    else if( mySimObj .mOutArea == true  ) {

                        //reseting entered passcode
                       
                        myBtnObj.passward[0] = 0;
                        myBtnObj.passward[1] = 0;
                        myBtnObj.passward[2] = 0;
                        myBtnObj.passward[3] = 0;
                      /*  portFTDI.Close();
                        portsConnect1();
                        //portArduino.Open();
                        portArduino.WriteLine("T");
                       
                        portArduino.Close();
                        portsConnect();
                        portFTDI.WriteLine("0");
                       */
                        //portArduino.WriteLine("RR");
                        //portArduino.Close();
                        myBtnObj.doneEnterinPin = false;
                        myBtnObj.mouseClicked = -1;
                        myBtnObj.btnClickedF = false;
                        mySimObj.enterPasscode = passward[0].ToString() + passward[1].ToString() + passward[2].ToString() + passward[3].ToString();
                        mySimObj.mOutArea = false;
                        //System.Threading.Thread.Sleep(500);
                        for (int k = 0; k < 4; k++)
                        {
                            myBtnObj.updateDisplPin[k] = false;
                        }
                    }
                    
                    
                }
                if (myBtnObj.rstWrong == 10 && mySimObj.loopDoor == 0)
                {

                    myBtnObj.passward[0] = 0;
                    myBtnObj.passward[1] = 0;
                    myBtnObj.passward[2] = 0;
                    myBtnObj.passward[3] = 0;

                    //red led is reseted as well
                    
                    portFTDI.Close();
                    portsConnect1();
                    //portArduino.Open();
                    portArduino.WriteLine("T");
                    seen2 = false ;
                   // portFTDI.Open();
                    
                    //reseting pin attributes
                    myBtnObj.doneEnterinPin = false;
                    myBtnObj.mouseClicked = -1;
                    myBtnObj.btnClickedF = false;
                    mySimObj.enterPasscode = passward[0].ToString() + passward[1].ToString() + passward[2].ToString() + passward[3].ToString();

                   // myBtnObj.rstWrong = 0;
                    mySimObj.ledR = false;
                    //display pin value reseted
                    for (int k = 0; k < 4; k++)
                    {
                        myBtnObj.updateDisplPin[k] = false;
                    }
                }
                    
                   
                   
            }
            /////////end/////////
            if (mySimObj.outflg)//reset name and surnme
            {
                
            }
            if (myBtnObj.CurV == 1)
            {
                mySimObj.flgGoOut = myBtnObj.flgGoOut;
                mySimObj.outflg = myBtnObj.outFlg;
                //green led is reseted
                //setupCom1();
               /* portArduino.Close();
                portsConnect();
                portFTDI.WriteLine("1");
                               
                   
                     portFTDI.WriteLine(myBtnObj.increm_OR_decrem1.ToString());
                   
                */
                seen = false;
           //     portsConnect1();
                //portArduino .Open ();
                //portArduino.WriteLine("GG");
               // portArduino.Close ();
                //passward initialization
                if(mySimObj .PassCorrect )
                {
                passward[0] = -1;
                mySimObj.enterPasscode = "****";
                }
               // code = "";
            }
            ////mous is clicked once
            oldMous = newMouseStat;
            newMouseStat = Mouse.GetState();

            myBtnObj.updateMyInput();
           thisDate = DateTime.UtcNow;
            base.Update(gameTime);
          /*  name = "Emmanuel Mongezi";
            surnam = "Mthimunye";
            */
           //read from txt files && ensures that it updates at view zero
            if(mySimObj .currentView == 0)
            {
                readFromTXT();
            }
           
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 
        protected void myKeyUpdate()
        {
            //port.Open();

           // port.ReadChar();

            /*myBtnObj.passward[0] = 0;
            myBtnObj.passward[1] = 5;
            myBtnObj.passward[2] = 8;

            myBtnObj.passward[3] = 7;
             */  
            
           // port.Close();
        }
        protected void readFromTXT()
        {
            
            StreamReader myReadr = new StreamReader ("C:\\project\\file.txt");
            String line; 
            int cout=0;
            while((line = myReadr .ReadLine ())!=null )
            {
                String[] parts = line.Split(',');
                name =parts[0].ToString ();
                surnam = parts[1].ToString();
                code = parts [2].ToString ();
                //send passcode to a tocken device
                              
                cout++;
            }
            //reder = myReadr .ReadLine ();
            myReadr .Close ();
        
           
        }
        protected void portsConnect1()
        {
            try
            {
                if (portArduino.IsOpen == false && mySimObj.currentView == 0)
                {
                    setupCom1();
                    portArduino .Open();
                    houseConnected2 = true;
                    hasHappen2 = true;
                }

            }
            catch
            {
                houseConnected2 = false;

                if (hasHappen2)
                {
                    portArduino.Close();
                    hasHappen2 = false;
                }
            }


        }
        protected void portsConnect()
        {
            try
            {
                if (portFTDI.IsOpen == false && mySimObj.currentView == 0)
                {
                    setupCom();
                    portFTDI.Open();
                    houseConnected = true;
                    hasHappen = true;
                }

            }
            catch
            {
                houseConnected = false;

                if (hasHappen)
                {
                    portFTDI.Close();
                    hasHappen = false;
                }
            }
            
        
        }
        protected int hardwrKeys()
        {
           int keyPresed=20;
            portsConnect();
           
           
          if (myBtnObj .mouseClicked < 4)
          {
            if (mySimObj.currentView == 0 && mySimObj.loopDoor == 0 && houseConnected)
            {
                reade = portFTDI.ReadExisting();
               
                if (reade.ToString() == "0")
                {
                    keyPresed =0;
                    myBtnObj.mouseClicked++;
                }
                else if (reade.ToString() == "1")
                {
                    keyPresed = 1;
                    myBtnObj.mouseClicked++;
                                    }
                else if (reade.ToString() == "2")
                {
                    keyPresed = 2;
                    myBtnObj.mouseClicked++;
                }
                else if (reade.ToString() == "3")
                {
                    keyPresed = 3;
                    myBtnObj.mouseClicked++;
       
                }
                else if (reade.ToString() == "4")
                {
                    keyPresed = 4;
                    myBtnObj.mouseClicked++;
                }
                else if (reade.ToString() == "5")
                {
                    keyPresed = 5;
                    myBtnObj.mouseClicked++;
                }
                else if (reade.ToString() == "6")
                {

                    keyPresed = 6;
                    myBtnObj.mouseClicked++;
                }
                else if (reade.ToString() == "7")
                {
                    keyPresed = 7;
                    myBtnObj.mouseClicked++;
                }
                else if (reade.ToString() == "8")
                {
                    keyPresed = 8;
                    //myBtnObj.pos.X = 201;
                    //myBtnObj.pos.Y = 189;
                    myBtnObj.mouseClicked++;
                }
                else if (reade.ToString() == "9")
                {

                    keyPresed = 9;
                    myBtnObj.mouseClicked++;
                }
                else if (reade.ToString() == "10" || reade.ToString() == "#") //#
                {
                    keyPresed = 10;
                    myBtnObj.mouseClicked++;
                }
                else if (reade.ToString() == "11" || reade.ToString() == "*")//*
                {
                    keyPresed = 11;
                    myBtnObj.mouseClicked++;
                }
                else if (reade.ToString() == "12" || reade.ToString() == "A")//A
                {
                    keyPresed = 12;
                    myBtnObj.mouseClicked++;

                }
                else if (reade.ToString() == "13" || reade.ToString() == "B")//B
                {
                    keyPresed = 13;
                    myBtnObj.mouseClicked++;
                }
                else if (reade.ToString() == "14" || reade.ToString() == "C")//C
                {
                    keyPresed = 14;
                    myBtnObj.mouseClicked++;
                }
                else if (reade.ToString() == "15" || reade.ToString() == "D")//D
                {

                    keyPresed = 15;
                    myBtnObj.mouseClicked++;
                }
                else if (reade.ToString() == "B")
                {
                    portFTDI.Close();
                    portsConnect1();
                    portArduino.WriteLine("B");
                }
                else if(reade.ToString () == "A")
                {
                    portFTDI.Close();
                    portsConnect1();
                    portArduino.WriteLine("A");
                }
                myBtnObj.doneEnterinPin = false;
            }
               if(myBtnObj .mouseClicked >=3)
               {
                   myBtnObj.mouseClicked = 3;
                   myBtnObj.doneEnterinPin = true;

               }

            }
            
            return keyPresed;         
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
           
            spriteBatch.Begin();
           

            ////////////////////////////////////testin////////////
            myBtnObj.key = hardwrKeys();
            if (done)
            {
                
                mySimObj.enterPasscode = passward[0].ToString() + passward[1].ToString() + passward[2].ToString() + passward[3].ToString();

            }
            /////////////////////////end teting///////////////////////////////////////////////////////////////////////
            ////////////////new draw door///////////////////
            mySimObj.drawAnimation(spriteBatch, door);
            myBtnObj.drwEffect(spriteBatch);
            Vector2 fontOrign = Font1.MeasureString(name) / 50;
            if (mySimObj.loopDoor == 13)
            {





                spriteBatch.DrawString(Font1, name, new Vector2(56, 64), Color.Goldenrod, 0, fontOrign, 1.0f, SpriteEffects.None, 0.5f);
                spriteBatch.DrawString(Font1, surnam, new Vector2(82, 98), Color.Goldenrod, 0, fontOrign, 1.0f, SpriteEffects.None, 0.5f);
                spriteBatch.DrawString(Font1, thisDate.ToLocalTime().ToString(), new Vector2(50, 129), Color.YellowGreen , 0, fontOrign, 1.0f, SpriteEffects.None, 0.5f);

                
            }

            System.Threading.Thread.Sleep(50);
            spriteBatch.End();
            //////////////////////////////////////////////////////////////////////////




            
            /////////////draw initiaization imge//////////

            spriteBatch.Begin();
          
            
            spriteBatch.End();
          
            base.Draw(gameTime);
        }
    }
}
