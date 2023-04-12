using System.Globalization;

namespace Home_Task_4_3;

public class ApartmentInformation
{
    private int _numberOfApartments;
    private int _quarter;

    public List<Apartment> ApartmentInfo(string fileName)
    {
        var lines = File.ReadAllLines(fileName);
        _numberOfApartments = int.Parse(lines[0].Split()[0]);
        _quarter = int.Parse(lines[0].Split()[1]);
        var apartments = new List<Apartment>();
        for (int i = 1; i < lines.Length; i++)
        {
            var apartmentInfo = lines[i].Split(" ");
            var apartment = new Apartment
            {
                NumberApartment = int.Parse(apartmentInfo[0]),
                UserName = apartmentInfo[2],
                IncomingDataQuarter = double.Parse(apartmentInfo[3]),
                OutputDataQuarter = double.Parse(apartmentInfo[4]),
                LastReadingDate = DateTime.ParseExact(apartmentInfo[5], "dd.MM.yy", CultureInfo.InvariantCulture)
            };
            apartments.Add(apartment);
        }
        return apartments;
    }

    public int NumberOfApartments
    {
        get { return _numberOfApartments; }
    }

    public int Quarter
    {
        get { return _quarter; }
    }

}
