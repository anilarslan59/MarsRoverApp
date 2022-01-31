using MarsRoverApp.Entity.Models;
using MarsRoverProblemSolution.Repository.Interfaces;

namespace MarsRoverProblemSolution.Repository.Process
{
    public class ExecuteAction : IProcess
    {
        /// <summary>
        /// execute
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public Coordinate Execute(ICommand command, Coordinate coordinate)
        {
            return command.Execute(coordinate);
        }
    }
}