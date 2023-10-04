using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Net.Security;

namespace deathwing696
{
    public class Country
    {
        #region Propiedades
        private string name;
        private string alpha2Code;
        private string alpha3Code;
        private string capital;
        private string region;
        private string nativeName;

        static private string url = "http://restcountries.com/v3.1";

        public string Name { get => name; set => name = value; }
        public string Alpha2Code { get => alpha2Code; set => alpha2Code = value; }
        public string Alpha3Code { get => alpha3Code; set => alpha3Code = value; }
        public string Capital { get => capital; set => capital = value; }
        public string Region { get => region; set => region = value; }
        public string NativeName { get => nativeName; set => nativeName = value; }
        #endregion

        #region Constructores

        public Country(string name, string alpha2Code, string alpha3Code, string capital, string region, string nativeName)
        {
            this.name = name;
            this.alpha2Code = alpha2Code;
            this.alpha3Code = alpha3Code;
            this.capital = capital;
            this.region = region;
            this.nativeName = nativeName;
        }

        #endregion

        #region Métodos públicos

        static public List<Country> Get_all_countries()
        {            
            List<Country> lista = new List<Country>();

            try
            {
                List<CountryAPI> countrys = Get_all_countries_api();

                foreach (var country_api in countrys)
	            {
                    var country = new Country(country_api.Country.Name, country_api.Alpha2Code, country_api.Alpha3Code, String.Join(", ", country_api.Capital), country_api.Region, country_api.Country.NativeName.NativeNameName.NativeName);

                    lista.Add(country);
	            }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return lista;
        }
        static public Country Get_country(string name)
        {
            Country country = null;

            try
            {
                CountryAPI country_api = Get_country_api(name);

                new Country(country_api.Country.Name, country_api.Alpha2Code, country_api.Alpha3Code, String.Join(", ", country_api.Capital), country_api.Region, country_api.Country.NativeName.NativeNameName.NativeName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return country;
        }
        static public string Get_flag(string name_country)
        {
            string bandera = null;

            try
            {
                var ruta_bandera = Get_flag_api(name_country);

                bandera = System.Convert.ToBase64String(ruta_bandera);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return bandera;
        }
        public void Dibuja_consola()
        {
            Console.WriteLine($"País:{this.Name} | {this.Alpha2Code} | {this.Alpha3Code} | {this.Capital} | {this.Region} | {this.NativeName} ");
        }

        private static byte[] Get_flag_api(string name_country)
        {
            byte[] buffer = null;
            string apiUrl = $"{url}/name/{name_country}?fields=flags";

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.UserAgent = "deathwing696";
            request.Accept = "*/*";
            request.Headers["Accept-Encoding"] = "gzip, deflate, br";
            request.Connection = "keep-alive";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader != null)
                        {
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                CountryAPI country;
                                string body = objReader.ReadToEnd();

                                country = JsonConvert.DeserializeObject<CountryAPI>(body);

                                buffer = Donwload_flag_and_encode(country.Flag.Flag);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return buffer;
        }
        private static byte[] Donwload_flag_and_encode(string url_bandera)
        {
            byte[] buffer = null;
            string temp_path = @"c:\temp\flag.svg";

            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri(url), temp_path);

                buffer = System.IO.File.ReadAllBytes(temp_path);

                var file = new FileInfo(temp_path);

                file.Delete();
            }

            return buffer;
        }
        private static CountryAPI Get_country_api(string name)
        {
            string apiUrl = $"{url}/name/{name}";

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            var request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Method = "GET";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader != null)
                        {
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                string body = objReader.ReadToEnd();

                                return JsonConvert.DeserializeObject<CountryAPI>(body);
                            }
                        }
                        else
                        {
                            return new CountryAPI();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new CountryAPI();
            }
        }
        private static List<CountryAPI> Get_all_countries_api()
        {
            string apiUrl = $"{url}/all";

            var request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.UserAgent = "Mozilla/5.0";
            request.Accept = "*/*";
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback (delegate { return true; });

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader != null)
                        {
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                string body = objReader.ReadToEnd();

                                return JsonConvert.DeserializeObject<List<CountryAPI>>(body);
                            }
                        }
                        else
                        {
                            return new List<CountryAPI>();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<CountryAPI>();
            }
        }

        #endregion
    } 

    public class CountryAPI
    {
        [JsonProperty("name")]
        public CountryAPICountry Country {get; set;}
//        public string Name { get; set; }

        [JsonProperty("cca2")]
        public string Alpha2Code { get; set; }

        [JsonProperty("cca3")]
        public string Alpha3Code { get; set; }

        [JsonProperty("capital")]
        public IList<string> Capital { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("flags")]
        public CoutryAPIFlag Flag{ get; set; }
    }

    public class CountryAPICountry
    {
        [JsonProperty("official")]
        public string Name { get; set; }

        [JsonProperty("nativeName")]
        public CountryAPINativaName NativeName { get; set; }
    }

    public class CountryAPINativaName
    {
        [JsonProperty("fra")]
        public CountryAPINativeNameName NativeNameName { get; set; }

        [JsonProperty("spa")]
        public CountryAPINativeNameName NativeNameName2 { set { NativeNameName = value; } }

        [JsonProperty("eng")]
        public CountryAPINativeNameName NativeNameName3 { set { NativeNameName = value; } }

        [JsonProperty("por")]
        public CountryAPINativeNameName NativeNameName4 { set { NativeNameName = value; } }

        [JsonProperty("swa")]
        public CountryAPINativeNameName NativeNameName5 { set { NativeNameName = value; } }

        [JsonProperty("div")]
        public CountryAPINativeNameName NativeNameName6 { set { NativeNameName = value; } }

        [JsonProperty("ber")]
        public CountryAPINativeNameName NativeNameName7 { set { NativeNameName = value; } }

        [JsonProperty("tur")]
        public CountryAPINativeNameName NativeNameName8 { set { NativeNameName = value; } }

        [JsonProperty("swe")]
        public CountryAPINativeNameName NativeNameName9 { set { NativeNameName = value; } }

        [JsonProperty("fas")]
        public CountryAPINativeNameName NativeNameName10 { set { NativeNameName = value; } }

        [JsonProperty("ind")]
        public CountryAPINativeNameName NativeNameName11 { set { NativeNameName = value; } }

        [JsonProperty("prs")]
        public CountryAPINativeNameName NativeNameName12 { set { NativeNameName = value; } }

        [JsonProperty("sqi")]
        public CountryAPINativeNameName NativeNameName13 { set { NativeNameName = value; } }

        [JsonProperty("ara")]
        public CountryAPINativeNameName NativeNameName14 { set { NativeNameName = value; } }

        [JsonProperty("khm")]
        public CountryAPINativeNameName NativeNameName15 { set { NativeNameName = value; } }

        [JsonProperty("nep")]
        public CountryAPINativeNameName NativeNameName16 { set { NativeNameName = value; } }

        [JsonProperty("tha")]
        public CountryAPINativeNameName NativeNameName17 { set { NativeNameName = value; } }

        [JsonProperty("cnr")]
        public CountryAPINativeNameName NativeNameName18 { set { NativeNameName = value; } }

        [JsonProperty("rus")]
        public CountryAPINativeNameName NativeNameName19 { set { NativeNameName = value; } }

        [JsonProperty("bul")]
        public CountryAPINativeNameName NativeNameName20 { set { NativeNameName = value; } }
    }

    public class CountryAPINativeNameName
    {
        [JsonProperty("official")]
        public string NativeName { get; set; }
    }
    public class CoutryAPIFlag
    {
        [JsonProperty("svg")]
        public string Flag { get; set; }
    }
}