using System.Diagnostics;

namespace eu.sig.training.ch02.v1
{
    public class Board
    {
        public int Height { get; set; }

        public int Width { get; set; }

        public Board( Square[ , ] grid )
        {
        }
    }

    public class BoardFactory
    {
        // tag::createBoard[]
        public Board CreateBoard( Square[ , ] grid )
        {
            Debug.Assert( grid != null );

            Board board = new Board( grid );

            int width = board.Width;
            int height = board.Height;
            for ( int x = 0; x < width; x++ )
            {
                for ( int y = 0; y < height; y++ )
                {
                    Square square = grid[ x, y ];
                    foreach ( Direction dir in Direction.Values )
                    {
                        SetLink( square, dir, x, y, width, height, grid );
                    }
                }
            }

            return board;
        }

        // end::createBoard[]

        // tag::setLink[]
        private void SetLink( Square square, Direction dir, int x, int y,
            int width, int height, Square[ , ] grid )
        {
            int dirX = ( width + x + dir.DeltaX ) % width;
            int dirY = ( height + y + dir.DeltaY ) % height;
            Square neighbour = grid[ dirX, dirY ];
            square.Link( neighbour, dir );
        }

        // end::setLink[]
    }

    public class Direction
    {
        public static Direction[ ] Values { get; set; }

        public int DeltaX { get; set; }
        public int DeltaY { get; set; }
    }

    public class Square
    {
        public void Link( Square neighbour, Direction dir )
        {
        }
    }
}