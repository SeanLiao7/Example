using System.Drawing;
using eu.sig.training.ch06.simpledigitalcamera;

namespace eu.sig.training.ch10
{
    public class PerfectPicture
    {
        // tag::takePerfectPicture[]
        public const int DAYLIGHT_START = 6;

        public static ISimpleDigitalCamera camera = null;

        public Image TakePerfectPicture( int currentHour )
        {
            Image image;
            if ( currentHour < PerfectPicture.DAYLIGHT_START )
            {
                camera.FlashLightOn( );
                image = camera.TakeSnapshot( );
                camera.FlashLightOff( );
            }
            else
            {
                image = camera.TakeSnapshot( );
            }
            return image;
        }

        // end::takePerfectPicture[]
    }
}