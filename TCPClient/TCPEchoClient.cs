﻿/*
 * TCPEchoClient
 *
 * Author Michael Claudius, ZIBAT Computer Science
 * Version 1.0. 2014.02.12
 * Copyright 2014 by Michael Claudius
 * Revised 2014.09.10
 * All rights reserved
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPClient
{
    class TCPEchoClient
    {
        static void MainX(string[] args)
        {
            Console.ReadLine();
            TcpClient clientSocket = new TcpClient("localhost", 6789);

            Stream ns = clientSocket.GetStream();  //provides a NetworkStream
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; // enable automatic flushing

            string message = Console.ReadLine();
            sw.WriteLine(message);
            string serverAnswer = sr.ReadLine();
            Console.WriteLine("Server: " + serverAnswer);

            ns.Close();
     
        
            clientSocket.Close();

        }
    }
}
