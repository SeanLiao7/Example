using System.Drawing;

namespace eu.sig.training.ch06.simpledigitalcamera
{
    // tag::SimpleDigitalCamera[]
    public interface ISimpleDigitalCamera
    {
        void FlashLightOff( );

        void FlashLightOn( );

        Image TakeSnapshot( );
    }

    // end::SimpleDigitalCamera[]
}