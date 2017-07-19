namespace eu.sig.training.ch07
{
    // tag::AzureCloudServerFactory[]
    public class AzureCloudServerFactory : ICloudServerFactory
    {
        public ICloudStorage CreateCloudStorage( long sizeGb )
        {
            return new AzureCloudStorage( sizeGb );
        }

        public ICloudServer LaunchComputeServer( )
        {
            return new AzureComputeServer( );
        }

        public ICloudServer LaunchDatabaseServer( )
        {
            return new AzureDatabaseServer( );
        }
    }

    // end::AzureCloudServerFactory[]
}