using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace checkForDrops {
  class Program {
    static void Main(string[] args) {

      Console.WriteLine("checkForDrops has been started successfully. ");
      Console.WriteLine("..................................................");
      bool isFirstCleanPing = true;
      while (true) {
        try {
          Ping pingSender =new Ping();
          PingReply reply = pingSender.Send("google.com", 120);
          if(reply.RoundtripTime < 100) {
            if (isFirstCleanPing) {
              Console.WriteLine("[{0}] Ping is OK.", DateTime.Now.ToString());
              isFirstCleanPing = false;
            }
          }
          else if(reply.RoundtripTime > 100) {  
            Console.WriteLine("[{0}] Ping has been detected as greater than 100", DateTime.Now.ToString());
            isFirstCleanPing = false;
          }       
          Thread.Sleep(1000);
        }
        catch(Exception ex) {
          Console.WriteLine("[{0}] LOST CONNECTION.", DateTime.Now.ToString());
          if (!isFirstCleanPing) {
            isFirstCleanPing = true;
          }
          Thread.Sleep(1000);
        }
      }

    }

  }
}
