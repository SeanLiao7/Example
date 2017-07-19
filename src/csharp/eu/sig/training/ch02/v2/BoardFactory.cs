using System.Diagnostics;

namespace eu.sig.training.ch02.v2
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
            return new BoardCreator( grid ).Create( );
        }

        // end::createBoard[]
    }

    public class Direction
    {
        public static Direction[ ] Values { get; set; }

        public int DeltaX { get; set; }
        public int DeltaY { get; set; }
    }

    // end::BoardCreator[]
    public class Square
    {
        public void Link( Square neighbour, Direction dir )
        {
        }
    }

    // tag::BoardCreator[]
    internal class BoardCreator
    {
        private Board board;
        private Square[ , ] grid;
        private int height;
        private int width;

        internal BoardCreator( Square[ , ] grid )
        {
            Debug.Assert( grid != null );
            this.grid = grid;
            this.board = new Board( grid );
            this.width = board.Width;
            this.height = board.Height;
        }

        internal Board Create( )
        {
            for ( int x = 0; x < width; x++ )
            {
                for ( int y = 0; y < height; y++ )
                {
                    Square square = grid[ x, y ];
                    foreach ( Direction dir in Direction.Values )
                    {
                        SetLink( square, dir, x, y );
                    }
                }
            }
            return this.board;
        }

        private void SetLink( Square square, Direction dir, int x, int y )
        {
            int dirX = ( width + x + dir.DeltaX ) % width;
            int dirY = ( height + y + dir.DeltaY ) % height;
            Square neighbour = grid[ dirX, dirY ];
            square.Link( neighbour, dir );
        }
    }
}