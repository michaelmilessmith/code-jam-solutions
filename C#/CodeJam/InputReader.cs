using System.Collections.Generic;

namespace CodeJam
{
    public interface InputReader<T>
    {
        List<T> ReadInput(string file);
    }
}