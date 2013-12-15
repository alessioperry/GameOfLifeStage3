using System.Collections.Generic;
using NUnit.Framework;
using QuickGraph;

namespace GameOfLifeStage3.Business.Test
{
    [TestFixture]
    public class JesusChristTest
    {
        private Cell upperLeft;
        private Cell upperCenter;
        private Cell upperRight;
        private Cell middleLeft;
        private Cell middleCenter;
        private Cell middleRight;
        private Cell lowerLeft;
        private Cell lowerCenter;
        private Cell lowerRight;

        private MyEdge upperLeftupperCenter;
        private MyEdge upperCenterupperRight;
        private MyEdge upperRightmiddleRight;
        private MyEdge middleRightlowerRight;
        private MyEdge lowerRightlowerCenter;
        private MyEdge lowerCenterlowerLeft;
        private MyEdge lowerLeftmiddleLeft;
        private MyEdge middleLeftupperLeft;
        private MyEdge upperLeftmiddleCenter;
        private MyEdge upperCenterMiddleCenter;
        private MyEdge upperRightMiddleCenter;
        private MyEdge middleRightMiddleCenter;
        private MyEdge middleLeftMiddleCenter;
        private MyEdge lowerLeftMiddleCenter;
        private MyEdge lowerCenterMiddleCenter;
        private MyEdge lowerRightMiddleCenter;


        private Jesus jesus;
        private UndirectedGraph<Cell, MyEdge> myGraph;

        [SetUp] 
        public void SetUp()
        {
            upperCenter = new Cell();
            upperLeft = new Cell();
            upperRight = new Cell();
            middleLeft = new Cell();
            middleCenter = new Cell();
            middleRight = new Cell();
            lowerLeft = new Cell();
            lowerCenter = new Cell();
            lowerRight = new Cell();

            upperLeftupperCenter = new MyEdge(upperLeft, upperCenter);
            upperCenterupperRight = new MyEdge(upperCenter, upperRight);
            upperRightmiddleRight = new MyEdge(upperCenter, middleRight);
            middleRightlowerRight = new MyEdge(middleRight, middleCenter);
            lowerRightlowerCenter = new MyEdge(lowerRight, lowerCenter);
            lowerCenterlowerLeft = new MyEdge(lowerCenter, lowerLeft);
            lowerLeftmiddleLeft = new MyEdge(lowerLeft, middleLeft);
            middleLeftupperLeft = new MyEdge(middleLeft, upperLeft);
            upperLeftmiddleCenter = new MyEdge(upperLeft, middleCenter);
            upperCenterMiddleCenter = new MyEdge(upperCenter, middleCenter);
            upperRightMiddleCenter = new MyEdge(upperRight, middleCenter);
            middleRightMiddleCenter = new MyEdge(middleRight, middleCenter);
            middleLeftMiddleCenter = new MyEdge(middleLeft, middleCenter);
            lowerLeftMiddleCenter = new MyEdge(lowerLeft, middleCenter);
            lowerCenterMiddleCenter = new MyEdge(lowerCenter, middleCenter);
            lowerRightMiddleCenter = new MyEdge(lowerLeft, middleCenter);


            myGraph.AddVertex(upperCenter);

            jesus = new Jesus(upperCenter);
        }

        [Test]
        public void IfYouHaveOnlyOneCellAliveItDies()
        {
            jesus.Evolve();

            Assert.False(upperCenter.IsAlive());
        }

        [Test]
        public void IfYouHaveTwoCellsTheyDiesTogheter()
        {
            upperCenter.AddNeighbour(upperLeft);

            jesus.Evolve();

            Assert.False(upperCenter.IsAlive());
        }

        [Test]
        public void AnyLiveCellWithTwoOrThreeLiveNeighboursLivesOnToTheNextGeneration()
        {
            upperCenter.AddNeighbour(upperLeft);
            upperCenter.AddNeighbour(upperRight);
            upperCenter.AddNeighbour(middleLeft);
            
            jesus.Evolve();

            Assert.True(upperCenter.IsAlive());
        }

    }

    internal enum Status
    {
        Alive,Dead
    }

    public class Cell
    {
        private Status status;
        private List<Cell> neighbours;

        public Cell()
        {
            status = Status.Alive;
        }

        public void AddNeighbour(Cell cell)
        {
            if (neighbours != null)
            neighbours.Add(cell);

            else
            neighbours = new List<Cell> { cell };
        }

        public int NeighbourCount()
        {
            return neighbours != null ? neighbours.Count : 0;
        }

        public void Killme()
        {
            status = Status.Dead;
        }

        public void Eraise()
        {
            status = Status.Alive;
        }

        public bool IsAlive()
        {
            return status == Status.Alive;
        }
    }

    internal class Jesus
    {
        private readonly Cell cell;

        public Jesus(Cell cell)
        {
            this.cell = cell;
        }

        public void Evolve()
        {
           if(cell.NeighbourCount() < 2)
            cell.Killme();
        }
    }

    public class MyEdge : IEdge<Cell>
    {
        public MyEdge(Cell source, Cell target)
        {
            Source = source;
            Target = target;
        }

        public Cell Source { get; private set; }

        public Cell Target { get; private set; }
    }
}