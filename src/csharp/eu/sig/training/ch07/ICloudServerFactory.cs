namespace eu.sig.training.ch07
{
    // tag::CloudServerFactory[]
    public interface ICloudServerFactory
    {
        ICloudStorage CreateCloudStorage( long sizeGb );

        ICloudServer LaunchComputeServer( );

        ICloudServer LaunchDatabaseServer( );
    }

    // end::CloudServerFactory[]
}