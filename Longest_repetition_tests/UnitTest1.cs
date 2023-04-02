using CodeWars;

namespace Longest_repetition_tests

{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IfLengthIsNull()
        {
            //arrange
            string input = "";
            var tuple = new Tuple<char?, int>(null, 0);

            //act
            new CodeWarsLR().LongestRepetition(input);

            //assert
            Assert.AreEqual(null, tuple.Item1);
            Assert.AreEqual(0, tuple.Item2);
        }

        [TestMethod]
        public void NoIdenticalSymbols()
        {
            //arrange
            string input = "abcd";
            var tuple = new Tuple<char?, int>('a', 1);

            //act
            new CodeWarsLR().LongestRepetition(input);

            //assert
            Assert.AreEqual('a', tuple.Item1);
            Assert.AreEqual(1, tuple.Item2);
        }


        [TestMethod]
        public void FewSymbolsAtTheBeginning()
        {
            //arrange
            string input = "aaayfhpjy";
            var tuple = new Tuple<char?, int>('a', 3);

            //act
            new CodeWarsLR().LongestRepetition(input);

            //assert
            Assert.AreEqual('a', tuple.Item1);
            Assert.AreEqual(3, tuple.Item2);
        }


        [TestMethod]
        public void FewSymbolsAtTheMiddle()
        {
            //arrange
            string input = "jhyfhpbbbbiju";
            var tuple = new Tuple<char?, int>('b', 4);

            //act
            new CodeWarsLR().LongestRepetition(input);

            //assert
            Assert.AreEqual('b', tuple.Item1);
            Assert.AreEqual(4, tuple.Item2);
        }

        [TestMethod]
        public void DoubleSameSymbols()
        {
            //arrange
            string input = "aabb";
            var tuple = new Tuple<char?, int>('a', 2);

            //act
            new CodeWarsLR().LongestRepetition(input);

            //assert
            Assert.AreEqual('a', tuple.Item1);
            Assert.AreEqual(2, tuple.Item2);
        }

        [TestMethod]
        public void ThreeDoubleSameSymbols()
        {
            //arrange
            string input = "aabbcñ";
            var tuple = new Tuple<char?, int>('a', 2);

            //act
            new CodeWarsLR().LongestRepetition(input);

            //assert
            Assert.AreEqual('a', tuple.Item1);
            Assert.AreEqual(2, tuple.Item2);
        }        
        
        [TestMethod]
        public void CheckIfSymbolsAreAtTheEnd()
        {
            //arrange
            string input = "stringggg";
            var Tuple = new Tuple<char?, int>('g', 4);

            //act
            new CodeWarsLR().LongestRepetition(input);

            //assert
            Assert.AreEqual('g', Tuple.Item1);
            Assert.AreEqual(4, Tuple.Item2);
        }

        [TestMethod]
        public void FirstLittleCheck()
        {
            //arrange
            string input = "dhyyyihyyok";
            var Tuple = new Tuple<char?, int>('y', 3);
        
            //act
            new CodeWarsLR().LongestRepetition(input);
        
            //assert
            Assert.AreEqual('y', Tuple.Item1);
            Assert.AreEqual(3, Tuple.Item2);
        }


        [TestMethod]
        public void SecondLittleCheck()
        {
            //arrange
            string input = "yyyihllllllllok456uuu786opp";
            var Tuple = new Tuple<char?, int>('l', 8);

            //act
            new CodeWarsLR().LongestRepetition(input);

            //assert
            Assert.AreEqual('l', Tuple.Item1);
            Assert.AreEqual(8, Tuple.Item2);
        }

        [TestMethod]
        public void ThirdLittleCheck()
        {
            //arrange
            string input = "stringgggfdfaa";
            var Tuple = new Tuple<char?, int>('g', 4);

            //act
            new CodeWarsLR().LongestRepetition(input);

            //assert
            Assert.AreEqual('g', Tuple.Item1);
            Assert.AreEqual(4, Tuple.Item2);
        }

        [TestMethod]
        public void FourthLittleCheck()
        {
            //arrange
            string input = "stringgggfdfaaa";
            var Tuple = new Tuple<char?, int>('g', 4);

            //act
            new CodeWarsLR().LongestRepetition(input);

            //assert
            Assert.AreEqual('g', Tuple.Item1);
            Assert.AreEqual(4, Tuple.Item2);
        }

        [TestMethod]
        public void FifthLittleCheck()
        {
            //arrange
            string input = "stringgggfdfaaadryyyyyfhjdfheyoo";
            var Tuple = new Tuple<char?, int>('y', 5);

            //act
            new CodeWarsLR().LongestRepetition(input);

            //assert
            Assert.AreEqual('y', Tuple.Item1);
            Assert.AreEqual(5, Tuple.Item2);
        }
    }
}