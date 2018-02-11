﻿using System.Collections.Generic;
using MazeGenerator.ObjectModel;
using MazeGenerator.ObjectModel.Maze;
using MazeGenerator.ObjectModel.Utils;

namespace MazeGenerator.Generator
{
    public class DepthFirstMazeGenerator : IMazeGenerator
    {
        private readonly IRandom random;
        private readonly IntactWallHelper intactWallHelper;
        private readonly WallKnocker wallKnocker;

        public DepthFirstMazeGenerator(IRandom random)
        {
            this.random = random;

            this.intactWallHelper = new IntactWallHelper();
            this.wallKnocker = new WallKnocker();
        }

        /* Depth-First Search algorithm:
           1. create a CellStack (LIFO) to hold a list of cell locations 
           2. set TotalCells = number of cells in grid 
           3. choose a cell at random and call it CurrentCell 
           4. set VisitedCells = 1 
           5. while VisitedCells < TotalCells 
           6.    find all neighbors of CurrentCell with all walls intact  
           7.    if one or more found 
           8.         choose one at random 
           9.         knock down the wall between it and CurrentCell 
           10.        push CurrentCell location on the CellStack 
           11.        make the new cell CurrentCell 
           12.        add 1 to VisitedCells 
           13.		else 
           14.        pop the most recent cell entry off the CellStack 
           15.        make it CurrentCell 
           16.	   endIf 
           17. endWhile 
         */
        public Maze Generate(int size)
        {
            Maze maze = new Maze(size);
            Stack<MazeCell> cells = new Stack<MazeCell>();

            MazeCell currentCell = maze.Cells[this.random.Next(size)][this.random.Next(size)];

            int totalCells = size * size;
            int visitedCells = 1;

            while (visitedCells < totalCells)
            {
                List<MazeCell> neighbors = this.intactWallHelper.FindNeighborsWithAllWallIntact(currentCell, maze);

                if (neighbors.Count > 0)
                {
                    MazeCell chosenNeighbor = neighbors[this.random.Next(neighbors.Count)];

                    this.wallKnocker.KnockDownWallBetween(currentCell, chosenNeighbor);

                    visitedCells++;
                    cells.Push(currentCell);
                    currentCell = chosenNeighbor;
                }
                else
                {
                    currentCell = cells.Pop();
                }
            }

            return maze;
        }
    }
}