using System.Collections.Generic;

namespace eu.sig.training.ch06.userservice.v3
{
    // tag::UserService[]
    public class UserService
    {
        public void BlockUser( User user )
        {
            // ...
        }

        public User ChangeUserInfo( UserInfo userInfo )
        {
            // ...
            // end::UserService[]
            return new User( );
            // tag::UserService[]
        }

        public bool DoesUserExist( string userId )
        {
            // ...
            // end::UserService[]
            return true;
            // tag::UserService[]
        }

        public List<User> GetAllBlockedUsers( )
        {
            // ...
            // end::UserService[]
            return new List<User>( );
            // tag::UserService[]
        }

        public List<NotificationType> GetNotificationTypes( User user )
        {
            // ...
            // end::UserService[]
            return new List<NotificationType>( );
            // tag::UserService[]
        }

        public User LoadUser( string userId )
        {
            // ...
            // end::UserService[]
            return new User( );
            // tag::UserService[]
        }

        public void RegisterForNotifications( User user, NotificationType type )
        {
            // ...
        }

        public List<User> SearchUsers( UserInfo userInfo )
        {
            // ...
            // end::UserService[]
            return new List<User>( );
            // tag::UserService[]
        }

        public void UnregisterForNotifications( User user, NotificationType type )
        {
            // ...
        }
    }

    // end::UserSerice[]
}