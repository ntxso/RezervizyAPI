using System;
using System.Collections.Generic;
using System.Text;

namespace CoreNT.Abstract
{
    public interface IRunnableLog : IRunnubale, ILog
    {

    }
    public interface IRunnubale
    {
        void Run();
        void Stop();
    }
    public interface ILog
    {
        string Log { get; }
    }
}
