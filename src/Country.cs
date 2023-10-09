using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Net.Security;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

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

        private static readonly string url = "http://restcountries.com/v3.1";

        [Key]
        public string Alpha2Code { get => alpha2Code; set => alpha2Code = value; }
        public string Name { get => name; set => name = value; }        
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
                    string name, alpha2Code, alpha3Code, capital, region, native_name;

                    name = country_api.Country.Name != null ? country_api.Country.Name : "";
                    alpha2Code = country_api.Alpha2Code != null ? country_api.Alpha2Code : "";
                    alpha3Code = country_api.Alpha3Code != null ? country_api.Alpha3Code : "";
                    capital = country_api.Capital != null ? String.Join(", ", country_api.Capital) : "";
                    region = country_api.Region != null ? country_api.Region : "";

                    if (country_api.Country.NativeName != null)
                    {
                        var first = country_api.Country.NativeName.Languages.First();
                        native_name = country_api.Country.NativeName.Languages[first.Key].Official;
                    }
                    else
                    {
                        native_name = "";
                    }

                    var country = new Country(name, alpha2Code, alpha3Code, String.Join(", ", capital), region, native_name);

                    lista.Add(country);
	            }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return lista;
        }
        static public Country Get_country(string nombre)
        {
            Country country = null;

            try
            {
                CountryAPI country_api = Get_country_api(nombre);
                string name, alpha2Code, alpha3Code, capital, region, native_name;

                name = country_api.Country.Name ?? "";
                alpha2Code = country_api.Alpha2Code ?? "";
                alpha3Code = country_api.Alpha3Code ?? "";
                capital = country_api.Capital != null ? String.Join(", ", country_api.Capital) : "";
                region = country_api.Region ?? "";

                if (country_api.Country.NativeName != null)
                {
                    var first = country_api.Country.NativeName.Languages.First();
                    native_name = country_api.Country.NativeName.Languages[first.Key].Official;
                }
                else
                {
                    native_name = "";
                }

                country = new Country(name, alpha2Code, alpha3Code, String.Join(", ", capital), region, native_name);
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

        private static byte[] Get_flag_api(string name_country)
        {
            byte[] buffer = null;
            string apiUrl = $"{url}/name/{name_country}?fields=flags";

            var request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.UserAgent = "Mozilla/5.0";
            request.Accept = "*/*";
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

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
                                List<CountryAPI> countries;
                                string body = objReader.ReadToEnd();

                                countries = JsonConvert.DeserializeObject<List<CountryAPI>>(body);

                                if (countries.Count > 0)
                                {
                                    buffer = Donwload_flag_and_encode(countries[0].Flag.Flag);
                                }
                                else
                                {
                                    buffer = new byte[0];
                                }
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
            string nombre_archivo = "flag.svg";

            using (WebClient client = new WebClient())
            {
                try
                {
                    client.DownloadFile(new Uri(url_bandera), nombre_archivo);
                }
                catch (WebException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                buffer = System.IO.File.ReadAllBytes(nombre_archivo);

                var file = new FileInfo(nombre_archivo);

                file.Delete();
            }

            return buffer;
        }
        private static CountryAPI Get_country_api(string name)
        {
            string apiUrl = $"{url}/name/{name}";

            var request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Method = "GET";
            request.Accept = "application/json";
            request.UserAgent = "Mozilla/5.0";
            request.Accept = "*/*";
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

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
                                List<CountryAPI> countries;

                                countries = JsonConvert.DeserializeObject<List<CountryAPI>>(body);

                                if (countries.Count > 0)
                                    return countries[0];
                                else
                                    return new CountryAPI();
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
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

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

        public void Dibuja_consola()
        {
            Console.WriteLine($"País:{this.Name} | {this.Alpha2Code} | {this.Alpha3Code} | {this.Capital} | {this.Region} | {this.NativeName} ");
        }

        public bool Insert(Bd context)
        {
            bool ok = true;

            try
            {
                if (!context.Countries.Any(c => c.Alpha2Code == Alpha2Code))
                {
                    context.Countries.Add(this);
                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                ok = false;
            }

            return ok;
        }
        static public Country Read(Bd context, string alpha2Code)
        {
            Country country = null;

            try
            {
                country = context.Countries.Find(alpha2Code);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return country;
        }
        public bool Update(Bd context)
        {
            bool ok = true;

            try
            {
                if (context.Countries.Any(c=> c.alpha2Code == Alpha2Code))
                {
                    Country country;

                    country = Read(context, this.Alpha2Code);

                    if (country != null)
                    {
                        country.Name = this.Name;
                        country.alpha3Code = this.Alpha3Code;
                        country.capital = this.Capital;
                        country.region = this.Region;
                        country.nativeName = this.NativeName;

                        context.SaveChanges();
                    }
                }
            }
            catch(Exception ex)
            {
                ok = false;
            }

            return ok;
        }
        static public bool Delete(Bd context, string alpha2Code)
        {
            bool ok = true;

            try
            {
                if (context.Countries.Any(c=> c.Alpha2Code == alpha2Code))
                {
                    Country country;

                    country = Read(context, alpha2Code);

                    context.Countries.Remove(country);

                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                ok = false;
            }

            return ok;
        }        

        #endregion
    } 

    public class CountryAPI
    {
        [JsonProperty("name")]
        public CountryAPICountry Country {get; set;}

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
        [JsonConverter(typeof(NativeNameConverter))]
        public NativeName NativeName { get; set; }
    }

    public class LanguageData
    {
        public string Official { get; set; }
        public string Common { get; set; }
    }

    public class NativeName
    {
        public Dictionary<string, LanguageData> Languages { get; set; } = new Dictionary<string, LanguageData>();
    }

    public class NativeNameConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(NativeName);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var nativeName = new NativeName();

            foreach (var property in jsonObject.Properties())
            {
                var languageData = property.Value.ToObject<LanguageData>();
                nativeName.Languages[property.Name] = languageData;
            }

            return nativeName;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    public class CoutryAPIFlag
    {
        [JsonProperty("svg")]
        public string Flag { get; set; }
    }
}