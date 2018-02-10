﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenerator.ObjectModel.Maze
{
    public interface IMazePainter
    {
        byte[] Paint(Maze maze);
    }
}
