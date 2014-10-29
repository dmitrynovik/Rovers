using System;
using NUnit.Framework;
using Rovers.App;

namespace Rovers.Test
{
    [TestFixture]
    public class RoverTest
    {
        [Test]
        public void When_Input_Valid_Output_Is_Correct()
        {
            var input = @"5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM
";
            var output = @"1 3 N
5 1 E
==========";

            Assert.AreEqual(output, Execute(input));
        }

        [Test]
        [ExpectedException(typeof(RoverException))]
        public void When_Erroneous_Character_In_Input_Exception_IsThrown()
        {
            var input = @"5 5
1 2 X
LMLMLMLMM
3 3 E
MMRMMRMRRM";

            Execute(input);
        }

        [Test]
        [ExpectedException(typeof(RoverException))]
        public void When_Incomplete_Input_Exception_IsThrown()
        {
            var input = @"5";
            Execute(input);
        }

        [Test]
        [ExpectedException(typeof(RoverException))]
        public void When_Out_Of_Bounds_Exception_IsThrown()
        {
            var input = @"4 4
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM";

            Execute(input);
        }

        private string Execute(string input)
        {
            var app = new RoversApplication(input);
            return app.ToString();
        }
    }
}
