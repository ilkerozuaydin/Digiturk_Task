using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging
{
    public interface ILogger
    {
        void Info(InfoLogDetail logDetail);

        void Error(ErrorLogDetail logDetail);
    }
}
