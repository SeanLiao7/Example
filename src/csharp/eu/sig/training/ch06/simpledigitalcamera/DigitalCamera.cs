using System.Drawing;

namespace eu.sig.training.ch06.simpledigitalcamera
{
    // tag::DigitalCamera[]
    public class DigitalCamera : ISimpleDigitalCamera
    {
        public void FlashLightOff( )
        {
        }

        public void FlashLightOn( )
        {
        }

        // ...
        // end::DigitalCamera[]
        public Image TakeSnapshot( )
        {
            return null;
        }

        // tag::DigitalCamera[]
    }

    // end::DigitalCamera[]
}