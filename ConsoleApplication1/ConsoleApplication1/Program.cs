using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length !=2)
            args=new String[] {"127.0.0.1","1234"};
            TcpListener tcpListener = new TcpListener(IPAddress.Parse("172.40.1.46"), int.Parse(args[0]));//ip为服务器IP地址，port为监听的端口
            tcpListener.Start();//开启监听  
            byte[] buf = new byte[1024];
            for( ; ;)
            {
                    TcpClient clinet = tcpListener.AcceptTcpClient();
                clinet.SendTimeout =1000;
                clinet.ReceiveTimeout=1000;
                try
                {
                    int rd= clinet.GetStream().Read(buf,0,buf.Length);
                    Console.WriteLine(System.Text.Encoding.GetEncoding("GBK").GetString(buf,0,rd));
                }
                catch {}
                try
                {
                    byte[] hi =System.Text.Encoding.GetEncoding("GBK").GetBytes("阮凌志 10150900232 FROM Client"+ DateTime.Now.ToString("yyyy-MM-dd HH"));
                    clinet.GetStream().Write(hi, 0,hi.Length);
                }
                catch{}
               /* try
                {
                    int rd =clinet.GetStream().Read(buf,0,buf.Length);
                    Console.ReadLine(System.Text.Encoding.GetEncoding("GBK").GetString(buf,0,rd));
                }
                 catch{}
                clinet.Close();
                Console.WriteLine("press any key");
                Console.ReadKey();
            }
        }
    }
}
