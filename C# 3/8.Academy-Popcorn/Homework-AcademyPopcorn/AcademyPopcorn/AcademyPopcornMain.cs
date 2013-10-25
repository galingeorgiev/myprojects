using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));
                engine.AddObject(currBlock);
            }

            //Exploding blocks
            //When collide with the ball effect is like a wave. I cannot find mistake. :(
            /*for (int i = startCol; i < endCol; i++)
            {
                ExplodingBlock currExplodingBlock = new ExplodingBlock(new MatrixCoords(startRow + 1, i));
                engine.AddObject(currExplodingBlock);
            }*/

            for (int i = startCol; i < endCol; i++)
            {
                GiftBlock currGiftBlock = new GiftBlock(new MatrixCoords(startRow + 2, i));
                engine.AddObject(currGiftBlock);
            }

            //Test the UnpassableBlock and the UnstoppableBall by adding them to the engine in AcademyPopcornMain.cs file
            for (int i = startCol; i < endCol / 2; i++)
            {
                UnpassableBlock currUnpassableBlock = new UnpassableBlock(new MatrixCoords(startRow + 3, i));
                engine.AddObject(currUnpassableBlock);
            }

            //Defaul ball
            //Uncomment this and comment Unstoppable Ball to switch between them
            //Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0),
            //    new MatrixCoords(-1, 1));
            //engine.AddObject(theBall);

            //Test the UnpassableBlock and the UnstoppableBall by adding them to the engine in AcademyPopcornMain.cs file
            //Unstoppable Ball
            UnstoppableBall theBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));
            engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);
            engine.AddObject(theRacket);

            /* The AcademyPopcorn class contains an IndestructibleBlock class.
             * Use it to create side and ceiling walls to the game.
             * You can ONLY edit the AcademyPopcornMain.cs file. */
            //Top
            for (int i = 0; i < WorldCols; i++)
            {
                IndestructibleBlock borders = new IndestructibleBlock(new MatrixCoords(0,i));
                engine.AddObject(borders);
            }

            //Bottom is theRacket
            
            //Left
            for (int i = 0; i < WorldRows; i++)
            {
                IndestructibleBlock borders = new IndestructibleBlock(new MatrixCoords(i, 0));
                engine.AddObject(borders);
            }
            //Right
            for (int i = 0; i < WorldRows; i++)
            {
                IndestructibleBlock borders = new IndestructibleBlock(new MatrixCoords(i, WorldCols - 1));
                engine.AddObject(borders);
            }

            /*Then test the TrailObject by adding an instance of it in the engine through the AcademyPopcornMain.cs file.*/
            TrailObject trailObject =
                new TrailObject(new MatrixCoords(WorldRows / 4, WorldCols / 4), new char[,] { {'@'} }, 20);
            //Life of trail object is lifetime * sleeptime
            engine.AddObject(trailObject);

            /*Test the MeteoriteBall by replacing the normal ball in the AcademyPopcornMain.cs file.*/
            //Uncomment this to see Meteorit ball with trail. Length of treil by defaul is tree.
            //MeteoriteBall meteoriteBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));
            //engine.AddObject(meteoriteBall);

            //Uncomment this and will see how fall down one 'gift' when you start game
            //Gift someGift = new Gift(new MatrixCoords(WorldRows / 2, WorldCols / 2), new char[,] { { 'G' } });
            //engine.AddObject(someGift);
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}