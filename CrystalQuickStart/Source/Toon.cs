using Crystal;

namespace CrystalQuickStart {

  public class Toon : IContextProvider {
    // All information related to our toon is stored here. 
    // This need not necessarily be the case in your implementation. 
    // A rule of thumb is for the context to be given access only to
    // information that is required by the AI to make decisions. 
    // More on that later. 
    FooContext _context;

    // IContextProvider implementation
    public IContext Context() {
      return _context;
    }

    public Toon(string name) {
      _context = new FooContext();
      _context.Name = name;
    }
  }

}
