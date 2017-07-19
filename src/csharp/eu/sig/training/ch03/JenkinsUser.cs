using System;
using System.IO;

namespace eu.sig.training.ch03
{
    public class JenkinsUser
    {
        // tag::getOrCreate[]
        /**
        * Retrieve a user by its ID, and create a new one if requested.
        * @return
        *      An existing or created user. May be {@code null} if a user does not exis
        *      and {@code create} is false.
        */
        private static Lock byName = new Lock( );

        private static Lock byNameLock = new Lock( );

        public enum Level
        {
            FINE,
            WARNING
        }

        public static Strategy idStrategy( )
        {
            return new Strategy( );
        }

        private static FileInfo getConfigFileFor( string id )
        {
            return null;
        }

        private static FileInfo[ ] getLegacyConfigFilesFor( string id )
        {
            return null;
        }

        private static User getOrCreate( string id, string fullName, bool create )
        {
            string idkey = idStrategy( ).keyFor( id );

            byNameLock.readLock( ).doLock( );
            User u;
            try
            {
                u = byName.get( idkey );
            }
            finally
            {
                byNameLock.readLock( ).unlock( );
            }
            FileInfo configFile = getConfigFileFor( id );
            if ( !configFile.Exists && !Directory.Exists( configFile.Directory.FullName ) )
            {
                // check for legacy users and migrate if safe to do so.
                FileInfo[ ] legacy = getLegacyConfigFilesFor( id );
                if ( legacy != null && legacy.Length > 0 )
                {
                    foreach ( FileInfo legacyUserDir in legacy )
                    {
                        XmlFile legacyXml = new XmlFile( XmlFile.XSTREAM,
                                                new FileInfo( Path.Combine(
                                                legacyUserDir.FullName, "config.xml" ) ) );
                        try
                        {
                            object o = legacyXml.read( );
                            if ( o is User )
                            {
                                if ( idStrategy( ).equals( id, legacyUserDir.Name )
                                    && !idStrategy( )
                                    .filenameOf( legacyUserDir.Name )
                                    .Equals( legacyUserDir.Name ) )
                                {
                                    try
                                    {
                                        File.Move( legacyUserDir.FullName,
                                            configFile.Directory.FullName );
                                    }
                                    catch ( IOException )
                                    {
                                        LOGGER.log( Level.WARNING,
                                            "Failed to migrate user record from {0} " +
                                            "to {1}", new Object[ ] {legacyUserDir,
                                                configFile.Directory.FullName
                                            } );
                                    }
                                    break;
                                }
                            }
                            else
                            {
                                LOGGER.log( Level.FINE,
                                    "Unexpected object loaded from {0}: {1}",
                                    new object[ ] { legacyUserDir, o } );
                            }
                        }
                        catch ( IOException e )
                        {
                            LOGGER.log( Level.FINE,
                                string.Format(
                                    "Exception trying to load user from {0}: {1}",
                                    new Object[ ] { legacyUserDir, e.Message } ),
                                e );
                        }
                    }
                }
            }
            if ( u == null && ( create || configFile.Exists ) )
            {
                User tmp = new User( id, fullName );
                User prev;
                byNameLock.readLock( ).doLock( );
                try
                {
                    prev = byName.putIfAbsent( idkey, u = tmp );
                }
                finally
                {
                    byNameLock.readLock( ).unlock( );
                }
                if ( prev != null )
                {
                    u = prev; // if some has already put a value in the map, use it
                    if ( LOGGER.isLoggable( Level.FINE )
                        && !fullName.Equals( prev.getFullName( ) ) )
                    {
                        LOGGER.log( Level.FINE,
                            "mismatch on fullName (‘" + fullName + "’ vs. ‘"
                            + prev.getFullName( ) + "’) for ‘" + id + "’",
                            new Exception( ) );
                    }
                }
                else if ( !id.Equals( fullName ) && !configFile.Exists )
                {
                    // JENKINS-16332: since the fullName may not be recoverable
                    // from the id, and various code may store the id only, we
                    // must save the fullName
                    try
                    {
                        u.save( );
                    }
                    catch ( IOException x )
                    {
                        LOGGER.log( Level.WARNING, null, x );
                    }
                }
            }
            return u;
        }

        // end::getOrCreate[]

        public static class LOGGER
        {
            public static bool isLoggable( Level fine )
            {
                return false;
            }

            public static void log( params object[ ] o )
            {
            }
        }

        public class Lock
        {
            public void doLock( )
            {
            }

            public User get( string idkey )
            {
                return null;
            }

            public User putIfAbsent( string idkey, User user )
            {
                return null;
            }

            public Lock readLock( )
            {
                return null;
            }

            public void unlock( )
            {
            }
        }

        public class Strategy
        {
            public bool equals( string id, string name )
            {
                return false;
            }

            public object filenameOf( string name )
            {
                return null;
            }

            public string keyFor( string id )
            {
                return null;
            }
        }

        public class User
        {
            public User( params object[ ] o )
            {
            }

            public object getFullName( )
            {
                return null;
            }

            public void save( )
            {
            }
        }

        public class XmlFile
        {
            public static readonly object XSTREAM = new object( );

            public XmlFile( params object[ ] o )
            {
            }

            public object read( )
            {
                return null;
            }
        }
    }
}