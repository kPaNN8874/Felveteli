using Felveteli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Felveteli
{
    class Felvetelizo : IFelvetelizo
    {
         string OMaz;
         string neve;
         string ertCím;
         DateTime szülDatum;
         string email;
         int matekPontok;
         int magyarPontok;

        public Felvetelizo() 
        { 
            
        }
        public Felvetelizo(string OMaz, string neve, string ertCím, DateTime szülDatum, string email, int matekPontok, int magyarPontok)
        {
            this.OMaz = OMaz;
            this.neve = neve;
            this.ertCím = ertCím;
            this.szülDatum = szülDatum;
            this.email = email;
            this.matekPontok = matekPontok;
            this.magyarPontok = magyarPontok;
         
        }
        public Felvetelizo(String csvString) { }

        public string Az { get => OMaz; set => OMaz = value; }
        public string Neve { get => neve; set => neve = value; }
        public string ErtCím { get => ertCím; set => ertCím = value; }
        public DateTime SzülDatum { get => szülDatum; set => szülDatum = value; }
        public string Email { get => email; set => email = value; }
        public int MatekPontok { get => matekPontok; set => matekPontok = value; }
        public int MagyarPontok { get => magyarPontok; set => magyarPontok = value; }
        public string OM_Azonosito { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ErtesitesiCime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime SzuletesiDatum { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Matematika { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Magyar { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string CSVSortAdVissza()
        {
            throw new NotImplementedException();
        }

        public void ModositCSVSorral(string csvString)
        {
            throw new NotImplementedException();
        }
    }
}
