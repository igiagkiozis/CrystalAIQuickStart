using Crystal;


namespace CrystalQuickStart {
  public class FooContext : IContext {
    public string Name;

    float _hunger;
    public float Hunger {
      get { return _hunger; }
      set { _hunger = value.Clamp(0f, 100f); }
    }
    float _thirst;
    public float Thirst {
      get { return _thirst; }
      set { _thirst = value.Clamp(0f, 100f); }
    }
    float _bladder;
    public float Bladder {
      get { return _bladder; }
      set { _bladder = value.Clamp(0f, 100f); }
    }

    string _lastAction;
    public void Report(string what) {
      _lastAction = what;
    }

    public FooContext() {
      // Just assign some random starting values to mix things up.
      _hunger = Pcg.Default.NextFloat(0f, 100f);
      _thirst = Pcg.Default.NextFloat(0f, 100f);
      _bladder = Pcg.Default.NextFloat(0f, 100f);
    }

    public override string ToString() {
      return string.Format("[{0}: Hunger={1,7:00.00%}, Thirst={2,7:00.00%}, Bladder={3,7:00.00%}] Last Action: {4,6}",
                           Name, Hunger/100f, Thirst/100f, Bladder/100f, _lastAction);
    }

  }
}
