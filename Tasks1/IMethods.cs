using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks1
{
    public interface IMethods
    {
        bool CheckConvergenceMethod(double firstNorm);
        int FindInterationCount();
        double FindFirstNormApprox();
    }
}
