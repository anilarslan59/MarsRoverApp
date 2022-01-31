using MarsRoverApp.Entity.Models;

namespace MarsRoverProblemSolution.Repository.Interfaces
{
    public interface ICommand
    {
        /// <summary>
        /// execute
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        public Coordinate Execute(Coordinate coordinate);
    }
}