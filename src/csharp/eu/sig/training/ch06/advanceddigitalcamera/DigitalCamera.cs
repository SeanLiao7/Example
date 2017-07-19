using System.Drawing;

namespace eu.sig.training.ch06.advanceddigitalcamera
{
    // tag::DigitalCamera[]
    public class DigitalCamera
    {
        public void FlashLightOn( )
        {
            // ...
        }

        public void FlaslLightOff( )
        {
            // ...
        }

        public Video Record( )
        {
            // ...
            // end::DigitalCamera[]
            return new Video( );
            // tag::DigitalCamera[]
        }

        public void SetTimer( int seconds )
        {
            // ...
        }

        public Image TakePanoramaSnapshot( )
        {
            // end::DigitalCamera[]
            return Image.FromFile( "" );
            // tag::DigitalCamera[]
            // ...
        }

        public Image TakeSnapshot( )
        {
            // ...
            // end::DigitalCamera[]
            return Image.FromFile( "" );
            // tag::DigitalCamera[]
        }

        public void ZoomIn( )
        {
            // ...
        }

        public void ZoomOut( )
        {
            // ...
        }
    }

    // end::DigitalCamera[]
}