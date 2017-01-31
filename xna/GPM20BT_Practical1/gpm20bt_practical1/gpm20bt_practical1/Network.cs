/*
 Name & Surname: Emmanuel Mthimunye
 Date: 2013 Sept 5
 Implementing Artificial Intelligent level 1,2,3 and 4 in Game design
 * Network programming
 * Sychronization
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GPM20BT_Practical1
{
    class Network
    {
        public bool connected;
        public string message;
        public string serverName;
        public UdpClient server;
        IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
        byte[] data;
        public Network()
        {
            connected = false;
            message = "";
            serverName = "127.0.0.1";
            server = new UdpClient(serverName, 9050);
            sender = new IPEndPoint(IPAddress.Any, 0);
        }
        public void Initialise(string ServerName)
        {
            if (!connected)
            {
                connected = true;
                try
                {

                    server.Client.Blocking = false;
                    data = Encoding.ASCII.GetBytes("Hello, are you there?");
                    server.Send(data, data.Length);

                    data = new byte[1024];
                    data = server.Receive(ref sender);

                    message = "Message received from " + sender.ToString() + ": ";
                    message += Encoding.ASCII.GetString(data, 0, data.Length);
                    //output.Add(message);

                }
                catch (Exception)
                {
                    connected = false;
                }
            }
        }
        public void sendData(string dataType, int unit, Vector2 pos, string Message, bool findpath)
        {
            if (connected)
            {

                if (dataType == "&u")
                {
                    string mas;
                    if (findpath == true)
                    {
                        mas = "1";
                    }
                    else
                    {
                        mas = "0";
                    }
                    byte[] data = Encoding.ASCII.GetBytes(dataType + "," + unit.ToString() +
                        "," + pos.X.ToString() + "," + pos.Y.ToString() + "," + mas);
                    server.Send(data, data.Length);
                }
                else if (dataType == "&m")
                {
                    byte[] data = Encoding.ASCII.GetBytes(dataType + "," + Message);
                    server.Send(data, data.Length);
                }
                else if (dataType == "&s")
                {
                    byte[] data = Encoding.ASCII.GetBytes(dataType + "," + unit.ToString() + "," + Message);
                    server.Send(data, data.Length);
                }
                else if (dataType == "&a")
                {
                    byte[] data = Encoding.ASCII.GetBytes(dataType + "," + unit.ToString() + "," + Message);
                    server.Send(data, data.Length);
                }


            }
        }
        public void receiveMassage(List<Units> unit)
        {
            try
            {
                data = new byte[1024];
                data = server.Receive(ref sender);
                String recDt = Encoding.ASCII.GetString(data, 0, data.Length);
                message = "Message received from " + sender.ToString() + ": ";

                String[] parts = recDt.Split(',');
                if (parts[0] == "&u")
                {
                    message = recDt;
                    unit[Convert.ToInt32(parts[1])].position.X = (float)Convert.ToDouble(parts[2]);
                    unit[Convert.ToInt32(parts[1])].position.Y = (float)Convert.ToDouble(parts[3]);
                    //if (parts[4] == "0")
                    //{
                    //    unit[Convert.ToInt32(parts[1])].pathFound = false;
                    //}
                    //else 
                    //{
                    //    unit[Convert.ToInt32(parts[1])].pathFound = true;
                    //}
                }
                else if (parts[0] == "&m")
                {
                    message = parts[1];
                }
                else if (parts[0] == "&a")
                {
                    unit[Convert.ToInt32(parts[1])].angle = (float)Convert.ToDouble(parts[2]);
                }
                else if (parts[0] == "&s")
                {
                    message = recDt;

                    for (int y = 0; y < unit.Count; y++)
                    {
                        unit[y].selected = false;
                    }
                    unit[Convert.ToInt32(parts[1])].selected = true;
                }
            }
            catch (Exception)
            {
            }
        }
        public void disconect()
        {
            if (connected == true)
            {
                connected = false;
                server.Close();
            }
        }
    }
}
