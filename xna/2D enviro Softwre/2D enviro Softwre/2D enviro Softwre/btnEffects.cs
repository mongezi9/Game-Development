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
using System.IO.Ports;

namespace _2D_enviro_Softwre
{
    class btnEffects
    {
        public bool btnClickedF;
        public bool flag;
        public Vector2 pos;
        public Texture2D btnEfects;
        public int mouseClicked;
        public int rstWrong;
        public int[] passward = new int [5];
        public Color myCol;
        public int CurV;
        public Simulation mySimObj;
        public Texture2D[] lld;
        public Texture2D ootS;
        public MouseState newMouse, oldMouse;
        public bool outFlg;
        public bool flgGoOut;
        public bool doneEnterinPin;
        public Texture2D[] pinPic;
        public Vector2 posPin;
        public bool[] updateDisplPin = new bool [5];
        public int loopDoorBtn;
        public bool inFlg1;
        public bool inFlg2;
        bool flg11;
        public Texture2D[] doorIn = new Texture2D[3];
        public Texture2D[] contrls = new Texture2D [5];
        public int stateCtrl=0;
        public Texture2D[] light= new Texture2D [5];
        public bool updtLigh;
        bool[] outRoom=new bool [3];
        bool[] lighUpDor = new bool[3];
        SerialPort portKey = new SerialPort("com5",9600);//arduino
        public Texture2D[] satelts = new Texture2D [20];
        public Texture2D camer;
        public int increm_OR_decrem1 = 0;
        public int increm_OR_decrem2 = 0;
        public int key=-1;

        public btnEffects(Vector2 p, Texture2D btn, int V)
        {
            pos = p;
            mouseClicked = -1;
            CurV = V;
            flag = false;
            btnEfects = btn;
            doneEnterinPin = false;
            pinPic = new Texture2D [5];
            
            myCol = Color.White;

        }


        //return the number clicked
        public int NumberClicked(int sel)
        {
           
            int vl = 0;
        
            switch (sel)
            {
                case 0: vl = 0;  //0
                    break;
                case 1: vl = 1;  //1
                    break;
                case 2: vl = 2;  //2
                    break;
                case 3: vl = 3;  //3
                    //portKey.Open();
                    //ascii = 'H';
                   // System.Threading.Thread.Sleep(1000);
                    //portKey.WriteLine(ascii.ToString());
                   
                    
                    break;
                case 4: vl = 4;  //4
                    break;
                case 5: vl = 5;  //5
                    break;
                case 6: vl = 6;  //6
                    break;
                case 7: vl = 7;  //7
                    break;
                case 8: vl = 8;  //8
                    break;
                case 9: vl = 9;  //9
                    break;
                case 10: vl = 10; //#
                    break;

                default: vl = 11;
                    break;

            }
            //m writing a returned value serial
           
            
            return vl ;
        }

        public void updateMyInput()
        {
            myBtnEffect();
            // MouseClickedOnce();
            oldMouse = newMouse;
            newMouse = Mouse.GetState();
            mySimObj = new Simulation(CurV, ootS, lld);

        }
        
        public void myBtnEffect() //changing button effects if mouse is over it and clicked
        {
            // 
            //column 1
            
            flag = true;
          /*  portKey .Open ();
            if(portKey .ReadByte ()=='3')
            {
                int conta=0;
               /* if(portKey .ReadLine ()=="3")
                {
                    passward[conta] = 3;
                }
            }*/
           
            if (Mouse.GetState().X > 184 && Mouse.GetState().X < 201 && (Mouse.GetState().Y > 160 && Mouse.GetState().Y < 217) || key == 1 || key == 4 || key == 7 || key == 11)
            {

                pos.X = 184;
                if (Mouse.GetState().Y > 160 && Mouse.GetState().Y < 174 || key == 1)//1
                {

                    pos.Y = 161;
                    if (btnClickedF == true || key == 1)
                    {
                        passward[mouseClicked] = NumberClicked(1); //storespassward;
                    }
                 
                }
                else if (Mouse.GetState().Y > 174 && Mouse.GetState().Y < 188 || key == 4)//4
                {
                    pos.Y = 175;
                    if (btnClickedF == true || key == 4)
                    {
                        passward[mouseClicked] = NumberClicked(4); //storespassward;
                    }
                 
                }
                else if (Mouse.GetState().Y > 188 && Mouse.GetState().Y < 202 || key == 7)//7
                {
                    pos.Y = 189;
                    if (btnClickedF == true || key == 7)
                    {
                        passward[mouseClicked] = NumberClicked(7); //storespassward;
                    }
                 
                }
                else if (Mouse.GetState().Y > 202 && Mouse.GetState().Y < 202 + 14 || key ==11 )//*
                {
                    pos.Y = 203;
                    
                }

            }
            //column 2
            else if (Mouse.GetState().X > 201 && Mouse.GetState().X < 220 && (Mouse.GetState().Y > 160 && Mouse.GetState().Y < 217) || key == 2 || key == 5 || key == 8 || key == 0)
            {
                pos.X = 201;
                if (Mouse.GetState().Y > 160 && Mouse.GetState().Y < 174 || key == 2)//2
                {

                    pos.Y = 161;
                   
                    if (btnClickedF == true || key == 2)
                    {
                        passward[mouseClicked] = NumberClicked(2); //storespassward;
                    }
                 
                }
                else if (Mouse.GetState().Y > 174 && Mouse.GetState().Y < 188 || key == 5)//5
                {
                    pos.Y = 175;
                   
                    if (btnClickedF == true || key == 5)
                    {
                        passward[mouseClicked] = NumberClicked(5); //storespassward;
                    }
                 
                }
                else if (Mouse.GetState().Y > 188 && Mouse.GetState().Y < 202 || key == 8)//8
                {
                    pos.Y = 189;
                   
                    if (btnClickedF == true || key == 8)
                    {
                       
                      
                        passward[mouseClicked] = NumberClicked(8); //storespassward;
                    }
                 
                }
                else if (Mouse.GetState().Y > 202 && Mouse.GetState().Y < 202 + 14 || key == 0)//0
                {
                    pos.Y = 203;
                   
                    if (btnClickedF == true || key == 0)
                    {
                        passward[mouseClicked] = NumberClicked(0); //storespassward;
                    }
                 
                }
               
            }
            // column 3

            else if (Mouse.GetState().X > 220 && Mouse.GetState().X < 240 && (Mouse.GetState().Y > 160 && Mouse.GetState().Y < 217) || key == 3 || key == 6 || key == 9 || key == 10)
            {
               
                pos.X = 220;
                if (Mouse.GetState().Y > 160 && Mouse.GetState().Y < 174 || key == 3)//3
                {
                    pos.Y = 161;
                    if (btnClickedF == true || key == 3)
                    {
                        passward[mouseClicked] = NumberClicked(3); //storespassward;
                       // portKey.Close();
                       
                    }
                 
                }
                else if (Mouse.GetState().Y > 174 && Mouse.GetState().Y < 188 || key == 6)//6
                {
                    pos.Y = 175;
                    if (btnClickedF == true || key == 6)
                    {
                        passward[mouseClicked] = NumberClicked(6); //storespassward;
                    }
                 
                }
                else if (Mouse.GetState().Y > 188 && Mouse.GetState().Y < 202 || key == 9)//9
                {
                    pos.Y = 189;
                    if (btnClickedF == true || key == 9)
                    {
                        passward[mouseClicked] = NumberClicked(9); //storespassward;
                    }
                 
                }
                else if (Mouse.GetState().Y > 202 && Mouse.GetState().Y < 202 + 14 || key == 10)//#
                {
                    pos.Y = 203;
                    if (btnClickedF == true || key == 10)
                    {
                       rstWrong  = NumberClicked(10); //storespassward;
                    }
                 
                }

            }
            //column4
            else if (Mouse.GetState().X > 240 && Mouse.GetState().X < 255 && (Mouse.GetState().Y > 160 && Mouse.GetState().Y < 217) || key == 12 || key == 13 || key == 14 || key == 15)
            {
                pos.X = 240;
                if (Mouse.GetState().Y > 160 && Mouse.GetState().Y < 174 || key ==12 )//A
                {
                    pos.Y = 161;

                    if (btnClickedF == true) { }
                }
                else if (Mouse.GetState().Y > 174 && Mouse.GetState().Y < 188 || key == 13)//B
                {
                    pos.Y = 175;

                    if (btnClickedF == true) { }
                    
                }
                else if (Mouse.GetState().Y > 188 && Mouse.GetState().Y < 202 || key == 14)//C
                {
                    pos.Y = 189;

                    if (btnClickedF == true) { } 
                    
                }
                else if (Mouse.GetState().Y > 202 && Mouse.GetState().Y < 202 + 14 || key == 15)//D
                {
                    pos.Y = 203;

                    if (btnClickedF == true) { }
                  
                   
                }
               
            }
            else
            {
                flag = false;
               
            }

            //out
            if (Mouse.GetState().X > 716 && Mouse.GetState().X < 716 + 69 && Mouse.GetState().Y > 126 && Mouse.GetState().Y < 126 + 70 && mySimObj .currentView == 1)
            {
                outFlg = true;
                inFlg1 = false ;
                inFlg2 = false;
                lighUpDor [0]=false ;
                lighUpDor [1]=false ;
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    flgGoOut = true;
                    inFlg1 = false;
                    inFlg2 = false;
                   
                }
            }
            else
            {
                //
                 outFlg = false;
              
            }
            //in door chat room
            if(effectDoor (550,56,141,52))
            {
                
                    inFlg1 = true;
                    inFlg2 = false;
            
            }
            //in door satellite room
            else if (effectDoor(550, 56, 313, 52))
            {

                    inFlg1 = false;
                    inFlg2 = true;
               
            }
            if (inFlg2 )
            {
                //////////first control//////////////
                if(effectDoor (407,34,250,35)) // left
                {
                    stateCtrl = 1;
                }
                else if (effectDoor(441, 34, 250, 35))//right
                {
                    stateCtrl = 2;
                }
                ///////////////////////end first control////////

                    ////////////second control///////////
                    else if(effectDoor (407,34,288,35) )
                    {
                        stateCtrl = 3;
                    }
                    else if (effectDoor(441, 34, 288, 35))
                    {
                        stateCtrl = 4;
                    }
                else
                {
                   stateCtrl = 5;
                }
            }
           

            if (newMouse.LeftButton == ButtonState.Pressed && oldMouse.LeftButton == ButtonState.Released && flag )
            {
                btnClickedF = true;
                
                //checks how many the mouse has been pressed
                //the pin has 4 digitz the mouse clicked will indicate the index of array for pin
                mouseClicked++;
               // posPin.X = posPin.X + 7;
                if (mouseClicked >= 3)
                {
                    mouseClicked = 3;
                    doneEnterinPin = true;
                }
            }
            else 
            {
                
              
            }
   
          
        }
        //mouse clicked once

        //door inside effet
        public bool effectDoor(int x,int objectWidth,int y, int objHeight)
        {
           
            if (Mouse.GetState().X > x && Mouse.GetState().X < x + objectWidth && Mouse.GetState().Y > y && Mouse.GetState().Y < y + objHeight)
            {
                flg11 = true;
            }
            else {

                flg11 = false;
            }
            return flg11;
        }
        //draw the effect
       
        public void drwEffect(SpriteBatch sp)
        {

            if (flag == true && CurV == 0 )
            {

                //drawing the buttons efects
                if (btnClickedF == true || rstWrong ==10)
                {
                    sp.Draw(btnEfects, new Vector2(pos.X, pos.Y), Color.Red);
                    btnClickedF = false;
                    rstWrong = 0;
                }
                else {
                    sp.Draw(btnEfects, new Vector2(pos.X, pos.Y), Color.White);
                    
                }

                ////
                

            }
            //drae those doors inside
            if(loopDoorBtn ==13 && CurV ==1)
            {
                
                    if(inFlg1 )
                    {
                   
                    //sp.Draw(doorIn [1],new Vector2 (550,141),Color .White );
                    updtLigh = false;

                    outRoom [0] = false ;
                   
                        //chat room
                    lighUpDor[0] = true;
                    lighUpDor[1] = false;
                      
                    if (Mouse.GetState().X > 595 && Mouse.GetState().Y > 145 && Mouse.GetState().Y < 40 + 145 && Mouse.GetState().X < 614 && Mouse.GetState().Y < 366)
                        {
                            lighUpDor[0] = false ;
                            if (Mouse.GetState().X > 595)
                            {
                                inFlg1 = false;
                               
                                updtLigh = true;
                            }
                            else
                            {
                                outRoom[0] = true;
                            }
                        }
                        else{
                            sp.Draw(light[3], new Vector2(378, 10), Color.White);
                            //
                        
                        }
                    }
                    

                    else if(inFlg2 )
                    {
                    updtLigh = false;
                    
                    //sp.Draw(doorIn[2], new Vector2(550, 314), Color.White);
                     outRoom [1]=false ;



                     //satellite room
                     lighUpDor[1] = true;
                     lighUpDor[0] = false;
                    if (Mouse.GetState().X > 595 && Mouse.GetState().Y > 317 && Mouse.GetState().Y < 40 + 317 && Mouse.GetState().X < 614 && Mouse.GetState().Y < 366)
                                {
                                    lighUpDor[1] = false ;
                                    if (Mouse.GetState().X > 595)
                                    {
                                        inFlg2 = false;
                                        updtLigh = true;
                                    }
                                    else
                                    {
                                        outRoom[1] = true;
                                    }
                                 }
                                else
                                {
                                    sp.Draw(light[1], new Vector2(377, 193), Color.White);
                                    
                                }

                    }
                   



                    else
                    {
                        //
                        updtLigh = true;
                    }
               
            }
            
            else
            {

                outRoom[0] = false;
                outRoom [1]=false ;
                lighUpDor[0] = false;
                lighUpDor [1]=false ;
            }

             //draw light if out of room eighter sat or client
            //chat room
            if(outRoom [0])
            {
                
                sp.Draw(light[2], new Vector2(591, 9), Color.White);
                  
            }
                //satellite room
            else if(outRoom [1])
            {
                
                sp.Draw(light[2], new Vector2(591, 9), Color.White);
                 
            }
            if(lighUpDor [0])
            {

                sp.Draw(doorIn[1], new Vector2(550, 141), Color.White);
             
            }
            else if(lighUpDor [1])
            {
                sp.Draw(doorIn[2], new Vector2(550, 314), Color.White);
                //now draw the satellite
                sp.Draw(camer , new Vector2(2, 157), Color.White);//satellite 1
                sp.Draw(satelts[increm_OR_decrem1 ], new Vector2(5, 160), Color.White);//satellite 1
                sp.Draw(satelts[increm_OR_decrem2 ], new Vector2(5, 304), Color.White);//satellite 2
              
                //switch case for drwaing controls in satellite room
                switch (stateCtrl)
                {
                        //control 1
                    case 1: sp.Draw(contrls[1], new Vector2(407, 250), Color.White);
                        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        {
                            sp.Draw(contrls[3], new Vector2(407, 250), Color.White);
                            //change pictures animation
                            increm_OR_decrem1--;
                            if(increm_OR_decrem1 ==-1)
                            {
                            increm_OR_decrem1 = 0;
                            }
                        }
                        break;
                    case 2: sp.Draw(contrls[2], new Vector2(407, 250), Color.White);
                        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        {
                            sp.Draw(contrls[4], new Vector2(407, 250), Color.White);
                            //change pictures animation
                            increm_OR_decrem1++;
                            if (increm_OR_decrem1 == 13)
                            {
                                increm_OR_decrem1 = 12;
                            }
                        }
                        break;
                        //controls 2
                    case 3: sp.Draw(contrls[1], new Vector2(407, 288), Color.White);
                        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        {
                            sp.Draw(contrls[3], new Vector2(407, 288), Color.White);
                            //change pictures animation
                            increm_OR_decrem2--;
                            if (increm_OR_decrem2 == -1)
                            {
                                increm_OR_decrem2 = 0;
                            }
                        
                        }
                        break;
                    case 4: sp.Draw(contrls[2], new Vector2(407, 288), Color.White);
                        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        {
                            sp.Draw(contrls[4], new Vector2(407, 288), Color.White);
                            //change pictures animation
                            increm_OR_decrem2++;
                            if (increm_OR_decrem2 == 13)
                            {
                                increm_OR_decrem2 = 12;
                            }
                        
                        }
                        break;
                    default:
                        break;
                }
            }
            

            //drawing the key entered on the LCD screen
            if (mouseClicked == 0||updateDisplPin [0] && CurV ==0 && loopDoorBtn <10)
            {
                sp.Draw(pinPic[0], new Vector2(187, 142), Color.White);
                updateDisplPin[0] = true;
                if (mouseClicked == 1 || updateDisplPin[1])
                {
                    updateDisplPin[1] = true ;
                    sp.Draw(pinPic[0], new Vector2(195, 142), Color.White);
                    if (updateDisplPin[2] || mouseClicked ==2)
                    {
                         sp.Draw(pinPic[0], new Vector2(203, 142), Color.White);
                            updateDisplPin[2] = true;
                        if (updateDisplPin[3] || mouseClicked ==3)
                        {
                            updateDisplPin[3] = true;
                            sp.Draw(pinPic[0], new Vector2(211, 142), Color.White);
                        }

                    }
                }

                
                
            }
           
        }

    }
}
