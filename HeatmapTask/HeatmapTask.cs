namespace Names;

internal static class HeatmapTask
{
    public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
    {
        var x = new string[30];
        var y = new string[12];
        var heat = new double[30, 12];
        for (var days = 2; days <= 31; days++)
        {
            x[days - 2] = days.ToString();
        }

        for (var months = 1; months <= 12; months++)
        {
            y[months - 1] = months.ToString();
        }

        foreach (var person in names)
        {
            if (person.BirthDate.Day != 1)
            {
                var day = person.BirthDate.Day - 2;
                var month = person.BirthDate.Month - 1;
                heat[day, month] += 1;
            }
        }
        return new HeatmapData("Карта интенсивности рождаемости", heat, x, y);
    }
}