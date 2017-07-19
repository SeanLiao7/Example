using System.Drawing;
using eu.sig.training.ch06.simpledigitalcamera;
using Moq;
using NUnit.Framework;

namespace eu.sig.training.ch10
{
    [TestFixture]
    public class PerfectPictureMoqTest
    {
        // tag::testNightPictureMockito[]
        [Test]
        public void TestNightPictureMoq( )
        {
            var currentPath = System.IO.Directory.GetCurrentDirectory( );

            Image image =
                Image.FromFile( $@"{currentPath}/src/test/resources/VanGoghStarryNight.jpg" );
            var cameraMock = new Mock<ISimpleDigitalCamera>( );
            cameraMock.Setup( foo => foo.TakeSnapshot( ) ).Returns( image );
            PerfectPicture.camera = cameraMock.Object;
            Assert.AreSame( image, new PerfectPicture( ).TakePerfectPicture( 0 ) );
            cameraMock.Verify( foo => foo.FlashLightOn( ), Times.AtMostOnce( ) );
        }

        // end::testNightPictureMockito[]
    }
}