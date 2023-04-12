using System.Globalization;
using System.Text;

namespace Home_Task_4_3;

public class PrintInformation
{
    const double COST_PER_KW = 1.68;

    private DateTime _date;
    private string _dateString;
    private string _monthName;
    private double _energyUsed;
    private double _cost;

    private CultureInfo _culture = new CultureInfo("uk-UA");

    private ApartmentInformation _apartmentInformation = new ApartmentInformation();

    public void PrintInfo(string fileName)
    {
        Console.OutputEncoding = UnicodeEncoding.UTF8;

        var apartments = _apartmentInformation.ApartmentInfo(fileName);

        byte answer = ReadAnswer();

        switch (answer)
        {
            case 1:
                WriteAllApartments(apartments);
                break;
            case 2:
                WriteNumberApartment(apartments);
                break;
            case 3:
                WriteBiggestDebt(apartments);
                break;
            case 4:
                WriteUserUnusedElectrical(apartments);
                break;
            default:
                Console.WriteLine("Такого варіанту немає!");
                break;
        }
    }

    private byte ReadAnswer()
    {
        Console.WriteLine("Що ви хочете дізнатися? \nВаріанти запитань: \nВсі квартири - 1 \nОдна квартира - 2 \nНайбільша забогованість - 3 " +
            "\nНомери квартир, в яких не використовувалась електроенергія - 4");
        byte answer = Convert.ToByte(Console.ReadLine());
        return answer;
    }

    #region Method Write Info

    private void WriteAllApartments(List<Apartment> apartments)
    {
        int quarter = _apartmentInformation.Quarter;
        Console.WriteLine($"Квартал {quarter} звіт про споживання електроенергії:");
        Console.WriteLine("{0,-10} {1,-25} {2,-15} {3,-25} {4,-20}", "Номер", "Власник", "Сума",
            "Останнє зняття", "Днів з останнього зняття");
        foreach (var apartment in apartments)
        {
            _date = apartment.LastReadingDate;
            _dateString = _date.ToString("dd.MM.yy");
            _monthName = _culture.DateTimeFormat.GetMonthName(_date.Month);
            GetUserDebt(apartment);

            Console.WriteLine("{0,-10} {1,-25} {2,-15:F2} {3,-25:dd.MM.yy} {4,-20}", apartment.NumberApartment,
                apartment.UserName, _cost, _monthName, (DateTime.Now - apartment.LastReadingDate).Days);
        }
    }

    private void WriteNumberApartment(List<Apartment> apartments)
    {
        Console.Write("Введіть номер квартири: ");
        int apartmentNumber = int.Parse(Console.ReadLine());

        var requestedApartment = apartments.FirstOrDefault(a => a.NumberApartment == apartmentNumber);

        _date = requestedApartment.LastReadingDate;
        _dateString = _date.ToString("dd.MM.yy");
        _monthName = _culture.DateTimeFormat.GetMonthName(_date.Month);

        GetUserDebt(requestedApartment);

        if (requestedApartment != null)
        {
            Console.WriteLine($"Інформація про квартиру №{apartmentNumber}:");
            Console.WriteLine("{0,-15} {1,-25} {2,-15}", "Власник", "Сума", "Останнє зняття");
            Console.WriteLine("{0,-15} {1,-25:F2} {2,-15:dd.MM.yy}", requestedApartment.UserName, _cost, _monthName);
        }
        else
        {
            Console.WriteLine($"Квартири з номером {apartmentNumber} не знайдено.");
        }
    }

    private void WriteBiggestDebt(List<Apartment> apartments)
    {
        foreach (var apartment in apartments)
        {
            GetUserDebt(apartment);
            apartment.Debt = _cost;
        }
        double minDebt = apartments.Min(obj => obj.Debt);
        Apartment minApartment = apartments.First(obj => obj.Debt == minDebt);
        
        Console.WriteLine($"Власник з найбільшою заборгованістю: {minApartment.UserName}, " +
                $"заборгованість: {minDebt:F2}");
    }

    private void WriteUserUnusedElectrical(List<Apartment> apartments)
    {
        foreach (var apartment in apartments)
        {
            GetUserDebt(apartment);
            if (_cost == 0)
            {
                Console.WriteLine("Номер квартири, в якій не використовувалась електроенергія: {0}", apartment.NumberApartment);
            }
        }
    }
    #endregion

    private void GetUserDebt(Apartment apartment)
    {
        _energyUsed = apartment.IncomingDataQuarter - apartment.OutputDataQuarter;
        _cost = _energyUsed * COST_PER_KW;
    }
}
