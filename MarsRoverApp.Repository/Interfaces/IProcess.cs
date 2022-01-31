using MarsRoverApp.Entity.Models;

namespace MarsRoverProblemSolution.Repository.Interfaces
{
    public interface IProcess
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        Coordinate Execute(ICommand command, Coordinate coordinate);
    }
}