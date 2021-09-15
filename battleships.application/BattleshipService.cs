using System;
using System.Threading.Tasks;

namespace battleships.application
{
    public class BattleshipService
    {
        Team?[,] board = new Team?[10, 10];
        bool created = false;

        public Task<bool> CreateBoard()
        {
            if (created) return Task.FromResult(false);

            created = true;
            return Task.FromResult(true);
        }

        public Task<Team?[,]> AddShip(Team team, int x, int y, Direction direction, int length)
        {
            if (!created) throw new ArgumentException("board needs to be created first");
            if (direction == Direction.down)
            {
                for (var i = x; i < x + length; i++)
                {
                    if (board[i, y] != null && board[i, y] != team) throw new ArgumentException("This square is used by the other team");
                    board[i, y] = team;
                }
            }
            else
            { // assume down
                for (var i = y; i < y + length; i++)
                {
                    if (board[x, i] != null && board[x, i] != team) throw new ArgumentException("This square is used by the other team");
                    board[x, i] = team;
                }
            }
            return Task.FromResult(board);
        }

        public Task<string> Attack(Team fromTeam, int x, int y)
        {
            if (!created) throw new ArgumentException("board needs to be created first");
            if (board[x, y] == null) return Task.FromResult("miss");
            if (board[x, y] != fromTeam) return Task.FromResult("hit");

            return Task.FromResult("miss");
        }
    }

    public enum Team
    {
        Team1 = 0, Team2 = 1
    }

    public enum Direction
    {
        down = 0, across = 1
    }
}
