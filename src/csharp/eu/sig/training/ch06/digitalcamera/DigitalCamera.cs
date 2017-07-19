using System.Drawing;

namespace eu.sig.training.ch06.digitalcamera
{
    // tag::DigitalCamera[]
    public class DigitalCamera
    {
        public void FlashLightOff( )
        {
            // ...
        }

        public void FlashLightOn( )
        {
            // ...
        }

        public Image TakeSnapshot( )
        {
            // ...
            // end::DigitalCamera[]
            return Image.FromFile( "" );
            // tag::DigitalCamera[]
        }
    }

    // end::DigitalCamera[]
}