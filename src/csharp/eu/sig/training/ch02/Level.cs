using System.Collections.Generic;

namespace eu.sig.training.ch02
{
    public class Level
    {
        private readonly IList<LevelObserver> observers;
        private bool inProgress;

        private Level( IList<LevelObserver> observers )
        {
            this.observers = observers;
        }

        // tag::start[]
        public void Start( )
        {
            if ( inProgress )
            {
                return;
            }
            inProgress = true;
            // Update observers if player died:
            if ( !IsAnyPlayerAlive( ) )
            {
                foreach ( LevelObserver o in observers )
                {
                    o.LevelLost( );
                }
            }
            // Update observers if all pellets eaten:
            if ( RemainingPellets( ) == 0 )
            {
                foreach ( LevelObserver o in observers )
                {
                    o.LevelWon( );
                }
            }
        }

        // end::start[]

        private bool IsAnyPlayerAlive( )
        {
            return false;
        }

        private int RemainingPellets( )
        {
            return 0;
        }

        // tag::updateObservers[]
        private void UpdateObservers( )
        {
            // Update observers if player died:
            if ( !IsAnyPlayerAlive( ) )
            {
                foreach ( LevelObserver o in observers )
                {
                    o.LevelLost( );
                }
            }
            // Update observers if all pellets eaten:
            if ( RemainingPellets( ) == 0 )
            {
                foreach ( LevelObserver o in observers )
                {
                    o.LevelWon( );
                }
            }
        }

        // end::updateObservers[]

        // tag::updateObserversPelletsEaten[]
        private void UpdateObserversPelletsEaten( )
        {
            if ( RemainingPellets( ) == 0 )
            {
                foreach ( LevelObserver o in observers )
                {
                    o.LevelWon( );
                }
            }
        }

        // tag::updateObserversPlayerDied[]
        private void UpdateObserversPlayerDied( )
        {
            if ( !IsAnyPlayerAlive( ) )
            {
                foreach ( LevelObserver o in observers )
                {
                    o.LevelLost( );
                }
            }
        }

        // end::updateObserversPlayerDied[]
        // end::updateObserversPelletsEaten[]
    }

    internal class LevelObserver
    {
        public void LevelLost( )
        {
        }

        public void LevelWon( )
        {
        }
    }
}