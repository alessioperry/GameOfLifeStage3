using System.Collections.Generic;
using NUnit.Framework;

namespace GameOfLifeStage3.Business.Test
{
    [TestFixture]
    public class JesusChristTest
    {
        private Cell second;
        private Cell first;
        private Jesus jesus;

        [SetUp]
        public void SetUp()
        {
            first = new Cell();
            second = new Cell();

            jesus = new Jesus(first);
        }

        [Test]
        public void IfYouHaveOnlyOneCellAliveItDies()
        {
            jesus.Evolve();

            Assert.False(first.IsAlive());
        }

        [Test]
        public void IfYouHaveTwoCellsTheyDiesTogheter()
        {
            first.AddNeighbour(second);

            jesus.Evolve();

            Assert.False(first.IsAlive());
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
}