using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // This will store words we've already seen
        var seen = new HashSet<string>();
        // This will store the result of the final pairs
        var result = new List<string>();

        // Loop through each word in the list
        foreach (var word in words)
        {
            // Skip words like "aa"
            if (word[0] == word[1])
            {
                continue;
            }

            // Reverse the word 
            var reversed = $"{word[1]}{word[0]}";

            // Check if reversed word already exists
            if (seen.Contains(reversed))
            {
                result.Add($"{word} & {reversed}");
            }
            else
            {
                seen.Add(word);
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE

            // Get the degree (4th column → index 3)
            string degree = fields[3].Trim();

            // Check if degree already exists in dictionary
            if (degrees.ContainsKey(degree))
            {
                // If yes, increase the count
                degrees[degree]++;
            }
            else
            {
                // If not, add it with count 1
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // Step 1: Normalize both words (remove spaces + lowercase)
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        // Step 2: If lengths are different → not anagram
        if (word1.Length != word2.Length)
        {
            return false;
        }

        // Step 3: Create dictionary to count letters
        Dictionary<char, int> letterCounts = new Dictionary<char, int>();

        // Count letters in word1
        foreach (char c in word1)
        {
            if (letterCounts.ContainsKey(c))
            {
                letterCounts[c]++;
            }
            else
            {
                letterCounts[c] = 1;
            }
        }

        // Subtract using word2
        foreach (char c in word2)
        {
            if (!letterCounts.ContainsKey(c))
            {
                return false; // letter not found
            }

            letterCounts[c]--;

            if (letterCounts[c] < 0)
            {
                return false; // too many of a letter
            }
        }

        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        // STEP 1: store results
        List<string> results = new List<string>();

        // STEP 2: loop through earthquakes
        foreach (var feature in featureCollection.Features)
        {
            string place = feature.Properties.Place;
            double? mag = feature.Properties.Mag;

            // STEP 3: format string
            results.Add($"{place} - Mag {mag}");
        }

        // STEP 4: return array
        return results.ToArray();
    }
}