using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PingPong.Hubs
{
    [HubName("pingPong")]
    public class PingPong : Hub
    {
        public void Update(int bx, int by, int px, int py, int psx, int psy, int dx, int dy, int scoreLeft, int scoreRight)
        {
            bx += dx;
            by += dy;

            if (by <= 0 || by + 15 >= 400)
            {
                dy = -dy;
            }
            if (bx <= 0 || bx + 15 >= 700)
            {
                dx = -dx;
            }

            if (bx <= px + 10 &&
               by <= py + 70 &&
               by + 15 >= py)
            {
                dx = -dx;
            }
            else if (bx >= psx - 10 &&
               by <= psy + 70 &&
               by + 15 >= psy)
            {
                dx = -dx;
            }

            Clients.All.updateBoard(bx, by, px, py, psx, psy, dx, dy, scoreLeft, scoreRight);
        }

        public void Reset()
        {
            Clients.All.resetBoard();
        }

        public void StartGame()
        {
            Clients.All.startGame();
        }
    }
}