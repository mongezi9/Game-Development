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
    class Simulation
    {
        public int loopDoor;
        public bool hasOpen;
        public bool PassCorrect;
        public int currentView;
    
        public string OrigPasscode;
        public string enterPasscode;

        public bool flgGoOut;
        public bool notFullyClosed;
        public bool mOutArea;
        public bool ledR;

        //
        public bool outflg;
        public Texture2D[] ledd;
        public Texture2D outSide;
        public bool resetWrongInput;
        public Texture2D initImg;
        public bool updtLight;
        public Texture2D light;
      

        public Simulation(int v,Texture2D outS, Texture2D[] ld)
        {

            currentView = v;
            notFullyClosed = false ;
          
            outSide = outS;
            ledd = ld;
            OrigPasscode = "0";
            enterPasscode = "0";
           
            
        }
        public void passward(SpriteBatch sp, Texture2D[] ld)
        { 
         
       
           if(OrigPasscode .ToString () == enterPasscode .ToString () )
           {
               DoorOpen();
               if (!PassCorrect )
               {
               
               sp.Draw(ld[1], new Vector2(260, 158), Color.White);
               hasOpen = true;
               }
              
               
           }
           else if (hasOpen == true || OrigPasscode.ToString() != enterPasscode.ToString())
           {
               
               
               if(notFullyClosed )
               {
                   DoorClose();
               }
               if (ledR)
               {
                   sp.Draw(ld[0], new Vector2(260, 174), Color.White);
               }
               else
               {
                   sp.Draw(ld[2], new Vector2(260, 174), Color.White  );

               }
               
           }
        
        }


        public void DoorOpen()
        {
            loopDoor++;
            
            if (loopDoor == 8)
            {
                loopDoor = 8;
                
                currentView=1;
                PassCorrect = true;

                
            }
        }
        public void DoorClose()
        {
            loopDoor--;
            System.Threading.Thread.Sleep(100);
            if (loopDoor == -1 || loopDoor == 8)
            {
                loopDoor = 0;
                
                hasOpen = false;
                PassCorrect = false;
                currentView = 0;
                notFullyClosed = false;
                ledR = false;
            }
            
        }
        public void InsideArea()
        {
            loopDoor++;
            System.Threading.Thread.Sleep(50);


            if (loopDoor == 14)
            {
                loopDoor = 13;
                PassCorrect  = false ;
            }
        }
        public void goOutArea()
        {
            if (loopDoor <= 14 && loopDoor >=7)
            {
                loopDoor--;
                System.Threading.Thread.Sleep(70);
                if (loopDoor == 7)
                {
                    loopDoor = 7;
                    currentView = 0;
                    flgGoOut = false;
                    //the passward must be reset here, to show that the user has logged out
                    if(PassCorrect )
                    {
                        PassCorrect = false;
                       
                    }
                  
                    notFullyClosed = true;
                    mOutArea = true;
                    
                }

            }
        
        }
        public void drawAnimation(SpriteBatch sp,Texture2D[] backImg)
        {
            //sp.Begin();
            //displaying the background images 2D enviro
            
          
            if (currentView == 0)
            {
               
                sp.Draw(backImg[loopDoor], new Vector2(0, 0), Color.White);
                System.Threading.Thread.Sleep(50);
               
                    passward(sp, ledd);//checks if the passward is correct
                    //myPasObj.ComparePasscode(sp,ledd );
                
            }
            else if (currentView == 1)
            {
              // sp.Draw(backImg[loopDoor], new Vector2(0, 0), Color.White);

                ////////////////////////////////if mouse is at the door/////////////////////
               if (flgGoOut == false )
               {
                   if (mOutArea == false )
                   {
                   InsideArea ();
                   }
                   sp.Draw(backImg [loopDoor], new Vector2(0, 0), Color.White);
                   //if click it goes outside the area
                   
                    if (updtLight  || outflg )
                   {
                       sp.Draw(light, new Vector2(591, 9), Color.White);
                   }
                    if (outflg == true)
                    {
                        //to go out

                        sp.Draw(outSide, new Vector2(716, 126), Color.White);
                    }

               }
                   /////////////////////////////end mouse check///////////////////////
               else
               {
                   goOutArea();
                   
                   sp.Draw(backImg[loopDoor], new Vector2(0, 0), Color.White);
                  

               }
            }
            
        }
    }
}
