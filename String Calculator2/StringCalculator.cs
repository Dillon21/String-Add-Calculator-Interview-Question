namespace String_Calculator2 {
    public class StringCalculator {
        public int Add(string numbers) {

            //return 0 if empty
            if (string.IsNullOrEmpty(numbers)) {
                return 0;
            }

            //split into array of 2 to capture delimiter line only
            string[] strArray = numbers.Split("\n");

            //initial delimiter, used if no custom delimiter is set
            string[] delimArray = {","};
            
            //Has Delimiter
            if (numbers.StartsWith("//[")) {
                //split multiple delimiters into array
                var tempArray = strArray[0].Split("[").Skip(1)
                  .Select(x => x.Substring(0,x.IndexOf("]")))
                  .ToList().ToArray();

                //resize delimiter array to make delimArray reuseable
                Array.Resize<string>(ref delimArray, tempArray.Length);
                delimArray = tempArray;
                strArray = strArray.Skip(1).ToArray();
            }

            //split by multiple in each number array
            var result = strArray
                .SelectMany(s => s.Split(delimArray, StringSplitOptions.None)
                .Select(s => ParsePositiveIntegers(s)))
                .Where(s => s <= 1000)
                .Sum();

                return result;
        }


        //return exception if a negative number is added
        //retun exception if value is blank
        private int ParsePositiveIntegers(string input) {

            if (int.TryParse(input, out int result)) {

                if (result < 0) {
                    throw new ArgumentException("Negatives Not Allowed");
                }
                return result;
            }

            throw new ArgumentException("Invalid input");
        }
    }
}

