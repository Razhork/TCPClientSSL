/*
 * TCPEchoClient1
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
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPClient
{
    class TCPEchoClient1
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            TcpClient clientSocket = new TcpClient("localhost", 6789);

            Stream unsecureStream = clientSocket.GetStream();
            SslStream sslStream = new SslStream(unsecureStream, false);
            sslStream.AuthenticateAsClient("FakeServerName");

            StreamReader sr = new StreamReader(sslStream);
            StreamWriter sw = new StreamWriter(sslStream);
            sw.AutoFlush = true; // enable automatic flushing

            for (int i = 0; i < 5; i++)
            {   string message = Console.ReadLine();
                sw.WriteLine(message);
                string serverAnswer = sr.ReadLine();
                Console.WriteLine("Server: " + serverAnswer);
            }
            sslStream.Close();
            clientSocket.Close();

        }
    }
}
