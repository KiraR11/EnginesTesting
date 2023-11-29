using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnginesTesting
{
    public abstract class EngineTest
    {
        public EngineTest(Engine engine)
        {
            Engine = engine;
            Engine.CoolDown();
            Run();
        }
        protected Engine Engine { get;}
        protected abstract void Run();
    }
}
