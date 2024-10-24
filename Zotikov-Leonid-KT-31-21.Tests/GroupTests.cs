using Zotikov_Leonid_KT_31_21.Models;

namespace Zotikov_Leonid_KT_31_21.Tests
{
    public class GroupTests
    {
        [Fact]
        public void isValidGroupName_KT3121_True()
        {
            //arrange
            var testGroup = new Group
            {
                GroupName = "KT-31-21"
            };

            //act
            var result = testGroup.IsValidGroupName();

            //assert
            Assert.True(result );
        }
    }
}