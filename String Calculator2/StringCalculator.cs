namespace String_Calculator2 {
    public class StringCalculator {
        public int Add(string numbers) {
            string delimiter = ",";

            if (string.IsNullOrEmpty(numbers)) {
                return 0;
            }


            string[] strArray = numbers.Split("\n");

            //Has Delimiter
            if (numbers.StartsWith("//")) {
                delimiter = strArray[0].Substring(2);
                strArray = strArray.Skip(1).ToArray();
            }

            var result = strArray
                .SelectMany(s => s.Split(delimiter)
                .Select(s => ParsePositiveIntegers(s)))
                .Where(s => s <= 1000)
                .Sum();

            return result;
        }

        private int ParsePositiveIntegers(string input) {

            if (int.TryParse(input, out int result)) {

                //if (result > 1000) {
                //    return 0;
                //}
                if (result < 0) {
                    throw new ArgumentException("Negatives Not Allowed");
                }
                return result;
            }

            throw new ArgumentException("Invalid input");
        }
    }
}
