namespace eu.sig.training.ch07
{
    // tag::AWSCloudServerFactory[]
    public class AWSCloudServerFactory : ICloudServerFactory
    {
        public ICloudStorage CreateCloudStorage( long sizeGb )
        {
            return new AWSCloudStorage( sizeGb );
        }

        public ICloudServer LaunchComputeServer( )
        {
            return new AWSComputeServer( );
        }

        public ICloudServer LaunchDatabaseServer( )
        {
            return new AWSDatabaseServer( );
        }
    }

    // end::AWSCloudServerFactory[]
}