using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var set = new HashSet<string>(words);
        var result = new List<string>();
        var seen = new HashSet<string>();

        foreach (var w in words)
        {
            string rev = new string(new[] { w[1], w[0] });

            // skip same-letter words like "aa"
            if (w[0] == w[1]) continue;

            if (set.Contains(rev) && !seen.Contains(w) && !seen.Contains(rev))
            {
                result.Add($"{w} & {rev}");
                seen.Add(w);
                seen.Add(rev);
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");

            string degree = fields[3];

            if (!degrees.ContainsKey(degree))
                degrees[degree] = 0;

            degrees[degree]++;
        }

        return degrees;
    }

    /// <summary>
    /// Determine if two words are anagrams using a dictionary.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        string w1 = word1.Replace(" ", "").ToLower();
        string w2 = word2.Replace(" ", "").ToLower();

        if (w1.Length != w2.Length)
            return false;

        var counts = new Dictionary<char, int>();

        foreach (char c in w1)
        {
            if (!counts.ContainsKey(c))
                counts[c] = 0;
            counts[c]++;
        }

        foreach (char c in w2)
        {
            if (!counts.ContainsKey(c)) return false;

            counts[c]--;
            if (counts[c] < 0) return false;
        }

        return true;
    }

    /// <summary>
    /// Retrieve and summarize today's USGS earthquake data.
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

    var summary = new List<string>();

    foreach (var feature in featureCollection.Features)
    {
        string place = feature.Properties.Place;
        double? mag = feature.Properties.Mag;

        // FIX: replace null magnitude
        double magnitude = mag ?? 0.0;

        summary.Add($"{place} - Mag {magnitude}");
    }

    return summary.ToArray();
    }
}
