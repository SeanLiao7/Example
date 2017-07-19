using System.Drawing;
using eu.sig.training.ch06.simpledigitalcamera;
using NUnit.Framework;

namespace eu.sig.training.ch10
{
    [TestFixture]
    public class PerfectPictureTest
    {
        // tag::testDayPicture[]
        [Test]
        public void TestDayPicture( )
        {
            var currentPath = System.IO.Directory.GetCurrentDirectory( );

            var image = Image.FromFile( $@"{currentPath}/src/test/resources/VanGoghSunflowers.jpg" );
            var cameraStub = new DigitalCameraStub( );
            cameraStub.TestImage = image;
            PerfectPicture.camera = cameraStub;
            Assert.AreSame( image, new PerfectPicture( ).TakePerfectPicture( 12 ) );
        }

        // end::testDayPicture[]

        // tag::testNightPicture[]
        [Test]
        public void TestNightPicture( )
        {
            var currentPath = System.IO.Directory.GetCurrentDirectory( );

            var image = Image.FromFile( $@"{currentPath}/src/test/resources/VanGoghStarryNight.jpg" );
            var cameraMock = new DigitalCameraMock( );
            cameraMock.TestImage = image;
            PerfectPicture.camera = cameraMock;
            Assert.AreSame( image, new PerfectPicture( ).TakePerfectPicture( 0 ) );
            Assert.AreEqual( 1, cameraMock.FlashOnCounter );
        }

        // end::testNightPicture[]
    }

    // tag::DigitalCameraMock[]
    internal class DigitalCameraMock : ISimpleDigitalCamera
    {
        public int FlashOnCounter = 0;
        public Image TestImage;

        public void FlashLightOff( )
        {
        }

        public void FlashLightOn( )
        {
            this.FlashOnCounter++;
        }

        public Image TakeSnapshot( )
        {
            return this.TestImage;
        }
    }

    // tag::DigitalCameraStub[]
    internal class DigitalCameraStub : ISimpleDigitalCamera
    {
        public Image TestImage;

        public void FlashLightOff( )
        {
        }

        public void FlashLightOn( )
        {
        }

        public Image TakeSnapshot( )
        {
            return this.TestImage;
        }
    }

    // end::DigitalCameraStub[]
    // end::DigitalCameraMock[]
}