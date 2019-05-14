using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
    public interface ISQLite
    {
       string GetDatabasePath(string filename);
    }
}

