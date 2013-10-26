namespace CadmiumBankApp.Controllers
{
    using CadmiumBankApp.DTOs;
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Xml;

    public class ExchangeRatesController : ApiController
    {
        // GET api/exchangerates
        [HttpGet]
        public IEnumerable<ExchangeRate> GetAll()
        {
            XmlReader xmlReader = XmlReader.Create("http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");
            List<ExchangeRate> exchangeRates = new List<ExchangeRate>();

            while (xmlReader.Read())
            {
                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "Cube"))
                {
                    if (xmlReader.HasAttributes)
                    {
                        string currency = xmlReader.GetAttribute("currency");
                        if (!string.IsNullOrWhiteSpace(currency))
                        {
                            float rate;
                            if (float.TryParse(xmlReader.GetAttribute("rate"), out rate))
                            {
                                exchangeRates.Add(new ExchangeRate
                                {
                                    Currency = currency,
                                    Rate = rate
                                });
                            }
                        }
                    }
                }
            }

            return exchangeRates;
        }
    }
}
