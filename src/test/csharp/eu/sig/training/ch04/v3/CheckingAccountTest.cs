using NUnit.Framework;

namespace eu.sig.training.ch04.v3
{
    [TestFixture]
    public class CheckingsAccountTest
    {
        private CheckingAccount counterAccount;
        private CheckingAccount myAccount;

        [SetUp]
        public void Init( )
        {
            myAccount = Accounts.MakeAccount<CheckingAccount>( "123456789" );
            counterAccount = Accounts.MakeAccount<CheckingAccount>( "497164833" );
        }

        [Test]
        public void TestTransferLimit( )
        {
            Assert.Throws( typeof( BusinessException ), ( ) =>
                {
                    myAccount.MakeTransfer( Accounts.GetAccountNumber( counterAccount ), new Money( ) );
                } );
        }
    }
}