using System;
using System.Threading.Tasks;

namespace battleships.application
{
    public class BattleshipService
    {
        public static bool?[,] board = new bool?[10,10];
        public static bool created = false;

        public Task<bool> CreateBoard(){
            if(created) Task.FromResult(false);

            created = true;
            return Task.FromResult(true);
        }

        public Task<bool> AddShip(Team team, int x, int y, Direction direction, int length){
            if(created) Task.FromResult(false);

            created = true;
            return Task.FromResult(true);
        }

        public Task<bool> Attack(Team fromTeam, int x, int y){
            if(created) Task.FromResult(false);

            created = true;
            return Task.FromResult(true);
        }
    }

    public enum Team{
        Team1=0, Team2=1
    }

    public enum Direction{
        down=0, across=1
    }
}
