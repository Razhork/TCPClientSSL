/*
 * TCPEchoClient2
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
    class TCPEchoClient2
    {
        static void Main1(string[] args)
        {

            TcpClient clientSocket = new TcpClient("localhost", 6789);

            Stream ns = clientSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; // enable automatic flushing

            for (int i = 0; i < 100; i++)
            {
                string message = "Michael " + i;
                sw.WriteLine(message);
                string serverAnswer = sr.ReadLine();
                Console.WriteLine("Server: " + serverAnswer);
            }
            Console.WriteLine("Ckient finished");
           // Console.ReadLine();
            ns.Close();
            clientSocket.Close();

        }
    }
}
