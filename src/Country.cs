using System;


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

        public Country Get_Countre_from_web()
        {
        }           

        #endregion
    }
}