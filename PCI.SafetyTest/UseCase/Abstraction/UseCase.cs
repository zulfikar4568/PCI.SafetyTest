﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCI.SafetyTest.UseCase.Abstraction
{
    public interface IUseCase
    {
        void MainLogic(string delimiter, string sourceFile);
    }
}
