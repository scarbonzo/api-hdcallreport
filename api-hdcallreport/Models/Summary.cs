using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Summary
{
    public int Year { get; set; }
    public int Month { get; set; }
    public int LSNJ { get; set; }
    public int CJLS { get; set; }
    public int ENLS { get; set; }
    public int SJLS { get; set; }
    public int LSNWJ { get; set; }
    public int NNJLS { get; set; }
    public int External { get; set; }
    public int TotalCalls { get; set; }

    public void Calculate()
    {
        TotalCalls = LSNJ + NNJLS + SJLS + ENLS + CJLS + LSNWJ + External;
    }
}
