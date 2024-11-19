using AoC_2023_1;

namespace Tests
{
	public class AoC_2023_1_Tests
	{
		[Fact]
		public void Helper_Returns_Zero_Value_From_String()
		{
			var testVal = Helper.Read("abc");
			Assert.Equal(0, testVal);
		}

		[Fact]
		public void Helper_Returns_Zero_Value_From_Empty_String()
		{
			var testVal = Helper.Read(string.Empty);
			Assert.Equal(0, testVal);
		}

		[Theory]
		[InlineData(11, "1")]
		[InlineData(11, "11")]
		public void Helper_Returns_Value_From_Int(int expectedValue, string input)
		{
			var testVal = Helper.Read(input);
			Assert.Equal(expectedValue, testVal);
		}

		[Theory]
		[InlineData(11, "abc1")]
		[InlineData(11, "1abc")]
		[InlineData(11, "a1bc")]
		[InlineData(11, "a-1bc")]
		public void Helper_Returns_Single_Value_From_Hidden_Int(int expectedValue, string input)
		{
			var testValue = Helper.Read(input);
			Assert.Equal(expectedValue, testValue);
		}

		[Theory]
		[InlineData(11, "1abc1")]
		[InlineData(11, "a1bc1")]
		[InlineData(11, "1ab1c")]
		[InlineData(11, "a1b1c")]
		[InlineData(11, "a11bc")]
		[InlineData(11, "11abc")]
		[InlineData(11, "abc11")]
		public void Helper_Returns_Multiple_Value_From_Hidden_Int(int expectedValue, string input)
		{
			var testValue = Helper.Read(input);
			Assert.Equal(expectedValue, testValue);
		}

		[Theory]
		[InlineData(11, "12abc1")]
		[InlineData(11, "1a2bc1")]
		[InlineData(11, "1ab2c1")]
		[InlineData(11, "1abc21")]
		public void Helper_Ignores_Middle_Int(int expectedValue, string input)
		{
			var testValue = Helper.Read(input);
			Assert.Equal(expectedValue, testValue);
		}

		[Theory]
		[InlineData(29, "two1nine")]
		[InlineData(83, "eightwothree")]
		[InlineData(13, "abcone2threexyz")]
		[InlineData(24, "xtwone3four")]
		[InlineData(42, "4nineeightseven2")]
		[InlineData(14, "zoneight234")]
		[InlineData(76, "7pqrstsixteen")]
		public void Helper_Parses_Part_Two_Examples(int expectedValue, string input)
		{
			var testValue = Helper.Read(input);
			Assert.Equal(expectedValue, testValue);
		}

		[Theory]
		[InlineData(11, "one")]
		[InlineData(22, "two")]
		[InlineData(33, "three")]
		[InlineData(44, "four")]
		[InlineData(55, "five")]
		[InlineData(66, "six")]
		[InlineData(77, "seven")]
		[InlineData(88, "eight")]
		[InlineData(99, "nine")]
		public void Helper_Parses_String_Digits(int expectedValue, string input)
		{
			var testValue = Helper.Read(input);
			Assert.Equal(expectedValue, testValue);
		}

		[Theory]
		[InlineData(10, "onezero")]
		[InlineData(20, "twozero")]
		[InlineData(30, "threezero")]
		[InlineData(40, "fourzero")]
		[InlineData(50, "fivezero")]
		[InlineData(60, "sixzero")]
		[InlineData(70, "sevenzero")]
		[InlineData(80, "eightzero")]
		[InlineData(90, "ninezero")]
		public void Helper_Parses_Multiple_String_Digits(int expectedValue, string input)
		{
			var testValue = Helper.Read(input);
			Assert.Equal(expectedValue, testValue);
		}
	}
}