using System;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using Crystal;


namespace CrystalQuickStart {
  class MainClass {
    public static void Main() {
      // Try with some higher values. Just, if you set this to higher than say 100-200,
      // don't forget to set the verbose variable to false, otherwise Console.Write(..)
      // will slow down things to a halt. 
      int N = 4; // 400000;
      bool verbose = true;

      var toons = new List<Toon>();
      var decisionMakers = new List<IDecisionMaker>();
      var aiConstructor = new QsAiConstructor();
      var scheduler = new Scheduler();
      var tStream = scheduler.ThinkStream as CommandStream;
      var uStream = scheduler.UpdateStream as CommandStream;
      tStream.MaxProcessingTime = 16.0;
      uStream.MaxProcessingTime = 0.01;

      // Toon creation loop
      for(int i = 0; i < N; i++) {
        var toon = new Toon(string.Format("Toon {0}", i));
        var dm = new DecisionMaker(aiConstructor.Create("QuickStartAi"), toon, scheduler) {
          ThinkDelayMin = 0.2f,
          ThinkDelayMax = 0.25f
        };


        toons.Add(toon);
        decisionMakers.Add(dm);
        dm.Start();
      }

      // Simulation loop
      Console.WriteLine("Entering simulation loop");
      float factor = 1.0f / 0.017f;
      var procPerSecMa = new MovingAverage(590);
      Stopwatch w = new Stopwatch();
      long itCount = 0;
      while(true) {
        var sb = new StringBuilder();
        w.Reset();
        w.Start();
        scheduler.Tick();
        itCount++;
        w.Stop();

        if(verbose)
          for(int i = 0; i < N; i++)
            sb.AppendLine(toons[i].Context().ToString());

        procPerSecMa.Enqueue(tStream.ProcessedCount);
        var stats = string.Format("Frame {0}, total time in milliseconds {1:0.00}, processed # {2}, proc/sec {3}",
                                 itCount, w.Elapsed.TotalMilliseconds, 
                                 tStream.ProcessedCount, 
                                 procPerSecMa.Mean * factor );
        sb.AppendLine(stats);
        Console.SetCursorPosition(0, 0);
        Console.Write(sb);

        // Just a crude way to simulate a game engine update loop at ~58.8 fps. (In case you're wondering 
        // why such a strange number, this just so that we have to deal only with ints below)
        if(w.ElapsedMilliseconds >= 17)
          continue;

        int dt = 17 - (int)w.ElapsedMilliseconds;
        Thread.Sleep(dt);
      }

    }
  }
}
